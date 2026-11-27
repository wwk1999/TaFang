using System;
using System.Collections.Generic;
using Config;
using Random = UnityEngine.Random;

public enum 符文之地Type
{
    None,
    青木林,
    赤炎窟,
    黑风谷,
    玄水深渊,
    紫雷泽,
    白骨荒原,
    金戈壁,
    幻梦泽,
    混沌墟,
    天道台,
}

public class 符文之地关卡怪物Item
{
    public 符文之地Type 符文之地Type;
    public MonsterType MonsterType;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        符文之地关卡怪物Item other = (符文之地关卡怪物Item)obj;
        return 符文之地Type == other.符文之地Type && MonsterType == other.MonsterType;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + 符文之地Type.GetHashCode();
            hash = hash * 23 + MonsterType.GetHashCode();
            return hash;
        }
    }

    public static bool operator ==(符文之地关卡怪物Item a, 符文之地关卡怪物Item b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(符文之地关卡怪物Item a, 符文之地关卡怪物Item b)
    {
        return !(a == b);
    }
}
public class 符文之地关卡胜利奖励
{
    public long 灵魂;
    public List<符文> 符文list;
}
public class 符文之地Config
{

    public static 符文之地关卡胜利奖励 Get符文之地奖励()
    {
        符文之地关卡胜利奖励 符文之地关卡胜利奖励 = new 符文之地关卡胜利奖励();
        符文之地关卡胜利奖励.符文list = Get符文之地掉落(LevelConfig.当前符文之地Type);
        var list = 符文之地掉落Dic[LevelConfig.当前符文之地Type];
        foreach (var item in list)
        {
            if (item.PropType == PropType.灵魂)
            {
                符文之地关卡胜利奖励.灵魂=(long)Random.Range(item.minCount, item.maxCount);
            }
        }
        return 符文之地关卡胜利奖励;
    }
    public static Dictionary<符文之地Type, List<MonsterTypeName>> 符文之地怪物列表 =
        new Dictionary<符文之地Type, List<MonsterTypeName>>()
        {
            {
                符文之地Type.青木林,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.藤蔓猴,
                    MonsterTypeName.木灵蝶,
                    MonsterTypeName.千年树妖,
                    MonsterTypeName.青木蛟,
                }
            },
            {
                符文之地Type.赤炎窟,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.火岩虫,
                    MonsterTypeName.熔岩火蜥,
                    MonsterTypeName.炎髓魔猿,
                    MonsterTypeName.火山兽,
                }
            },
            {
                符文之地Type.黑风谷,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.黑风貂,
                    MonsterTypeName.浮空水母,
                    MonsterTypeName.黑风双煞,
                    MonsterTypeName.黑风老妖,
                }
            },
            {
                符文之地Type.玄水深渊,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.水形怪,
                    MonsterTypeName.深渊鮟鱇,
                    MonsterTypeName.玄水毒蛟,
                    MonsterTypeName.玄水兽,
                }
            },
            {
                符文之地Type.紫雷泽,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.雷纹蛛,
                    MonsterTypeName.雷灵球,
                    MonsterTypeName.紫雷夔牛,
                    MonsterTypeName.紫雷兽,
                }
            },
            {
                符文之地Type.白骨荒原,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.白骨兵,
                    MonsterTypeName.噬魂鸦,
                    MonsterTypeName.白骨将,
                    MonsterTypeName.白骨兽,
                }
            },
            {
                符文之地Type.金戈壁,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.金甲傀,
                    MonsterTypeName.戈刃灵,
                    MonsterTypeName.金戈将,
                    MonsterTypeName.金戈兽,
                }
            },
            {
                符文之地Type.幻梦泽,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.幻梦蝶,
                    MonsterTypeName.幻梦虫,
                    MonsterTypeName.幻梦妖,
                    MonsterTypeName.幻梦兽,
                }
            },
            {
                符文之地Type.混沌墟,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.混沌虫,
                    MonsterTypeName.吞噬兽,
                    MonsterTypeName.混沌魔将,
                    MonsterTypeName.混沌兽王,
                }
            },
            {
                符文之地Type.天道台,
                new List<MonsterTypeName>
                {
                    MonsterTypeName.天道卫,
                    MonsterTypeName.造化灵,
                    MonsterTypeName.天道将,
                    MonsterTypeName.天道兽,
                }
            },
        };
    
    public static Dictionary<符文之地Type, SmallLevelInfo> 符文之地信息Dic = new Dictionary<符文之地Type, SmallLevelInfo>()
    {
        {
            符文之地Type.青木林, new SmallLevelInfo() { NormalMonsterCount = 200, CreateNormalMonsterTime = 0.5f, EliteMonsterCount = 5 }
        },
        {
            符文之地Type.赤炎窟, new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.45f, EliteMonsterCount = 6 }
        },
        {
            符文之地Type.黑风谷, new SmallLevelInfo() { NormalMonsterCount = 300, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 7 }
        },
        {
            符文之地Type.玄水深渊, new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.25f, EliteMonsterCount = 8 }
        },
        {
            符文之地Type.紫雷泽, new SmallLevelInfo() { NormalMonsterCount = 300, CreateNormalMonsterTime = 0.15f, EliteMonsterCount = 12 }
        },
        {
            符文之地Type.白骨荒原, new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.15f, EliteMonsterCount = 11 }
        },
        {
            符文之地Type.金戈壁, new SmallLevelInfo() { NormalMonsterCount = 400, CreateNormalMonsterTime = 0.15f, EliteMonsterCount = 12 }
        },
        {
            符文之地Type.幻梦泽, new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.15f, EliteMonsterCount = 12 }
        },
        {
            符文之地Type.混沌墟, new SmallLevelInfo() { NormalMonsterCount = 500, CreateNormalMonsterTime = 0.15f, EliteMonsterCount = 14 }
        },
        {
            符文之地Type.天道台, new SmallLevelInfo() { NormalMonsterCount = 550, CreateNormalMonsterTime = 0.15f, EliteMonsterCount = 15 }
        },
    };
    
    public static Dictionary<符文之地Type, string> 符文之地关卡名Dic = new Dictionary<符文之地Type, string>()
    {
        { 符文之地Type.青木林, "青木林" },
        { 符文之地Type.赤炎窟, "赤炎窟" },
        { 符文之地Type.黑风谷, "黑风谷" },
        { 符文之地Type.玄水深渊, "玄水深渊" },
        { 符文之地Type.紫雷泽, "紫雷泽" },
        { 符文之地Type.白骨荒原, "白骨荒原" },
        { 符文之地Type.金戈壁, "金戈壁" },
        { 符文之地Type.幻梦泽, "幻梦泽" },
        { 符文之地Type.混沌墟, "混沌墟" },
        { 符文之地Type.天道台, "天道台" },
    };

    public static Dictionary<符文之地Type, List<float>> 符文之地掉落概率Dic = new Dictionary<符文之地Type, List<float>>()
    {
        { 符文之地Type.青木林, new List<float>(){30,0,0,0,0,0,0,0} },
        { 符文之地Type.赤炎窟, new List<float>(){50,10,0,0,0,0,0,0} },
        { 符文之地Type.黑风谷, new List<float>(){70,20,0,0,0,0,0,0} },
        { 符文之地Type.玄水深渊, new List<float>(){90,30,5,0,0,0,0,0} },
        { 符文之地Type.紫雷泽, new List<float>(){100,40,10,0,0,0,0,0} },
        { 符文之地Type.白骨荒原, new List<float>(){100,60,15,0,0,0,0,0} },
        { 符文之地Type.金戈壁, new List<float>(){100,80,20,3,0,0,0,0} },
        { 符文之地Type.幻梦泽, new List<float>(){0,100,30,5,0,0,0,0} },
        { 符文之地Type.混沌墟, new List<float>(){0,100,40,8,0,0,0,0} },
        { 符文之地Type.天道台, new List<float>(){0,0,50,12,1,0,0,0} },
    };

    private static QualityType 应用仙子掉落加成(QualityType quality)
    {
        if (Random.Range(0f, 100f) < 属性config.仙子总属性.宇品以上符文掉落概率)
        {
            if ((int)quality < (int)QualityType.宇品) quality = QualityType.宇品;
        }
        if (Random.Range(0f, 100f) < 属性config.仙子总属性.荒品符文掉落概率)
        {
            quality = QualityType.荒品;
        }
        return quality;
    }

    public static 符文 Get品质符文(QualityType quality)
    {
        quality = 应用仙子掉落加成(quality);
        符文 符文 = new 符文();
        符文.quality = quality;
        符文.type = (符文Type)Random.Range(1, Enum.GetValues(typeof(符文Type)).Length);
        minmax mm = 符文Config.Get符文minmax(符文.type, quality);
        符文.count = Random.Range(mm.min, mm.max);
        return 符文;
    }

    public static List<符文> Get符文之地掉落(符文之地Type type)
    {
        List<float> list=符文之地掉落概率Dic[type];
        List<符文> 符文列表 = new List<符文>();
        int index=0;
        foreach (var item in list)
        {
            float random=Random.Range(0f, 100f)/属性config.总掉宝率;
            if (random < item)
            {
                符文 符文 = new 符文();
                符文.quality = 应用仙子掉落加成((QualityType)(index + 1));
                符文.type = (符文Type)Random.Range(1, Enum.GetValues(typeof(符文Type)).Length);
                minmax mm = 符文Config.Get符文minmax(符文.type, 符文.quality);
                符文.count = Random.Range(mm.min, mm.max);
                符文列表.Add(符文);
            }
            index++;
        }
        return 符文列表;
    }
    
    
   
    
    public static Dictionary<符文之地关卡怪物Item, MonsterAttribute> 符文之地关卡怪物属性Dic = new Dictionary<符文之地关卡怪物Item, MonsterAttribute>()
    {
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.青木林, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Normal}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Normal}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Normal}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.青木林, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Elite}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Elite}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Elite}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.青木林, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Boss}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Boss}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.芭蕉洞,MonsterType = MonsterType.Boss}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        
        
        
        

        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.赤炎窟, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Normal}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Normal}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Normal}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.赤炎窟, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Elite}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Elite}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Elite}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.赤炎窟, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Boss}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Boss}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.冥府,MonsterType = MonsterType.Boss}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },



        
        
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.黑风谷, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Normal}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Normal}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Normal}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.黑风谷, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Elite}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Elite}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Elite}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.黑风谷, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Boss}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Boss}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.瑶池仙境,MonsterType = MonsterType.Boss}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },

        
        

        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.玄水深渊, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Normal}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Normal}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Normal}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.玄水深渊, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Elite}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Elite}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Elite}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.玄水深渊, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Boss}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Boss}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.御马监,MonsterType = MonsterType.Boss}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },

        
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.紫雷泽, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Normal}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Normal}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Normal}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.紫雷泽, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Elite}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Elite}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Elite}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.紫雷泽, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Boss}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Boss}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.兜率宫,MonsterType = MonsterType.Boss}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },


        
        
        
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.白骨荒原, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Normal}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Normal}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Normal}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.白骨荒原, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Elite}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Elite}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Elite}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.白骨荒原, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Boss}].Hp, Attack = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Boss}].Attack, Defense = MonsterConfig.主线关卡怪物属性Dic[new 主线关卡怪物Item(){主线关卡Type = 主线关卡Type.昊天殿,MonsterType = MonsterType.Boss}].Defense, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },

        
        
        
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.金戈壁, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Normal).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Normal).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Normal).Defense, 物理抗性 = 80, 冰霜抗性 = 80, 火焰抗性 = 80, 黑暗抗性 = 80, 雷电抗性 = 80 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.金戈壁, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Elite).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Elite).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Elite).Defense, 物理抗性 = 80, 冰霜抗性 = 80, 火焰抗性 = 80, 黑暗抗性 = 80, 雷电抗性 = 80 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.金戈壁, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Boss).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Boss).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(20,MonsterType.Boss).Defense, 物理抗性 = 80, 冰霜抗性 = 80, 火焰抗性 = 80, 黑暗抗性 = 80, 雷电抗性 = 80 }
        },

        
        
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.幻梦泽, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Normal).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Normal).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Normal).Defense, 物理抗性 = 85, 冰霜抗性 = 85, 火焰抗性 = 85, 黑暗抗性 = 85, 雷电抗性 = 85 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.幻梦泽, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Elite).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Elite).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Elite).Defense, 物理抗性 = 85, 冰霜抗性 = 85, 火焰抗性 = 85, 黑暗抗性 = 85, 雷电抗性 = 85 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.幻梦泽, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Boss).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Boss).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(100,MonsterType.Boss).Defense, 物理抗性 = 85, 冰霜抗性 = 85, 火焰抗性 = 85, 黑暗抗性 = 85, 雷电抗性 = 85 }
        },

        
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.混沌墟, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Normal).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Normal).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Normal).Defense, 物理抗性 = 90, 冰霜抗性 = 90, 火焰抗性 = 90, 黑暗抗性 = 90, 雷电抗性 = 90 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.混沌墟, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Elite).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Elite).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Elite).Defense, 物理抗性 = 90, 冰霜抗性 = 90, 火焰抗性 = 90, 黑暗抗性 = 90, 雷电抗性 = 90 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.混沌墟, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Boss).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Boss).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(300,MonsterType.Boss).Defense, 物理抗性 = 90, 冰霜抗性 = 90, 火焰抗性 = 90, 黑暗抗性 = 90, 雷电抗性 = 90 }
        },

        
        
        
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.天道台, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Normal).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Normal).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Normal).Defense, 物理抗性 = 95, 冰霜抗性 = 95, 火焰抗性 = 95, 黑暗抗性 = 95, 雷电抗性 = 95 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.天道台, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Elite).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Elite).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Elite).Defense, 物理抗性 = 95, 冰霜抗性 = 95, 火焰抗性 = 95, 黑暗抗性 = 95, 雷电抗性 = 95 }
        },
        {
            new 符文之地关卡怪物Item() { 符文之地Type = 符文之地Type.天道台, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Boss).Hp, Attack = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Boss).Attack, Defense = MonsterConfig.Get三十三重天怪物属性(1000,MonsterType.Boss).Defense, 物理抗性 = 95, 冰霜抗性 = 95, 火焰抗性 = 95, 黑暗抗性 = 95, 雷电抗性 = 95 }
        },
    };
    
    
    
    public static Dictionary<符文之地Type, HashSet<LevelDiaoLuo>> 符文之地掉落Dic =
    new Dictionary<符文之地Type, HashSet<LevelDiaoLuo>>()
    {
        {
            符文之地Type.青木林,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 1200, minCount = 1500, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.赤炎窟,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 1500, minCount = 2000, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.黑风谷,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 2000, minCount = 2600, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.玄水深渊,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 2600, minCount = 3400, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.紫雷泽,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 3400, minCount = 4400, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.白骨荒原,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 4400, minCount = 5600, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.金戈壁,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 5600, minCount = 7000, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.幻梦泽,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 7000, minCount = 8500, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.混沌墟,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 8500, minCount = 10000, PropType = PropType.灵魂 },
            }
        },
        {
            符文之地Type.天道台,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 10000, minCount = 12000, PropType = PropType.灵魂 },
            }
        },
    };
}
