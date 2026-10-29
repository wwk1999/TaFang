using System;
using System.Collections.Generic;

public enum 仙子Type
{
    None,
    伤害,
    炼丹,
    炼器,
    功法,
    符文,
    领主装备,
    灵兽,
    合欢,
    掉宝,
    时间流速,
}

public class 仙子属性
{
    public float 最终伤害;
    public float 元素伤害;
    public float 职业伤害;
    public float 暴击伤害;
    public float 暴击率;
    public float 攻击力;
    public float 元素穿透;
    
    public float 炼丹速度;
    public float 炼丹经验;
    public float 丹药效果;
    public float 一炉双丹概率;
    public float 提升品质概率;
    public float 提升阶数概率;
    
    public float 炼器速度;
    public float 法器效果;
    public float 一炉双器概率;
    public float 加荒品打造概率;
    public float 加分解粉尘;
    public float 加法器无暇洗练概率;
    
    public float 功法层数效果;
    public float 功法层数速度增幅;
    public float 加功法分解粉尘;
    public float 加荒品功法概率;
    public float 传道功德消耗减少;
    public float 每道年传道次数翻倍;
    
    public float 符文效果;
    public float 宇品以上符文掉落概率;
    public float 荒品符文掉落概率;
    public float 符文无暇概率增加;
    public float 符文融合成功概率增加;
    public float 分解符箓增加;
    
    public float 领主装备所有效果;
    public float 无暇洗练概率增加;
    public float 强化灵气消耗减少;
    public float 领主装备攻击力增加;
    public float 领主装备词条效果增加;
    public float 洗练灵气消耗减少;
    
    public float 灵兽增幅;
    public float 灵兽生长速度;
    public float 灵兽洗练无暇概率增加;
    public float 灵兽蛋数量增加;
    public float 灵兽蛋荒品概率增加;
    public float 孵化时间缩减;
    
    public float 仙子效果;
    public float 好感度增加;
    public float 灵植生长速度;
    public float 灵植变异概率;
    public float 喜好灵植额外加好感;
    public float 变异灵植额外加好感;

    public float 掉宝率;
    public float 灵气增幅;
    public float 轮回石掉落数量增加;

    public float 时间流速;
}

public class 仙女
{
    public 仙子Type 仙子Type;
    public int 好感度等级;
    public int 好感度经验;
    public bool 解锁;
}
public class 仙子等级解锁属性
{
    public 仙子属性 仙子属性1;
    public 仙子属性 仙子属性2;
    public 仙子属性 仙子属性3;
    public 仙子属性 仙子属性4;
    public 仙子属性 仙子属性5;
    public 仙子属性 仙子属性6;
}

public class 阴阳殿Config
{
    
    public static Dictionary<仙子Type, 仙子等级解锁属性> 仙子等级解锁奖励 = new Dictionary<仙子Type, 仙子等级解锁属性>()
    {
        {
            仙子Type.伤害,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 元素伤害 = 10 }, 仙子属性2 = new 仙子属性() { 职业伤害 = 20 }, 仙子属性3 = new 仙子属性() { 元素穿透 = 30 },
                仙子属性4 = new 仙子属性() { 暴击率 = 30 }, 仙子属性5 = new 仙子属性() { 暴击伤害 = 300 }, 仙子属性6 = new 仙子属性() { 攻击力 = 1000 }
            }
        },
        {
            仙子Type.炼丹,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 炼丹速度 = 10 }, 仙子属性2 = new 仙子属性() { 炼丹经验 = 20 }, 仙子属性3 = new 仙子属性() { 丹药效果 = 30 },
                仙子属性4 = new 仙子属性() { 一炉双丹概率 = 15 }, 仙子属性5 = new 仙子属性() { 提升品质概率 = 10 },
                仙子属性6 = new 仙子属性() { 提升阶数概率 = 5 }
            }
        },
        {
            仙子Type.炼器,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 炼器速度 = 10 }, 仙子属性2 = new 仙子属性() { 法器效果 = 20 }, 仙子属性3 = new 仙子属性() { 加分解粉尘 = 30 },
                仙子属性4 = new 仙子属性() { 一炉双器概率 = 15 }, 仙子属性5 = new 仙子属性() { 加荒品打造概率 = 30 }, 仙子属性6 = new 仙子属性() { 加法器无暇洗练概率 = 100 }
            }
        },
        {
            仙子Type.功法,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 功法层数效果 = 10 }, 仙子属性2 = new 仙子属性() { 每道年传道次数翻倍 = 1 }, 仙子属性3 = new 仙子属性() { 传道功德消耗减少 = 30 },
                仙子属性4 = new 仙子属性() { 功法层数速度增幅 = 50 }, 仙子属性5 = new 仙子属性() { 加功法分解粉尘 = 100 }, 仙子属性6 = new 仙子属性() { 加荒品功法概率 = 100 }
            }
        },
        {
            仙子Type.符文,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 符文效果 = 10 }, 仙子属性2 = new 仙子属性() { 宇品以上符文掉落概率 = 20 }, 仙子属性3 = new 仙子属性() { 分解符箓增加 = 30 },
                仙子属性4 = new 仙子属性() { 符文融合成功概率增加 = 30 }, 仙子属性5 = new 仙子属性() { 荒品符文掉落概率 = 50 }, 仙子属性6 = new 仙子属性() { 符文无暇概率增加 = 100 }
            }
        },
        {
            仙子Type.领主装备,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 领主装备所有效果 = 10 }, 仙子属性2 = new 仙子属性() { 领主装备攻击力增加 = 20 }, 仙子属性3 = new 仙子属性() { 领主装备词条效果增加 = 30 },
                仙子属性4 = new 仙子属性() { 强化灵气消耗减少 = 30 }, 仙子属性5 = new 仙子属性() { 洗练灵气消耗减少 = 30 }, 仙子属性6 = new 仙子属性() { 无暇洗练概率增加 = 100 }
            }
        },
        {
            仙子Type.灵兽,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 灵兽增幅 = 10 }, 仙子属性2 = new 仙子属性() { 灵兽蛋数量增加 = 15 }, 仙子属性3 = new 仙子属性() { 孵化时间缩减 = 20 },
                仙子属性4 = new 仙子属性() { 灵兽生长速度 = 50 }, 仙子属性5 = new 仙子属性() { 灵兽蛋荒品概率增加 = 100 }, 仙子属性6 = new 仙子属性() { 灵兽洗练无暇概率增加 = 100 }
            }
        },
        {
            仙子Type.合欢,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 仙子效果 = 10 }, 仙子属性2 = new 仙子属性() { 灵植生长速度 = 20 }, 仙子属性3 = new 仙子属性() { 灵植变异概率 =30 },
                仙子属性4 = new 仙子属性() { 喜好灵植额外加好感 = 50 }, 仙子属性5 = new 仙子属性() { 变异灵植额外加好感 = 100 }, 仙子属性6 = new 仙子属性() { 好感度增加 = 100 }
            }
        },
        {
            仙子Type.掉宝,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 掉宝率 = 10 }, 仙子属性2 = new 仙子属性() { 掉宝率 = 20 }, 仙子属性3 = new 仙子属性() { 掉宝率 = 30 },
                仙子属性4 = new 仙子属性() { 掉宝率 = 50 }, 仙子属性5 = new 仙子属性() { 灵气增幅 = 50 }, 仙子属性6 = new 仙子属性() { 轮回石掉落数量增加 = 1 }
            }
        },
        {
            仙子Type.时间流速,
            new 仙子等级解锁属性()
            {
                仙子属性1 = new 仙子属性() { 时间流速 = 10 }, 仙子属性2 = new 仙子属性() { 时间流速 = 20 }, 仙子属性3 = new 仙子属性() { 时间流速 = 30 },
                仙子属性4 = new 仙子属性() { 时间流速 = 50 }, 仙子属性5 = new 仙子属性() { 时间流速 = 100 }, 仙子属性6 = new 仙子属性() { 时间流速 = 300 }
            }
        },
    };

    public static Dictionary<仙子Type, 仙子属性> 仙子每级固定奖励 = new Dictionary<仙子Type, 仙子属性>()
    {
        {仙子Type.伤害,new 仙子属性(){最终伤害 = 1}},
        {仙子Type.炼丹,new 仙子属性(){炼丹速度 = 1}},
        {仙子Type.炼器,new 仙子属性(){炼器速度 = 1}},
        {仙子Type.功法,new 仙子属性(){功法层数效果 = 1}},
        {仙子Type.符文,new 仙子属性(){符文效果 = 1}},
        {仙子Type.领主装备,new 仙子属性(){领主装备所有效果 = 1}},
        {仙子Type.灵兽,new 仙子属性(){灵兽增幅 = 1}},
        {仙子Type.合欢,new 仙子属性(){仙子效果 = 1}},
        {仙子Type.掉宝,new 仙子属性(){掉宝率 = 1}},
        {仙子Type.时间流速,new 仙子属性(){时间流速 = 1}},
    };

    public static List<int> 仙子解锁等级 = new List<int>() { 5, 12, 20, 30, 60, 100 };
    public static Dictionary<仙子Type, string> 仙子名Dic = new Dictionary<仙子Type, string>()
    {
        {仙子Type.伤害,"秦照雪"},
        {仙子Type.炼丹,"白蘅芜"},
        {仙子Type.炼器,"顾熔霜"},
        {仙子Type.功法,"姜卷舒"},
        {仙子Type.符文,"谢云篆"},
        {仙子Type.领主装备,"裴明光"},
        {仙子Type.灵兽,"温鹿鸣"},
        {仙子Type.合欢,"崔绛雪"},
        {仙子Type.掉宝,"沈拾遗"},
        {仙子Type.时间流速,"宋流光"},
    };

    public static Dictionary<仙子Type, string> 仙子身份Dic = new Dictionary<仙子Type, string>()
    {
        {仙子Type.伤害,"霜华剑仙，青冥剑阁守剑人"},
        {仙子Type.炼丹,"药蘅仙子，丹霞谷掌炉人"},
        {仙子Type.炼器,"炉火仙子，玄铁山庄铸器仙"},
        {仙子Type.功法,"藏卷仙子，藏经阁传功仙"},
        {仙子Type.符文,"朱笔符仙，符箓阁执笔人"},
        {仙子Type.领主装备,"明光甲仙，天策府护城者"},
        {仙子Type.灵兽,"御兽仙子，万兽谷牧灵人"},
        {仙子Type.合欢,"合欢花仙，合欢宗掌缘人"},
        {仙子Type.掉宝,"拾缘仙子，寻宝阁机缘使"},
        {仙子Type.时间流速,"时晷仙子，光阴殿执晷人"},
    };

    public static Dictionary<仙子Type, string> 仙子性格Dic = new Dictionary<仙子Type, string>()
    {
        {仙子Type.伤害,"冷冽寡言，剑心澄明，只以剑论高低；待你却总留半招"},
        {仙子Type.炼丹,"温吞絮叨，视药材如命，最恨糟蹋灵草之人"},
        {仙子Type.炼器,"豪爽直率，痴迷器物，谈起炉锤时眼中有光"},
        {仙子Type.功法,"温和迂阔，爱考校后辈，讲道能三日不歇"},
        {仙子Type.符文,"跳脱狡黠，画符爱故意画歪半笔，认真时一笔不苟"},
        {仙子Type.领主装备,"沉稳可靠，寡言重诺，一诺便是千军不破"},
        {仙子Type.灵兽,"天真烂漫，与兽亲厚，对人反倒慢热"},
        {仙子Type.合欢,"娇媚大胆，爱逗人脸红，笑意里藏着真心"},
        {仙子Type.掉宝,"财迷眼尖，最爱捡漏，捡来的愿分你一半"},
        {仙子Type.时间流速,"慵懒悠然，说话慢条斯理，最烦人催"},
    };

    public static Dictionary<仙子Type, string> 仙子简介Dic = new Dictionary<仙子Type, string>()
    {
        {仙子Type.伤害,"生于万剑冢，三岁抱剑而眠，剑意如霜雪覆野。她认定的道侣便是她的剑鞘——剑出鞘，只为你斩敌。"},
        {仙子Type.炼丹,"谷中炉火三百年不熄，丹成时满山生香。她常说，火候差一线，便是生死两隔。"},
        {仙子Type.炼器,"她曾以自身一缕神魂入炉，铸成一柄能承天雷的剑。世人只见器成，不知器中有她一魄。"},
        {仙子Type.功法,"云卷云舒，书页自翻。她信法无高低，唯人所悟，故从不藏私——只挑有缘人。"},
        {仙子Type.符文,"朱砂一点，天地为纸；心念一动，万里传音。她的符能镇山河，亦能引风雷。"},
        {仙子Type.领主装备,"明光铠照夜如昼，她立于城头，便是万里河山的最后一道防线。她的甲只护一人，也护那一人的天下。"},
        {仙子Type.灵兽,"幼时与鹿群同宿幽谷，一声鹿鸣便是她的名。她说灵兽不认主，只认心——所以她从不驯，只与它们做伴。"},
        {仙子Type.合欢,"宗中桃花终年不落，她一身绛衣立于花下，红梅映雪，故号绛雪。她说合欢非贪欢，是两人一心同修，各证长生。"},
        {仙子Type.掉宝,"世人求宝，她拾遗。她信天地之间无废物，只有未被看见的缘——你一弯腰，机缘就在脚下。"},
        {仙子Type.时间流速,"她掌中光阴可缓可急，一炷香能过一甲子。世人皆叹时不我待，唯她笑说，急什么，日子长着呢。"},
    };

    /// <summary>
    /// 仙子喜好灵植：每位仙子8种，按品质黄→荒各一；32种灵植全部登场，除荒品仅白玉莲外均为2~3次
    /// </summary>
    public static Dictionary<仙子Type, List<灵植Type>> 仙子喜好灵植dic = new Dictionary<仙子Type, List<灵植Type>>()
    {
        {仙子Type.伤害, new List<灵植Type>() { 灵植Type.曜日葵, 灵植Type.赤焰百合, 灵植Type.赤阳花, 灵植Type.赤霞花, 灵植Type.血菩提, 灵植Type.玄冰魄, 灵植Type.修罗花, 灵植Type.白玉莲 }},
        {仙子Type.炼丹, new List<灵植Type>() { 灵植Type.紫云英, 灵植Type.紫幽草, 灵植Type.三生花, 灵植Type.空谷幽兰, 灵植Type.太素花, 灵植Type.黄龙掌, 灵植Type.幻樱木, 灵植Type.白玉莲 }},
        {仙子Type.炼器, new List<灵植Type>() { 灵植Type.曜日葵, 灵植Type.碧海螺, 灵植Type.白玉玲, 灵植Type.惊雷子, 灵植Type.灵犀铃, 灵植Type.紫晶铃, 灵植Type.金乌葵, 灵植Type.白玉莲 }},
        {仙子Type.功法, new List<灵植Type>() { 灵植Type.幻音铃, 灵植Type.粉面佛莲, 灵植Type.向阳花, 灵植Type.幽兰铃, 灵植Type.血菩提, 灵植Type.玄冰魄, 灵植Type.修罗花, 灵植Type.白玉莲 }},
        {仙子Type.符文, new List<灵植Type>() { 灵植Type.紫云英, 灵植Type.九幽紫, 灵植Type.寒星兰, 灵植Type.惊雷子, 灵植Type.太素花, 灵植Type.紫晶铃, 灵植Type.幻樱木, 灵植Type.白玉莲 }},
        {仙子Type.领主装备, new List<灵植Type>() { 灵植Type.紫云英, 灵植Type.碧海螺, 灵植Type.白玉玲, 灵植Type.赤霞花, 灵植Type.醉仙球, 灵植Type.黄龙掌, 灵植Type.修罗花, 灵植Type.白玉莲 }},
        {仙子Type.灵兽, new List<灵植Type>() { 灵植Type.幻紫玫, 灵植Type.紫幽草, 灵植Type.三生花, 灵植Type.幽兰铃, 灵植Type.醉仙菌, 灵植Type.招财草, 灵植Type.金乌葵, 灵植Type.白玉莲 }},
        {仙子Type.合欢, new List<灵植Type>() { 灵植Type.幻紫玫, 灵植Type.粉面佛莲, 灵植Type.向阳花, 灵植Type.赤霞花, 灵植Type.灵犀铃, 灵植Type.粉霞仙, 灵植Type.幻樱木, 灵植Type.白玉莲 }},
        {仙子Type.掉宝, new List<灵植Type>() { 灵植Type.幻音铃, 灵植Type.赤焰百合, 灵植Type.寒星兰, 灵植Type.惊雷子, 灵植Type.醉仙球, 灵植Type.招财草, 灵植Type.金乌葵, 灵植Type.白玉莲 }},
        {仙子Type.时间流速, new List<灵植Type>() { 灵植Type.曜日葵, 灵植Type.九幽紫, 灵植Type.赤阳花, 灵植Type.空谷幽兰, 灵植Type.醉仙菌, 灵植Type.粉霞仙, 灵植Type.幻樱木, 灵植Type.白玉莲 }},
    };

    /// <summary>仙女殿每级解锁顺序：1级解锁第0个，2级解锁第1个，依此类推</summary>
    public static readonly List<仙子Type> 仙子解锁顺序 = new List<仙子Type>()
    {
        仙子Type.伤害,
        仙子Type.炼丹,
        仙子Type.炼器,
        仙子Type.功法,
        仙子Type.符文,
        仙子Type.领主装备,
        仙子Type.灵兽,
        仙子Type.合欢,
        仙子Type.掉宝,
        仙子Type.时间流速,
    };

    /// <summary>创建全部未解锁的仙女数据</summary>
    public static Dictionary<仙子Type, 仙女> 创建默认仙女Dic()
    {
        var dic = new Dictionary<仙子Type, 仙女>();
        foreach (仙子Type t in Enum.GetValues(typeof(仙子Type)))
        {
            if (t == 仙子Type.None) continue;
            dic[t] = new 仙女() { 仙子Type = t, 好感度等级 = 0, 好感度经验 = 0, 解锁 = false };
        }
        return dic;
    }

    /// <summary>根据仙女殿等级解锁对应仙女，解锁后默认好感度等级为1</summary>
    public static void 同步仙女解锁()
    {
        int 殿等级 = PlayerData.S.建筑等级Dic[建筑Type.仙女阁];
        int 已解锁 = Math.Min(殿等级, 仙子解锁顺序.Count);
        for (int i = 0; i < 仙子解锁顺序.Count; i++)
        {
            var type = 仙子解锁顺序[i];
            var 仙女 = PlayerData.S.仙女Dic[type];
            if (i < 已解锁)
            {
                if (!仙女.解锁)
                {
                    仙女.解锁 = true;
                    仙女.好感度等级 = Math.Max(仙女.好感度等级, 1);
                }
            }
            else
            {
                仙女.解锁 = false;
                仙女.好感度等级 = 0;
                仙女.好感度经验 = 0;
            }
        }
    }
}
