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

public class 灵物item
{
    public JingJieType JingJieType;
    public QualityType QualityType;
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
                new LevelDiaoLuo() { minCount = 100, maxCount = 150, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 80, maxCount = 100, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 150, maxCount = 200, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100, maxCount = 120, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200, maxCount = 300, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 120, maxCount = 150, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 300, maxCount = 500, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 150, maxCount = 200, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500, maxCount = 1000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200, maxCount = 300, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000, maxCount = 2000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 300, maxCount = 500, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500, maxCount = 1000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000, maxCount = 2000, PropType = PropType.功德 },
            }
        },

        // ==================== 筑基 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200, maxCount = 300, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 120, maxCount = 150, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 300, maxCount = 500, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 150, maxCount = 200, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500, maxCount = 1000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200, maxCount = 300, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000, maxCount = 2000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 300, maxCount = 500, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500, maxCount = 1000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000, maxCount = 2000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.功德 },
            }
        },

        // ==================== 金丹 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500, maxCount = 1000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200, maxCount = 300, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000, maxCount = 2000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 300, maxCount = 500, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500, maxCount = 1000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000, maxCount = 2000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.功德 },
            }
        },

        // ==================== 元婴 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500, maxCount = 1000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000, maxCount = 2000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.功德 },
            }
        },

        // ==================== 化神 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000, maxCount = 5000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000, maxCount = 10000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.功德 },
            }
        },

        // ==================== 合体 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000, maxCount = 20000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000, maxCount = 50000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.功德 },
            }
        },

        // ==================== 大乘 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000, maxCount = 100000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000, maxCount = 200000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.功德 },
            }
        },

        // ==================== 天仙 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000, maxCount = 500000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000, maxCount = 1000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.功德 },
            }
        },

        // ==================== 玄仙 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000, maxCount = 2000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000, maxCount = 5000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.功德 },
            }
        },

        // ==================== 金仙 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000, maxCount = 10000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000, maxCount = 20000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.功德 },
            }
        },

        // ==================== 太乙金仙 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000, maxCount = 50000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000, maxCount = 100000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.功德 },
            }
        },

        // ==================== 大罗金仙 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000, maxCount = 200000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000, maxCount = 500000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.功德 },
            }
        },

        // ==================== 准圣 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000, maxCount = 1000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000000, maxCount = 2000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.功德 },
            }
        },

        // ==================== 圣人 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000000, maxCount = 5000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000000, maxCount = 10000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000000, maxCount = 2000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000000, maxCount = 5000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.功德 },
            }
        },

        // ==================== 天道圣人 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000000, maxCount = 20000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000000, maxCount = 50000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000000, maxCount = 2000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000000, maxCount = 5000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000000000, maxCount = 10000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000000000, maxCount = 2000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000000000, maxCount = 20000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000000000, maxCount = 5000000000000, PropType = PropType.功德 },
            }
        },

        // ==================== 大道圣人 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000000, maxCount = 100000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 100000000000, maxCount = 200000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000000, maxCount = 2000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000000, maxCount = 5000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000000000, maxCount = 10000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000000000, maxCount = 2000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000000000, maxCount = 20000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000000000, maxCount = 5000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000000000, maxCount = 50000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000000000, maxCount = 10000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000000000, maxCount = 100000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000000000, maxCount = 20000000000000, PropType = PropType.功德 },
            }
        },

        // ==================== 混元圣人 ====================
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.黄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 1000000000000, maxCount = 2000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 200000000000, maxCount = 500000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.玄品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 2000000000000, maxCount = 5000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 500000000000, maxCount = 1000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.地品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 5000000000000, maxCount = 10000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 1000000000000, maxCount = 2000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.天品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 10000000000000, maxCount = 20000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 2000000000000, maxCount = 5000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.宇品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 20000000000000, maxCount = 50000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 5000000000000, maxCount = 10000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.宙品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 50000000000000, maxCount = 100000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 10000000000000, maxCount = 20000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.洪品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 100000000000000, maxCount = 200000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 20000000000000, maxCount = 50000000000000, PropType = PropType.功德 },
            }
        },
        {
            new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.荒品 },
            new List<LevelDiaoLuo>()
            {
                new LevelDiaoLuo() { minCount = 200000000000000, maxCount = 500000000000000, PropType = PropType.灵魂 },
                new LevelDiaoLuo() { minCount = 50000000000000, maxCount = 100000000000000, PropType = PropType.功德 },
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
