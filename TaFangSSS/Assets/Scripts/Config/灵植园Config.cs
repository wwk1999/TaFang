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
    public float 城墙生命值;
    public float 城墙防御;
    public float 暴击率;
    public float 暴击伤害;
    public float 最终伤害;
    
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
    public float 跟脚;
    public float 真灵;
    public float 时间流速;
    public float 修炼速度;
}
public class 灵植园Config
{
    public static float 变异倍数 = 10;
    
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
        { 土地Type.普通土地 ,1000},
        { 土地Type.黑土地 ,50000},
        { 土地Type.紫土地 ,10000000},
        { 土地Type.金土地 ,1000000000},
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
        { 灵植Type.紫幽草, QualityType.玄品 },
        
        
        { 灵植Type.三生花, QualityType.地品 },
        { 灵植Type.向阳花, QualityType.地品 },
        { 灵植Type.白玉玲, QualityType.地品 },
        { 灵植Type.赤阳花, QualityType.地品 },
        { 灵植Type.寒星兰, QualityType.地品 },
        
        
        { 灵植Type.赤霞花, QualityType.天品 },
        { 灵植Type.惊雷子, QualityType.天品 },
        { 灵植Type.幽兰铃, QualityType.天品 },
        { 灵植Type.空谷幽兰, QualityType.天品 },
        
        
        { 灵植Type.醉仙球, QualityType.宇品 },
        { 灵植Type.醉仙菌, QualityType.宇品 },
        { 灵植Type.太素花, QualityType.宇品 },
        { 灵植Type.灵犀铃, QualityType.宇品 },
        { 灵植Type.血菩提, QualityType.宇品 },
        
        
        
        { 灵植Type.紫晶铃, QualityType.宙品 },
        { 灵植Type.招财草, QualityType.宙品 },
        { 灵植Type.粉霞仙, QualityType.宙品 },
        { 灵植Type.黄龙掌, QualityType.宙品 },
        { 灵植Type.玄冰魄, QualityType.宙品 },

        // 荒品（4个）
        { 灵植Type.修罗花, QualityType.洪品 },
        { 灵植Type.金乌葵, QualityType.洪品 },
        { 灵植Type.幻樱木, QualityType.洪品 },
        
        
        
        { 灵植Type.白玉莲, QualityType.荒品 },
    };

    /// <summary>每株灵植赠送时提供的基础好感度，实际好感再按喜好（×2）与变异（×变异倍数）乘算</summary>
    public static Dictionary<灵植Type, int> 灵植赠送好感度Dic = new Dictionary<灵植Type, int>()
    {
        { 灵植Type.紫云英, 10 },
        { 灵植Type.曜日葵, 10 },
        { 灵植Type.幻音铃, 10 },
        { 灵植Type.幻紫玫, 10 },
        
        { 灵植Type.九幽紫, 30 },
        { 灵植Type.赤焰百合, 40 },
        { 灵植Type.碧海螺, 50 },
        { 灵植Type.粉面佛莲, 60 },
        { 灵植Type.紫幽草, 80 },
        
        
        { 灵植Type.三生花, 200 },
        { 灵植Type.向阳花, 250 },
        { 灵植Type.白玉玲, 300 },
        { 灵植Type.赤阳花, 350 },
        { 灵植Type.寒星兰, 400 },
        
        
        { 灵植Type.赤霞花, 1000 },
        { 灵植Type.惊雷子, 1500 },
        { 灵植Type.幽兰铃, 2000 },
        { 灵植Type.空谷幽兰, 2500 },
        
        
        { 灵植Type.醉仙球, 6000 },
        { 灵植Type.醉仙菌, 7000 },
        { 灵植Type.太素花, 8000 },
        { 灵植Type.灵犀铃, 9000 },
        { 灵植Type.血菩提, 10000 },
        
        
        { 灵植Type.紫晶铃, 30000 },
        { 灵植Type.招财草, 40000 },
        { 灵植Type.粉霞仙, 50000 },
        { 灵植Type.黄龙掌, 60000 },
        { 灵植Type.玄冰魄, 80000 },

        
        { 灵植Type.修罗花, 200000 },
        { 灵植Type.金乌葵, 250000 },
        { 灵植Type.幻樱木, 300000 },
        
        
        { 灵植Type.白玉莲, 1000000 },
    };
    
    
    public static Dictionary<灵植Type, 灵植效果> 灵植效果 = new Dictionary<灵植Type, 灵植效果>()
    {
        { 灵植Type.紫云英, new 灵植效果(){战士伤害=2} },
        { 灵植Type.曜日葵, new 灵植效果(){射手伤害=2} },
        { 灵植Type.幻音铃, new 灵植效果(){控制伤害=2} },
        { 灵植Type.幻紫玫, new 灵植效果(){法师伤害=2} },
        
        { 灵植Type.九幽紫, new 灵植效果(){黑暗伤害=5} },
        { 灵植Type.赤焰百合, new 灵植效果(){火焰伤害=5} },
        { 灵植Type.碧海螺, new 灵植效果(){雷电伤害=5} },
        { 灵植Type.粉面佛莲, new 灵植效果(){物理伤害=5}},
        { 灵植Type.紫幽草, new 灵植效果(){冰霜伤害=5} },
        
        { 灵植Type.三生花, new 灵植效果(){最终伤害= 10} },
        { 灵植Type.向阳花, new 灵植效果(){暴击伤害= 10} },
        { 灵植Type.白玉玲, new 灵植效果(){暴击率= 2} },
        { 灵植Type.赤阳花, new 灵植效果(){城墙生命值= 15} },
        { 灵植Type.寒星兰, new 灵植效果(){城墙防御= 15} },
        
        { 灵植Type.赤霞花, new 灵植效果(){战士伤害=50} },
        { 灵植Type.惊雷子, new 灵植效果(){法师伤害=50} },
        { 灵植Type.幽兰铃, new 灵植效果(){射手伤害=50} },
        { 灵植Type.空谷幽兰, new 灵植效果(){控制伤害=50} },
        
        { 灵植Type.醉仙球, new 灵植效果(){黑暗伤害=200} },
        { 灵植Type.醉仙菌, new 灵植效果(){火焰伤害=200} },
        { 灵植Type.太素花, new 灵植效果(){物理伤害=200} },
        { 灵植Type.灵犀铃, new 灵植效果(){冰霜伤害=200} },
        { 灵植Type.血菩提, new 灵植效果(){雷电伤害=200} },
        
        { 灵植Type.紫晶铃, new 灵植效果(){职业伤害=500} },
        { 灵植Type.招财草, new 灵植效果(){元素伤害=500} },
        { 灵植Type.粉霞仙,new 灵植效果(){灵气增幅= 10} },
        { 灵植Type.黄龙掌, new 灵植效果(){功德增幅= 10} },
        { 灵植Type.玄冰魄, new 灵植效果(){修炼速度= 100} },
        
        { 灵植Type.修罗花, new 灵植效果(){跟脚= 100} },
        { 灵植Type.金乌葵, new 灵植效果(){掉宝率= 3} },
        { 灵植Type.幻樱木, new 灵植效果(){时间流速= 3}},
        
        { 灵植Type.白玉莲, new 灵植效果(){真灵= 20}},
    };
    
    public static Dictionary<灵植Type, float> 灵植成熟时间Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 2 },
        { 灵植Type.曜日葵, 2.5f },
        { 灵植Type.幻音铃, 3f },
        { 灵植Type.幻紫玫, 3.5f },
        
        { 灵植Type.九幽紫, 6f },
        { 灵植Type.赤焰百合, 7f },
        { 灵植Type.碧海螺, 8f },
        { 灵植Type.粉面佛莲, 9f },
        { 灵植Type.紫幽草, 10f },
        
        { 灵植Type.三生花, 20f },
        { 灵植Type.向阳花, 22f },
        { 灵植Type.白玉玲, 24f },
        { 灵植Type.赤阳花, 26f },
        { 灵植Type.寒星兰, 28f },
        
        { 灵植Type.赤霞花, 60f },
        { 灵植Type.惊雷子, 70f },
        { 灵植Type.幽兰铃, 80f },
        { 灵植Type.空谷幽兰, 90f },
        
        { 灵植Type.醉仙球, 200f },
        { 灵植Type.醉仙菌, 240f },
        { 灵植Type.太素花, 280f },
        { 灵植Type.灵犀铃, 320f },
        { 灵植Type.血菩提, 360f },
        
        { 灵植Type.紫晶铃, 700f },
        { 灵植Type.招财草, 800f },
        { 灵植Type.粉霞仙, 900f },
        { 灵植Type.黄龙掌, 1000f },
        { 灵植Type.玄冰魄, 1100f },
        
        { 灵植Type.修罗花, 2500f },
        { 灵植Type.金乌葵, 3000f },
        { 灵植Type.幻樱木, 3500f },
        
        { 灵植Type.白玉莲, 10000f },
    };
    
    public static Dictionary<灵植Type, float> 灵植收获青石Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 20 },
        { 灵植Type.曜日葵, 25 },
        { 灵植Type.幻音铃, 30 },
        { 灵植Type.幻紫玫, 40 },
        
        { 灵植Type.九幽紫, 100 },
        { 灵植Type.赤焰百合, 140 },
        { 灵植Type.碧海螺, 180 },
        { 灵植Type.粉面佛莲, 220 },
        { 灵植Type.紫幽草, 260 },
        
        { 灵植Type.三生花, 600 },
        { 灵植Type.向阳花, 700 },
        { 灵植Type.白玉玲, 800 },
        { 灵植Type.赤阳花, 900 },
        { 灵植Type.寒星兰, 1000 },
        
        { 灵植Type.赤霞花, 2500 },
        { 灵植Type.惊雷子, 3000 },
        { 灵植Type.幽兰铃, 3500 },
        { 灵植Type.空谷幽兰, 4000 },
        
        { 灵植Type.醉仙球, 10000 },
        { 灵植Type.醉仙菌, 12000 },
        { 灵植Type.太素花, 14000 },
        { 灵植Type.灵犀铃, 16000 },
        { 灵植Type.血菩提, 18000 },
        
        { 灵植Type.紫晶铃, 40000 },
        { 灵植Type.招财草, 50000 },
        { 灵植Type.粉霞仙, 60000 },
        { 灵植Type.黄龙掌, 70000 },
        { 灵植Type.玄冰魄, 80000 },
        
        { 灵植Type.修罗花, 200000 },
        { 灵植Type.金乌葵, 300000 },
        { 灵植Type.幻樱木, 400000 },
        
        { 灵植Type.白玉莲, 1000000 },
    };

    public static float Get肥料价格(肥料Type type, QualityType qualityType)
    {
        switch (type)
        {
            case 肥料Type.提速:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.玄品:
                        return 50;
                    case QualityType.地品:
                        return 300;
                    case QualityType.天品:
                        return 1250;
                    case QualityType.宇品:
                        return 5000;
                    case QualityType.宙品:
                        return 20000;
                    case QualityType.洪品:
                        return 100000;
                    case QualityType.荒品:
                        return 300000;
                }
                break;
            
            case 肥料Type.增产:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.玄品:
                        return 50;
                    case QualityType.地品:
                        return 300;
                    case QualityType.天品:
                        return 1250;
                    case QualityType.宇品:
                        return 5000;
                    case QualityType.宙品:
                        return 20000;
                    case QualityType.洪品:
                        return 100000;
                    case QualityType.荒品:
                        return 300000;
                }
                break;
            
            case 肥料Type.延时:
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
            
            case 肥料Type.异化:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 30;
                    case QualityType.玄品:
                        return 200;
                    case QualityType.地品:
                        return 1000;
                    case QualityType.天品:
                        return 3000;
                    case QualityType.宇品:
                        return 12000;
                    case QualityType.宙品:
                        return 50000;
                    case QualityType.洪品:
                        return 300000;
                    case QualityType.荒品:
                        return 1000000;
                }
                break;
        }

        return 0;
    }
    
    public static Dictionary<灵植Type, float> 灵植价格Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 5 },
        { 灵植Type.曜日葵, 10 },
        { 灵植Type.幻音铃, 15 },
        { 灵植Type.幻紫玫, 20 },
        
        { 灵植Type.九幽紫, 25 },
        { 灵植Type.赤焰百合, 30 },
        { 灵植Type.碧海螺, 35 },
        { 灵植Type.粉面佛莲, 40 },
        { 灵植Type.紫幽草, 50 },
        
        { 灵植Type.三生花, 150 },
        { 灵植Type.向阳花, 200 },
        { 灵植Type.白玉玲, 250 },
        { 灵植Type.赤阳花, 300 },
        { 灵植Type.寒星兰, 350 },
        
        { 灵植Type.赤霞花, 600 },
        { 灵植Type.惊雷子, 700 },
        { 灵植Type.幽兰铃, 800 },
        { 灵植Type.空谷幽兰, 900 },
        
        { 灵植Type.醉仙球, 2500 },
        { 灵植Type.醉仙菌, 3000 },
        { 灵植Type.太素花, 3500 },
        { 灵植Type.灵犀铃, 4000 },
        { 灵植Type.血菩提, 4500 },
        
        { 灵植Type.紫晶铃, 10000 },
        { 灵植Type.招财草, 12000 },
        { 灵植Type.粉霞仙, 14000 },
        { 灵植Type.黄龙掌, 18000 },
        { 灵植Type.玄冰魄, 20000 },
        
        { 灵植Type.修罗花, 50000 },
        { 灵植Type.金乌葵, 60000 },
        { 灵植Type.幻樱木, 70000 },
        
        { 灵植Type.白玉莲, 250000 },
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
        
        {10,300},
        {11,400},
        {12,500},
        {13,600},
        {14,700},
        {15,800},
        {16,900},
        {17,1000},
        {18,1100},
        {19,1200},
        {20,1300},
        
        {21,1800},
        {22,2000},
        {23,2200},
        {24,2400},
        {25,2600},
        {26,2800},
        {27,3000},
        {28,3200},
        {29,3400},
        
        {30,4000},
        {31,5000},
        {32,6000},
        {33,7000},
        {34,8000},
        {35,9000},
        {36,10000},
        {37,11000},
        {38,12000},
        {39,13000},
        
        {40,15000},
        {41,20000},
        {42,25000},
        {43,30000},
        {44,35000},
        {45,45000},
        {46,50000},
        {47,55000},
        {48,60000},
        {49,65000},
        
        {50,80000},
        {51,100000},
        {52,120000},
        {53,140000},
        {54,160000},
        {55,180000},
        {56,200000},
        {57,220000},
        {58,240000},
        {59,260000},
        
        
        {60,300000},
        {61,400000},
        {62,500000},
        {63,600000},
        {64,700000},
        {65,800000},
        {66,900000},
        {67,1000000},
        {68,1100000},
        {69,1200000},
        
        {70,1500000},
        {71,2000000},
        {72,2500000},
        {73,3000000},
        {74,3500000},
        {75,4000000},
        {76,4500000},
        {77,5000000},
        {78,5500000},
        {79,6000000},
        
        {80,8000000},
        {81,12000000},
        {82,16000000},
        {83,20000000},
        {84,25000000},
        {85,30000000},
        {86,35000000},
        {87,40000000},
        {88,45000000},
        {89,50000000},
        
        {90,70000000},
        {91,100000000},
        {92,130000000},
        {93,160000000},
        {94,190000000},
        {95,220000000},
        {96,250000000},
        {97,280000000},
        {98,310000000},
        {99,350000000},
        
        {100,999999999999},
        
    };

    
    public static Dictionary<灵植Type, float> 灵植收获经验Dic = new Dictionary<灵植Type, float>()
    {
        { 灵植Type.紫云英, 20 },
        { 灵植Type.曜日葵, 25 },
        { 灵植Type.幻音铃, 30 },
        { 灵植Type.幻紫玫, 40 },
        
        { 灵植Type.九幽紫, 100 },
        { 灵植Type.赤焰百合, 140 },
        { 灵植Type.碧海螺, 180 },
        { 灵植Type.粉面佛莲, 220 },
        { 灵植Type.紫幽草, 260 },
        
        { 灵植Type.三生花, 600 },
        { 灵植Type.向阳花, 700 },
        { 灵植Type.白玉玲, 800 },
        { 灵植Type.赤阳花, 900 },
        { 灵植Type.寒星兰, 1000 },
        
        { 灵植Type.赤霞花, 2500 },
        { 灵植Type.惊雷子, 3000 },
        { 灵植Type.幽兰铃, 3500 },
        { 灵植Type.空谷幽兰, 4000 },
        
        { 灵植Type.醉仙球, 10000 },
        { 灵植Type.醉仙菌, 12000 },
        { 灵植Type.太素花, 14000 },
        { 灵植Type.灵犀铃, 16000 },
        { 灵植Type.血菩提, 18000 },
        
        { 灵植Type.紫晶铃, 40000 },
        { 灵植Type.招财草, 50000 },
        { 灵植Type.粉霞仙, 60000 },
        { 灵植Type.黄龙掌, 70000 },
        { 灵植Type.玄冰魄, 80000 },
        
        { 灵植Type.修罗花, 200000 },
        { 灵植Type.金乌葵, 300000 },
        { 灵植Type.幻樱木, 400000 },
        
        { 灵植Type.白玉莲, 1000000 },
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
        { 灵植Type.白玉莲, 15f },
    };

    public static Dictionary<int, minmax> 植物位置Dic = new Dictionary<int, minmax>()
    {
        {1,new minmax(){min = 17.35831f,max = 237.6649f}},
        {2,new minmax(){min = -140.6417f,max = 157.6649f}},
         {3,new minmax(){min = 177.3583f,max = 158.6649f}},
         {4,new minmax(){min = 19.35828f,max = 78.66492f}},
        {5,new minmax(){min = 338.8f,max = 80}},
         {6,new minmax(){min = -298.4417f,max = 77.66492f}},
         {7,new minmax(){min = 180.8f,max = 0}}, 
         {8,new minmax(){min = 497.8f,max = 0}},
         {9,new minmax(){min = -138.4417f,max = -1.335083f}}, 
         {10,new minmax(){min = -455.6f,max = 1.4f}},
          {11,new minmax(){min = 339.8f,max = -80}},
        {12,new minmax(){min = -296,max = -81}},
        {13,new minmax(){min = 23,max = -80}},
        
       {14,new minmax(){min = 658,max = -79}},
       {15,new minmax(){min = 500,max = -159}},
       {16,new minmax(){min = 182,max = -160}},
        {17,new minmax(){min = -134.5583f,max = -159.6649f}},
         {18,new minmax(){min = 342.2f,max = -239}},
        {19,new minmax(){min = 24.44165f,max = -239.6649f}},
        {20,new minmax(){min = 184.6417f,max = -318.6649f}},
    };

    /// <summary>
    /// 按领主府「灵植园」建筑等级同步土地解锁：每级解锁一块土地
    /// </summary>

    public static List<int> 土地解锁顺序 = new List<int>() { };
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
