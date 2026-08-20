using System.Collections.Generic;

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
    最终伤害,
    修炼速度,
    掉宝率,
    英雄永久增伤,
    加跟脚,//轮回后重置
    加火焰伤害,
    加冰霜伤害,
    加雷电伤害,
    加黑暗伤害,
    加物理伤害,
    加战士伤害,
    加法师伤害,
    加射手伤害,
    加控制伤害,
    加最终伤害,
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
        { 丹药Type.最终伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.回春草, 灵药Type.补血花, 灵药Type.千年雪莲 } },

        // 功能类丹药（5种）
        { 丹药Type.修炼速度, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.四叶参根, 灵药Type.聚灵凝神叶, 灵药Type.回春草 } },
        { 丹药Type.掉宝率, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.千年雪莲, 灵药Type.千幻蝶恋花, 灵药Type.龙纹草 } },
        { 丹药Type.英雄永久增伤, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.补血花, 灵药Type.金银花蕊, 灵药Type.四叶参根 } },
        { 丹药Type.加跟脚, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.聚灵凝神叶, 灵药Type.千年雪莲, 灵药Type.马兜铃果 } },
        { 丹药Type.加火焰伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.千幻蝶恋花, 灵药Type.九曲黄泉草, 灵药Type.补血花 } },

        // 元素增伤类（6种）
        { 丹药Type.加冰霜伤害, new List<灵药Type> { 灵药Type.四叶参根, 灵药Type.金银花蕊, 灵药Type.补血花, 灵药Type.回春草 } },
        { 丹药Type.加雷电伤害, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.龙纹草, 灵药Type.九曲黄泉草, 灵药Type.聚灵凝神叶 } },
        { 丹药Type.加黑暗伤害, new List<灵药Type> { 灵药Type.千年雪莲, 灵药Type.千幻蝶恋花, 灵药Type.四叶参根, 灵药Type.金银花蕊 } },
        { 丹药Type.加物理伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.回春草, 灵药Type.马兜铃果, 灵药Type.千年雪莲 } },
        { 丹药Type.加战士伤害, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.聚灵凝神叶, 灵药Type.补血花, 灵药Type.千幻蝶恋花 } },
        { 丹药Type.加法师伤害, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.四叶参根, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草 } },

        // 加伤类（3种）
        { 丹药Type.加射手伤害, new List<灵药Type> { 灵药Type.补血花, 灵药Type.千年雪莲, 灵药Type.聚灵凝神叶, 灵药Type.回春草 } },
        { 丹药Type.加控制伤害, new List<灵药Type> { 灵药Type.千幻蝶恋花, 灵药Type.龙纹草, 灵药Type.金银花蕊, 灵药Type.四叶参根 } },
        { 丹药Type.加最终伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草, 灵药Type.千年雪莲 } },
    };
}
