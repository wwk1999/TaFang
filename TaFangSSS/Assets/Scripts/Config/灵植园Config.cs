using System.Collections.Generic;
using Config;

public enum 灵植Type
{
    None,
    紫云英,
    曜日葵,
    幻音铃,
    幻紫玫,
    九幽紫,
    赤焰百合,
    碧海螺,
    粉面佛莲,
    紫幽草,
    三生花,
    向阳花,
    白玉玲,
    赤阳花,
    寒星兰,
    赤霞花,
    惊雷子,
    幽兰铃,
    空谷幽兰,
    醉仙球,
    醉仙菌,
    太素花,
    灵犀铃,
    血菩提,
    紫晶铃,
    招财草,
    粉霞仙,
    黄龙掌,
    玄冰魄,
    修罗花,
    金乌葵,
    幻樱木,
    白玉莲,
}
public class 灵植园Config
{
    public static Dictionary<灵植Type, QualityType> 灵植品质Dic = new Dictionary<灵植Type, QualityType>()
    {
        // 黄品（前4个）
        { 灵植Type.紫云英, QualityType.黄品 },
        { 灵植Type.曜日葵, QualityType.黄品 },
        { 灵植Type.幻音铃, QualityType.黄品 },
        { 灵植Type.幻紫玫, QualityType.黄品 },

        // 玄品（4个）
        { 灵植Type.九幽紫, QualityType.玄品 },
        { 灵植Type.赤焰百合, QualityType.玄品 },
        { 灵植Type.碧海螺, QualityType.玄品 },
        { 灵植Type.粉面佛莲, QualityType.玄品 },

        // 地品（4个）
        { 灵植Type.紫幽草, QualityType.地品 },
        { 灵植Type.三生花, QualityType.地品 },
        { 灵植Type.向阳花, QualityType.地品 },
        { 灵植Type.白玉玲, QualityType.地品 },

        // 天品（4个）
        { 灵植Type.赤阳花, QualityType.天品 },
        { 灵植Type.寒星兰, QualityType.天品 },
        { 灵植Type.赤霞花, QualityType.天品 },
        { 灵植Type.惊雷子, QualityType.天品 },

        // 宇品（4个）
        { 灵植Type.幽兰铃, QualityType.宇品 },
        { 灵植Type.空谷幽兰, QualityType.宇品 },
        { 灵植Type.醉仙球, QualityType.宇品 },
        { 灵植Type.醉仙菌, QualityType.宇品 },

        // 宙品（4个）
        { 灵植Type.太素花, QualityType.宙品 },
        { 灵植Type.灵犀铃, QualityType.宙品 },
        { 灵植Type.血菩提, QualityType.宙品 },
        { 灵植Type.紫晶铃, QualityType.宙品 },

        // 洪品（4个）
        { 灵植Type.招财草, QualityType.洪品 },
        { 灵植Type.粉霞仙, QualityType.洪品 },
        { 灵植Type.黄龙掌, QualityType.洪品 },
        { 灵植Type.玄冰魄, QualityType.洪品 },

        // 荒品（4个）
        { 灵植Type.修罗花, QualityType.荒品 },
        { 灵植Type.金乌葵, QualityType.荒品 },
        { 灵植Type.幻樱木, QualityType.荒品 },
        { 灵植Type.白玉莲, QualityType.荒品 },
    };
    public static Dictionary<灵植Type, int> 灵植解锁等级Dic = new Dictionary<灵植Type, int>()
    {
        { 灵植Type.紫云英, 1 },
        { 灵植Type.曜日葵, 4 },
        { 灵植Type.幻音铃, 7 },
        { 灵植Type.幻紫玫, 10 },
        
        { 灵植Type.九幽紫, 13 },
        { 灵植Type.赤焰百合, 16 },
        { 灵植Type.碧海螺, 19 },
        { 灵植Type.粉面佛莲, 22 },
        
        { 灵植Type.紫幽草, 25 },
        { 灵植Type.三生花, 28 },
        { 灵植Type.向阳花, 31 },
        { 灵植Type.白玉玲, 34 },
        
        { 灵植Type.赤阳花, 37 },
        { 灵植Type.寒星兰, 40 },
        { 灵植Type.赤霞花, 43 },
        { 灵植Type.惊雷子, 46 },
        
        { 灵植Type.幽兰铃, 49 },
        { 灵植Type.空谷幽兰, 52 },
        { 灵植Type.醉仙球, 55 },
        { 灵植Type.醉仙菌, 58 },
        
        { 灵植Type.太素花, 61 },
        { 灵植Type.灵犀铃, 64 },
        { 灵植Type.血菩提, 67 },
        { 灵植Type.紫晶铃, 70 },
        
        { 灵植Type.招财草, 73 },
        { 灵植Type.粉霞仙, 76 },
        { 灵植Type.黄龙掌, 79 },
        { 灵植Type.玄冰魄, 82 },
        
        { 灵植Type.修罗花, 85 },
        { 灵植Type.金乌葵, 90 },
        { 灵植Type.幻樱木, 95 },
        { 灵植Type.白玉莲, 100 },
    };

    public static Dictionary<灵植Type, float> 灵植成熟时间Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 1 },
        { 灵植Type.曜日葵, 1.2f },
        { 灵植Type.幻音铃, 1.5f },
        { 灵植Type.幻紫玫, 2f },
        
        { 灵植Type.九幽紫, 1.5f },
        { 灵植Type.赤焰百合, 2f },
        { 灵植Type.碧海螺, 2.5f },
        { 灵植Type.粉面佛莲, 3f },
        
        { 灵植Type.紫幽草, 2f },
        { 灵植Type.三生花, 2.5f },
        { 灵植Type.向阳花, 3f },
        { 灵植Type.白玉玲, 4f },
        
        { 灵植Type.赤阳花, 3f },
        { 灵植Type.寒星兰, 3.5f },
        { 灵植Type.赤霞花, 4f },
        { 灵植Type.惊雷子, 4.5f },
        
        { 灵植Type.幽兰铃, 4f },
        { 灵植Type.空谷幽兰, 4.5f },
        { 灵植Type.醉仙球, 5f },
        { 灵植Type.醉仙菌, 5.5f },
        
        { 灵植Type.太素花, 6f },
        { 灵植Type.灵犀铃, 7f },
        { 灵植Type.血菩提, 8f },
        { 灵植Type.紫晶铃, 10f },
        
        { 灵植Type.招财草, 12f },
        { 灵植Type.粉霞仙, 15f },
        { 灵植Type.黄龙掌, 18f },
        { 灵植Type.玄冰魄, 20f },
        
        { 灵植Type.修罗花, 25f },
        { 灵植Type.金乌葵, 30f },
        { 灵植Type.幻樱木, 35f },
        { 灵植Type.白玉莲, 40f },
    };

    public static Dictionary<int, float> 灵植园等级经验 = new Dictionary<int, float>()
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
        
        {10,280},
        {11,320},
        {12,360},
        {13,400},
        {14,440},
        {15,480},
        {16,520},
        {17,560},
        {18,600},
        {19,640},
        {20,680},
        
        {21,720},
        {22,760},
        {23,840},
        {24,920},
        {25,1000},
        {26,1080},
        {27,1160},
        {28,1240},
        {29,1320},
        
        {30,1400},
        {31,1480},
        {32,1560},
        {33,1640},
        {34,1720},
        {35,1900},
        {36,2100},
        {37,2300},
        {38,2500},
        {39,2700},
        
        {40,2900},
        {41,3100},
        {42,3300},
        {43,3500},
        {44,4000},
        {45,4500},
        {46,5000},
        {47,5500},
        {48,6000},
        {49,6500},
        
        {50,7000},
        {51,7500},
        {52,8000},
        {53,9000},
        {54,10000},
        {55,11000},
        {56,12000},
        {57,13000},
        {58,14000},
        {59,15000},
        
        {60,17000},
        {61,19000},
        {62,21000},
        {63,23000},
        {64,25000},
        {65,27000},
        {66,29000},
        {67,32000},
        {68,35000},
        {69,38000},
        
        {70,41000},
        {71,45000},
        {72,50000},
        {73,55000},
        {74,60000},
        {75,65000},
        {76,70000},
        {77,75000},
        {78,80000},
        {79,90000},
        
        {80,100000},
        {81,110000},
        {82,120000},
        {83,140000},
        {84,160000},
        {85,180000},
        {86,200000},
        {87,230000},
        {88,260000},
        {89,290000},
        
        {90,320000},
        {91,360000},
        {92,400000},
        {93,450000},
        {94,500000},
        {95,600000},
        {96,700000},
        {97,800000},
        {98,900000},
        {99,1000000},
        
        {100,2000000},
        
    };

    
    public static Dictionary<灵植Type, float> 灵植收获经验Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 20 },
        { 灵植Type.曜日葵, 25 },
        { 灵植Type.幻音铃, 30 },
        { 灵植Type.幻紫玫, 40 },
        
        { 灵植Type.九幽紫, 30 },
        { 灵植Type.赤焰百合, 40 },
        { 灵植Type.碧海螺, 50 },
        { 灵植Type.粉面佛莲, 60 },
        
        { 灵植Type.紫幽草, 40 },
        { 灵植Type.三生花, 50 },
        { 灵植Type.向阳花, 60 },
        { 灵植Type.白玉玲, 80 },
        
        { 灵植Type.赤阳花, 60 },
        { 灵植Type.寒星兰, 70 },
        { 灵植Type.赤霞花, 80 },
        { 灵植Type.惊雷子, 90 },
        
        { 灵植Type.幽兰铃, 80 },
        { 灵植Type.空谷幽兰, 90 },
        { 灵植Type.醉仙球, 100 },
        { 灵植Type.醉仙菌, 110 },
        
        { 灵植Type.太素花, 120 },
        { 灵植Type.灵犀铃, 140 },
        { 灵植Type.血菩提, 160 },
        { 灵植Type.紫晶铃, 200 },
        
        { 灵植Type.招财草, 240 },
        { 灵植Type.粉霞仙, 300 },
        { 灵植Type.黄龙掌, 360 },
        { 灵植Type.玄冰魄, 400 },
        
        { 灵植Type.修罗花, 500 },
        { 灵植Type.金乌葵, 600 },
        { 灵植Type.幻樱木, 700 },
        { 灵植Type.白玉莲, 800 },
    };
    
    public static Dictionary<灵植Type, float> 灵植产量Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 10 },
        { 灵植Type.曜日葵, 12f },
        { 灵植Type.幻音铃, 15f },
        { 灵植Type.幻紫玫, 20f },
        
        { 灵植Type.九幽紫, 10 },
        { 灵植Type.赤焰百合, 12 },
        { 灵植Type.碧海螺, 15 },
        { 灵植Type.粉面佛莲, 20},
        
        { 灵植Type.紫幽草, 10 },
        { 灵植Type.三生花, 12 },
        { 灵植Type.向阳花, 15 },
        { 灵植Type.白玉玲, 20 },
        
        { 灵植Type.赤阳花, 10 },
        { 灵植Type.寒星兰, 12 },
        { 灵植Type.赤霞花, 15 },
        { 灵植Type.惊雷子, 20 },
        
        { 灵植Type.幽兰铃, 12 },
        { 灵植Type.空谷幽兰, 14 },
        { 灵植Type.醉仙球, 16 },
        { 灵植Type.醉仙菌, 18 },
        
        { 灵植Type.太素花, 12 },
        { 灵植Type.灵犀铃, 14 },
        { 灵植Type.血菩提, 16 },
        { 灵植Type.紫晶铃, 18 },
        
        { 灵植Type.招财草, 12f },
        { 灵植Type.粉霞仙, 14f },
        { 灵植Type.黄龙掌, 16f },
        { 灵植Type.玄冰魄, 18f },
        
        { 灵植Type.修罗花, 12f },
        { 灵植Type.金乌葵, 14f },
        { 灵植Type.幻樱木, 16f },
        { 灵植Type.白玉莲, 18f },
    };
}
