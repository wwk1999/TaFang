using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 法器打造Item
{
    public 法器Type 法器Type;
    public QualityType 品质;
    public int 阶数;
    public int count;
    public float 进度;
}

/// <summary>
/// 法器基础类型（仅含职业+部位，不含品质和阶数）
/// </summary>
public enum 法器Type
{
    None,

    // ============== 1. 战士 ==============
    战士武器,
    战士头盔,
    战士衣服,
    战士鞋子,

    // ============== 2. 控制 ==============
    控制武器,
    控制头盔,
    控制衣服,
    控制鞋子,

    // ============== 3. 辅助 ==============
    辅助武器,
    辅助头盔,
    辅助衣服,
    辅助鞋子,

    // ============== 4. 射手 ==============
    射手武器,
    射手头盔,
    射手衣服,
    射手鞋子,

    // ============== 5. 法师 ==============
    法师武器,
    法师头盔,
    法师衣服,
    法师鞋子,
}

public class 法器附加属性品质type
{
    public 法器附加属性Type 法器附加属性Type { get; set; }
    public int 阶数 { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        法器附加属性品质type other = (法器附加属性品质type)obj;
        return 法器附加属性Type == other.法器附加属性Type && 阶数 == other.阶数;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + 法器附加属性Type.GetHashCode();
            hash = hash * 31 + 阶数.GetHashCode();
            return hash;
        }
    }
}

public enum 法器附加属性Type
{
    None,
    暴击率,
    暴击伤害,
    火焰伤害,
    雷电伤害,
    黑暗伤害,
    冰霜伤害,
    物理伤害,
    最终伤害,
    普通怪增伤,
    精英怪增伤,
    首领怪增伤,
    火焰穿透,
    雷电穿透,
    物理穿透,
    冰霜穿透,
    黑暗穿透,
}

public enum 法器类型
{
    None,
    武器,
    衣服,
    头盔,
    鞋子,
}

public class 法器附加属性值
{
    public 法器附加属性Type 法器附加属性Type;
    public float count;
    public bool 锁 = false;
    public bool 无暇 = false;
}

public class 法器
{
    public 法器Type 法器Type;
    public QualityType 品质;
    public int 阶数;
    public List<法器附加属性值> list = new List<法器附加属性值>();
    public List<仙石> 仙石list = new List<仙石>();
    public HeroType HeroType = HeroType.None;
    public 符文 符文 = new 符文();
    public int 魂器等级;
    public float 魂器经验;
}

public class 法器属性
{
    public float 暴击率;
    public float 暴击伤害;
    public float 火焰伤害;
    public float 雷电伤害;
    public float 黑暗伤害;
    public float 冰霜伤害;
    public float 物理伤害;
    public float 最终伤害;
    public float 普通怪增伤;
    public float 精英怪增伤;
    public float 首领怪增伤;
    public float 火焰穿透;
    public float 雷电穿透;
    public float 物理穿透;
    public float 冰霜穿透;
    public float 黑暗穿透;

    public static 法器属性 operator +(法器属性 a, 法器属性 b)
    {
        if (a == null || b == null) return null;
        return new 法器属性
        {
            暴击率 = a.暴击率 + b.暴击率,
            暴击伤害 = a.暴击伤害 + b.暴击伤害,
            火焰伤害 = a.火焰伤害 + b.火焰伤害,
            雷电伤害 = a.雷电伤害 + b.雷电伤害,
            黑暗伤害 = a.黑暗伤害 + b.黑暗伤害,
            冰霜伤害 = a.冰霜伤害 + b.冰霜伤害,
            物理伤害 = a.物理伤害 + b.物理伤害,
            最终伤害 = a.最终伤害 + b.最终伤害,
            普通怪增伤 = a.普通怪增伤 + b.普通怪增伤,
            精英怪增伤 = a.精英怪增伤 + b.精英怪增伤,
            首领怪增伤 = a.首领怪增伤 + b.首领怪增伤,
            火焰穿透 = a.火焰穿透 + b.火焰穿透,
            雷电穿透 = a.雷电穿透 + b.雷电穿透,
            物理穿透 = a.物理穿透 + b.物理穿透,
            冰霜穿透 = a.冰霜穿透 + b.冰霜穿透,
            黑暗穿透 = a.黑暗穿透 + b.黑暗穿透,
        };
    }

    public static 法器属性 operator *(法器属性 a, float scalar)
    {
        if (a == null) return null;
        return new 法器属性
        {
            暴击率 = a.暴击率 * scalar,
            暴击伤害 = a.暴击伤害 * scalar,
            火焰伤害 = a.火焰伤害 * scalar,
            雷电伤害 = a.雷电伤害 * scalar,
            黑暗伤害 = a.黑暗伤害 * scalar,
            冰霜伤害 = a.冰霜伤害 * scalar,
            物理伤害 = a.物理伤害 * scalar,
            最终伤害 = a.最终伤害 * scalar,
            普通怪增伤 = a.普通怪增伤 * scalar,
            精英怪增伤 = a.精英怪增伤 * scalar,
            首领怪增伤 = a.首领怪增伤 * scalar,
            火焰穿透 = a.火焰穿透 * scalar,
            雷电穿透 = a.雷电穿透 * scalar,
            物理穿透 = a.物理穿透 * scalar,
            冰霜穿透 = a.冰霜穿透 * scalar,
            黑暗穿透 = a.黑暗穿透 * scalar,
        };
    }

    public static 法器属性 operator *(float scalar, 法器属性 a)
    {
        return a * scalar;
    }

    public void 清零()
    {
        暴击率 = 0;
        暴击伤害 = 0;
        火焰伤害 = 0;
        雷电伤害 = 0;
        黑暗伤害 = 0;
        冰霜伤害 = 0;
        物理伤害 = 0;
        最终伤害 = 0;
        普通怪增伤 = 0;
        精英怪增伤 = 0;
        首领怪增伤 = 0;
        火焰穿透 = 0;
        雷电穿透 = 0;
        物理穿透 = 0;
        冰霜穿透 = 0;
        黑暗穿透 = 0;
    }
}

public enum 法器材料Type
{
    None,
    铁,
    石,
    羽,
    砂,
}

public class 法器材料
{
    public 法器材料Type 法器材料Type;
    public int 阶数;
}

public class 法器Config
{
    // ==================== 概率与倍率 ====================

    /// <summary>
    /// 法器打造品质概率（万分比，从荒品到黄品顺序）
    /// </summary>
    public static List<float> 法器打造品质概率 = new List<float>() { 10000, 3000, 1000, 500, 300, 100, 10f, 1f };

    /// <summary>
    /// 法器品质倍率（基础值乘此倍率）
    /// </summary>
    public static Dictionary<QualityType, float> 法器品质倍率 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品 ,1},
        { QualityType.玄品 ,1.5f},
        { QualityType.地品 ,2},
        { QualityType.天品 ,3},
        { QualityType.宇品 ,5},
        { QualityType.宙品 ,10},
        { QualityType.洪品 ,100},
        { QualityType.荒品 ,1000},
    };

    public static Dictionary<法器类型, string> 法器类型String = new Dictionary<法器类型, string>()
    {
        { 法器类型.头盔 ,"头盔"},
        { 法器类型.武器 ,"武器"},
        { 法器类型.衣服 ,"衣服"},
        { 法器类型.鞋子 ,"鞋子"},
    };

    public static Dictionary<QualityType, float> 法器打造时间 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品 ,0.01f},
        { QualityType.玄品 ,0.02f},
        { QualityType.地品 ,0.05f},
        { QualityType.天品 ,0.12f},
        { QualityType.宇品 ,0.25f},
        { QualityType.宙品 ,0.5f},
        { QualityType.洪品 ,1.5f},
        { QualityType.荒品 ,6f},
    };

    // ==================== 材料配置 ====================

    public static Dictionary<法器类型, List<法器材料Type>> 法器材料Dic = new Dictionary<法器类型, List<法器材料Type>>()
    {
        { 法器类型.武器 ,new List<法器材料Type>() { 法器材料Type.铁 ,法器材料Type.石}},
        { 法器类型.衣服 ,new List<法器材料Type>() { 法器材料Type.羽 ,法器材料Type.砂}},
        { 法器类型.头盔 ,new List<法器材料Type>() { 法器材料Type.铁 ,法器材料Type.砂}},
        { 法器类型.鞋子 ,new List<法器材料Type>() { 法器材料Type.羽 ,法器材料Type.石}},
    };

    public static Dictionary<法器材料Type, string[]> 材料名称 = new Dictionary<法器材料Type, string[]>()
    {
        { 法器材料Type.铁, new[]{ "凡铁", "精铁", "玄铁", "寒铁", "地火精金", "星辰铁", "鸿蒙紫铁", "混沌神铁", "太虚玄铁", "鸿蒙精铁", "混沌原铁", "造化神铁", "太初玄铁", "先天道铁", "无极圣铁", "大道仙铁" } },
        { 法器材料Type.砂, new[]{ "粗砂", "细砂", "灵砂", "星辰砂", "地脉砂", "玄天砂", "鸿蒙砂", "混沌砂", "太虚灵砂", "鸿蒙精砂", "混沌原砂", "造化神砂", "太初元砂", "先天道砂", "无极圣砂", "大道仙砂" } },
        { 法器材料Type.石, new[]{ "青石", "硬石", "灵玉", "玄龟石", "地脉晶", "星辰石", "鸿蒙石", "混沌石", "太虚灵石", "鸿蒙晶石", "混沌原石", "造化神石", "太初元石", "先天道石", "无极圣石", "大道仙石" } },
        { 法器材料Type.羽, new[]{ "凡羽", "轻羽", "风灵羽", "云纹羽", "灵鹤羽", "鲲鹏羽", "鸿蒙羽", "混沌羽", "太虚无羽", "鸿蒙精羽", "混沌原羽", "造化神羽", "太初元羽", "先天道羽", "无极圣羽", "大道仙羽" } },
    };

    public static string Get法器材料Name(法器材料Type 法器材料Type, int 阶数)
    {
        if (阶数 < 1 || 阶数 > 16) return string.Empty;
        if (材料名称.TryGetValue(法器材料Type, out var names))
        {
            return names[阶数 - 1];
        }
        return string.Empty;
    }

    /// <summary>阶数对应的显示品质档位：1~8阶对应黄品~荒品，9阶以上沿用荒品表现</summary>
    public static QualityType Get阶数对应品质(int 阶数)
    {
        return (QualityType)Mathf.Clamp(阶数, 1, 8);
    }

    /// <summary>法器显示名称：基础名 + 阶数，如「巨剑3阶」</summary>
    public static string Get法器Name(法器Type type, int 阶数)
    {
        if (法器名Dic.TryGetValue(type, out var name)) return name + 阶数 + "阶";
        return string.Empty;
    }

    /// <summary>
    /// 获取打造指定法器（按阶数）所需的材料PropType列表
    /// 每种材料按阶数取 石N/铁N/羽N/砂N，每件每种材料各1个
    /// </summary>
    public static List<PropType> Get打造法器材料(法器Type type, int 阶数)
    {
        List<PropType> result = new List<PropType>();
        if (!法器类型Dic.TryGetValue(type, out var 法器类型)) return result;
        if (!法器材料Dic.TryGetValue(法器类型, out var 材料List)) return result;

        foreach (var 材料类型 in 材料List)
        {
            string propName = 材料类型.ToString() + 阶数;
            if (Enum.IsDefined(typeof(PropType), propName))
            {
                result.Add((PropType)Enum.Parse(typeof(PropType), propName));
            }
        }

        return result;
    }

    public static int Get最大打造数量(法器Type type, int 阶数)
    {
        if (type == 法器Type.None) return 0;
        int 最大数量 = int.MaxValue;
        foreach (var propType in Get打造法器材料(type, 阶数))
        {
            PlayerData.S.PropListDic.TryGetValue(propType, out float count);
            最大数量 = Math.Min(最大数量, Mathf.FloorToInt(count));
        }
        return 最大数量 == int.MaxValue ? 0 : 最大数量;
    }

    // ==================== 基础属性 ====================

    /// <summary>
    /// 16阶法器的基础最终伤害值（品质倍率在外层乘）
    /// </summary>
    public static Dictionary<int, float> 法器基础属性Dic = new Dictionary<int, float>()
    {
        { 1, 10 },
        { 2, 20 },
        { 3, 30 },
        { 4, 50 },
        { 5, 80 },
        { 6, 120 },
        { 7, 180 },
        { 8, 300 },
        { 9, 450 },
        { 10, 650 },
        { 11, 900 },
        { 12, 1200 },
        { 13, 1600 },
        { 14, 2100 },
        { 15, 2800 },
        { 16, 3600 },
    };

    public static float Get法器基础伤害(int 阶数, QualityType 品质)
    {
        if (法器基础属性Dic.TryGetValue(阶数, out var 基础值) && 法器品质倍率.TryGetValue(品质, out var 倍率))
        {
            return 基础值 * 倍率;
        }
        return 0;
    }

    // ==================== 法器属性计算 ====================

    public static 法器属性 Get英雄法器属性(HeroType heroType)
    {
        法器属性 法器属性 = new 法器属性();
        法器属性 衣服属性 = Get法器属性(PlayerData.S.HeroDataDic[heroType].衣服);
        法器属性 头盔属性 = Get法器属性(PlayerData.S.HeroDataDic[heroType].头盔);
        法器属性 鞋子属性 = Get法器属性(PlayerData.S.HeroDataDic[heroType].鞋子);
        法器属性 武器属性 = Get法器属性(PlayerData.S.HeroDataDic[heroType].武器);
        法器属性 = 衣服属性 + 头盔属性 + 鞋子属性 + 武器属性;
        return 法器属性 * (1f + 体质Config.当前体质总属性.法器效果加成 / 100f);
    }

    public static 法器属性 Get法器属性(法器 法器)
    {
        法器属性 法器属性 = new 法器属性();
        if (法器 == null) return 法器属性;

        // 基础伤害 = 阶数基础值 × 品质倍率
        法器属性.最终伤害 += Get法器基础伤害(法器.阶数, 法器.品质);

        // 无暇套装加成
        int count = 0;
        float 无暇加成 = 0;
        foreach (var item in 法器.list)
        {
            if (item != null && item.无暇) count++;
        }
        if (count >= 8) 无暇加成 = EquipConfig.无暇套装加成3 / 100f;
        else if (count >= 6) 无暇加成 = EquipConfig.无暇套装加成2 / 100f;
        else if (count >= 4) 无暇加成 = EquipConfig.无暇套装加成1 / 100f;

        foreach (var item in 法器.list)
        {
            if (item == null) continue;
            float 品质倍率 = 法器品质倍率[法器.品质];
            switch (item.法器附加属性Type)
            {
                case 法器附加属性Type.暴击率:
                    法器属性.暴击率 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.暴击伤害:
                    法器属性.暴击伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.火焰伤害:
                    法器属性.火焰伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.雷电伤害:
                    法器属性.雷电伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.黑暗伤害:
                    法器属性.黑暗伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.冰霜伤害:
                    法器属性.冰霜伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.物理伤害:
                    法器属性.物理伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.最终伤害:
                    法器属性.最终伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.普通怪增伤:
                    法器属性.普通怪增伤 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.精英怪增伤:
                    法器属性.精英怪增伤 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.首领怪增伤:
                    法器属性.首领怪增伤 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.火焰穿透:
                    法器属性.火焰穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.雷电穿透:
                    法器属性.雷电穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.物理穿透:
                    法器属性.物理穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.冰霜穿透:
                    法器属性.冰霜穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.黑暗穿透:
                    法器属性.黑暗穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1f + 无暇加成) * (1f + 法器.魂器等级 / 100f);
                    break;
                case 法器附加属性Type.None:
                default:
                    break;
            }
        }

        // 仙石加成
        float 仙石效果 = 仙石Config.Get法器仙石效果(法器);
        foreach (var 仙石 in 法器.仙石list)
        {
            if (仙石.type == 仙石Type.None) continue;
            foreach (var item in 仙石.list)
            {
                if (item == null) continue;
                float 品质倍率 = 法器品质倍率[法器.品质];
                switch (item.法器附加属性Type)
                {
                    case 法器附加属性Type.暴击率:
                        法器属性.暴击率 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.暴击伤害:
                        法器属性.暴击伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.火焰伤害:
                        法器属性.火焰伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.雷电伤害:
                        法器属性.雷电伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.黑暗伤害:
                        法器属性.黑暗伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.冰霜伤害:
                        法器属性.冰霜伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.物理伤害:
                        法器属性.物理伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.最终伤害:
                        法器属性.最终伤害 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.普通怪增伤:
                        法器属性.普通怪增伤 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.精英怪增伤:
                        法器属性.精英怪增伤 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.首领怪增伤:
                        法器属性.首领怪增伤 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.火焰穿透:
                        法器属性.火焰穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.雷电穿透:
                        法器属性.雷电穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.物理穿透:
                        法器属性.物理穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.冰霜穿透:
                        法器属性.冰霜穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    case 法器附加属性Type.黑暗穿透:
                        法器属性.黑暗穿透 += item.count * 品质倍率 * (item.无暇 ? (1f + EquipConfig.无暇词条加成) : 1f) * (1 + 仙石效果 / 100f) * (1f + 法器.魂器等级 / 100f);
                        break;
                    default:
                        break;
                }
            }
        }

        return 法器属性;
    }

    // ==================== 法器Type → 法器类型（部位） ====================

    public static Dictionary<法器Type, 法器类型> 法器类型Dic = new Dictionary<法器Type, 法器类型>()
    {
        // 战士
        { 法器Type.战士武器, 法器类型.武器 },
        { 法器Type.战士头盔, 法器类型.头盔 },
        { 法器Type.战士衣服, 法器类型.衣服 },
        { 法器Type.战士鞋子, 法器类型.鞋子 },
        // 控制
        { 法器Type.控制武器, 法器类型.武器 },
        { 法器Type.控制头盔, 法器类型.头盔 },
        { 法器Type.控制衣服, 法器类型.衣服 },
        { 法器Type.控制鞋子, 法器类型.鞋子 },
        // 辅助
        { 法器Type.辅助武器, 法器类型.武器 },
        { 法器Type.辅助头盔, 法器类型.头盔 },
        { 法器Type.辅助衣服, 法器类型.衣服 },
        { 法器Type.辅助鞋子, 法器类型.鞋子 },
        // 射手
        { 法器Type.射手武器, 法器类型.武器 },
        { 法器Type.射手头盔, 法器类型.头盔 },
        { 法器Type.射手衣服, 法器类型.衣服 },
        { 法器Type.射手鞋子, 法器类型.鞋子 },
        // 法师
        { 法器Type.法师武器, 法器类型.武器 },
        { 法器Type.法师头盔, 法器类型.头盔 },
        { 法器Type.法师衣服, 法器类型.衣服 },
        { 法器Type.法师鞋子, 法器类型.鞋子 },
    };

    // ==================== 附加属性描述 ====================

    public static Dictionary<法器附加属性Type, string> 法器附加属性Desc = new Dictionary<法器附加属性Type, string>()
    {
        { 法器附加属性Type.None, "无属性" },
        { 法器附加属性Type.暴击率, "暴击率" },
        { 法器附加属性Type.暴击伤害, "暴击伤害" },
        { 法器附加属性Type.火焰伤害, "火焰伤害" },
        { 法器附加属性Type.雷电伤害, "雷电伤害" },
        { 法器附加属性Type.黑暗伤害, "黑暗伤害" },
        { 法器附加属性Type.冰霜伤害, "冰霜伤害" },
        { 法器附加属性Type.物理伤害, "物理伤害" },
        { 法器附加属性Type.最终伤害, "最终伤害" },
        { 法器附加属性Type.普通怪增伤, "普通怪增伤" },
        { 法器附加属性Type.精英怪增伤, "精英怪增伤" },
        { 法器附加属性Type.首领怪增伤, "首领怪增伤" },
        { 法器附加属性Type.火焰穿透, "火焰穿透" },
        { 法器附加属性Type.雷电穿透, "雷电穿透" },
        { 法器附加属性Type.物理穿透, "物理穿透" },
        { 法器附加属性Type.冰霜穿透, "冰霜穿透" },
        { 法器附加属性Type.黑暗穿透, "黑暗穿透" },
    };

    // ==================== 消耗/分解（品质维度保持不变） ====================

    public static Dictionary<QualityType, int> 法器洗练消耗Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,100},
        { QualityType.玄品 ,300},
        { QualityType.地品 ,1000},
        { QualityType.天品 ,3000},
        { QualityType.宇品 ,10000},
        { QualityType.宙品 ,30000},
        { QualityType.洪品 ,100000},
        { QualityType.荒品 ,500000},
    };

    public static Dictionary<QualityType, int> 法器分解Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,100},
        { QualityType.玄品 ,300},
        { QualityType.地品 ,1000},
        { QualityType.天品 ,3000},
        { QualityType.宇品 ,10000},
        { QualityType.宙品 ,30000},
        { QualityType.洪品 ,100000},
        { QualityType.荒品 ,500000},
    };

    public static Dictionary<QualityType, int> 法器材料分解粉尘Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,20},
        { QualityType.玄品 ,60},
        { QualityType.地品 ,200},
        { QualityType.天品 ,600},
        { QualityType.宇品 ,2000},
        { QualityType.宙品 ,6000},
        { QualityType.洪品 ,20000},
        { QualityType.荒品 ,100000},
    };

    // ==================== 法器职业 ====================

    public static Dictionary<法器Type, ZhiYeType> 法器职业Dic = new Dictionary<法器Type, ZhiYeType>()
    {
        { 法器Type.战士武器, ZhiYeType.战士 },
        { 法器Type.战士头盔, ZhiYeType.战士 },
        { 法器Type.战士衣服, ZhiYeType.战士 },
        { 法器Type.战士鞋子, ZhiYeType.战士 },

        { 法器Type.控制武器, ZhiYeType.控制 },
        { 法器Type.控制头盔, ZhiYeType.控制 },
        { 法器Type.控制衣服, ZhiYeType.控制 },
        { 法器Type.控制鞋子, ZhiYeType.控制 },

        { 法器Type.辅助武器, ZhiYeType.辅助 },
        { 法器Type.辅助头盔, ZhiYeType.辅助 },
        { 法器Type.辅助衣服, ZhiYeType.辅助 },
        { 法器Type.辅助鞋子, ZhiYeType.辅助 },

        { 法器Type.射手武器, ZhiYeType.射手 },
        { 法器Type.射手头盔, ZhiYeType.射手 },
        { 法器Type.射手衣服, ZhiYeType.射手 },
        { 法器Type.射手鞋子, ZhiYeType.射手 },

        { 法器Type.法师武器, ZhiYeType.法师 },
        { 法器Type.法师头盔, ZhiYeType.法师 },
        { 法器Type.法师衣服, ZhiYeType.法师 },
        { 法器Type.法师鞋子, ZhiYeType.法师 },
    };

    // ==================== 法器描述（基础描述，不含品质） ====================

    public static Dictionary<法器Type, string> 法器descDic = new Dictionary<法器Type, string>()
    {
        // 战士
        { 法器Type.战士武器, "战士所使用的巨剑，分量极沉，有开天辟地之能。" },
        { 法器Type.战士头盔, "战士所佩戴的重盔，坚固无比，能抵御致命一击。" },
        { 法器Type.战士衣服, "战士所穿的重甲，铁甲铮铮，护体如盾。" },
        { 法器Type.战士鞋子, "战士所着的战靴，踏地如雷，冲锋陷阵。" },
        // 控制
        { 法器Type.控制武器, "控制系修士所用法宝，能定魂镇魄，封印敌人。" },
        { 法器Type.控制头盔, "控制系修士所戴兜帽，隐藏气息，洞察一切。" },
        { 法器Type.控制衣服, "控制系修士所着法袍，符文流转，增益咒法威力。" },
        { 法器Type.控制鞋子, "控制系修士所穿布靴，踏云乘风，来去无踪。" },
        // 辅助
        { 法器Type.辅助武器, "辅助系修士所持法杖，引天地灵气，护佑友军。" },
        { 法器Type.辅助头盔, "辅助系修士所戴头冠，温润祥和，凝聚福泽。" },
        { 法器Type.辅助衣服, "辅助系修士所穿法衣，灵力流转，治愈伤势。" },
        { 法器Type.辅助鞋子, "辅助系修士所着云履，轻盈飘逸，日行千里。" },
        // 射手
        { 法器Type.射手武器, "射手所使用的法器，迅捷无比，百步穿杨。" },
        { 法器Type.射手头盔, "射手所戴的轻盔，视野开阔，反应敏锐。" },
        { 法器Type.射手衣服, "射手所穿的轻甲，防护灵巧，迅捷如风。" },
        { 法器Type.射手鞋子, "射手所着的劲靴，脚步轻盈，身法如电。" },
        // 法师
        { 法器Type.法师武器, "法师所使用的法杖，引动天地灵气，施展法术。" },
        { 法器Type.法师头盔, "法师所戴的法冠，凝聚神识，增强法威。" },
        { 法器Type.法师衣服, "法师所穿的法袍，符文密布，引灵助法。" },
        { 法器Type.法师鞋子, "法师所着的法履，踏空而行，灵气护体。" },
    };

    // ==================== 法器名称（基础名称，不含品质） ====================

    public static Dictionary<法器Type, string> 法器名Dic = new Dictionary<法器Type, string>()
    {
        // 战士
        { 法器Type.战士武器, "巨剑" },
        { 法器Type.战士头盔, "重盔" },
        { 法器Type.战士衣服, "重甲" },
        { 法器Type.战士鞋子, "战靴" },
        // 控制
        { 法器Type.控制武器, "法器" },
        { 法器Type.控制头盔, "兜帽" },
        { 法器Type.控制衣服, "法袍" },
        { 法器Type.控制鞋子, "布靴" },
        // 辅助
        { 法器Type.辅助武器, "法杖" },
        { 法器Type.辅助头盔, "头冠" },
        { 法器Type.辅助衣服, "法衣" },
        { 法器Type.辅助鞋子, "云履" },
        // 射手
        { 法器Type.射手武器, "猎弓" },
        { 法器Type.射手头盔, "轻盔" },
        { 法器Type.射手衣服, "轻甲" },
        { 法器Type.射手鞋子, "劲靴" },
        // 法师
        { 法器Type.法师武器, "魔杖" },
        { 法器Type.法师头盔, "法冠" },
        { 法器Type.法师衣服, "灵袍" },
        { 法器Type.法师鞋子, "法履" },
    };

    // ==================== 法器品质与阶数随机 ====================

    /// <summary>
    /// 按概率随机品质（万分比，先抽荒品再往下）
    /// </summary>
    public static QualityType Random品质()
    {
        float random = Random.Range(0, 10000f);
        float accumulate = 0;
        QualityType[] qualities = { QualityType.荒品, QualityType.洪品, QualityType.宙品, QualityType.宇品, QualityType.天品, QualityType.地品, QualityType.玄品, QualityType.黄品 };
        for (int i = 0; i < qualities.Length; i++)
        {
            accumulate += 法器打造品质概率[i];
            if (random < accumulate) return qualities[i];
        }
        return QualityType.黄品;
    }

    // ==================== 掉落 ====================

    public static List<float> 掉落数量概率List = new List<float>()
    {
        10, 40, 30, 15, 5
    };

    /// <summary>
    /// 法器材料掉落概率（前8阶，对应旧8品质；9~16阶暂时不掉落）
    /// </summary>
    public static Dictionary<JingJieType, List<float>> 法器材料掉落概率Dic = new Dictionary<JingJieType, List<float>>()
    {
        // 索引对应阶数-1：[0]=1阶, [1]=2阶, ..., [7]=8阶, [8~15]=0
        { JingJieType.练气 , new List<float>(){100,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.筑基 , new List<float>(){80,20,0,0,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.金丹 , new List<float>(){50,50,0,0,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.元婴 , new List<float>(){10,70,20,0,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.化神 , new List<float>(){0,50,50,0,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.合体 , new List<float>(){0,20,70,10,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.大乘 , new List<float>(){0,0,80,20,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.天仙 , new List<float>(){0,0,60,40,0,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.玄仙 , new List<float>(){0,0,40,50,10,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.金仙 , new List<float>(){0,0,10,70,20,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.太乙金仙 , new List<float>(){0,0,0,70,30,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.大罗金仙 , new List<float>(){0,0,15,40,40,5,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.准圣 , new List<float>(){0,0,10,30,50,10,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.圣人 , new List<float>(){0,0,0,25,60,15,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.天道圣人 , new List<float>(){0,0,0,0,62,35,3,0,0,0,0,0,0,0,0,0}},
        { JingJieType.大道圣人 , new List<float>(){0,0,0,0,45,50,5,0,0,0,0,0,0,0,0,0}},
        { JingJieType.混元圣人 , new List<float>(){0,0,0,0,25,65,10,0,0,0,0,0,0,0,0,0}},
        { JingJieType.鸿蒙 , new List<float>(){0,0,0,0,14,70,15,1,0,0,0,0,0,0,0,0}},
    };

    public static 法器 Get坊市法器(法器Type type, QualityType qualityType, int 阶数)
    {
        法器 法器 = new 法器();
        法器.法器Type = type;
        法器.品质 = qualityType;
        法器.阶数 = 阶数;
        法器.list = Get法器附加属性(qualityType, 阶数);
        int 孔个数 = Get孔数量(qualityType);
        for (int i = 0; i < 孔个数; i++)
        {
            法器.仙石list.Add(new 仙石() { type = 仙石Type.None, quality = QualityType.None, list = null });
        }
        return 法器;
    }

    public static 法器材料 单次法器材料掉落(JingJieType jingJieType)
    {
        int 掉落阶数 = 1;
        float count = 0;
        float 阶数random = Random.Range(0, 100);
        if (法器材料掉落概率Dic.ContainsKey(jingJieType))
        {
            var probList = 法器材料掉落概率Dic[jingJieType];
            for (int i = 0; i < probList.Count; i++)
            {
                count += probList[i];
                if (阶数random < count)
                {
                    掉落阶数 = i + 1;
                    break;
                }
            }
        }

        法器材料 法器材料 = new 法器材料();
        法器材料.阶数 = 掉落阶数;
        法器材料.法器材料Type = (法器材料Type)Random.Range(1, 5);
        return 法器材料;
    }

    public static List<法器材料> Get关卡法器材料掉落(JingJieType jingJieType)
    {
        int 掉落数量 = 0;
        float count = 0;
        float 数量random = Random.Range(0, 100);
        foreach (var item in 掉落数量概率List)
        {
            count += item;
            if (数量random < count) break;
            掉落数量++;
        }

        掉落数量 = (int)(掉落数量 * 属性config.总掉宝率);
        List<法器材料> list = new List<法器材料>();
        for (int i = 0; i < 掉落数量; i++)
        {
            list.Add(单次法器材料掉落(jingJieType));
        }
        return list;
    }

    // ==================== 附加属性Minmaxes（16阶基础值，不含品质倍率） ====================

    public static Dictionary<法器附加属性品质type, minmax> 法器Minmaxes = new Dictionary<法器附加属性品质type, minmax>()
    {
        // ===== 冰霜伤害 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=1}, new minmax(){min = 5, max = 10}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=2}, new minmax(){min = 10, max = 20}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=3}, new minmax(){min = 20, max = 40}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=4}, new minmax(){min = 40, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=5}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=6}, new minmax(){min = 120, max = 250}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=7}, new minmax(){min = 250, max = 500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=8}, new minmax(){min = 500, max = 1000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=9}, new minmax(){min = 1000, max = 1500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=10}, new minmax(){min = 1500, max = 2200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=11}, new minmax(){min = 2200, max = 3200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=12}, new minmax(){min = 3200, max = 4600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=13}, new minmax(){min = 4600, max = 6500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=14}, new minmax(){min = 6500, max = 9000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=15}, new minmax(){min = 9000, max = 12000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜伤害, 阶数=16}, new minmax(){min = 12000, max = 16000}},

        // ===== 火焰伤害 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=1}, new minmax(){min = 5, max = 10}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=2}, new minmax(){min = 10, max = 20}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=3}, new minmax(){min = 20, max = 40}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=4}, new minmax(){min = 40, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=5}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=6}, new minmax(){min = 120, max = 250}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=7}, new minmax(){min = 250, max = 500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=8}, new minmax(){min = 500, max = 1000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=9}, new minmax(){min = 1000, max = 1500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=10}, new minmax(){min = 1500, max = 2200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=11}, new minmax(){min = 2200, max = 3200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=12}, new minmax(){min = 3200, max = 4600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=13}, new minmax(){min = 4600, max = 6500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=14}, new minmax(){min = 6500, max = 9000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=15}, new minmax(){min = 9000, max = 12000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰伤害, 阶数=16}, new minmax(){min = 12000, max = 16000}},

        // ===== 黑暗伤害 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=1}, new minmax(){min = 5, max = 10}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=2}, new minmax(){min = 10, max = 20}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=3}, new minmax(){min = 20, max = 40}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=4}, new minmax(){min = 40, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=5}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=6}, new minmax(){min = 120, max = 250}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=7}, new minmax(){min = 250, max = 500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=8}, new minmax(){min = 500, max = 1000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=9}, new minmax(){min = 1000, max = 1500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=10}, new minmax(){min = 1500, max = 2200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=11}, new minmax(){min = 2200, max = 3200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=12}, new minmax(){min = 3200, max = 4600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=13}, new minmax(){min = 4600, max = 6500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=14}, new minmax(){min = 6500, max = 9000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=15}, new minmax(){min = 9000, max = 12000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗伤害, 阶数=16}, new minmax(){min = 12000, max = 16000}},

        // ===== 雷电伤害 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=1}, new minmax(){min = 5, max = 10}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=2}, new minmax(){min = 10, max = 20}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=3}, new minmax(){min = 20, max = 40}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=4}, new minmax(){min = 40, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=5}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=6}, new minmax(){min = 120, max = 250}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=7}, new minmax(){min = 250, max = 500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=8}, new minmax(){min = 500, max = 1000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=9}, new minmax(){min = 1000, max = 1500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=10}, new minmax(){min = 1500, max = 2200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=11}, new minmax(){min = 2200, max = 3200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=12}, new minmax(){min = 3200, max = 4600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=13}, new minmax(){min = 4600, max = 6500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=14}, new minmax(){min = 6500, max = 9000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=15}, new minmax(){min = 9000, max = 12000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电伤害, 阶数=16}, new minmax(){min = 12000, max = 16000}},

        // ===== 物理伤害 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=1}, new minmax(){min = 5, max = 10}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=2}, new minmax(){min = 10, max = 20}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=3}, new minmax(){min = 20, max = 40}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=4}, new minmax(){min = 40, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=5}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=6}, new minmax(){min = 120, max = 250}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=7}, new minmax(){min = 250, max = 500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=8}, new minmax(){min = 500, max = 1000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=9}, new minmax(){min = 1000, max = 1500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=10}, new minmax(){min = 1500, max = 2200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=11}, new minmax(){min = 2200, max = 3200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=12}, new minmax(){min = 3200, max = 4600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=13}, new minmax(){min = 4600, max = 6500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=14}, new minmax(){min = 6500, max = 9000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=15}, new minmax(){min = 9000, max = 12000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理伤害, 阶数=16}, new minmax(){min = 12000, max = 16000}},

        // ===== 冰霜穿透 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.冰霜穿透, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 火焰穿透 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.火焰穿透, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 黑暗穿透 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.黑暗穿透, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 雷电穿透 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.雷电穿透, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 物理穿透 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.物理穿透, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 最终伤害 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=1}, new minmax(){min = 5, max = 10}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=2}, new minmax(){min = 10, max = 20}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=3}, new minmax(){min = 20, max = 40}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=4}, new minmax(){min = 40, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=5}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=6}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=7}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=8}, new minmax(){min = 400, max = 800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=9}, new minmax(){min = 800, max = 1200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=10}, new minmax(){min = 1200, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=11}, new minmax(){min = 1800, max = 2600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=12}, new minmax(){min = 2600, max = 3600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=13}, new minmax(){min = 3600, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=14}, new minmax(){min = 5000, max = 7000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=15}, new minmax(){min = 7000, max = 10000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.最终伤害, 阶数=16}, new minmax(){min = 10000, max = 14000}},

        // ===== 暴击率 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击率, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 暴击伤害 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=1}, new minmax(){min = 5, max = 10}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=2}, new minmax(){min = 10, max = 20}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=3}, new minmax(){min = 20, max = 40}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=4}, new minmax(){min = 40, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=5}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=6}, new minmax(){min = 120, max = 250}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=7}, new minmax(){min = 250, max = 500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=8}, new minmax(){min = 500, max = 1000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=9}, new minmax(){min = 1000, max = 1500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=10}, new minmax(){min = 1500, max = 2200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=11}, new minmax(){min = 2200, max = 3200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=12}, new minmax(){min = 3200, max = 4600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=13}, new minmax(){min = 4600, max = 6500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=14}, new minmax(){min = 6500, max = 9000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=15}, new minmax(){min = 9000, max = 12000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.暴击伤害, 阶数=16}, new minmax(){min = 12000, max = 16000}},

        // ===== 普通怪增伤 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.普通怪增伤, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 精英怪增伤 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.精英怪增伤, 阶数=16}, new minmax(){min = 5000, max = 7000}},

        // ===== 首领怪增伤 =====
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=1}, new minmax(){min = 5, max = 8}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=2}, new minmax(){min = 8, max = 15}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=3}, new minmax(){min = 15, max = 30}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=4}, new minmax(){min = 30, max = 50}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=5}, new minmax(){min = 50, max = 80}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=6}, new minmax(){min = 80, max = 120}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=7}, new minmax(){min = 120, max = 200}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=8}, new minmax(){min = 200, max = 400}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=9}, new minmax(){min = 400, max = 600}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=10}, new minmax(){min = 600, max = 900}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=11}, new minmax(){min = 900, max = 1300}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=12}, new minmax(){min = 1300, max = 1800}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=13}, new minmax(){min = 1800, max = 2500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=14}, new minmax(){min = 2500, max = 3500}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=15}, new minmax(){min = 3500, max = 5000}},
        { new 法器附加属性品质type(){法器附加属性Type = 法器附加属性Type.首领怪增伤, 阶数=16}, new minmax(){min = 5000, max = 7000}},
    };

    // ==================== 辅助函数 ====================

    public static int Get孔数量(QualityType qualityType)
    {
        int max = (int)qualityType;
        int random = Random.Range(0, max + 1);
        return random;
    }

    /// <summary>
    /// 按品质确定词条数量，按阶数取Minmaxes基础值；词条存基础值，品质倍率在Get法器属性中统一乘算
    /// </summary>
    public static List<法器附加属性值> Get法器附加属性(QualityType qualityType, int 阶数)
    {
        List<法器附加属性值> list = new List<法器附加属性值>();
        // 词条数量按品质决定：黄品1条，玄品2条...荒品8条
        int 数量 = (int)qualityType;
        for (int i = 0; i < 数量; i++)
        {
            int type = Random.Range(1, Enum.GetValues(typeof(法器附加属性Type)).Length);
            法器附加属性Type 附加属性Type = (法器附加属性Type)type;
            var key = new 法器附加属性品质type() { 法器附加属性Type = 附加属性Type, 阶数 = 阶数 };
            float min = 法器Minmaxes[key].min;
            float max = 法器Minmaxes[key].max;
            法器附加属性值 法器附加属性值 = new 法器附加属性值();
            var 无暇random = Random.Range(0, 100f);
            if (无暇random < 1f)
            {
                法器附加属性值.无暇 = true;
                法器附加属性值.count = max;
            }
            else
            {
                法器附加属性值.无暇 = false;
                法器附加属性值.count = Random.Range(min, max);
            }
            法器附加属性值.法器附加属性Type = 附加属性Type;
            list.Add(法器附加属性值);
        }
        return list;
    }
}
