using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 法器打造Item
{
    public 法器Type 法器Type;
    public QualityType 品质;
    // 默认1阶：旧存档无阶数字段时反序列化会保留字段初始值，避免出现0阶
    public int 阶数 = 1;
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
    // 默认1阶：旧存档无阶数字段时反序列化会保留字段初始值，避免0阶导致背包/分解/洗练异常
    public int 阶数 = 1;
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
    /// 法器打造品质概率（按阶数，万分比累计阈值，从黄品到荒品顺序）
    /// </summary>
    public static Dictionary<int, List<float>> 法器打造品质概率 = new Dictionary<int, List<float>>()
    {
        { 1, new List<float>() { 10000, 3000, 1000, 0, 0, 0, 0, 0 } },
        { 2, new List<float>() { 10000, 5000, 2000, 0, 0, 0, 0, 0 } },
        { 3, new List<float>() { 10000, 7000, 3000, 500, 0, 0, 0, 0 }},
        { 4, new List<float>() { 10000, 9000, 4000, 1000, 0, 0, 0, 0 } },
        { 5, new List<float>() { 10000, 10000, 5000, 1500, 0, 0, 0, 0 } },
        { 6, new List<float>() { 10000, 10000, 6000, 2000, 200, 0, 0, 0 } },
        { 7, new List<float>() { 10000, 10000, 7000, 2500, 400, 0, 0, 0 } },
        { 8, new List<float>() { 10000, 10000, 8000, 3000, 600, 50, 0, 0 } },
        { 9, new List<float>() { 10000, 10000, 9000, 3500, 800, 100, 0, 0 } },
        { 10, new List<float>() { 10000, 10000, 8000, 3000, 600, 150, 0, 0 } },
        { 11, new List<float>() { 10000, 10000, 10000, 4000, 1000, 250, 0, 0 } },
        { 12, new List<float>() { 10000, 10000, 10000, 5000, 1400, 350, 20, 0 } },
        { 13, new List<float>() { 10000, 10000, 10000, 6000, 1800, 500, 50, 0 } },
        { 14, new List<float>() { 10000, 10000, 10000, 10000, 2200, 800, 100, 0 } },
        { 15, new List<float>() { 10000, 10000, 10000, 10000, 2600, 1200, 200, 10 } },
        { 16, new List<float>() { 10000, 10000, 10000, 10000, 3000, 1600, 300, 20 } },
    };
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

    /// <summary>
    /// 法器打造时间（单位：道年），只与阶数有关；品质在打造完成后随机赋予
    /// </summary>
    public static Dictionary<int, float> 法器打造时间 = new Dictionary<int, float>()
    {
        { 1 ,0.01f},
        { 2 ,0.02f},
        { 3 ,0.05f},
        { 4 ,0.1f},
        { 5 ,0.2f},
        { 6 ,0.35f},
        { 7 ,0.55f},
        { 8 ,0.8f},
        { 9 ,1.1f},
        { 10 ,1.5f},
        { 11 ,2f},
        { 12 ,2.6f},
        { 13 ,3.3f},
        { 14 ,4.1f},
        { 15 ,5f},
        { 16 ,6f},
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
        { 法器材料Type.铁, new[]{ "凡铁", "精铁", "墨铁", "寒铁", "地火精金", "星辰铁", "鸿蒙紫铁", "混沌神铁", "太虚玄铁", "鸿蒙精铁", "混沌原铁", "造化神铁", "太初玄铁", "先天道铁", "无极圣铁", "大道仙铁" } },
        { 法器材料Type.砂, new[]{ "粗砂", "细砂", "灵砂", "星辰砂", "地脉砂", "玄天砂", "鸿蒙砂", "混沌砂", "太虚灵砂", "鸿蒙精砂", "混沌原砂", "造化神砂", "太初元砂", "先天道砂", "无极圣砂", "大道仙砂" } },
        { 法器材料Type.石, new[]{ "顽石", "硬石", "灵玉", "玄龟石", "地脉晶", "星辰石", "鸿蒙石", "混沌石", "太虚灵石", "鸿蒙晶石", "混沌原石", "造化神石", "太初元石", "先天道石", "无极圣石", "大道仙石" } },
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

    public static Dictionary<法器材料Type, string[]> 材料描述 = new Dictionary<法器材料Type, string[]>()
    {
        { 法器材料Type.铁, new[]
        {
            "山间凡矿锤炼而成，质地粗粝，聊胜于无。",
            "凡铁百炼去芜存菁，锋芒初显。",
            "深埋幽谷，色沉如夜，坚逾精钢。",
            "采自极北玄冰之下，触之寒彻入骨。",
            "地肺熔岩中淬炼千年，赤纹隐现。",
            "陨星坠地所化，内蕴周天星辉。",
            "鸿蒙初判时凝结的神铁，紫气缭绕。",
            "混沌之气孕化而成，万法难侵。",
            "采自太虚深处，似有若无，虚实难辨。",
            "鸿蒙紫铁千锤百炼，去尽杂质。",
            "混沌本源所聚，锻之则鸣若道音。",
            "夺天地造化而生，自成灵性。",
            "太初之时便已存在，历万劫而不磨。",
            "先天而生，通体铭刻大道纹路。",
            "无极之境孕育的圣物，坚不可摧。",
            "大道载体所化，一击可碎星辰。",
        } },
        { 法器材料Type.石, new[]
        {
            "山岩崩落的粗胚，磨之尚可用。",
            "山石中至坚者，刀砍不留痕。",
            "蕴微量灵气的玉石，温润生光。",
            "玄龟驮负之石，刻有先天卦纹。",
            "地脉灵气结晶，触之可感大地脉动。",
            "夜空星屑凝聚，暗夜自发微光。",
            "鸿蒙气息浸染之石，内藏一线生机。",
            "混沌漩涡中捞出，形质变幻不定。",
            "太虚裂隙边缘拾得，时隐时现。",
            "鸿蒙之气凝晶而成，剔透生辉。",
            "混沌未分的本原石胎，重若山岳。",
            "造化之力点化顽石，已通灵窍。",
            "太初元气固结，万物之母。",
            "先天道韵所钟，纹理暗合天道。",
            "无极圣地核心之石，圣威内敛。",
            "大道长河冲刷而成，握之可闻道音。",
        } },
        { 法器材料Type.羽, new[]
        {
            "凡鸟脱落之羽，轻飘无力。",
            "灵雀褪下的细羽，轻若无物。",
            "风灵鸟之羽，持之耳畔生风。",
            "云鹤之羽，天生云纹，不沾尘露。",
            "千年灵鹤尾羽，丹顶一点朱红。",
            "鲲鹏换羽时遗落，大如蒲扇。",
            "鸿蒙灵禽之羽，振之紫气东来。",
            "混沌神鸟之羽，五色迷离。",
            "太虚鸟脱落的虚羽，视之不见其形。",
            "鸿蒙灵禽本命精羽，光华内蕴。",
            "混沌神鸟初生之羽，蕴藏原初之力。",
            "造化神禽之羽，落地即生灵芝。",
            "太初第一只神鸟之羽，万羽之祖。",
            "先天道禽尾羽，挥动间道韵流转。",
            "无极圣禽之羽，圣人亦难求得。",
            "大道仙禽之羽，一羽可遮一方天。",
        } },
        { 法器材料Type.砂, new[]
        {
            "河床粗砂，淘之可得微末铁屑。",
            "淘洗百遍的细砂，莹白如雪。",
            "灵泉冲刷之砂，粒粒含光。",
            "星辉洒落沙洲所化，夜放银芒。",
            "地脉缝隙淘出，温润如脂。",
            "玄天罡风磨砺而成，锋利异常。",
            "鸿蒙紫气流散凝结，紫砂点点。",
            "混沌气旋中心的沉砂，重逾金铁。",
            "太虚幻境中的灵砂，虚实相生。",
            "鸿蒙砂淘尽杂质，颗颗晶莹。",
            "混沌本源沉底之砂，万法归源。",
            "造化伟力所聚，撒之可成山川。",
            "太初洪流的沉淀，岁月之痕。",
            "先天灵河之砂，水过留痕皆是道。",
            "无极圣河河底之砂，圣光氤氲。",
            "大道长河之底的仙砂，一粒一世界。",
        } },
    };

    /// <summary>法器材料描述：材料风味文字 + 用途（打造N阶法器所需的材料。）</summary>
    public static string Get法器材料描述(法器材料Type 法器材料Type, int 阶数)
    {
        string 描述 = string.Empty;
        if (阶数 >= 1 && 阶数 <= 16 && 材料描述.TryGetValue(法器材料Type, out var descs))
        {
            描述 = descs[阶数 - 1];
        }
        return 描述 + "打造" + 阶数 + "阶法器所需的材料。";
    }

    /// <summary>阶数对应的品质档位：每2阶一个品质（1~2阶黄品、3~4阶玄品、5~6阶地品、…、15~16阶荒品）</summary>
    public static QualityType Get阶数对应品质(int 阶数)
    {
        return (QualityType)Mathf.Clamp(1 + (阶数 - 1) / 2, 1, 8);
    }

    /// <summary>法器显示名称：按阶数取专属名（1~16阶各自不同），超出范围回退为基础名+阶数</summary>
    public static string Get法器Name(法器Type type, int 阶数)
    {
        if (法器阶数名Dic.TryGetValue(type, out var names) && names != null)
        {
            int index = Mathf.Clamp(阶数, 1, names.Length) - 1;
            return names[index];
        }
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

    // ==================== 消耗/分解（阶数基础值 × 品质倍数） ====================
    // 键为1~16阶；数组索引 0=黄品 … 7=荒品
    public static List<float> 法器洗练品质倍数消耗 = new List<float>() { 1, 1.5f, 2f, 3, 5, 8, 12, 20 };
    public static List<float> 法器粉尘品质分解倍数 = new List<float>() { 1, 1.5f, 2f, 3, 5, 10, 20, 50 };

    /// <summary>品质倍数（黄品=1 … 荒品=50/20），越界按1处理</summary>
    public static float Get品质倍数(List<float> 倍数表, QualityType 品质)
    {
        int index = (int)品质 - 1;
        if (index < 0 || index >= 倍数表.Count) return 1f;
        return 倍数表[index];
    }

    /// <summary>法器分解粉尘 = 阶数基础值 × 品质分解倍数</summary>
    public static float Get法器分解粉尘(法器 法器)
    {
        int 阶数 = Mathf.Clamp(法器.阶数, 1, 16);
        float 基础 = 法器分解Dic.TryGetValue(阶数, out var value) ? value : 法器分解Dic[1];
        return 基础 * Get品质倍数(法器粉尘品质分解倍数, 法器.品质);
    }

    /// <summary>法器洗练粉尘消耗 = 阶数基础值 × 品质倍数 × 2^锁定词条数</summary>
    public static float Get法器洗练粉尘消耗(法器 法器, int 锁定数量)
    {
        int 阶数 = Mathf.Clamp(法器.阶数, 1, 16);
        float 基础 = 法器洗练消耗Dic.TryGetValue(阶数, out var value) ? value : 法器洗练消耗Dic[1];
        return 基础 * Get品质倍数(法器洗练品质倍数消耗, 法器.品质) * Mathf.Pow(2, 锁定数量);
    }

    /// <summary>法器材料分解粉尘 = 阶数基础值 × 该阶数对应品质的分解倍数</summary>
    public static float Get法器材料分解粉尘(int 阶数)
    {
        阶数 = Mathf.Clamp(阶数, 1, 16);
        float 基础 = 法器材料分解粉尘Dic.TryGetValue(阶数, out var value) ? value : 法器材料分解粉尘Dic[1];
        return 基础 * Get品质倍数(法器粉尘品质分解倍数, Get阶数对应品质(阶数));
    }

    public static Dictionary<int, float> 法器洗练消耗Dic = new Dictionary<int, float>()
    {
        { 1 ,50},
        { 2 ,150},
        { 3 ,500},
        { 4 ,1500},
        { 5 ,5000},
        { 6 ,15000},
        { 7 ,50000},
        { 8 ,250000},
        
        { 9 ,1500000},
        { 10 ,8000000},
        { 11 ,35000000},
        { 12 ,150000000},
        { 13 ,800000000},
        { 14 ,4000000000},
        { 15 ,20000000000},
        { 16 ,100000000000},
    };

    public static Dictionary<int, float> 法器分解Dic = new Dictionary<int, float>()
    {
        { 1 ,100},
        { 2 ,300},
        { 3 ,1000},
        { 4 ,3000},
        { 5 ,10000},
        { 6 ,30000},
        { 7 ,100000},
        { 8 ,500000},
        
        { 9 ,3000000},
        { 10 ,15000000},
        { 11 ,75000000},
        { 12 ,350000000},
        { 13 ,1600000000},
        { 14 ,8000000000},
        { 15 ,40000000000},
        { 16 ,200000000000},
    };

    public static Dictionary<int, float> 法器材料分解粉尘Dic = new Dictionary<int, float>()
    {
        { 1 ,30},
        { 2 ,100},
        { 3 ,300},
        { 4 ,1000},
        { 5 ,3000},
        { 6 ,10000},
        { 7 ,30000},
        { 8 ,150000},
        
        { 9 ,1000000},
        { 10 ,5000000},
        { 11 ,25000000},
        { 12 ,100000000},
        { 13 ,600000000},
        { 14 ,2500000000},
        { 15 ,10000000000},
        { 16 ,60000000000},
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
        { 法器Type.战士武器, "战士所用之巨剑，挥落时势可崩山裂岳。" },
        { 法器Type.战士头盔, "战士所戴之重盔，镇首如岳，致命之击亦难伤分毫。" },
        { 法器Type.战士衣服, "战士所披之重铠，如玄武负山，刀枪不入。" },
        { 法器Type.战士鞋子, "战士所踏之战靴，落地声若惊雷，冲锋无人能挡。" },
        // 控制
        { 法器Type.控制武器, "控制系修士所持法宝，铃音定魂镇魄，封敌于无形。" },
        { 法器Type.控制头盔, "控制系修士所戴兜帽，玄机暗藏，敌情洞察秋毫。" },
        { 法器Type.控制衣服, "控制系修士所着法袍，符文如星河缠绕，咒法威力倍增。" },
        { 法器Type.控制鞋子, "控制系修士所穿布靴，踏云乘风，来去无踪。" },
        // 辅助
        { 法器Type.辅助武器, "辅助系修士所持法杖，轻挥间天地灵气汇聚，枯木亦能回春。" },
        { 法器Type.辅助头盔, "辅助系修士所戴头冠，灵韵温润，福泽汇聚于身。" },
        { 法器Type.辅助衣服, "辅助系修士所穿法衣，灵力流转，所到之处伤势尽愈。" },
        { 法器Type.辅助鞋子, "辅助系修士所着云履，飘然若仙，日行千里不疲。" },
        // 射手
        { 法器Type.射手武器, "射手所用之猎弓，满月一箭，百步之外穿云裂石。" },
        { 法器Type.射手头盔, "射手所戴之轻盔，目若鹰隼，远敌无所遁形。" },
        { 法器Type.射手衣服, "射手所穿之轻甲，疾风附体，进退自如。" },
        { 法器Type.射手鞋子, "射手所着之劲靴，追风逐电，瞬息而至。" },
        // 法师
        { 法器Type.法师武器, "法师所执之法杖，引动九霄神雷，法术所至万物成灰。" },
        { 法器Type.法师头盔, "法师所戴之法冠，凝神聚识，法威更盛三分。" },
        { 法器Type.法师衣服, "法师所穿之灵袍，符文万千，引灵助法，法术不绝。" },
        { 法器Type.法师鞋子, "法师所着之法履，凌波踏空，灵气托身，飘然世外。" },
    };

    // ==================== 法器名称（基础名称，显示时拼接阶数） ====================

    public static Dictionary<法器Type, string> 法器名Dic = new Dictionary<法器Type, string>()
    {
        // 战士
        { 法器Type.战士武器, "崩山剑" },
        { 法器Type.战士头盔, "镇岳盔" },
        { 法器Type.战士衣服, "玄武铠" },
        { 法器Type.战士鞋子, "惊雷靴" },
        // 控制
        { 法器Type.控制武器, "镇魂铃" },
        { 法器Type.控制头盔, "玄机帽" },
        { 法器Type.控制衣服, "缚星袍" },
        { 法器Type.控制鞋子, "踏云靴" },
        // 辅助
        { 法器Type.辅助武器, "回春杖" },
        { 法器Type.辅助头盔, "聚灵冠" },
        { 法器Type.辅助衣服, "慈航衣" },
        { 法器Type.辅助鞋子, "流云履" },
        // 射手
        { 法器Type.射手武器, "穿云弓" },
        { 法器Type.射手头盔, "鹰眼盔" },
        { 法器Type.射手衣服, "疾风甲" },
        { 法器Type.射手鞋子, "追电靴" },
        // 法师
        { 法器Type.法师武器, "引雷杖" },
        { 法器Type.法师头盔, "凝神冠" },
        { 法器Type.法师衣服, "万象袍" },
        { 法器Type.法师鞋子, "凌波履" },
    };

    // ==================== 法器阶数名称（1~16阶各自独立，阶数越高越神秘） ====================

    public static Dictionary<法器Type, string[]> 法器阶数名Dic = new Dictionary<法器Type, string[]>()
    {
        // 战士
        { 法器Type.战士武器, new[]{ "崩山剑", "裂石剑", "断岳剑", "镇岳剑", "焚天剑", "裂空剑", "斩星剑", "覆海剑", "诛仙剑", "太阿剑", "玄黄剑", "混沌剑", "鸿蒙剑", "弑神剑", "万劫剑", "无相剑" } },
        { 法器Type.战士头盔, new[]{ "镇岳盔", "磐石盔", "裂地盔", "玄光盔", "焚天盔", "裂空盔", "龙鳞盔", "山河盔", "诛邪盔", "太虚盔", "玄黄盔", "混沌盔", "鸿蒙盔", "弑神盔", "万劫盔", "无相盔" } },
        { 法器Type.战士衣服, new[]{ "玄武铠", "铁壁铠", "磐岳铠", "玄光铠", "焚天铠", "龙鳞铠", "星辉铠", "山海铠", "诛邪铠", "太虚铠", "玄黄铠", "混沌铠", "鸿蒙铠", "弑神铠", "万劫铠", "无相铠" } },
        { 法器Type.战士鞋子, new[]{ "惊雷靴", "踏山靴", "裂地靴", "玄岳靴", "焚天靴", "追星靴", "云海靴", "破空靴", "诛邪靴", "太虚靴", "玄黄靴", "混沌靴", "鸿蒙靴", "弑神靴", "万劫靴", "无相靴" } },
        // 控制
        { 法器Type.控制武器, new[]{ "镇魂铃", "摄魂铃", "勾魂铃", "锁魄铃", "焚心铃", "夺命铃", "迷魂铃", "乱神铃", "诛魂铃", "摄天铃", "九幽铃", "幽冥铃", "太阴铃", "罗刹铃", "劫灭铃", "无心铃" } },
        { 法器Type.控制头盔, new[]{ "玄机帽", "静心帽", "定神帽", "锁识帽", "焚心帽", "夺魄帽", "迷星帽", "乱神帽", "诛魂帽", "摄天帽", "九幽帽", "幽冥帽", "太阴帽", "罗刹帽", "劫灭帽", "无心帽" } },
        { 法器Type.控制衣服, new[]{ "缚星袍", "定魂袍", "摄魂袍", "锁识袍", "焚心袍", "夺魄袍", "迷星袍", "乱神袍", "诛魂袍", "摄天袍", "九幽袍", "幽冥袍", "太阴袍", "罗刹袍", "劫灭袍", "无心袍" } },
        { 法器Type.控制鞋子, new[]{ "踏云履", "御风履", "凌虚履", "玄机履", "焚心履", "夺影履", "迷踪履", "乱神履", "诛魂履", "摄天履", "九幽履", "幽冥履", "太阴履", "罗刹履", "劫灭履", "无心履" } },
        // 辅助
        { 法器Type.辅助武器, new[]{ "回春杖", "生息杖", "聚灵杖", "渡厄杖", "慈航杖", "甘露杖", "琼华杖", "玄清杖", "太上杖", "太素杖", "天工杖", "造化杖", "无极杖", "无量杖", "无垢杖", "道源杖" } },
        { 法器Type.辅助头盔, new[]{ "聚灵冠", "凝露冠", "清心冠", "渡厄冠", "慈航冠", "甘露冠", "琼华冠", "玄清冠", "太上冠", "太素冠", "天工冠", "造化冠", "无极冠", "无量冠", "无垢冠", "道源冠" } },
        { 法器Type.辅助衣服, new[]{ "慈航衣", "生息衣", "聚灵衣", "渡厄衣", "甘露衣", "琼华衣", "玄青衣", "太上衣", "太素衣", "天工衣", "造化衣", "无极衣", "无量衣", "无垢衣", "道源衣", "混元衣" } },
        { 法器Type.辅助鞋子, new[]{ "流云履", "生息履", "聚灵履", "渡厄履", "慈航履", "甘露履", "琼华履", "玄清履", "太上履", "太素履", "天工履", "造化履", "无极履", "无量履", "无垢履", "道源履" } },
        // 射手
        { 法器Type.射手武器, new[]{ "穿云弓", "破风弓", "惊弦弓", "落雁弓", "裂空弓", "贯日弓", "射日弓", "天穹弓", "破军弓", "流光弓", "星陨弓", "归墟弓", "大荒弓", "震天弓", "诛神弓", "无咎弓" } },
        { 法器Type.射手头盔, new[]{ "鹰眼盔", "疾目盔", "凝眸盔", "穿杨盔", "破风盔", "贯日盔", "射日盔", "天穹盔", "破军盔", "流光盔", "星陨盔", "归墟盔", "大荒盔", "震天盔", "诛神盔", "无咎盔" } },
        { 法器Type.射手衣服, new[]{ "疾风甲", "轻云甲", "追影甲", "逐月甲", "裂风甲", "贯日甲", "射日甲", "天穹甲", "破军甲", "流光甲", "星陨甲", "归墟甲", "大荒甲", "震天甲", "诛神甲", "无咎甲" } },
        { 法器Type.射手鞋子, new[]{ "追电靴", "逐影靴", "掠云靴", "踏月靴", "裂风靴", "贯日靴", "射日靴", "天穹靴", "破军靴", "流光靴", "星陨靴", "归墟靴", "大荒靴", "震天靴", "诛神靴", "无咎靴" } },
        // 法师
        { 法器Type.法师武器, new[]{ "引雷杖", "聚雷杖", "玄雷杖", "紫霄杖", "九霄杖", "雷池杖", "万象杖", "星河杖", "先天杖", "太一杖", "玄天杖", "天罚杖", "诛仙杖", "太初杖", "鸿蒙杖", "无相杖" } },
        { 法器Type.法师头盔, new[]{ "凝神冠", "静心冠", "定识冠", "紫霄冠", "九霄冠", "雷池冠", "万象冠", "星河冠", "先天冠", "太一冠", "玄天冠", "天罚冠", "诛仙冠", "太初冠", "鸿蒙冠", "无相冠" } },
        { 法器Type.法师衣服, new[]{ "万象袍", "聚灵袍", "玄机袍", "紫霄袍", "九霄袍", "雷池袍", "星河袍", "流云袍", "先天袍", "太一袍", "玄天袍", "天罚袍", "诛仙袍", "太初袍", "鸿蒙袍", "无相袍" } },
        { 法器Type.法师鞋子, new[]{ "凌波履", "踏虚履", "步云履", "紫霄履", "九霄履", "雷池履", "星河履", "玄光履", "先天履", "太一履", "玄天履", "天罚履", "诛仙履", "太初履", "鸿蒙履", "无相履" } },
    };

    // ==================== 法器品质与阶数随机 ====================

    /// <summary>
    /// 按阶数对应的概率表随机品质（万分比，先抽荒品再往下）
    /// 概率表按 黄→荒 顺序存的是各品质的累计阈值
    /// </summary>
    public static QualityType Random品质(int 阶数)
    {
        float random = Random.Range(0f, 10000f);
        QualityType[] qualities = { QualityType.荒品, QualityType.洪品, QualityType.宙品, QualityType.宇品, QualityType.天品, QualityType.地品, QualityType.玄品, QualityType.黄品 };
        int[] 阈值索引 = { 7, 6, 5, 4, 3, 2, 1, 0 };
        if (!法器打造品质概率.TryGetValue(Mathf.Clamp(阶数, 1, 16), out var 概率表))
        {
            return QualityType.黄品;
        }
        for (int i = 0; i < qualities.Length; i++)
        {
            if (random < 概率表[阈值索引[i]]) return qualities[i];
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
        // 夹住阶数，避免旧存档（无阶数字段，值为0）触发Minmaxes索引异常
        阶数 = Mathf.Clamp(阶数, 1, 16);
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
