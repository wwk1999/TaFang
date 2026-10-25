using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

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

public enum 土地Type
{
    None,
    未解锁,
    普通土地,
    黑土地,
    紫土地,
    金土地,
    红土地,
}

public enum 植物成长阶段Type
{
    None,
    播种,
    幼苗,
    成长,
    成熟,
}

public class 土地
{
    public int index;
    public 土地Type 土地Type;
    public 灵植Type 灵植Type;
    public 植物成长阶段Type 植物成长阶段Type;
    public bool 变异;
    public float 当前time;
    public float 所需time;
    public QualityType 提速肥料;
    public QualityType 增产肥料;
    public QualityType 延时肥料;
    public QualityType 异化肥料;
}

public enum 肥料Type
{
    None,
    提速,
    增产,
    异化,
    延时,
}

public class 土地数值
{
    public float 速度;
    public float 增产;
    public float 异化;
    public float 青石加成;
    public float 经验加成;
}

public class 灵植效果
{
    public float 战士伤害;
    public float 射手伤害;
    public float 控制伤害;
    public float 法师伤害;
    public float 黑暗伤害;
    public float 火焰伤害;
    public float 雷电伤害;
    public float 物理伤害;
    public float 冰霜伤害;
    public float 职业伤害;
    public float 元素伤害;
    
    public float 掉宝率;
    public float 灵气增幅;
    public float 功德增幅;
    public float 跟脚倍数;
    public float 真灵倍数;
}
public class 灵植园Config
{
    /// <summary>每种灵植（普通/变异各自独立）最多可服用次数</summary>
    public const int 最大服用次数 = 100;

    /// <summary>
    /// 创建全灵植类型的服用次数记录字典（普通/变异各自一份）
    /// </summary>
    public static Dictionary<灵植Type, int> 创建服用次数Dic()
    {
        var dic = new Dictionary<灵植Type, int>();
        foreach (灵植Type t in System.Enum.GetValues(typeof(灵植Type)))
        {
            if (t == 灵植Type.None) continue;
            dic[t] = 0;
        }
        return dic;
    }

    public static Dictionary<土地Type, 土地数值> 土地数值 = new Dictionary<土地Type, 土地数值>()
    {
        { 土地Type.普通土地, new 土地数值() { 速度 = 0, 增产 = 0, 异化 = 0, 青石加成 = 0, 经验加成 = 0 } },
        { 土地Type.黑土地, new 土地数值() { 速度 = 30, 增产 = 0, 异化 = 0, 青石加成 = 0, 经验加成 = 0 } },
        { 土地Type.紫土地, new 土地数值() { 速度 = 50, 增产 = 20, 异化 = 0, 青石加成 = 0, 经验加成 = 0 } },
        { 土地Type.金土地, new 土地数值() { 速度 = 100, 增产 = 40, 异化 = 0, 青石加成 = 30, 经验加成 = 30 } },
        { 土地Type.红土地, new 土地数值() { 速度 = 200, 增产 = 60, 异化 = 100, 青石加成 = 50, 经验加成 = 50 } },
    };

    public static Dictionary<肥料Type, string> 肥料名 = new Dictionary<肥料Type, string>()
    {
        { 肥料Type.提速 ,"催生肥"},
        { 肥料Type.增产 ,"增产肥"},
        { 肥料Type.异化 ,"异化肥"},
        { 肥料Type.延时 ,"延时肥"},
    };

    public static Dictionary<QualityType, float> 提速肥料数值 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 10 },
        { QualityType.玄品, 20 },
        { QualityType.地品, 30 },
        { QualityType.天品, 40 },
        { QualityType.宇品, 50 },
        { QualityType.宙品, 70 },
        { QualityType.洪品, 100 },
        { QualityType.荒品, 150 },
    };
    
    public static Dictionary<QualityType, float> 增产肥料数值 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 5 },
        { QualityType.玄品, 10 },
        { QualityType.地品, 15 },
        { QualityType.天品, 20 },
        { QualityType.宇品, 30 },
        { QualityType.宙品, 40 },
        { QualityType.洪品, 60 },
        { QualityType.荒品, 100 },
    };
    
    public static Dictionary<QualityType, float> 异化肥料数值 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 5 },
        { QualityType.玄品, 10 },
        { QualityType.地品, 15 },
        { QualityType.天品, 20 },
        { QualityType.宇品, 30 },
        { QualityType.宙品, 40 },
        { QualityType.洪品, 60 },
        { QualityType.荒品, 100 },
    };

    public static Dictionary<土地Type, float> 土地升级消耗 = new Dictionary<土地Type, float>()
    {
        { 土地Type.普通土地 ,100},
        { 土地Type.黑土地 ,1000},
        { 土地Type.紫土地 ,10000},
        { 土地Type.金土地 ,100000},
    };
    
    public static Dictionary<QualityType, float> 延时肥料数值 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 0.3f },
        { QualityType.玄品, 0.5f },
        { QualityType.地品, 1 },
        { QualityType.天品, 2 },
        { QualityType.宇品, 4 },
        { QualityType.宙品, 8 },
        { QualityType.洪品, 15 },
        { QualityType.荒品, 30 },
    };
    public static Dictionary<灵植Type, string> 灵植名 = new Dictionary<灵植Type, string>()
    {
        { 灵植Type.紫云英, "紫云英" },
        { 灵植Type.曜日葵, "曜日葵" },
        { 灵植Type.幻音铃, "幻音铃" },
        { 灵植Type.幻紫玫, "幻紫玫" },
        { 灵植Type.九幽紫, "九幽紫" },
        { 灵植Type.赤焰百合, "赤焰百合" },
        { 灵植Type.碧海螺, "碧海螺" },
        { 灵植Type.粉面佛莲, "粉面佛莲" },
        { 灵植Type.紫幽草, "紫幽草" },
        { 灵植Type.三生花, "三生花" },
        { 灵植Type.向阳花, "向阳花" },
        { 灵植Type.白玉玲, "白玉玲" },
        { 灵植Type.赤阳花, "赤阳花" },
        { 灵植Type.寒星兰, "寒星兰" },
        { 灵植Type.赤霞花, "赤霞花" },
        { 灵植Type.惊雷子, "惊雷子" },
        { 灵植Type.幽兰铃, "幽兰铃" },
        { 灵植Type.空谷幽兰, "空谷幽兰" },
        { 灵植Type.醉仙球, "醉仙球" },
        { 灵植Type.醉仙菌, "醉仙菌" },
        { 灵植Type.太素花, "太素花" },
        { 灵植Type.灵犀铃, "灵犀铃" },
        { 灵植Type.血菩提, "血菩提" },
        { 灵植Type.紫晶铃, "紫晶铃" },
        { 灵植Type.招财草, "招财草" },
        { 灵植Type.粉霞仙, "粉霞仙" },
        { 灵植Type.黄龙掌, "黄龙掌" },
        { 灵植Type.玄冰魄, "玄冰魄" },
        { 灵植Type.修罗花, "修罗花" },
        { 灵植Type.金乌葵, "金乌葵" },
        { 灵植Type.幻樱木, "幻樱木" },
        { 灵植Type.白玉莲, "白玉莲" },
    };
    
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

    /// <summary>
    /// 每种灵植服用后的效果描述（普通/变异通用），默认"无"，按策划表逐株填写。
    /// 示例："战士伤害+1%"
    /// </summary>
    public static Dictionary<灵植Type, string> 灵植服用效果Dic = 创建服用效果Dic();

    private static Dictionary<灵植Type, string> 创建服用效果Dic()
    {
        var dic = new Dictionary<灵植Type, string>();
        foreach (灵植Type t in System.Enum.GetValues(typeof(灵植Type)))
        {
            if (t == 灵植Type.None) continue;
            dic[t] = "无";
        }
        return dic;
    }

    public static string Get服用效果(灵植Type type)
    {
        return 灵植服用效果Dic.TryGetValue(type, out string 效果) ? 效果 : "无";
    }

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
        
        { 灵植Type.九幽紫, 3f },
        { 灵植Type.赤焰百合, 4f },
        { 灵植Type.碧海螺, 5f },
        { 灵植Type.粉面佛莲, 6f },
        
        { 灵植Type.紫幽草, 6f },
        { 灵植Type.三生花, 8f },
        { 灵植Type.向阳花, 10f },
        { 灵植Type.白玉玲, 12f },
        
        { 灵植Type.赤阳花, 15f },
        { 灵植Type.寒星兰, 13f },
        { 灵植Type.赤霞花, 17f },
        { 灵植Type.惊雷子, 20f },
        
        { 灵植Type.幽兰铃, 25f },
        { 灵植Type.空谷幽兰, 30f },
        { 灵植Type.醉仙球, 35f },
        { 灵植Type.醉仙菌, 40f },
        
        { 灵植Type.太素花, 50f },
        { 灵植Type.灵犀铃, 60f },
        { 灵植Type.血菩提, 70f },
        { 灵植Type.紫晶铃, 80f },
        
        { 灵植Type.招财草, 80f },
        { 灵植Type.粉霞仙, 100f },
        { 灵植Type.黄龙掌, 120f },
        { 灵植Type.玄冰魄, 140f },
        
        { 灵植Type.修罗花, 150f },
        { 灵植Type.金乌葵, 200f },
        { 灵植Type.幻樱木, 250f },
        { 灵植Type.白玉莲, 300f },
    };
    
    public static Dictionary<灵植Type, float> 灵植收获青石Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 20 },
        { 灵植Type.曜日葵, 25 },
        { 灵植Type.幻音铃, 30 },
        { 灵植Type.幻紫玫, 40 },
        
        { 灵植Type.九幽紫, 50 },
        { 灵植Type.赤焰百合, 60 },
        { 灵植Type.碧海螺, 70 },
        { 灵植Type.粉面佛莲, 80 },
        
        { 灵植Type.紫幽草, 100 },
        { 灵植Type.三生花, 120 },
        { 灵植Type.向阳花, 140 },
        { 灵植Type.白玉玲, 160 },
        
        { 灵植Type.赤阳花, 200 },
        { 灵植Type.寒星兰, 230 },
        { 灵植Type.赤霞花, 260 },
        { 灵植Type.惊雷子, 300 },
        
        { 灵植Type.幽兰铃, 350 },
        { 灵植Type.空谷幽兰, 400 },
        { 灵植Type.醉仙球, 450 },
        { 灵植Type.醉仙菌, 500 },
        
        { 灵植Type.太素花, 600 },
        { 灵植Type.灵犀铃, 700 },
        { 灵植Type.血菩提, 800 },
        { 灵植Type.紫晶铃, 900 },
        
        { 灵植Type.招财草, 1000 },
        { 灵植Type.粉霞仙, 1300 },
        { 灵植Type.黄龙掌, 1600 },
        { 灵植Type.玄冰魄, 1900 },
        
        { 灵植Type.修罗花, 2500 },
        { 灵植Type.金乌葵, 3000 },
        { 灵植Type.幻樱木, 3500 },
        { 灵植Type.白玉莲, 4000 },
    };

    public static float Get肥料价格(肥料Type type, QualityType qualityType)
    {
        switch (type)
        {
            case 肥料Type.提速:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 5;
                    case QualityType.玄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.天品:
                        return 40;
                    case QualityType.宇品:
                        return 80;
                    case QualityType.宙品:
                        return 150;
                    case QualityType.洪品:
                        return 300;
                    case QualityType.荒品:
                        return 600;
                }
                break;
            
            case 肥料Type.增产:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 5;
                    case QualityType.玄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.天品:
                        return 40;
                    case QualityType.宇品:
                        return 80;
                    case QualityType.宙品:
                        return 150;
                    case QualityType.洪品:
                        return 300;
                    case QualityType.荒品:
                        return 600;
                }
                break;
            
            case 肥料Type.延时:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 2;
                    case QualityType.玄品:
                        return 5;
                    case QualityType.地品:
                        return 10;
                    case QualityType.天品:
                        return 15;
                    case QualityType.宇品:
                        return 20;
                    case QualityType.宙品:
                        return 30;
                    case QualityType.洪品:
                        return 40;
                    case QualityType.荒品:
                        return 50;
                }
                break;
            
            case 肥料Type.异化:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.玄品:
                        return 20;
                    case QualityType.地品:
                        return 40;
                    case QualityType.天品:
                        return 80;
                    case QualityType.宇品:
                        return 150;
                    case QualityType.宙品:
                        return 300;
                    case QualityType.洪品:
                        return 600;
                    case QualityType.荒品:
                        return 1000;
                }
                break;
        }

        return 0;
    }
    
    public static Dictionary<灵植Type, float> 灵植价格Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 10 },
        { 灵植Type.曜日葵, 12 },
        { 灵植Type.幻音铃, 15 },
        { 灵植Type.幻紫玫, 20 },
        
        { 灵植Type.九幽紫, 25 },
        { 灵植Type.赤焰百合, 30 },
        { 灵植Type.碧海螺, 35 },
        { 灵植Type.粉面佛莲, 40 },
        
        { 灵植Type.紫幽草, 50 },
        { 灵植Type.三生花, 60 },
        { 灵植Type.向阳花, 70 },
        { 灵植Type.白玉玲, 80 },
        
        { 灵植Type.赤阳花, 100 },
        { 灵植Type.寒星兰, 115 },
        { 灵植Type.赤霞花, 130 },
        { 灵植Type.惊雷子, 150 },
        
        { 灵植Type.幽兰铃, 175 },
        { 灵植Type.空谷幽兰, 200 },
        { 灵植Type.醉仙球, 225 },
        { 灵植Type.醉仙菌, 250 },
        
        { 灵植Type.太素花, 300 },
        { 灵植Type.灵犀铃, 350 },
        { 灵植Type.血菩提, 400 },
        { 灵植Type.紫晶铃, 450 },
        
        { 灵植Type.招财草, 500 },
        { 灵植Type.粉霞仙, 650 },
        { 灵植Type.黄龙掌, 800 },
        { 灵植Type.玄冰魄, 950 },
        
        { 灵植Type.修罗花, 1250 },
        { 灵植Type.金乌葵, 1500 },
        { 灵植Type.幻樱木, 1750 },
        { 灵植Type.白玉莲, 2000 },
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
        
        { 灵植Type.九幽紫, 50 },
        { 灵植Type.赤焰百合, 60 },
        { 灵植Type.碧海螺, 70 },
        { 灵植Type.粉面佛莲, 80 },
        
        { 灵植Type.紫幽草, 100 },
        { 灵植Type.三生花, 120 },
        { 灵植Type.向阳花, 140 },
        { 灵植Type.白玉玲, 160 },
        
        { 灵植Type.赤阳花, 200 },
        { 灵植Type.寒星兰, 230 },
        { 灵植Type.赤霞花, 260 },
        { 灵植Type.惊雷子, 290 },
        
        { 灵植Type.幽兰铃, 350 },
        { 灵植Type.空谷幽兰, 400 },
        { 灵植Type.醉仙球, 450 },
        { 灵植Type.醉仙菌, 500 },
        
        { 灵植Type.太素花, 600 },
        { 灵植Type.灵犀铃, 700 },
        { 灵植Type.血菩提, 800 },
        { 灵植Type.紫晶铃, 900 },
        
        { 灵植Type.招财草, 1000 },
        { 灵植Type.粉霞仙, 1300 },
        { 灵植Type.黄龙掌, 1600 },
        { 灵植Type.玄冰魄, 1900 },
        
        { 灵植Type.修罗花, 2000 },
        { 灵植Type.金乌葵, 2500 },
        { 灵植Type.幻樱木, 3000 },
        { 灵植Type.白玉莲, 3500 },
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

    public static Dictionary<int, minmax> 植物位置Dic = new Dictionary<int, minmax>()
    {
        {1,new minmax(){min = -455.6f,max = 1.4f}},
        {2,new minmax(){min = -298.4417f,max = 77.66492f}},
        {3,new minmax(){min = -140.6417f,max = 157.6649f}},
        {4,new minmax(){min = 17.35831f,max = 237.6649f}},
        {5,new minmax(){min = -296,max = -81}},
        {6,new minmax(){min = -138.4417f,max = -1.335083f}},
        {7,new minmax(){min = 19.35828f,max = 78.66492f}},
        {8,new minmax(){min = 177.3583f,max = 158.6649f}},
        {9,new minmax(){min = -134.5583f,max = -159.6649f}},
        {10,new minmax(){min = 23,max = -80}},
        {11,new minmax(){min = 180.8f,max = 0}},
        {12,new minmax(){min = 338.8f,max = 80}},
        {13,new minmax(){min = 24.44165f,max = -239.6649f}},
        {14,new minmax(){min = 182,max = -160}},
        {15,new minmax(){min = 339.8f,max = -80}},
        {16,new minmax(){min = 497.8f,max = 0}},
        {17,new minmax(){min = 184.6417f,max = -318.6649f}},
        {18,new minmax(){min = 342.2f,max = -239}},
        {19,new minmax(){min = 500,max = -159}},
        {20,new minmax(){min = 658,max = -79}},
    };

    /// <summary>
    /// 按领主府「灵植园」建筑等级同步土地解锁：每级解锁一块土地
    /// </summary>
    public static void 同步土地解锁()
    {
        int 等级 = PlayerData.S.建筑等级Dic[建筑Type.灵植园];
        if (!道场Config.灵植园配置.ContainsKey(等级)) return;
        int 土地个数 = 道场Config.灵植园配置[等级].土地个数;
        foreach (var item in PlayerData.S.灵植土地列表)
        {
            if (item.Value.index > 土地个数) continue;
            if (item.Value.土地Type == 土地Type.未解锁)
            {
                item.Value.土地Type = 土地Type.普通土地;
            }
        }
    }
}
