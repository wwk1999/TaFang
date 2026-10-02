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
    public bool 是否被购买 = false;
}
public class 坊市Config
{
    public static Dictionary<QualityType, long> 法器价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 200 },
        { QualityType.玄品, 500 },
        { QualityType.地品, 2000 },
        { QualityType.天品, 6000 },
        { QualityType.宇品, 50000 },
        { QualityType.宙品, 1000000 },
        { QualityType.洪品, 20000000 },
        { QualityType.荒品, 1000000000 },
    };
    
    public static Dictionary<QualityType, long> 战斗丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 100 },
        { QualityType.玄品, 200 },
        { QualityType.地品, 500 },
        { QualityType.天品, 2000 },
        { QualityType.宇品, 10000 },
        { QualityType.宙品, 50000 },
        { QualityType.洪品, 300000 },
        { QualityType.荒品, 1000000 },
    };
    public static Dictionary<QualityType, long> 战斗丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 1000 },
        { QualityType.玄品, 2000 },
        { QualityType.地品, 5000 },
        { QualityType.天品, 20000 },
        { QualityType.宇品, 100000 },
        { QualityType.宙品, 500000},
        { QualityType.洪品, 3000000 },
        { QualityType.荒品, 10000000 },
    };
    
    public static Dictionary<QualityType, long> 辅助丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 200 },
        { QualityType.玄品, 500 },
        { QualityType.地品, 2000 },
        { QualityType.天品, 10000 },
        { QualityType.宇品, 50000 },
        { QualityType.宙品, 300000 },
        { QualityType.洪品, 1000000 },
        { QualityType.荒品, 10000000 },
    };
    public static Dictionary<QualityType, long> 辅助丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 2000 },
        { QualityType.玄品, 5000 },
        { QualityType.地品, 20000 },
        { QualityType.天品, 100000 },
        { QualityType.宇品, 500000 },
        { QualityType.宙品, 3000000 },
        { QualityType.洪品, 10000000 },
        { QualityType.荒品, 100000000 },
    };
    public static Dictionary<QualityType, long> 功法价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 3000 },
        { QualityType.玄品, 8000 },
        { QualityType.地品, 30000 },
        { QualityType.天品, 80000 },
        { QualityType.宇品, 300000 },
        { QualityType.宙品, 800000 },
        { QualityType.洪品, 3000000 },
        { QualityType.荒品, 15000000 },
    };
    public static Dictionary<QualityType, long> 根基丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 500 },
        { QualityType.玄品, 2000 },
        { QualityType.地品, 10000 },
        { QualityType.天品, 50000 },
        { QualityType.宇品, 300000 },
        { QualityType.宙品, 1000000 },
        { QualityType.洪品, 5000000 },
        { QualityType.荒品, 50000000 },
    };
    
    public static Dictionary<QualityType, long> 根基丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 5000 },
        { QualityType.玄品, 20000 },
        { QualityType.地品, 100000 },
        { QualityType.天品, 500000 },
        { QualityType.宇品, 3000000 },
        { QualityType.宙品, 10000000 },
        { QualityType.洪品, 50000000 },
        { QualityType.荒品, 500000000 },
    };
    
    public static Dictionary<QualityType, long> 造化丹药价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 2000 },
        { QualityType.玄品, 10000 },
        { QualityType.地品, 50000 },
        { QualityType.天品, 300000 },
        { QualityType.宇品, 1000000 },
        { QualityType.宙品, 5000000 },
        { QualityType.洪品, 30000000 },
        { QualityType.荒品, 300000000 },
    };
    
    public static Dictionary<QualityType, long> 造化丹方价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 20000 },
        { QualityType.玄品, 100000 },
        { QualityType.地品, 500000 },
        { QualityType.天品, 3000000 },
        { QualityType.宇品, 10000000 },
        { QualityType.宙品, 50000000 },
        { QualityType.洪品, 300000000 },
        { QualityType.荒品, 3000000000 },
    };

    
    public static Dictionary<QualityType, long> 仙石价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 100 },
        { QualityType.玄品, 300 },
        { QualityType.地品, 1000 },
        { QualityType.天品, 5000 },
        { QualityType.宇品, 30000 },
        { QualityType.宙品, 200000 },
        { QualityType.洪品, 1500000 },
        { QualityType.荒品, 30000000 },
    };
    
   

    public static QualityType Get坊市物品品质()
    {
        var list = 道场Config.坊市配置[PlayerData.S.坊市等级].概率;
        float random = Random.Range(0, 100f);
        float count = 0;
        QualityType qualityType = QualityType.黄品;
        foreach (var  item in list)
        {
            count += item;
            if (random <= count)
            {
                return qualityType;
            }

            qualityType++;
        }

        return QualityType.黄品;
    }

    public static void 刷新坊市列表()
    {
        PlayerData.S.坊市物品列表.Clear();
        for (int i = 0; i < 12; i++)
        {
            var item = Get坊市物品();
            PlayerData.S.坊市物品列表.Add(item);
        }
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
