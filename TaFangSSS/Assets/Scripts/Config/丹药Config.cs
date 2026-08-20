using System.Collections.Generic;
using Config;

public enum 丹药Type
{
    None,
    火焰伤害,
    冰霜伤害,
    雷电伤害,
    黑暗伤害,
    物理伤害,
    战士伤害,
    法师伤害,
    射手伤害,
    控制伤害,
    辅助伤害,
    最终伤害,
    修炼速度,
    掉宝率,
    英雄暴击伤害,
    加跟脚,//轮回后重置
    英雄火焰伤害,
    英雄冰霜伤害,
    英雄雷电伤害,
    英雄黑暗伤害,
    英雄物理伤害,
    英雄战士伤害,
    英雄法师伤害,
    英雄射手伤害,
    英雄控制伤害,
    英雄辅助伤害,
    英雄最终伤害,
}

public class 灵药
{
    public 灵药Type 灵药Type = 灵药Type.None;
    public QualityType QualityType = QualityType.None;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        灵药 other = (灵药)obj;
        return 灵药Type == other.灵药Type && QualityType == other.QualityType;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + 灵药Type.GetHashCode();
        hash = hash * 31 + QualityType.GetHashCode();
        return hash;
    }
}

public enum 灵药Type
{
    None,
    金银花蕊,
    马兜铃果,
    四叶参根,
    千年雪莲,
    回春草,
    补血花,
    龙纹草,
    九曲黄泉草,
    千幻蝶恋花,
    聚灵凝神叶
}

public class 丹药Config
{
    public static Dictionary<灵药Type, string> 灵药名Dic = new Dictionary<灵药Type, string>()
    {
        { 灵药Type.金银花蕊, "金银花蕊" },
        { 灵药Type.马兜铃果, "马兜铃果" },
        { 灵药Type.四叶参根, "四叶参根" },
        { 灵药Type.千年雪莲, "千年雪莲" },
        { 灵药Type.回春草, "回春草" },
        { 灵药Type.补血花, "补血花" },
        { 灵药Type.龙纹草, "龙纹草" },
        { 灵药Type.九曲黄泉草, "九曲黄泉草" },
        { 灵药Type.千幻蝶恋花, "千幻蝶恋花" },
        { 灵药Type.聚灵凝神叶, "聚灵凝神叶" },
    };
    public static Dictionary<丹药Type, string> 丹药名Dic = new Dictionary<丹药Type, string>()
    {
        { 丹药Type.None, "无" },
        { 丹药Type.火焰伤害, "火元丹" },
        { 丹药Type.冰霜伤害, "霜华丹" },
        { 丹药Type.雷电伤害, "雷魄丹" },
        { 丹药Type.黑暗伤害, "玄冥丹" },
        { 丹药Type.物理伤害, "破罡丹" },
        { 丹药Type.战士伤害, "虎力丹" },
        { 丹药Type.法师伤害, "灵蕴丹" },
        { 丹药Type.射手伤害, "凝矢丹" },
        { 丹药Type.控制伤害, "缚灵丹" },
        { 丹药Type.辅助伤害, "玄辅丹" },
        { 丹药Type.最终伤害, "归元丹" },
        { 丹药Type.修炼速度, "悟道丹" },
        { 丹药Type.掉宝率, "寻龙丹" },
        { 丹药Type.英雄暴击伤害, "绝杀丹" },
        { 丹药Type.加跟脚, "洗髓伐脉丹" },
        { 丹药Type.英雄火焰伤害, "凤火丹" },
        { 丹药Type.英雄冰霜伤害, "玄冰丹" },
        { 丹药Type.英雄雷电伤害, "奔雷丹" },
        { 丹药Type.英雄黑暗伤害, "幽泉丹" },
        { 丹药Type.英雄物理伤害, "金刚丹" },
        { 丹药Type.英雄战士伤害, "骁勇丹" },
        { 丹药Type.英雄法师伤害, "天机丹" },
        { 丹药Type.英雄射手伤害, "破军丹" },
        { 丹药Type.英雄控制伤害, "镇魂丹" },
        { 丹药Type.英雄辅助伤害, "太初丹" },
        { 丹药Type.英雄最终伤害, "混元丹" },
    };
    public static Dictionary<丹药Type, List<灵药Type>> 丹方Dic = new Dictionary<丹药Type, List<灵药Type>>()
    {
        // 伤害类丹药（11种）
        { 丹药Type.火焰伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.金银花蕊, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草 } },
        { 丹药Type.冰霜伤害, new List<灵药Type> { 灵药Type.四叶参根, 灵药Type.四叶参根, 灵药Type.回春草, 灵药Type.聚灵凝神叶 } },
        { 丹药Type.雷电伤害, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.马兜铃果, 灵药Type.千幻蝶恋花, 灵药Type.龙纹草 } },
        { 丹药Type.黑暗伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.九曲黄泉草, 灵药Type.补血花, 灵药Type.四叶参根 } },
        { 丹药Type.物理伤害, new List<灵药Type> { 灵药Type.千年雪莲, 灵药Type.千年雪莲, 灵药Type.聚灵凝神叶, 灵药Type.金银花蕊 } },
        { 丹药Type.战士伤害, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.龙纹草, 灵药Type.千年雪莲, 灵药Type.回春草 } },
        { 丹药Type.法师伤害, new List<灵药Type> { 灵药Type.聚灵凝神叶, 灵药Type.聚灵凝神叶, 灵药Type.四叶参根, 灵药Type.千幻蝶恋花 } },
        { 丹药Type.射手伤害, new List<灵药Type> { 灵药Type.补血花, 灵药Type.补血花, 灵药Type.马兜铃果, 灵药Type.金银花蕊 } },
        { 丹药Type.控制伤害, new List<灵药Type> { 灵药Type.千幻蝶恋花, 灵药Type.千幻蝶恋花, 灵药Type.龙纹草, 灵药Type.九曲黄泉草 } },
        { 丹药Type.辅助伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.马兜铃果, 灵药Type.四叶参根, 灵药Type.千年雪莲 } },
        { 丹药Type.英雄辅助伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.千幻蝶恋花, 灵药Type.回春草, 灵药Type.补血花 } },

        { 丹药Type.最终伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.回春草, 灵药Type.补血花, 灵药Type.千年雪莲 } },

        // 功能类丹药（5种）
        { 丹药Type.修炼速度, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.四叶参根, 灵药Type.聚灵凝神叶, 灵药Type.回春草 } },
        { 丹药Type.掉宝率, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.千年雪莲, 灵药Type.千幻蝶恋花, 灵药Type.龙纹草 } },
        { 丹药Type.英雄暴击伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.补血花, 灵药Type.金银花蕊, 灵药Type.四叶参根 } },
        { 丹药Type.加跟脚, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.聚灵凝神叶, 灵药Type.千年雪莲, 灵药Type.马兜铃果 } },
        { 丹药Type.英雄火焰伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.千幻蝶恋花, 灵药Type.九曲黄泉草, 灵药Type.补血花 } },

        // 元素增伤类（6种）
        { 丹药Type.英雄冰霜伤害, new List<灵药Type> { 灵药Type.四叶参根, 灵药Type.金银花蕊, 灵药Type.补血花, 灵药Type.回春草 } },
        { 丹药Type.英雄雷电伤害, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.龙纹草, 灵药Type.九曲黄泉草, 灵药Type.聚灵凝神叶 } },
        { 丹药Type.英雄黑暗伤害, new List<灵药Type> { 灵药Type.千年雪莲, 灵药Type.千幻蝶恋花, 灵药Type.四叶参根, 灵药Type.金银花蕊 } },
        { 丹药Type.英雄物理伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.回春草, 灵药Type.马兜铃果, 灵药Type.千年雪莲 } },
        { 丹药Type.英雄战士伤害, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.聚灵凝神叶, 灵药Type.补血花, 灵药Type.千幻蝶恋花 } },
        { 丹药Type.英雄法师伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.四叶参根, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草 } },

        // 加伤类（3种）
        { 丹药Type.英雄射手伤害, new List<灵药Type> { 灵药Type.补血花, 灵药Type.千年雪莲, 灵药Type.聚灵凝神叶, 灵药Type.回春草 } },
        { 丹药Type.英雄控制伤害, new List<灵药Type> { 灵药Type.千幻蝶恋花, 灵药Type.龙纹草, 灵药Type.金银花蕊, 灵药Type.四叶参根 } },
        { 丹药Type.英雄最终伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草, 灵药Type.千年雪莲 } },
    };
}
