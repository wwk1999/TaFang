using System.Collections.Generic;
using Config;

public enum 丹药类型
{
    None,
    战斗丹药,
    辅助丹药,
    根基丹药,
    造化丹药,
}
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

public class 丹药
{
    public 丹药Type 丹药Type = 丹药Type.None;
    public QualityType QualityType = QualityType.None;

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        丹药 other = (丹药)obj;
        return 丹药Type == other.丹药Type && QualityType == other.QualityType;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 31 + 丹药Type.GetHashCode();
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

    public static Dictionary<丹药Type, 丹药类型> 丹药类型Dic = new Dictionary<丹药Type, 丹药类型>()
    {
        { 丹药Type.火焰伤害, 丹药类型.战斗丹药 },
        { 丹药Type.冰霜伤害, 丹药类型.战斗丹药 },
        { 丹药Type.雷电伤害, 丹药类型.战斗丹药 },
        { 丹药Type.黑暗伤害, 丹药类型.战斗丹药 },
        { 丹药Type.物理伤害, 丹药类型.战斗丹药 },
        { 丹药Type.战士伤害, 丹药类型.战斗丹药 },
        { 丹药Type.法师伤害, 丹药类型.战斗丹药 },
        { 丹药Type.射手伤害, 丹药类型.战斗丹药 },
        { 丹药Type.控制伤害, 丹药类型.战斗丹药 },
        { 丹药Type.辅助伤害, 丹药类型.战斗丹药 },
        { 丹药Type.最终伤害, 丹药类型.战斗丹药 },
        { 丹药Type.修炼速度, 丹药类型.辅助丹药 },
        { 丹药Type.掉宝率, 丹药类型.辅助丹药 },
        { 丹药Type.英雄暴击伤害, 丹药类型.根基丹药 },
        { 丹药Type.加跟脚, 丹药类型.造化丹药 },
        { 丹药Type.英雄火焰伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄冰霜伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄雷电伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄黑暗伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄物理伤害, 丹药类型.根基丹药 },
        { 丹药Type.英雄最终伤害, 丹药类型.根基丹药 },
    };

    public static float Get丹药值(丹药Type type, QualityType qualityType)
    {
        switch (type)
        {
            case 丹药Type.火焰伤害:
            case 丹药Type.冰霜伤害:
            case 丹药Type.雷电伤害:
            case 丹药Type.黑暗伤害:
            case 丹药Type.物理伤害:
            case 丹药Type.战士伤害:
            case 丹药Type.射手伤害:
            case 丹药Type.法师伤害:
            case 丹药Type.辅助伤害:
            case 丹药Type.控制伤害:
                switch (qualityType)
                {
                    case QualityType.黄品: return 10;
                    case QualityType.玄品: return 20;
                    case QualityType.地品: return 30;
                    case QualityType.天品: return 50;
                    case QualityType.宇品: return 80;
                    case QualityType.宙品: return 120;
                    case QualityType.洪品: return 180;
                    case QualityType.荒品: return 300;
                }

                break;
            case 丹药Type.最终伤害:
                switch (qualityType)
                {
                    case QualityType.黄品: return 5;
                    case QualityType.玄品: return 10;
                    case QualityType.地品: return 20;
                    case QualityType.天品: return 30;
                    case QualityType.宇品: return 50;
                    case QualityType.宙品: return 80;
                    case QualityType.洪品: return 120;
                    case QualityType.荒品: return 180;
                }

                break;
            case 丹药Type.英雄最终伤害:
            case 丹药Type.英雄暴击伤害:
            case 丹药Type.英雄火焰伤害:
            case 丹药Type.英雄冰霜伤害:
            case 丹药Type.英雄雷电伤害:
            case 丹药Type.英雄黑暗伤害:
            case 丹药Type.英雄物理伤害:
                switch (qualityType)
                {
                    case QualityType.黄品: return 5;
                    case QualityType.玄品: return 10;
                    case QualityType.地品: return 20;
                    case QualityType.天品: return 30;
                    case QualityType.宇品: return 50;
                    case QualityType.宙品: return 80;
                    case QualityType.洪品: return 120;
                    case QualityType.荒品: return 180;
                }

                break;

            case 丹药Type.掉宝率:
                switch (qualityType)
                {
                    case QualityType.黄品: return 10;
                    case QualityType.玄品: return 20;
                    case QualityType.地品: return 30;
                    case QualityType.天品: return 50;
                    case QualityType.宇品: return 80;
                    case QualityType.宙品: return 120;
                    case QualityType.洪品: return 180;
                    case QualityType.荒品: return 300;
                }

                break;

            case 丹药Type.修炼速度:
                switch (qualityType)
                {
                    case QualityType.黄品: return 10;
                    case QualityType.玄品: return 20;
                    case QualityType.地品: return 30;
                    case QualityType.天品: return 50;
                    case QualityType.宇品: return 80;
                    case QualityType.宙品: return 120;
                    case QualityType.洪品: return 180;
                    case QualityType.荒品: return 300;
                }

                break;

            case 丹药Type.加跟脚:
                switch (qualityType)
                {
                    case QualityType.黄品: return 5;
                    case QualityType.玄品: return 10;
                    case QualityType.地品: return 20;
                    case QualityType.天品: return 30;
                    case QualityType.宇品: return 50;
                    case QualityType.宙品: return 80;
                    case QualityType.洪品: return 120;
                    case QualityType.荒品: return 180;
                }

                break;
        }

        return 0;
    }

    public static float Get丹药价格(丹药Type 丹药Type, QualityType qualityType)
    {
        var 丹药类型 = 丹药类型Dic[丹药Type];
        switch (丹药类型)
        {
            case 丹药类型.战斗丹药:
                return 坊市Config.战斗丹药价格Dic[qualityType];
            case 丹药类型.辅助丹药:
                return 坊市Config.辅助丹药价格Dic[qualityType];
            case 丹药类型.根基丹药:
                return 坊市Config.根基丹药价格Dic[qualityType];
            case 丹药类型.造化丹药:
                return 坊市Config.造化丹药价格Dic[qualityType];
        }

        return 0;
    }
    
    public static float Get丹方价格(丹药Type 丹药Type, QualityType qualityType)
    {
        var 丹药类型 = 丹药类型Dic[丹药Type];
        switch (丹药类型)
        {
            case 丹药类型.战斗丹药:
                return 坊市Config.战斗丹方价格Dic[qualityType];
            case 丹药类型.辅助丹药:
                return 坊市Config.辅助丹方价格Dic[qualityType];
            case 丹药类型.根基丹药:
                return 坊市Config.根基丹方价格Dic[qualityType];
            case 丹药类型.造化丹药:
                return 坊市Config.造化丹方价格Dic[qualityType];
        }

        return 0;
    }

    public static string Get丹药Desc(丹药Type 丹药Type, QualityType qualityType)
    {
        string 丹药值 = Get丹药值(丹药Type, qualityType).ToString();
        switch (丹药Type)
        {
            case 丹药Type.火焰伤害:
                return $"战斗时服用,增加{丹药值}%的火焰伤害";
            case 丹药Type.黑暗伤害:
                return $"战斗时服用,增加{丹药值}%的黑暗伤害";
            case 丹药Type.冰霜伤害:
                return $"战斗时服用,增加{丹药值}%的冰霜伤害";
            case 丹药Type.雷电伤害:
                return $"战斗时服用,增加{丹药值}%的雷电伤害";
            case 丹药Type.物理伤害:
                return $"战斗时服用,增加{丹药值}%的物理伤害";
            case 丹药Type.战士伤害:
                return $"战斗时服用,增加{丹药值}%的战士伤害";
            case 丹药Type.射手伤害:
                return $"战斗时服用,增加{丹药值}%的射手伤害";
            case 丹药Type.法师伤害:
                return $"战斗时服用,增加{丹药值}%的法师伤害";
            case 丹药Type.辅助伤害:
                return $"战斗时服用,增加{丹药值}%的辅助伤害";
            case 丹药Type.控制伤害:
                return $"战斗时服用,增加{丹药值}%的控制伤害";
            case 丹药Type.最终伤害:
                return $"战斗时服用,增加{丹药值}%的最终伤害";


            case 丹药Type.英雄火焰伤害:
                return $"服用后增加英雄{丹药值}%的火焰伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄黑暗伤害:
                return $"服用后增加英雄{丹药值}%的黑暗伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄冰霜伤害:
                return $"服用后增加英雄{丹药值}%的冰霜伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄雷电伤害:
                return $"服用后增加英雄{丹药值}%的雷电伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄物理伤害:
                return $"服用后增加英雄{丹药值}%的物理伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄最终伤害:
                return $"服用后增加英雄{丹药值}%的最终伤害,每个英雄每品质丹药最多可服用5次";
            case 丹药Type.英雄暴击伤害:
                return $"服用后增加英雄{丹药值}%的暴击伤害,每个英雄每品质丹药最多可服用5次";
            
            case 丹药Type.掉宝率:
                return $"服用后增加{丹药值}%的掉宝率,持续一道年";
            case 丹药Type.修炼速度:
                return $"服用后增加{丹药值}%的修炼速度,持续一道年";
            case 丹药Type.加跟脚:
                return $"服用后永久增加{丹药值}%的跟脚,轮回保留";
        }
        return null;
    }

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
        { 丹药Type.加跟脚, "造化丹" },
        { 丹药Type.英雄火焰伤害, "凤火丹" },
        { 丹药Type.英雄冰霜伤害, "玄冰丹" },
        { 丹药Type.英雄雷电伤害, "奔雷丹" },
        { 丹药Type.英雄黑暗伤害, "幽泉丹" },
        { 丹药Type.英雄物理伤害, "金刚丹" },

        { 丹药Type.英雄最终伤害, "混元丹" },
    };
    
    public static Dictionary<丹药Type, string> 丹方DescDic = new Dictionary<丹药Type, string>()
    {
        { 丹药Type.None, "无" },
        { 丹药Type.火焰伤害, "使用后可炼制火元丹" },
        { 丹药Type.冰霜伤害, "使用后可炼制霜华丹" },
        { 丹药Type.雷电伤害, "使用后可炼制雷魄丹" },
        { 丹药Type.黑暗伤害, "使用后可炼制玄冥丹" },
        { 丹药Type.物理伤害, "使用后可炼制破罡丹" },
        { 丹药Type.战士伤害, "使用后可炼制虎力丹" },
        { 丹药Type.法师伤害, "使用后可炼制灵蕴丹" },
        { 丹药Type.射手伤害, "使用后可炼制凝矢丹" },
        { 丹药Type.控制伤害, "使用后可炼制缚灵丹" },
        { 丹药Type.辅助伤害, "使用后可炼制玄辅丹" },
        { 丹药Type.最终伤害, "使用后可炼制归元丹" },
        { 丹药Type.修炼速度, "使用后可炼制悟道丹" },
        { 丹药Type.掉宝率, "使用后可炼制寻龙丹" },
        { 丹药Type.英雄暴击伤害, "使用后可炼制绝杀丹" },
        { 丹药Type.加跟脚, "使用后可炼制造化丹" },
        { 丹药Type.英雄火焰伤害, "使用后可炼制凤火丹" },
        { 丹药Type.英雄冰霜伤害, "使用后可炼制玄冰丹" },
        { 丹药Type.英雄雷电伤害, "使用后可炼制奔雷丹" },
        { 丹药Type.英雄黑暗伤害, "使用后可炼制幽泉丹" },
        { 丹药Type.英雄物理伤害, "使用后可炼制金刚丹" },

        { 丹药Type.英雄最终伤害, "使用后可炼制混元丹" },
    };
    
    
    public static Dictionary<丹药Type, string> 丹方名Dic = new Dictionary<丹药Type, string>()
    {
        { 丹药Type.None, "无" },
        { 丹药Type.火焰伤害, "火元丹方" },
        { 丹药Type.冰霜伤害, "霜华丹方" },
        { 丹药Type.雷电伤害, "雷魄丹方" },
        { 丹药Type.黑暗伤害, "玄冥丹方" },
        { 丹药Type.物理伤害, "破罡丹方" },
        { 丹药Type.战士伤害, "虎力丹方" },
        { 丹药Type.法师伤害, "灵蕴丹方" },
        { 丹药Type.射手伤害, "凝矢丹方" },
        { 丹药Type.控制伤害, "缚灵丹方" },
        { 丹药Type.辅助伤害, "玄辅丹方" },
        { 丹药Type.最终伤害, "归元丹方" },
        { 丹药Type.修炼速度, "悟道丹方" },
        { 丹药Type.掉宝率, "寻龙丹方" },
        { 丹药Type.英雄暴击伤害, "绝杀丹方" },
        { 丹药Type.加跟脚, "造化丹方" },
        { 丹药Type.英雄火焰伤害, "凤火丹方" },
        { 丹药Type.英雄冰霜伤害, "玄冰丹方" },
        { 丹药Type.英雄雷电伤害, "奔雷丹方" },
        { 丹药Type.英雄黑暗伤害, "幽泉丹方" },
        { 丹药Type.英雄物理伤害, "金刚丹方" },

        { 丹药Type.英雄最终伤害, "混元丹方" },
    };

    public static Dictionary<丹药Type, List<灵药Type>> 丹方Dic = new Dictionary<丹药Type, List<灵药Type>>()
    {
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
        { 丹药Type.最终伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.回春草, 灵药Type.补血花, 灵药Type.千年雪莲 } },
        { 丹药Type.修炼速度, new List<灵药Type> { 灵药Type.金银花蕊, 灵药Type.四叶参根, 灵药Type.聚灵凝神叶, 灵药Type.回春草 } },
        { 丹药Type.掉宝率, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.千年雪莲, 灵药Type.千幻蝶恋花, 灵药Type.龙纹草 } },
        { 丹药Type.英雄暴击伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.补血花, 灵药Type.金银花蕊, 灵药Type.四叶参根 } },
        { 丹药Type.加跟脚, new List<灵药Type> { 灵药Type.龙纹草, 灵药Type.聚灵凝神叶, 灵药Type.千年雪莲, 灵药Type.马兜铃果 } },
        { 丹药Type.英雄火焰伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.千幻蝶恋花, 灵药Type.九曲黄泉草, 灵药Type.补血花 } },
        { 丹药Type.英雄冰霜伤害, new List<灵药Type> { 灵药Type.四叶参根, 灵药Type.金银花蕊, 灵药Type.补血花, 灵药Type.回春草 } },
        { 丹药Type.英雄雷电伤害, new List<灵药Type> { 灵药Type.马兜铃果, 灵药Type.龙纹草, 灵药Type.九曲黄泉草, 灵药Type.聚灵凝神叶 } },
        { 丹药Type.英雄黑暗伤害, new List<灵药Type> { 灵药Type.千年雪莲, 灵药Type.千幻蝶恋花, 灵药Type.四叶参根, 灵药Type.金银花蕊 } },
        { 丹药Type.英雄物理伤害, new List<灵药Type> { 灵药Type.九曲黄泉草, 灵药Type.回春草, 灵药Type.马兜铃果, 灵药Type.千年雪莲 } },
        { 丹药Type.英雄最终伤害, new List<灵药Type> { 灵药Type.回春草, 灵药Type.马兜铃果, 灵药Type.九曲黄泉草, 灵药Type.千年雪莲 } },
    };
}
