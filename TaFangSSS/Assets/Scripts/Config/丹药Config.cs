using System;
using System.Collections.Generic;
using Config;

public enum 丹药类型
{
    None,
    战斗丹药,
    辅助丹药,
    根基丹药,
    造化丹药,
}

public class 英雄根基丹药属性
{
    public float 火焰伤害;
    public float 冰霜伤害;
    public float 雷电伤害;
    public float 黑暗伤害;
    public float 物理伤害;
    public float 最终伤害;
    public float 暴击伤害;

    // 英雄根基丹药属性 * float
    public static 英雄根基丹药属性 operator *(英雄根基丹药属性 a, float scalar)
    {
        if (a == null) return null;

        return new 英雄根基丹药属性
        {
            火焰伤害 = a.火焰伤害 * scalar,
            冰霜伤害 = a.冰霜伤害 * scalar,
            雷电伤害 = a.雷电伤害 * scalar,
            黑暗伤害 = a.黑暗伤害 * scalar,
            物理伤害 = a.物理伤害 * scalar,
            最终伤害 = a.最终伤害 * scalar,
            暴击伤害 = a.暴击伤害 * scalar
        };
    }

    // float * 英雄根基丹药属性
    public static 英雄根基丹药属性 operator *(float scalar, 英雄根基丹药属性 a)
    {
        return a * scalar;
    }
}
public class 丹药属性
{
    public float 火焰伤害;
    public float 冰霜伤害;
    public float 雷电伤害;
    public float 黑暗伤害;
    public float 物理伤害;
    public float 战士伤害;
    public float 法师伤害;
    public float 射手伤害;
    public float 控制伤害;
    public float 辅助伤害;
    public float 最终伤害;
    public float 修炼速度;
    public float 掉宝率;
    public float 英雄暴击伤害;
    public float 加跟脚;
    public float 英雄火焰伤害;
    public float 英雄冰霜伤害;
    public float 英雄雷电伤害;
    public float 英雄黑暗伤害;
    public float 英雄物理伤害;
    public float 英雄最终伤害;

    // 加法重载（两个丹药属性相加）
    public static 丹药属性 operator +(丹药属性 a, 丹药属性 b)
    {
        if (a == null) return b;
        if (b == null) return a;

        return new 丹药属性
        {
            火焰伤害 = a.火焰伤害 + b.火焰伤害,
            冰霜伤害 = a.冰霜伤害 + b.冰霜伤害,
            雷电伤害 = a.雷电伤害 + b.雷电伤害,
            黑暗伤害 = a.黑暗伤害 + b.黑暗伤害,
            物理伤害 = a.物理伤害 + b.物理伤害,
            战士伤害 = a.战士伤害 + b.战士伤害,
            法师伤害 = a.法师伤害 + b.法师伤害,
            射手伤害 = a.射手伤害 + b.射手伤害,
            控制伤害 = a.控制伤害 + b.控制伤害,
            辅助伤害 = a.辅助伤害 + b.辅助伤害,
            最终伤害 = a.最终伤害 + b.最终伤害,
            修炼速度 = a.修炼速度 + b.修炼速度,
            掉宝率 = a.掉宝率 + b.掉宝率,
            英雄暴击伤害 = a.英雄暴击伤害 + b.英雄暴击伤害,
            加跟脚 = a.加跟脚 + b.加跟脚,
            英雄火焰伤害 = a.英雄火焰伤害 + b.英雄火焰伤害,
            英雄冰霜伤害 = a.英雄冰霜伤害 + b.英雄冰霜伤害,
            英雄雷电伤害 = a.英雄雷电伤害 + b.英雄雷电伤害,
            英雄黑暗伤害 = a.英雄黑暗伤害 + b.英雄黑暗伤害,
            英雄物理伤害 = a.英雄物理伤害 + b.英雄物理伤害,
            英雄最终伤害 = a.英雄最终伤害 + b.英雄最终伤害
        };
    }

    // 丹药属性 * float
    public static 丹药属性 operator *(丹药属性 a, float scalar)
    {
        if (a == null) return null;

        return new 丹药属性
        {
            火焰伤害 = a.火焰伤害 * scalar,
            冰霜伤害 = a.冰霜伤害 * scalar,
            雷电伤害 = a.雷电伤害 * scalar,
            黑暗伤害 = a.黑暗伤害 * scalar,
            物理伤害 = a.物理伤害 * scalar,
            战士伤害 = a.战士伤害 * scalar,
            法师伤害 = a.法师伤害 * scalar,
            射手伤害 = a.射手伤害 * scalar,
            控制伤害 = a.控制伤害 * scalar,
            辅助伤害 = a.辅助伤害 * scalar,
            最终伤害 = a.最终伤害 * scalar,
            修炼速度 = a.修炼速度 * scalar,
            掉宝率 = a.掉宝率 * scalar,
            英雄暴击伤害 = a.英雄暴击伤害 * scalar,
            加跟脚 = a.加跟脚 * scalar,
            英雄火焰伤害 = a.英雄火焰伤害 * scalar,
            英雄冰霜伤害 = a.英雄冰霜伤害 * scalar,
            英雄雷电伤害 = a.英雄雷电伤害 * scalar,
            英雄黑暗伤害 = a.英雄黑暗伤害 * scalar,
            英雄物理伤害 = a.英雄物理伤害 * scalar,
            英雄最终伤害 = a.英雄最终伤害 * scalar
        };
    }

    // float * 丹药属性
    public static 丹药属性 operator *(float scalar, 丹药属性 a)
    {
        return a * scalar;
    }
}
public class 丹药炼制Item
{
    public 丹药Type 丹药Type;
    public int 阶数;
    public int count;
    public float 进度;
}
public enum 丹药Type
{
    None,
    火焰伤害,
    冰霜伤害,
    雷电伤害,
    黑暗伤害,
    物理伤害,
    战士伤害,
    法师伤害,
    射手伤害,
    控制伤害,
    最终伤害,
    修炼速度,
    掉宝率,
    英雄暴击伤害,
    加跟脚,//轮回后不重置
    英雄火焰伤害,
    英雄冰霜伤害,
    英雄雷电伤害,
    英雄黑暗伤害,
    英雄物理伤害,
    英雄最终伤害,
}

public class 灵药
{
    public 灵药Type 灵药Type = 灵药Type.None;
    public QualityType QualityType = QualityType.None;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        灵药 other = (灵药)obj;
        return 灵药Type == other.灵药Type && QualityType == other.QualityType;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + 灵药Type.GetHashCode();
        hash = hash * 31 + QualityType.GetHashCode();
        return hash;
    }
}

public class 丹药
{
    public 丹药Type 丹药Type = 丹药Type.None;
    public QualityType QualityType = QualityType.None;
    public int 阶段 = 1;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        丹药 other = (丹药)obj;
        return 丹药Type == other.丹药Type && QualityType == other.QualityType && 阶段 == other.阶段;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + 丹药Type.GetHashCode();
        hash = hash * 31 + QualityType.GetHashCode();
        hash = hash * 31 + 阶段.GetHashCode();
        return hash;
    }
}

public enum 灵药Type
{
    None,
    金银花蕊,
    马兜铃果,
    四叶参根,
    千年雪莲,
    回春草,
    补血花,
    龙纹草,
    九曲黄泉草,
    千幻蝶恋花,
    聚灵凝神叶
}

public class 丹药Config
{

    public static string Get阶数string(int 阶数)
    {
        switch (阶数)
        {
            case 1:
                return "一阶";
            case 2:
                return "二阶";
            case 3:
                return "三阶";
            case 4:
                return "四阶";
            case 5:
                return "五阶";
            case 6:
                return "六阶";
            case 7:
                return "七阶";
            case 8:
                return "八阶";
            case 9:
                return "九阶";
            case 10:
                return "十阶";
            case 11:
                return "十一阶";
            case 12:
                return "十二阶";
            case 13:
                return "十三阶";
            case 14:
                return "十四阶";
            case 15:
                return "十五阶";
            case 16:
                return "十六阶";
            default:
                return string.Empty; // 或者 throw new ArgumentOutOfRangeException(nameof(阶数));
        }
    }
    public static float 丹药阶数倍数=2;
    /// <summary>每品质每阶数独立计数（各5次上限），数值按阶段翻倍</summary>
    public static 英雄根基丹药属性 Get英雄根基丹药属性(HeroType heroType)
    {
        英雄根基丹药属性 英雄根基丹药属性 = new 英雄根基丹药属性();
        for (int i = 1; i <= 8; i++)
        {
            var quality = (QualityType)i;
            for (int 阶段 = 1; 阶段 <= PlayerData.Get丹药最高阶段(quality); 阶段++)
            {
                英雄根基丹药属性.冰霜伤害 += PlayerData.S.Get英雄根基丹药服用(heroType, 丹药Type.英雄冰霜伤害, quality, 阶段) * Get丹药值(丹药Type.英雄冰霜伤害, quality, 阶段);
                英雄根基丹药属性.火焰伤害 += PlayerData.S.Get英雄根基丹药服用(heroType, 丹药Type.英雄火焰伤害, quality, 阶段) * Get丹药值(丹药Type.英雄火焰伤害, quality, 阶段);
                英雄根基丹药属性.雷电伤害 += PlayerData.S.Get英雄根基丹药服用(heroType, 丹药Type.英雄雷电伤害, quality, 阶段) * Get丹药值(丹药Type.英雄雷电伤害, quality, 阶段);
                英雄根基丹药属性.物理伤害 += PlayerData.S.Get英雄根基丹药服用(heroType, 丹药Type.英雄物理伤害, quality, 阶段) * Get丹药值(丹药Type.英雄物理伤害, quality, 阶段);
                英雄根基丹药属性.黑暗伤害 += PlayerData.S.Get英雄根基丹药服用(heroType, 丹药Type.英雄黑暗伤害, quality, 阶段) * Get丹药值(丹药Type.英雄黑暗伤害, quality, 阶段);
                英雄根基丹药属性.最终伤害 += PlayerData.S.Get英雄根基丹药服用(heroType, 丹药Type.英雄最终伤害, quality, 阶段) * Get丹药值(丹药Type.英雄最终伤害, quality, 阶段);
                英雄根基丹药属性.暴击伤害 += PlayerData.S.Get英雄根基丹药服用(heroType, 丹药Type.英雄暴击伤害, quality, 阶段) * Get丹药值(丹药Type.英雄暴击伤害, quality, 阶段);
            }
        }

        return 英雄根基丹药属性*(1f+体质Config.当前体质总属性.丹药效果/100f);
    }
    public static 丹药属性 Get战斗丹药属性()
    {
        丹药属性 丹药属性 = new 丹药属性();
        if (PlayerData.S.战斗选择丹药Dic[1].丹药Type != 丹药Type.None)
        {
            丹药属性 丹药属性1 = Get丹药属性(PlayerData.S.战斗选择丹药Dic[1].丹药Type, PlayerData.S.战斗选择丹药Dic[1].QualityType, PlayerData.S.战斗选择丹药Dic[1].阶段);
            丹药属性 +=丹药属性1;
        }
        if (PlayerData.S.战斗选择丹药Dic[2].丹药Type != 丹药Type.None)
        {
            丹药属性 丹药属性2 = Get丹药属性(PlayerData.S.战斗选择丹药Dic[2].丹药Type, PlayerData.S.战斗选择丹药Dic[2].QualityType, PlayerData.S.战斗选择丹药Dic[2].阶段);
            丹药属性 += 丹药属性2;
        }
        if (PlayerData.S.战斗选择丹药Dic[3].丹药Type != 丹药Type.None)
        {
            丹药属性 丹药属性3 = Get丹药属性(PlayerData.S.战斗选择丹药Dic[3].丹药Type, PlayerData.S.战斗选择丹药Dic[3].QualityType, PlayerData.S.战斗选择丹药Dic[3].阶段);
            丹药属性 += 丹药属性3;
        }
        return 丹药属性*(1f+体质Config.当前体质总属性.丹药效果/100f);
    }
    public static Dictionary<丹药类型, string> 丹药类型String = new Dictionary<丹药类型, string>()
    {
        { 丹药类型.战斗丹药, "战斗丹药" },
        { 丹药类型.根基丹药, "根基丹药" },
        { 丹药类型.造化丹药, "造化丹药" },
        { 丹药类型.辅助丹药, "辅助丹药" },
    };

    // [废弃] 旧的按品质获取炼制经验接口，保留签名用于兼容
    public static float Get炼制丹药经验(丹药Type type, QualityType qualityType)
    {
        return Get炼制经验(type, (int)qualityType); // 临时桥接：品质值作为阶数
    }
    public static Dictionary<QualityType, long> 战斗丹药经验Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 30 },
        { QualityType.玄品, 100 },
        { QualityType.地品, 300 },
        { QualityType.天品, 1000 },
        { QualityType.宇品, 3000 },
        { QualityType.宙品, 10000 },
        { QualityType.洪品, 30000 },
        { QualityType.荒品, 100000 },
    };

    // [废弃] 旧的按品质获取炼制等级接口
    public static long Get炼制丹药等级(丹药Type type, QualityType qualityType)
    {
        return Get炼丹等级要求(type, (int)qualityType); // 临时桥接
    }
    public static Dictionary<QualityType, long> 战斗丹药炼制等级Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 1 },
        { QualityType.玄品, 5 },
        { QualityType.地品, 10 },
        { QualityType.天品, 17 },
        { QualityType.宇品, 25 },
        { QualityType.宙品, 35 },
        { QualityType.洪品, 45 },
        { QualityType.荒品, 60 },
    };
    
    public static Dictionary<QualityType, long> 辅助丹药炼制等级Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 3 },
        { QualityType.玄品, 10 },
        { QualityType.地品, 17 },
        { QualityType.天品, 25 },
        { QualityType.宇品, 35 },
        { QualityType.宙品, 45 },
        { QualityType.洪品, 60 },
        { QualityType.荒品, 70 },
    };
    public static Dictionary<QualityType, long> 根基丹药炼制等级Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 6 },
        { QualityType.玄品, 15 },
        { QualityType.地品, 25 },
        { QualityType.天品, 35 },
        { QualityType.宇品, 45 },
        { QualityType.宙品, 55 },
        { QualityType.洪品, 65 },
        { QualityType.荒品, 80 },
    };
    public static Dictionary<QualityType, long> 造化丹药炼制等级Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 10 },
        { QualityType.玄品, 17 },
        { QualityType.地品, 25 },
        { QualityType.天品, 35 },
        { QualityType.宇品, 45 },
        { QualityType.宙品, 55 },
        { QualityType.洪品, 70 },
        { QualityType.荒品, 90 },
    };
    
    
    public static Dictionary<QualityType, float> 战斗丹药炼制时间Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 0.1f },
        { QualityType.玄品, 0.2f },
        { QualityType.地品, 0.3f },
        { QualityType.天品, 0.4f },
        { QualityType.宇品, 0.5f },
        { QualityType.宙品, 0.6f },
        { QualityType.洪品, 0.8f },
        { QualityType.荒品, 1f },
    };
    
    public static Dictionary<QualityType, float> 辅助丹药炼制时间Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 0.15f },
        { QualityType.玄品, 0.3f },
        { QualityType.地品, 0.45f },
        { QualityType.天品, 0.6f },
        { QualityType.宇品, 0.75f },
        { QualityType.宙品, 0.9f },
        { QualityType.洪品, 1.2f },
        { QualityType.荒品, 1.5f },
    };
    public static Dictionary<QualityType, float> 根基丹药炼制时间Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 0.2f },
        { QualityType.玄品, 0.4f },
        { QualityType.地品, 0.6f },
        { QualityType.天品, 0.8f },
        { QualityType.宇品, 0.1f },
        { QualityType.宙品, 1.2f },
        { QualityType.洪品, 1.5f },
        { QualityType.荒品, 1.8f },
    };
    public static Dictionary<QualityType, float> 造化丹药炼制时间Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 0.3f },
        { QualityType.玄品, 0.6f },
        { QualityType.地品, 0.9f },
        { QualityType.天品, 1.2f },
        { QualityType.宇品, 1.5f },
        { QualityType.宙品, 1.8f },
        { QualityType.洪品, 2.1f },
        { QualityType.荒品, 2.5f },
    };
    
    public static Dictionary<QualityType, long> 辅助丹药经验Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 50 },
        { QualityType.玄品, 150 },
        { QualityType.地品, 500 },
        { QualityType.天品, 1500 },
        { QualityType.宇品, 4500 },
        { QualityType.宙品, 15000 },
        { QualityType.洪品, 45000 },
        { QualityType.荒品, 150000 },
    };
    
    public static Dictionary<QualityType, long> 根基丹药经验Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 100 },
        { QualityType.玄品, 300 },
        { QualityType.地品, 1000 },
        { QualityType.天品, 3000 },
        { QualityType.宇品, 10000 },
        { QualityType.宙品, 30000 },
        { QualityType.洪品, 100000 },
        { QualityType.荒品, 300000 },
    };
    public static Dictionary<QualityType, long> 造化丹药经验Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 300 },
        { QualityType.玄品, 1000 },
        { QualityType.地品, 3000 },
        { QualityType.天品, 10000 },
        { QualityType.宇品, 30000 },
        { QualityType.宙品, 100000 },
        { QualityType.洪品, 300000 },
        { QualityType.荒品, 1000000 },
    };

    // [废弃] 旧的按品质+筛选计算最大炼制数量接口（现在数量固定按阶数算）
    public static int Get最大炼制数量(丹药Type type, QualityType qualityType,bool 黄,bool 玄,bool 地,bool 天,bool 宇,bool 宙,bool 洪,bool 荒)
    {
        return int.MaxValue; // 现在不再靠品质筛选限制数量
    }

    // [废弃] 旧的按品质获取炼制时间接口
    public static float Get炼制丹药需要时间(丹药Type type, QualityType qualityType)
    {
        return Get炼制时间(type, (int)qualityType); // 临时桥接
    }

    // [废弃] 旧的按品质获取灵药列表接口，改为按阶数取固定品质
    public static List<灵药> Get炼制灵药(丹药Type type, QualityType qualityType)
    {
        return Get炼制灵药按阶数(type, (int)qualityType);
    }

    /// <summary>按阶数获取固定品质的灵药列表（新接口）</summary>
    public static List<灵药> Get炼制灵药按阶数(丹药Type type, int 阶数)
    {
        if (type == 丹药Type.None) return null;
        QualityType 材料品质 = Get材料品质(阶数);

        // 造化丹药（加跟脚）用灵植，不走灵药流程
        if (丹药类型Dic[type] == 丹药类型.造化丹药)
            return null;

        var 灵药list = 丹方Dic[type];
        var list = new List<灵药>();
        for (int i = 0; i < 4; i++)
        {
            list.Add(new 灵药 { 灵药Type = 灵药list[i], QualityType = 材料品质 });
        }
        return list;
    }
    public static Dictionary<float, float> 炼丹等级经验Dic = new Dictionary<float, float>()
{
    // 1-10级：每级+100
    {1,100}, {2,200}, {3,300}, {4,400}, {5,500}, {6,600}, {7,700}, {8,800}, {9,900}, {10,1000},

    // 11-20级：每级+300
    {11,1200}, {12,1500}, {13,1800}, {14,2100}, {15,2400}, {16,2700}, {17,3000}, {18,3300}, {19,3600}, {20,3900},

    // 21-30级：每级+1000
    {21,4000}, {22,5000}, {23,6000}, {24,7000}, {25,8000}, {26,9000}, {27,10000}, {28,11000}, {29,12000}, {30,13000},

    // 31-40级：每级+3000
    {31,14000}, {32,17000}, {33,20000}, {34,23000}, {35,26000}, {36,29000}, {37,32000}, {38,35000}, {39,38000}, {40,41000},

    // 41-50级：每级+10000
    {41,42000}, {42,52000}, {43,62000}, {44,72000}, {45,82000}, {46,92000}, {47,102000}, {48,112000}, {49,122000}, {50,132000},

    // 51-60级：每级+30000
    {51,135000}, {52,165000}, {53,195000}, {54,225000}, {55,255000}, {56,285000}, {57,315000}, {58,345000}, {59,375000}, {60,405000},

    // 61-70级：每级+100000
    {61,410000}, {62,510000}, {63,610000}, {64,710000}, {65,810000}, {66,910000}, {67,1010000}, {68,1110000}, {69,1210000}, {70,1310000},

    // 71-80级：每级+300000
    {71,1350000}, {72,1650000}, {73,1950000}, {74,2250000}, {75,2550000}, {76,2850000}, {77,3150000}, {78,3450000}, {79,3750000}, {80,4050000},

    // 81-90级：每级+1000000
    {81,4100000}, {82,5100000}, {83,6100000}, {84,7100000}, {85,8100000}, {86,9100000}, {87,10100000}, {88,11100000}, {89,12100000}, {90,13100000},

    // 91-100级：每级+3000000
    {91,13500000}, {92,16500000}, {93,19500000}, {94,22500000}, {95,25500000}, {96,28500000}, {97,31500000}, {98,34500000}, {99,37500000}, {100,40500000},

    // 101-110级：每级+10000000
    {101,41000000}, {102,51000000}, {103,61000000}, {104,71000000}, {105,81000000}, {106,91000000}, {107,101000000}, {108,111000000}, {109,121000000}, {110,131000000},

    // 111-120级：每级+30000000
    {111,135000000}, {112,165000000}, {113,195000000}, {114,225000000}, {115,255000000}, {116,285000000}, {117,315000000}, {118,345000000}, {119,375000000}, {120,405000000},

    // 121-130级：每级+100000000
    {121,410000000}, {122,510000000}, {123,610000000}, {124,710000000}, {125,810000000}, {126,910000000}, {127,1010000000}, {128,1110000000}, {129,1210000000}, {130,1310000000},

    // 131-140级：每级+300000000
    {131,1350000000}, {132,1650000000}, {133,1950000000}, {134,2250000000}, {135,2550000000}, {136,2850000000}, {137,3150000000}, {138,3450000000}, {139,3750000000}, {140,4050000000},

    // 141-150级：每级+1000000000
    {141,4100000000}, {142,5100000000}, {143,6100000000}, {144,7100000000}, {145,8100000000}, {146,9100000000}, {147,10100000000}, {148,11100000000}, {149,12100000000}, {150,13100000000},

    // 151-160级：每级+3000000000
    {151,13500000000}, {152,16500000000}, {153,19500000000}, {154,22500000000}, {155,25500000000}, {156,28500000000}, {157,31500000000}, {158,34500000000}, {159,37500000000}, {160,40500000000},

    // 161-170级：每级+10000000000
    {161,41000000000}, {162,51000000000}, {163,61000000000}, {164,71000000000}, {165,81000000000}, {166,91000000000}, {167,101000000000}, {168,111000000000}, {169,121000000000}, {170,131000000000},

    // 171-180级：每级+30000000000
    {171,135000000000}, {172,165000000000}, {173,195000000000}, {174,225000000000}, {175,255000000000}, {176,285000000000}, {177,315000000000}, {178,345000000000}, {179,375000000000}, {180,405000000000},

    // 181-190级：每级+100000000000
    {181,410000000000}, {182,510000000000}, {183,610000000000}, {184,710000000000}, {185,810000000000}, {186,910000000000}, {187,1010000000000}, {188,1110000000000}, {189,1210000000000}, {190,1310000000000},

    // 191-200级：每级+300000000000
    {191,1350000000000}, {192,1650000000000}, {193,1950000000000}, {194,2250000000000}, {195,2550000000000}, {196,2850000000000}, {197,3150000000000}, {198,3450000000000}, {199,3750000000000}, {200,4050000000000},
};
    
    public static Dictionary<灵药Type, string> 灵药名Dic = new Dictionary<灵药Type, string>()
    {
        { 灵药Type.金银花蕊, "金银花蕊" },
        { 灵药Type.马兜铃果, "马兜铃果" },
        { 灵药Type.四叶参根, "四叶参根" },
        { 灵药Type.千年雪莲, "千年雪莲" },
        { 灵药Type.回春草, "回春草" },
        { 灵药Type.补血花, "补血花" },
        { 灵药Type.龙纹草, "龙纹草" },
        { 灵药Type.九曲黄泉草, "九曲黄泉草" },
        { 灵药Type.千幻蝶恋花, "千幻蝶恋花" },
        { 灵药Type.聚灵凝神叶, "聚灵凝神叶" },
    };
    
    public static Dictionary<丹药Type, YuanSuType> 丹药元素类型Dic = new Dictionary<丹药Type, YuanSuType>()
    {
        { 丹药Type.火焰伤害, YuanSuType.None },
        { 丹药Type.冰霜伤害, YuanSuType.None },
        { 丹药Type.雷电伤害, YuanSuType.None },
        { 丹药Type.黑暗伤害, YuanSuType.None },
        { 丹药Type.物理伤害, YuanSuType.None },
        { 丹药Type.战士伤害, YuanSuType.None },
        { 丹药Type.法师伤害, YuanSuType.None },
        { 丹药Type.射手伤害, YuanSuType.None },
        { 丹药Type.控制伤害, YuanSuType.None },
        { 丹药Type.最终伤害, YuanSuType.None},
        { 丹药Type.修炼速度, YuanSuType.None },
        { 丹药Type.掉宝率, YuanSuType.None },
        { 丹药Type.英雄暴击伤害, YuanSuType.None },
        { 丹药Type.加跟脚, YuanSuType.None },
        { 丹药Type.英雄火焰伤害, YuanSuType.火 },
        { 丹药Type.英雄冰霜伤害, YuanSuType.冰 },
        { 丹药Type.英雄雷电伤害, YuanSuType.电 },
        { 丹药Type.英雄黑暗伤害, YuanSuType.黑暗 },
        { 丹药Type.英雄物理伤害, YuanSuType.物理 },
        { 丹药Type.英雄最终伤害, YuanSuType.None },
    };

    public static Dictionary<丹药Type, 丹药类型> 丹药类型Dic = new Dictionary<丹药Type, 丹药类型>()
    {
        { 丹药Type.火焰伤害, 丹药类型.战斗丹药 },
        { 丹药Type.冰霜伤害, 丹药类型.战斗丹药 },
        { 丹药Type.雷电伤害, 丹药类型.战斗丹药 },
        { 丹药Type.黑暗伤害, 丹药类型.战斗丹药 },
        { 丹药Type.物理伤害, 丹药类型.战斗丹药 },
        { 丹药Type.战士伤害, 丹药类型.战斗丹药 },
        { 丹药Type.法师伤害, 丹药类型.战斗丹药 },
        { 丹药Type.射手伤害, 丹药类型.战斗丹药 },
        { 丹药Type.控制伤害, 丹药类型.战斗丹药 },
        { 丹药Type.最终伤害, 丹药类型.战斗丹药 },
        { 丹药Type.修炼速度, 丹药类型.辅助丹药 },
        { 丹药Type.掉宝率, 丹药类型.辅助丹药 },
        { 丹药Type.英雄暴击伤害, 丹药类型.根基丹药 },
        { 丹药Type.加跟脚, 丹药类型.造化丹药 },
        { 丹药Type.英雄火焰伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄冰霜伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄雷电伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄黑暗伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄物理伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄最终伤害, 丹药类型.根基丹药 },
    };

    /// <summary>获取丹药属性。1阶为基础值，每升一阶翻 丹药阶数倍数 倍（2阶2倍、3阶4倍……）</summary>
    public static 丹药属性 Get丹药属性(丹药Type type, QualityType qualityType, int 阶段 = 1)
    {
        return Get丹药属性基础(type, qualityType) * (float)Math.Pow(丹药阶数倍数, 阶段 - 1);
    }

    private static 丹药属性 Get丹药属性基础(丹药Type type, QualityType qualityType)
{
    丹药属性 丹药属性 = new 丹药属性();
    switch (type)
    {
        // ========== 伤害类 ==========
        case 丹药Type.火焰伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.火焰伤害 = 10; break;
                case QualityType.玄品: 丹药属性.火焰伤害 = 25; break;
                case QualityType.地品: 丹药属性.火焰伤害 = 50; break;
                case QualityType.天品: 丹药属性.火焰伤害 = 100; break;
                case QualityType.宇品: 丹药属性.火焰伤害 = 200; break;
                case QualityType.宙品: 丹药属性.火焰伤害 = 500; break;
                case QualityType.洪品: 丹药属性.火焰伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.火焰伤害 = 3000; break;
            }
            break;

        case 丹药Type.冰霜伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.冰霜伤害 = 10; break;
                case QualityType.玄品: 丹药属性.冰霜伤害 = 25; break;
                case QualityType.地品: 丹药属性.冰霜伤害 = 50; break;
                case QualityType.天品: 丹药属性.冰霜伤害 = 100; break;
                case QualityType.宇品: 丹药属性.冰霜伤害 = 200; break;
                case QualityType.宙品: 丹药属性.冰霜伤害 = 500; break;
                case QualityType.洪品: 丹药属性.冰霜伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.冰霜伤害 = 3000; break;
            }
            break;

        case 丹药Type.雷电伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.雷电伤害 = 10; break;
                case QualityType.玄品: 丹药属性.雷电伤害 = 25; break;
                case QualityType.地品: 丹药属性.雷电伤害 = 50; break;
                case QualityType.天品: 丹药属性.雷电伤害 = 100; break;
                case QualityType.宇品: 丹药属性.雷电伤害 = 200; break;
                case QualityType.宙品: 丹药属性.雷电伤害 = 500; break;
                case QualityType.洪品: 丹药属性.雷电伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.雷电伤害 = 3000; break;
            }
            break;

        case 丹药Type.黑暗伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.黑暗伤害 = 10; break;
                case QualityType.玄品: 丹药属性.黑暗伤害 = 25; break;
                case QualityType.地品: 丹药属性.黑暗伤害 = 50; break;
                case QualityType.天品: 丹药属性.黑暗伤害 = 100; break;
                case QualityType.宇品: 丹药属性.黑暗伤害 = 200; break;
                case QualityType.宙品: 丹药属性.黑暗伤害 = 500; break;
                case QualityType.洪品: 丹药属性.黑暗伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.黑暗伤害 = 3000; break;
            }
            break;

        case 丹药Type.物理伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.物理伤害 = 10; break;
                case QualityType.玄品: 丹药属性.物理伤害 = 25; break;
                case QualityType.地品: 丹药属性.物理伤害 = 50; break;
                case QualityType.天品: 丹药属性.物理伤害 = 100; break;
                case QualityType.宇品: 丹药属性.物理伤害 = 200; break;
                case QualityType.宙品: 丹药属性.物理伤害 = 500; break;
                case QualityType.洪品: 丹药属性.物理伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.物理伤害 = 3000; break;
            }
            break;

        case 丹药Type.战士伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.战士伤害 = 10; break;
                case QualityType.玄品: 丹药属性.战士伤害 = 25; break;
                case QualityType.地品: 丹药属性.战士伤害 = 50; break;
                case QualityType.天品: 丹药属性.战士伤害 = 100; break;
                case QualityType.宇品: 丹药属性.战士伤害 = 200; break;
                case QualityType.宙品: 丹药属性.战士伤害 = 500; break;
                case QualityType.洪品: 丹药属性.战士伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.战士伤害 = 3000; break;
            }
            break;

        case 丹药Type.射手伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.射手伤害 = 10; break;
                case QualityType.玄品: 丹药属性.射手伤害 = 25; break;
                case QualityType.地品: 丹药属性.射手伤害 = 50; break;
                case QualityType.天品: 丹药属性.射手伤害 = 100; break;
                case QualityType.宇品: 丹药属性.射手伤害 = 200; break;
                case QualityType.宙品: 丹药属性.射手伤害 = 500; break;
                case QualityType.洪品: 丹药属性.射手伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.射手伤害 = 3000; break;
            }
            break;

        case 丹药Type.法师伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.法师伤害 = 10; break;
                case QualityType.玄品: 丹药属性.法师伤害 = 25; break;
                case QualityType.地品: 丹药属性.法师伤害 = 50; break;
                case QualityType.天品: 丹药属性.法师伤害 = 100; break;
                case QualityType.宇品: 丹药属性.法师伤害 = 200; break;
                case QualityType.宙品: 丹药属性.法师伤害 = 500; break;
                case QualityType.洪品: 丹药属性.法师伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.法师伤害 = 3000; break;
            }
            break;

       

        case 丹药Type.控制伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.控制伤害 = 10; break;
                case QualityType.玄品: 丹药属性.控制伤害 = 25; break;
                case QualityType.地品: 丹药属性.控制伤害 = 50; break;
                case QualityType.天品: 丹药属性.控制伤害 = 100; break;
                case QualityType.宇品: 丹药属性.控制伤害 = 200; break;
                case QualityType.宙品: 丹药属性.控制伤害 = 500; break;
                case QualityType.洪品: 丹药属性.控制伤害 = 1000; break;
                case QualityType.荒品: 丹药属性.控制伤害 = 3000; break;
            }
            break;

        // ========== 最终伤害 ==========
        case 丹药Type.最终伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.最终伤害 = 5; break;
                case QualityType.玄品: 丹药属性.最终伤害 = 10; break;
                case QualityType.地品: 丹药属性.最终伤害 = 25; break;
                case QualityType.天品: 丹药属性.最终伤害 = 50; break;
                case QualityType.宇品: 丹药属性.最终伤害 = 100; break;
                case QualityType.宙品: 丹药属性.最终伤害 = 200; break;
                case QualityType.洪品: 丹药属性.最终伤害 = 500; break;
                case QualityType.荒品: 丹药属性.最终伤害 = 2000; break;
            }
            break;

        // ========== 英雄类 ==========
        case 丹药Type.英雄最终伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.英雄最终伤害 = 5; break;
                case QualityType.玄品: 丹药属性.英雄最终伤害 = 10; break;
                case QualityType.地品: 丹药属性.英雄最终伤害 = 25; break;
                case QualityType.天品: 丹药属性.英雄最终伤害 = 50; break;
                case QualityType.宇品: 丹药属性.英雄最终伤害 = 100; break;
                case QualityType.宙品: 丹药属性.英雄最终伤害 = 200; break;
                case QualityType.洪品: 丹药属性.英雄最终伤害 = 500; break;
                case QualityType.荒品: 丹药属性.英雄最终伤害 = 2000; break;
            }
            break;

        case 丹药Type.英雄暴击伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.英雄暴击伤害 = 5; break;
                case QualityType.玄品: 丹药属性.英雄暴击伤害 = 10; break;
                case QualityType.地品: 丹药属性.英雄暴击伤害 = 25; break;
                case QualityType.天品: 丹药属性.英雄暴击伤害 = 50; break;
                case QualityType.宇品: 丹药属性.英雄暴击伤害 = 100; break;
                case QualityType.宙品: 丹药属性.英雄暴击伤害 = 200; break;
                case QualityType.洪品: 丹药属性.英雄暴击伤害 = 500; break;
                case QualityType.荒品: 丹药属性.英雄暴击伤害 = 2000; break;
            }
            break;

        case 丹药Type.英雄火焰伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.火焰伤害 = 5; break;
                case QualityType.玄品: 丹药属性.火焰伤害 = 10; break;
                case QualityType.地品: 丹药属性.火焰伤害 = 25; break;
                case QualityType.天品: 丹药属性.火焰伤害 = 50; break;
                case QualityType.宇品: 丹药属性.火焰伤害 = 100; break;
                case QualityType.宙品: 丹药属性.火焰伤害 = 200; break;
                case QualityType.洪品: 丹药属性.火焰伤害 = 500; break;
                case QualityType.荒品: 丹药属性.火焰伤害 = 2000; break;
            }
            break;

        case 丹药Type.英雄冰霜伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.冰霜伤害 = 5; break;
                case QualityType.玄品: 丹药属性.冰霜伤害 = 10; break;
                case QualityType.地品: 丹药属性.冰霜伤害 = 25; break;
                case QualityType.天品: 丹药属性.冰霜伤害 = 50; break;
                case QualityType.宇品: 丹药属性.冰霜伤害 = 100; break;
                case QualityType.宙品: 丹药属性.冰霜伤害 = 200; break;
                case QualityType.洪品: 丹药属性.冰霜伤害 = 500; break;
                case QualityType.荒品: 丹药属性.冰霜伤害 = 2000; break;
            }
            break;

        case 丹药Type.英雄雷电伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.雷电伤害 = 5; break;
                case QualityType.玄品: 丹药属性.雷电伤害 = 10; break;
                case QualityType.地品: 丹药属性.雷电伤害 = 25; break;
                case QualityType.天品: 丹药属性.雷电伤害 = 50; break;
                case QualityType.宇品: 丹药属性.雷电伤害 = 100; break;
                case QualityType.宙品: 丹药属性.雷电伤害 = 200; break;
                case QualityType.洪品: 丹药属性.雷电伤害 = 500; break;
                case QualityType.荒品: 丹药属性.雷电伤害 = 2000; break;
            }
            break;

        case 丹药Type.英雄黑暗伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.黑暗伤害 = 5; break;
                case QualityType.玄品: 丹药属性.黑暗伤害 = 10; break;
                case QualityType.地品: 丹药属性.黑暗伤害 = 25; break;
                case QualityType.天品: 丹药属性.黑暗伤害 = 50; break;
                case QualityType.宇品: 丹药属性.黑暗伤害 = 100; break;
                case QualityType.宙品: 丹药属性.黑暗伤害 = 200; break;
                case QualityType.洪品: 丹药属性.黑暗伤害 = 500; break;
                case QualityType.荒品: 丹药属性.黑暗伤害 = 2000; break;
            }
            break;

        case 丹药Type.英雄物理伤害:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.物理伤害 = 5; break;
                case QualityType.玄品: 丹药属性.物理伤害 = 10; break;
                case QualityType.地品: 丹药属性.物理伤害 = 25; break;
                case QualityType.天品: 丹药属性.物理伤害 = 50; break;
                case QualityType.宇品: 丹药属性.物理伤害 = 100; break;
                case QualityType.宙品: 丹药属性.物理伤害 = 200; break;
                case QualityType.洪品: 丹药属性.物理伤害 = 500; break;
                case QualityType.荒品: 丹药属性.物理伤害 = 2000; break;
            }
            break;

        // ========== 掉宝率 ==========
        case 丹药Type.掉宝率:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.掉宝率 = 10; break;
                case QualityType.玄品: 丹药属性.掉宝率 = 20; break;
                case QualityType.地品: 丹药属性.掉宝率 = 30; break;
                case QualityType.天品: 丹药属性.掉宝率 = 50; break;
                case QualityType.宇品: 丹药属性.掉宝率 = 80; break;
                case QualityType.宙品: 丹药属性.掉宝率 = 120; break;
                case QualityType.洪品: 丹药属性.掉宝率 = 180; break;
                case QualityType.荒品: 丹药属性.掉宝率 = 300; break;
            }
            break;

        // ========== 修炼速度 ==========
        case 丹药Type.修炼速度:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.修炼速度 = 10; break;
                case QualityType.玄品: 丹药属性.修炼速度 = 20; break;
                case QualityType.地品: 丹药属性.修炼速度 = 30; break;
                case QualityType.天品: 丹药属性.修炼速度 = 50; break;
                case QualityType.宇品: 丹药属性.修炼速度 = 80; break;
                case QualityType.宙品: 丹药属性.修炼速度 = 120; break;
                case QualityType.洪品: 丹药属性.修炼速度 = 180; break;
                case QualityType.荒品: 丹药属性.修炼速度 = 300; break;
            }
            break;

        // ========== 加跟脚 ==========
        case 丹药Type.加跟脚:
            switch (qualityType)
            {
                case QualityType.黄品: 丹药属性.加跟脚 = 5; break;
                case QualityType.玄品: 丹药属性.加跟脚 = 10; break;
                case QualityType.地品: 丹药属性.加跟脚 = 20; break;
                case QualityType.天品: 丹药属性.加跟脚 = 30; break;
                case QualityType.宇品: 丹药属性.加跟脚 = 50; break;
                case QualityType.宙品: 丹药属性.加跟脚 = 80; break;
                case QualityType.洪品: 丹药属性.加跟脚 = 120; break;
                case QualityType.荒品: 丹药属性.加跟脚 = 180; break;
            }
            break;
    }

    return 丹药属性;
}

    /// <summary>获取丹药效果数值。1阶为基础值，每升一阶翻 丹药阶数倍数 倍</summary>
    public static float Get丹药值(丹药Type type, QualityType qualityType, int 阶段 = 1)
    {
        return Get丹药值基础(type, qualityType) * (float)Math.Pow(丹药阶数倍数, 阶段 - 1)
            * (1f + 属性config.仙子总属性.丹药效果 / 100f);
    }

    private static float Get丹药值基础(丹药Type type, QualityType qualityType)
    {
        switch (type)
        {
            case 丹药Type.火焰伤害:
            case 丹药Type.冰霜伤害:
            case 丹药Type.雷电伤害:
            case 丹药Type.黑暗伤害:
            case 丹药Type.物理伤害:
            case 丹药Type.战士伤害:
            case 丹药Type.射手伤害:
            case 丹药Type.法师伤害:
            case 丹药Type.控制伤害:
                switch (qualityType)
                {
                    case QualityType.黄品: return 10;
                    case QualityType.玄品: return 20;
                    case QualityType.地品: return 30;
                    case QualityType.天品: return 50;
                    case QualityType.宇品: return 80;
                    case QualityType.宙品: return 120;
                    case QualityType.洪品: return 180;
                    case QualityType.荒品: return 300;
                }

                break;
            case 丹药Type.最终伤害:
                switch (qualityType)
                {
                    case QualityType.黄品: return 5;
                    case QualityType.玄品: return 10;
                    case QualityType.地品: return 20;
                    case QualityType.天品: return 30;
                    case QualityType.宇品: return 50;
                    case QualityType.宙品: return 80;
                    case QualityType.洪品: return 120;
                    case QualityType.荒品: return 180;
                }

                break;
            case 丹药Type.英雄最终伤害:
            case 丹药Type.英雄暴击伤害:
            case 丹药Type.英雄火焰伤害:
            case 丹药Type.英雄冰霜伤害:
            case 丹药Type.英雄雷电伤害:
            case 丹药Type.英雄黑暗伤害:
            case 丹药Type.英雄物理伤害:
                switch (qualityType)
                {
                    case QualityType.黄品: return 5;
                    case QualityType.玄品: return 10;
                    case QualityType.地品: return 20;
                    case QualityType.天品: return 30;
                    case QualityType.宇品: return 50;
                    case QualityType.宙品: return 80;
                    case QualityType.洪品: return 120;
                    case QualityType.荒品: return 180;
                }

                break;

            case 丹药Type.掉宝率:
                switch (qualityType)
                {
                    case QualityType.黄品: return 5;
                    case QualityType.玄品: return 10;
                    case QualityType.地品: return 15;
                    case QualityType.天品: return 25;
                    case QualityType.宇品: return 40;
                    case QualityType.宙品: return 60;
                    case QualityType.洪品: return 100;
                    case QualityType.荒品: return 200;
                }

                break;

            case 丹药Type.修炼速度:
                switch (qualityType)
                {
                    case QualityType.黄品: return 10;
                    case QualityType.玄品: return 20;
                    case QualityType.地品: return 30;
                    case QualityType.天品: return 50;
                    case QualityType.宇品: return 80;
                    case QualityType.宙品: return 120;
                    case QualityType.洪品: return 180;
                    case QualityType.荒品: return 300;
                }

                break;

            case 丹药Type.加跟脚:
                switch (qualityType)
                {
                    case QualityType.黄品: return 3;
                    case QualityType.玄品: return 5;
                    case QualityType.地品: return 10;
                    case QualityType.天品: return 15;
                    case QualityType.宇品: return 25;
                    case QualityType.宙品: return 40;
                    case QualityType.洪品: return 60;
                    case QualityType.荒品: return 100;
                }

                break;
        }

        return 0;
    }

    public static float Get造化丹药总值()
    {
        float count = 0;
        for (int i = 0; i < PlayerData.S.造化丹药List.Count; i++)
        {
            // 阶段列表与品质列表按索引一一对应，旧档缺阶段记录时按 1 阶计
            int 阶段 = i < PlayerData.S.造化丹药阶段List.Count ? PlayerData.S.造化丹药阶段List[i] : 1;
            count += Get丹药值(丹药Type.加跟脚, PlayerData.S.造化丹药List[i], 阶段);
        }

        return count*(1f+体质Config.当前体质总属性.丹药效果/100f);
    }

    public static float Get丹药价格(丹药Type 丹药Type, QualityType qualityType)
    {
        var 丹药类型 = 丹药类型Dic[丹药Type];
        switch (丹药类型)
        {
            case 丹药类型.战斗丹药:
                return 坊市Config.战斗丹药价格Dic[qualityType];
            case 丹药类型.辅助丹药:
                return 坊市Config.辅助丹药价格Dic[qualityType];
            case 丹药类型.根基丹药:
                return 坊市Config.根基丹药价格Dic[qualityType];
            case 丹药类型.造化丹药:
                return 坊市Config.造化丹药价格Dic[qualityType];
        }

        return 0;
    }
    
    public static float Get丹药分解价格(丹药Type 丹药Type, QualityType qualityType, int 阶段 = 1)
    {
        var 丹药类型 = 丹药类型Dic[丹药Type];
        // 分解价格与属性一致按阶段翻倍：N阶 = 基础价 × 丹药阶数倍数^(N-1)
        float 倍率 = (float)Math.Pow(丹药阶数倍数, 阶段 - 1);
        switch (丹药类型)
        {
            case 丹药类型.战斗丹药:
                return 坊市Config.战斗丹药分解价格Dic[qualityType] * 倍率;
            case 丹药类型.辅助丹药:
                return 坊市Config.辅助丹药分解价格Dic[qualityType] * 倍率;
            case 丹药类型.根基丹药:
                return 坊市Config.根基丹药分解价格Dic[qualityType] * 倍率;
            case 丹药类型.造化丹药:
                return 坊市Config.造化丹药分解价格Dic[qualityType] * 倍率;
        }

        return 0;
    }
    
    public static float Get丹方价格(丹药Type 丹药Type, QualityType qualityType)
    {
        var 丹药类型 = 丹药类型Dic[丹药Type];
        switch (丹药类型)
        {
            case 丹药类型.战斗丹药:
                return 坊市Config.战斗丹方价格Dic[qualityType];
            case 丹药类型.辅助丹药:
                return 坊市Config.辅助丹方价格Dic[qualityType];
            case 丹药类型.根基丹药:
                return 坊市Config.根基丹方价格Dic[qualityType];
            case 丹药类型.造化丹药:
                return 坊市Config.造化丹方价格Dic[qualityType];
        }

        return 0;
    }

    public static string Get丹药Desc(丹药Type 丹药Type, QualityType qualityType, int 阶段 = 1)
    {
        string 丹药值 = Get丹药值(丹药Type, qualityType, 阶段).ToString();
        switch (丹药Type)
        {
            case 丹药Type.火焰伤害:
                return $"战斗时服用,增加{丹药值}%的火焰伤害";
            case 丹药Type.黑暗伤害:
                return $"战斗时服用,增加{丹药值}%的黑暗伤害";
            case 丹药Type.冰霜伤害:
                return $"战斗时服用,增加{丹药值}%的冰霜伤害";
            case 丹药Type.雷电伤害:
                return $"战斗时服用,增加{丹药值}%的雷电伤害";
            case 丹药Type.物理伤害:
                return $"战斗时服用,增加{丹药值}%的物理伤害";
            case 丹药Type.战士伤害:
                return $"战斗时服用,增加{丹药值}%的战士伤害";
            case 丹药Type.射手伤害:
                return $"战斗时服用,增加{丹药值}%的射手伤害";
            case 丹药Type.法师伤害:
                return $"战斗时服用,增加{丹药值}%的法师伤害";
            case 丹药Type.控制伤害:
                return $"战斗时服用,增加{丹药值}%的控制伤害";
            case 丹药Type.最终伤害:
                return $"战斗时服用,增加{丹药值}%的最终伤害";


            case 丹药Type.英雄火焰伤害:
                return $"服用后增加英雄{丹药值}%的火焰伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄黑暗伤害:
                return $"服用后增加英雄{丹药值}%的黑暗伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄冰霜伤害:
                return $"服用后增加英雄{丹药值}%的冰霜伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄雷电伤害:
                return $"服用后增加英雄{丹药值}%的雷电伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄物理伤害:
                return $"服用后增加英雄{丹药值}%的物理伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄最终伤害:
                return $"服用后增加英雄{丹药值}%的最终伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄暴击伤害:
                return $"服用后增加英雄{丹药值}%的暴击伤害,每个英雄每品质丹药最多可服用5次";
            
            case 丹药Type.掉宝率:
                return $"服用后增加{丹药值}%的掉宝率,持续一道年";
            case 丹药Type.修炼速度:
                return $"服用后增加{丹药值}%的修炼速度,持续一道年";
            case 丹药Type.加跟脚:
                return $"服用后永久增加{丹药值}%的跟脚,轮回保留";
        }
        return null;
    }

    public static Dictionary<丹药Type, string> 丹药名Dic = new Dictionary<丹药Type, string>()
    {
        { 丹药Type.None, "无" },
        { 丹药Type.火焰伤害, "火元丹" },
        { 丹药Type.冰霜伤害, "霜华丹" },
        { 丹药Type.雷电伤害, "雷魄丹" },
        { 丹药Type.黑暗伤害, "玄冥丹" },
        { 丹药Type.物理伤害, "破罡丹" },
        { 丹药Type.战士伤害, "虎力丹" },
        { 丹药Type.法师伤害, "灵蕴丹" },
        { 丹药Type.射手伤害, "凝矢丹" },
        { 丹药Type.控制伤害, "缚灵丹" },
        { 丹药Type.最终伤害, "归元丹" },
        { 丹药Type.修炼速度, "悟道丹" },
        { 丹药Type.掉宝率, "寻龙丹" },
        { 丹药Type.英雄暴击伤害, "绝杀丹" },
        { 丹药Type.加跟脚, "造化丹" },
        { 丹药Type.英雄火焰伤害, "凤火丹" },
        { 丹药Type.英雄冰霜伤害, "玄冰丹" },
        { 丹药Type.英雄雷电伤害, "奔雷丹" },
        { 丹药Type.英雄黑暗伤害, "幽泉丹" },
        { 丹药Type.英雄物理伤害, "金刚丹" },

        { 丹药Type.英雄最终伤害, "混元丹" },
    };
    
    public static Dictionary<丹药Type, string> 丹方DescDic = new Dictionary<丹药Type, string>()
    {
        { 丹药Type.None, "无" },
        { 丹药Type.火焰伤害, "使用后可炼制火元丹" },
        { 丹药Type.冰霜伤害, "使用后可炼制霜华丹" },
        { 丹药Type.雷电伤害, "使用后可炼制雷魄丹" },
        { 丹药Type.黑暗伤害, "使用后可炼制玄冥丹" },
        { 丹药Type.物理伤害, "使用后可炼制破罡丹" },
        { 丹药Type.战士伤害, "使用后可炼制虎力丹" },
        { 丹药Type.法师伤害, "使用后可炼制灵蕴丹" },
        { 丹药Type.射手伤害, "使用后可炼制凝矢丹" },
        { 丹药Type.控制伤害, "使用后可炼制缚灵丹" },
        { 丹药Type.最终伤害, "使用后可炼制归元丹" },
        { 丹药Type.修炼速度, "使用后可炼制悟道丹" },
        { 丹药Type.掉宝率, "使用后可炼制寻龙丹" },
        { 丹药Type.英雄暴击伤害, "使用后可炼制绝杀丹" },
        { 丹药Type.加跟脚, "使用后可炼制造化丹" },
        { 丹药Type.英雄火焰伤害, "使用后可炼制凤火丹" },
        { 丹药Type.英雄冰霜伤害, "使用后可炼制玄冰丹" },
        { 丹药Type.英雄雷电伤害, "使用后可炼制奔雷丹" },
        { 丹药Type.英雄黑暗伤害, "使用后可炼制幽泉丹" },
        { 丹药Type.英雄物理伤害, "使用后可炼制金刚丹" },

        { 丹药Type.英雄最终伤害, "使用后可炼制混元丹" },
    };
    
    
    public static Dictionary<丹药Type, string> 丹方名Dic = new Dictionary<丹药Type, string>()
    {
        { 丹药Type.None, "无" },
        { 丹药Type.火焰伤害, "火元丹方" },
        { 丹药Type.冰霜伤害, "霜华丹方" },
        { 丹药Type.雷电伤害, "雷魄丹方" },
        { 丹药Type.黑暗伤害, "玄冥丹方" },
        { 丹药Type.物理伤害, "破罡丹方" },
        { 丹药Type.战士伤害, "虎力丹方" },
        { 丹药Type.法师伤害, "灵蕴丹方" },
        { 丹药Type.射手伤害, "凝矢丹方" },
        { 丹药Type.控制伤害, "缚灵丹方" },
        { 丹药Type.最终伤害, "归元丹方" },
        { 丹药Type.修炼速度, "悟道丹方" },
        { 丹药Type.掉宝率, "寻龙丹方" },
        { 丹药Type.英雄暴击伤害, "绝杀丹方" },
        { 丹药Type.加跟脚, "造化丹方" },
        { 丹药Type.英雄火焰伤害, "凤火丹方" },
        { 丹药Type.英雄冰霜伤害, "玄冰丹方" },
        { 丹药Type.英雄雷电伤害, "奔雷丹方" },
        { 丹药Type.英雄黑暗伤害, "幽泉丹方" },
        { 丹药Type.英雄物理伤害, "金刚丹方" },

        { 丹药Type.英雄最终伤害, "混元丹方" },
    };
    
    public static Dictionary<丹药Type, List<灵药Type>> 丹方Dic = new Dictionary<丹药Type, List<灵药Type>>()
    {
        // 按顺序轮换，保证每种灵药出现的频率几乎相等（每种刚好被用到8~9次）
        { 丹药Type.火焰伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.马兜铃果, 灵药Type.四叶参根, 灵药Type.千年雪莲 } },
        { 丹药Type.冰霜伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.补血花, 灵药Type.龙纹草, 灵药Type.九曲黄泉草 } },
        { 丹药Type.雷电伤害, new List<灵药Type> { 灵药Type.千幻蝶恋花, 灵药Type.聚灵凝神叶, 灵药Type.金银花蕊, 灵药Type.马兜铃果 } },
        { 丹药Type.黑暗伤害, new List<灵药Type> { 灵药Type.四叶参根, 灵药Type.千年雪莲, 灵药Type.回春草, 灵药Type.补血花 } },
        { 丹药Type.物理伤害, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.九曲黄泉草, 灵药Type.千幻蝶恋花, 灵药Type.聚灵凝神叶 } },
        { 丹药Type.战士伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.四叶参根, 灵药Type.补血花, 灵药Type.九曲黄泉草 } },
        { 丹药Type.法师伤害, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.千年雪莲, 灵药Type.龙纹草, 灵药Type.千幻蝶恋花 } },
        { 丹药Type.射手伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.聚灵凝神叶, 灵药Type.金银花蕊, 灵药Type.四叶参根 } },
        { 丹药Type.控制伤害, new List<灵药Type> { 灵药Type.补血花, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草, 灵药Type.千年雪莲 } },
        { 丹药Type.最终伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.千年雪莲, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草 } },
        { 丹药Type.修炼速度, new List<灵药Type> { 灵药Type.四叶参根, 灵药Type.龙纹草, 灵药Type.补血花, 灵药Type.千幻蝶恋花 } },
        { 丹药Type.掉宝率, new List<灵药Type> { 灵药Type.回春草, 灵药Type.聚灵凝神叶, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草 } },
        { 丹药Type.英雄暴击伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.千年雪莲, 灵药Type.龙纹草, 灵药Type.四叶参根 } },
        { 丹药Type.加跟脚, new List<灵药Type> { 灵药Type.补血花, 灵药Type.千幻蝶恋花, 灵药Type.马兜铃果, 灵药Type.聚灵凝神叶 } },
        { 丹药Type.英雄火焰伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.回春草, 灵药Type.金银花蕊, 灵药Type.龙纹草 } },
        { 丹药Type.英雄冰霜伤害, new List<灵药Type> { 灵药Type.千年雪莲, 灵药Type.四叶参根, 灵药Type.千幻蝶恋花, 灵药Type.补血花 } },
        { 丹药Type.英雄雷电伤害, new List<灵药Type> { 灵药Type.聚灵凝神叶, 灵药Type.马兜铃果, 灵药Type.回春草, 灵药Type.九曲黄泉草 } },
        { 丹药Type.英雄黑暗伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.龙纹草, 灵药Type.千年雪莲, 灵药Type.千幻蝶恋花 } },
        { 丹药Type.英雄物理伤害, new List<灵药Type> { 灵药Type.四叶参根, 灵药Type.补血花, 灵药Type.聚灵凝神叶, 灵药Type.马兜铃果 } },
        { 丹药Type.英雄最终伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.九曲黄泉草, 灵药Type.龙纹草, 灵药Type.千年雪莲 } },
    };

    // ============ 新增：按阶数维度的配置（替代旧的品质维度Dic） ============

    /// <summary>阶数→品质映射（每2阶一组：1-2黄/3-4玄/5-6地/7-8天/9-10宇/11-12宙/13-14洪/15-16荒）</summary>
    public static QualityType Get材料品质(int 阶数)
    {
        if (阶数 < 1 || 阶数 > 16) return QualityType.黄品;
        return (QualityType)((阶数 - 1) / 2 + 1);
    }

    /// <summary>阶数→单种材料数量（奇数阶1个，偶数阶3个：1阶1/2阶3/3阶1/4阶3...）</summary>
    public static int Get单种材料数量(int 阶数)
    {
        return 阶数 % 2 == 0 ? 3 : 1;
    }

    /// <summary>炼制造化丹药时，灵植品质→可用灵植Type列表（每种品质取前4种，不足4则取该品质全部）</summary>
    public static List<灵植Type> Get造化灵植列表(QualityType qualityType)
    {
        var list = new List<灵植Type>();
        foreach (var kvp in 灵植园Config.灵植品质Dic)
        {
            if (kvp.Value == qualityType) list.Add(kvp.Key);
            if (list.Count >= 4) break;
        }
        return list;
    }

    /// <summary>造化丹药（加跟脚）的基础灵植类型配置（按品质轮序排列）</summary>
    public static Dictionary<QualityType, List<灵植Type>> 造化丹药灵植Dic = new Dictionary<QualityType, List<灵植Type>>
    {
        { QualityType.黄品, new List<灵植Type> { 灵植Type.紫云英, 灵植Type.曜日葵, 灵植Type.幻音铃, 灵植Type.幻紫玫 } },
        { QualityType.玄品, new List<灵植Type> { 灵植Type.九幽紫, 灵植Type.赤焰百合, 灵植Type.碧海螺, 灵植Type.粉面佛莲 } },
        { QualityType.地品, new List<灵植Type> { 灵植Type.紫幽草, 灵植Type.三生花, 灵植Type.向阳花, 灵植Type.白玉玲 } },
        { QualityType.天品, new List<灵植Type> { 灵植Type.赤阳花, 灵植Type.寒星兰, 灵植Type.赤霞花, 灵植Type.惊雷子 } },
        { QualityType.宇品, new List<灵植Type> { 灵植Type.幽兰铃, 灵植Type.空谷幽兰, 灵植Type.醉仙球, 灵植Type.醉仙菌 } },
        { QualityType.宙品, new List<灵植Type> { 灵植Type.太素花, 灵植Type.灵犀铃, 灵植Type.血菩提, 灵植Type.紫晶铃 } },
        { QualityType.洪品, new List<灵植Type> { 灵植Type.招财草, 灵植Type.粉霞仙, 灵植Type.黄龙掌, 灵植Type.玄冰魄 } },
        { QualityType.荒品, new List<灵植Type> { 灵植Type.修罗花, 灵植Type.金乌葵, 灵植Type.幻樱木, 灵植Type.白玉莲 } },
    };

    // ============ 炼丹等级要求（按阶数1-16，替代旧品质Dic） ============
    public static Dictionary<丹药类型, Dictionary<int, long>> 炼丹等级要求Dic = new Dictionary<丹药类型, Dictionary<int, long>>
    {
        { 丹药类型.战斗丹药, new Dictionary<int, long>
            { {1,1},{2,3},{3,5},{4,8},{5,12},{6,16},{7,20},{8,25},{9,30},{10,36},{11,42},{12,48},{13,55},{14,62},{15,70},{16,80} } },
        { 丹药类型.辅助丹药, new Dictionary<int, long>
            { {1,2},{2,5},{3,8},{4,12},{5,17},{6,22},{7,28},{8,34},{9,40},{10,47},{11,54},{12,62},{13,70},{14,80},{15,90},{16,100} } },
        { 丹药类型.根基丹药, new Dictionary<int, long>
            { {1,4},{2,8},{3,14},{4,20},{5,27},{6,34},{7,42},{8,50},{9,58},{10,68},{11,78},{12,90},{13,102},{14,115},{15,130},{16,150} } },
        { 丹药类型.造化丹药, new Dictionary<int, long>
            { {1,5},{2,12},{3,20},{4,28},{5,37},{6,47},{7,58},{8,70},{9,82},{10,96},{11,110},{12,126},{13,142},{14,160},{15,180},{16,200} } },
    };

    // ============ 炼制时间（按阶数1-16，单位=基础时间×每年秒数系数，替代旧品质Dic） ============
    public static Dictionary<丹药类型, Dictionary<int, float>> 炼丹时间Dic = new Dictionary<丹药类型, Dictionary<int, float>>
    {
        { 丹药类型.战斗丹药, new Dictionary<int, float>
            { {1,0.1f},{2,0.15f},{3,0.2f},{4,0.25f},{5,0.3f},{6,0.35f},{7,0.4f},{8,0.5f},{9,0.6f},{10,0.7f},{11,0.8f},{12,0.9f},{13,1.0f},{14,1.2f},{15,1.4f},{16,1.6f} } },
        { 丹药类型.辅助丹药, new Dictionary<int, float>
            { {1,0.15f},{2,0.25f},{3,0.35f},{4,0.45f},{5,0.55f},{6,0.65f},{7,0.8f},{8,0.9f},{9,1.1f},{10,1.3f},{11,1.5f},{12,1.7f},{13,2.0f},{14,2.3f},{15,2.6f},{16,3.0f} } },
        { 丹药类型.根基丹药, new Dictionary<int, float>
            { {1,0.2f},{2,0.35f},{3,0.5f},{4,0.65f},{5,0.8f},{6,0.95f},{7,1.1f},{8,1.3f},{9,1.5f},{10,1.7f},{11,2.0f},{12,2.3f},{13,2.6f},{14,3.0f},{15,3.4f},{16,4.0f} } },
        { 丹药类型.造化丹药, new Dictionary<int, float>
            { {1,0.3f},{2,0.5f},{3,0.7f},{4,0.9f},{5,1.2f},{6,1.5f},{7,1.8f},{8,2.1f},{9,2.5f},{10,3.0f},{11,3.5f},{12,4.0f},{13,4.5f},{14,5.0f},{15,6.0f},{16,7.0f} } },
    };

    // ============ 炼制经验（按阶数1-16，替代旧品质Dic） ============
    public static Dictionary<丹药类型, Dictionary<int, long>> 炼丹经验Dic = new Dictionary<丹药类型, Dictionary<int, long>>
    {
        { 丹药类型.战斗丹药, new Dictionary<int, long>
            { {1,30},{2,60},{3,120},{4,240},{5,500},{6,1000},{7,2000},{8,4000},{9,8000},{10,15000},{11,30000},{12,60000},{13,120000},{14,250000},{15,500000},{16,1000000} } },
        { 丹药类型.辅助丹药, new Dictionary<int, long>
            { {1,50},{2,100},{3,200},{4,400},{5,800},{6,1500},{7,3000},{8,6000},{9,12000},{10,25000},{11,50000},{12,100000},{13,200000},{14,400000},{15,800000},{16,1500000} } },
        { 丹药类型.根基丹药, new Dictionary<int, long>
            { {1,100},{2,200},{3,400},{4,800},{5,1500},{6,3000},{7,6000},{8,12000},{9,25000},{10,50000},{11,100000},{12,200000},{13,400000},{14,800000},{15,1600000},{16,3000000} } },
        { 丹药类型.造化丹药, new Dictionary<int, long>
            { {1,300},{2,600},{3,1200},{4,2400},{5,5000},{6,10000},{7,20000},{8,40000},{9,80000},{10,150000},{11,300000},{12,600000},{13,1200000},{14,2500000},{15,5000000},{16,10000000} } },
    };

    // ============ 炼丹等级升级经验 ============
    // 旧字典（float/float类型但存整数，直接复用）见 514行 炼丹等级经验Dic

    // ============ 品质概率（固定值，品质随机时按此概率抽取） ============
    // 顺序：黄、玄、地、天、宇、宙、洪、荒，权重越高越容易出
    public static Dictionary<QualityType, float> 品质概率Dic = new Dictionary<QualityType, float>
    {
        { QualityType.黄品, 45 },
        { QualityType.玄品, 30 },
        { QualityType.地品, 15 },
        { QualityType.天品, 6 },
        { QualityType.宇品, 2.5f },
        { QualityType.宙品, 1 },
        { QualityType.洪品, 0.4f },
        { QualityType.荒品, 0.1f },
    };

    /// <summary>按品质概率Dic随机抽取品质</summary>
    public static QualityType 随机品质()
    {
        float random = UnityEngine.Random.value * 100f;
        float 累计 = 0;
        foreach (var kvp in 品质概率Dic)
        {
            累计 += kvp.Value;
            if (random <= 累计) return kvp.Key;
        }
        return QualityType.黄品;
    }

    // ============ 新的方法：按阶数获取炼制参数 ============

    /// <summary>按阶数获取炼丹等级要求</summary>
    public static long Get炼丹等级要求(丹药Type type, int 阶数)
    {
        丹药类型 类型 = 丹药类型Dic[type];
        if (炼丹等级要求Dic.TryGetValue(类型, out var dic) && dic.TryGetValue(阶数, out var value))
            return value;
        return 0;
    }

    /// <summary>按阶数获取炼制经验</summary>
    public static float Get炼制经验(丹药Type type, int 阶数)
    {
        丹药类型 类型 = 丹药类型Dic[type];
        float 经验 = 0;
        if (炼丹经验Dic.TryGetValue(类型, out var dic) && dic.TryGetValue(阶数, out var v))
            经验 = v;
        return 经验 * (1f + 体质Config.当前体质总属性.炼丹经验加成 / 100f)
                   * (1f + 道场Config.供奉总属性.增加炼丹经验 / 100f)
                   * (1f + 属性config.仙子总属性.炼丹经验 / 100f);
    }

    /// <summary>按阶数获取炼制时间</summary>
    public static float Get炼制时间(丹药Type type, int 阶数)
    {
        丹药类型 类型 = 丹药类型Dic[type];
        float 系数 = 0;
        if (炼丹时间Dic.TryGetValue(类型, out var dic) && dic.TryGetValue(阶数, out var v))
            系数 = v;
        float 需要时间 = 属性config.每年秒数 * 系数;
        需要时间 /= (1f + 体质Config.当前体质总属性.炼丹速度 / 100f);
        需要时间 /= (1f + 道场Config.供奉总属性.炼丹速度 / 100f);
        需要时间 /= (1f + 属性config.仙子总属性.炼丹速度 / 100f);
        return 需要时间 / (1f + 体质Config.当前体质总属性.炼丹速度 / 100f);
    }

    /// <summary>获取炼丹品质概率说明文本</summary>
    public static string Get品质概率说明()
    {
        var sb = new System.Text.StringBuilder();
        foreach (var kvp in 品质概率Dic)
        {
            sb.AppendLine($"{PropConfig.QualityNameDic[kvp.Key]}品: {kvp.Value}%");
        }
        return sb.ToString();
    }
}
