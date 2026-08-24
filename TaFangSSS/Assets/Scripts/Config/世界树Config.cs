using System.Collections.Generic;
using Config;
using UnityEngine;

public class 世界树秘境寻宝Item
{
    public bool 寻宝;
    public float time;
    public bool 重复;
    public List<寻宝道宝道具item> list;
}
public class 寻宝道宝道具item
{
    public 道宝Type 道宝Type;
    public int count;
}
public class 世界树Config
{
    public static int Get世界树最大层数()
    {
        switch (PlayerData.S.历史最高境界)
        {
            case JingJieType.练气:
            case JingJieType.筑基:
                return 0;
            case JingJieType.金丹:
            case JingJieType.元婴:
                return 1;
            case JingJieType.化神:
            case JingJieType.合体:
                return 2;
            case JingJieType.大乘:
            case JingJieType.天仙:
                return 3;
            case JingJieType.玄仙:
            case JingJieType.金仙:
                return 4;
            case JingJieType.太乙金仙:
            case JingJieType.大罗金仙:
                return 5;
            case JingJieType.准圣:
            case JingJieType.圣人:
                return 6;
            case JingJieType.天道圣人:
            case JingJieType.大道圣人:
                return 7;
            case JingJieType.混元圣人:
                return 8;
            case JingJieType.鸿蒙:
                return 9;
        }
        return 0;
    }
    public static Dictionary<int, 秘境属性> 世界树关卡Dic = new Dictionary<int, 秘境属性>()
    {
        {
            1,
            new 秘境属性()
            {
                jingJieType = JingJieType.金丹,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.天品, 概率 = 70 },
                    new 掉落item() { quality = QualityType.宇品, 概率 = 30 },
                },
                掉落数量 = 2,
                需要年数 = 0.2f,
                需要人数 = 2,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 0,
                需要英雄元素 = YuanSuType.冰,
                需要英雄职业 = ZhiYeType.None,
            }
        },

        {
            2,
            new 秘境属性()
            {
                jingJieType = JingJieType.化神,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.天品, 概率 = 50 },
                    new 掉落item() { quality = QualityType.宇品, 概率 = 40 },
                    new 掉落item() { quality = QualityType.宙品, 概率 = 10 },
                },
                掉落数量 = 3,
                需要年数 = 0.5f,
                需要人数 = 3,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 1,
                需要英雄元素 = YuanSuType.火,
                需要英雄职业 = ZhiYeType.None,
            }
        },

        {
            3,
            new 秘境属性()
            {
                jingJieType = JingJieType.大乘,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.天品, 概率 = 30 },
                    new 掉落item() { quality = QualityType.宇品, 概率 = 50 },
                    new 掉落item() { quality = QualityType.宙品, 概率 = 20 },
                },
                掉落数量 = 4,
                需要年数 = 1,
                需要人数 = 3,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 2,
                需要英雄元素 = YuanSuType.物理,
                需要英雄职业 = ZhiYeType.None,
            }
        },

        {
            4,
            new 秘境属性()
            {
                jingJieType = JingJieType.玄仙,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.天品, 概率 = 10 },
                    new 掉落item() { quality = QualityType.宇品, 概率 = 55 },
                    new 掉落item() { quality = QualityType.宙品, 概率 = 30 },
                    new 掉落item() { quality = QualityType.洪品, 概率 = 5 },
                },
                掉落数量 = 5,
                需要年数 = 2,
                需要人数 = 4,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 2,
                需要英雄元素 = YuanSuType.电,
                需要英雄职业 = ZhiYeType.None,
            }
        },


        {
            5,
            new 秘境属性()
            {
                jingJieType = JingJieType.太乙金仙,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.宇品, 概率 = 50 },
                    new 掉落item() { quality = QualityType.宙品, 概率 = 40 },
                    new 掉落item() { quality = QualityType.洪品, 概率 = 10 },
                },
                掉落数量 = 6,
                需要年数 = 5,
                需要人数 = 4,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 3,
                需要英雄元素 = YuanSuType.黑暗,
                需要英雄职业 = ZhiYeType.None,
            }
        },

        {
            6,
            new 秘境属性()
            {
                jingJieType = JingJieType.准圣,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.宇品, 概率 = 35 },
                    new 掉落item() { quality = QualityType.宙品, 概率 = 50 },
                    new 掉落item() { quality = QualityType.洪品, 概率 = 15 },
                },
                掉落数量 = 7,
                需要年数 = 10,
                需要人数 = 4,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 3,
                需要英雄元素 = YuanSuType.火,
                需要英雄职业 = ZhiYeType.None,
            }
        },

        {
            7,
            new 秘境属性()
            {
                jingJieType = JingJieType.天道圣人,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.宇品, 概率 = 20 },
                    new 掉落item() { quality = QualityType.宙品, 概率 = 60 },
                    new 掉落item() { quality = QualityType.洪品, 概率 = 20 },
                },
                掉落数量 = 8,
                需要年数 = 20,
                需要人数 = 4,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 4,
                需要英雄元素 = YuanSuType.黑暗,
                需要英雄职业 = ZhiYeType.None,
            }
        },

        {
            8,
            new 秘境属性()
            {
                jingJieType = JingJieType.混元圣人,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.宙品, 概率 = 70 },
                    new 掉落item() { quality = QualityType.洪品, 概率 = 25 },
                    new 掉落item() { quality = QualityType.荒品, 概率 = 5 },
                },
                掉落数量 = 9,
                需要年数 = 50,
                需要人数 = 4,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 4,
                需要英雄元素 = YuanSuType.冰,
                需要英雄职业 = ZhiYeType.None,
            }
        },

        {
            9,
            new 秘境属性()
            {
                jingJieType = JingJieType.鸿蒙,
                list = new List<掉落item>()
                {
                    new 掉落item() { quality = QualityType.宙品, 概率 = 50 },
                    new 掉落item() { quality = QualityType.洪品, 概率 = 40 },
                    new 掉落item() { quality = QualityType.荒品, 概率 = 10 },
                },
                掉落数量 = 10,
                需要年数 = 100,
                需要人数 = 4,
                需要英雄品质 = QualityType.None,
                需要英雄星级 = 5,
                需要英雄元素 = YuanSuType.物理,
                需要英雄职业 = ZhiYeType.None,
            }
        },
    };
    public static 道宝Type Get随机道宝Type(QualityType qualityType)
    {
        var list=道宝Config.道宝品质列表[道宝Config.QualityTo道宝Quality[qualityType]];
        int random=Random.Range(0, list.Count);
        return  list[random];
    }
    
    public static List<道宝Type> Get世界树掉落(int 层数)
    {
        int count = 世界树关卡Dic[层数].掉落数量;
        List<道宝Type> list = new List<道宝Type>();
        for (int i = 0; i < count; i++)
        {
            float random = Random.Range(0, 100f);
            float 概率 = 0;
            QualityType quality=QualityType.None;
            foreach (var item in 世界树关卡Dic[层数].list)
            {
                概率 += item.概率;
                if (random <= 概率)
                {
                    quality=item.quality;
                    break;
                }
            }
            list.Add(Get随机道宝Type(quality));
        }

        return list;
    }
}
