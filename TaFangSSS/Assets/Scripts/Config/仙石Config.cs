using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
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
    // 1~16阶，与法器一致；默认1阶避免旧数据/空数据落到0阶
    public int 阶数 = 1;
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
        30, 64, 5, 1, 0
    };

    public static List<float> 仙石重铸品质倍数List = new List<float>() { 1, 1.5f, 2, 3, 5, 8, 12, 20 };
    public static Dictionary<int, float> 仙石重铸消耗Dic = new Dictionary<int, float>()
    {
        { 1 ,100},
        { 2 ,300},
        { 3 ,1000},
        { 4 ,3000},
        { 5 ,10000},
        { 6 ,30000},
        { 7 ,100000},
        { 8 ,300000},
        { 9 ,1000000},
        { 10 ,3000000},
        { 11 ,10000000},
        { 12 ,30000000},
        { 13 ,100000000},
        { 14 ,3000000000},
        { 15 ,10000000000},
        { 16 ,300000000000},
    };
    public static Dictionary<JingJieType, List<float>> 仙石掉落概率Dic = new Dictionary<JingJieType, List<float>>()
    {
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
        { JingJieType.太乙金仙 , new List<float>(){0,00,00,70,30,0,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.大罗金仙 , new List<float>(){0,0,15,40,40,5,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.准圣 , new List<float>(){0,0,10,30,50,10,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.圣人 , new List<float>(){0,0,0,25,60,15,0,0,0,0,0,0,0,0,0,0}},
        { JingJieType.天道圣人 , new List<float>(){0,0,0,0,62,35,3,0,0,0,0,0,0,0,0,0}},
        { JingJieType.大道圣人 , new List<float>(){0,0,0,0,44,50,6,0,0,0,0,0,0,0,0,0}},
        { JingJieType.混元圣人 , new List<float>(){0,0,0,0,25,65,10,0,0,0,0,0,0,0,0,0}},
        { JingJieType.鸿蒙 , new List<float>(){0,0,0,0,14,70,15,1,0,0,0,0,0,0,0,0}},
    };

    public static int Get法器仙石数量(法器 法器, 仙石Type type)
    {
        int count = 0;
        foreach (var item in 法器.仙石list)
        {
            if(item.type==type)
            {
                count++;
            }
        }
        return count;
    }

    public static float Get法器仙石效果(法器 法器)
    {
        float value = 0;
        float 赤阳石数量 = 0;
        float 太虚石数量 = 0;
        float 清心玉数量 = 0;
        float 玄冥石数量 = 0;
        float 玄灵晶数量 = 0;
        float 天罡石数量 = 0;
        foreach (var item in 法器.仙石list)
        {
            switch (item.type)
            {
                case 仙石Type.天罡石:
                    天罡石数量++;
                    break;
                case 仙石Type.赤阳石:
                    赤阳石数量++;
                    break;
                case 仙石Type.太虚石:
                    太虚石数量++;
                    break;
                case 仙石Type.清心玉:
                    清心玉数量++;
                    break;
                case 仙石Type.玄冥石:
                    玄冥石数量++;
                    break;
                case 仙石Type.玄灵晶:
                    玄灵晶数量++;
                    break;
            }
        }
        if (天罡石数量 > 4) value += 仙石羁绊效果Dic[4];
        if (天罡石数量 > 6) value += 仙石羁绊效果Dic[6];
        if (天罡石数量 > 8) value += 仙石羁绊效果Dic[8];
            
        if (赤阳石数量 > 4) value += 仙石羁绊效果Dic[4];
        if (赤阳石数量 > 6) value += 仙石羁绊效果Dic[6];
        if (赤阳石数量 > 8) value += 仙石羁绊效果Dic[8];
            
        if (玄灵晶数量 > 4) value += 仙石羁绊效果Dic[4];
        if (玄灵晶数量 > 6) value += 仙石羁绊效果Dic[6];
        if (玄灵晶数量 > 8) value += 仙石羁绊效果Dic[8];
            
        if (太虚石数量 > 4) value += 仙石羁绊效果Dic[4];
        if (太虚石数量 > 6) value += 仙石羁绊效果Dic[6];
        if (太虚石数量 > 8) value += 仙石羁绊效果Dic[8];
            
        if (清心玉数量 > 4) value += 仙石羁绊效果Dic[4];
        if (清心玉数量 > 6) value += 仙石羁绊效果Dic[6];
        if (清心玉数量 > 8) value += 仙石羁绊效果Dic[8];
            
        if (玄冥石数量 > 4) value += 仙石羁绊效果Dic[4];
        if (玄冥石数量 > 6) value += 仙石羁绊效果Dic[6];
        if (玄冥石数量 > 8) value += 仙石羁绊效果Dic[8];
        return value;
    }
    public static Dictionary<int, float> 仙石羁绊效果Dic = new Dictionary<int, float>()
    {
        { 4, 50 },
        { 6, 100 },
        { 8, 300 },
    };
    
    public static Dictionary<int, List<float>>仙石品质掉落概率 = new Dictionary<int, List<float>>()
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
    public static List<float> 仙石品质倍数List = new List<float>() { 1, 1.5f, 2, 3, 5, 8, 12, 20 };

    public static List<float> 仙石分解品质倍数List = new List<float>() { 1, 1.5f, 2, 3, 5, 8, 12, 20 };

    public static Dictionary<int, float> 仙石分解Dic = new Dictionary<int, float>()
    {
        { 1 ,50},
        { 2 ,150},
        { 3 ,500},
        { 4 ,1500},
        { 5 ,5000},
        { 6 ,15000},
        { 7 ,50000},
        { 8 ,150000},
        { 9 ,500000},
        { 10 ,1500000},
        { 11 ,5000000},
        { 12 ,15000000},
        { 13 ,50000000},
        { 14 ,1500000000},
        { 15 ,5000000000},
        { 16 ,150000000000},
    };
    /// <summary>
    /// 按品质确定词条数量（黄品1条…荒品8条），按阶数取Minmaxes基础值；
    /// 词条存基础值，品质倍率在Get法器属性中统一乘算
    /// </summary>
    public static List<法器附加属性值> Get仙石附加属性(int 阶数, QualityType qualityType)
    {
        List<法器附加属性值> list = new List<法器附加属性值>();
        int 数量 = (int)qualityType;
        阶数 = Mathf.Clamp(阶数, 1, 16);
        for (int i = 0; i < 数量; i++)
        {
            int type = Random.Range(1, Enum.GetValues(typeof(法器附加属性Type)).Length);
            法器附加属性Type 附加属性Type = (法器附加属性Type)type;
            var key = new 法器附加属性品质type() { 法器附加属性Type = 附加属性Type, 阶数 = 阶数 };
            float min = 法器Config.法器Minmaxes[key].min;
            float max = 法器Config.法器Minmaxes[key].max;
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
            法器附加属性值.法器附加属性Type = (法器附加属性Type)type;
            list.Add(法器附加属性值);
        }
        return list;
    }

    public static 仙石 Get坊市仙石(仙石Type type, QualityType qualityType, int 阶数)
    {
        仙石 仙石 = new 仙石();
        仙石.quality = qualityType;
        仙石.type = type;
        仙石.阶数 = Mathf.Clamp(阶数, 1, 16);
        仙石.list = Get仙石附加属性(仙石.阶数, qualityType);
        return 仙石;
    }
    public static 仙石 单次仙石掉落(JingJieType jingJieType)
    {
        // 先按境界抽阶数（掉落概率表每个境界16档，索引0=1阶），再按阶数抽品质
        int 掉落阶数 = 1;
        float count = 0;
        float 阶数random = Random.Range(0, 100);
        if (仙石掉落概率Dic.TryGetValue(jingJieType, out var 阶数概率表))
        {
            for (int i = 0; i < 阶数概率表.Count; i++)
            {
                count += 阶数概率表[i];
                if (阶数random < count)
                {
                    掉落阶数 = i + 1;
                    break;
                }
            }
        }
        QualityType 掉落品质 = Random品质(掉落阶数);
        仙石 仙石 = new 仙石();
        仙石.阶数 = 掉落阶数;
        仙石.quality = 掉落品质;
        仙石.type = (仙石Type)Random.Range(1, Enum.GetValues(typeof(仙石Type)).Length);
        仙石.list = Get仙石附加属性(掉落阶数, 掉落品质);
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
        掉落数量 = (int)(掉落数量*属性config.总掉宝率);
        List<仙石> list = new List<仙石>();
        for (int i = 0; i < 掉落数量; i++)
        {
            list.Add(单次仙石掉落(jingJieType));
        }
        return list;
    }

    /// <summary>仙石显示名：赤阳石·3阶</summary>
    public static string Get仙石Name(仙石Type type, int 阶数)
    {
        string name = 仙石名Dic.TryGetValue(type, out var value) ? value : type.ToString();
        return name + "·" + Mathf.Clamp(阶数, 1, 16) + "阶";
    }

    /// <summary>按阶数抽取品质（概率为万分比，索引0=黄品…7=荒品）</summary>
    public static QualityType Random品质(int 阶数)
    {
        阶数 = Mathf.Clamp(阶数, 1, 16);
        if (!仙石品质掉落概率.TryGetValue(阶数, out var 概率表) || 概率表 == null || 概率表.Count == 0)
            return QualityType.黄品;
        float random = Random.Range(0f, 10000f);
        for (int i = 概率表.Count - 1; i >= 0; i--)
        {
            if (random < 概率表[i]) return (QualityType)(i + 1);
        }
        return QualityType.黄品;
    }

    /// <summary>仙石重铸消耗 = 阶数基础值 × 重铸品质倍数</summary>
    public static float Get仙石重铸消耗(仙石 仙石)
    {
        return Get仙石重铸消耗(仙石.阶数, 仙石.quality);
    }

    public static float Get仙石重铸消耗(int 阶数, QualityType qualityType)
    {
        阶数 = Mathf.Clamp(阶数, 1, 16);
        float 基础 = 仙石重铸消耗Dic.TryGetValue(阶数, out var value) ? value : 仙石重铸消耗Dic[1];
        return 基础 * 法器Config.Get品质倍数(仙石重铸品质倍数List, qualityType);
    }

    /// <summary>仙石分解精华 = 阶数基础值 × 分解品质倍数</summary>
    public static float Get仙石分解精华(仙石 仙石)
    {
        return Get仙石分解精华(仙石.阶数, 仙石.quality);
    }

    public static float Get仙石分解精华(int 阶数, QualityType qualityType)
    {
        阶数 = Mathf.Clamp(阶数, 1, 16);
        float 基础 = 仙石分解Dic.TryGetValue(阶数, out var value) ? value : 仙石分解Dic[1];
        return 基础 * 法器Config.Get品质倍数(仙石分解品质倍数List, qualityType);
    }
}
