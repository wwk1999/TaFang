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
    
    public static Dictionary<QualityType, long> 战斗丹药分解价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 10 },
        { QualityType.玄品, 20 },
        { QualityType.地品, 50 },
        { QualityType.天品, 200 },
        { QualityType.宇品, 1000 },
        { QualityType.宙品, 5000 },
        { QualityType.洪品, 30000 },
        { QualityType.荒品, 100000 },
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
    
    public static Dictionary<QualityType, long> 辅助丹药分解价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 20 },
        { QualityType.玄品, 50 },
        { QualityType.地品, 200 },
        { QualityType.天品, 1000 },
        { QualityType.宇品, 5000 },
        { QualityType.宙品, 30000 },
        { QualityType.洪品, 100000 },
        { QualityType.荒品, 1000000 },
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
    
    public static Dictionary<QualityType, long> 根基丹药分解价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 50 },
        { QualityType.玄品, 200 },
        { QualityType.地品, 1000 },
        { QualityType.天品, 5000 },
        { QualityType.宇品, 30000 },
        { QualityType.宙品, 100000 },
        { QualityType.洪品, 500000 },
        { QualityType.荒品, 5000000 },
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
    public static Dictionary<QualityType, long> 造化丹药分解价格Dic = new Dictionary<QualityType, long>()
    {
        { QualityType.黄品, 200 },
        { QualityType.玄品, 1000 },
        { QualityType.地品, 5000 },
        { QualityType.天品, 30000 },
        { QualityType.宇品, 100000 },
        { QualityType.宙品, 500000 },
        { QualityType.洪品, 3000000 },
        { QualityType.荒品, 30000000 },
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

        for (int i = 0; i < PlayerData.S.坊市物品列表.Count; i++)
        {
            if (PlayerData.S.坊市物品列表[i].法器Type != 法器Type.None)
            {
                if (PlayerData.S.Get坊市法器自动购买(PlayerData.S.坊市物品列表[i].法器Type))
                {
                    float value =法器价格Dic[法器Config.法器品质Dic[PlayerData.S.坊市物品列表[i].法器Type]] /
                                  (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                    if (PlayerData.S.PropListDic[PropType.灵魂] < value)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= value;
                    法器 法器 = 法器Config.Get坊市法器(PlayerData.S.坊市物品列表[i].法器Type);
                    PlayerData.S.法器列表.Add(法器);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast",法器Config.法器名Dic[PlayerData.S.坊市物品列表[i].法器Type],法器Config.法器品质Dic[PlayerData.S.坊市物品列表[i].法器Type],1);
                }
            }
            
            if (PlayerData.S.坊市物品列表[i].仙石Type != 仙石Type.None)
            {
                if (PlayerData.S.Get坊市仙石自动购买(PlayerData.S.坊市物品列表[i].仙石Type,PlayerData.S.坊市物品列表[i].QualityType))
                {
                    float value =仙石价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                    if (PlayerData.S.PropListDic[PropType.灵魂] < value)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= value;
                    仙石 仙石 = 仙石Config.Get坊市仙石(PlayerData.S.坊市物品列表[i].仙石Type,PlayerData.S.坊市物品列表[i].QualityType);
                    PlayerData.S.仙石列表.Add(仙石);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast",仙石Config.仙石名Dic[PlayerData.S.坊市物品列表[i].仙石Type],PlayerData.S.坊市物品列表[i].QualityType,1);

                }
            }

            if (PlayerData.S.坊市物品列表[i].丹药Type != 丹药Type.None)
            {
                if (PlayerData.S.Get坊市丹药自动购买(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType))
                {
                    var 丹药类型 = 丹药Config.丹药类型Dic[PlayerData.S.坊市物品列表[i].丹药Type];
                    float 价格 = 0;
                    switch (丹药类型)
                    {
                        case 丹药类型.战斗丹药:
                            价格=战斗丹药价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                        case 丹药类型.辅助丹药:
                            价格=辅助丹药价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                        case 丹药类型.根基丹药:
                            价格=根基丹药价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                        case 丹药类型.造化丹药:
                            价格=造化丹药价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                    }
                    if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                    PlayerData.S.Set丹药数量(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType,PlayerData.S.Get丹药数量(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType)+1);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast",丹药Config.丹药名Dic[PlayerData.S.坊市物品列表[i].丹药Type],PlayerData.S.坊市物品列表[i].QualityType,1);

                }
            }

            if (PlayerData.S.坊市物品列表[i].丹方Type != 丹药Type.None&&!PlayerData.S.Get丹方解锁(PlayerData.S.坊市物品列表[i].丹方Type,PlayerData.S.坊市物品列表[i].QualityType))
            {
                if (PlayerData.S.Get坊市丹方自动购买(PlayerData.S.坊市物品列表[i].丹方Type,PlayerData.S.坊市物品列表[i].QualityType))
                {
                    var 丹药类型 = 丹药Config.丹药类型Dic[PlayerData.S.坊市物品列表[i].丹方Type];
                    float 价格 = 0;
                    switch (丹药类型)
                    {
                        case 丹药类型.战斗丹药:
                            价格=战斗丹方价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                        case 丹药类型.辅助丹药:
                            价格=辅助丹方价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                        case 丹药类型.根基丹药:
                            价格=根基丹方价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                        case 丹药类型.造化丹药:
                            价格=造化丹方价格Dic[PlayerData.S.坊市物品列表[i].QualityType]/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                            break;
                    }
                    if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                    PlayerData.S.Set丹方数量(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType,PlayerData.S.Get丹药数量(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType)+1);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast",丹药Config.丹方名Dic[PlayerData.S.坊市物品列表[i].丹方Type],PlayerData.S.坊市物品列表[i].QualityType,1);
                }
            }
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
