using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 神物Type
{
    None,
    最终伤害,
    冷却缩减,
    全元素增伤,
    元素我为人人,
    元素人人为我,
    全职业增伤,
    职业我为人人,
    职业人人为我,
    暴击爆伤,
    二次暴击,
    轮回次数加伤,
    轮回系数,
    时间流速加快,
}

public class 遗迹关卡胜利奖励
{
    public long 灵魂;
    public long 功德;
    public bool 神物;
}

public class 遗迹关卡怪物Item
{
    public 神物Type 神物Type;
    public MonsterType MonsterType;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        
        遗迹关卡怪物Item other = (遗迹关卡怪物Item)obj;
        return 神物Type == other.神物Type && MonsterType == other.MonsterType;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + 神物Type.GetHashCode();
            hash = hash * 31 + MonsterType.GetHashCode();
            return hash;
        }
    }
}
public class 神物Config
{
    public static Dictionary<神物Type, string> 神物名Dic = new Dictionary<神物Type, string>()
    {
        { 神物Type.最终伤害, "无极灭世印" },
        { 神物Type.冷却缩减, "时序轮盘" },
        { 神物Type.全元素增伤, "五行混沌珠" },
        { 神物Type.元素人人为我, "噬灵珠" },
        { 神物Type.元素我为人人, "润泽珠" },
        { 神物Type.全职业增伤, "普渡莲" },
        { 神物Type.职业人人为我, "天枢汇星图" },
        { 神物Type.职业我为人人, "天璇分星图" },
        { 神物Type.暴击爆伤, "斩天刃" },
        { 神物Type.二次暴击, "归元葫" },
        { 神物Type.轮回次数加伤, "渡厄黄泉铃" },
        { 神物Type.轮回系数, "六道轮回盘" },
        { 神物Type.时间流速加快, "流光掠影梭" },
    };
    public static Dictionary<神物Type, float> 神物数值Dic = new Dictionary<神物Type, float>()
    {
        { 神物Type.最终伤害, 50 },
        { 神物Type.冷却缩减, 30 },
        { 神物Type.全元素增伤, 50 },
        { 神物Type.元素人人为我, 1 },
        { 神物Type.元素我为人人, 1 },
        { 神物Type.全职业增伤, 50 },
        { 神物Type.职业我为人人, 1 },
        { 神物Type.职业人人为我, 1 },
        { 神物Type.暴击爆伤, 50 },
        { 神物Type.二次暴击, 1 },
        { 神物Type.轮回次数加伤, 10 },
        { 神物Type.轮回系数, 1 },
        { 神物Type.时间流速加快, 20 },
    };

    public static 遗迹关卡胜利奖励 Get遗迹关卡奖励()
    {
        遗迹关卡胜利奖励 遗迹关卡胜利奖励 = new 遗迹关卡胜利奖励();
        var list = 遗迹掉落Dic[LevelConfig.当前神物Type];
        foreach (var item in list)
        {
            if (item.PropType == PropType.功德)
            {
                遗迹关卡胜利奖励.功德=LongRandom.Range(item.minCount, item.maxCount);
            }
            if (item.PropType == PropType.灵魂)
            {
                遗迹关卡胜利奖励.灵魂=LongRandom.Range(item.minCount, item.maxCount);
            }
        }
        float random=Random.Range(0f, 100f);
        遗迹关卡胜利奖励.神物 = random < 神物掉落概率Dic[LevelConfig.当前神物Type]*属性config.总掉宝率;
        return 遗迹关卡胜利奖励;
    }

    public static Dictionary<神物Type, SmallLevelInfo> 遗迹关卡信息Dic = new Dictionary<神物Type, SmallLevelInfo>()
    {
        {
            神物Type.最终伤害, new SmallLevelInfo() { NormalMonsterCount = 30, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.冷却缩减, new SmallLevelInfo() { NormalMonsterCount = 28, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.全元素增伤, new SmallLevelInfo() { NormalMonsterCount = 30, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.元素人人为我, new SmallLevelInfo() { NormalMonsterCount = 32, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.元素我为人人, new SmallLevelInfo() { NormalMonsterCount = 32, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.全职业增伤, new SmallLevelInfo() { NormalMonsterCount = 30, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.职业人人为我, new SmallLevelInfo() { NormalMonsterCount = 32, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.职业我为人人, new SmallLevelInfo() { NormalMonsterCount = 32, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.暴击爆伤, new SmallLevelInfo() { NormalMonsterCount = 25, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.二次暴击, new SmallLevelInfo() { NormalMonsterCount = 25, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.轮回次数加伤, new SmallLevelInfo() { NormalMonsterCount = 35, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.轮回系数, new SmallLevelInfo() { NormalMonsterCount = 35, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.时间流速加快, new SmallLevelInfo() { NormalMonsterCount = 30, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
    };
    public static Dictionary<神物Type, string> 神物descDic = new Dictionary<神物Type, string>()
    {
        { 神物Type.最终伤害, $"最终伤害+{神物数值Dic[神物Type.最终伤害]}%" },
        { 神物Type.冷却缩减,  $"英雄冷却缩减+{神物数值Dic[神物Type.冷却缩减]}%" },
        { 神物Type.全元素增伤,  $"所有元素伤害+{神物数值Dic[神物Type.全元素增伤]}%" },
        { 神物Type.元素人人为我,  $"最高的元素伤害增幅获得其他所有元素增幅之和" },
        { 神物Type.元素我为人人,  $"其他所有的元素伤害增幅获得最低的元素伤害增幅" },
        { 神物Type.全职业增伤,  $"所有职业伤害+{神物数值Dic[神物Type.全职业增伤]}" },
        { 神物Type.职业人人为我,  $"最高的职业伤害增幅获得其他所有职业增幅之和" },
        { 神物Type.职业我为人人,  $"其他所有的职业伤害增幅获得最低的职业伤害增幅" },
        { 神物Type.暴击爆伤,  $"暴击率+{神物数值Dic[神物Type.暴击爆伤]}%,暴击伤害+{神物数值Dic[神物Type.暴击爆伤]}%" },
        { 神物Type.二次暴击,  $"伤害可二次暴击,二次暴击率为暴击率/5" },
        { 神物Type.轮回次数加伤,  $"增加轮回次数X{神物数值Dic[神物Type.轮回次数加伤]}%的最终伤害" },
        { 神物Type.轮回系数,  $"轮回时跟脚保留+{神物数值Dic[神物Type.轮回系数]}%" },
        { 神物Type.时间流速加快,  $"时间流速加快{神物数值Dic[神物Type.时间流速加快]}%" },
    };
    public static Dictionary<神物Type, List<MonsterTypeName>> 遗迹怪物列表 = new Dictionary<神物Type, List<MonsterTypeName>>()
    {
        { 神物Type.最终伤害, new List<MonsterTypeName>(){ MonsterTypeName.石皮野猪, MonsterTypeName.铁羽麻雀, MonsterTypeName.裂蹄蛮牛, MonsterTypeName.风吼应龙 } },
        { 神物Type.冷却缩减, new List<MonsterTypeName>(){ MonsterTypeName.棘背豪猪, MonsterTypeName.赤眼乌鸦, MonsterTypeName.碎岩巨蜥, MonsterTypeName.雷翼飞廉 } },
        { 神物Type.全元素增伤, new List<MonsterTypeName>(){ MonsterTypeName.甲壳穿山, MonsterTypeName.毒牙田鼠, MonsterTypeName.震地巨蟾, MonsterTypeName.冰晶玄龟 } },
        { 神物Type.元素人人为我, new List<MonsterTypeName>(){ MonsterTypeName.骨刺刺猬, MonsterTypeName.火羽雉鸡, MonsterTypeName.熔岩巨蟒, MonsterTypeName.双首炎蟒 } },
        { 神物Type.元素我为人人, new List<MonsterTypeName>(){ MonsterTypeName.铜鳞鲤鱼, MonsterTypeName.铁爪鹰隼, MonsterTypeName.金刚巨猿, MonsterTypeName.紫电麒麟 } },
        { 神物Type.全职业增伤, new List<MonsterTypeName>(){ MonsterTypeName.青面狼妖, MonsterTypeName.赤尾狐精, MonsterTypeName.三眼毒蟾, MonsterTypeName.九尾天狐 } },
        { 神物Type.职业我为人人, new List<MonsterTypeName>(){ MonsterTypeName.黑风蛇妖, MonsterTypeName.金瞳猫妖, MonsterTypeName.四臂魔猿, MonsterTypeName.七首蛟龙 } },
        { 神物Type.职业人人为我, new List<MonsterTypeName>(){ MonsterTypeName.碧磷蝎精, MonsterTypeName.霜白蛛妖, MonsterTypeName.六翼蜈蚣, MonsterTypeName.八足火蛛 } },
        { 神物Type.暴击爆伤, new List<MonsterTypeName>(){ MonsterTypeName.黄沙鼠妖, MonsterTypeName.紫电貂精, MonsterTypeName.双头狼王, MonsterTypeName.金翅大鹏 } },
        { 神物Type.二次暴击, new List<MonsterTypeName>(){ MonsterTypeName.赤焰蚁精, MonsterTypeName.寒冰蝶妖, MonsterTypeName.五色毒蟾, MonsterTypeName.玄冥巨蟒 } },
        { 神物Type.轮回次数加伤, new List<MonsterTypeName>(){ MonsterTypeName.噬骨秃鹫, MonsterTypeName.腐肉豺狼, MonsterTypeName.血瞳巨人, MonsterTypeName.三头地狱犬 } },
        { 神物Type.轮回系数, new List<MonsterTypeName>(){ MonsterTypeName.丧魂幽灵, MonsterTypeName.碎骨骷髅, MonsterTypeName.尸煞尸王, MonsterTypeName.六臂夜叉 } },
        { 神物Type.时间流速加快, new List<MonsterTypeName>(){ MonsterTypeName.怨气怨灵, MonsterTypeName.诅咒木偶, MonsterTypeName.嗜血蝠王, MonsterTypeName.九婴凶蛇 } },
    };
    
    public static Dictionary<神物Type, float> 神物掉落概率Dic = new Dictionary<神物Type, float>()
    {
        { 神物Type.最终伤害, 3 },
        { 神物Type.冷却缩减, 3 },
        { 神物Type.全元素增伤, 3 },
        { 神物Type.元素人人为我, 1 },
        { 神物Type.元素我为人人, 1 },
        { 神物Type.全职业增伤, 3 },
        { 神物Type.职业我为人人, 1 },
        { 神物Type.职业人人为我, 1 },
        { 神物Type.暴击爆伤, 2 },
        { 神物Type.二次暴击, 0.5f },
        { 神物Type.轮回次数加伤, 1 },
        { 神物Type.轮回系数, 0.5f },
        { 神物Type.时间流速加快, 1 },
    };

    public static Dictionary<神物Type, HashSet<LevelDiaoLuo>> 遗迹掉落Dic =
    new Dictionary<神物Type, HashSet<LevelDiaoLuo>>()
    {
        {
            神物Type.最终伤害,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.功德 },
            }
        },
        {
            神物Type.冷却缩减,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 110, minCount = 90, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 90, minCount = 70, PropType = PropType.功德 },
            }
        },
        {
            神物Type.全元素增伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 115, minCount = 95, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 95, minCount = 75, PropType = PropType.功德 },
            }
        },
        {
            神物Type.元素人人为我,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 130, minCount = 110, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 110, minCount = 90, PropType = PropType.功德 },
            }
        },
        {
            神物Type.元素我为人人,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 130, minCount = 110, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 110, minCount = 90, PropType = PropType.功德 },
            }
        },
        {
            神物Type.全职业增伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 115, minCount = 95, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 95, minCount = 75, PropType = PropType.功德 },
            }
        },
        {
            神物Type.职业人人为我,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 130, minCount = 110, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 110, minCount = 90, PropType = PropType.功德 },
            }
        },
        {
            神物Type.职业我为人人,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 130, minCount = 110, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 110, minCount = 90, PropType = PropType.功德 },
            }
        },
        {
            神物Type.暴击爆伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 80, minCount = 60, PropType = PropType.功德 },
            }
        },
        {
            神物Type.二次暴击,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 80, minCount = 60, PropType = PropType.功德 },
            }
        },
        {
            神物Type.轮回次数加伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 140, minCount = 120, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.功德 },
            }
        },
        {
            神物Type.轮回系数,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 140, minCount = 120, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.功德 },
            }
        },
        {
            神物Type.时间流速加快,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 130, minCount = 110, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { maxCount = 110, minCount = 90, PropType = PropType.功德 },
            }
        },
    };

    
    public static Dictionary<遗迹关卡怪物Item, MonsterAttribute> 遗迹关卡怪物属性Dic = new Dictionary<遗迹关卡怪物Item, MonsterAttribute>()
    {
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.最终伤害, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.最终伤害, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 120, Attack = 15, Defense = 12, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.最终伤害, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 300, Attack = 35, Defense = 25, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.冷却缩减, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 55, Attack = 7, Defense = 4, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.冷却缩减, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 130, Attack = 16, Defense = 10, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.冷却缩减, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 320, Attack = 38, Defense = 22, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全元素增伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 45, Attack = 8, Defense = 3, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全元素增伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 110, Attack = 18, Defense = 8, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全元素增伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 280, Attack = 40, Defense = 20, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素人人为我, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 48, Attack = 5, Defense = 6, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素人人为我, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 115, Attack = 12, Defense = 14, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素人人为我, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 290, Attack = 30, Defense = 30, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素我为人人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 52, Attack = 7, Defense = 4, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素我为人人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 125, Attack = 16, Defense = 10, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素我为人人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 310, Attack = 36, Defense = 24, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全职业增伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 60, Attack = 9, Defense = 3, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全职业增伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 140, Attack = 20, Defense = 8, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全职业增伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 350, Attack = 45, Defense = 18, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业我为人人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 42, Attack = 10, Defense = 2, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业我为人人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 100, Attack = 22, Defense = 6, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业我为人人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 260, Attack = 50, Defense = 15, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业人人为我, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 58, Attack = 6, Defense = 7, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业人人为我, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 135, Attack = 14, Defense = 16, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业人人为我, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 330, Attack = 32, Defense = 35, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.暴击爆伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 40, Attack = 12, Defense = 2, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.暴击爆伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 95, Attack = 28, Defense = 5, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.暴击爆伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 240, Attack = 60, Defense = 12, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.二次暴击, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 38, Attack = 14, Defense = 1, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.二次暴击, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 90, Attack = 32, Defense = 4, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.二次暴击, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 220, Attack = 70, Defense = 10, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回次数加伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 70, Attack = 5, Defense = 8, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回次数加伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 160, Attack = 12, Defense = 18, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回次数加伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 400, Attack = 28, Defense = 40, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回系数, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 65, Attack = 4, Defense = 9, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回系数, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 150, Attack = 10, Defense = 20, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回系数, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 380, Attack = 25, Defense = 45, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.时间流速加快, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 35, Attack = 11, Defense = 3, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.时间流速加快, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 85, Attack = 25, Defense = 8, 物理抗性 = 5, 冰霜抗性 = 5, 火焰抗性 = 5, 黑暗抗性 = 5, 雷电抗性 = 5 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.时间流速加快, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 210, Attack = 55, Defense = 18, 物理抗性 = 15, 冰霜抗性 = 15, 火焰抗性 = 15, 黑暗抗性 = 15, 雷电抗性 = 15 }
        },
    };

}
