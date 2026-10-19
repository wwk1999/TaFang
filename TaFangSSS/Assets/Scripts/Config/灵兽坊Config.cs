using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 灵兽Type
{
    None,
    火1,
    火2,
    火3,
    火4,
    火5,
    火6,
    火7,
    火8,
    
    暗1,
    暗2,
    暗3,
    暗4,
    暗5,
    暗6,
    暗7,
    暗8,
    
    物1,
    物2,
    物3,
    物4,
    物5,
    物6,
    物7,
    物8,
    
    冰1,
    冰2,
    冰3,
    冰4,
    冰5,
    冰6,
    冰7,
    冰8,
    
    电1,
    电2,
    电3,
    电4,
    电5,
    电6,
    电7,
    电8,
}

public enum 性别
{
    None,
    公,
    母,
}

public enum 血脉Type
{
    None,
    凡品,
    良品,
    上品,
    变异,
    卓越,
    完美,
    绝品,
    至尊
}
public enum 阶段Type
{
    None,
    幼生期,
    成长期,
    完全体,
    脱变期,
    灵化期,
    归元体,
    通神体,
    本源体
}

public class 灵兽
{
    public 灵兽Type 灵兽Type;
    public QualityType QualityType;
    public YuanSuType 元素Type;
    public 性别 性别;
    public 血脉Type 血脉Type;
    public 阶段Type 阶段Type;
    public float 道龄;
    public bool 最终伤害无暇 = false;
    public bool 暴击伤害无暇 = false;
    public bool 元素伤害无暇 = false;
    public float 最终伤害;
    public float 暴击伤害;
    public float 元素伤害;
}
public class 灵兽坊Config
{
    public static Dictionary<血脉Type, string> 血脉Name = new Dictionary<血脉Type, string>()
    {
        { 血脉Type.凡品 ,"凡品"},
        { 血脉Type.良品 ,"良品"},
        { 血脉Type.上品 ,"上品"},
        { 血脉Type.变异 ,"变异"},
        { 血脉Type.卓越 ,"卓越"},
        { 血脉Type.完美 ,"完美"},
        { 血脉Type.绝品 ,"绝品"},
        { 血脉Type.至尊 ,"至尊"},
    };
    
    public static Dictionary<阶段Type, string> 阶段Name = new Dictionary<阶段Type, string>()
    {
        { 阶段Type.幼生期 ,"幼生期"},
        { 阶段Type.成长期 ,"成长期"},
        { 阶段Type.完全体 ,"完全体"},
        { 阶段Type.脱变期 ,"脱变期"},
        { 阶段Type.灵化期 ,"灵化期"},
        { 阶段Type.归元体 ,"归元体"},
        { 阶段Type.通神体 ,"通神体"},
        { 阶段Type.本源体 ,"本源体"},
    };

    public static float Get灵兽洗髓消耗(QualityType qualityType, 阶段Type 阶段Type)
    {
        return 品级洗髓消耗[qualityType] * 阶段洗髓倍数[阶段Type];
    }
    
    public static float Get灵兽进化消耗(QualityType qualityType, 阶段Type 阶段Type)
    {
        return 品级进化消耗[qualityType] * 阶段进化倍数[阶段Type];
    }

    public static Dictionary<QualityType, float> 品级洗髓消耗 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 10 },
        { QualityType.玄品 ,20},
        { QualityType.地品 ,40},
        { QualityType.天品 ,80},
        { QualityType.宇品 ,150},
        { QualityType.宙品 ,400},
        { QualityType.洪品 ,1200},
        { QualityType.荒品 ,10000},
    };
    public static Dictionary<QualityType, float> 灵兽分解 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 10 },
        { QualityType.玄品 ,20},
        { QualityType.地品 ,40},
        { QualityType.天品 ,80},
        { QualityType.宇品 ,150},
        { QualityType.宙品 ,400},
        { QualityType.洪品 ,1200},
        { QualityType.荒品 ,10000},
    };
    public static Dictionary<阶段Type, float> 阶段洗髓倍数 = new Dictionary<阶段Type, float>()
    {
        { 阶段Type.幼生期, 1 },
        { 阶段Type.成长期 ,2},
        { 阶段Type.完全体 ,4},
        { 阶段Type.脱变期 ,8},
        { 阶段Type.灵化期 ,15},
        { 阶段Type.归元体 ,40},
        { 阶段Type.通神体 ,120},
        { 阶段Type.本源体 ,1000},
    };
    
    public static Dictionary<QualityType, float> 品级进化消耗 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 1000},
        { QualityType.玄品 ,2000},
        { QualityType.地品 ,4000},
        { QualityType.天品 ,8000},
        { QualityType.宇品 ,15000},
        { QualityType.宙品 ,40000},
        { QualityType.洪品 ,120000},
        { QualityType.荒品 ,1000000},
    };
    public static Dictionary<阶段Type, float> 阶段进化倍数 = new Dictionary<阶段Type, float>()
    {
        { 阶段Type.幼生期, 1 },
        { 阶段Type.成长期 ,2},
        { 阶段Type.完全体 ,4},
        { 阶段Type.脱变期 ,8},
        { 阶段Type.灵化期 ,15},
        { 阶段Type.归元体 ,40},
        { 阶段Type.通神体 ,120},
        { 阶段Type.本源体 ,1000},
    };
    public static 灵兽 砸蛋获得灵兽(QualityType qualityType)
    {
        灵兽 灵兽 = new 灵兽();
        var 灵兽typeList = 灵兽品质List[qualityType];
        灵兽.灵兽Type = 灵兽typeList[Random.Range(0, 灵兽typeList.Count)];
        灵兽.QualityType=灵兽品质[灵兽.灵兽Type];
        灵兽.元素Type = 灵兽元素[灵兽.灵兽Type];
        int 性别random = Random.Range(0, 2);
        if (性别random == 1)
        {
            灵兽.性别 = 性别.公;
        }
        else
        {
            灵兽.性别 = 性别.母;
        }

        var 血脉list = 灵兽血脉概率[qualityType];
        float count = 0;
        int index = 0;
        float 血脉random = Random.Range(0, 100f);
        血脉Type 血脉Type = 血脉Type.None;
        foreach (var item in 血脉list)
        {
            count += item;
            if (血脉random < count)
            {
                血脉Type = (血脉Type)(index + 1);
                break;
            }
            index++;
        }
        灵兽.血脉Type = 血脉Type;
        灵兽.阶段Type = 阶段Type.幼生期;
        灵兽.道龄 = 0;
        float 最大资质 = 品级最大资质[qualityType] * 血脉倍数[(int)(灵兽.血脉Type - 1)];
        灵兽.最终伤害 = Random.Range(0f, 最大资质);
        灵兽.元素伤害 = Random.Range(0f, 最大资质);
        灵兽.暴击伤害 = Random.Range(0f, 最大资质);
        float 最终伤害无暇random = Random.Range(0, 100f);
        float 暴击伤害无暇random = Random.Range(0, 100f);
        float 元素伤害无暇random = Random.Range(0, 100f);
        if (最终伤害无暇random < 1f)
        {
            灵兽.最终伤害无暇 = true;
            灵兽.最终伤害 = 最大资质;
        }
        if (暴击伤害无暇random < 1f)
        {
            灵兽.暴击伤害无暇 = true;
            灵兽.暴击伤害 = 最大资质;
        }
        if (元素伤害无暇random < 1f)
        {
            灵兽.元素伤害无暇 = true;
            灵兽.元素伤害 = 最大资质;
        }
        return 灵兽;
    }
    public static List<float> 阶段倍数 = new List<float>() { 1,2,5,10,20,50,200,1500};
    public static List<float> 血脉倍数 = new List<float>() { 1,2,5,10,20,50,200,1500};

    public static Dictionary<QualityType, float> 品级最大资质 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 10 },
        { QualityType.玄品, 20 },
        { QualityType.地品, 50 },
        { QualityType.天品, 100 },
        { QualityType.宇品, 250 },
        { QualityType.宙品, 500 },
        { QualityType.洪品, 1500 },
        { QualityType.荒品, 10000 },
    };
    public static Dictionary<QualityType, List<float>> 灵兽血脉概率 = new Dictionary<QualityType, List<float>>()
    {
        { QualityType.黄品 ,new List<float>(){100,0,0,0,0,0,0,0}},
        { QualityType.玄品 ,new List<float>(){70,30,0,0,0,0,0,0}},
        { QualityType.地品 ,new List<float>(){30,70,0,0,0,0,0,0}},
        { QualityType.天品 ,new List<float>(){10,70,20,0,0,0,0,0}},
        { QualityType.宇品 ,new List<float>(){0,50,50,0,0,0,0,0}},
        { QualityType.宙品 ,new List<float>(){0,20,70,10,0,0,0,0}},
        { QualityType.洪品 ,new List<float>(){0,0,80,20,0,0,0,0}},
        { QualityType.荒品 ,new List<float>(){0,0,55,40,5,0,0,0}},
    };
public static Dictionary<灵兽Type, string> 灵兽介绍 = new Dictionary<灵兽Type, string>()
{
    // 火焰系
    { 灵兽Type.火1, "栖息于火山灰中的小巧鼠类，尾尖常年燃着一簇火苗，受惊时会喷出火星吓退敌人。" },
    { 灵兽Type.火2, "通体赤红的狐形灵兽，三条尾巴各燃一色火焰，擅长以幻火迷惑猎物，性情狡黠而忠诚。" },
    { 灵兽Type.火3, "背覆熔岩甲壳的巨蜥，行走时足下石土焦裂，怒时脊背喷涌岩浆，是火山地带的霸主。" },
    { 灵兽Type.火4, "羽翎如焰的飞禽，振翅时洒落点点火羽，鸣声清越可引燃枯林，被视为火之吉兆。" },
    { 灵兽Type.火5, "额生赤纹的猛虎，咆哮之声震得山石崩裂，浑身皮毛如熔铁般滚烫，一击可焚尽林木。" },
    { 灵兽Type.火6, "传说中驮负九日而行的火麟兽，鳞甲映出九曜星光，蹄落之处地火翻涌，非大机缘者不可驯服。" },
    { 灵兽Type.火7, "生有赤色龙角的焚天蛟龙，腾空时云层尽染朱霞，吐息可熔金断岳，为火系蛟属之至尊。" },
    { 灵兽Type.火8, "自太初离火中涅槃而生的神凰，万火之祖，展翼则天穹赤透，其焰可焚尽诸天浊气，唯传说中可见。" },

    // 黑暗系
    { 灵兽Type.暗1, "藏身于墙隙阴影中的小鼠，能短距遁入暗影，以恐惧为食，越是在幽暗处越难捕捉。" },
    { 灵兽Type.暗2, "双瞳如夜的黑猫，可在黑暗中视物如昼，其瞳中所映之影可令敌人陷入短暂梦魇。" },
    { 灵兽Type.暗3, "结网于古墓幽穴的暗影蜘蛛，蛛丝无色无光，触之则被拖入影中，悄无声息。" },
    { 灵兽Type.暗4, "通体墨黑的冥界之鸦，栖息于枯枝坟头，其啼鸣可引来阴风，能穿梭阴阳两界传讯。" },
    { 灵兽Type.暗5, "游弋于暗渊的巨蛇，鳞片能吞噬光线，所过之处尽成墨色，被其缠绕者神魂俱沉。" },
    { 灵兽Type.暗6, "出没于幽都梦境中的貘兽，以噩梦为食，亦可吞噬敌人的记忆与斗志，令人恍惚失神。" },
    { 灵兽Type.暗7, "盘踞九幽之底的噬魂蛟，龙身覆满幽焰，所噬之魂皆化为自身之力，为冥河守门之凶物。" },
    { 灵兽Type.暗8, "太虚之中沉浮于冥河源头的烛龙，睁眼为昼闭眼为夜，吞吐幽冥之气，万魂之主，传说见之者不入轮回。" },

    // 物理系
    { 灵兽Type.物1, "外壳坚如岩石的小虫，平时蜷缩如卵石，受击时以硬化甲壳反弹伤害，是天然的活盾。" },
    { 灵兽Type.物2, "前爪覆铁般坚硬的獾类，善掘地筑巢，一爪可裂石板，性情执拗，认准的猎物绝不放弃。" },
    { 灵兽Type.物3, "臂力惊人的巨猿，能徒手掰断合抱巨木、掀翻山岩，性情暴躁，领地意识极强。" },
    { 灵兽Type.物4, "前肢化为风刃的螳形灵兽，挥刃快如疾风，可斩落飞叶于半空，一击断石而不留痕。" },
    { 灵兽Type.物5, "体型如小山般的巨犀，独角可撞塌城垣，四蹄踏地山岳震动，冲锋之势无可阻挡。" },
    { 灵兽Type.物6, "身披金鳞的狻猊灵兽，拳掌可碎金石，吼声可震慑百兽，兼有金刚不坏之躯与狮王之威。" },
    { 灵兽Type.物7, "羽翼如天罡利刃的巨鹏，一翅可裂长空，俯冲之时如陨星坠地，以纯粹之力破开万法。" },
    { 灵兽Type.物8, "传说中开天辟地之猿，肩可扛岳、掌可裂空，一怒则山河易形，为物理系灵兽之极。" },

    // 冰霜系
    { 灵兽Type.冰1, "毛茸茸如雪团的兔形灵兽，所过之处凝起薄霜，受惊时蹦跳逃窜，留下一路冰晶脚印。" },
    { 灵兽Type.冰2, "皮毛下隐现冰棱的貂类，行动敏捷如风，吐息可瞬间冻结猎物，性喜寒潭深谷。" },
    { 灵兽Type.冰3, "龟甲覆满寒潭之冰的巨龟，行动虽缓却坚不可摧，甲壳所凝之冰可反弹法术，寿元极长。" },
    { 灵兽Type.冰4, "羽白如雪、翩然起舞的仙鹤，翼间寒气缭绕，飞过之处飘落霜羽，被视为冰之祥瑞。" },
    { 灵兽Type.冰5, "通体银白的玄冰之狼，群居于雪原极地，嚎叫可引来暴风雪，獠牙所触之处尽结冰霜。" },
    { 灵兽Type.冰6, "凛冬之地的熊形魁兽，肩背覆着万年玄冰，一掌拍下可冻结方圆数丈，冬眠时化为冰川。" },
    { 灵兽Type.冰7, "游于极寒霜渊之底的鲲形巨兽，身躯横亘如岛屿，摆尾可掀起滔天冰浪，沉浮皆引极寒。" },
    { 灵兽Type.冰8, "太阴之气孕育的玄冰真龙，鳞甲皆为永冻之晶，吐息可冰封千里，为冰霜系之至尊。" },

    // 雷电系
    { 灵兽Type.电1, "腹部储有微弱电流的小虫，成群时能放出连锁电光，常于雷雨前伏于叶背充电。" },
    { 灵兽Type.电2, "皮毛间隐现紫纹的貂类，奔跑时带起细碎电弧，尾尖放电可击昏小型猎物，行动迅如闪电。" },
    { 灵兽Type.电3, "鸣声如雷的蛙形灵兽，背上纹路天然成雷符，鼓噪之时可引落小股天雷，雨夜尤盛。" },
    { 灵兽Type.电4, "翼展带电的紫电之鹰，俯冲时双翼划出电弧，可从高空引雷击地，视野所及皆在其雷霆之下。" },
    { 灵兽Type.电5, "身法如雷的豹形灵兽，奔跑时化作一道电光，足下雷纹迸发，瞬息之间可越数十丈。" },
    { 灵兽Type.电6, "栖息于雷泽的巨犀，独角如引雷之针，雷雨之时周身缠绕电网，冲撞间电光炸裂。" },
    { 灵兽Type.电7, "翱翔于九霄之上的雷鹏，双翼招引天雷，鸣叫之声伴滚滚雷音，一落则万雷随行。" },
    { 灵兽Type.电8, "混沌紫雷所化的麒麟圣兽，踏雷而行、角放紫电，其所至之处雷云自聚，为雷电系之极致。" },
};
    public static Dictionary<灵兽Type, string> 灵兽名 = new Dictionary<灵兽Type, string>()
    {
        // 火焰系
        { 灵兽Type.火1, "火绒鼠" },
        { 灵兽Type.火2, "赤焰狐" },
        { 灵兽Type.火3, "熔岩蜥" },
        { 灵兽Type.火4, "炎翎雀" },
        { 灵兽Type.火5, "焚山虎" },
        { 灵兽Type.火6, "九曜火麟" },
        { 灵兽Type.火7, "赤霄焚天蛟" },
        { 灵兽Type.火8, "太初离火神凰" },

        // 黑暗系
        { 灵兽Type.暗1, "影隙鼠" },
        { 灵兽Type.暗2, "夜瞳猫" },
        { 灵兽Type.暗3, "蚀影蛛" },
        { 灵兽Type.暗4, "冥鸦" },
        { 灵兽Type.暗5, "暗渊蛇" },
        { 灵兽Type.暗6, "幽都梦貘" },
        { 灵兽Type.暗7, "九幽噬魂蛟" },
        { 灵兽Type.暗8, "太虚冥河烛龙" },

        // 物理系
        { 灵兽Type.物1, "石甲虫" },
        { 灵兽Type.物2, "铁爪獾" },
        { 灵兽Type.物3, "裂山猿" },
        { 灵兽Type.物4, "风刃螳" },
        { 灵兽Type.物5, "撼岳犀" },
        { 灵兽Type.物6, "金身狻猊" },
        { 灵兽Type.物7, "天罡裂空鹏" },
        { 灵兽Type.物8, "盘古开岳神猿" },

        // 冰霜系
        { 灵兽Type.冰1, "霜团兔" },
        { 灵兽Type.冰2, "冰棱貂" },
        { 灵兽Type.冰3, "寒潭龟" },
        { 灵兽Type.冰4, "雪羽鹤" },
        { 灵兽Type.冰5, "玄冰狼" },
        { 灵兽Type.冰6, "凛冬熊魁" },
        { 灵兽Type.冰7, "极寒霜渊鲲" },
        { 灵兽Type.冰8, "太阴玄冰龙" },

        // 雷电系
        { 灵兽Type.电1, "电光虫" },
        { 灵兽Type.电2, "雷纹貂" },
        { 灵兽Type.电3, "鸣雷蛙" },
        { 灵兽Type.电4, "紫电鹰" },
        { 灵兽Type.电5, "奔雷豹" },
        { 灵兽Type.电6, "雷泽犀" },
        { 灵兽Type.电7, "九霄雷鹏" },
        { 灵兽Type.电8, "混沌紫雷麒麟" },
    };
    public static Dictionary<灵兽Type, YuanSuType> 灵兽元素 = new Dictionary<灵兽Type, YuanSuType>()
    {
        // 火焰系
        { 灵兽Type.火1, YuanSuType.火 },
        { 灵兽Type.火2, YuanSuType.火 },
        { 灵兽Type.火3, YuanSuType.火 },
        { 灵兽Type.火4, YuanSuType.火 },
        { 灵兽Type.火5, YuanSuType.火 },
        { 灵兽Type.火6, YuanSuType.火 },
        { 灵兽Type.火7, YuanSuType.火 },
        { 灵兽Type.火8, YuanSuType.火 },

        // 黑暗系
        { 灵兽Type.暗1, YuanSuType.黑暗 },
        { 灵兽Type.暗2, YuanSuType.黑暗 },
        { 灵兽Type.暗3, YuanSuType.黑暗 },
        { 灵兽Type.暗4, YuanSuType.黑暗 },
        { 灵兽Type.暗5, YuanSuType.黑暗 },
        { 灵兽Type.暗6, YuanSuType.黑暗 },
        { 灵兽Type.暗7, YuanSuType.黑暗 },
        { 灵兽Type.暗8, YuanSuType.黑暗 },

        // 物理系
        { 灵兽Type.物1, YuanSuType.物理 },
        { 灵兽Type.物2, YuanSuType.物理 },
        { 灵兽Type.物3, YuanSuType.物理 },
        { 灵兽Type.物4, YuanSuType.物理 },
        { 灵兽Type.物5, YuanSuType.物理 },
        { 灵兽Type.物6, YuanSuType.物理 },
        { 灵兽Type.物7, YuanSuType.物理 },
        { 灵兽Type.物8, YuanSuType.物理 },

        // 冰霜系
        { 灵兽Type.冰1, YuanSuType.冰 },
        { 灵兽Type.冰2, YuanSuType.冰 },
        { 灵兽Type.冰3, YuanSuType.冰 },
        { 灵兽Type.冰4, YuanSuType.冰 },
        { 灵兽Type.冰5, YuanSuType.冰 },
        { 灵兽Type.冰6, YuanSuType.冰 },
        { 灵兽Type.冰7, YuanSuType.冰 },
        { 灵兽Type.冰8, YuanSuType.冰 },

        // 雷电系
        { 灵兽Type.电1, YuanSuType.电 },
        { 灵兽Type.电2, YuanSuType.电 },
        { 灵兽Type.电3, YuanSuType.电 },
        { 灵兽Type.电4, YuanSuType.电 },
        { 灵兽Type.电5, YuanSuType.电 },
        { 灵兽Type.电6, YuanSuType.电 },
        { 灵兽Type.电7, YuanSuType.电 },
        { 灵兽Type.电8, YuanSuType.电 },
    };
    public static Dictionary<QualityType, List<灵兽Type>> 灵兽品质List = new Dictionary<QualityType, List<灵兽Type>>()
    {
        {
            QualityType.黄品, new List<灵兽Type>()
            {
                灵兽Type.火1, 灵兽Type.暗1, 灵兽Type.物1, 灵兽Type.冰1, 灵兽Type.电1
            }
        },
        {
            QualityType.玄品, new List<灵兽Type>()
            {
                灵兽Type.火2, 灵兽Type.暗2, 灵兽Type.物2, 灵兽Type.冰2, 灵兽Type.电2
            }
        },
        {
            QualityType.地品, new List<灵兽Type>()
            {
                灵兽Type.火3, 灵兽Type.暗3, 灵兽Type.物3, 灵兽Type.冰3, 灵兽Type.电3
            }
        },
        {
            QualityType.天品, new List<灵兽Type>()
            {
                灵兽Type.火4, 灵兽Type.暗4, 灵兽Type.物4, 灵兽Type.冰4, 灵兽Type.电4
            }
        },
        {
            QualityType.宇品, new List<灵兽Type>()
            {
                灵兽Type.火5, 灵兽Type.暗5, 灵兽Type.物5, 灵兽Type.冰5, 灵兽Type.电5
            }
        },
        {
            QualityType.宙品, new List<灵兽Type>()
            {
                灵兽Type.火6, 灵兽Type.暗6, 灵兽Type.物6, 灵兽Type.冰6, 灵兽Type.电6
            }
        },
        {
            QualityType.洪品, new List<灵兽Type>()
            {
                灵兽Type.火7, 灵兽Type.暗7, 灵兽Type.物7, 灵兽Type.冰7, 灵兽Type.电7
            }
        },
        {
            QualityType.荒品, new List<灵兽Type>()
            {
                灵兽Type.火8, 灵兽Type.暗8, 灵兽Type.物8, 灵兽Type.冰8, 灵兽Type.电8
            }
        },
    };

    public static Dictionary<灵兽Type, QualityType> 灵兽品质 = new Dictionary<灵兽Type, QualityType>()
    {
        // 火焰系
        { 灵兽Type.火1, QualityType.黄品 },
        { 灵兽Type.火2, QualityType.玄品 },
        { 灵兽Type.火3, QualityType.地品 },
        { 灵兽Type.火4, QualityType.天品 },
        { 灵兽Type.火5, QualityType.宇品 },
        { 灵兽Type.火6, QualityType.宙品 },
        { 灵兽Type.火7, QualityType.洪品 },
        { 灵兽Type.火8, QualityType.荒品 },

        // 黑暗系
        { 灵兽Type.暗1, QualityType.黄品 },
        { 灵兽Type.暗2, QualityType.玄品 },
        { 灵兽Type.暗3, QualityType.地品 },
        { 灵兽Type.暗4, QualityType.天品 },
        { 灵兽Type.暗5, QualityType.宇品 },
        { 灵兽Type.暗6, QualityType.宙品 },
        { 灵兽Type.暗7, QualityType.洪品 },
        { 灵兽Type.暗8, QualityType.荒品 },

        // 物理系
        { 灵兽Type.物1, QualityType.黄品 },
        { 灵兽Type.物2, QualityType.玄品 },
        { 灵兽Type.物3, QualityType.地品 },
        { 灵兽Type.物4, QualityType.天品 },
        { 灵兽Type.物5, QualityType.宇品 },
        { 灵兽Type.物6, QualityType.宙品 },
        { 灵兽Type.物7, QualityType.洪品 },
        { 灵兽Type.物8, QualityType.荒品 },

        // 冰霜系
        { 灵兽Type.冰1, QualityType.黄品 },
        { 灵兽Type.冰2, QualityType.玄品 },
        { 灵兽Type.冰3, QualityType.地品 },
        { 灵兽Type.冰4, QualityType.天品 },
        { 灵兽Type.冰5, QualityType.宇品 },
        { 灵兽Type.冰6, QualityType.宙品 },
        { 灵兽Type.冰7, QualityType.洪品 },
        { 灵兽Type.冰8, QualityType.荒品 },

        // 雷电系
        { 灵兽Type.电1, QualityType.黄品 },
        { 灵兽Type.电2, QualityType.玄品 },
        { 灵兽Type.电3, QualityType.地品 },
        { 灵兽Type.电4, QualityType.天品 },
        { 灵兽Type.电5, QualityType.宇品 },
        { 灵兽Type.电6, QualityType.宙品 },
        { 灵兽Type.电7, QualityType.洪品 },
        { 灵兽Type.电8, QualityType.荒品 },
    };

    public static List<float> 灵兽蛋概率 = new List<float>()
    {
        5500,2500,1200,500,200,89f,10f,1f
    };

}
