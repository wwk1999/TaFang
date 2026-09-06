using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public enum 关卡类型
{
    None,
    主线关卡,
    洞天秘境,//突破灵物
    远古遗迹,
}
public enum 主线关卡Type
{
    None,
    花果山,
    水帘洞,
    蓬莱仙岛,
    五行山,
    傲来国,
    高老庄, 
    女儿国,
    小雷音寺,
    平顶山,
    火焰山, 
    芭蕉洞,
    流沙河,
    狮驼岭,
    东海龙宫,
    冥府,
    
    南天门,//16
    瑶池仙境,
    斩妖台,
    御马监,
    蟠桃园,
    兜率宫,
    紫微宫,
    昊天殿,
    
    登天路,//24
    欲界天,
    色界天,
    无色天,
    四梵天,
    上清境禹余天,
    玉清境清微天,
    太清境大赤天,
    大罗天,
    
    混沌虚空,
}
public class LevelDiaoLuo
{
    public long maxCount;
    public long minCount;
    public PropType PropType;
}

public class minmax
{
    public long min;
    public long max;
}

public class SmallLevelInfo
{
    public int NormalMonsterCount;
    public float CreateNormalMonsterTime;
    public int EliteMonsterCount;
}

public class 洞天关卡胜利奖励
{
    public long 灵魂;
    public long 功德;
    public List<灵物item> List;
}
public class 普通关卡胜利奖励
{
    public long 灵魂;
    public long 功德;
    public long 射手经验值;
    public long 法师经验值;
    public long 战士经验值;
    public long 辅助经验值;
    public long 控制经验值;
    public long 衣服锻造石;
    public long 鞋子锻造石;
    public long 头盔锻造石;
    public long 项链锻造石;
    public long 戒指锻造石;
    public long 护手锻造石;
    public long 招募卷;
    public long 高级招募卷;
    public long 洗练石;
}

public class LevelConfig : MonoBehaviour
{
    public static 关卡类型 当前关卡类型 = 关卡类型.主线关卡;
    public static 主线关卡Type 当前主线关卡Type = 主线关卡Type.花果山;
    public static QualityType 当前洞天QualityType = QualityType.黄品;
    public static 神物Type 当前神物Type = 神物Type.最终伤害;

    public static bool Is混沌虚空=false;
    public static int 战斗混沌虚空层数 = 1;
    public static Dictionary<主线关卡Type, int> 主线关卡通关奖励Dic = new Dictionary<主线关卡Type, int>()
    {
        { 主线关卡Type.花果山, 5 },
        { 主线关卡Type.水帘洞, 5 },
        { 主线关卡Type.蓬莱仙岛, 10 },
        { 主线关卡Type.五行山, 10 },
        { 主线关卡Type.傲来国, 15 },
        { 主线关卡Type.高老庄, 15 },
        { 主线关卡Type.女儿国, 20 },
        { 主线关卡Type.小雷音寺, 20 },
        { 主线关卡Type.平顶山, 25 },
        { 主线关卡Type.火焰山, 25 },
        { 主线关卡Type.芭蕉洞, 30 },
        { 主线关卡Type.流沙河, 30 },
        { 主线关卡Type.狮驼岭, 35 },
        { 主线关卡Type.东海龙宫,35 },
        { 主线关卡Type.冥府,40 },
        { 主线关卡Type.南天门, 40 },
        { 主线关卡Type.瑶池仙境, 40 },
        { 主线关卡Type.斩妖台, 45 },
        { 主线关卡Type.御马监, 45 },
        { 主线关卡Type.蟠桃园, 50 },
        { 主线关卡Type.兜率宫, 50 },
        { 主线关卡Type.紫微宫, 55 },
        { 主线关卡Type.昊天殿, 55 },
        
        { 主线关卡Type.登天路, 60 },
        { 主线关卡Type.欲界天, 60 },
        { 主线关卡Type.色界天, 65 },
        { 主线关卡Type.无色天, 65 },
        { 主线关卡Type.四梵天, 65 },
        { 主线关卡Type.玉清境清微天, 70 },
        { 主线关卡Type.上清境禹余天, 70 },
        { 主线关卡Type.太清境大赤天, 70 },
        { 主线关卡Type.大罗天, 80 },
        { 主线关卡Type.混沌虚空, 100 },
    };
    public static Dictionary<主线关卡Type, JingJieType> 主线关卡境界Dic = new Dictionary<主线关卡Type, JingJieType>()
    {
        { 主线关卡Type.花果山, JingJieType.练气 },
        { 主线关卡Type.水帘洞, JingJieType.练气 }, 
        { 主线关卡Type.蓬莱仙岛, JingJieType.筑基 },
        { 主线关卡Type.五行山, JingJieType.筑基 },
        { 主线关卡Type.傲来国, JingJieType.金丹 },
        { 主线关卡Type.高老庄, JingJieType.金丹 },
        { 主线关卡Type.女儿国, JingJieType.元婴 },
        { 主线关卡Type.小雷音寺, JingJieType.元婴 },
        { 主线关卡Type.平顶山, JingJieType.化神 },
        { 主线关卡Type.火焰山, JingJieType.化神 },
        { 主线关卡Type.芭蕉洞, JingJieType.合体 },
        { 主线关卡Type.流沙河, JingJieType.合体 },
        { 主线关卡Type.狮驼岭, JingJieType.大乘 },
        { 主线关卡Type.东海龙宫,JingJieType.大乘 },
        { 主线关卡Type.冥府, JingJieType.大乘 },
        { 主线关卡Type.南天门, JingJieType.天仙 },
        { 主线关卡Type.瑶池仙境, JingJieType.天仙 },
        { 主线关卡Type.斩妖台, JingJieType.天仙 },
        { 主线关卡Type.御马监, JingJieType.玄仙 },
        { 主线关卡Type.蟠桃园, JingJieType.玄仙 },
        { 主线关卡Type.兜率宫, JingJieType.金仙 },
        { 主线关卡Type.紫微宫, JingJieType.金仙 },
        { 主线关卡Type.昊天殿, JingJieType.金仙 },
        
        { 主线关卡Type.登天路, JingJieType.太乙金仙 },
        { 主线关卡Type.欲界天, JingJieType.太乙金仙 },
        { 主线关卡Type.色界天, JingJieType.大罗金仙 },
        { 主线关卡Type.无色天, JingJieType.大罗金仙 },
        { 主线关卡Type.四梵天, JingJieType.大罗金仙 },
        { 主线关卡Type.玉清境清微天, JingJieType.准圣 },
        { 主线关卡Type.上清境禹余天, JingJieType.准圣 },
        { 主线关卡Type.太清境大赤天, JingJieType.准圣 },
        { 主线关卡Type.大罗天, JingJieType.圣人 },
        { 主线关卡Type.混沌虚空, JingJieType.圣人 },
    };
   public static Dictionary<主线关卡Type, string> 主线关卡介绍Dic = new Dictionary<主线关卡Type, string>()
{
    { 主线关卡Type.花果山, "美猴王诞生之地，十洲之祖脉，三岛之来龙。群山叠翠，灵猴嬉戏，仙气缭绕，孕育天地灵根之处。" },
    { 主线关卡Type.水帘洞, "花果山福地，水帘洞洞天。飞瀑倒挂，隐有石室，乃齐天大圣昔日称王之所，内有石桌石椅，别有洞天。" },
    { 主线关卡Type.蓬莱仙岛, "东海三仙山之一，琼楼玉宇，遍地灵芝。岛上白鹤飞舞，仙雾弥漫，乃海外仙人聚居修行的清静圣地。" },
    { 主线关卡Type.五行山, "如来五指所化神山，分金木水火土五形。山下压有神猴，仅露头颅，山势险峻，上有镇压封印之贴。" },
    { 主线关卡Type.傲来国, "东胜神洲海外小国，花果山近邻。国中百姓以渔猎为生，市井喧嚣，常闻海上仙山奇闻异事。" },
    { 主线关卡Type.高老庄, "乌斯藏国富庶庄园，庄主高太公宅邸。良田千顷，屋舍俨然，因猪妖入赘一事而名扬四海。" },
    { 主线关卡Type.女儿国, "西梁女国，一国尽是红粉。城中街道繁华，女子当政，民风奇特，城外有子母河，饮者皆孕。" },
    { 主线关卡Type.小雷音寺, "黄眉怪幻化之小西天，庙宇巍峨，禅音阵阵，实则处处陷阱。内有金铙、人种袋等佛门法宝。" },
    { 主线关卡Type.平顶山, "山脉连绵，峰峦如削，山上松柏苍翠，山中藏有莲花洞。金角银角二妖据守此山，拦路索宝。" },
    { 主线关卡Type.火焰山, "八百里火焰，无春无秋，四季皆热。赤地千里，寸草不生，唯有铁扇公主之宝扇可灭此烈火。" },
    { 主线关卡Type.芭蕉洞, "翠云山深处幽洞，铁扇公主修炼洞府。洞前芭蕉茂密，洞内阴凉幽静，藏有先天至宝芭蕉扇。" },
    { 主线关卡Type.流沙河, "八百余里宽，鹅毛浮不起，芦花定底沉。弱水三千，汹涌澎湃，河中隐有妖魔兴风作浪。" },
    { 主线关卡Type.狮驼岭, "八百里狮驼岭，白骨嶙峋，妖气冲天。青狮、白象、大鹏三魔在此结盟，为西天路上最凶险之地。" },
    { 主线关卡Type.东海龙宫, "水晶宫中明珠闪烁，珊瑚成林。龙王敖广坐镇于此，藏有如意金箍棒定海神针，虾兵蟹将无数。" },
    { 主线关卡Type.冥府, "幽暗地界，阴风阵阵，鬼门关后便是幽冥地府。内有判官生死簿，十殿阎罗执掌生死轮回。" },

    // ==================== 天庭篇（凌霄宝殿十大关） ====================
    { 主线关卡Type.南天门, "天庭正南门户，巍峨凌云，金瓦流光。四大天王分守四方，门内瑞气千条，门外红尘万丈，凡圣自此隔绝。" },
    { 主线关卡Type.瑶池仙境, "王母娘娘瑶池胜境，碧波万顷，莲开并蒂。蟠桃灵根遍植园中，三千年一熟，霞光瑞霭，仙乐飘飘。" },
    { 主线关卡Type.斩妖台, "天庭刑戮之地，阴煞之气凝而不散。台上悬刀斧剑戟，诛仙斩妖，昔日齐天大圣曾被缚于此，雷霆加身而不灭。" },
    { 主线关卡Type.御马监, "天马监养之所，槽枥整齐，草料丰足。千匹天马膘肥体壮，行空踏云，乃天庭骑兵之根本，昔有齐天大圣任弼马温。" },
    { 主线关卡Type.蟠桃园, "瑶池畔千株蟠桃灵树，枝繁叶茂，桃实累累。前中后三园各分品级，九千年一熟者食之可与天地同寿。" },
    { 主线关卡Type.兜率宫, "离恨天太上老君炼丹圣宫，八卦炉中六丁神火日夜不熄。宫中藏有紫金红葫芦、羊脂玉净瓶等先天灵宝。" },
    { 主线关卡Type.紫微宫, "中天北极紫微大帝之宫阙，星辉万点，紫气盘绕。宫内壁画周天星斗图，暗合星辰运转之玄机。" },
    { 主线关卡Type.昊天殿, "玉皇大帝御前正殿，九龙金柱撑天而立，牌匾高悬昊天金阙。殿内威严赫赫，乃三界权力中枢所在。" },

    // ==================== 登天路 & 六重天/四重天/三清境/大罗天 ====================
    { 主线关卡Type.登天路, "凡间通往天庭的玄虚天梯，九千九百九十九级石阶，直插云霄。沿路云雾翻滚，罡风凛冽，时有雷劫降下，考验登天者道心。" },

    { 主线关卡Type.欲界天, "六重天之下第一层天，众生欲念交织所化。云霞之中隐现琼台楼阁，但声色犬马之幻象丛生，心境不坚者易沉沦其中。" },
    { 主线关卡Type.色界天, "六重天之中层天域，形色具足而离欲清净。天光流彩，宝树成行，居住于此者已断粗重烦恼，唯余微细色相执著。" },
    { 主线关卡Type.无色天, "六重天之极高处，无形无色，空寂玄妙。四维上下唯有虚明灵光，身处其中如入太虚，需凭纯粹定力方可立足。" },
    { 主线关卡Type.四梵天, "超越六重天之上的四层圣境，分别为无烦天、无热天、善见天、善现天。此间天人已近解脱，身光自照，寿量极长。" },

    { 主线关卡Type.上清境禹余天, "三清境之首，灵宝天尊道场。余气化为紫霞，仙鹤衔芝，灵兽奔走，道法自然演化万物生机。" },
    { 主线关卡Type.玉清境清微天, "三清境之中，元始天尊所居。元气未分，混沌初开之象，玄光流转不息。此地无形无相，唯有大道真意弥漫。" },
    { 主线关卡Type.太清境大赤天, "三清境之末，圣人老子治所。赤光笼罩，丹气缭绕，天地炉鼎隐现其中，万物皆在此炼化归真。" },

    { 主线关卡Type.大罗天, "三界最高之玄境，包罗万象，超越一切时空。弥罗宫屹立于虚无之中，金光万道，乃圣贤最终归宿，得道者方至之地。" },
    
    { 主线关卡Type.混沌虚空, "大罗天外至深至玄之境，非天非地，非有非无。此处无光无暗，无始无终，只有一片原初的混沌之气翻涌不息。" },
};

public static Dictionary<洞天关卡Item, SmallLevelInfo> 洞天LevelInfos = new Dictionary<洞天关卡Item, SmallLevelInfo>()
{
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 30, CreateNormalMonsterTime = 1.5f, EliteMonsterCount = 1 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 50, CreateNormalMonsterTime = 1.4f, EliteMonsterCount = 1 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 80, CreateNormalMonsterTime = 1.3f, EliteMonsterCount = 1 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 120, CreateNormalMonsterTime = 1.2f, EliteMonsterCount = 1 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 180, CreateNormalMonsterTime = 1f, EliteMonsterCount = 1 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 1 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 1 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.练气, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 500, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 1 }
    },
    
    
    
   
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 50, CreateNormalMonsterTime = 1.4f, EliteMonsterCount = 1 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 80, CreateNormalMonsterTime = 1.3f, EliteMonsterCount = 2 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 120, CreateNormalMonsterTime = 1.2f, EliteMonsterCount = 3 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 180, CreateNormalMonsterTime = 1f, EliteMonsterCount = 4 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 5 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 6 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.筑基, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 80, CreateNormalMonsterTime = 1.3f, EliteMonsterCount = 2 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 120, CreateNormalMonsterTime = 1.2f, EliteMonsterCount = 3 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 180, CreateNormalMonsterTime = 1f, EliteMonsterCount = 4 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 5 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 6 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金丹, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 120, CreateNormalMonsterTime = 1.2f, EliteMonsterCount = 3 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 180, CreateNormalMonsterTime = 1f, EliteMonsterCount = 4 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 5 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 6 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.元婴, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 180, CreateNormalMonsterTime = 1f, EliteMonsterCount = 4 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 5 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 6 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.化神, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 5 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 6 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.合体, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 350, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 6 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大乘, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天仙, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.玄仙, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.金仙, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.太乙金仙, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大罗金仙, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.准圣, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.圣人, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.天道圣人, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.大道圣人, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
    
    
    
    
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.黄品 },
        new SmallLevelInfo() { NormalMonsterCount = 450, CreateNormalMonsterTime = 0.4f, EliteMonsterCount = 7 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.玄品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 8 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.地品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 9 }
    },
    
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.天品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.宇品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 11 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.宙品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 12 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.洪品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 13 }
    },
    {
        new 洞天关卡Item() { JingJieType = JingJieType.混元圣人, qualityType = QualityType.荒品 },
        new SmallLevelInfo() { NormalMonsterCount = 600, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 14 }
    },
    
};
    public static Dictionary<主线关卡Type, SmallLevelInfo> LevelInfos = new Dictionary<主线关卡Type, SmallLevelInfo>()
{
    { 主线关卡Type.花果山, new SmallLevelInfo() { NormalMonsterCount = 20, CreateNormalMonsterTime = 1.5f, EliteMonsterCount = 1} },
    { 主线关卡Type.水帘洞, new SmallLevelInfo() { NormalMonsterCount = 30, CreateNormalMonsterTime = 1.5f, EliteMonsterCount = 1 } },
    { 主线关卡Type.傲来国, new SmallLevelInfo() { NormalMonsterCount = 40, CreateNormalMonsterTime = 1.4f, EliteMonsterCount = 1} },
    { 主线关卡Type.东海龙宫, new SmallLevelInfo() { NormalMonsterCount = 50, CreateNormalMonsterTime = 1.4f, EliteMonsterCount = 1} },
    { 主线关卡Type.蓬莱仙岛, new SmallLevelInfo() { NormalMonsterCount = 60, CreateNormalMonsterTime = 1.3f, EliteMonsterCount = 2 } },
    { 主线关卡Type.五行山, new SmallLevelInfo() { NormalMonsterCount = 70, CreateNormalMonsterTime = 1.3f, EliteMonsterCount = 2 } },
    { 主线关卡Type.高老庄, new SmallLevelInfo() { NormalMonsterCount = 80, CreateNormalMonsterTime = 1.2f, EliteMonsterCount = 2 } },
    { 主线关卡Type.平顶山, new SmallLevelInfo() { NormalMonsterCount = 90, CreateNormalMonsterTime = 1.2f, EliteMonsterCount = 2 } },
    { 主线关卡Type.女儿国, new SmallLevelInfo() { NormalMonsterCount = 100, CreateNormalMonsterTime = 1f, EliteMonsterCount = 3 } },
    { 主线关卡Type.火焰山, new SmallLevelInfo() { NormalMonsterCount = 110, CreateNormalMonsterTime = 1f, EliteMonsterCount = 3} },
    { 主线关卡Type.狮驼岭, new SmallLevelInfo() { NormalMonsterCount = 120, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 3 } },
    { 主线关卡Type.芭蕉洞, new SmallLevelInfo() { NormalMonsterCount = 130, CreateNormalMonsterTime = 0.9f, EliteMonsterCount = 3 } },
    { 主线关卡Type.流沙河, new SmallLevelInfo() { NormalMonsterCount = 150, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 4 } },
    { 主线关卡Type.小雷音寺, new SmallLevelInfo() { NormalMonsterCount = 160, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 4 } },
    { 主线关卡Type.冥府, new SmallLevelInfo() { NormalMonsterCount = 170, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 4 } },
    { 主线关卡Type.南天门, new SmallLevelInfo() { NormalMonsterCount = 180, CreateNormalMonsterTime = 0.8f, EliteMonsterCount = 4 } },
    { 主线关卡Type.瑶池仙境, new SmallLevelInfo() { NormalMonsterCount = 190, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 5 } },
    { 主线关卡Type.斩妖台, new SmallLevelInfo() { NormalMonsterCount = 200, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 5 } },
    { 主线关卡Type.御马监, new SmallLevelInfo() { NormalMonsterCount = 210, CreateNormalMonsterTime = 0.7f, EliteMonsterCount = 5 } },
    { 主线关卡Type.蟠桃园, new SmallLevelInfo() { NormalMonsterCount = 220, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 5 } },
    { 主线关卡Type.兜率宫, new SmallLevelInfo() { NormalMonsterCount = 230, CreateNormalMonsterTime = 0.6f, EliteMonsterCount = 6 } },
    { 主线关卡Type.紫微宫, new SmallLevelInfo() { NormalMonsterCount = 240, CreateNormalMonsterTime = 0.5f, EliteMonsterCount = 6 } },
    { 主线关卡Type.昊天殿, new SmallLevelInfo() { NormalMonsterCount = 250, CreateNormalMonsterTime = 0.5f, EliteMonsterCount = 6 } },

    { 主线关卡Type.登天路, new SmallLevelInfo() { NormalMonsterCount = 300, CreateNormalMonsterTime = 0.45f, EliteMonsterCount = 6 } },
    { 主线关卡Type.欲界天, new SmallLevelInfo() { NormalMonsterCount = 320, CreateNormalMonsterTime = 0.45f, EliteMonsterCount = 7 } },
    { 主线关卡Type.色界天, new SmallLevelInfo() { NormalMonsterCount = 340, CreateNormalMonsterTime = 0.45f, EliteMonsterCount = 7 } },
    { 主线关卡Type.无色天, new SmallLevelInfo() { NormalMonsterCount = 360, CreateNormalMonsterTime = 0.40f, EliteMonsterCount = 7 } },
    { 主线关卡Type.四梵天, new SmallLevelInfo() { NormalMonsterCount = 380, CreateNormalMonsterTime = 0.40f, EliteMonsterCount = 7 } },
    { 主线关卡Type.上清境禹余天, new SmallLevelInfo() { NormalMonsterCount = 400, CreateNormalMonsterTime = 0.40f, EliteMonsterCount = 8 } },
    { 主线关卡Type.玉清境清微天, new SmallLevelInfo() { NormalMonsterCount = 420, CreateNormalMonsterTime = 0.35f, EliteMonsterCount = 8 } },
    { 主线关卡Type.太清境大赤天, new SmallLevelInfo() { NormalMonsterCount = 440, CreateNormalMonsterTime = 0.35f, EliteMonsterCount = 8 } },
    { 主线关卡Type.大罗天, new SmallLevelInfo() { NormalMonsterCount = 460, CreateNormalMonsterTime = 0.35f, EliteMonsterCount = 8 } },
    { 主线关卡Type.混沌虚空, new SmallLevelInfo() { NormalMonsterCount = 500, CreateNormalMonsterTime = 0.3f, EliteMonsterCount = 10 } },

};
    
    public static Dictionary<JingJieType, List<MonsterTypeName>> 洞天MonsterDic =
    new Dictionary<JingJieType, List<MonsterTypeName>>()
    {
      {
        JingJieType.练气, new List<MonsterTypeName>()
        {
          MonsterTypeName.仙鹤, MonsterTypeName.灵芝童
        }
      },
      // 筑基 · 青木秘境
      {
        JingJieType.筑基, new List<MonsterTypeName>()
        {
          MonsterTypeName.青木狼, MonsterTypeName.铁背龟, MonsterTypeName.荆棘猿
        }
      },
      
      // 金丹 · 赤焰谷
      {
        JingJieType.金丹, new List<MonsterTypeName>()
        {
          MonsterTypeName.熔岩蜥, MonsterTypeName.火鸦, MonsterTypeName.炎晶巨人, MonsterTypeName.地火蛟
        }
      },

      // 元婴 · 幽冥渊
      {
        JingJieType.元婴, new List<MonsterTypeName>()
        {
          MonsterTypeName.怨魂蝶, MonsterTypeName.食骨鳄, MonsterTypeName.无面鬼, MonsterTypeName.九幽尸王
        }
      },

      // 化神 · 裂天峡
      {
        JingJieType.化神, new List<MonsterTypeName>()
        {
          MonsterTypeName.罡风鹫, MonsterTypeName.裂空蝎, MonsterTypeName.虚影兽, MonsterTypeName.双首海蛇
        }
      },

      // 合体 · 万象海
      {
        JingJieType.合体, new List<MonsterTypeName>()
        {
          MonsterTypeName.幻鳞鱼, MonsterTypeName.铁钳蟹, MonsterTypeName.万象鲸, MonsterTypeName.饕餮
        }
      },

      // 大乘 · 天外天
      {
        JingJieType.大乘, new List<MonsterTypeName>()
        {
          MonsterTypeName.云纹兽, MonsterTypeName.星光蝶, MonsterTypeName.朱雀, MonsterTypeName.白虎
        }
      },

      // 天仙 · 瑶光仙境
      {
        JingJieType.天仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.仙灵鹤, MonsterTypeName.玉兔精, MonsterTypeName.朱厌, MonsterTypeName.应龙
        }
      },

      // 玄仙 · 归墟海
      {
        JingJieType.玄仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.虚空兽, MonsterTypeName.混沌兽, MonsterTypeName.归墟古凤, MonsterTypeName.归墟古龙
        }
      },

      // 金仙 · 太初宫
      {
        JingJieType.金仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.道纹甲虫, MonsterTypeName.混沌蝠, MonsterTypeName.梼杌, MonsterTypeName.霸下
        }
      },

      // 太乙金仙 · 混元界
      {
        JingJieType.太乙金仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.玄黄蜉蝣, MonsterTypeName.剑齿虎, MonsterTypeName.混元兽, MonsterTypeName.道胎灵童
        }
      },

      // 大罗金仙 · 无何有之乡
      {
        JingJieType.大罗金仙, new List<MonsterTypeName>()
        {
          MonsterTypeName.青丘白狐, MonsterTypeName.青丘黑狐, MonsterTypeName.白泽, MonsterTypeName.九尾狐
        }
      },

      // 准圣 · 道海
      {
        JingJieType.准圣, new List<MonsterTypeName>()
        {
          MonsterTypeName.远古巨兽, MonsterTypeName.法则之兽, MonsterTypeName.凤凰, MonsterTypeName.真龙
        }
      },

      // 圣人/天道圣人 · 紫霄宫
      {
        JingJieType.圣人, new List<MonsterTypeName>()
        {
          MonsterTypeName.远古凶兽, MonsterTypeName.远古大蛇, MonsterTypeName.穷奇, MonsterTypeName.麒麟
        }
      },

      // 大道圣人 · 混沌海
      {
        JingJieType.大道圣人, new List<MonsterTypeName>()
        {
          MonsterTypeName.先天魔神, MonsterTypeName.混沌巨兽, MonsterTypeName.劫兽, MonsterTypeName.混沌之眼
        }
      },

      // 混元圣人 · 永恒之门
      {
        JingJieType.混元圣人, new List<MonsterTypeName>()
        {
          MonsterTypeName.归墟古兽, MonsterTypeName.时空扭曲者, MonsterTypeName.混沌古兽, MonsterTypeName.永恒之门
        }
      },
    };
   public static Dictionary<主线关卡Type, List<MonsterTypeName>> LevelMonsterDic =
    new Dictionary<主线关卡Type, List<MonsterTypeName>>()
    {
        // 花果山
        { 主线关卡Type.花果山, new List<MonsterTypeName>() { 
            MonsterTypeName.猴精, MonsterTypeName.山魈 } },
        // 水帘洞
        { 主线关卡Type.水帘洞, new List<MonsterTypeName>() { 
            MonsterTypeName.水虱精, MonsterTypeName.蝙蝠精 } },
        // 傲来国
        { 主线关卡Type.傲来国, new List<MonsterTypeName>() { 
            MonsterTypeName.傲来民兵, MonsterTypeName.猎户, MonsterTypeName.傲来偏将, MonsterTypeName.傲来国师 } },
        // 东海龙宫
        { 主线关卡Type.东海龙宫, new List<MonsterTypeName>() { 
            MonsterTypeName.虾兵, MonsterTypeName.蟹将, MonsterTypeName.龟丞相, MonsterTypeName.东海龙王 } },
        // 蓬莱仙岛
        { 主线关卡Type.蓬莱仙岛, new List<MonsterTypeName>() { 
            MonsterTypeName.仙鹤, MonsterTypeName.灵芝童, MonsterTypeName.蓬莱剑仙 } },
        // 五行山
        { 主线关卡Type.五行山, new List<MonsterTypeName>() { 
            MonsterTypeName.山石精, MonsterTypeName.土蝼, MonsterTypeName.五行山神 } },
        // 高老庄
        { 主线关卡Type.高老庄, new List<MonsterTypeName>() { 
            MonsterTypeName.野猪精, MonsterTypeName.高才, MonsterTypeName.高太公, MonsterTypeName.猪刚鬣 } },
        // 平顶山
        { 主线关卡Type.平顶山, new List<MonsterTypeName>() { 
            MonsterTypeName.莲花洞小妖, MonsterTypeName.狐阿七, MonsterTypeName.银角大王, MonsterTypeName.金角大王 } },
        // 女儿国
        { 主线关卡Type.女儿国, new List<MonsterTypeName>() { 
            MonsterTypeName.女儿国兵, MonsterTypeName.女儿国将, MonsterTypeName.女儿国太师, MonsterTypeName.女儿国国王 } },
        // 火焰山
        { 主线关卡Type.火焰山, new List<MonsterTypeName>() { 
            MonsterTypeName.火焰精, MonsterTypeName.赤蛇, MonsterTypeName.红孩儿, MonsterTypeName.牛魔王 } },
        // 芭蕉洞
        { 主线关卡Type.芭蕉洞, new List<MonsterTypeName>() { 
            MonsterTypeName.芭蕉精, MonsterTypeName.火焰童, MonsterTypeName.铁扇侍女, MonsterTypeName.铁扇公主 } },
        // 流沙河
        { 主线关卡Type.流沙河, new List<MonsterTypeName>() { 
            MonsterTypeName.流沙精, MonsterTypeName.水鬼, MonsterTypeName.水蛇妖, MonsterTypeName.沙和尚 } },
        // 小雷音寺
        { 主线关卡Type.小雷音寺, new List<MonsterTypeName>() { 
            MonsterTypeName.假罗汉, MonsterTypeName.假金刚, MonsterTypeName.黄眉童子, MonsterTypeName.黄眉老祖 } },
        // 狮驼岭
        { 主线关卡Type.狮驼岭, new List<MonsterTypeName>() { 
            MonsterTypeName.青狮精手下, MonsterTypeName.白象精手下, MonsterTypeName.大鹏金翅雕, MonsterTypeName.青狮精 } },
        // 冥府
        { 主线关卡Type.冥府, new List<MonsterTypeName>() { 
            MonsterTypeName.牛头, MonsterTypeName.马面, MonsterTypeName.判官, MonsterTypeName.阎罗王 } },

        // ==================== 天庭篇（凌霄宝殿十大关） ====================
        // 南天门
        { 主线关卡Type.南天门, new List<MonsterTypeName>() { 
            MonsterTypeName.天兵, MonsterTypeName.天将, MonsterTypeName.守卫统领, MonsterTypeName.巨灵王 } },
        // 瑶池仙境
        { 主线关卡Type.瑶池仙境, new List<MonsterTypeName>() { 
            MonsterTypeName.瑶池仙女, MonsterTypeName.瑶池守卫, MonsterTypeName.仙女首领, MonsterTypeName.西王母 } },
        // 斩妖台
        { 主线关卡Type.斩妖台, new List<MonsterTypeName>() { 
            MonsterTypeName.执法天兵, MonsterTypeName.执法天将, MonsterTypeName.斩妖剑侍, MonsterTypeName.天刑星君 } },
        // 御马监
        { 主线关卡Type.御马监, new List<MonsterTypeName>() { 
            MonsterTypeName.天马精, MonsterTypeName.监丞侍卫, MonsterTypeName.弼马温, MonsterTypeName.天马星君 } },
        // 蟠桃园
        { 主线关卡Type.蟠桃园, new List<MonsterTypeName>() { 
            MonsterTypeName.桃园力士, MonsterTypeName.桃园仙女, MonsterTypeName.蟠桃守卫, MonsterTypeName.蟠桃树精 } },
        // 兜率宫
        { 主线关卡Type.兜率宫, new List<MonsterTypeName>() { 
            MonsterTypeName.炼丹道童, MonsterTypeName.烧火道童, MonsterTypeName.兜率宫侍卫, MonsterTypeName.太上老君 } },
        // 紫微宫
        { 主线关卡Type.紫微宫, new List<MonsterTypeName>() { 
            MonsterTypeName.紫微星侍, MonsterTypeName.天罡星卒, MonsterTypeName.北极星君, MonsterTypeName.紫微大帝 } },
        // 昊天殿
        { 主线关卡Type.昊天殿, new List<MonsterTypeName>() { 
            MonsterTypeName.镇殿守卫, MonsterTypeName.镇殿天将, MonsterTypeName.九龙神卫, MonsterTypeName.玉皇大帝 } },

        // ==================== 登天路 & 六重天/四重天/三清境/大罗天 ====================
        // 登天路
        { 主线关卡Type.登天路, new List<MonsterTypeName>() { 
            MonsterTypeName.登天石傀, MonsterTypeName.罡风精, MonsterTypeName.雷劫之灵, MonsterTypeName.守天路神将 } },
        // 欲界天
        { 主线关卡Type.欲界天, new List<MonsterTypeName>() { 
            MonsterTypeName.欲念魅妖, MonsterTypeName.幻音雀, MonsterTypeName.贪欲魔, MonsterTypeName.欲界天魔王 } },
        // 色界天
        { 主线关卡Type.色界天, new List<MonsterTypeName>() { 
            MonsterTypeName.色相天女, MonsterTypeName.光音天众, MonsterTypeName.形色尊者, MonsterTypeName.色界天主 } },
        // 无色天
        { 主线关卡Type.无色天, new List<MonsterTypeName>() { 
            MonsterTypeName.虚灵, MonsterTypeName.空无影, MonsterTypeName.太虚之魂, MonsterTypeName.无色天祖 } },
        // 四梵天
        { 主线关卡Type.四梵天, new List<MonsterTypeName>() { 
            MonsterTypeName.梵天守卫, MonsterTypeName.净居天人, MonsterTypeName.善现尊者, MonsterTypeName.四梵天王 } },
        // 玉清境清微天
        { 主线关卡Type.玉清境清微天, new List<MonsterTypeName>() { 
            MonsterTypeName.清微仙童, MonsterTypeName.玄光玉女, MonsterTypeName.玉清道卫, MonsterTypeName.魔元始天尊 } },
        // 上清境禹余天
        { 主线关卡Type.上清境禹余天, new List<MonsterTypeName>() { 
            MonsterTypeName.禹余灵官, MonsterTypeName.紫霞仙鹤, MonsterTypeName.上清剑侍, MonsterTypeName.魔灵宝天尊 } },
        // 太清境大赤天
        { 主线关卡Type.太清境大赤天, new List<MonsterTypeName>() { 
            MonsterTypeName.大赤丹童, MonsterTypeName.炉火精, MonsterTypeName.太清护卫, MonsterTypeName.魔老子 } },
        // 大罗天
        { 主线关卡Type.大罗天, new List<MonsterTypeName>() { 
            MonsterTypeName.弥罗侍卫, MonsterTypeName.弥罗宫卫, MonsterTypeName.混元道兵, MonsterTypeName.魔鸿钧 } },
        // 大罗天
        { 主线关卡Type.混沌虚空, new List<MonsterTypeName>() { 
            MonsterTypeName.混沌蠕虫, MonsterTypeName.虚空螯虫, MonsterTypeName.虚空巨兽, MonsterTypeName.混沌主宰 } },
    };

   public static 洞天关卡胜利奖励 Get洞天关卡胜利奖励()
   {
       洞天关卡Item item = new 洞天关卡Item()
           { JingJieType = PlayerData.S.当前轮回境界, qualityType = 当前洞天QualityType };
       var list = 灵物突破Config.洞天普通掉落Dic[item];
       洞天关卡胜利奖励 value = new 洞天关卡胜利奖励();
       List<灵物item> 灵物list = new List<灵物item>();
       value.灵魂=LongRandom.Range(list[0].minCount,list[0].maxCount);
       value.功德=LongRandom.Range(list[1].minCount,list[1].maxCount);
       var 灵物概率列表 = 灵物突破Config.灵物掉落概率Dic[当前洞天QualityType];
       for (int index = 0; index < 灵物概率列表.Count; index++)
       {
           float prob = 灵物概率列表[index];
           float random = Random.Range(0, 100f);
           if (random < prob*属性config.总掉宝率)
           {
               灵物item 灵物item = new 灵物item();
               灵物item.JingJieType = PlayerData.S.当前轮回境界;
               灵物item.QualityType = (QualityType)(index + 1);
               灵物list.Add(灵物item);
           }
       }

       value.List = 灵物list;
       return value;
   }
   public static 普通关卡胜利奖励 Get主线胜利奖励()
   {
       HashSet<LevelDiaoLuo> list = LevelDiaoLuoDic[当前主线关卡Type];
       普通关卡胜利奖励 value = new 普通关卡胜利奖励();
       foreach (var item in list)
       {
           long min = item.minCount;
           long max = item.maxCount;
           if (当前主线关卡Type == 主线关卡Type.混沌虚空)
           {
               min = Get混沌虚空奖励(战斗混沌虚空层数, item.PropType).min;
               max = Get混沌虚空奖励(战斗混沌虚空层数, item.PropType).max;
           }
           long random=LongRandom.Range(min,max);
           switch (item.PropType)
           {
               case PropType.灵魂:
                   value.灵魂 = (int)(random*(1f+道宝Config.羁绊灵气/100f));
                   break;
               case PropType.功德:
                   value.功德 = (int)(random*(1f+道宝Config.羁绊功德/100f));
                   break;
               case PropType.射手经验值:
                   value.射手经验值 = random;
                   break;
               case PropType.法师经验值:
                   value.法师经验值 = random;
                   break;
               case PropType.控制经验值:
                   value.控制经验值 = random;
                   break;
               case PropType.战士经验值:
                   value.战士经验值 = random;
                   break;
               case PropType.辅助经验值:
                   value.辅助经验值 = random;
                   break;
               case PropType.衣服锻造石:
                   value.衣服锻造石 = random;
                   break;
               case PropType.头盔锻造石:
                   value.头盔锻造石 = random;
                   break;
               case PropType.鞋子锻造石:
                   value.鞋子锻造石 = random;
                   break;
               case PropType.护手锻造石:
                   value.护手锻造石 = random;
                   break;
               case PropType.戒指锻造石:
                   value.戒指锻造石 = random;
                   break;
               case PropType.项链锻造石:
                   value.项链锻造石 = random;
                   break;
               case PropType.招募卷:
                   value.招募卷 = random;
                   break;
               case PropType.高级招募卷:
                   var random1 = Random.Range(0, 100f);
                   if (random1 < random)
                   {
                       value.高级招募卷 = 1;
                   }
                   else
                   {
                       value.高级招募卷 = 0;
                   }
                   
                   break;
               case PropType.洗练石:
                   value.洗练石 = random;
                   break;
           }
       }

       return value;
   }

   public static minmax Get混沌虚空奖励(int 层数, PropType type)
 {
     minmax result = new minmax();

     // 基础值取自混沌虚空掉落表
     LevelDiaoLuo baseItem = null;
     foreach (var item in LevelDiaoLuoDic[主线关卡Type.混沌虚空])
     {
         if (item.PropType == type)
         {
             baseItem = item;
             break;
         }
     }

     if (baseItem == null)
     {
         return result;
     }

     result.min = baseItem.minCount;
     result.max = baseItem.maxCount;

     // 第1层为基础值，之后每加一层累加加成
     int 加成层数 = 层数 - 1;
     if (加成层数 <= 0)
     {
         return result;
     }

     switch (type)
     {
         // 每加一层 min/max +1500
         case PropType.灵魂:
             result.min += 加成层数 * 1500;
             result.max += 加成层数 * 1500;
             break;
         // 每加一层 min/max +1000
         case PropType.功德:
             result.min += 加成层数 * 1000;
             result.max += 加成层数 * 1000;
             break;
         // 经验值：每加一层 min/max +1000
         case PropType.射手经验值:
         case PropType.战士经验值:
         case PropType.辅助经验值:
         case PropType.控制经验值:
         case PropType.法师经验值:
         case PropType.全职业经验值:
             result.min += 加成层数 * 1000;
             result.max += 加成层数 * 1000;
             break;
         // 锻造石和招募卷：每10层 min/max +1
         case PropType.衣服锻造石:
         case PropType.头盔锻造石:
         case PropType.鞋子锻造石:
         case PropType.护手锻造石:
         case PropType.项链锻造石:
         case PropType.戒指锻造石:
         case PropType.招募卷:
             result.min += 加成层数 / 10;
             result.max += 加成层数 / 10;
             break;
         // 洗练石和高级招募卷：每20层 min/max +1
         case PropType.洗练石:
         case PropType.高级招募卷:
             result.min += 加成层数 / 20;
             result.max += 加成层数 / 20;
             break;
     }

     return result;
 }
   
    public static Dictionary<主线关卡Type, HashSet<LevelDiaoLuo>> LevelDiaoLuoDic =
        new Dictionary<主线关卡Type, HashSet<LevelDiaoLuo>>()
        {
            {
                主线关卡Type.花果山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 100, minCount = 80, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.水帘洞,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 120, minCount = 100, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.蓬莱仙岛,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 150, minCount = 120, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.五行山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 200, minCount = 150, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.傲来国,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 250, minCount = 200, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.高老庄,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 400, minCount = 300, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 300, minCount = 250, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.女儿国,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 500, minCount = 400, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 350, minCount = 300, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.小雷音寺,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 400, minCount = 350, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.招募卷 },
                }
            },
            
            
            {
                主线关卡Type.平顶山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.功德 },                   
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 600, minCount = 500, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 3, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.火焰山,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 800, minCount = 700, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 700, minCount = 600, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.招募卷 },
                }
            },
            
            
            
            {
                主线关卡Type.芭蕉洞,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1000, minCount = 800, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 900, minCount = 800, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 4, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.招募卷 },
                }
            },
            
            
            
            {
                主线关卡Type.流沙河,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1200, minCount = 1000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 5, minCount = 5, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.狮驼岭,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 1500, minCount = 1200, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1400, minCount = 1200, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 4, minCount = 4, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.东海龙宫,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 1500, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1600, minCount = 1400, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 5, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.冥府,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 2500, minCount = 2000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 1800, minCount = 1600, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 1, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 1800, minCount = 1600, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 1800, minCount = 1600, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 1800, minCount = 1600, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 1800, minCount = 1600, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 1800, minCount = 1600, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.南天门,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 3200, minCount = 2500, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2200, minCount = 1800, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 2000, minCount = 1800, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 1800, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 1800, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 1800, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 2000, minCount = 1800, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 6, minCount = 6, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.瑶池仙境,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 4000, minCount = 3200, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 2800, minCount = 2200, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 2300, minCount = 2000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 2300, minCount = 2000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 2300, minCount = 2000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 2300, minCount = 2000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 2300, minCount = 2000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.斩妖台,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 4000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 3600, minCount = 2800, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 2600, minCount = 2300, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 2600, minCount = 2300, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 2600, minCount = 2300, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 2600, minCount = 2300, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 2600, minCount = 2300, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 6, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.御马监,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 4500, minCount = 3600, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 3000, minCount = 2600, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 3000, minCount = 2600, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 3000, minCount = 2600, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 3000, minCount = 2600, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 3000, minCount = 2600, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.蟠桃园,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 7500, minCount = 6000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 4500, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 1, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 3500, minCount = 3000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 3500, minCount = 3000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 3500, minCount = 3000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 3500, minCount = 3000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 3500, minCount = 3000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.兜率宫,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 5000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 4000, minCount = 3500, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 4000, minCount = 3500, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 4000, minCount = 3500, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 4000, minCount = 3500, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 4000, minCount = 3500, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 4000, minCount = 3500, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.紫微宫,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5500, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 4500, minCount = 4000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.洗练石 },

                    new LevelDiaoLuo() { maxCount = 4500, minCount = 4000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 4500, minCount = 4000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 4500, minCount = 4000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 4500, minCount = 4000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 4500, minCount = 4000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.昊天殿,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 7000, minCount = 6000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 4500, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 4500, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 4500, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 4500, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 4500, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 5000, minCount = 4500, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 7, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            
            
            
            
            
            
            {
                主线关卡Type.登天路,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 5000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 2, minCount = 2, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 5000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 5000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 5000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 5000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 5500, minCount = 5000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.欲界天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 9000, minCount = 8000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5500, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5500, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5500, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5500, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5500, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 6000, minCount = 5500, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.色界天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 9000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 6500, minCount = 6000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 6500, minCount = 6000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 6500, minCount = 6000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 6500, minCount = 6000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 6500, minCount = 6000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 6500, minCount = 6000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.无色天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 7000, minCount = 6500, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 7000, minCount = 6500, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 7000, minCount = 6500, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 7000, minCount = 6500, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 7000, minCount = 6500, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 7000, minCount = 6500, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.四梵天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 14000, minCount = 12000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 2, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 8000, minCount = 7000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 7, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.上清境禹余天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 16000, minCount = 14000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 9000, minCount = 8000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 9000, minCount = 8000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 9000, minCount = 8000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 9000, minCount = 8000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 9000, minCount = 8000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 9000, minCount = 8000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.玉清境清微天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 18000, minCount = 16000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 9000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 9000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 9000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 9000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 9000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 10000, minCount = 9000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.太清境大赤天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 20000, minCount = 18000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 12000, minCount = 10000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 8, minCount = 8, PropType = PropType.招募卷 },
                }
            },
            {
                主线关卡Type.大罗天,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 22000, minCount = 20000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 14000, minCount = 12000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 14000, minCount = 12000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 14000, minCount = 12000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 14000, minCount = 12000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 14000, minCount = 12000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 14000, minCount = 12000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.招募卷 },
                }
            },
            
            {
                主线关卡Type.混沌虚空,
                new HashSet<LevelDiaoLuo>()
                {
                    new LevelDiaoLuo() { maxCount = 24000, minCount = 22000, PropType = PropType.灵魂 },
                    new LevelDiaoLuo() { maxCount = 16000, minCount = 14000, PropType = PropType.功德 },
                    new LevelDiaoLuo() { maxCount = 20, minCount = 20, PropType = PropType.高级招募卷 },
                    new LevelDiaoLuo() { maxCount = 3, minCount = 3, PropType = PropType.洗练石 },
                    new LevelDiaoLuo() { maxCount = 16000, minCount = 14000, PropType = PropType.射手经验值 },
                    new LevelDiaoLuo() { maxCount = 16000, minCount = 14000, PropType = PropType.战士经验值 },
                    new LevelDiaoLuo() { maxCount = 16000, minCount = 14000, PropType = PropType.辅助经验值 },
                    new LevelDiaoLuo() { maxCount = 16000, minCount = 14000, PropType = PropType.控制经验值 },
                    new LevelDiaoLuo() { maxCount = 16000, minCount = 14000, PropType = PropType.法师经验值 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.衣服锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.头盔锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.鞋子锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.护手锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.项链锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.戒指锻造石 },
                    new LevelDiaoLuo() { maxCount = 9, minCount = 9, PropType = PropType.招募卷 },
                }
            },
        };

   

    public static Dictionary<主线关卡Type, string> 主线关卡NameDic = new Dictionary<主线关卡Type, string>()
    {
        { 主线关卡Type.花果山, "花果山" },
        { 主线关卡Type.水帘洞, "水帘洞" },
        { 主线关卡Type.傲来国, "傲来国" },
        { 主线关卡Type.东海龙宫, "东海龙宫" },
        { 主线关卡Type.蓬莱仙岛, "蓬莱仙岛" },
        { 主线关卡Type.五行山, "五行山" },
        { 主线关卡Type.高老庄, "高老庄" },
        { 主线关卡Type.平顶山, "平顶山" },
        { 主线关卡Type.女儿国, "女儿国" },
        { 主线关卡Type.火焰山, "火焰山" },
        { 主线关卡Type.狮驼岭, "狮驼岭" },
        { 主线关卡Type.流沙河, "流沙河" },
        { 主线关卡Type.芭蕉洞, "芭蕉洞" },
        { 主线关卡Type.小雷音寺, "小雷音寺" },
        { 主线关卡Type.冥府, "冥府" },

        // ==================== 天庭篇（凌霄宝殿十大关） ====================
        { 主线关卡Type.南天门, "南天门" },
        { 主线关卡Type.瑶池仙境, "瑶池仙境" },
        { 主线关卡Type.斩妖台, "斩妖台" },
        { 主线关卡Type.御马监, "御马监" },
        { 主线关卡Type.蟠桃园, "蟠桃园" },
        { 主线关卡Type.兜率宫, "兜率宫" },
        { 主线关卡Type.紫微宫, "紫微宫" },
        { 主线关卡Type.昊天殿, "昊天殿" },
        
        { 主线关卡Type.登天路, "登天路" },
        { 主线关卡Type.欲界天, "欲界天" },
        { 主线关卡Type.色界天, "色界天" },
        { 主线关卡Type.无色天, "无色天" },
        { 主线关卡Type.四梵天, "四梵天" },
        { 主线关卡Type.上清境禹余天, "上清境禹余天" },
        { 主线关卡Type.玉清境清微天, "玉清境清微天" },
        { 主线关卡Type.太清境大赤天, "太清境大赤天" },
        { 主线关卡Type.大罗天, "大罗天" },
        { 主线关卡Type.混沌虚空, "混沌虚空" },
    };

    public static int Get混沌虚空通关奖励(int 层数)
    {
        return (层数 - 1) * 2 + 100;
    }
}
