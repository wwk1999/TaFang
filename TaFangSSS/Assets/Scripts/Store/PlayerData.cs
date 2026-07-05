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

    public Dictionary<(道纹Type 道纹Type, QualityType QualityType), int> 道纹List = new Dictionary<(道纹Type, QualityType), int>()
{
    // 增加百分比攻击力
    {(道纹Type.增加百分比攻击力, QualityType.天品), 0},
    {(道纹Type.增加百分比攻击力, QualityType.宇品), 0},
    {(道纹Type.增加百分比攻击力, QualityType.宙品), 0},
    {(道纹Type.增加百分比攻击力, QualityType.洪品), 0},
    {(道纹Type.增加百分比攻击力, QualityType.荒品), 0},

    // 增加战士伤害
    {(道纹Type.增加战士伤害, QualityType.天品), 0},
    {(道纹Type.增加战士伤害, QualityType.宇品), 0},
    {(道纹Type.增加战士伤害, QualityType.宙品), 0},
    {(道纹Type.增加战士伤害, QualityType.洪品), 0},
    {(道纹Type.增加战士伤害, QualityType.荒品), 0},

    // 增加法师伤害
    {(道纹Type.增加法师伤害, QualityType.天品), 0},
    {(道纹Type.增加法师伤害, QualityType.宇品), 0},
    {(道纹Type.增加法师伤害, QualityType.宙品), 0},
    {(道纹Type.增加法师伤害, QualityType.洪品), 0},
    {(道纹Type.增加法师伤害, QualityType.荒品), 0},

    // 增加控制伤害
    {(道纹Type.增加控制伤害, QualityType.天品), 0},
    {(道纹Type.增加控制伤害, QualityType.宇品), 0},
    {(道纹Type.增加控制伤害, QualityType.宙品), 0},
    {(道纹Type.增加控制伤害, QualityType.洪品), 0},
    {(道纹Type.增加控制伤害, QualityType.荒品), 0},

    // 增加射手伤害
    {(道纹Type.增加射手伤害, QualityType.天品), 0},
    {(道纹Type.增加射手伤害, QualityType.宇品), 0},
    {(道纹Type.增加射手伤害, QualityType.宙品), 0},
    {(道纹Type.增加射手伤害, QualityType.洪品), 0},
    {(道纹Type.增加射手伤害, QualityType.荒品), 0},

    // 增加小怪伤害
    {(道纹Type.增加小怪伤害, QualityType.天品), 0},
    {(道纹Type.增加小怪伤害, QualityType.宇品), 0},
    {(道纹Type.增加小怪伤害, QualityType.宙品), 0},
    {(道纹Type.增加小怪伤害, QualityType.洪品), 0},
    {(道纹Type.增加小怪伤害, QualityType.荒品), 0},

    // 增加物理伤害
    {(道纹Type.增加物理伤害, QualityType.天品), 0},
    {(道纹Type.增加物理伤害, QualityType.宇品), 0},
    {(道纹Type.增加物理伤害, QualityType.宙品), 0},
    {(道纹Type.增加物理伤害, QualityType.洪品), 0},
    {(道纹Type.增加物理伤害, QualityType.荒品), 0},

    // 增加雷电伤害
    {(道纹Type.增加雷电伤害, QualityType.天品), 0},
    {(道纹Type.增加雷电伤害, QualityType.宇品), 0},
    {(道纹Type.增加雷电伤害, QualityType.宙品), 0},
    {(道纹Type.增加雷电伤害, QualityType.洪品), 0},
    {(道纹Type.增加雷电伤害, QualityType.荒品), 0},

    // 增加冰霜伤害
    {(道纹Type.增加冰霜伤害, QualityType.天品), 0},
    {(道纹Type.增加冰霜伤害, QualityType.宇品), 0},
    {(道纹Type.增加冰霜伤害, QualityType.宙品), 0},
    {(道纹Type.增加冰霜伤害, QualityType.洪品), 0},
    {(道纹Type.增加冰霜伤害, QualityType.荒品), 0},

    // 增加黑暗伤害
    {(道纹Type.增加黑暗伤害, QualityType.天品), 0},
    {(道纹Type.增加黑暗伤害, QualityType.宇品), 0},
    {(道纹Type.增加黑暗伤害, QualityType.宙品), 0},
    {(道纹Type.增加黑暗伤害, QualityType.洪品), 0},
    {(道纹Type.增加黑暗伤害, QualityType.荒品), 0},

    // 增加火焰伤害
    {(道纹Type.增加火焰伤害, QualityType.天品), 0},
    {(道纹Type.增加火焰伤害, QualityType.宇品), 0},
    {(道纹Type.增加火焰伤害, QualityType.宙品), 0},
    {(道纹Type.增加火焰伤害, QualityType.洪品), 0},
    {(道纹Type.增加火焰伤害, QualityType.荒品), 0},

    // 增加精英怪和首领伤害
    {(道纹Type.增加精英怪和首领伤害, QualityType.天品), 0},
    {(道纹Type.增加精英怪和首领伤害, QualityType.宇品), 0},
    {(道纹Type.增加精英怪和首领伤害, QualityType.宙品), 0},
    {(道纹Type.增加精英怪和首领伤害, QualityType.洪品), 0},
    {(道纹Type.增加精英怪和首领伤害, QualityType.荒品), 0},

    // 城墙低血增加伤害
    {(道纹Type.城墙低血增加伤害, QualityType.天品), 0},
    {(道纹Type.城墙低血增加伤害, QualityType.宇品), 0},
    {(道纹Type.城墙低血增加伤害, QualityType.宙品), 0},
    {(道纹Type.城墙低血增加伤害, QualityType.洪品), 0},
    {(道纹Type.城墙低血增加伤害, QualityType.荒品), 0},

    // 击杀精英怪城墙回血
    {(道纹Type.击杀精英怪城墙回血, QualityType.天品), 0},
    {(道纹Type.击杀精英怪城墙回血, QualityType.宇品), 0},
    {(道纹Type.击杀精英怪城墙回血, QualityType.宙品), 0},
    {(道纹Type.击杀精英怪城墙回血, QualityType.洪品), 0},
    {(道纹Type.击杀精英怪城墙回血, QualityType.荒品), 0},

    // 城墙血量百分比
    {(道纹Type.城墙血量百分比, QualityType.天品), 0},
    {(道纹Type.城墙血量百分比, QualityType.宇品), 0},
    {(道纹Type.城墙血量百分比, QualityType.宙品), 0},
    {(道纹Type.城墙血量百分比, QualityType.洪品), 0},
    {(道纹Type.城墙血量百分比, QualityType.荒品), 0},

    // 城墙免疫伤害
    {(道纹Type.城墙免疫伤害, QualityType.天品), 0},
    {(道纹Type.城墙免疫伤害, QualityType.宇品), 0},
    {(道纹Type.城墙免疫伤害, QualityType.宙品), 0},
    {(道纹Type.城墙免疫伤害, QualityType.洪品), 0},
    {(道纹Type.城墙免疫伤害, QualityType.荒品), 0},

    // 城墙满血时加伤害
    {(道纹Type.城墙满血时加伤害, QualityType.天品), 0},
    {(道纹Type.城墙满血时加伤害, QualityType.宇品), 0},
    {(道纹Type.城墙满血时加伤害, QualityType.宙品), 0},
    {(道纹Type.城墙满血时加伤害, QualityType.洪品), 0},
    {(道纹Type.城墙满血时加伤害, QualityType.荒品), 0},

    // 英雄暴击率
    {(道纹Type.英雄暴击率, QualityType.天品), 0},
    {(道纹Type.英雄暴击率, QualityType.宇品), 0},
    {(道纹Type.英雄暴击率, QualityType.宙品), 0},
    {(道纹Type.英雄暴击率, QualityType.洪品), 0},
    {(道纹Type.英雄暴击率, QualityType.荒品), 0},

    // 伤害在范围内浮动
    {(道纹Type.伤害在范围内浮动, QualityType.天品), 0},
    {(道纹Type.伤害在范围内浮动, QualityType.宇品), 0},
    {(道纹Type.伤害在范围内浮动, QualityType.宙品), 0},
    {(道纹Type.伤害在范围内浮动, QualityType.洪品), 0},
    {(道纹Type.伤害在范围内浮动, QualityType.荒品), 0},

    // 无视抗性
    {(道纹Type.无视抗性, QualityType.天品), 0},
    {(道纹Type.无视抗性, QualityType.宇品), 0},
    {(道纹Type.无视抗性, QualityType.宙品), 0},
    {(道纹Type.无视抗性, QualityType.洪品), 0},
    {(道纹Type.无视抗性, QualityType.荒品), 0},

    // 战士对靠近城墙敌人伤害增高
    {(道纹Type.战士对靠近城墙敌人伤害增高, QualityType.天品), 0},
    {(道纹Type.战士对靠近城墙敌人伤害增高, QualityType.宇品), 0},
    {(道纹Type.战士对靠近城墙敌人伤害增高, QualityType.宙品), 0},
    {(道纹Type.战士对靠近城墙敌人伤害增高, QualityType.洪品), 0},
    {(道纹Type.战士对靠近城墙敌人伤害增高, QualityType.荒品), 0},

    // 射手连射概率
    {(道纹Type.射手连射概率, QualityType.天品), 0},
    {(道纹Type.射手连射概率, QualityType.宇品), 0},
    {(道纹Type.射手连射概率, QualityType.宙品), 0},
    {(道纹Type.射手连射概率, QualityType.洪品), 0},
    {(道纹Type.射手连射概率, QualityType.荒品), 0},

    // 控制冷却缩减
    {(道纹Type.控制冷却缩减, QualityType.天品), 0},
    {(道纹Type.控制冷却缩减, QualityType.宇品), 0},
    {(道纹Type.控制冷却缩减, QualityType.宙品), 0},
    {(道纹Type.控制冷却缩减, QualityType.洪品), 0},
    {(道纹Type.控制冷却缩减, QualityType.荒品), 0},

    // 法师暴击率
    {(道纹Type.法师暴击率, QualityType.天品), 0},
    {(道纹Type.法师暴击率, QualityType.宇品), 0},
    {(道纹Type.法师暴击率, QualityType.宙品), 0},
    {(道纹Type.法师暴击率, QualityType.洪品), 0},
    {(道纹Type.法师暴击率, QualityType.荒品), 0},

    // 辅助被辅助英雄伤害增幅
    {(道纹Type.辅助被辅助英雄伤害增幅, QualityType.天品), 0},
    {(道纹Type.辅助被辅助英雄伤害增幅, QualityType.宇品), 0},
    {(道纹Type.辅助被辅助英雄伤害增幅, QualityType.宙品), 0},
    {(道纹Type.辅助被辅助英雄伤害增幅, QualityType.洪品), 0},
    {(道纹Type.辅助被辅助英雄伤害增幅, QualityType.荒品), 0},

    // 三味真火无视抗性百分比
    {(道纹Type.三味真火无视抗性百分比, QualityType.天品), 0},
    {(道纹Type.三味真火无视抗性百分比, QualityType.宇品), 0},
    {(道纹Type.三味真火无视抗性百分比, QualityType.宙品), 0},
    {(道纹Type.三味真火无视抗性百分比, QualityType.洪品), 0},
    {(道纹Type.三味真火无视抗性百分比, QualityType.荒品), 0},

    // 孙悟空每秒增加伤害
    {(道纹Type.孙悟空每秒增加伤害, QualityType.天品), 0},
    {(道纹Type.孙悟空每秒增加伤害, QualityType.宇品), 0},
    {(道纹Type.孙悟空每秒增加伤害, QualityType.宙品), 0},
    {(道纹Type.孙悟空每秒增加伤害, QualityType.洪品), 0},
    {(道纹Type.孙悟空每秒增加伤害, QualityType.荒品), 0},

    // 碧霄冰龙有概率再次释放
    {(道纹Type.碧霄冰龙有概率再次释放, QualityType.天品), 0},
    {(道纹Type.碧霄冰龙有概率再次释放, QualityType.宇品), 0},
    {(道纹Type.碧霄冰龙有概率再次释放, QualityType.宙品), 0},
    {(道纹Type.碧霄冰龙有概率再次释放, QualityType.洪品), 0},
    {(道纹Type.碧霄冰龙有概率再次释放, QualityType.荒品), 0},

    // 琼霄定身衰减效果减少
    {(道纹Type.琼霄定身衰减效果减少, QualityType.天品), 0},
    {(道纹Type.琼霄定身衰减效果减少, QualityType.宇品), 0},
    {(道纹Type.琼霄定身衰减效果减少, QualityType.宙品), 0},
    {(道纹Type.琼霄定身衰减效果减少, QualityType.洪品), 0},
    {(道纹Type.琼霄定身衰减效果减少, QualityType.荒品), 0},

    // 云霄暴击率
    {(道纹Type.云霄暴击率, QualityType.天品), 0},
    {(道纹Type.云霄暴击率, QualityType.宇品), 0},
    {(道纹Type.云霄暴击率, QualityType.宙品), 0},
    {(道纹Type.云霄暴击率, QualityType.洪品), 0},
    {(道纹Type.云霄暴击率, QualityType.荒品), 0},

    // 后羿距离越远伤害越高
    {(道纹Type.后羿距离越远伤害越高, QualityType.天品), 0},
    {(道纹Type.后羿距离越远伤害越高, QualityType.宇品), 0},
    {(道纹Type.后羿距离越远伤害越高, QualityType.宙品), 0},
    {(道纹Type.后羿距离越远伤害越高, QualityType.洪品), 0},
    {(道纹Type.后羿距离越远伤害越高, QualityType.荒品), 0},

    // 羲和灼烧伤害
    {(道纹Type.羲和灼烧伤害, QualityType.天品), 0},
    {(道纹Type.羲和灼烧伤害, QualityType.宇品), 0},
    {(道纹Type.羲和灼烧伤害, QualityType.宙品), 0},
    {(道纹Type.羲和灼烧伤害, QualityType.洪品), 0},
    {(道纹Type.羲和灼烧伤害, QualityType.荒品), 0},

    // 常曦有概率冻结敌人
    {(道纹Type.常曦有概率冻结敌人, QualityType.天品), 0},
    {(道纹Type.常曦有概率冻结敌人, QualityType.宇品), 0},
    {(道纹Type.常曦有概率冻结敌人, QualityType.宙品), 0},
    {(道纹Type.常曦有概率冻结敌人, QualityType.洪品), 0},
    {(道纹Type.常曦有概率冻结敌人, QualityType.荒品), 0},

    // 女娲增加被辅助英雄暴击率
    {(道纹Type.女娲增加被辅助英雄暴击率, QualityType.天品), 0},
    {(道纹Type.女娲增加被辅助英雄暴击率, QualityType.宇品), 0},
    {(道纹Type.女娲增加被辅助英雄暴击率, QualityType.宙品), 0},
    {(道纹Type.女娲增加被辅助英雄暴击率, QualityType.洪品), 0},
    {(道纹Type.女娲增加被辅助英雄暴击率, QualityType.荒品), 0},

    // 通天每次暴击增加伤害
    {(道纹Type.通天每次暴击增加伤害, QualityType.天品), 0},
    {(道纹Type.通天每次暴击增加伤害, QualityType.宇品), 0},
    {(道纹Type.通天每次暴击增加伤害, QualityType.宙品), 0},
    {(道纹Type.通天每次暴击增加伤害, QualityType.洪品), 0},
    {(道纹Type.通天每次暴击增加伤害, QualityType.荒品), 0},

    // 老子旋风体积越大伤害越高
    {(道纹Type.老子旋风体积越大伤害越高, QualityType.天品), 0},
    {(道纹Type.老子旋风体积越大伤害越高, QualityType.宇品), 0},
    {(道纹Type.老子旋风体积越大伤害越高, QualityType.宙品), 0},
    {(道纹Type.老子旋风体积越大伤害越高, QualityType.洪品), 0},
    {(道纹Type.老子旋风体积越大伤害越高, QualityType.荒品), 0},

    // 元始每次释放有概率增加火种数量
    {(道纹Type.元始每次释放有概率增加火种数量, QualityType.天品), 0},
    {(道纹Type.元始每次释放有概率增加火种数量, QualityType.宇品), 0},
    {(道纹Type.元始每次释放有概率增加火种数量, QualityType.宙品), 0},
    {(道纹Type.元始每次释放有概率增加火种数量, QualityType.洪品), 0},
    {(道纹Type.元始每次释放有概率增加火种数量, QualityType.荒品), 0},

    // 鸿钧每释放陨石增加伤害
    {(道纹Type.鸿钧每释放陨石增加伤害, QualityType.天品), 0},
    {(道纹Type.鸿钧每释放陨石增加伤害, QualityType.宇品), 0},
    {(道纹Type.鸿钧每释放陨石增加伤害, QualityType.宙品), 0},
    {(道纹Type.鸿钧每释放陨石增加伤害, QualityType.洪品), 0},
    {(道纹Type.鸿钧每释放陨石增加伤害, QualityType.荒品), 0},

    // 盘古每击杀敌人增加伤害
    {(道纹Type.盘古每击杀敌人增加伤害, QualityType.天品), 0},
    {(道纹Type.盘古每击杀敌人增加伤害, QualityType.宇品), 0},
    {(道纹Type.盘古每击杀敌人增加伤害, QualityType.宙品), 0},
    {(道纹Type.盘古每击杀敌人增加伤害, QualityType.洪品), 0},
    {(道纹Type.盘古每击杀敌人增加伤害, QualityType.荒品), 0},
};
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

    public Dictionary<LevelBigType, bool> LevelZhanKaiDic = new Dictionary<LevelBigType, bool>()
    {
        { LevelBigType.东胜神州, false },
        { LevelBigType.西牛贺洲, false },
        { LevelBigType.南瞻部洲, false },
        { LevelBigType.北俱芦洲, false },
    };

    public Dictionary<LevelBigType, bool> LevelBigJieSuoDic = new Dictionary<LevelBigType, bool>()
    {
        { LevelBigType.东胜神州, true },
        { LevelBigType.西牛贺洲, false },
        { LevelBigType.南瞻部洲, false },
        { LevelBigType.北俱芦洲, false },
    };

    public Dictionary<LevelSmallType, bool> LevelSmallJieSuoDic = new Dictionary<LevelSmallType, bool>()
    {
        { LevelSmallType.花果山, true },
        { LevelSmallType.水帘洞, false },
        { LevelSmallType.傲来国, false },
        { LevelSmallType.东海龙宫, false },
        { LevelSmallType.蓬莱仙岛, false },
        { LevelSmallType.五行山, false },
        { LevelSmallType.高老庄, false },
        { LevelSmallType.平顶山, false },
        { LevelSmallType.车迟国, false },
        { LevelSmallType.女儿国, false },
        { LevelSmallType.火焰山, false },
        { LevelSmallType.盘丝洞, false },
        { LevelSmallType.狮驼岭, false },
        { LevelSmallType.天竺国, false },
        { LevelSmallType.小雷音寺, false },
        { LevelSmallType.流沙河, false },
        { LevelSmallType.芭蕉洞, false },
    };
}
