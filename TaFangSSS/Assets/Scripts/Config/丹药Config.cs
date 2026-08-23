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
    辅助伤害,
    最终伤害,
    修炼速度,
    掉宝率,
    英雄暴击伤害,
    加跟脚,//轮回后重置
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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        丹药 other = (丹药)obj;
        return 丹药Type == other.丹药Type && QualityType == other.QualityType;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + 丹药Type.GetHashCode();
        hash = hash * 31 + QualityType.GetHashCode();
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
    public static Dictionary<丹药类型, string> 丹药类型String = new Dictionary<丹药类型, string>()
    {
        { 丹药类型.战斗丹药, "战斗丹药" },
        { 丹药类型.根基丹药, "根基丹药" },
        { 丹药类型.造化丹药, "造化丹药" },
        { 丹药类型.辅助丹药, "辅助丹药" },
    };
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

    public static int Get最大炼制数量(丹药Type type, QualityType qualityType)
    {
        var list = 丹方Dic[type];
        int min=int.MaxValue;
        for (int i = 0; i < 4; i++)
        {
            int count = 0;
            for (int j = 1; j <= 8; j++)
            {
                if (PlayerData.S.丹药灵药筛选Dic[(QualityType)j]&&(QualityType)j>=qualityType)
                {
                    count+=PlayerData.S.Get灵药数量(list[i], (QualityType)j);
                }
            }
            if(count < min)min = count;
        }
        return min;
    }

    public static float Get炼制丹药需要时间(丹药Type type, QualityType qualityType)
    {
        if (type == 丹药Type.None) return 1;
        丹药类型 当前炼制丹药类型 = 丹药类型Dic[type];
        float 需要时间 = 0;
        switch (当前炼制丹药类型)
        {
            case 丹药类型.战斗丹药:
                需要时间 = 属性config.每年秒数 * 战斗丹药炼制时间Dic[qualityType];
                break;
            case 丹药类型.辅助丹药:
                需要时间 = 属性config.每年秒数 * 辅助丹药炼制时间Dic[qualityType];
                break;
            case 丹药类型.根基丹药:
                需要时间 = 属性config.每年秒数 * 根基丹药炼制时间Dic[qualityType];
                break;
            case 丹药类型.造化丹药:
                需要时间 = 属性config.每年秒数 * 造化丹药炼制时间Dic[qualityType];
                break;
        }

        return 需要时间;
    }

    public static List<灵药> Get炼制灵药(丹药Type type, QualityType qualityType)
    {
        if (type == 丹药Type.None) return null;
        var 灵药list = 丹方Dic[type];
        List<灵药> list = new List<灵药>();
        for (int j = 0; j < 4; j++)
        {
            for (int i = 1; i <= 8; i++)
            {
                if (PlayerData.S.丹药灵药筛选Dic[(QualityType)i])
                {
                    if (PlayerData.S.Get灵药数量(灵药list[j], (QualityType)i) > 0)
                    {
                        list.Add(new 灵药(){灵药Type = 灵药list[j],QualityType = (QualityType)i});
                        break;
                    }
                }
            }
        }
        return  list;
    }
    public static Dictionary<int, int> 炼丹经验Dic = new Dictionary<int, int>()
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
        { 丹药Type.辅助伤害, 丹药类型.战斗丹药 },
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

    public static float Get丹药值(丹药Type type, QualityType qualityType)
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
            case 丹药Type.辅助伤害:
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
        }

        return 0;
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

    public static string Get丹药Desc(丹药Type 丹药Type, QualityType qualityType)
    {
        string 丹药值 = Get丹药值(丹药Type, qualityType).ToString();
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
            case 丹药Type.辅助伤害:
                return $"战斗时服用,增加{丹药值}%的辅助伤害";
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
        { 丹药Type.辅助伤害, "玄辅丹" },
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
        { 丹药Type.辅助伤害, "使用后可炼制玄辅丹" },
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
        { 丹药Type.辅助伤害, "玄辅丹方" },
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
        { 丹药Type.辅助伤害, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.千幻蝶恋花, 灵药Type.回春草, 灵药Type.聚灵凝神叶 } },
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
}
