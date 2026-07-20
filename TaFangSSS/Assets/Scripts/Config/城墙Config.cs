using System.Collections.Generic;
using Config;

public enum 城墙道具Type
{
    None,
    不动明王阵,
    不周山柱,
    不朽魂晶,
    不死木,
    不灭玄石,
    九曲黄河阵,
    初源露,
    厚土珠,
    反伤岩,
    周天星斗大阵,
    土灵珠,
    地髓晶,
    大道本源,
    天命罗盘,
    天机石,
    天罡石,
    山河阵盘,
    星辰沙,
    星辰铁,
    永恒之火,
    混沌磐石,
    灵兽骨粉,
    灵石尘,
    灵藤蔓,
    玄武石,
    玄黄之气,
    百年桃木,
    蛟龙骨,
    血琥珀,
    轮回印记,
    雷击木,
    鸿蒙灵根,
}
public class 城墙Config
{
    public static Dictionary<QualityType, int> 城墙解锁等级Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,10},
        { QualityType.玄品 ,20},
        { QualityType.地品 ,30},
        { QualityType.天品 ,40},
        { QualityType.宇品 ,50},
        { QualityType.宙品 ,60},
        { QualityType.洪品 ,70},
        { QualityType.荒品 ,80},

    };

    public static QualityType Get城墙Quality()
    {
        if (PlayerData.S.城墙等级 <= 10)
        {
            return QualityType.黄品;
        }
        else if (PlayerData.S.城墙等级 <= 20)
        {
            return QualityType.玄品;
        }else if (PlayerData.S.城墙等级 <= 30)
        {
            return QualityType.地品;
        }else if (PlayerData.S.城墙等级 <= 40)
        {
            return QualityType.天品;
        }else if (PlayerData.S.城墙等级 <= 50)
        {
            return QualityType.宇品;
        }else if (PlayerData.S.城墙等级 <= 60)
        {
            return QualityType.宙品;
        }else if (PlayerData.S.城墙等级 <= 70)
        {
            return QualityType.洪品;
        }else
        {
            return QualityType.荒品;
        }
    }

    public static string Get城墙名()
    {
        if (PlayerData.S.城墙等级 <= 10)
        {
            return 城墙名Dic[QualityType.黄品];
        }
        else if (PlayerData.S.城墙等级 <= 20)
        {
            return 城墙名Dic[QualityType.玄品];
        }else if (PlayerData.S.城墙等级 <= 30)
        {
            return 城墙名Dic[QualityType.地品];
        }else if (PlayerData.S.城墙等级 <= 40)
        {
            return 城墙名Dic[QualityType.天品];
        }else if (PlayerData.S.城墙等级 <= 50)
        {
            return 城墙名Dic[QualityType.宇品];
        }else if (PlayerData.S.城墙等级 <= 60)
        {
            return 城墙名Dic[QualityType.宙品];
        }else if (PlayerData.S.城墙等级 <= 70)
        {
            return 城墙名Dic[QualityType.洪品];
        }else
        {
            return 城墙名Dic[QualityType.荒品];
        }
    }
    
    public static Dictionary<QualityType, string> 城墙名Dic = new Dictionary<QualityType, string>()
    {
        { QualityType.黄品 ,"白石垒"},
        { QualityType.玄品 ,"木灵墙"},
        { QualityType.地品 ,"青冥壁"},
        { QualityType.天品 ,"紫府玄关"},
        { QualityType.宇品 ,"古烬垣"},
        { QualityType.宙品 ,"血月赤垣"},
        { QualityType.洪品 ,"无极寂垒"},
        { QualityType.荒品 ,"太初遗垣"},

    };
    public static int Get城墙升级灵气()
    {
        if (PlayerData.S.城墙等级 < 10)
        {
            return 200;
        }else if (PlayerData.S.城墙等级 < 20)
        {
            return 500;
        }else if (PlayerData.S.城墙等级 < 30)
        {
            return 2000;
        }else if (PlayerData.S.城墙等级 < 40)
        {
            return 5000;
        }else if (PlayerData.S.城墙等级 < 50)
        {
            return 20000;
        }else if (PlayerData.S.城墙等级 < 60)
        {
            return 50000;
        }else if (PlayerData.S.城墙等级 < 70)
        {
            return 200000;
        }else
        {
            return 500000;
        }
    }

    public static int Get城墙基础血量()
    {
        if (PlayerData.S.城墙等级 <= 80)
        {
            return 城墙基础血量Dic[PlayerData.S.城墙等级];
        }
        else
        {
            return 城墙基础血量Dic[80]+50000*(PlayerData.S.城墙等级 - 80);
        }
    }
    
    public static int Get城墙基础防御()
    {
        if (PlayerData.S.城墙等级 <= 80)
        {
            return 城墙基础防御Dic[PlayerData.S.城墙等级];
        }
        else 
        {
            return 城墙基础血量Dic[80]+500*(PlayerData.S.城墙等级 - 80);
        }
    }
    public static Dictionary<int, int> 城墙基础血量Dic = new Dictionary<int, int>()
    {
        {1,100},
        {2,120},
        {3,140},
        {4,160},
        {5,180},
        {6,200},
        {7,220},
        {8,240},
        {9,260},
        {10,300},
        
        {11,350},
        {12,400},
        {13,450},
        {14,500},
        {15,550},
        {16,600},
        {17,650},
        {18,700},
        {19,750},
        {20,800},
        
        {21,1000},
        {22,1200},
        {23,1400},
        {24,1600},
        {25,1800},
        {26,2000},
        {27,2200},
        {28,2400},
        {29,2600},
        {30,3000},
        
        {31,3500},
        {32,4000},
        {33,4500},
        {34,5000},
        {35,5500},
        {36,6000},
        {37,6500},
        {38,7000},
        {39,7500},
        {40,8000},
        
        {41,10000},
        {42,12000},
        {43,14000},
        {44,16000},
        {45,18000},
        {46,20000},
        {47,22000},
        {48,24000},
        {49,26000},
        {50,30000},
        
        {51,35000},
        {52,40000},
        {53,45000},
        {54,50000},
        {55,55000},
        {56,60000},
        {57,65000},
        {58,70000},
        {59,75000},
        {60,80000},
        
        {61,100000},
        {62,120000},
        {63,140000},
        {64,160000},
        {65,180000},
        {66,200000},
        {67,220000},
        {68,240000},
        {69,260000},
        {70,300000},
        
        {71,350000},
        {72,400000},
        {73,450000},
        {74,500000},
        {75,550000},
        {76,600000},
        {77,650000},
        {78,700000},
        {79,750000},
        {80,800000},
    };
    
    public static Dictionary<int, int> 城墙基础防御Dic = new Dictionary<int, int>()
    {
        {1,1},
        {2,1},
        {3,1},
        {4,1},
        {5,1},
        {6,2},
        {7,2},
        {8,2},
        {9,2},
        {10,3},
        
        {11,3},
        {12,4},
        {13,4},
        {14,5},
        {15,5},
        {16,6},
        {17,6},
        {18,7},
        {19,7},
        {20,8},
        
        {21,10},
        {22,12},
        {23,14},
        {24,16},
        {25,18},
        {26,20},
        {27,22},
        {28,24},
        {29,26},
        {30,30},
        
        {31,35},
        {32,40},
        {33,45},
        {34,50},
        {35,55},
        {36,60},
        {37,65},
        {38,70},
        {39,75},
        {40,80},
        
        {41,100},
        {42,120},
        {43,140},
        {44,160},
        {45,180},
        {46,200},
        {47,220},
        {48,240},
        {49,260},
        {50,300},
        
        {51,350},
        {52,400},
        {53,450},
        {54,500},
        {55,550},
        {56,600},
        {57,650},
        {58,700},
        {59,750},
        {60,800},
        
        {61,1000},
        {62,1200},
        {63,1400},
        {64,1600},
        {65,1800},
        {66,2000},
        {67,2200},
        {68,2400},
        {69,2600},
        {70,3000},
        
        {71,3500},
        {72,4000},
        {73,4500},
        {74,5000},
        {75,5500},
        {76,6000},
        {77,6500},
        {78,7000},
        {79,7500},
        {80,8000},
    };

    public static Dictionary<城墙道具Type, string> 城墙道具名Dic = new Dictionary<城墙道具Type, string>()
    {
        { 城墙道具Type.不动明王阵, "不动明王阵" },
        { 城墙道具Type.不周山柱, "不周山柱" },
        { 城墙道具Type.不朽魂晶, "不朽魂晶" },
        { 城墙道具Type.不死木, "不死木" },
        { 城墙道具Type.不灭玄石, "不灭玄石" },
        { 城墙道具Type.九曲黄河阵, "九曲黄河阵" },
        { 城墙道具Type.初源露, "初源露" },
        { 城墙道具Type.厚土珠, "厚土珠" },
        { 城墙道具Type.反伤岩, "反伤岩" },
        { 城墙道具Type.周天星斗大阵, "周天星斗大阵" },
        { 城墙道具Type.土灵珠, "土灵珠" },
        { 城墙道具Type.地髓晶, "地髓晶" },
        { 城墙道具Type.大道本源, "大道本源" },
        { 城墙道具Type.天命罗盘, "天命罗盘" },
        { 城墙道具Type.天机石, "天机石" },
        { 城墙道具Type.天罡石, "天罡石" },
        { 城墙道具Type.山河阵盘, "山河阵盘" },
        { 城墙道具Type.星辰沙, "星辰沙" },
        { 城墙道具Type.星辰铁, "星辰铁" },
        { 城墙道具Type.永恒之火, "永恒之火" },
        { 城墙道具Type.混沌磐石, "混沌磐石" },
        { 城墙道具Type.灵兽骨粉, "灵兽骨粉" },
        { 城墙道具Type.灵石尘, "灵石尘" },
        { 城墙道具Type.灵藤蔓, "灵藤蔓" },
        { 城墙道具Type.玄武石, "玄武石" },
        { 城墙道具Type.玄黄之气, "玄黄之气" },
        { 城墙道具Type.百年桃木, "百年桃木" },
        { 城墙道具Type.蛟龙骨, "蛟龙骨" },
        { 城墙道具Type.血琥珀, "血琥珀" },
        { 城墙道具Type.轮回印记, "轮回印记" },
        { 城墙道具Type.雷击木, "雷击木" },
        { 城墙道具Type.鸿蒙灵根, "鸿蒙灵根" },
    };

    public static Dictionary<道宝Quality, List<城墙道具Type>> 城墙道具列表Dic = new Dictionary<道宝Quality, List<城墙道具Type>>()
    {
        {
            道宝Quality.混沌至宝, new List<城墙道具Type>
            {
                城墙道具Type.混沌磐石,
                城墙道具Type.大道本源,
                城墙道具Type.鸿蒙灵根,
            }
        },
        {
            道宝Quality.先天至宝, new List<城墙道具Type>
            {
                城墙道具Type.轮回印记,
                城墙道具Type.永恒之火,
                城墙道具Type.玄黄之气,
                城墙道具Type.不周山柱,
                城墙道具Type.不朽魂晶,
            }
        },
        {
            道宝Quality.功德至宝, new List<城墙道具Type>
            {
                城墙道具Type.周天星斗大阵,
                城墙道具Type.天命罗盘,
                城墙道具Type.九曲黄河阵,
                城墙道具Type.不动明王阵,
                城墙道具Type.天罡石,
                城墙道具Type.土灵珠,
                城墙道具Type.不灭玄石,
            }
        },
        {
            道宝Quality.先天灵宝, new List<城墙道具Type>
            {
                城墙道具Type.初源露,
                城墙道具Type.不死木,
                城墙道具Type.厚土珠,
                城墙道具Type.天机石,
                城墙道具Type.山河阵盘,
                城墙道具Type.星辰沙,
                城墙道具Type.星辰铁,
            }
        },
        {
            道宝Quality.后天法宝, new List<城墙道具Type>
            {
                城墙道具Type.雷击木,
                城墙道具Type.血琥珀,
                城墙道具Type.蛟龙骨,
                城墙道具Type.百年桃木,
                城墙道具Type.玄武石,
                城墙道具Type.灵藤蔓,
                城墙道具Type.灵石尘,
                城墙道具Type.灵兽骨粉,
                城墙道具Type.地髓晶,
                城墙道具Type.反伤岩,
            }
        },
    };
    public static Dictionary<城墙道具Type, QualityType> 城墙道具QualityDic = new Dictionary<城墙道具Type, QualityType>()
    {
        { 城墙道具Type.None ,QualityType.黄品},

        { 城墙道具Type.混沌磐石 ,QualityType.荒品},
        { 城墙道具Type.大道本源 ,QualityType.荒品},
        { 城墙道具Type.鸿蒙灵根 ,QualityType.荒品},
        
        { 城墙道具Type.轮回印记 ,QualityType.洪品},
        { 城墙道具Type.永恒之火 ,QualityType.洪品},
        { 城墙道具Type.玄黄之气 ,QualityType.洪品},
        { 城墙道具Type.不周山柱 ,QualityType.洪品},
        { 城墙道具Type.不朽魂晶 ,QualityType.洪品},

        { 城墙道具Type.周天星斗大阵 ,QualityType.宙品},
        { 城墙道具Type.天命罗盘 ,QualityType.宙品},
        { 城墙道具Type.九曲黄河阵 ,QualityType.宙品},
        { 城墙道具Type.不动明王阵,QualityType.宙品},
        { 城墙道具Type.天罡石 ,QualityType.宙品},
        { 城墙道具Type.土灵珠 ,QualityType.宙品},
        { 城墙道具Type.不灭玄石 ,QualityType.宙品},

        { 城墙道具Type.初源露 ,QualityType.宇品},
        { 城墙道具Type.不死木 ,QualityType.宇品},
        { 城墙道具Type.厚土珠 ,QualityType.宇品},
        { 城墙道具Type.天机石 ,QualityType.宇品},
        { 城墙道具Type.山河阵盘 ,QualityType.宇品},
        { 城墙道具Type.星辰沙 ,QualityType.宇品},
        { 城墙道具Type.星辰铁 ,QualityType.宇品},

        { 城墙道具Type.雷击木 ,QualityType.天品},
        { 城墙道具Type.血琥珀 ,QualityType.天品},
        { 城墙道具Type.蛟龙骨 ,QualityType.天品},
        { 城墙道具Type.百年桃木 ,QualityType.天品},
        { 城墙道具Type.玄武石 ,QualityType.天品},
        { 城墙道具Type.灵藤蔓 ,QualityType.天品},
        { 城墙道具Type.灵石尘 ,QualityType.天品},
        { 城墙道具Type.灵兽骨粉 ,QualityType.天品},
        { 城墙道具Type.地髓晶 ,QualityType.天品},
        { 城墙道具Type.反伤岩 ,QualityType.天品},
    };
}
