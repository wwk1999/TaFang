using System;
using System.Collections.Generic;
using Config;
using Random = UnityEngine.Random;


public class 坊市物品
{
    public 法器Type 法器Type;
    public 仙石Type 仙石Type;
    public 丹药Type 丹药Type;
    public 丹药Type 丹方Type;
    public QualityType QualityType;
}
public class 坊市Config
{
    public static Dictionary<QualityType, long> 法器价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 300 },
        { QualityType.玄品, 2000 },
        { QualityType.地品, 10000 },
        { QualityType.天品, 50000 },
        { QualityType.宇品, 200000 },
        { QualityType.宙品, 1200000 },
        { QualityType.洪品, 10000000 },
        { QualityType.荒品, 100000000 },
    };
    
    public static Dictionary<QualityType, long> 战斗丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 300 },
        { QualityType.玄品, 2000 },
        { QualityType.地品, 10000 },
        { QualityType.天品, 50000 },
        { QualityType.宇品, 200000 },
        { QualityType.宙品, 1200000 },
        { QualityType.洪品, 10000000 },
        { QualityType.荒品, 100000000 },
    };
    public static Dictionary<QualityType, long> 战斗丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 3000 },
        { QualityType.玄品, 20000 },
        { QualityType.地品, 100000 },
        { QualityType.天品, 500000 },
        { QualityType.宇品, 2000000 },
        { QualityType.宙品, 12000000 },
        { QualityType.洪品, 100000000 },
        { QualityType.荒品, 1000000000 },
    };
    
    public static Dictionary<QualityType, long> 辅助丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 500 },
        { QualityType.玄品, 3000 },
        { QualityType.地品, 20000 },
        { QualityType.天品, 100000 },
        { QualityType.宇品, 400000 },
        { QualityType.宙品, 2400000 },
        { QualityType.洪品, 20000000 },
        { QualityType.荒品, 200000000 },
    };
    public static Dictionary<QualityType, long> 辅助丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 5000 },
        { QualityType.玄品, 30000 },
        { QualityType.地品, 200000 },
        { QualityType.天品, 1000000 },
        { QualityType.宇品, 4000000 },
        { QualityType.宙品, 24000000 },
        { QualityType.洪品, 200000000 },
        { QualityType.荒品, 2000000000 },
    };
    
    public static Dictionary<QualityType, long> 功法价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 5000 },
        { QualityType.玄品, 30000 },
        { QualityType.地品, 200000 },
        { QualityType.天品, 1000000 },
        { QualityType.宇品, 4000000 },
        { QualityType.宙品, 24000000 },
        { QualityType.洪品, 200000000 },
        { QualityType.荒品, 2000000000 },
    };
    public static Dictionary<QualityType, long> 根基丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 1000 },
        { QualityType.玄品, 6000 },
        { QualityType.地品, 40000 },
        { QualityType.天品, 200000 },
        { QualityType.宇品, 800000 },
        { QualityType.宙品, 4800000 },
        { QualityType.洪品, 40000000 },
        { QualityType.荒品, 400000000 },
    };
    
    public static Dictionary<QualityType, long> 根基丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 10000 },
        { QualityType.玄品, 60000 },
        { QualityType.地品, 400000 },
        { QualityType.天品, 2000000 },
        { QualityType.宇品, 8000000 },
        { QualityType.宙品, 48000000 },
        { QualityType.洪品, 400000000 },
        { QualityType.荒品, 4000000000 },
    };
    
    public static Dictionary<QualityType, long> 造化丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 10000 },
        { QualityType.玄品, 60000 },
        { QualityType.地品, 400000 },
        { QualityType.天品, 2000000 },
        { QualityType.宇品, 8000000 },
        { QualityType.宙品, 48000000 },
        { QualityType.洪品, 400000000},
        { QualityType.荒品, 4000000000 },
    };
    
    public static Dictionary<QualityType, long> 造化丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 100000 },
        { QualityType.玄品, 600000 },
        { QualityType.地品, 4000000 },
        { QualityType.天品, 20000000 },
        { QualityType.宇品, 80000000 },
        { QualityType.宙品, 480000000 },
        { QualityType.洪品, 4000000000},
        { QualityType.荒品, 40000000000 },
    };

    
    public static Dictionary<QualityType, long> 仙石价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 300 },
        { QualityType.玄品, 2000 },
        { QualityType.地品, 10000 },
        { QualityType.天品, 50000 },
        { QualityType.宇品, 200000 },
        { QualityType.宙品, 1200000 },
        { QualityType.洪品, 10000000 },
        { QualityType.荒品, 100000000 },
    };
    
    public static Dictionary<JingJieType, List<ZhaoMuItem>> 坊市概率Dic =
            new Dictionary<JingJieType, List<ZhaoMuItem>>()
            {
                {
                    JingJieType.练气,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 50 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 5 }
                    }
                },

                {
                    JingJieType.筑基,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 10 }
                    }
                },

                {
                    JingJieType.金丹,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 15 }
                    }
                },

                {
                    JingJieType.元婴,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 20 }
                    }
                },

                {
                    JingJieType.化神,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 32 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 3 }
                    }
                },

                {
                    JingJieType.合体,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 5 }
                    }
                },

                {
                    JingJieType.大乘,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 5 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 42 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 8 }
                    }
                },

                {
                    JingJieType.天仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 40 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 12 }
                    }
                },

                {
                    JingJieType.玄仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 3 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 16 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 1 },
                    }
                },

                {
                    JingJieType.金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 20 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 3 },
                    }
                },

                {
                    JingJieType.太乙金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 8 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 16 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 24 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 5 },
                    }
                },

                {
                    JingJieType.大罗金仙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 12 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 45 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 8 },
                    }
                },

                {
                    JingJieType.准圣,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 12 },
                    }
                },

                {
                    JingJieType.圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 2 },
                    }
                },

                {
                    JingJieType.天道圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 13 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 18 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 4 },
                    }
                },

                {
                    JingJieType.大道圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 21 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 6 },
                    }
                },

                {
                    JingJieType.混元圣人,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 9 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 25 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 24 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 8 },
                        new ZhaoMuItem() { type = QualityType.荒品, count = 1 },
                    }
                },
                
                
                {
                    JingJieType.鸿蒙,
                    new List<ZhaoMuItem>()
                    {
                        new ZhaoMuItem() { type = QualityType.黄品, count = 1 },
                        new ZhaoMuItem() { type = QualityType.玄品, count = 2 },
                        new ZhaoMuItem() { type = QualityType.地品, count = 4 },
                        new ZhaoMuItem() { type = QualityType.天品, count = 15 },
                        new ZhaoMuItem() { type = QualityType.宇品, count = 30 },
                        new ZhaoMuItem() { type = QualityType.宙品, count = 35 },
                        new ZhaoMuItem() { type = QualityType.洪品, count = 10 },
                        new ZhaoMuItem() { type = QualityType.荒品, count = 3 },
                    }
                },
            };

    public static QualityType Get坊市物品品质()
    {
        List<ZhaoMuItem> list = 坊市概率Dic[PlayerData.S.JingJieType];
        float random = Random.Range(0, 100f);
        float count = 0;
        foreach (var  item in list)
        {
            count += item.count;
            if (random <= count)
            {
                return item.type;
            }
        }

        return QualityType.黄品;
    }

    public static 坊市物品 Get坊市物品()
    {
        int 物品类型 = Random.Range(1, 5);
        QualityType QualityType = Get坊市物品品质();
        坊市物品 坊市物品 = new 坊市物品();
        坊市物品.QualityType = QualityType;
        switch (物品类型)
        {
            case 1:
                var list = 法器Config.法器品质列表Dic[QualityType];
                坊市物品.法器Type = list[Random.Range(0, list.Count)];
                break;
            case 2:
                坊市物品.仙石Type = (仙石Type)Random.Range(1, Enum.GetValues(typeof(仙石Type)).Length);
                break;
            case 3:
                坊市物品.丹药Type=(丹药Type)Random.Range(1, Enum.GetValues(typeof(丹药Type)).Length);
                break;
            case 4:
                坊市物品.丹方Type=(丹药Type)Random.Range(1, Enum.GetValues(typeof(丹药Type)).Length);
                break;
        }

        return 坊市物品;
    }
    
}
