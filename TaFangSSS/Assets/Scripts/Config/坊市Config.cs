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
    public int 阶数=1;
    public QualityType QualityType;
    public bool 是否被购买 = false;
}
public class 坊市Config
{
    /// <summary>阶数→品质固定映射（法器与仙石共用，每个阶数只出现对应品质）</summary>
    public static Dictionary<int, QualityType> 坊市阶数品质Dic = new Dictionary<int, QualityType>()
    {
        { 1, QualityType.黄品 },
        { 2, QualityType.黄品 },
        { 3, QualityType.玄品 },
        { 4, QualityType.玄品 },
        { 5, QualityType.玄品 },
        { 6, QualityType.地品 },
        { 7, QualityType.地品 },
        { 8, QualityType.地品 },

        { 9, QualityType.天品 },
        { 10, QualityType.天品 },
        { 11, QualityType.天品 },
        { 12, QualityType.天品 },
        { 13, QualityType.宇品 },
        { 14, QualityType.宇品 },
        { 15, QualityType.宇品 },
        { 16, QualityType.宇品 },
    };

    
    public static Dictionary<int, float> 法器价格Dic = new Dictionary<int, float>()
    {
        { 1, 200 },
        { 2, 500 },
        { 3, 2000 },
        { 4, 6000 },
        { 5, 50000 },
        { 6, 1000000 },
        { 7, 20000000 },
        { 8, 100000000 },
        
        { 9, 500000000 },
        { 10, 2500000000 },
        { 11, 10000000000 },
        { 12, 50000000000 },
        { 13, 250000000000 },
        { 14, 1000000000000 },
        { 15, 5000000000000 },
        { 16, 25000000000000 },
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

    
    /// <summary>仙石售价 = 阶数基础价 × 品质倍数 × 2（与分解产出同口径，高阶自然拉开）</summary>
    public static float Get仙石价格(int 阶数, QualityType qualityType)
    {
        return 仙石Config.Get仙石分解精华(阶数, qualityType) * 2;
    }

    // ============ 新增：丹药/丹方的阶数×品质价格系统 ============

    /// <summary>丹药按阶数的基础价（1-16阶，按丹药类型区分）</summary>
    public static Dictionary<丹药类型, Dictionary<int, float>> 丹药阶数价格Dic = new Dictionary<丹药类型, Dictionary<int, float>>
    {
        { 丹药类型.战斗丹药, new Dictionary<int, float>
            { {1,100},{2,300},{3,600},{4,1200},{5,2500},{6,5000},{7,10000},{8,20000},{9,40000},{10,80000},{11,160000},{12,320000},{13,640000},{14,1280000},{15,2560000},{16,5120000} } },
        { 丹药类型.辅助丹药, new Dictionary<int, float>
            { {1,200},{2,600},{3,1200},{4,2400},{5,5000},{6,10000},{7,20000},{8,40000},{9,80000},{10,160000},{11,320000},{12,640000},{13,1280000},{14,2560000},{15,5120000},{16,10240000} } },
        { 丹药类型.根基丹药, new Dictionary<int, float>
            { {1,500},{2,1500},{3,3000},{4,6000},{5,12500},{6,25000},{7,50000},{8,100000},{9,200000},{10,400000},{11,800000},{12,1600000},{13,3200000},{14,6400000},{15,12800000},{16,25600000} } },
        { 丹药类型.造化丹药, new Dictionary<int, float>
            { {1,2000},{2,6000},{3,12000},{4,24000},{5,50000},{6,100000},{7,200000},{8,400000},{9,800000},{10,1600000},{11,3200000},{12,6400000},{13,12800000},{14,25600000},{15,51200000},{16,102400000} } },
    };

    /// <summary>丹方按阶数的基础价（1-16阶）</summary>
    public static Dictionary<丹药类型, Dictionary<int, float>> 丹方阶数价格Dic = new Dictionary<丹药类型, Dictionary<int, float>>
    {
        { 丹药类型.战斗丹药, new Dictionary<int, float>
            { {1,1000},{2,3000},{3,6000},{4,12000},{5,25000},{6,50000},{7,100000},{8,200000},{9,400000},{10,800000},{11,1600000},{12,3200000},{13,6400000},{14,12800000},{15,25600000},{16,51200000} } },
        { 丹药类型.辅助丹药, new Dictionary<int, float>
            { {1,2000},{2,6000},{3,12000},{4,24000},{5,50000},{6,100000},{7,200000},{8,400000},{9,800000},{10,1600000},{11,3200000},{12,6400000},{13,12800000},{14,25600000},{15,51200000},{16,102400000} } },
        { 丹药类型.根基丹药, new Dictionary<int, float>
            { {1,5000},{2,15000},{3,30000},{4,60000},{5,125000},{6,250000},{7,500000},{8,1000000},{9,2000000},{10,4000000},{11,8000000},{12,16000000},{13,32000000},{14,64000000},{15,128000000},{16,256000000} } },
        { 丹药类型.造化丹药, new Dictionary<int, float>
            { {1,20000},{2,60000},{3,120000},{4,240000},{5,500000},{6,1000000},{7,2000000},{8,4000000},{9,8000000},{10,16000000},{11,32000000},{12,64000000},{13,128000000},{14,256000000},{15,512000000},{16,1024000000} } },
    };

    /// <summary>品质价格系数（丹药品质不固定时，丹药价格需×品质系数；丹方无品质概念所以不用）</summary>
    public static Dictionary<QualityType, float> 丹方品质系数Dic = new Dictionary<QualityType, float>
    {
        { QualityType.黄品, 1 },
        { QualityType.玄品, 1.5f },
        { QualityType.地品, 2.5f },
        { QualityType.天品, 4 },
        { QualityType.宇品, 6 },
        { QualityType.宙品, 10 },
        { QualityType.洪品, 20 },
        { QualityType.荒品, 50 },
    };

    /// <summary>坊市等级→丹方最高阶数（1-3级只能1阶，4-6级只能2阶，以此类推）</summary>
    public static int Get丹方最高购买阶数()
    {
        int 等级 = PlayerData.S.建筑等级Dic[建筑Type.坊市];
        return Math.Min(16, Math.Max(1, (等级 - 1) / 3 + 1)); // 每3级解锁一个新阶数段
    }

    /// <summary>丹药售价 = 阶数基础价 × 品质系数</summary>
    public static float Get丹药阶数价格(丹药Type type, int 阶数, QualityType qualityType)
    {
        丹药类型 丹药类型 = 丹药Config.丹药类型Dic[type];
        if (丹药阶数价格Dic.TryGetValue(丹药类型, out var 阶数Dic) && 阶数Dic.TryGetValue(阶数, out float 基础价))
        {
            丹方品质系数Dic.TryGetValue(qualityType, out float 系数);
            return 基础价 * Math.Max(1, 系数);
        }
        return 0;
    }

    /// <summary>丹方售价 = 阶数基础价（丹方无品质概念）</summary>
    public static float Get丹方阶数价格(丹药Type type, int 阶数)
    {
        丹药类型 丹药类型 = 丹药Config.丹药类型Dic[type];
        if (丹方阶数价格Dic.TryGetValue(丹药类型, out var 阶数Dic) && 阶数Dic.TryGetValue(阶数, out float 基础价))
            return 基础价;
        return 0;
    }

    /// <summary>坊市丹药生成：阶数由坊市等级限定，品质最高天品（随机）</summary>
    public static int 随机丹方阶数()
    {
        return Random.Range(1, Get丹方最高购买阶数() + 1);
    }

    /// <summary>坊市丹药品质随机（最高天品）</summary>
    public static QualityType 随机丹药品质()
    {
        // 品质权重最高到天品（前4品质），后4品质权重0
        var 权重 = new Dictionary<QualityType, float>
        {
            { QualityType.黄品, 45 }, { QualityType.玄品, 30 },
            { QualityType.地品, 15 }, { QualityType.天品, 10 },
        };
        float random = Random.value * 100f;
        float 累计 = 0;
        foreach (var kvp in 权重)
        {
            累计 += kvp.Value;
            if (random <= 累计) return kvp.Key;
        }
        return QualityType.黄品;
    }
    
   

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

    /// <summary>当前坊市等级可购买的法器最高阶数（1~16），46级起可购买16阶</summary>
    public static int Get法器最高购买阶数()
    {
        int 等级 = PlayerData.S.建筑等级Dic[建筑Type.坊市];
        if (道场Config.坊市配置.TryGetValue(等级, out var 配置))
        {
            return Math.Min(16, Math.Max(1, 配置.最高购买阶数));
        }
        return 1;
    }

    /// <summary>法器售价（按阶数计价）</summary>
    public static float Get法器价格(int 阶数)
    {
        阶数 = Math.Min(16, Math.Max(1, 阶数));
        if (法器价格Dic.TryGetValue(阶数, out var value)) return value;
        return 法器价格Dic[1];
    }

    /// <summary>法器对应品质（按阶数查表，坊市法器固定品质）</summary>
    public static QualityType Get法器品质(int 阶数)
    {
        if (坊市阶数品质Dic.TryGetValue(Math.Min(16, Math.Max(1, 阶数)), out var quality)) return quality;
        return QualityType.黄品;
    }

    /// <summary>仙石对应品质（与法器共用阶数→品质映射，坊市仙石固定品质）</summary>
    public static QualityType Get仙石品质(int 阶数)
    {
        return Get法器品质(阶数);
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
                    var item = PlayerData.S.坊市物品列表[i];
                    float value = Get法器价格(item.阶数) /
                                  (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                    if (PlayerData.S.PropListDic[PropType.灵魂] < value)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= value;
                    法器 法器 = 法器Config.Get坊市法器(item.法器Type, item.QualityType, item.阶数);
                    PlayerData.S.法器列表.Add(法器);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast",法器Config.Get法器Name(item.法器Type, item.阶数), item.QualityType, 1);
                }
            }
            
            if (PlayerData.S.坊市物品列表[i].仙石Type != 仙石Type.None)
            {
                if (PlayerData.S.Get坊市仙石自动购买(PlayerData.S.坊市物品列表[i].仙石Type))
                {
                    float value =Get仙石价格(PlayerData.S.坊市物品列表[i].阶数, PlayerData.S.坊市物品列表[i].QualityType)/(1f+道场Config.供奉总属性.坊市价格减少/100f);
                    if (PlayerData.S.PropListDic[PropType.灵魂] < value)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= value;
                    仙石 仙石 = 仙石Config.Get坊市仙石(PlayerData.S.坊市物品列表[i].仙石Type,PlayerData.S.坊市物品列表[i].QualityType,PlayerData.S.坊市物品列表[i].阶数);
                    PlayerData.S.仙石列表.Add(仙石);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast",仙石Config.Get仙石Name(PlayerData.S.坊市物品列表[i].仙石Type, PlayerData.S.坊市物品列表[i].阶数),PlayerData.S.坊市物品列表[i].QualityType,1);

                }
            }

            if (PlayerData.S.坊市物品列表[i].丹药Type != 丹药Type.None)
            {
                if (PlayerData.S.Get坊市丹药自动购买(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType))
                {
                    float 价格 = Get丹药阶数价格(PlayerData.S.坊市物品列表[i].丹药Type, PlayerData.S.坊市物品列表[i].阶数, PlayerData.S.坊市物品列表[i].QualityType) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                    if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                    PlayerData.S.Set丹药数量(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType,PlayerData.S.Get丹药数量(PlayerData.S.坊市物品列表[i].丹药Type,PlayerData.S.坊市物品列表[i].QualityType)+1);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast", 丹药Config.丹药名Dic[PlayerData.S.坊市物品列表[i].丹药Type] + $"·{PlayerData.S.坊市物品列表[i].阶数}阶", PlayerData.S.坊市物品列表[i].QualityType, 1);

                }
            }

            if (PlayerData.S.坊市物品列表[i].丹方Type != 丹药Type.None&&!PlayerData.S.Get丹方解锁(PlayerData.S.坊市物品列表[i].丹方Type,PlayerData.S.坊市物品列表[i].阶数)&&PlayerData.S.Get丹方数量(PlayerData.S.坊市物品列表[i].丹方Type,PlayerData.S.坊市物品列表[i].阶数)<=0)
            {
                if (PlayerData.S.Get坊市丹方自动购买(PlayerData.S.坊市物品列表[i].丹方Type))
                {
                    float 价格 = Get丹方阶数价格(PlayerData.S.坊市物品列表[i].丹方Type, PlayerData.S.坊市物品列表[i].阶数) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                    if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToat","灵气不足,自动购买失败");
                        return;
                    }

                    PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                    PlayerData.S.Set丹方数量(PlayerData.S.坊市物品列表[i].丹方Type, PlayerData.S.坊市物品列表[i].阶数, PlayerData.S.Get丹方数量(PlayerData.S.坊市物品列表[i].丹方Type, PlayerData.S.坊市物品列表[i].阶数) + 1);
                    PlayerData.S.坊市物品列表[i].是否被购买 = true;
                    ObserverModuleManager.S.SendEvent("SendUIToast", 丹药Config.丹方名Dic[PlayerData.S.坊市物品列表[i].丹方Type] + $"·{PlayerData.S.坊市物品列表[i].阶数}阶", QualityType.None, 1);
                }
            }
        }
        
    }

    public static 坊市物品 Get坊市物品()
    {
        int 物品类型 = Random.Range(1, 5);
        坊市物品 坊市物品 = new 坊市物品();
        switch (物品类型)
        {
            case 1:
                // 法器：阶数受坊市等级限制，品质由阶数固定映射（不再随机）
                坊市物品.法器Type = (法器Type)Random.Range(1, Enum.GetValues(typeof(法器Type)).Length);
                坊市物品.阶数 = Random.Range(1, Get法器最高购买阶数() + 1);
                坊市物品.QualityType = Get法器品质(坊市物品.阶数);
                break;
            case 2:
                // 仙石：与法器一致，阶数受坊市等级限制，品质由阶数固定映射
                坊市物品.阶数 = Random.Range(1, Get法器最高购买阶数() + 1);
                坊市物品.QualityType = Get仙石品质(坊市物品.阶数);
                坊市物品.仙石Type = (仙石Type)Random.Range(1, Enum.GetValues(typeof(仙石Type)).Length);
                break;
            case 3:
                // 丹药：阶数由坊市等级限定，品质随机（最高天品）
                坊市物品.丹药Type = (丹药Type)Random.Range(1, Enum.GetValues(typeof(丹药Type)).Length);
                坊市物品.阶数 = 随机丹方阶数();
                坊市物品.QualityType = 随机丹药品质();
                break;
            case 4:
                // 丹方：只有Type+阶数，无品质概念
                坊市物品.丹方Type = (丹药Type)Random.Range(1, Enum.GetValues(typeof(丹药Type)).Length);
                坊市物品.阶数 = 随机丹方阶数();
                坊市物品.QualityType = QualityType.None; // 丹方不再有品质字段
                break;
        }

        return 坊市物品;
    }
    
}
