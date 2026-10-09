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
        { 神物Type.最终伤害, 80 },
        { 神物Type.冷却缩减, 40 },
        { 神物Type.全元素增伤, 80 },
        { 神物Type.元素人人为我, 1 },
        { 神物Type.元素我为人人, 1 },
        { 神物Type.全职业增伤, 80 },
        { 神物Type.职业我为人人, 1 },
        { 神物Type.职业人人为我, 1 },
        { 神物Type.暴击爆伤, 60 },
        { 神物Type.二次暴击, 1 },
        { 神物Type.轮回次数加伤, 10 },
        { 神物Type.轮回系数, 1 },
        { 神物Type.时间流速加快, 30 },
    };

    public static 遗迹关卡胜利奖励 Get遗迹关卡奖励()
    {
        遗迹关卡胜利奖励 遗迹关卡胜利奖励 = new 遗迹关卡胜利奖励();
        var list = 遗迹掉落Dic[LevelConfig.当前神物Type];
        foreach (var item in list)
        {
            if (item.PropType == PropType.灵魂)
            {
                遗迹关卡胜利奖励.灵魂=(long)Random.Range(item.minCount, item.maxCount);
            }
        }
        float random=Random.Range(0f, 100f);
        遗迹关卡胜利奖励.神物 = random < 神物掉落概率Dic[LevelConfig.当前神物Type]*属性config.总掉宝率;
        return 遗迹关卡胜利奖励;
    }

    public static Dictionary<神物Type, SmallLevelInfo> 遗迹关卡信息Dic = new Dictionary<神物Type, SmallLevelInfo>()
    {
        {
            神物Type.最终伤害, new SmallLevelInfo() { NormalMonsterCount = 200, CreateNormalMonsterTime = 0.5f, EliteMonsterCount = 1 }
        },
        {
            神物Type.冷却缩减, new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.45f, EliteMonsterCount = 1 }
        },
        {
            神物Type.全元素增伤, new SmallLevelInfo() { NormalMonsterCount = 300, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 1 }
        },
        {
            神物Type.元素人人为我, new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.35f, EliteMonsterCount = 2 }
        },
        {
            神物Type.元素我为人人, new SmallLevelInfo() { NormalMonsterCount = 300, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.全职业增伤, new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.职业人人为我, new SmallLevelInfo() { NormalMonsterCount = 400, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.职业我为人人, new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.暴击爆伤, new SmallLevelInfo() { NormalMonsterCount = 500, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.二次暴击, new SmallLevelInfo() { NormalMonsterCount = 550, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 1 }
        },
        {
            神物Type.轮回次数加伤, new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.轮回系数, new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
        {
            神物Type.时间流速加快, new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 2 }
        },
    };
    public static Dictionary<神物Type, string> 神物descDic = new Dictionary<神物Type, string>()
    {
        { 神物Type.最终伤害, $"最终伤害+{神物数值Dic[神物Type.最终伤害]}%,背包自动生效" },
        { 神物Type.冷却缩减,  $"英雄冷却缩减+{神物数值Dic[神物Type.冷却缩减]}%,背包自动生效" },
        { 神物Type.全元素增伤,  $"所有元素伤害+{神物数值Dic[神物Type.全元素增伤]}%,背包自动生效" },
        { 神物Type.元素人人为我,  $"最高的元素伤害增幅获得其他所有元素增幅之和,但其他所有元素增幅设为0,在设置可以关闭" },
        { 神物Type.元素我为人人,  $"其他所有的元素伤害增幅获得最低的元素伤害增幅,背包自动生效" },
        { 神物Type.全职业增伤,  $"所有职业伤害+{神物数值Dic[神物Type.全职业增伤]}%,背包自动生效" },
        { 神物Type.职业人人为我,  $"最高的职业伤害增幅获得其他所有职业增幅之和,但其他所有职业增幅设为0,在设置可以关闭" },
        { 神物Type.职业我为人人,  $"其他所有的职业伤害增幅获得最低的职业伤害增幅,背包自动生效" },
        { 神物Type.暴击爆伤,  $"暴击率+{神物数值Dic[神物Type.暴击爆伤]}%,暴击伤害+{神物数值Dic[神物Type.暴击爆伤]}%,背包自动生效" },
        { 神物Type.二次暴击,  $"伤害可二次暴击,二次暴击率为暴击率/5,背包自动生效" },
        { 神物Type.轮回次数加伤,  $"增加轮回次数X{神物数值Dic[神物Type.轮回次数加伤]}%的最终伤害,背包自动生效" },
        { 神物Type.轮回系数,  $"轮回时跟脚保留+{神物数值Dic[神物Type.轮回系数]}%,背包自动生效" },
        { 神物Type.时间流速加快,  $"时间流速加快{神物数值Dic[神物Type.时间流速加快]}%,背包自动生效" },
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
        { 神物Type.最终伤害, 2f },
        { 神物Type.冷却缩减, 2f },
        { 神物Type.全元素增伤, 2f },
        { 神物Type.元素人人为我, 1 },
        { 神物Type.元素我为人人, 1 },
        { 神物Type.全职业增伤, 1 },
        { 神物Type.职业我为人人, 1f },
        { 神物Type.职业人人为我, 1f },
        { 神物Type.暴击爆伤, 1f },
        { 神物Type.二次暴击, 0.4f },
        { 神物Type.轮回次数加伤, 0.4f },
        { 神物Type.轮回系数, 0.3f },
        { 神物Type.时间流速加快, 0.1f },
    };

    public static Dictionary<神物Type, HashSet<LevelDiaoLuo>> 遗迹掉落Dic =
    new Dictionary<神物Type, HashSet<LevelDiaoLuo>>()
    {
        {
            神物Type.最终伤害,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 1000, minCount = 1000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.冷却缩减,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 1300, minCount = 1000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.全元素增伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 1600, minCount = 1300, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.元素人人为我,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 2000, minCount = 1600, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.元素我为人人,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 2500, minCount = 2000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.全职业增伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 3000, minCount = 2500, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.职业人人为我,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 3800, minCount = 3000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.职业我为人人,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 4800, minCount = 3800, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.暴击爆伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 6000, minCount = 5000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.二次暴击,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 7000, minCount = 6000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.轮回次数加伤,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.轮回系数,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 9500, minCount = 8000, PropType = PropType.灵魂 },
            }
        },
        {
            神物Type.时间流速加快,
            new HashSet<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.灵魂 },
            }
        },
    };

    
    public static Dictionary<遗迹关卡怪物Item, MonsterAttribute> 遗迹关卡怪物属性Dic = new Dictionary<遗迹关卡怪物Item, MonsterAttribute>()
    {
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.最终伤害, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 300000, Attack = 1000, Defense = 500, 物理抗性 = 20, 冰霜抗性 = 20, 火焰抗性 = 20, 黑暗抗性 = 20, 雷电抗性 = 20 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.最终伤害, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3000000, Attack = 1500, Defense = 800, 物理抗性 = 20, 冰霜抗性 = 20, 火焰抗性 = 20, 黑暗抗性 = 20, 雷电抗性 = 20 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.最终伤害, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 30000000, Attack = 4000, Defense = 1500, 物理抗性 = 20, 冰霜抗性 = 20, 火焰抗性 = 20, 黑暗抗性 = 20, 雷电抗性 = 20 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.冷却缩减, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3000000, Attack = 2000, Defense = 1000, 物理抗性 = 30, 冰霜抗性 = 30, 火焰抗性 = 30, 黑暗抗性 = 30, 雷电抗性 = 30 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.冷却缩减, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 30000000, Attack = 3000, Defense = 1500, 物理抗性 = 30, 冰霜抗性 = 30, 火焰抗性 = 30, 黑暗抗性 = 30, 雷电抗性 = 30 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.冷却缩减, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 300000000, Attack = 8000, Defense = 3000, 物理抗性 = 30, 冰霜抗性 = 30, 火焰抗性 = 30, 黑暗抗性 = 30, 雷电抗性 = 30 }
        },

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全元素增伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e7f, Attack = 5000, Defense = 2000, 物理抗性 = 40, 冰霜抗性 = 40, 火焰抗性 = 40, 黑暗抗性 = 40, 雷电抗性 = 40 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全元素增伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e8f, Attack = 10000, Defense = 3000, 物理抗性 = 40, 冰霜抗性 = 40, 火焰抗性 = 40, 黑暗抗性 = 40, 雷电抗性 = 40 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全元素增伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e9f, Attack = 20000, Defense = 6000, 物理抗性 = 40, 冰霜抗性 = 40, 火焰抗性 = 40, 黑暗抗性 = 40, 雷电抗性 = 40 }
        },
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素我为人人, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e8f, Attack = 10000, Defense = 4000, 物理抗性 = 50, 冰霜抗性 = 50, 火焰抗性 = 50, 黑暗抗性 = 50, 雷电抗性 = 50 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素我为人人, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e9f, Attack = 20000, Defense = 6000, 物理抗性 = 50, 冰霜抗性 = 50, 火焰抗性 = 50, 黑暗抗性 = 50, 雷电抗性 = 50 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素我为人人, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e10f, Attack = 40000, Defense = 8000, 物理抗性 = 50, 冰霜抗性 = 50, 火焰抗性 = 50, 黑暗抗性 = 50, 雷电抗性 = 50 }
        },
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素人人为我, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e9f, Attack = 20000, Defense = 8000, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素人人为我, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e10f, Attack = 40000, Defense = 12000, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.元素人人为我, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e11f, Attack = 80000, Defense = 16000, 物理抗性 = 60, 冰霜抗性 = 60, 火焰抗性 = 60, 黑暗抗性 = 60, 雷电抗性 = 60 }
        },
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全职业增伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e10f, Attack = 40000, Defense = 16000, 物理抗性 = 65, 冰霜抗性 = 65, 火焰抗性 = 65, 黑暗抗性 = 65, 雷电抗性 = 65 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全职业增伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e11f, Attack = 80000, Defense = 24000, 物理抗性 = 65, 冰霜抗性 = 65, 火焰抗性 = 65, 黑暗抗性 = 65, 雷电抗性 = 65 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.全职业增伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e12f, Attack = 160000, Defense = 32000, 物理抗性 = 65, 冰霜抗性 = 65, 火焰抗性 = 65, 黑暗抗性 = 65, 雷电抗性 = 65 }
        },
        
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业我为人人, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e11f, Attack = 80000, Defense = 32000, 物理抗性 = 70, 冰霜抗性 = 70, 火焰抗性 = 70, 黑暗抗性 = 70, 雷电抗性 = 70 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业我为人人, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e12f, Attack = 160000, Defense = 48000, 物理抗性 = 70, 冰霜抗性 = 70, 火焰抗性 = 70, 黑暗抗性 = 70, 雷电抗性 = 70 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业我为人人, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e13f, Attack = 320000, Defense = 64000, 物理抗性 = 70, 冰霜抗性 = 70, 火焰抗性 = 70, 黑暗抗性 = 70, 雷电抗性 = 70 }
        },
        
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业人人为我, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e12f, Attack = 80000, Defense = 64000, 物理抗性 = 75, 冰霜抗性 = 75, 火焰抗性 = 75, 黑暗抗性 = 75, 雷电抗性 = 75 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业人人为我, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e13f, Attack = 160000, Defense = 96000, 物理抗性 = 75, 冰霜抗性 = 75, 火焰抗性 = 75, 黑暗抗性 = 75, 雷电抗性 = 75 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.职业人人为我, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e14f, Attack = 320000, Defense = 128000, 物理抗性 = 75, 冰霜抗性 = 75, 火焰抗性 = 75, 黑暗抗性 = 75, 雷电抗性 = 75 }
        },
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.暴击爆伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e13f, Attack = 160000, Defense = 100000, 物理抗性 = 80, 冰霜抗性 = 80, 火焰抗性 = 80, 黑暗抗性 = 80, 雷电抗性 = 80 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.暴击爆伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e14f, Attack = 300000, Defense = 200000, 物理抗性 = 80, 冰霜抗性 = 80, 火焰抗性 = 80, 黑暗抗性 = 80, 雷电抗性 = 80 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.暴击爆伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e15f, Attack = 600000, Defense = 400000, 物理抗性 = 80, 冰霜抗性 = 80, 火焰抗性 = 80, 黑暗抗性 = 80, 雷电抗性 = 80 }
        },
        
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.二次暴击, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e14f, Attack = 400000, Defense = 200000, 物理抗性 = 83, 冰霜抗性 = 83, 火焰抗性 = 83, 黑暗抗性 = 83, 雷电抗性 = 83 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.二次暴击, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e15f, Attack = 600000, Defense = 400000, 物理抗性 = 83, 冰霜抗性 = 83, 火焰抗性 = 83, 黑暗抗性 = 83, 雷电抗性 = 83 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.二次暴击, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e16f, Attack = 800000, Defense = 800000, 物理抗性 = 83, 冰霜抗性 = 83, 火焰抗性 = 83, 黑暗抗性 = 83, 雷电抗性 = 83 }
        },

        
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回次数加伤, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e15f, Attack = 800000, Defense = 400000, 物理抗性 = 86, 冰霜抗性 = 86, 火焰抗性 = 86, 黑暗抗性 = 86, 雷电抗性 = 86 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回次数加伤, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e16f, Attack = 1200000, Defense = 800000, 物理抗性 = 86, 冰霜抗性 = 86, 火焰抗性 = 86, 黑暗抗性 = 86, 雷电抗性 = 86 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回次数加伤, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e17f, Attack = 1600000, Defense = 1600000, 物理抗性 = 86, 冰霜抗性 = 86, 火焰抗性 = 86, 黑暗抗性 = 86, 雷电抗性 = 86 }
        },
        
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回系数, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e16f, Attack = 1600000, Defense = 800000, 物理抗性 = 89, 冰霜抗性 = 89, 火焰抗性 = 89, 黑暗抗性 = 89, 雷电抗性 = 89 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回系数, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e17f, Attack = 2000000, Defense = 1600000, 物理抗性 = 89, 冰霜抗性 = 89, 火焰抗性 = 89, 黑暗抗性 = 89, 雷电抗性 = 89 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.轮回系数, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e18f, Attack = 4000000, Defense = 3200000, 物理抗性 = 89, 冰霜抗性 = 89, 火焰抗性 = 89, 黑暗抗性 = 89, 雷电抗性 = 89 }
        },
        
        
        

        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.时间流速加快, MonsterType = MonsterType.Normal },
            new MonsterAttribute() { Hp = 3e17f, Attack = 3200000, Defense = 1600000, 物理抗性 = 92, 冰霜抗性 = 92, 火焰抗性 = 92, 黑暗抗性 = 92, 雷电抗性 = 92 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.时间流速加快, MonsterType = MonsterType.Elite },
            new MonsterAttribute() { Hp = 3e18f, Attack = 4000000, Defense = 3200000, 物理抗性 = 92, 冰霜抗性 = 92, 火焰抗性 = 92, 黑暗抗性 = 92, 雷电抗性 = 92 }
        },
        {
            new 遗迹关卡怪物Item() { 神物Type = 神物Type.时间流速加快, MonsterType = MonsterType.Boss },
            new MonsterAttribute() { Hp = 3e19f, Attack = 8000000, Defense = 6400000, 物理抗性 = 92, 冰霜抗性 = 92, 火焰抗性 = 92, 黑暗抗性 = 92, 雷电抗性 = 92 }
        },
    };

}
