using System;
using System.Collections.Generic;
using Config;
using Random = UnityEngine.Random;

public enum 仙石Type
{
    None,
    赤阳石,
    太虚石,
    清心玉,
    玄冥石,
    玄灵晶,
    天罡石,
}
public class 仙石
{
    public QualityType quality;
    public 仙石Type type;
    public List<法器附加属性值> list=new List<法器附加属性值>();
}
public class 仙石Config
{
    public static Dictionary<仙石Type, string> 仙石名Dic = new Dictionary<仙石Type, string>()
    {
        { 仙石Type.赤阳石, "赤阳石" },
        { 仙石Type.太虚石, "太虚石" },
        { 仙石Type.清心玉, "清心玉" },
        { 仙石Type.玄冥石, "玄冥石" },
        { 仙石Type.玄灵晶, "玄灵晶" },
        { 仙石Type.天罡石, "天罡石" },
    };
    
    public static Dictionary<仙石Type, string> 仙石DescDic = new Dictionary<仙石Type, string>()
    {
        { 仙石Type.None, "无" },
        { 仙石Type.赤阳石, "上古金乌离火之精凝结，焰光灼灼，内蕴焚天煮海的毁灭之力。" },
        { 仙石Type.太虚石, "域外破碎星辰坠落的星辉结晶，内含微缩宇宙，能洞察寰宇。" },
        { 仙石Type.清心玉, "西方极乐净土伴生之玉，纯净无瑕，可辟万邪护灵台清明。" },
        { 仙石Type.玄冥石, "北海极渊万载玄冰髓晶，触之刺骨，蕴藏冰封万物的极寒本源。" },
        { 仙石Type.玄灵晶, "瑶池仙境万载花魂凝结，散发着玄奥灵光，可治愈万物。" },
        { 仙石Type.天罡石, "雷云深处历经千载孕育的紫核，引动九天雷霆，势不可挡。" },
    };
    //掉落0-4件
    public static List<float> 仙石掉落数量概率List = new List<float>()
    {
        10, 40, 30, 15, 5
    };
    public static Dictionary<QualityType, int> 仙石重铸消耗Dic = new Dictionary<QualityType, int>()
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
    public static Dictionary<JingJieType, List<float>> 仙石掉落概率Dic = new Dictionary<JingJieType, List<float>>()
    {
        { JingJieType.练气 , new List<float>(){100,0,0,0,0,0,0,0}},
        { JingJieType.筑基 , new List<float>(){80,20,0,0,0,0,0,0}},
        { JingJieType.金丹 , new List<float>(){50,50,0,0,0,0,0,0}},
        { JingJieType.元婴 , new List<float>(){10,70,20,0,0,0,0,0}},
        { JingJieType.化神 , new List<float>(){0,50,50,0,0,0,0,0}},
        { JingJieType.合体 , new List<float>(){0,20,70,10,0,0,0,0}},
        { JingJieType.大乘 , new List<float>(){0,0,80,20,0,0,0,0}},
        { JingJieType.天仙 , new List<float>(){0,0,60,40,0,0,0,0}},
        { JingJieType.玄仙 , new List<float>(){0,0,40,50,10,0,0,0}},
        { JingJieType.金仙 , new List<float>(){0,0,10,70,20,0,0,0}},
        { JingJieType.太乙金仙 , new List<float>(){0,00,00,70,30,0,0,0}},
        { JingJieType.大罗金仙 , new List<float>(){0,0,13,40,40,7,0,0}},
        { JingJieType.准圣 , new List<float>(){0,0,5,30,50,15,0,0}},
        { JingJieType.圣人 , new List<float>(){0,0,0,15,60,25,0,0}},
        { JingJieType.天道圣人 , new List<float>(){0,0,0,0,62,35,3,0}},
        { JingJieType.大道圣人 , new List<float>(){0,0,0,0,42,50,8,0}},
        { JingJieType.混元圣人 , new List<float>(){0,0,0,0,20,65,15,0}},
        { JingJieType.鸿蒙 , new List<float>(){0,0,0,0,4,70,25,1}},
    };
    public static Dictionary<QualityType, int> 仙石分解Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,50},
        { QualityType.玄品 ,150},
        { QualityType.地品 ,500},
        { QualityType.天品 ,1500},
        { QualityType.宇品 ,5000},
        { QualityType.宙品 ,15000},
        { QualityType.洪品 ,50000},
        { QualityType.荒品 ,250000},
    };
    public static List<法器附加属性值> Get仙石附加属性(QualityType qualityType)
    {
        List<法器附加属性值> list = new List<法器附加属性值>();
        int 数量=Random.Range(1,4);
        for (int i = 0; i < 数量; i++)
        {
            int type = Random.Range(1, Enum.GetValues(typeof(法器附加属性Type)).Length);
            法器附加属性Type 附加属性Type = (法器附加属性Type)type;
            float min=法器Config.法器Minmaxes[new 法器附加属性品质type(){法器附加属性Type = 附加属性Type,QualityType =  qualityType}].min;
            float max=法器Config.法器Minmaxes[new 法器附加属性品质type(){法器附加属性Type = 附加属性Type,QualityType =  qualityType}].max;
            法器附加属性值 法器附加属性值 = new 法器附加属性值();
            法器附加属性值.法器附加属性Type = (法器附加属性Type)type;
            法器附加属性值.count=Random.Range(min,max)/数量;
            list.Add(法器附加属性值);
        }
        return list;
    }
    
    
    public static 仙石 单次仙石掉落(JingJieType jingJieType)
    {
        QualityType 掉落品质 = QualityType.黄品;
        float count = 0;
        float 品质random=Random.Range(0,100);
        foreach (var item in 仙石掉落数量概率List)
        {
            count += item;
            if (品质random < count) break;
            掉落品质++;
        }
        仙石 仙石 = new 仙石();
        仙石.quality = 掉落品质;
        仙石.type = (仙石Type)Random.Range(1, Enum.GetValues(typeof(仙石Type)).Length);
        var 附加属性列表 = Get仙石附加属性(掉落品质);
        仙石.list = 附加属性列表;
        return 仙石;
    }
    public static List<仙石> Get关卡仙石掉落(JingJieType jingJieType)
    {
        int 掉落数量 = 0;
        float count = 0;
        float 数量random=Random.Range(0,100);
        foreach (var item in 仙石掉落数量概率List)
        {
            count += item;
            if (数量random < count) break;
            掉落数量++;
        }

        List<仙石> list = new List<仙石>();
        for (int i = 0; i < 掉落数量; i++)
        {
            list.Add(单次仙石掉落(jingJieType));
        }
        return list;
    }
}
