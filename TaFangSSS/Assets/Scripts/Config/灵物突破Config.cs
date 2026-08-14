using System.Collections.Generic;
using Config;

public enum 突破灵物Type
{
    None,
    练气,
    筑基,
    金丹,
    元婴,
    化神,
    合体,
    大乘,
    天仙,
    玄仙,
    金仙,
    太乙金仙,
    大罗金仙,
    准圣,
    圣人,
    天道圣人,    
    大道圣人,
    混元圣人,
}

public class 洞天怪物Item
{
    public 突破灵物Type 突破灵物Type { get; set; }
    public QualityType QualityType { get; set; }

    public MonsterType MonsterType { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        洞天怪物Item other = (洞天怪物Item)obj;
        return QualityType==other.QualityType&&突破灵物Type == other.突破灵物Type && MonsterType == other.MonsterType;
    }


    public static Dictionary<洞天怪物Item, MonsterAttribute> 主线关卡怪物属性Dic = new Dictionary<洞天怪物Item, MonsterAttribute>()
    {
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.练气, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.练气, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.练气, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.筑基, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.筑基, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.筑基, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.金丹, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.金丹, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.金丹, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.元婴, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.元婴, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.元婴, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.化神, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.化神, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.化神, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.合体, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.合体, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.合体, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大乘, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大乘, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大乘, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.天仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.天仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.天仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.玄仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.玄仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.玄仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.金仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.金仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.金仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.太乙金仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.太乙金仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.太乙金仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大罗金仙, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大罗金仙, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大罗金仙, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.准圣, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.准圣, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.准圣, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.圣人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.天道圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.天道圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.天道圣人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大道圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大道圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.大道圣人, MonsterType = MonsterType.Boss },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        
        
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.混元圣人, MonsterType = MonsterType.Normal },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.混元圣人, MonsterType = MonsterType.Elite },
            new MonsterAttribute()
                { Hp = 50, Attack = 6, Defense = 5, 物理抗性 = 0, 冰霜抗性 = 0, 火焰抗性 = 0, 黑暗抗性 = 0, 雷电抗性 = 0 }
        },
        {
            new 洞天怪物Item() { QualityType = QualityType.黄品,突破灵物Type = 突破灵物Type.混元圣人, MonsterType = MonsterType.Boss },
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
}

public class 灵物突破Config
{
    
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
