using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 功法Type
{
    None,
    // 战士系列
    战士白,
    战士绿,
    战士蓝,
    战士紫,
    战士橙,
    战士粉,
    战士红,
    战士彩,
    // 射手系列
    射手白,
    射手绿,
    射手蓝,
    射手紫,
    射手橙,
    射手粉,
    射手红,
    射手彩,
    // 控制系列
    控制白,
    控制绿,
    控制蓝,
    控制紫,
    控制橙,
    控制粉,
    控制红,
    控制彩,
    // 辅助系列
    辅助白,
    辅助绿,
    辅助蓝,
    辅助紫,
    辅助橙,
    辅助粉,
    辅助红,
    辅助彩,
    // 法师系列
    法师白,
    法师绿,
    法师蓝,
    法师紫,
    法师橙,
    法师粉,
    法师红,
    法师彩,
}

public enum 功法属性Type
{
    None,
    攻击距离,
    冷却缩减,
    暴击伤害,
    控制效果,
    辅助效果,
}

public class 功法属性Item
{
    public 功法属性Type 功法属性Type;
    public float count;
}

public class 功法Config
{
    public static Dictionary<QualityType, int> 功法升星经验 = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,100},
        { QualityType.玄品 ,200},
        { QualityType.地品 ,400},
        { QualityType.天品 ,1000},
        { QualityType.宇品 ,2000},
        { QualityType.宙品 ,4000},
        { QualityType.洪品 ,8000},
        { QualityType.荒品 ,20000},
    };

    public static int Get功法升级经验(int level)
    {
        if (level <= 5)return 300;
        else if (level <= 10)return 500;
        else if (level <= 15)return 800;
        else if (level <= 20)return 1200;
        else if (level <= 25)return 1500;
        else if (level <= 30)return 1800;
        else if (level <= 35)return 2100;
        else if (level <= 40)return 2500;
        else if (level <= 45)return 3000;
        else if (level <= 50)return 3500;
        else if (level <= 55)return 4500;
        else if (level <= 60)return 5000;
        else if (level <= 65)return 5500;
        else if (level <= 70)return 6000;
        else if (level <= 75)return 6500;
        else if (level <= 80)return 7000;
        else if (level <= 85)return 7500;
        else if (level <= 90)return 8000;
        else if (level <= 95)return 8500;
        else if (level <= 100) return 9000;
        else return 10000;
    }
    
    public static Dictionary<QualityType, int> 功法分解经验 = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,50},
        { QualityType.玄品 ,100},
        { QualityType.地品 ,200},
        { QualityType.天品 ,500},
        { QualityType.宇品 ,1000},
        { QualityType.宙品 ,2000},
        { QualityType.洪品 ,4000},
        { QualityType.荒品 ,10000},
    };
    public static Dictionary<功法Type, QualityType> 功法TypeQualityDic = new Dictionary<功法Type, QualityType>()
    {
        // 战士系列
        { 功法Type.战士白, QualityType.黄品 },
        { 功法Type.战士绿, QualityType.玄品 },
        { 功法Type.战士蓝, QualityType.地品 },
        { 功法Type.战士紫, QualityType.天品 },
        { 功法Type.战士橙, QualityType.宇品 },
        { 功法Type.战士粉, QualityType.宙品 },
        { 功法Type.战士红, QualityType.洪品 },
        { 功法Type.战士彩, QualityType.荒品 },

        // 射手系列
        { 功法Type.射手白, QualityType.黄品 },
        { 功法Type.射手绿, QualityType.玄品 },
        { 功法Type.射手蓝, QualityType.地品 },
        { 功法Type.射手紫, QualityType.天品 },
        { 功法Type.射手橙, QualityType.宇品 },
        { 功法Type.射手粉, QualityType.宙品 },
        { 功法Type.射手红, QualityType.洪品 },
        { 功法Type.射手彩, QualityType.荒品 },

        // 控制系列
        { 功法Type.控制白, QualityType.黄品 },
        { 功法Type.控制绿, QualityType.玄品 },
        { 功法Type.控制蓝, QualityType.地品 },
        { 功法Type.控制紫, QualityType.天品 },
        { 功法Type.控制橙, QualityType.宇品 },
        { 功法Type.控制粉, QualityType.宙品 },
        { 功法Type.控制红, QualityType.洪品 },
        { 功法Type.控制彩, QualityType.荒品 },

        // 辅助系列
        { 功法Type.辅助白, QualityType.黄品 },
        { 功法Type.辅助绿, QualityType.玄品 },
        { 功法Type.辅助蓝, QualityType.地品 },
        { 功法Type.辅助紫, QualityType.天品 },
        { 功法Type.辅助橙, QualityType.宇品 },
        { 功法Type.辅助粉, QualityType.宙品 },
        { 功法Type.辅助红, QualityType.洪品 },
        { 功法Type.辅助彩, QualityType.荒品 },

        // 法师系列
        { 功法Type.法师白, QualityType.黄品 },
        { 功法Type.法师绿, QualityType.玄品 },
        { 功法Type.法师蓝, QualityType.地品 },
        { 功法Type.法师紫, QualityType.天品 },
        { 功法Type.法师橙, QualityType.宇品 },
        { 功法Type.法师粉, QualityType.宙品 },
        { 功法Type.法师红, QualityType.洪品 },
        { 功法Type.法师彩, QualityType.荒品 },
    };
    public static Dictionary<功法Type, string> 功法名Dic = new Dictionary<功法Type, string>()
    {
        // 战士系列
        { 功法Type.战士白, "莽牛劲" },
        { 功法Type.战士绿, "开山诀" },
        { 功法Type.战士蓝, "碎岳拳" },
        { 功法Type.战士紫, "霸体金身" },
        { 功法Type.战士橙, "蚩尤战血" },
        { 功法Type.战士粉, "刑天舞干戚" },
        { 功法Type.战士红, "大巫真身" },
        { 功法Type.战士彩, "混沌开天经" },

        // 射手系列
        { 功法Type.射手白, "穿杨诀" },
        { 功法Type.射手绿, "逐风箭" },
        { 功法Type.射手蓝, "落星弓" },
        { 功法Type.射手紫, "破虚神眼" },
        { 功法Type.射手橙, "九日落日箭" },
        { 功法Type.射手粉, "射日神弓" },
        { 功法Type.射手红, "太阴凝光诀" },
        { 功法Type.射手彩, "天道诛仙矢" },

        // 控制系列
        { 功法Type.控制白, "缠藤术" },
        { 功法Type.控制绿, "定身咒" },
        { 功法Type.控制蓝, "画地为牢" },
        { 功法Type.控制紫, "六合锁天阵" },
        { 功法Type.控制橙, "八荒困仙阵" },
        { 功法Type.控制粉, "三千烦恼丝" },
        { 功法Type.控制红, "九幽镇魂咒" },
        { 功法Type.控制彩, "混沌囚笼" },

        // 辅助系列
        { 功法Type.辅助白, "养气诀" },
        { 功法Type.辅助绿, "济世经" },
        { 功法Type.辅助蓝, "回春功" },
        { 功法Type.辅助紫, "造化诀" },
        { 功法Type.辅助橙, "众生渡" },
        { 功法Type.辅助粉, "万象回春法" },
        { 功法Type.辅助红, "天道神符决" },
        { 功法Type.辅助彩, "无极造化决" },

        // 法师系列
        { 功法Type.法师白, "聚灵诀" },
        { 功法Type.法师绿, "凝神咒" },
        { 功法Type.法师蓝, "化元功" },
        { 功法Type.法师紫, "神念御天" },
        { 功法Type.法师橙, "万法归宗" },
        { 功法Type.法师粉, "通玄经" },
        { 功法Type.法师红, "混元道决" },
        { 功法Type.法师彩, "万法本源" },
    };

    public static Dictionary<功法Type, ZhiYeType> 功法职业Dic = new Dictionary<功法Type, ZhiYeType>()
    {
        // 战士系列
        { 功法Type.战士白, ZhiYeType.战士 },
        { 功法Type.战士绿, ZhiYeType.战士 },
        { 功法Type.战士蓝, ZhiYeType.战士 },
        { 功法Type.战士紫, ZhiYeType.战士 },
        { 功法Type.战士粉, ZhiYeType.战士 },
        { 功法Type.战士红, ZhiYeType.战士 },
        { 功法Type.战士橙, ZhiYeType.战士 },
        { 功法Type.战士彩, ZhiYeType.战士 },

        // 射手系列
        { 功法Type.射手白, ZhiYeType.射手 },
        { 功法Type.射手绿, ZhiYeType.射手 },
        { 功法Type.射手蓝, ZhiYeType.射手 },
        { 功法Type.射手紫, ZhiYeType.射手 },
        { 功法Type.射手粉, ZhiYeType.射手 },
        { 功法Type.射手红, ZhiYeType.射手 },
        { 功法Type.射手橙, ZhiYeType.射手 },
        { 功法Type.射手彩, ZhiYeType.射手 },

        // 控制系列
        { 功法Type.控制白, ZhiYeType.控制 },
        { 功法Type.控制绿, ZhiYeType.控制 },
        { 功法Type.控制蓝, ZhiYeType.控制 },
        { 功法Type.控制紫, ZhiYeType.控制 },
        { 功法Type.控制粉, ZhiYeType.控制 },
        { 功法Type.控制红, ZhiYeType.控制 },
        { 功法Type.控制橙, ZhiYeType.控制 },
        { 功法Type.控制彩, ZhiYeType.控制 },

        // 辅助系列
        { 功法Type.辅助白, ZhiYeType.辅助 },
        { 功法Type.辅助绿, ZhiYeType.辅助 },
        { 功法Type.辅助蓝, ZhiYeType.辅助 },
        { 功法Type.辅助紫, ZhiYeType.辅助 },
        { 功法Type.辅助粉, ZhiYeType.辅助 },
        { 功法Type.辅助红, ZhiYeType.辅助 },
        { 功法Type.辅助橙, ZhiYeType.辅助 },
        { 功法Type.辅助彩, ZhiYeType.辅助 },

        // 法师系列
        { 功法Type.法师白, ZhiYeType.法师 },
        { 功法Type.法师绿, ZhiYeType.法师 },
        { 功法Type.法师蓝, ZhiYeType.法师 },
        { 功法Type.法师紫, ZhiYeType.法师 },
        { 功法Type.法师粉, ZhiYeType.法师 },
        { 功法Type.法师红, ZhiYeType.法师 },
        { 功法Type.法师橙, ZhiYeType.法师 },
        { 功法Type.法师彩, ZhiYeType.法师 },
    };
    public static Dictionary<功法Type, string> 功法介绍Dic = new Dictionary<功法Type, string>()
{
    // 战士系列
    { 功法Type.战士白, "蛮牛之力灌注全身，横冲直撞势不可挡，以绝对力量碾压一切对手。" },
    { 功法Type.战士绿, "一斧开山碎石裂地，气吞山河威震八方，势如破竹无人可挡。" },
    { 功法Type.战士蓝, "拳碎山岳力贯千钧，刚猛无俦破尽万法，一拳出则天地变色。" },
    { 功法Type.战士紫, "金刚不坏万法不侵，肉身成圣立于不败，纵横天地唯我独尊。" },
    { 功法Type.战士粉, "唤醒上古魔血沸腾，战意滔天不死不灭，愈战愈勇直至敌亡。" },
    { 功法Type.战士红, "以乳为目以脐为口，刑天舞干戚永不息，战天斗地至死方休。" },
    { 功法Type.战士橙, "盘古后裔真身降临，肉身破万法力拔山河，一拳可碎星辰日月。" },
    { 功法Type.战士彩, "开天辟地之力加身，一拳碎虚空万法皆破，混沌之中唯我称尊。" },

    // 射手系列
    { 功法Type.射手白, "百步穿杨箭无虚发，精准无双例不虚发，一箭出则敌首落地。" },
    { 功法Type.射手绿, "追风逐电快如流星，敌人尚未察觉箭至，已穿喉而过命丧当场。" },
    { 功法Type.射手蓝, "弯弓射星坠落九天，一箭出可定乾坤，万里之外取敌首级。" },
    { 功法Type.射手紫, "洞虚破妄无所遁形，万物皆在神眼之中，箭箭穿心例不虚发。" },
    { 功法Type.射手粉, "后羿遗技九日齐坠，一箭惊天动地泣神，上古神射威震八方。" },
    { 功法Type.射手红, "羿射九日万古留名，神弓一出天下皆惊，射日之威无人可敌。" },
    { 功法Type.射手橙, "月华凝箭穿魂夺魄，无形无影防不胜防，一箭出则神魂俱灭。" },
    { 功法Type.射手彩, "代天行罚一箭诛仙，天道之下皆为蝼蚁，神罚之矢无人能挡。" },

    // 控制系列
    { 功法Type.控制白, "荆棘缠身寸步难行，藤蔓束缚困敌于方寸之间，动弹不得任人宰割。" },
    { 功法Type.控制绿, "言出法随定住身形，一语既出敌人僵立，如坠冰窟无法挣脱。" },
    { 功法Type.控制蓝, "一指画地自成囚笼，困锁万物无处可逃，方圆之内皆为牢狱。" },
    { 功法Type.控制紫, "封锁六合困锁苍穹，天地四方皆为囚笼，插翅难逃插翅难飞。" },
    { 功法Type.控制粉, "八荒之力结为大阵，仙神难脱万古牢笼，阵中万物皆受禁锢。" },
    { 功法Type.控制红, "情丝缠绕神智沉沦，坠入无尽轮回之痛，心神失守永堕黑暗。" },
    { 功法Type.控制橙, "九幽之力镇压神魂，永世不得超生轮回，魂魄被锁万劫不复。" },
    { 功法Type.控制彩, "混沌之力化为囚笼，禁锢天地万法皆封，大道之下无人可破。" },

    // 辅助系列
    { 功法Type.辅助白, "温养元气强身健体，固本培元奠定修行之基，百病不侵气脉悠长。" },
    { 功法Type.辅助绿, "心怀济世之念苍生，初通医理救人于危难，悬壶济世普惠众生。" },
    { 功法Type.辅助蓝, "枯木回春生机流转，愈合一切伤痛创伤，气血充盈活力焕发。" },
    { 功法Type.辅助紫, "夺天地之造化玄机，补众生之缺漏缺陷，逆转生死起死回生。" },
    { 功法Type.辅助粉, "渡尽众生福泽万物，大爱无疆慈悲为怀，普度天下惠及苍生。" },
    { 功法Type.辅助红, "一念回春万象复苏，枯骨亦可生肉活命，造化之力妙手回春。" },
    { 功法Type.辅助橙, "绘制天道神纹，引动天威福泽众生，护体加持所向披靡。" },
    { 功法Type.辅助彩, "无极生造化天地开，生生不息万灵永昌盛，福泽绵长泽被苍生。" },

    // 法师系列
    { 功法Type.法师白, "汇聚天地灵气入体，感应元素初源之力，法力初生道基始成。" },
    { 功法Type.法师绿, "凝神静气精神御法，心念通达天地万物，一念起则风云变色。" },
    { 功法Type.法师蓝, "化灵为元法力澎湃，施法连绵不绝如缕，以一敌众游刃有余。" },
    { 功法Type.法师紫, "神念外放御法天地，一念可动山河移位，精神之力浩瀚如海。" },
    { 功法Type.法师粉, "万般法术终归同源，一法通则万法皆通，触类旁通无师自通。" },
    { 功法Type.法师红, "通达玄妙洞悉天机，法术随心所欲不逾矩，大道至简万变不离。" },
    { 功法Type.法师橙, "混沌归元道果自成，半步踏入大道之门，离那至高只差一步。" },
    { 功法Type.法师彩, "参悟万法本源之道，言出法随造化由心，天地法则尽在掌中。" },
};

    public static string Get功法基础属性String(功法Type type)
    {
        if (!功法属性Dic.ContainsKey(type)) return "";

        功法属性Item item = 功法属性Dic[type];
        float value = item.count;

        switch (type)
        {
            // 战士系列 - 攻击距离
            case 功法Type.战士白:
            case 功法Type.战士绿:
            case 功法Type.战士蓝:
            case 功法Type.战士紫:
            case 功法Type.战士粉:
            case 功法Type.战士红:
            case 功法Type.战士橙:
            case 功法Type.战士彩:
                return $"战士攻击距离+<color=green>{value}</color>";

            // 法师系列 - 暴击伤害
            case 功法Type.法师白:
            case 功法Type.法师绿:
            case 功法Type.法师蓝:
            case 功法Type.法师紫:
            case 功法Type.法师粉:
            case 功法Type.法师红:
            case 功法Type.法师橙:
            case 功法Type.法师彩:
                return $"法师暴击伤害+<color=green>{value}%</color>";

            // 辅助系列 - 辅助效果
            case 功法Type.辅助白:
            case 功法Type.辅助绿:
            case 功法Type.辅助蓝:
            case 功法Type.辅助紫:
            case 功法Type.辅助粉:
            case 功法Type.辅助红:
            case 功法Type.辅助橙:
            case 功法Type.辅助彩:
                return $"辅助效果+<color=green>{value}%</color>";

            // 控制系列 - 控制效果
            case 功法Type.控制白:
            case 功法Type.控制绿:
            case 功法Type.控制蓝:
            case 功法Type.控制紫:
            case 功法Type.控制粉:
            case 功法Type.控制红:
            case 功法Type.控制橙:
            case 功法Type.控制彩:
                return $"控制效果+<color=green>{value}%</color>";

            // 射手系列 - 冷却缩减
            case 功法Type.射手白:
            case 功法Type.射手绿:
            case 功法Type.射手蓝:
            case 功法Type.射手紫:
            case 功法Type.射手粉:
            case 功法Type.射手红:
            case 功法Type.射手橙:
            case 功法Type.射手彩:
                return $"射手冷却缩减+<color=green>{value}%</color>";

            default:
                return "";
        }
    }

    public static Dictionary<QualityType, float> 功法升级最终伤害奖励Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 5 },
        { QualityType.玄品, 10 },
        { QualityType.地品, 15 },
        { QualityType.天品, 20 },
        { QualityType.宇品, 30 },
        { QualityType.宙品, 50 },
        { QualityType.洪品, 100 },
        { QualityType.荒品, 200 },
    };
    
    //增加被辅助英雄伤害
    public static Dictionary<QualityType, float> 辅助功法升级奖励Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 3 },
        { QualityType.玄品, 5 },
        { QualityType.地品, 10 },
        { QualityType.天品, 15 },
        { QualityType.宇品, 20 },
        { QualityType.宙品, 30 },
        { QualityType.洪品, 50 },
        { QualityType.荒品, 100 },
    };

    // 辅助英雄功法给被辅助英雄的最终伤害加成（比率，如0.15=15%）
    // 未装备功法返回0；多个辅助的加成在 MonsterBase.计算功法伤害 中与主英雄功法相加后统一乘一次
    public static float Get辅助功法伤害加成(HeroType 辅助英雄)
    {
        var 数据 = PlayerData.S.HeroDataDic[辅助英雄];
        if (数据.功法Type == 功法Type.None) return 0f;
        float 每重奖励 = 辅助功法升级奖励Dic[功法TypeQualityDic[数据.功法Type]];
        return 数据.功法等级 * 每重奖励 / 100f;
    }
    public static Dictionary<功法Type, 功法属性Item> 功法属性Dic = new Dictionary<功法Type, 功法属性Item>()
    {
        { 功法Type.战士白, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 0.5f } },
        { 功法Type.战士绿, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 0.7f } },
        { 功法Type.战士蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 1f } },
        { 功法Type.战士紫, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 1.3f } },
        { 功法Type.战士橙, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 1.8f } },
        { 功法Type.战士粉, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 2.4f } },
        { 功法Type.战士红, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 3 } },
        { 功法Type.战士彩, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 4 } },

        { 功法Type.法师白, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 10f } },
        { 功法Type.法师绿, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 15f } },
        { 功法Type.法师蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 25f } },
        { 功法Type.法师紫, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 40f } },
        { 功法Type.法师橙, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 70 } },
        { 功法Type.法师粉, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 110 } },
        { 功法Type.法师红, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 180 } },
        { 功法Type.法师彩, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 300 } },

        { 功法Type.辅助白, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 5f } },
        { 功法Type.辅助绿, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 10f } },
        { 功法Type.辅助蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 15f } },
        { 功法Type.辅助紫, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 25f } },
        { 功法Type.辅助橙, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 40f } },
        { 功法Type.辅助粉, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 60f } },
        { 功法Type.辅助红, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 90 } },
        { 功法Type.辅助彩, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 150 } },

        { 功法Type.控制白, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 5f } },
        { 功法Type.控制绿, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 10f } },
        { 功法Type.控制蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 15f } },
        { 功法Type.控制紫, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 25f } },
        { 功法Type.控制橙, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 40f } },
        { 功法Type.控制粉, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 60f } },
        { 功法Type.控制红, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 90 } },
        { 功法Type.控制彩, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 150 } },

        { 功法Type.射手白, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 5f } },
        { 功法Type.射手绿, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 10f } },
        { 功法Type.射手蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 18f } },
        { 功法Type.射手紫, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 30f } },
        { 功法Type.射手橙, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 50f } },
        { 功法Type.射手粉, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 80f } },
        { 功法Type.射手红, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 120f } },
        { 功法Type.射手彩, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 200f } },
    };

    public static Dictionary<QualityType, int> 传道消耗Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品, 100 },
        { QualityType.玄品, 300 },
        { QualityType.地品, 1000 },
        { QualityType.天品, 3000 },
        { QualityType.宇品, 10000 },
        { QualityType.宙品, 30000 },
        { QualityType.洪品, 100000 },
        { QualityType.荒品, 1000000 },
    };

    public static Dictionary<QualityType, List<float>> 传道概率Dic = new Dictionary<QualityType, List<float>>()
    {
        { QualityType.黄品, new List<float>() { 100, 0, 0, 0, 0, 0, 0, 0 } },
        { QualityType.玄品, new List<float>() { 70, 30, 0, 0, 0, 0, 0, 0 } },
        { QualityType.地品, new List<float>() { 35, 50, 25, 0, 0, 0, 0, 0 } },
        { QualityType.天品, new List<float>() { 10, 30, 40, 20, 0, 0, 0, 0 } },
        { QualityType.宇品, new List<float>() { 0, 15, 40, 30, 15, 0, 0, 0 } },
        { QualityType.宙品, new List<float>() { 0, 10, 25, 30, 25, 10, 0, 0 } },
        { QualityType.洪品, new List<float>() { 0, 0, 10, 25, 40, 20, 5, 0 } },
        { QualityType.荒品, new List<float>() { 0, 0, 0, 14, 40, 30, 15, 1 } },
    };

    public static 功法Type Get功法(QualityType qualityType)
    {
        switch (qualityType)
        {
            case QualityType.黄品:
                int random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士白;
                    case 2: return 功法Type.法师白;
                    case 3: return 功法Type.辅助白;
                    case 4: return 功法Type.控制白;
                    case 5: return 功法Type.射手白;
                }

                break;

            case QualityType.玄品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士绿;
                    case 2: return 功法Type.法师绿;
                    case 3: return 功法Type.辅助绿;
                    case 4: return 功法Type.控制绿;
                    case 5: return 功法Type.射手绿;
                }

                break;

            case QualityType.地品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士蓝;
                    case 2: return 功法Type.法师蓝;
                    case 3: return 功法Type.辅助蓝;
                    case 4: return 功法Type.控制蓝;
                    case 5: return 功法Type.射手蓝;
                }

                break;

            case QualityType.天品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士紫;
                    case 2: return 功法Type.法师紫;
                    case 3: return 功法Type.辅助紫;
                    case 4: return 功法Type.控制紫;
                    case 5: return 功法Type.射手紫;
                }

                break;

            case QualityType.宙品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士粉;
                    case 2: return 功法Type.法师粉;
                    case 3: return 功法Type.辅助粉;
                    case 4: return 功法Type.控制粉;
                    case 5: return 功法Type.射手粉;
                }

                break;

            case QualityType.洪品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士红;
                    case 2: return 功法Type.法师红;
                    case 3: return 功法Type.辅助红;
                    case 4: return 功法Type.控制红;
                    case 5: return 功法Type.射手红;
                }

                break;

            case QualityType.宇品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士橙;
                    case 2: return 功法Type.法师橙;
                    case 3: return 功法Type.辅助橙;
                    case 4: return 功法Type.控制橙;
                    case 5: return 功法Type.射手橙;
                }

                break;

            case QualityType.荒品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士彩;
                    case 2: return 功法Type.法师彩;
                    case 3: return 功法Type.辅助彩;
                    case 4: return 功法Type.控制彩;
                    case 5: return 功法Type.射手彩;
                }

                break;
        }
        return 功法Type.None;
    }

    public static 功法Type 传道(QualityType qualityType)
    {
        List<float> list = 传道概率Dic[qualityType];
        int index = 0;
        float count = 0;
        float random = Random.Range(0, 100);
        foreach (var item in list)
        {
            count += item;
            if (random <= count)
            {
                break;
            }
            index++;
        }

        switch (index)
        {
            case 0:
                return Get功法(QualityType.黄品);
            case 1:
                return Get功法(QualityType.玄品);
            case 2:
                return Get功法(QualityType.地品);
            case 3:
                return Get功法(QualityType.天品);
            case 4:
                return Get功法(QualityType.宇品);
            case 5:
                return Get功法(QualityType.宙品);
            case 6:
                return Get功法(QualityType.洪品);
            case 7:
                return Get功法(QualityType.荒品);
        }

        return 功法Type.None;
    }
}
