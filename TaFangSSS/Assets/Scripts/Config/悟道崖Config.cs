using System.Collections.Generic;

public enum 大道Type
{
    //基础
    None,
    火焰,
    冰霜,
    黑暗,
    雷电,
    物理,
    战士,
    控制,
    射手,
    法师,
    辅助,
    //上等
    法器,
    丹药,
    符文,
    灵兽,
    仙女,
    灵植,
    领主装备,
    功法,
    元素,
    职业,
    最终伤害,
    暴击伤害,
    //至尊
    掉宝,
    时间流速,
    轮回,
    悟道,
    长生,
    //本源
    力,
}

public class 大道
{
    public 大道Type 大道Type;
    public float 等级;
    public float 经验;
}
public enum 大道效果Type
{
    None,
    击杀敌人概率留下火焰,
    火焰伤害增幅,
    
    击中概率落雷,
    雷电伤害增幅,
    
    击杀敌人爆炸,
    黑暗伤害增幅,
    
    冰霜伤害增幅,
    击杀敌人释放冰刺,
    
    物理伤害增幅,
    破甲上限提高到100,
    
    战士伤害增幅,
    战士每次攻击伤害增幅,
    
    控制伤害增幅,
    控制效果,
    
    法师伤害增幅,
    效果范围,
    
    射手伤害增幅,
    射手分裂,
    
    被辅助英雄伤害增幅,
    辅助效果,
    
    炼器速度,
    法器效果,
    法器荒品概率,
    法器无暇概率,
    
    炼丹速度,
    丹药效果,
    一炉双丹概率,
    丹药升阶概率,
    
    符文效果,
    符文无暇概率,
    符文融合概率,
    符文荒品概率,
    
    灵兽增幅,
    灵兽蛋荒品概率,
    灵兽生长速度,
    灵兽孵化速度,
    
    仙女增幅,
    仙女好感度增幅,
    
    灵植效果增幅,
    灵植生长速度,
    灵植变异概率,
    灵植产量,
    
    领主装备效果增幅,
    领主装备无暇概率增加,
    领主强化灵气减少,
    领主洗练灵气减少,
    
    功法效果,
    荒品功法概率,
    功法分解粉尘,
    功法层数速度增幅,
    
    元素伤害增加,
    职业伤害增加,
    最终伤害增加,
    暴击伤害增加,
    
    掉宝率增加,
    
    时间流速增加,
    
    轮回系数增加,
    
    修炼速度增加,
    
    每道龄增加伤害,
    
    增加所有大道效果,
    
}

public class 大道效果item
{
    public 大道效果Type 大道效果Type;
    public float count;
}
public class 大道配置
{
    public string name;
    public string 介绍;
    public List<大道效果item> 大道效果列表 = new List<大道效果item>();
    public 大道等级Type 大道等级Type;
    public string 果位名;
}

public enum 大道等级Type
{
    None,
    基础大道,
    上等大道,
    至尊大道,
    本源大道,
}

public enum 大道等级固定奖励Type
{
    None,
    伤害增幅,
    跟脚,
    真灵,
}

public class 大道等级固定奖励
{
    public 大道等级固定奖励Type 大道等级固定奖励Type;
    public float count;
}
public class 悟道崖Config
{
    public static Dictionary<大道Type, 大道配置> 大道配置 = new Dictionary<大道Type, 大道配置>()
    {
        // ==================== 基础大道 ====================
        {
            大道Type.火焰, new 大道配置()
            {
                name = "焚天大道",
                介绍 = "一点真火燃万界，焚尽苍穹万里空",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "焚天赤炎真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.击杀敌人概率留下火焰, count = 10f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.火焰伤害增幅, count = 20f },
                }
            }
        },
        {
            大道Type.冰霜, new 大道配置()
            {
                name = "寒冰大道",
                介绍 = "千里冰封寒彻骨，万古长河一瞬凝",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "玄冥凝霜真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.冰霜伤害增幅, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.击杀敌人释放冰刺, count = 10f },
                }
            }
        },
        {
            大道Type.黑暗, new 大道配置()
            {
                name = "幽冥大道",
                介绍 = "幽冥深处万物寂，万古虚空归寂灭",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "幽冥寂灭真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.击杀敌人爆炸, count = 10f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.黑暗伤害增幅, count = 20f },
                }
            }
        },
        {
            大道Type.雷电, new 大道配置()
            {
                name = "雷霆大道",
                介绍 = "九霄天威破万障，雷光一闪慑苍穹",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "紫府霆威真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.击中概率落雷, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.雷电伤害增幅, count = 20f },
                }
            }
        },
        {
            大道Type.物理, new 大道配置()
            {
                name = "肉身大道",
                介绍 = "肉身成圣踏寰宇，一力降十破万法",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "天罡镇岳真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.物理伤害增幅, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.破甲上限提高到100, count = 1f },
                }
            }
        },
        {
            大道Type.战士, new 大道配置()
            {
                name = "御战大道",
                介绍 = "一身杀伐冲霄汉，万古英魂战不休",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "杀伐戮战真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.战士伤害增幅, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.战士每次攻击伤害增幅, count = 5f },
                }
            }
        },
        {
            大道Type.控制, new 大道配置()
            {
                name = "御控大道",
                介绍 = "执掌乾坤定天下，一念翻覆动星辰",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "乾坤御衡真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.控制伤害增幅, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.控制效果, count = 20f },
                }
            }
        },
        {
            大道Type.射手, new 大道配置()
            {
                name = "御箭大道",
                介绍 = "一箭破云诛千里，射天射地射苍穹",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "星河穿云真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.射手伤害增幅, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.射手分裂, count = 1f },
                }
            }
        },
        {
            大道Type.法师, new 大道配置()
            {
                name = "御法大道",
                介绍 = "掐诀念咒引天机，一念法动惊九霄",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "玉清玄法真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.法师伤害增幅, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.效果范围, count = 20f },
                }
            }
        },
        {
            大道Type.辅助, new 大道配置()
            {
                name = "御辅大道",
                介绍 = "玄功护持渡众生，润物无声道自明",
                大道等级Type = 大道等级Type.基础大道,
                果位名 = "慈航护度真君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.被辅助英雄伤害增幅, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.辅助效果, count = 20f },
                }
            }
        },

        // ==================== 上等大道 ====================
        {
            大道Type.法器, new 大道配置()
            {
                name = "器之大道",
                介绍 = "千锤百炼出神锋，一器成时动乾坤",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "灵宝通神天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.炼器速度, count = 50f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.法器效果, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.法器荒品概率, count = 10f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.法器无暇概率, count = 15f },
                }
            }
        },
        {
            大道Type.丹药, new 大道配置()
            {
                name = "丹之大道",
                介绍 = "九转丹成换生死，一颗灵丹脱凡尘",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "九转玄丹天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.炼丹速度, count = 50f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.丹药效果, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.一炉双丹概率, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.丹药升阶概率, count = 10f },
                }
            }
        },
        {
            大道Type.符文, new 大道配置()
            {
                name = "符之大道",
                介绍 = "一笔落下天地惊，符文万卷定幽冥",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "云箓紫府天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.符文效果, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.符文无暇概率, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.符文融合概率, count = 10f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.符文荒品概率, count = 10f },
                }
            }
        },
        {
            大道Type.灵兽, new 大道配置()
            {
                name = "御兽大道",
                介绍 = "万兽朝宗踏虚空，一声长啸动天廷",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "万灵朝宗天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵兽增幅, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵兽蛋荒品概率, count = 10f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵兽生长速度, count = 30f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵兽孵化速度, count = 30f },
                }
            }
        },
        {
            大道Type.仙女, new 大道配置()
            {
                name = "阴阳大道",
                介绍 = "红袖添香伴修行，仙缘一线牵万世",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "阴阳合欢天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.仙女增幅, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.仙女好感度增幅, count = 30f },
                }
            }
        },
        {
            大道Type.灵植, new 大道配置()
            {
                name = "造化大道",
                介绍 = "一粒灵根种天地，百草成精护苍生",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "造化元成天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵植效果增幅, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵植生长速度, count = 30f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵植变异概率, count = 10f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.灵植产量, count = 25f },
                }
            }
        },
        {
            大道Type.领主装备, new 大道配置()
            {
                name = "君主大道",
                介绍 = "王者一怒山河碎，百万雄狮踏八荒",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "混元霸统天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.领主装备效果增幅, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.领主装备无暇概率增加, count = 15f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.领主强化灵气减少, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.领主洗练灵气减少, count = 20f },
                }
            }
        },
        {
            大道Type.功法, new 大道配置()
            {
                name = "悟法大道",
                介绍 = "一卷功法通天地，苦修终得见真我",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "玄功悟彻天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.功法效果, count = 20f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.荒品功法概率, count = 10f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.功法分解粉尘, count = 30f },
                    new 大道效果item() { 大道效果Type = 大道效果Type.功法层数速度增幅, count = 25f },
                }
            }
        },
        {
            大道Type.元素, new 大道配置()
            {
                name = "五行大道",
                介绍 = "五行轮转生生息，相生相克化万机",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "五行化生天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.元素伤害增加, count = 30f },
                }
            }
        },
        {
            大道Type.职业, new 大道配置()
            {
                name = "万象大道",
                介绍 = "一技精修通天彻，术业有专攻万灵",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "万象归元天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.职业伤害增加, count = 30f },
                }
            }
        },
        {
            大道Type.最终伤害, new 大道配置()
            {
                name = "毁灭大道",
                介绍 = "一击必杀无生机，千军万马亦难回",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "灭世绝生天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.最终伤害增加, count = 25f },
                }
            }
        },
        {
            大道Type.暴击伤害, new 大道配置()
            {
                name = "杀戮大道",
                介绍 = "锋芒毕露屠万里，一击便使鬼神泣",
                大道等级Type = 大道等级Type.上等大道,
                果位名 = "血煞噬天天君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.暴击伤害增加, count = 40f },
                }
            }
        },

        // ==================== 至尊大道 ====================
        {
            大道Type.掉宝, new 大道配置()
            {
                name = "寻龙大道",
                介绍 = "紫气东来三万里，天材地宝聚道心",
                大道等级Type = 大道等级Type.至尊大道,
                果位名 = "紫气玄天道君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.掉宝率增加, count = 30f },
                }
            }
        },
        {
            大道Type.时间流速, new 大道配置()
            {
                name = "时间大道",
                介绍 = "弹指一挥万古过，岁月长河任我行",
                大道等级Type = 大道等级Type.至尊大道,
                果位名 = "万古不朽道君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.时间流速增加, count = 20f },
                }
            }
        },
        {
            大道Type.轮回, new 大道配置()
            {
                name = "轮回大道",
                介绍 = "百世轮回悟真如，涅槃重生踏天途",
                大道等级Type = 大道等级Type.至尊大道,
                果位名 = "玄天轮回道君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.轮回系数增加, count = 25f },
                }
            }
        },
        {
            大道Type.悟道, new 大道配置()
            {
                name = "悟道大道",
                介绍 = "一朝顿悟观天地，方知大道在心中",
                大道等级Type = 大道等级Type.至尊大道,
                果位名 = "通天悟道道君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.修炼速度增加, count = 50f },
                }
            }
        },
        {
            大道Type.长生, new 大道配置()
            {
                name = "长生大道",
                介绍 = "天地有尽我无尽，日月同辉证永恒",
                大道等级Type = 大道等级Type.至尊大道,
                果位名 = "太虚长生道君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.每道龄增加伤害, count = 2f },
                }
            }
        },

        // ==================== 本源大道 ====================
        {
            大道Type.力, new 大道配置()
            {
                name = "力之大道",
                介绍 = "大道之力源无尽，一掌可推日月星",
                大道等级Type = 大道等级Type.本源大道,
                果位名 = "混元无极帝君",
                大道效果列表 = new List<大道效果item>()
                {
                    new 大道效果item() { 大道效果Type = 大道效果Type.增加所有大道效果, count = 10f },
                }
            }
        },
    };
    public static Dictionary<大道Type, List<大道Type>> 大道限制列表 = new Dictionary<大道Type, List<大道Type>>()
    {
        { 大道Type.法器 ,new List<大道Type>() { 大道Type.冰霜 ,大道Type.火焰,大道Type.战士,大道Type.射手}},
        { 大道Type.丹药 ,new List<大道Type>() { 大道Type.冰霜 ,大道Type.物理,大道Type.战士,大道Type.法师}},
        { 大道Type.符文 ,new List<大道Type>() { 大道Type.冰霜 ,大道Type.雷电,大道Type.战士,大道Type.辅助}},
        { 大道Type.灵兽 ,new List<大道Type>() { 大道Type.冰霜 ,大道Type.黑暗,大道Type.战士,大道Type.控制}},
        { 大道Type.仙女 ,new List<大道Type>() { 大道Type.物理 ,大道Type.雷电,大道Type.射手,大道Type.法师}},
        { 大道Type.灵植 ,new List<大道Type>() { 大道Type.物理 ,大道Type.黑暗,大道Type.射手,大道Type.控制}},
        { 大道Type.领主装备 ,new List<大道Type>() { 大道Type.物理 ,大道Type.火焰,大道Type.射手,大道Type.辅助}},
        { 大道Type.功法 ,new List<大道Type>() { 大道Type.雷电 ,大道Type.黑暗,大道Type.控制,大道Type.法师}},
        { 大道Type.元素 ,new List<大道Type>() { 大道Type.雷电 ,大道Type.火焰,大道Type.冰霜,大道Type.黑暗,大道Type.物理}},
        { 大道Type.职业 ,new List<大道Type>() { 大道Type.射手 ,大道Type.战士,大道Type.法师,大道Type.辅助,大道Type.控制}},
        { 大道Type.最终伤害 ,new List<大道Type>() { 大道Type.雷电 ,大道Type.物理,大道Type.法师,大道Type.辅助}},
        { 大道Type.暴击伤害 ,new List<大道Type>() { 大道Type.物理 ,大道Type.黑暗,大道Type.控制,大道Type.辅助}},

        { 大道Type.掉宝 ,new List<大道Type>() { 大道Type.法器 ,大道Type.丹药,大道Type.灵兽,大道Type.符文,大道Type.仙女,大道Type.灵植}},
        { 大道Type.时间流速 ,new List<大道Type>() { 大道Type.领主装备 ,大道Type.功法,大道Type.元素,大道Type.职业,大道Type.暴击伤害,大道Type.最终伤害}},
        { 大道Type.悟道 ,new List<大道Type>() { 大道Type.法器 ,大道Type.丹药,大道Type.灵兽,大道Type.职业,大道Type.暴击伤害,大道Type.最终伤害}},
        { 大道Type.长生 ,new List<大道Type>() { 大道Type.符文 ,大道Type.仙女,大道Type.灵植,大道Type.领主装备,大道Type.功法,大道Type.元素}},
        { 大道Type.轮回 ,new List<大道Type>() { 大道Type.法器 ,大道Type.丹药,大道Type.仙女,大道Type.元素,大道Type.职业,大道Type.最终伤害}},

        { 大道Type.力 ,new List<大道Type>() { 大道Type.掉宝 ,大道Type.时间流速,大道Type.悟道,大道Type.长生,大道Type.轮回}},

    };

    public static Dictionary<大道等级Type, int> 大道果位解锁等级 = new Dictionary<大道等级Type, int>()
    {
        { 大道等级Type.基础大道 ,100},
        { 大道等级Type.上等大道 ,100},
        { 大道等级Type.至尊大道 ,100},
        { 大道等级Type.本源大道 ,100},
    };
    
    public static Dictionary<大道等级Type, float> 大道经验 = new Dictionary<大道等级Type, float>()
    {
        { 大道等级Type.基础大道 ,1000000},
        { 大道等级Type.上等大道 ,10000000},
        { 大道等级Type.至尊大道 ,100000000},
        { 大道等级Type.本源大道 ,1000000000},
    };
    
    public static Dictionary<大道等级Type, 大道等级固定奖励> 大道等级奖励 = new Dictionary<大道等级Type, 大道等级固定奖励>()
    {
        { 大道等级Type.基础大道 ,new 大道等级固定奖励(){大道等级固定奖励Type= 大道等级固定奖励Type.伤害增幅,count = 10}},
        { 大道等级Type.上等大道 ,new 大道等级固定奖励(){大道等级固定奖励Type= 大道等级固定奖励Type.跟脚,count = 10}},
        { 大道等级Type.至尊大道 ,new 大道等级固定奖励(){大道等级固定奖励Type= 大道等级固定奖励Type.真灵,count = 10}},
        { 大道等级Type.本源大道 ,new 大道等级固定奖励(){大道等级固定奖励Type= 大道等级固定奖励Type.真灵,count = 1000}},
    };
}
