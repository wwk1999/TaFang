using System.Collections.Generic;
using Config;

public class 法则config
{
    public static Dictionary<HeroType, string> 法则名Dic = new Dictionary<HeroType, string>()
    {
        { HeroType.哪吒, "火之法则" },
        { HeroType.孙悟空, "斗之法则" },
        { HeroType.碧霄, "冰之法则" },
        { HeroType.琼霄, "禁之法则" },

        { HeroType.云霄, "剑之法则" },
        { HeroType.羲和, "日之法则" },
        { HeroType.常羲, "月之法则" },
        { HeroType.后羿, "箭之法则" },

        { HeroType.女娲, "造化法则" },
        { HeroType.元始, "原始法则" },
        { HeroType.通天, "诛仙法则" },
        { HeroType.老子, "道之法则" },

        { HeroType.鸿钧, "鸿蒙法则" },
        { HeroType.盘古, "力之法则" },
    };
    
    
    public static Dictionary<HeroType, PropType> 法则TypeDic = new Dictionary<HeroType, PropType>()
    {
        { HeroType.哪吒, PropType.火之法则 },
        { HeroType.孙悟空, PropType.斗之法则 },
        { HeroType.碧霄, PropType.冰之法则 },
        { HeroType.琼霄, PropType.禁之法则 },

        { HeroType.云霄, PropType.剑之法则 },
        { HeroType.羲和, PropType.日之法则 },
        { HeroType.常羲, PropType.月之法则 },
        { HeroType.后羿, PropType.箭之法则 },

        { HeroType.女娲, PropType.造化法则 },
        { HeroType.元始, PropType.原始法则 },
        { HeroType.通天, PropType.诛仙法则 },
        { HeroType.老子, PropType.道之法则 },

        { HeroType.鸿钧, PropType.鸿蒙法则 },
        { HeroType.盘古, PropType.力之法则 },
    };

    public static Dictionary<HeroType, string> 法则info = new Dictionary<HeroType, string>()
    {
        { HeroType.哪吒, "掌控三昧真火，焚尽世间污秽，于灰烬中涅槃重生。" },
        { HeroType.孙悟空, "战意不息，愈战愈勇，一棒破万法，斗天斗地斗自我。" },
        { HeroType.碧霄, "至阴至寒，冻结时空，削去仙神顶上三花，消融道行。" },
        { HeroType.琼霄, "混元封禁，困锁肉身，定住元神，万法难逃。" },
        { HeroType.云霄, "剑意通玄，诛仙剑阵化形，攻伐无双，无坚不摧。" },
        { HeroType.羲和, "大日真火，阳极之精，普照万物，亦可焚天煮海。" },
        { HeroType.常羲, "太阴之力，潮汐盈亏，蚀骨销魂，掌控月之阴晴圆缺。" },
        { HeroType.后羿, "射日神箭，因果锁定，贯穿时空，箭出必中，绝无虚发。" },
        { HeroType.女娲, "造化之道，抟土造人，炼石补天，创生万物，修复规则。" },
        { HeroType.元始, "万物之始，混沌初开，鸿蒙紫气，乃万法本源之源头。" },
        { HeroType.通天, "诛仙杀伐，非铜非铁，剑阵临世，戮神屠仙，洪荒第一杀道。" },
        { HeroType.老子, "无为大道，顺应自然，清静玄妙，万法归宗，返璞归真。" },
        { HeroType.鸿钧, "天道化身，万道之源，鸿蒙初判，同化一切，归于无极。" },
        { HeroType.盘古, "力之极致，一力降十会，开天辟地，破碎虚空，力破万法。" }
    };

    public static Dictionary<HeroType, List<string>> 法则升级info = new Dictionary<HeroType, List<string>>()
    {
        {
            HeroType.哪吒, new List<string>()
            {
                "效果范围增大<color=green>5%</color>",
                "效果范围增大<color=green>10%</color>",
                "效果范围增大<color=green>15%</color>",
                "效果范围增大<color=green>20%</color>",
                "效果范围增大<color=green>25%</color>"
            }
        },
        {
            HeroType.碧霄, new List<string>()
            {
                "冷却缩减增加<color=green>5%</color>",
                "效果范围增大<color=green>10%</color>",
                "冷却缩减增加<color=green>15%</color>",
                "效果范围增大<color=green>20%</color>",
                "冷却缩减增加<color=green>25%</color>"
            }
        },
        {
            HeroType.琼霄, new List<string>()
            {
                "定身时间增加<color=green>0.1S</color>",
                "定身时间增加<color=green>0.2S</color>",
                "定身时间增加<color=green>0.3S</color>",
                "定身时间增加<color=green>0.4S</color>",
                "定身时间增加<color=green>0.5S</color>",
            }
        },
        {
            HeroType.孙悟空, new List<string>()
            {
                "每次下场增加<color=green>1%</color>伤害",
                "每次下场增加<color=green>1.25%</color>伤害",
                "每次下场增加<color=green>1.5%</color>伤害",
                "每次下场增加<color=green>1.75%</color>伤害",
                "每次下场增加<color=green>2%</color>伤害",
            }
        },
        
        
        {
            HeroType.云霄, new List<string>()
            {
                "冷却缩减增加<color=green>5%</color>",
                "冷却缩减增加<color=green>10%</color>",
                "冷却缩减增加<color=green>15%</color>",
                "冷却缩减增加<color=green>20%</color>",
                "冷却缩减增加<color=green>25%</color>",
            }
        },
        
        {
            HeroType.后羿, new List<string>()
            {
                "连射概率增加<color=green>3%</color>",
                "连射概率增加<color=green>6%</color>",
                "连射概率增加<color=green>9%</color>",
                "连射概率增加<color=green>12%</color>",
                "连射概率增加<color=green>15%</color>",
            }
        },
        
        {
            HeroType.羲和, new List<string>()
            {
                "灼烧每次可叠加<color=green>10%</color>伤害",
                "灼烧每次可叠加<color=green>15%</color>伤害",
                "灼烧每次可叠加<color=green>20%</color>伤害",
                "灼烧每次可叠加<color=green>25%</color>伤害",
                "灼烧每次可叠加<color=green>30%</color>伤害",
            }
        },
        
        {
            HeroType.常羲, new List<string>()
            {
                "减速效果增加<color=green>3%</color>",
                "减速效果增加<color=green>6%</color>",
                "减速效果增加<color=green>9%</color>",
                "减速效果增加<color=green>12%</color>",
                "减速效果增加<color=green>15%</color>",
            }
        },
        
        {
            HeroType.女娲, new List<string>()
            {
                "被施法英雄伤害增加<color=green>3%</color>",
                "被施法英雄伤害增加<color=green>6%</color>",
                "被施法英雄伤害增加<color=green>9%</color>",
                "被施法英雄伤害增加<color=green>12%</color>",
                "被施法英雄伤害增加<color=green>15%</color>",
            }
        },
        
        {
            HeroType.元始, new List<string>()
            {
                "鸿蒙火种转速增加<color=green>5%</color>,体积增大<color=green>5%</color>",
                "鸿蒙火种转速增加<color=green>10%</color>,体积增大<color=green>10%</color>",
                "鸿蒙火种转速增加<color=green>15%</color>,体积增大<color=green>15%</color>",
                "鸿蒙火种转速增加<color=green>20%</color>,体积增大<color=green>20%</color>",
                "鸿蒙火种数量增加<color=green>1</color>",
            }
        },
        
        {
            HeroType.老子, new List<string>()
            {
                "太清玄冰风增大速度增加<color=green>1%</color>",
                "太清玄冰风增大速度增加<color=green>2%</color>",
                "太清玄冰风增大速度增加<color=green>3%</color>",
                "太清玄冰风增大速度增加<color=green>4%</color>",
                "太清玄冰风增大速度增加<color=green>5%</color>",
            }
        },
        
        {
            HeroType.通天, new List<string>()
            {
                "冷却缩减增加<color=green>5%</color>,暴击率增加<color=green>3%</color>",
                "冷却缩减增加<color=green>10%</color>,暴击率增加<color=green>6%</color>",
                "冷却缩减增加<color=green>15%</color>,暴击率增加<color=green>9%</color>",
                "冷却缩减增加<color=green>20%</color>,暴击率增加<color=green>12%</color>",
                "冷却缩减增加<color=green>25%</color>,暴击率增加<color=green>15%</color>",
            }
        },
        
        {
            HeroType.鸿钧, new List<string>()
            {
                "无极天火冷却缩减增加<color=green>5%</color>,数量增加<color=green>1</color>",
                "无极天火冷却缩减增加<color=green>10%</color>,数量增加<color=green>1</color>",
                "无极天火冷却缩减增加<color=green>15%</color>,数量增加<color=green>1</color>",
                "无极天火冷却缩减增加<color=green>20%</color>,数量增加<color=green>1</color>",
                "无极天火冷却缩减增加<color=green>25%</color>,数量增加<color=green>1</color>",
            }
        },
        
        {
            HeroType.盘古, new List<string>()
            {
                "混沌开天拳每次出拳增加<color=green>1%</color>伤害,出拳次数增加<color=green>1</color>",
                "混沌开天拳每次出拳增加<color=green>1.25%</color>伤害,出拳次数增加<color=green>1</color>",
                "混沌开天拳每次出拳增加<color=green>1.5%</color>伤害,出拳次数增加<color=green>1</color>",
                "混沌开天拳每次出拳增加<color=green>1.75%</color>伤害,出拳次数增加<color=green>1</color>",
                "混沌开天拳每次出拳增加<color=green>2%</color>伤害,出拳次数增加<color=green>1</color>",
            }
        },
    };

    public static Dictionary<QualityType, float> 法则升级奖励Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.宇品 ,1f},
        { QualityType.宙品 ,1.5f},
        { QualityType.洪品 ,2f},
        { QualityType.荒品 ,3f},
    };

    public static Dictionary<int, int> 法则升级材料Dic = new Dictionary<int, int>()
    {
        {0,10},
        {1,10},
        {2,10},
        {3,10},
        {4,10},
        
        {5,15},
        {6,15},
        {7,15},
        {8,15},
        {9,15},
        
        {10,20},
        {11,20},
        {12,20},
        {13,20},
        {14,20},
        
        {15,25},
        {16,25},
        {17,25},
        {18,25},
        {19,25},
        
        {20,30},
        {21,30},
        {22,30},
        {23,30},
        {24,30},
    };
}
