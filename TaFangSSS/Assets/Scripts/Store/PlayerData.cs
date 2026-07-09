using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class PlayerData : XSingleton<PlayerData>
{
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string Name = "白辰";
    public JingJieType JingJieType = JingJieType.练气;
    public int Exp;
    public int LingQi;
    public int GongDe;
    public int CurrentBianDui = 1;

    public Dictionary<道宝Type, int> 道宝LevelDic = new Dictionary<道宝Type, int>()
    {
        // ==================== 混沌至宝 ====================
        { 道宝Type.混沌青莲,   0 },
        { 道宝Type.造化玉碟,   0 },
        { 道宝Type.混沌珠,     0 },
        { 道宝Type.开天斧,     0 },

        // ==================== 先天至宝 ====================
        { 道宝Type.盘古幡,     0 },
        { 道宝Type.混沌钟,     0 },
        { 道宝Type.诛仙剑,     0 },
        { 道宝Type.戮仙剑,     0 },
        { 道宝Type.陷仙剑,     0 },
        { 道宝Type.绝仙剑,     0 },

        // ==================== 功德至宝 ====================
        { 道宝Type.玲珑塔,     0 },
        { 道宝Type.轩辕剑,     0 },
        { 道宝Type.女娲石,     0 },
        { 道宝Type.炼妖壶,     0 },
        { 道宝Type.玉净瓶,     0 },
        { 道宝Type.乾坤鼎,     0 },
        { 道宝Type.菩提妙树,   0 },
        { 道宝Type.风火轮,     0 },

        // ==================== 先天灵宝 ====================
        { 道宝Type.山河社稷图, 0 },
        { 道宝Type.七宝妙树,   0 },
        { 道宝Type.天书,       0 },
        { 道宝Type.地书,       0 },
        { 道宝Type.冥书,       0 },
        { 道宝Type.弑神枪,     0 },
        { 道宝Type.定海神珠,   0 },
        { 道宝Type.河图洛书,   0 },

        // ==================== 后天法宝 ====================
        { 道宝Type.翻天印,     0 },
        { 道宝Type.紫金葫芦,   0 },
        { 道宝Type.金蛟剪,     0 },
        { 道宝Type.斩仙飞刀,   0 },
        { 道宝Type.五色神光,   0 },
        { 道宝Type.宝莲灯,     0 },
        { 道宝Type.落宝金钱,   0 },
        { 道宝Type.先天五方旗, 0 },
        { 道宝Type.照妖镜,     0 },
        { 道宝Type.如意金箍棒, 0 },
    };
    public Dictionary<EquipType, List<道纹>> 装备道纹List = new Dictionary<EquipType, List<道纹>>()
    {
        { EquipType.头盔 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.衣服 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.戒指 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.项链 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.鞋子 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
        { EquipType.护手 ,new List<道纹>(){new 道纹(),new 道纹(),new 道纹(),new 道纹(),new 道纹()}},
    };
    public Dictionary<string, int> 道纹List = new Dictionary<string, int>()
{
    // 增加百分比攻击力
    {"增加百分比攻击力_天品", 0},
    {"增加百分比攻击力_宇品", 0},
    {"增加百分比攻击力_宙品", 0},
    {"增加百分比攻击力_洪品", 0},
    {"增加百分比攻击力_荒品", 0},

    // 增加战士伤害
    {"增加战士伤害_天品", 0},
    {"增加战士伤害_宇品", 0},
    {"增加战士伤害_宙品", 0},
    {"增加战士伤害_洪品", 0},
    {"增加战士伤害_荒品", 0},

    // 增加法师伤害
    {"增加法师伤害_天品", 0},
    {"增加法师伤害_宇品", 0},
    {"增加法师伤害_宙品", 0},
    {"增加法师伤害_洪品", 0},
    {"增加法师伤害_荒品", 0},

    // 增加控制伤害
    {"增加控制伤害_天品", 0},
    {"增加控制伤害_宇品", 0},
    {"增加控制伤害_宙品", 0},
    {"增加控制伤害_洪品", 0},
    {"增加控制伤害_荒品", 0},

    // 增加射手伤害
    {"增加射手伤害_天品", 0},
    {"增加射手伤害_宇品", 0},
    {"增加射手伤害_宙品", 0},
    {"增加射手伤害_洪品", 0},
    {"增加射手伤害_荒品", 0},

    // 增加小怪伤害
    {"增加小怪伤害_天品", 0},
    {"增加小怪伤害_宇品", 0},
    {"增加小怪伤害_宙品", 0},
    {"增加小怪伤害_洪品", 0},
    {"增加小怪伤害_荒品", 0},

    // 增加物理伤害
    {"增加物理伤害_天品", 0},
    {"增加物理伤害_宇品", 0},
    {"增加物理伤害_宙品", 0},
    {"增加物理伤害_洪品", 0},
    {"增加物理伤害_荒品", 0},

    // 增加雷电伤害
    {"增加雷电伤害_天品", 0},
    {"增加雷电伤害_宇品", 0},
    {"增加雷电伤害_宙品", 0},
    {"增加雷电伤害_洪品", 0},
    {"增加雷电伤害_荒品", 0},

    // 增加冰霜伤害
    {"增加冰霜伤害_天品", 0},
    {"增加冰霜伤害_宇品", 0},
    {"增加冰霜伤害_宙品", 0},
    {"增加冰霜伤害_洪品", 0},
    {"增加冰霜伤害_荒品", 0},

    // 增加黑暗伤害
    {"增加黑暗伤害_天品", 0},
    {"增加黑暗伤害_宇品", 0},
    {"增加黑暗伤害_宙品", 0},
    {"增加黑暗伤害_洪品", 0},
    {"增加黑暗伤害_荒品", 0},

    // 增加火焰伤害
    {"增加火焰伤害_天品", 0},
    {"增加火焰伤害_宇品", 0},
    {"增加火焰伤害_宙品", 0},
    {"增加火焰伤害_洪品", 0},
    {"增加火焰伤害_荒品", 0},

    // 增加精英怪和首领伤害
    {"增加精英怪和首领伤害_天品", 0},
    {"增加精英怪和首领伤害_宇品", 0},
    {"增加精英怪和首领伤害_宙品", 0},
    {"增加精英怪和首领伤害_洪品", 0},
    {"增加精英怪和首领伤害_荒品", 0},

    // 城墙低血增加伤害
    {"城墙低血增加伤害_天品", 0},
    {"城墙低血增加伤害_宇品", 0},
    {"城墙低血增加伤害_宙品", 0},
    {"城墙低血增加伤害_洪品", 0},
    {"城墙低血增加伤害_荒品", 0},

    // 击杀精英怪城墙回血
    {"击杀精英怪城墙回血_天品", 0},
    {"击杀精英怪城墙回血_宇品", 0},
    {"击杀精英怪城墙回血_宙品", 0},
    {"击杀精英怪城墙回血_洪品", 0},
    {"击杀精英怪城墙回血_荒品", 0},

    // 城墙血量百分比
    {"城墙血量百分比_天品", 0},
    {"城墙血量百分比_宇品", 0},
    {"城墙血量百分比_宙品", 0},
    {"城墙血量百分比_洪品", 0},
    {"城墙血量百分比_荒品", 0},

    // 城墙免疫伤害
    {"城墙免疫伤害_天品", 0},
    {"城墙免疫伤害_宇品", 0},
    {"城墙免疫伤害_宙品", 0},
    {"城墙免疫伤害_洪品", 0},
    {"城墙免疫伤害_荒品", 0},

    // 城墙满血时加伤害
    {"城墙满血时加伤害_天品", 0},
    {"城墙满血时加伤害_宇品", 0},
    {"城墙满血时加伤害_宙品", 0},
    {"城墙满血时加伤害_洪品", 0},
    {"城墙满血时加伤害_荒品", 0},

    // 英雄暴击率
    {"英雄暴击率_天品", 0},
    {"英雄暴击率_宇品", 0},
    {"英雄暴击率_宙品", 0},
    {"英雄暴击率_洪品", 0},
    {"英雄暴击率_荒品", 0},

    // 伤害在范围内浮动
    {"伤害在范围内浮动_天品", 0},
    {"伤害在范围内浮动_宇品", 0},
    {"伤害在范围内浮动_宙品", 0},
    {"伤害在范围内浮动_洪品", 0},
    {"伤害在范围内浮动_荒品", 0},

    // 无视抗性
    {"无视抗性_天品", 0},
    {"无视抗性_宇品", 0},
    {"无视抗性_宙品", 0},
    {"无视抗性_洪品", 0},
    {"无视抗性_荒品", 0},

    // 战士对靠近城墙敌人伤害增高
    {"战士对靠近城墙敌人伤害增高_天品", 0},
    {"战士对靠近城墙敌人伤害增高_宇品", 0},
    {"战士对靠近城墙敌人伤害增高_宙品", 0},
    {"战士对靠近城墙敌人伤害增高_洪品", 0},
    {"战士对靠近城墙敌人伤害增高_荒品", 0},

    // 射手连射概率
    {"射手连射概率_天品", 0},
    {"射手连射概率_宇品", 0},
    {"射手连射概率_宙品", 0},
    {"射手连射概率_洪品", 0},
    {"射手连射概率_荒品", 0},

    // 控制冷却缩减
    {"控制冷却缩减_天品", 0},
    {"控制冷却缩减_宇品", 0},
    {"控制冷却缩减_宙品", 0},
    {"控制冷却缩减_洪品", 0},
    {"控制冷却缩减_荒品", 0},

    // 法师暴击率
    {"法师暴击率_天品", 0},
    {"法师暴击率_宇品", 0},
    {"法师暴击率_宙品", 0},
    {"法师暴击率_洪品", 0},
    {"法师暴击率_荒品", 0},

    // 辅助被辅助英雄伤害增幅
    {"辅助被辅助英雄伤害增幅_天品", 0},
    {"辅助被辅助英雄伤害增幅_宇品", 0},
    {"辅助被辅助英雄伤害增幅_宙品", 0},
    {"辅助被辅助英雄伤害增幅_洪品", 0},
    {"辅助被辅助英雄伤害增幅_荒品", 0},

    // 三味真火无视抗性百分比
    {"三味真火无视抗性百分比_天品", 0},
    {"三味真火无视抗性百分比_宇品", 0},
    {"三味真火无视抗性百分比_宙品", 0},
    {"三味真火无视抗性百分比_洪品", 0},
    {"三味真火无视抗性百分比_荒品", 0},

    // 孙悟空每秒增加伤害
    {"孙悟空每秒增加伤害_天品", 0},
    {"孙悟空每秒增加伤害_宇品", 0},
    {"孙悟空每秒增加伤害_宙品", 0},
    {"孙悟空每秒增加伤害_洪品", 0},
    {"孙悟空每秒增加伤害_荒品", 0},

    // 碧霄冰龙有概率再次释放
    {"碧霄冰龙有概率再次释放_天品", 0},
    {"碧霄冰龙有概率再次释放_宇品", 0},
    {"碧霄冰龙有概率再次释放_宙品", 0},
    {"碧霄冰龙有概率再次释放_洪品", 0},
    {"碧霄冰龙有概率再次释放_荒品", 0},

    // 琼霄定身衰减效果减少
    {"琼霄定身衰减效果减少_天品", 0},
    {"琼霄定身衰减效果减少_宇品", 0},
    {"琼霄定身衰减效果减少_宙品", 0},
    {"琼霄定身衰减效果减少_洪品", 0},
    {"琼霄定身衰减效果减少_荒品", 0},

    // 云霄暴击率
    {"云霄暴击率_天品", 0},
    {"云霄暴击率_宇品", 0},
    {"云霄暴击率_宙品", 0},
    {"云霄暴击率_洪品", 0},
    {"云霄暴击率_荒品", 0},

    // 后羿距离越远伤害越高
    {"后羿距离越远伤害越高_天品", 0},
    {"后羿距离越远伤害越高_宇品", 0},
    {"后羿距离越远伤害越高_宙品", 0},
    {"后羿距离越远伤害越高_洪品", 0},
    {"后羿距离越远伤害越高_荒品", 0},

    // 羲和灼烧伤害
    {"羲和灼烧伤害_天品", 0},
    {"羲和灼烧伤害_宇品", 0},
    {"羲和灼烧伤害_宙品", 0},
    {"羲和灼烧伤害_洪品", 0},
    {"羲和灼烧伤害_荒品", 0},

    // 常曦有概率冻结敌人
    {"常曦有概率冻结敌人_天品", 0},
    {"常曦有概率冻结敌人_宇品", 0},
    {"常曦有概率冻结敌人_宙品", 0},
    {"常曦有概率冻结敌人_洪品", 0},
    {"常曦有概率冻结敌人_荒品", 0},

    // 女娲增加被辅助英雄暴击率
    {"女娲增加被辅助英雄暴击率_天品", 0},
    {"女娲增加被辅助英雄暴击率_宇品", 0},
    {"女娲增加被辅助英雄暴击率_宙品", 0},
    {"女娲增加被辅助英雄暴击率_洪品", 0},
    {"女娲增加被辅助英雄暴击率_荒品", 0},

    // 通天每次暴击增加伤害
    {"通天每次暴击增加伤害_天品", 0},
    {"通天每次暴击增加伤害_宇品", 0},
    {"通天每次暴击增加伤害_宙品", 0},
    {"通天每次暴击增加伤害_洪品", 0},
    {"通天每次暴击增加伤害_荒品", 0},

    // 老子旋风体积越大伤害越高
    {"老子旋风体积越大伤害越高_天品", 0},
    {"老子旋风体积越大伤害越高_宇品", 0},
    {"老子旋风体积越大伤害越高_宙品", 0},
    {"老子旋风体积越大伤害越高_洪品", 0},
    {"老子旋风体积越大伤害越高_荒品", 0},

    // 元始每次释放有概率增加火种数量
    {"元始每次释放有概率增加火种数量_天品", 0},
    {"元始每次释放有概率增加火种数量_宇品", 0},
    {"元始每次释放有概率增加火种数量_宙品", 0},
    {"元始每次释放有概率增加火种数量_洪品", 0},
    {"元始每次释放有概率增加火种数量_荒品", 0},

    // 鸿钧每释放陨石增加伤害
    {"鸿钧每释放陨石增加伤害_天品", 0},
    {"鸿钧每释放陨石增加伤害_宇品", 0},
    {"鸿钧每释放陨石增加伤害_宙品", 0},
    {"鸿钧每释放陨石增加伤害_洪品", 0},
    {"鸿钧每释放陨石增加伤害_荒品", 0},

    // 盘古每击杀敌人增加伤害
    {"盘古每击杀敌人增加伤害_天品", 0},
    {"盘古每击杀敌人增加伤害_宇品", 0},
    {"盘古每击杀敌人增加伤害_宙品", 0},
    {"盘古每击杀敌人增加伤害_洪品", 0},
    {"盘古每击杀敌人增加伤害_荒品", 0},
};
    
    public int Get道纹数量(道纹Type 类型, QualityType 品质)
    {
        string key = $"{类型}_{品质}";
        return 道纹List.TryGetValue(key, out int value) ? value : 0;
    }
    
    public void Set道纹数量(道纹Type 类型, QualityType 品质, int count)
    {
        string key = $"{类型}_{品质}";
        道纹List[key] = count;
    }
    
    
    public Dictionary<HeroType, int> 英雄法则等级Dic = new Dictionary<HeroType, int>()
    {
        { HeroType.哪吒 ,0},
        { HeroType.孙悟空 ,0},
        { HeroType.碧霄 ,0},
        { HeroType.琼霄 ,0},
        
        { HeroType.云霄 ,0},
        { HeroType.后羿 ,0},
        { HeroType.常羲 ,0},
        { HeroType.羲和 ,0},
        
        { HeroType.女娲 ,0},
        { HeroType.通天 ,0},
        { HeroType.元始 ,0},
        { HeroType.老子 ,0},
        
        { HeroType.盘古 ,0},
        { HeroType.鸿钧 ,0},
    };
    public Dictionary<JingJieType, 突破Type> 突破Dic = new Dictionary<JingJieType, 突破Type>()
    {
        { JingJieType.练气 ,突破Type.None},
        { JingJieType.筑基 ,突破Type.None},
        { JingJieType.金丹 ,突破Type.None},
        { JingJieType.元婴 ,突破Type.None},
        { JingJieType.化神 ,突破Type.None},
        { JingJieType.合体 ,突破Type.None},
        { JingJieType.大乘 ,突破Type.None},
        { JingJieType.天仙 ,突破Type.None},
        { JingJieType.玄仙 ,突破Type.None},
        { JingJieType.金仙 ,突破Type.None},
        { JingJieType.太乙金仙 ,突破Type.None},
        { JingJieType.大罗金仙 ,突破Type.None},
        { JingJieType.准圣 ,突破Type.None},
        { JingJieType.圣人 ,突破Type.None},
        { JingJieType.天道圣人 ,突破Type.None},
        { JingJieType.大道圣人 ,突破Type.None},
        { JingJieType.混元圣人 ,突破Type.None},
    };

    public Dictionary<EquipType, List<附加属性>> 装备附加属性Dic = new Dictionary<EquipType, List<附加属性>>()
    {
        {
            EquipType.头盔,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
            }
        },
        {
            EquipType.护手,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
            }
        },
        {
            EquipType.衣服,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
            }
        },
        {
            EquipType.鞋子,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
            }
        },
        {
            EquipType.项链,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
            }
        },
        {
            EquipType.戒指,
            new List<附加属性>()
            {
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
                new 附加属性() { 附加属性Type = 附加属性Type.None, QualityType = QualityType.None ,IsSuo = false},
            }
        },
    };
    public Dictionary<EquipType, int> EquipLevelDic = new Dictionary<EquipType, int>()
    {
        { EquipType.头盔 ,1},
        { EquipType.护手 ,1},
        { EquipType.鞋子 ,1},
        { EquipType.戒指 ,1},
        { EquipType.项链 ,1},
        { EquipType.衣服 ,1},
    };
    public Dictionary<int, List<HeroType>> 出战英雄List = new Dictionary<int, List<HeroType>>()
    {
        { 0, new List<HeroType>() { HeroType.丹童 ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
        { 1, new List<HeroType>(){ HeroType.None ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
        { 2, new List<HeroType>(){ HeroType.None ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
        { 3, new List<HeroType>(){ HeroType.None ,HeroType.None,HeroType.None,HeroType.None,HeroType.None}},
    };

    public Dictionary<int, string> 编队名List = new Dictionary<int, string>()
    {
        { 0, "" },
        { 1, "" },
        { 2, "" },
        { 3, "" },
    };

    //level=0表示未解锁，level=1是星级为0，level=2是星级=1
    public Dictionary<HeroType, HeroData> HeroDataDic = new Dictionary<HeroType, HeroData>()
    {
        { HeroType.丹童, new HeroData() { Level = 1, 元神 = 0 } },
        { HeroType.土地, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.河伯, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.瑶池仙女, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.石敢当, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.玄女, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.龟丞相, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.太白金星, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.多闻天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.广目天王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.雷震子, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.月老, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.嫦娥, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.杨戬, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.妲己, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.牛魔王, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.哪吒, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.孙悟空, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.碧霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.琼霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.羲和, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.常羲, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.后羿, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.云霄, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.女娲, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.老子, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.通天, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.元始, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.盘古, new HeroData() { Level = 0, 元神 = 0 } },
        { HeroType.鸿钧, new HeroData() { Level = 0, 元神 = 0 } },

    };

    public Dictionary<PropType, int> PropListDic = new Dictionary<PropType, int>()
    {
        { PropType.领主经验值, 0 },
        { PropType.全职业经验值, 0 },
        { PropType.功德, 0 },
        { PropType.头盔锻造石, 0 },
        { PropType.射手经验值, 0 },
        { PropType.戒指锻造石, 0 },
        { PropType.战士经验值, 0 },
        { PropType.护手锻造石, 0 },
        { PropType.招募卷, 0 },
        { PropType.控制经验值, 0 },
        { PropType.法师经验值, 0 },
        { PropType.洗练石, 0 },
        { PropType.灵魂, 0 },
        { PropType.衣服锻造石, 0 },
        { PropType.辅助经验值, 0 },
        { PropType.鞋子锻造石, 0 },
        { PropType.项链锻造石, 0 },
        { PropType.高级招募卷, 0 },
        
        { PropType.火之法则 ,0},
        { PropType.剑之法则 ,0},
        { PropType.冰之法则 ,0},
        { PropType.力之法则 ,0},
        { PropType.原始法则 ,0},
        { PropType.斗之法则 ,0},
        { PropType.日之法则 ,0},
        { PropType.月之法则 ,0},
        { PropType.禁之法则 ,0},
        { PropType.箭之法则 ,0},
        { PropType.诛仙法则 ,0},
        { PropType.造化法则 ,0},
        { PropType.道之法则 ,0},
        { PropType.鸿蒙法则 ,0},
    };

   

    

    public Dictionary<主线关卡Type, bool> LevelSmallJieSuoDic = new Dictionary<主线关卡Type, bool>()
    {
        { 主线关卡Type.花果山, true },
        { 主线关卡Type.水帘洞, false },
        { 主线关卡Type.傲来国, false },
        { 主线关卡Type.东海龙宫, false },
        { 主线关卡Type.蓬莱仙岛, false },
        { 主线关卡Type.五行山, false },
        { 主线关卡Type.高老庄, false },
        { 主线关卡Type.平顶山, false },
        { 主线关卡Type.女儿国, false },
        { 主线关卡Type.火焰山, false },
        { 主线关卡Type.狮驼岭, false },
        { 主线关卡Type.小雷音寺, false },
        { 主线关卡Type.流沙河, false },
        { 主线关卡Type.芭蕉洞, false },
        { 主线关卡Type.冥府, false },

    };
}
