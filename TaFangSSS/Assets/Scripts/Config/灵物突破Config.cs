using System.Collections.Generic;
using Config;

public class 洞天怪物Item
{
    public JingJieType JingJieType { get; set; }

    public MonsterType MonsterType { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        洞天怪物Item other = (洞天怪物Item)obj;
        return JingJieType == other.JingJieType && MonsterType == other.MonsterType;
    }

    // Dictionary 查找时必须先通过 GetHashCode() 定位桶，再用 Equals() 比较；
    // 只重写 Equals 不重写 GetHashCode 会导致值相同的两个 new 对象哈希不同，
    // Dictionary 认为是不同 Key，抛 KeyNotFoundException。
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + JingJieType.GetHashCode();
            hash = hash * 31 + MonsterType.GetHashCode();
            return hash;
        }
    }
}

public class 洞天关卡Item
{
    public JingJieType JingJieType { get; set; }

    public QualityType qualityType { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        洞天关卡Item other = (洞天关卡Item)obj;
        return JingJieType == other.JingJieType && qualityType == other.qualityType;
    }

    // 同上：GetHashCode 必须与 Equals 保持一致，使用同样的字段做哈希。
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + JingJieType.GetHashCode();
            hash = hash * 31 + qualityType.GetHashCode();
            return hash;
        }
    }
}

public class 灵物突破Config
{
    public static Dictionary<洞天怪物Item, MonsterAttribute> 洞天怪物属性Dic = new Dictionary<洞天怪物Item, MonsterAttribute>()
    {
        {
            new 洞天怪物Item() { JingJieType = JingJieType.练气, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.练气, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.练气, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },



        {
            new 洞天怪物Item() { JingJieType = JingJieType.筑基, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.筑基, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.筑基, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.金丹, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.金丹, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.金丹, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.元婴, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.元婴, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.元婴, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.化神, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.化神, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.化神, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.合体, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.合体, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.合体, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.大乘, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.大乘, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.大乘, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.天仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.天仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.天仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.玄仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.玄仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.玄仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.金仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.金仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.金仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },



        {
            new 洞天怪物Item() { JingJieType = JingJieType.太乙金仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.太乙金仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.太乙金仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.大罗金仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.大罗金仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.大罗金仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.准圣, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.准圣, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.准圣, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.圣人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },




        {
            new 洞天怪物Item() { JingJieType = JingJieType.天道圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.天道圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.天道圣人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },




        {
            new 洞天怪物Item() { JingJieType = JingJieType.大道圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.大道圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.大道圣人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },


        {
            new 洞天怪物Item() { JingJieType = JingJieType.混元圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.混元圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { JingJieType = JingJieType.混元圣人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
    };

    public static Dictionary<QualityType, float> 洞天品质倍数Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 1 },
        { QualityType.玄品, 3 },
        { QualityType.地品, 10 },
        { QualityType.天品, 50 },
        { QualityType.宇品, 300 },
        { QualityType.宙品, 3000 },
        { QualityType.洪品, 80000 },
        { QualityType.荒品, 3000000 },
    };

    public static Dictionary<JingJieType, string> 突破灵物名Dic = new Dictionary<JingJieType, string>()
    {
        { JingJieType.练气, "筑基果" },
        { JingJieType.筑基, "凝气草" },
        { JingJieType.金丹, "空冥石" },
        { JingJieType.元婴, "虚空尘" },
        { JingJieType.化神, "月华晶" },
        { JingJieType.合体, "琉璃珠" },
        { JingJieType.大乘, "天一水" },
        { JingJieType.天仙, "神府液" },
        { JingJieType.玄仙, "天青石" },
        { JingJieType.金仙, "造化果" },
        { JingJieType.太乙金仙, "玄黄母气" },
        { JingJieType.大罗金仙, "宇宙尘" },
        { JingJieType.准圣, "鸿蒙紫气" },
        { JingJieType.圣人, "轮回沙" },
        { JingJieType.天道圣人, "太初本源" },
        { JingJieType.大道圣人, "涅槃莲心" },
        { JingJieType.混元圣人, "混沌石" },
    };

    public static Dictionary<洞天关卡Item, List<LevelDiaoLuo>> 洞天普通掉落Dic =
        new Dictionary<洞天关卡Item, List<LevelDiaoLuo>>()
        {
            // ==================== 练气 ====================
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100, minCount = 150, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 80, minCount = 100, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 150, minCount = 200, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 120, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200, minCount = 300, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 150, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 300, minCount = 500, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 200, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500, minCount = 1000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 300, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 2000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 500, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 1000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 2000, PropType = PropType.功德 },
                }
            },

            // ==================== 筑基 ====================
            // 筑基黄品 = 练气地品 (200-300, 120-150) ✓
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200, minCount = 300, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 150, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 300, minCount = 500, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 200, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500, minCount = 1000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 300, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 2000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 500, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 1000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 2000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.功德 },
                }
            },

            // ==================== 金丹 ====================
            // 金丹黄品 = 筑基地品 (500-1000, 200-300)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500, minCount = 1000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 300, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 2000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 500, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 1000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 2000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.功德 },
                }
            },

            // ==================== 元婴 ====================
            // 元婴黄品 = 金丹地品 (2000-5000, 500-1000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500, minCount = 1000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 2000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.功德 },
                }
            },

            // ==================== 化神 ====================
            // 化神黄品 = 元婴地品 (10000-20000, 2000-5000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 5000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 10000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.功德 },
                }
            },

            // ==================== 合体 ====================
            // 合体黄品 = 化神地品 (50000-100000, 10000-20000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 20000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 50000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.功德 },
                }
            },

            // ==================== 大乘 ====================
            // 大乘黄品 = 合体地品 (200000-500000, 50000-100000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000, minCount = 100000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000, minCount = 200000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.功德 },
                }
            },

            // ==================== 天仙 ====================
            // 天仙黄品 = 大乘地品 (1000000-2000000, 200000-500000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000, minCount = 500000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000, minCount = 1000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.功德 },
                }
            },

            // ==================== 玄仙 ====================
            // 玄仙黄品 = 天仙地品 (5000000-10000000, 1000000-2000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000, minCount = 2000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000, minCount = 5000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.功德 },
                }
            },

            // ==================== 金仙 ====================
            // 金仙黄品 = 玄仙地品 (20000000-50000000, 5000000-10000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000, minCount = 10000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000, minCount = 20000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.功德 },
                }
            },

            // ==================== 太乙金仙 ====================
            // 太乙金仙黄品 = 金仙地品 (100000000-200000000, 20000000-50000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000, minCount = 50000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000, minCount = 100000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.功德 },
                }
            },

            // ==================== 大罗金仙 ====================
            // 大罗金仙黄品 = 太乙金仙地品 (500000000-1000000000, 100000000-200000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000, minCount = 200000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000, minCount = 500000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.功德 },
                }
            },

            // ==================== 准圣 ====================
            // 准圣黄品 = 大罗金仙地品 (2000000000-5000000000, 500000000-1000000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000, minCount = 1000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000000, minCount = 2000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.功德 },
                }
            },

            // ==================== 圣人 ====================
            // 圣人黄品 = 准圣地品 (10000000000-20000000000, 2000000000-5000000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000000, minCount = 5000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000000, minCount = 10000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000000, minCount = 2000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000000, minCount = 5000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.功德 },
                }
            },

            // ==================== 天道圣人 ====================
            // 天道圣人黄品 = 圣人的地品 (50000000000-100000000000, 10000000000-20000000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000000, minCount = 20000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000000, minCount = 50000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000000, minCount = 2000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000000, minCount = 5000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000000000, minCount = 10000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000000000, minCount = 2000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000000000, minCount = 20000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000000000, minCount = 5000000000000, PropType = PropType.功德 },
                }
            },

            // ==================== 大道圣人 ====================
            // 大道圣人黄品 = 天道圣人的地品 (200000000000-500000000000, 50000000000-100000000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000000, minCount = 100000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100000000000, minCount = 200000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000000, minCount = 2000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000000, minCount = 5000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000000000, minCount = 10000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000000000, minCount = 2000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000000000, minCount = 20000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000000000, minCount = 5000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000000000, minCount = 50000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000000000, minCount = 10000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000000000, minCount = 100000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000000000, minCount = 20000000000000, PropType = PropType.功德 },
                }
            },

            // ==================== 混元圣人 ====================
            // 混元圣人黄品 = 大道圣人的地品 (1000000000000-2000000000000, 200000000000-500000000000)
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.黄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000000000000, minCount = 2000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200000000000, minCount = 500000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.玄品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000000000000, minCount = 5000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 500000000000, minCount = 1000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.地品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000000000000, minCount = 10000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1000000000000, minCount = 2000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.天品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000000000000, minCount = 20000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2000000000000, minCount = 5000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.宇品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000000000000, minCount = 50000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000000000000, minCount = 10000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.宙品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 50000000000000, minCount = 100000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000000000000, minCount = 20000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.洪品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 100000000000000, minCount = 200000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 20000000000000, minCount = 50000000000000, PropType = PropType.功德 },
                }
            },
            {
                new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.荒品 },
                new List<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200000000000000, minCount = 500000000000000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 50000000000000, minCount = 100000000000000, PropType = PropType.功德 },
                }
            },
        };

    public static Dictionary<QualityType, List<float>> 灵物掉落概率Dic = new Dictionary<QualityType, List<float>>()
    {
        { QualityType.黄品, new List<float>() { 50, 0, 0, 0, 0, 0, 0, 0 } },
        { QualityType.玄品, new List<float>() { 70, 30, 0, 0, 0, 0, 0, 0 } },
        { QualityType.地品, new List<float>() { 35, 50, 25, 0, 0, 0, 0, 0 } },
        { QualityType.天品, new List<float>() { 10, 30, 40, 20, 0, 0, 0, 0 } },
        { QualityType.宇品, new List<float>() { 0, 15, 40, 30, 15, 0, 0, 0 } },
        { QualityType.宙品, new List<float>() { 0, 10, 25, 30, 25, 10, 0, 0 } },
        { QualityType.洪品, new List<float>() { 0, 0, 10, 25, 40, 20, 5, 0 } },
        { QualityType.荒品, new List<float>() { 0, 0, 0, 14, 40, 30, 15, 1 } },
    };
}
