using System;
using System.Globalization;
using Newtonsoft.Json;

/// <summary>
/// 无量大数：尾数 × 10^指数。范围约 ±10^(±9×10^15)，远超 double 的 1.8e308，
/// 专供放置游戏滚雪球数值（怪物血量/攻击、英雄伤害、城墙生命）使用。
/// 与 double 可直接混算：乘区等小数值保持 double 即可（operator 已重载，无需转换）。
/// 序列化走字符串（"1.234E56"），旧存档里的纯数字 token 也能读（自动兼容）。
/// </summary>
public struct BigDouble : IEquatable<BigDouble>, IComparable<BigDouble>
{
    /// <summary>尾数，规范后处于 [1,10) 或 (-10,-1] 或 0</summary>
    public double Mantissa;
    /// <summary>指数</summary>
    public long Exponent;

    public static readonly BigDouble Zero = new BigDouble { Mantissa = 0, Exponent = 0 };
    public static readonly BigDouble One = new BigDouble { Mantissa = 1, Exponent = 0 };

    // 10 的 0~17 次幂查表：加法指数对齐时用（diff>17 的小项低于 double 精度，直接忽略）
    private static readonly double[] PowersOfTen = new double[18];
    static BigDouble()
    {
        PowersOfTen[0] = 1;
        for (int i = 1; i < 18; i++) PowersOfTen[i] = PowersOfTen[i - 1] * 10;
    }

    /// <summary>热路径构造：假定尾数来自运算结果（大致 [0.1,100)），一两步修正即可归位</summary>
    private static BigDouble Fast(double mantissa, long exponent)
    {
        if (mantissa == 0 || double.IsNaN(mantissa)) return Zero;
        // ∞ 尾数（哨兵值参与运算的产物）：保持 ∞，绝不进入归位循环（否则死循环）
        if (double.IsInfinity(mantissa)) return new BigDouble { Mantissa = mantissa > 0 ? 1 : -1, Exponent = long.MaxValue };
        while (mantissa >= 10 || mantissa <= -10)
        {
            mantissa /= 10;
            if (exponent == long.MaxValue) return new BigDouble { Mantissa = mantissa > 0 ? 1 : -1, Exponent = long.MaxValue }; // 指数饱和为 ∞，不回绕
            exponent++;
        }
        while (mantissa < 1 && mantissa > -1)
        {
            mantissa *= 10;
            if (exponent == long.MinValue) return Zero; // 指数下溢饱和为 0，不回绕
            exponent--;
        }
        return new BigDouble { Mantissa = mantissa, Exponent = exponent };
    }

    /// <summary>从尾数+指数构造（读档/解析用，走对数归位保证规范）</summary>
    public BigDouble(double mantissa, long exponent)
    {
        if (mantissa == 0 || double.IsNaN(mantissa)) { Mantissa = 0; Exponent = 0; return; }
        if (double.IsInfinity(mantissa)) { Mantissa = mantissa > 0 ? 1 : -1; Exponent = long.MaxValue; return; } // (long)Log10(∞) 是未定义强转，会得到 long.MinValue 垃圾指数
        var e = Math.Floor(Math.Log10(Math.Abs(mantissa)));
        Exponent = exponent + (long)e;
        Mantissa = mantissa / Math.Pow(10, e);
        while (Math.Abs(Mantissa) >= 10) { Mantissa /= 10; Exponent++; }
        while (Math.Abs(Mantissa) < 1) { Mantissa *= 10; Exponent--; }
    }

    /// <summary>从任意 double 归位构造（走对数，用于转换/读档，不在战斗热路径上）</summary>
    public BigDouble(double value)
    {
        if (value == 0 || double.IsNaN(value)) { Mantissa = 0; Exponent = 0; return; }
        if (double.IsInfinity(value)) { Mantissa = value > 0 ? 1 : -1; Exponent = long.MaxValue; return; }
        var e = Math.Floor(Math.Log10(Math.Abs(value)));
        Mantissa = value / Math.Pow(10, e);
        Exponent = (long)e;
        // 修正浮点误差导致的越界
        while (Math.Abs(Mantissa) >= 10) { Mantissa /= 10; Exponent++; }
        while (Math.Abs(Mantissa) < 1) { Mantissa *= 10; Exponent--; }
    }

    // ---- 与 double 互转 ----
    public static implicit operator BigDouble(double value) => new BigDouble(value);
    /// <summary>转 double：超出范围的按无穷/0 处理（只用于显示比例等小值场景）</summary>
    public static explicit operator double(BigDouble value)
    {
        if (value.Mantissa == 0) return 0;
        if (value.Exponent > 308) return value.Mantissa > 0 ? double.PositiveInfinity : double.NegativeInfinity;
        if (value.Exponent < -308) return 0;
        return value.Mantissa * Math.Pow(10, value.Exponent);
    }

    // ---- 运算 ----
    public static BigDouble operator +(BigDouble a, BigDouble b)
    {
        if (a.Mantissa == 0) return b;
        if (b.Mantissa == 0) return a;
        if (a.Exponent == b.Exponent) return Fast(a.Mantissa + b.Mantissa, a.Exponent);
        if (a.Exponent > b.Exponent)
        {
            var diff = a.Exponent - b.Exponent;
            if (diff > 17) return a; // 小项低于精度，忽略
            return Fast(a.Mantissa + b.Mantissa / PowersOfTen[diff], a.Exponent);
        }
        else
        {
            var diff = b.Exponent - a.Exponent;
            if (diff > 17) return b;
            return Fast(b.Mantissa + a.Mantissa / PowersOfTen[diff], b.Exponent);
        }
    }

    public static BigDouble operator -(BigDouble a, BigDouble b) => a + new BigDouble { Mantissa = -b.Mantissa, Exponent = b.Exponent };
    public static BigDouble operator -(BigDouble a) => new BigDouble { Mantissa = -a.Mantissa, Exponent = a.Exponent };

    /// <summary>乘法热路径：两个规范尾数之积 ∈ [1,100)，一步归位，零对数调用</summary>
    public static BigDouble operator *(BigDouble a, BigDouble b)
    {
        // ∞ 哨兵参与乘法：指数相加会溢出回绕，必须短路成饱和结果
        if (a.Exponent == long.MaxValue || b.Exponent == long.MaxValue)
        {
            double m = a.Mantissa * b.Mantissa;
            if (m == 0) return new BigDouble { Mantissa = double.NaN, Exponent = 0 }; // 0×∞ = NaN
            return new BigDouble { Mantissa = m > 0 ? 1 : -1, Exponent = long.MaxValue };
        }
        return Fast(a.Mantissa * b.Mantissa, a.Exponent + b.Exponent);
    }

    /// <summary>大数 × 小乘区（百分比增幅等），最常用的热路径</summary>
    public static BigDouble operator *(BigDouble a, double b) => Fast(a.Mantissa * b, a.Exponent);
    public static BigDouble operator *(double a, BigDouble b) => Fast(b.Mantissa * a, b.Exponent);

    public static BigDouble operator /(BigDouble a, BigDouble b)
    {
        // ∞ 哨兵参与除法：指数相减同样会回绕，先短路
        if (a.Exponent == long.MaxValue)
        {
            if (b.Exponent == long.MaxValue) return new BigDouble { Mantissa = double.NaN, Exponent = 0 }; // ∞/∞ = NaN
            return new BigDouble { Mantissa = a.Mantissa > 0 == b.Mantissa > 0 ? 1 : -1, Exponent = long.MaxValue };
        }
        if (b.Exponent == long.MaxValue) return Zero; // 有限大数 / ∞ = 0
        if (b.Mantissa == 0)
        {
            // IEEE 语义（与 double 一致）：x/0 = ±∞，0/0 = NaN。
            // 老代码里血条/护盾/比例等显示层有大量"除零不炸"的隐含依赖，抛异常会在战斗现场直接崩
            if (a.Mantissa == 0 || double.IsNaN(a.Mantissa)) return new BigDouble { Mantissa = double.NaN, Exponent = 0 };
            return new BigDouble { Mantissa = a.Mantissa > 0 ? 1 : -1, Exponent = long.MaxValue };
        }
        return Fast(a.Mantissa / b.Mantissa, a.Exponent - b.Exponent);
    }
    public static BigDouble operator /(BigDouble a, double b)
    {
        if (b == 0)
        {
            if (a.Mantissa == 0 || double.IsNaN(a.Mantissa)) return new BigDouble { Mantissa = double.NaN, Exponent = 0 };
            return new BigDouble { Mantissa = a.Mantissa > 0 ? 1 : -1, Exponent = long.MaxValue };
        }
        return Fast(a.Mantissa / b, a.Exponent);
    }
    public static BigDouble operator /(double a, BigDouble b) => (BigDouble)a / b;

    // ---- 比较 ----
    public int CompareTo(BigDouble other)
    {
        if (Mantissa == 0 && other.Mantissa == 0) return 0;
        if (Mantissa == 0) return other.Mantissa > 0 ? -1 : 1;
        if (other.Mantissa == 0) return Mantissa > 0 ? 1 : -1;
        if (Mantissa > 0 && other.Mantissa < 0) return 1;
        if (Mantissa < 0 && other.Mantissa > 0) return -1;
        // 同号：指数大者大
        if (Exponent != other.Exponent) return Exponent > other.Exponent ? 1 : -1;
        return Mantissa.CompareTo(other.Mantissa);
    }

    public static bool operator <(BigDouble a, BigDouble b) => a.CompareTo(b) < 0;
    public static bool operator >(BigDouble a, BigDouble b) => a.CompareTo(b) > 0;
    public static bool operator <=(BigDouble a, BigDouble b) => a.CompareTo(b) <= 0;
    public static bool operator >=(BigDouble a, BigDouble b) => a.CompareTo(b) >= 0;
    public static bool operator ==(BigDouble a, BigDouble b) => a.Mantissa == b.Mantissa && a.Exponent == b.Exponent;
    public static bool operator !=(BigDouble a, BigDouble b) => !(a == b);

    public bool Equals(BigDouble other) => this == other;
    public override bool Equals(object obj) => obj is BigDouble other && this == other;
    public override int GetHashCode() => Mantissa.GetHashCode() ^ (Exponent * 397).GetHashCode();

    // ---- 数学 ----
    public static BigDouble Max(BigDouble a, BigDouble b) => a >= b ? a : b;
    public static BigDouble Min(BigDouble a, BigDouble b) => a <= b ? a : b;
    public static BigDouble Abs(BigDouble a) => a.Mantissa < 0 ? new BigDouble { Mantissa = -a.Mantissa, Exponent = a.Exponent } : a;

    /// <summary>10 的任意次幂（指数可以是任意 double，支持 1.5^n 这类大幂数换底）</summary>
    public static BigDouble Pow10(double power)
    {
        if (power == 0) return One;
        var e = Math.Floor(power);
        return Fast(Math.Pow(10, power - e), (long)e);
    }

    /// <summary>幂运算：value^power = 10^(log10(value)×power)，支持超大幂</summary>
    public static BigDouble Pow(BigDouble value, double power)
    {
        if (value.Mantissa == 0) return Zero;
        if (power == 0) return One;
        return Pow10(Log10(value) * power);
    }

    /// <summary>常用对数（返回 double，大数的 log10 天然在 double 范围内）</summary>
    public static double Log10(BigDouble value)
    {
        if (value.Mantissa <= 0) return double.NaN;
        return value.Exponent + Math.Log10(value.Mantissa);
    }

    // ---- 显示与解析 ----
    /// <summary>规范字符串 "1.234E56"（往返无损）</summary>
    public override string ToString()
    {
        if (Mantissa == 0) return "0";
        return Mantissa.ToString("R", CultureInfo.InvariantCulture) + "E" + Exponent;
    }

    /// <summary>解析 "1.234E56"、"1.234E+56"、纯小数均可；旧存档数字经 ToString 后也走这里</summary>
    public static BigDouble Parse(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return Zero;
        s = s.Trim();
        var idx = s.IndexOf('E');
        if (idx < 0) return new BigDouble(double.Parse(s, CultureInfo.InvariantCulture));
        var m = double.Parse(s.Substring(0, idx), CultureInfo.InvariantCulture);
        var e = long.Parse(s.Substring(idx + 1), CultureInfo.InvariantCulture);
        return new BigDouble(m, e);
    }
}

/// <summary>
/// BigDouble 的 Newtonsoft 序列化：写成规范字符串，读时兼容字符串/数字/整数三种 token
/// （旧存档里 double 时代的字段是纯数字，读入自动转换，零迁移成本）
/// </summary>
public class BigDoubleJsonConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((BigDouble)value).ToString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        switch (reader.TokenType)
        {
            case JsonToken.String:
                return BigDouble.Parse((string)reader.Value);
            case JsonToken.Float:
                return new BigDouble((double)reader.Value);
            case JsonToken.Integer:
                return new BigDouble((double)(long)reader.Value);
            case JsonToken.Null:
                return BigDouble.Zero;
        }
        throw new JsonSerializationException($"无法将 {reader.TokenType} 转换为 BigDouble");
    }

    public override bool CanConvert(Type objectType) => objectType == typeof(BigDouble);
}

/// <summary>
/// 进程启动即安装全局 JsonConverter：所有不带显式 settings 的 JsonConvert 调用
/// （如 StartWindow 读档）自动获得 BigDouble 支持；带显式 settings 的调用需手动挂。
/// </summary>
public static class BigDoubleBootstrap
{
    [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void 安装全局序列化设置()
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            Converters = { new BigDoubleJsonConverter() }
        };
    }
}
