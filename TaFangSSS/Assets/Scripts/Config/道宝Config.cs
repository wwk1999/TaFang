using System.Collections.Generic;
using Config;

public enum 道宝Quality
{
    None,
    混沌至宝,
    功德至宝,
    先天至宝,
    先天灵宝,
    后天法宝,
}

public enum 道宝属性Type
{
    None,
    不周山速度,
    血海速度,
    世界树速度,
    通天塔速度,
    
    战士伤害,
    控制伤害,
    射手伤害,
    法师伤害,
    暴击率,
    最终伤害,
}
public class 羁绊配置
{
    public 羁绊Type 类型 { get; set; }
    public 道宝Quality 品质 { get; set; }          // 直接使用道宝Quality
    public string 名称 { get; set; }
    public string 描述 { get; set; }
    public List<道宝Type> 所需道宝列表 { get; set; }
    public string 效果描述 { get; set; } // Key: 触发件数, Value: 效果文本
}
public enum 羁绊Type
{
    // ==================== 混沌至宝羁绊（1个）====================
    混沌归元,           // 混沌青莲 + 造化玉碟 + 混沌珠 + 开天斧

    // ==================== 先天至宝羁绊（2个）====================
    诛仙剑阵,          
    开天辟地,           

    // ==================== 功德至宝羁绊（3个）====================
    圣德光辉,           
    造化乾坤,           // 炼妖壶 + 乾坤鼎 + 玉净瓶
    菩提风火,           // 菩提妙树 + 风火轮 + 河图洛书

    // ==================== 先天灵宝羁绊（3个）====================
    天地人,         // 天书 + 地书 + 冥书
    山河七宝,           // 山河社稷图 + 七宝妙树
    弑神定海,           

    翻海断岳,           
    五行飞仙斩,         
    照落金莲,           
    紫金断岳,           
    五方照落,          
}
public enum 道宝Type
{
    None,
    山河社稷图,
    七宝妙树,
    天书,
    地书,
    弑神枪,
    冥书,
    定海神珠,
    河图洛书,
    
    翻天印,
    紫金葫芦,
    金蛟剪,
    斩仙飞刀,
    五色神光,
    宝莲灯,
    落宝金钱,
    先天五方旗,
    
    混沌青莲,
    造化玉碟,
    混沌珠,
    开天斧,
    
    盘古幡,
    混沌钟,
    诛仙剑,
    戮仙剑,
    陷仙剑,
    绝仙剑,
    乾坤鼎,
    菩提妙树,
    
    玲珑塔,
    炼妖壶,
    女娲石,
    轩辕剑,
    玉净瓶,
    照妖镜,
    风火轮,
    如意金箍棒,
}
public class 道宝Config
{
    public static float Get道宝总修炼速度()
    {
        float value = 0;
        foreach (var item in 道宝品质Dic)
        {
            switch (item.Value)
            {
                case 道宝Quality.后天法宝:
                    value+=PlayerData.S.道宝LevelDic[item.Key]*单件升级奖励Dic[0];
                    break;
                case 道宝Quality.先天灵宝:
                    value+=PlayerData.S.道宝LevelDic[item.Key]*单件升级奖励Dic[1];
                    break;
                case 道宝Quality.功德至宝:
                    value+=PlayerData.S.道宝LevelDic[item.Key]*单件升级奖励Dic[2];
                    break;
                case 道宝Quality.先天至宝:
                    value+=PlayerData.S.道宝LevelDic[item.Key]*单件升级奖励Dic[3];
                    break;
                case 道宝Quality.混沌至宝:
                    value+=PlayerData.S.道宝LevelDic[item.Key]*单件升级奖励Dic[4];
                    break;
            }
        }

        return value;
    }
    public static List<float> 单件升级奖励Dic = new List<float>() {1,5,30,200,1500 };

    public static Dictionary<道宝Type, string> 道宝InfoDic = new Dictionary<道宝Type, string>()
    {
        { 道宝Type.None, "无" },
        { 道宝Type.山河社稷图, "内含山川河流，可困锁万物生灵，演化真实世界，变化无穷。" },
        { 道宝Type.七宝妙树, "准提道人证道至宝，七色神光无物不刷，可落尽天下法宝。" },
        { 道宝Type.天书, "即封神榜，可敕封天地神祇，定三界神位秩序，掌天庭运转。" },
        { 道宝Type.地书, "大地胎膜所化，可掌山河地脉，防御无双，立于大地便不败。" },
        { 道宝Type.弑神枪, "洪荒凶煞第一杀器，专克神魔金仙，锋芒过处神魂俱灭。" },
        { 道宝Type.冥书, "即生死簿，掌幽冥众生寿元生死，断六道轮回因果报应。" },
        { 道宝Type.定海神珠, "可定四海之水，化为二十四诸天世界，珠光一照群魔伏。" },
        { 道宝Type.河图洛书, "伏羲推演天机之宝，包罗星象地理，万物变化尽在其中。" },
    
        { 道宝Type.翻天印, "元始天尊以半截不周山所炼，一击之下山崩地裂，势不可挡。" },
        { 道宝Type.紫金葫芦, "太上老君盛丹之物，呼名应声即收，任你神通广大也难逃。" },
        { 道宝Type.金蛟剪, "两条金蛟所化，剪断世间一切法器，锋芒锐利无可匹敌。" },
        { 道宝Type.斩仙飞刀, "陆压道君压箱至宝，斩仙杀佛只需一声，出手必中毫无虚发。" },
        { 道宝Type.五色神光, "孔宣本命神通，五行之内无物不刷，圣人之下一刷即擒。" },
        { 道宝Type.宝莲灯, "女娲娘娘赐予三圣母，圣光护体辟万邪，明灯照处妖魔退散。" },
        { 道宝Type.落宝金钱, "先天灵宝，专落天下法宝兵器，任凭至宝遇之亦坠地失灵。" },
        { 道宝Type.先天五方旗, "青黄赤白黑五旗镇守五方，攻防兼备，布阵可定洪荒地水火风。" },
    
        { 道宝Type.混沌青莲, "创世之初第一莲，孕育盘古大神，万莲之祖，混沌本源所化。" },
        { 道宝Type.造化玉碟, "鸿钧道祖执掌之物，蕴含天地造化玄机，主掌天道法则运行。" },
        { 道宝Type.混沌珠, "内含完整混沌世界，可定地水火风，重开天地，自成宇宙乾坤。" },
        { 道宝Type.开天斧, "盘古开天辟地之神器，一斧破开混沌鸿蒙，奠定洪荒根基。" },
    
        { 道宝Type.盘古幡, "盘古三宝之一，撕裂混沌开天辟地，攻击至宝威震洪荒万古。" },
        { 道宝Type.混沌钟, "东皇太一伴生至宝，镇压鸿蒙逆转时空，钟声响彻三十三天。" },
        { 道宝Type.诛仙剑, "诛仙四剑之首，非四圣不可破，杀伐凶威冠绝洪荒第一剑。" },
        { 道宝Type.戮仙剑, "诛仙四剑之一，杀意凛然剑气凌霄，斩仙屠魔只在瞬息之间。" },
        { 道宝Type.陷仙剑, "诛仙四剑之一，剑光所过陷落众生，入剑阵者神魂皆坠无间。" },
        { 道宝Type.绝仙剑, "诛仙四剑之一，绝灭一切生机，霸道剑气横扫九天十地。" },
        { 道宝Type.乾坤鼎, "可炼化万物返本归元，定鼎一方天地乾坤，造化无穷妙用。" },
        { 道宝Type.菩提妙树, "准提道人悟道之树，静心明性万法不侵，一叶一菩提皆大道。" },
    
        { 道宝Type.玲珑塔, "托塔天王李靖掌中至宝，层层镇压妖魔邪祟，威势如山不可撼。" },
        { 道宝Type.炼妖壶, "壶中自成天地，炼化万妖返本归元，妖族闻之无不胆寒。" },
        { 道宝Type.女娲石, "女娲补天所遗五彩灵石，可起死回生，灵性通天蕴含造化玄奇。" },
        { 道宝Type.轩辕剑, "黄帝斩蚩尤之圣道神兵，人皇之剑，正气浩然斩尽天下妖邪。" },
        { 道宝Type.玉净瓶, "观音大士持之普渡众生，甘露一滴起死回生，净水洒处万物复苏。" },
        { 道宝Type.照妖镜, "可照破一切妖魔原形，任你变化万千亦难遁形，明察秋毫之末。" },
        { 道宝Type.风火轮, "哪吒足下灵宝，脚踏风火日行万里，飞腾九天灵动非凡至极。" },
        { 道宝Type.如意金箍棒, "大禹定海神针，可大可小随心如意，齐天大圣横扫九天之兵。" },
    };
    public static float 羁绊黑暗伤害增幅 => Get羁绊Level(羁绊Type.翻海断岳) * 5;
    public static float 羁绊火焰伤害增幅 => Get羁绊Level(羁绊Type.五方照落) * 5;
    public static float 羁绊雷电伤害增幅 => Get羁绊Level(羁绊Type.照落金莲) * 5;
    public static float 羁绊物理伤害增幅 => Get羁绊Level(羁绊Type.五行飞仙斩) * 5;
    public static float 羁绊冰霜伤害增幅 => Get羁绊Level(羁绊Type.紫金断岳) * 5;
    
    public static float 羁绊法师伤害增幅 => Get羁绊Level(羁绊Type.天地人) * 5;
    public static float 羁绊战士伤害增幅 => Get羁绊Level(羁绊Type.弑神定海) * 5;
    public static float 羁绊射手伤害增幅 => Get羁绊Level(羁绊Type.山河七宝) * 5;
    
    public static float 羁绊暴击率 => Get羁绊Level(羁绊Type.造化乾坤) * 5;
    public static float 羁绊伤害减免 => Get羁绊Level(羁绊Type.圣德光辉) * 5;
    public static float 羁绊最终伤害 => Get羁绊Level(羁绊Type.菩提风火) * 5;
    
    public static float 羁绊灵气 => Get羁绊Level(羁绊Type.开天辟地) * 10;
    public static float 羁绊功德 => Get羁绊Level(羁绊Type.诛仙剑阵) * 10;
    
    public static float 羁绊寻宝速度=> Get羁绊Level(羁绊Type.混沌归元) * 10;

     public static Dictionary<羁绊Type, 羁绊配置> 羁绊配置 = new Dictionary<羁绊Type, 羁绊配置>()
    {
         {
            羁绊Type.翻海断岳, new 羁绊配置
            {
                类型 = 羁绊Type.翻海断岳,
                品质 = 道宝Quality.后天法宝,
                名称 = "翻海断岳",
                描述 = "翻天印动山河碎，金蛟剪落因果断，五方旗镇气运长。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.翻天印,
                    道宝Type.金蛟剪,
                    道宝Type.先天五方旗,
                },
                效果描述 = "每级提供5%的黑暗伤害增幅"
            }
        },
        {
            羁绊Type.五行飞仙斩, new 羁绊配置
            {
                类型 = 羁绊Type.五行飞仙斩,
                品质 = 道宝Quality.后天法宝,
                名称 = "五行飞仙斩",
                描述 = "五色神光刷万法，斩仙飞刀取首级，紫金葫芦纳乾坤。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.斩仙飞刀,
                    道宝Type.五色神光,
                    道宝Type.紫金葫芦,
                },
                效果描述 = "每级提供5%的物理伤害增幅"
            }
        },
        {
            羁绊Type.照落金莲, new 羁绊配置
            {
                类型 = 羁绊Type.照落金莲,
                品质 = 道宝Quality.后天法宝,
                名称 = "照落金莲",
                描述 = "宝莲灯照破三千迷障，落宝金钱落尽万般法宝，照妖镜显诸邪原形。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.宝莲灯,
                    道宝Type.落宝金钱,
                    道宝Type.照妖镜,
                },
                效果描述 = "每级提供5%的雷霆伤害增幅"
            }
        },
        {
            羁绊Type.紫金断岳, new 羁绊配置
            {
                类型 = 羁绊Type.紫金断岳,
                品质 = 道宝Quality.后天法宝,
                名称 = "紫金断岳",
                描述 = "紫金葫芦吞天纳地，金蛟剪断因果轮回，金箍棒横扫十万天兵。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.紫金葫芦,
                    道宝Type.金蛟剪,
                    道宝Type.如意金箍棒,
                },
                效果描述 = "每级提供5%的冰霜伤害增幅"
            }
        },
        {
            羁绊Type.五方照落, new 羁绊配置
            {
                类型 = 羁绊Type.五方照落,
                品质 = 道宝Quality.后天法宝,
                名称 = "五方照落",
                描述 = "五方旗镇守气运，照妖镜洞察诸邪，翻天印碎山河万岳。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.先天五方旗,
                    道宝Type.照妖镜,
                    道宝Type.翻天印,
                },
                效果描述 = "每级提供5%的火焰伤害增幅"
            }
        },
        
        // ==================== 先天灵宝级 ====================
        {
            羁绊Type.天地人, new 羁绊配置
            {
                类型 = 羁绊Type.天地人,
                品质 = 道宝Quality.先天灵宝,
                名称 = "天地人三书",
                描述 = "天书封神定天规，地书镇岳安地脉，冥书度鬼判轮回。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.天书,
                    道宝Type.地书,
                    道宝Type.冥书,
                },
                效果描述 = "每级提供5%法师伤害增幅"
            }
        },
        {
            羁绊Type.山河七宝, new 羁绊配置
            {
                类型 = 羁绊Type.山河七宝,
                品质 = 道宝Quality.先天灵宝,
                名称 = "山河七宝",
                描述 = "山河社稷图藏万象，七宝妙树刷尽诸天法。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.山河社稷图,
                    道宝Type.七宝妙树,
                },
                效果描述 = "每级提供5%射手伤害增幅"
            }
        },
        {
            羁绊Type.弑神定海, new 羁绊配置
            {
                类型 = 羁绊Type.弑神定海,
                品质 = 道宝Quality.先天灵宝,
                名称 = "弑神定海",
                描述 = "弑神枪出鬼神惊，定海珠落四海平。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.弑神枪,
                    道宝Type.定海神珠,
                },
                效果描述 = "每级提供5%战士伤害增幅"
            }
        },
        
        // ==================== 功德级 ====================
        {
            羁绊Type.圣德光辉, new 羁绊配置
            {
                类型 = 羁绊Type.圣德光辉,
                品质 = 道宝Quality.功德至宝,
                名称 = "圣德光辉",
                描述 = "玲珑塔镇八方气运，轩辕剑斩九幽邪魔，女娲石补天地残缺。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.玲珑塔,
                    道宝Type.轩辕剑,
                    道宝Type.女娲石,
                },
                效果描述 = "每级提供5%城墙伤害减免"
            }
        },
        {
            羁绊Type.造化乾坤, new 羁绊配置
            {
                类型 = 羁绊Type.造化乾坤,
                品质 = 道宝Quality.功德至宝,
                名称 = "造化乾坤",
                描述 = "炼妖壶收尽天下妖，乾坤鼎炼化万物灵，玉净瓶甘露济苍生。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.炼妖壶,
                    道宝Type.乾坤鼎,
                    道宝Type.玉净瓶,
                },
                效果描述 = "每级提供5%暴击率"
            }
        },
        {
            羁绊Type.菩提风火, new 羁绊配置
            {
                类型 = 羁绊Type.菩提风火,
                品质 = 道宝Quality.功德至宝,
                名称 = "菩提风火",
                描述 = "菩提妙树悟大道，风火轮转踏九霄，河图洛书演天机。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.菩提妙树,
                    道宝Type.风火轮,
                    道宝Type.河图洛书,
                },
                效果描述 = "每级提供5%最终伤害增幅"
            }
        },
        
        // ==================== 先天级 ====================
        {
            羁绊Type.诛仙剑阵, new 羁绊配置
            {
                类型 = 羁绊Type.诛仙剑阵,
                品质 = 道宝Quality.先天至宝,
                名称 = "诛仙剑阵",
                描述 = "诛戮陷绝四剑横，非圣难破此阵门。剑气纵横三万里，一剑光寒十九洲。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.诛仙剑,
                    道宝Type.戮仙剑,
                    道宝Type.陷仙剑,
                    道宝Type.绝仙剑,
                },
                效果描述 = "每级增加主线关卡10%功德数量"
            }
        },
        {
            羁绊Type.开天辟地, new 羁绊配置
            {
                类型 = 羁绊Type.开天辟地,
                品质 = 道宝Quality.先天至宝,
                名称 = "开天辟地",
                描述 = "盘古幡摇动地水火风，混沌钟鸣镇洪荒万界。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.盘古幡,
                    道宝Type.混沌钟,
                },
                效果描述 = "每级增加主线关卡10%灵气数量"
            }
        },
        // ==================== 混沌级 ====================
        {
            羁绊Type.混沌归元, new 羁绊配置
            {
                类型 = 羁绊Type.混沌归元,
                品质 = 道宝Quality.混沌至宝,
                名称 = "混沌归元",
                描述 = "混沌青莲绽造化，玉碟天机演玄黄。混沌珠内藏宇宙，开天斧出定洪荒。",
                所需道宝列表 = new List<道宝Type>
                {
                    道宝Type.混沌青莲,
                    道宝Type.造化玉碟,
                    道宝Type.混沌珠,
                    道宝Type.开天斧,
                },
                效果描述 = "每级增加秘境关卡10%寻宝速度"
            }
        },
    };
     
    public static Dictionary<道宝Quality, string> 道宝QualityNameDic = new Dictionary<道宝Quality, string>()
    {
        { 道宝Quality.混沌至宝 ,"混沌至宝"},
        { 道宝Quality.先天至宝 ,"先天至宝"},
        { 道宝Quality.功德至宝 ,"功德至宝"},
        { 道宝Quality.先天灵宝 ,"先天灵宝"},
        { 道宝Quality.后天法宝 ,"后天法宝"},
    };
    public static int Get羁绊Level(羁绊Type type)
    {
        int value = int.MaxValue;
        foreach (var item in 道宝Config.羁绊配置[type].所需道宝列表)
        {
            if (PlayerData.S.道宝LevelDic[item] < value)
            {
                value = PlayerData.S.道宝LevelDic[item];
            }
        }

        return value;
    }
    public static Dictionary<道宝Quality, QualityType> 道宝QualityToQuality = new Dictionary<道宝Quality, QualityType>()
    {
        { 道宝Quality.混沌至宝 ,QualityType.荒品},
        { 道宝Quality.先天至宝 ,QualityType.洪品},
        { 道宝Quality.功德至宝 ,QualityType.宙品},
        { 道宝Quality.先天灵宝 ,QualityType.宇品},
        { 道宝Quality.后天法宝 ,QualityType.天品},
    };
    
    public static Dictionary< QualityType,道宝Quality> QualityTo道宝Quality = new Dictionary<QualityType,道宝Quality>()
    {
        { QualityType.荒品,道宝Quality.混沌至宝 },
        { QualityType.洪品,道宝Quality.先天至宝},
        {  QualityType.宙品,道宝Quality.功德至宝},
        {  QualityType.宇品,道宝Quality.先天灵宝},
        {  QualityType.天品,道宝Quality.后天法宝},
    };

    public static Dictionary<道宝Type, string> 道宝NameDic = new Dictionary<道宝Type, string>()
    {
        // ==================== 混沌至宝（4个）====================
        { 道宝Type.混沌青莲, "混沌青莲" },
        { 道宝Type.造化玉碟, "造化玉碟" },
        { 道宝Type.混沌珠, "混沌珠" },
        { 道宝Type.开天斧, "开天斧" },

        // ==================== 先天至宝（6个）====================
        { 道宝Type.盘古幡, "盘古幡" },
        { 道宝Type.混沌钟, "混沌钟" },
        { 道宝Type.诛仙剑, "诛仙剑" },
        { 道宝Type.戮仙剑, "戮仙剑" },
        { 道宝Type.陷仙剑, "陷仙剑" },
        { 道宝Type.绝仙剑, "绝仙剑" },

        // ==================== 功德至宝（8个）====================
        { 道宝Type.玲珑塔, "玲珑塔" },
        { 道宝Type.轩辕剑, "轩辕剑" },
        { 道宝Type.女娲石, "女娲石" },
        { 道宝Type.炼妖壶, "炼妖壶" },
        { 道宝Type.玉净瓶, "玉净瓶" },
        { 道宝Type.乾坤鼎, "乾坤鼎" },
        { 道宝Type.菩提妙树, "菩提妙树" },
        { 道宝Type.风火轮, "风火轮" },

        // ==================== 先天灵宝（8个）====================
        { 道宝Type.山河社稷图, "山河社稷图" },
        { 道宝Type.七宝妙树, "七宝妙树" },
        { 道宝Type.天书, "天书" },
        { 道宝Type.地书, "地书" },
        { 道宝Type.冥书, "冥书" },
        { 道宝Type.弑神枪, "弑神枪" },
        { 道宝Type.定海神珠, "定海神珠" },
        { 道宝Type.河图洛书, "河图洛书" },

        // ==================== 后天法宝（10个）====================
        { 道宝Type.翻天印, "翻天印" },
        { 道宝Type.紫金葫芦, "紫金葫芦" },
        { 道宝Type.金蛟剪, "金蛟剪" },
        { 道宝Type.斩仙飞刀, "斩仙飞刀" },
        { 道宝Type.五色神光, "五色神光" },
        { 道宝Type.宝莲灯, "宝莲灯" },
        { 道宝Type.落宝金钱, "落宝金钱" },
        { 道宝Type.先天五方旗, "先天五方旗" },
        { 道宝Type.照妖镜, "照妖镜" },
        { 道宝Type.如意金箍棒, "如意金箍棒" },
    };
    public static Dictionary<道宝Quality, List<道宝Type>> 道宝品质列表 = new Dictionary<道宝Quality, List<道宝Type>>()
    {
        // ==================== 混沌至宝（4个）====================
        {
            道宝Quality.混沌至宝, new List<道宝Type>()
            {
                道宝Type.混沌青莲,
                道宝Type.造化玉碟,
                道宝Type.混沌珠,
                道宝Type.开天斧,
            }
        },

        // ==================== 先天至宝（6个）====================
        {
            道宝Quality.先天至宝, new List<道宝Type>()
            {
                道宝Type.盘古幡,
                道宝Type.混沌钟,
                道宝Type.诛仙剑,
                道宝Type.戮仙剑,
                道宝Type.陷仙剑,
                道宝Type.绝仙剑,
            }
        },

        // ==================== 功德至宝（8个）====================
        {
            道宝Quality.功德至宝, new List<道宝Type>()
            {
                道宝Type.玲珑塔,
                道宝Type.轩辕剑,
                道宝Type.女娲石,
                道宝Type.炼妖壶,
                道宝Type.玉净瓶,
                道宝Type.乾坤鼎,
                道宝Type.菩提妙树,
                道宝Type.风火轮,
            }
        },

        // ==================== 先天灵宝（8个）====================
        {
            道宝Quality.先天灵宝, new List<道宝Type>()
            {
                道宝Type.山河社稷图,
                道宝Type.七宝妙树,
                道宝Type.天书,
                道宝Type.地书,
                道宝Type.冥书,
                道宝Type.弑神枪,
                道宝Type.定海神珠,
                道宝Type.河图洛书,
            }
        },

        // ==================== 后天法宝（10个）====================
        {
            道宝Quality.后天法宝, new List<道宝Type>()
            {
                道宝Type.翻天印,
                道宝Type.紫金葫芦,
                道宝Type.金蛟剪,
                道宝Type.斩仙飞刀,
                道宝Type.五色神光,
                道宝Type.宝莲灯,
                道宝Type.落宝金钱,
                道宝Type.先天五方旗,
                道宝Type.照妖镜,
                道宝Type.如意金箍棒,
            }
        },
    };
    public static Dictionary<道宝Type, 道宝Quality> 道宝品质Dic = new Dictionary<道宝Type, 道宝Quality>()
    {
        // ==================== 混沌至宝（4个）====================
        { 道宝Type.混沌青莲, 道宝Quality.混沌至宝 },
        { 道宝Type.造化玉碟, 道宝Quality.混沌至宝 },
        { 道宝Type.混沌珠,   道宝Quality.混沌至宝 },
        { 道宝Type.开天斧,   道宝Quality.混沌至宝 },

        // ==================== 先天至宝（6个）====================
        { 道宝Type.盘古幡,   道宝Quality.先天至宝 },
        { 道宝Type.混沌钟,   道宝Quality.先天至宝 },
        { 道宝Type.诛仙剑,   道宝Quality.先天至宝 },
        { 道宝Type.戮仙剑,   道宝Quality.先天至宝 },
        { 道宝Type.陷仙剑,   道宝Quality.先天至宝 },
        { 道宝Type.绝仙剑,   道宝Quality.先天至宝 },

        { 道宝Type.玲珑塔,   道宝Quality.功德至宝 },
        { 道宝Type.轩辕剑,   道宝Quality.功德至宝 },
        { 道宝Type.女娲石,   道宝Quality.功德至宝 },
        { 道宝Type.炼妖壶,   道宝Quality.功德至宝 },
        { 道宝Type.玉净瓶,   道宝Quality.功德至宝 },
        { 道宝Type.乾坤鼎,   道宝Quality.功德至宝 },   // 补天功德，归入功德至宝
        { 道宝Type.菩提妙树, 道宝Quality.功德至宝 },   // 准提证道，有功德加持
        { 道宝Type.风火轮,   道宝Quality.功德至宝 },   // 哪吒功绩所化

        { 道宝Type.山河社稷图, 道宝Quality.先天灵宝 },
        { 道宝Type.七宝妙树,   道宝Quality.先天灵宝 },
        { 道宝Type.天书,       道宝Quality.先天灵宝 },
        { 道宝Type.地书,       道宝Quality.先天灵宝 },
        { 道宝Type.冥书,       道宝Quality.先天灵宝 },
        { 道宝Type.弑神枪,     道宝Quality.先天灵宝 },
        { 道宝Type.定海神珠,   道宝Quality.先天灵宝 },
        { 道宝Type.河图洛书,   道宝Quality.先天灵宝 },

        { 道宝Type.翻天印,     道宝Quality.后天法宝 },
        { 道宝Type.紫金葫芦,   道宝Quality.后天法宝 },
        { 道宝Type.金蛟剪,     道宝Quality.后天法宝 },
        { 道宝Type.斩仙飞刀,   道宝Quality.后天法宝 },
        { 道宝Type.五色神光,   道宝Quality.后天法宝 },
        { 道宝Type.宝莲灯,     道宝Quality.后天法宝 },
        { 道宝Type.落宝金钱,   道宝Quality.后天法宝 },
        { 道宝Type.先天五方旗, 道宝Quality.后天法宝 },
        { 道宝Type.照妖镜,     道宝Quality.后天法宝 },
        { 道宝Type.如意金箍棒, 道宝Quality.后天法宝 },
    };
}
