using System.Collections.Generic;
using Config;

public enum 城墙道具Type
{
    None,
    不动明王阵,
    不周山柱,
    不朽魂晶,
    不死木,
    不灭玄石,
    九曲黄河阵,
    初源露,
    厚土珠,
    不灭岩,
    周天星斗大阵,
    土灵珠,
    地髓晶,
    大道本源,
    天命罗盘,
    天机石,
    天罡石,
    山河阵盘,
    星辰沙,
    星辰铁,
    永恒之火,
    混沌磐石,
    灵兽骨粉,
    灵石尘,
    灵藤蔓,
    玄武石,
    玄黄之气,
    百年桃木,
    蛟龙骨,
    血琥珀,
    轮回印记,
    雷击木,
    鸿蒙灵根,
}

public enum 城墙道具属性Type
{
    None,
    
    涅槃,
    泥沼,
    冰冻,
     
    杀怪回血,
    杀怪增伤,
    无敌,
    伤害减免,
    每段时间护盾,
    
    低血量增伤,
    低血量伤害减免,
    高血量增伤,
    高血量伤害减免,
    每秒回血,
    免疫护盾,
    开局护盾,
}

public class 寻宝城墙道具item
{
    public 城墙道具Type 城墙道具Type;
    public int count;
}
public class 城墙Config
{
    public static int Get当前装备城墙道具等级(城墙道具Type Type)
    {
        foreach (var item in PlayerData.S.当前装备城墙道具Dic)
        {
            if (item.Value == Type)
            {
                return PlayerData.S.城墙道具等级Dic[Type];
            }
        }

        return 0;
    }

    public static int 涅槃次数 => Get涅槃次数();

    public static int Get涅槃次数()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.涅槃]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[2])
        {
            return 1;
        }else if (level < 城墙道具升级List[4])
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
    
    public static int 涅槃无敌时间 => Get涅槃无敌时间();

    public static int Get涅槃无敌时间()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.涅槃]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[1])
        {
            return 2;
        }else 
        {
            return 3;
        }
    }
    
    public static int 涅槃血量 => Get涅槃血量();

    public static int Get涅槃血量()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.涅槃]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 30;
        }if (level < 城墙道具升级List[3])
        {
            return 50;
        }else 
        {
            return 80;
        }
    }
    
    public static float 泥沼减速距离 => Get泥沼减速距离();

    public static float Get泥沼减速距离()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.泥沼]);
        if (level == 0)
        {
            return -5f;
        }else if (level < 城墙道具升级List[1])
        {
            return -1;
        }if (level < 城墙道具升级List[3])
        {
            return 0;
        }if (level < 城墙道具升级List[4])
        {
            return 1;
        }else 
        {
            return 3;
        }
    }
    
    public static float 泥沼减速效果 => Get泥沼减速效果();

    public static float Get泥沼减速效果()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.泥沼]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 30;
        }if (level < 城墙道具升级List[2])
        {
            return 40;
        }else 
        {
            return 50;
        }
    }
    
    public static float 冰冻间隔 => Get冰冻间隔();

    public static float Get冰冻间隔()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.冰冻]);
        if (level == 0)
        {
            return int.MaxValue;
        }else if (level < 城墙道具升级List[1])
        {
            return 10;
        }if (level < 城墙道具升级List[3])
        {
            return 8;
        }else 
        {
            return 6;
        }
    }
    public static float 冰冻时间 => Get冰冻时间();

    public static float Get冰冻时间()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.冰冻]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 1f;
        }if (level < 城墙道具升级List[2])
        {
            return 1.3f;
        }if (level < 城墙道具升级List[4])
        {
            return 1.6f;
        }else 
        {
            return 2f;
        }
    }
    
    
    public static float 杀怪回血数值 => Get杀怪回血数值();

    public static float Get杀怪回血数值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.杀怪回血]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 1f;
        }if (level < 城墙道具升级List[1])
        {
            return 1.1f;
        }if (level < 城墙道具升级List[2])
        {
            return 1.25f;
        }if (level < 城墙道具升级List[3])
        {
            return 1.45f;
        }if (level < 城墙道具升级List[4])
        {
            return 1.8f;
        }else 
        {
            return 2.2f;
        }
    }
    
    public static float 杀怪增伤数值 => Get杀怪增伤数值();

    public static float Get杀怪增伤数值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.杀怪增伤]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 0.5f;
        }if (level < 城墙道具升级List[1])
        {
            return 0.55f;
        }if (level < 城墙道具升级List[2])
        {
            return 0.65f;
        }if (level < 城墙道具升级List[3])
        {
            return 0.75f;
        }if (level < 城墙道具升级List[4])
        {
            return 0.9f;
        }else 
        {
            return 1.1f;
        }
    }
    
    public static float 无敌时间 => Get无敌时间();

    public static float Get无敌时间()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.无敌]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[1])
        {
            return 1f;
        }if (level < 城墙道具升级List[3])
        {
            return 1.2f;
        }else 
        {
            return 1.5f;
        }
    }
    
    public static float 无敌间隔时间 => Get无敌间隔时间();

    public static float Get无敌间隔时间()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.无敌]);
        if (level == 0)
        {
            return int.MaxValue;
        }else if (level < 城墙道具升级List[0])
        {
            return 10f;
        }if (level < 城墙道具升级List[2])
        {
            return 9f;
        }if (level < 城墙道具升级List[4])
        {
            return 8f;
        }else 
        {
            return 7f;
        }
    }
    
    public static float 伤害减免 => Get伤害减免();

    public static float Get伤害减免()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.伤害减免]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 20f;
        }if (level < 城墙道具升级List[1])
        {
            return 22f;
        }if (level < 城墙道具升级List[2])
        {
            return 25f;
        }if (level < 城墙道具升级List[3])
        {
            return 28f;
        }if (level < 城墙道具升级List[4])
        {
            return 33f;
        }else 
        {
            return 40f;
        }
    }
    
    public static float 护盾间隔时间 => Get护盾间隔时间();

    public static float Get护盾间隔时间()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.每段时间护盾]);
        if (level == 0)
        {
            return int.MaxValue;
        }else if (level < 城墙道具升级List[1])
        {
            return 10f;
        }if (level < 城墙道具升级List[3])
        {
            return 8f;
        }else 
        {
            return 6f;
        }
    }
    
    public static float 每段时间护盾值 => Get每段时间护盾值();

    public static float Get每段时间护盾值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.每段时间护盾]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 10f;
        }if (level < 城墙道具升级List[2])
        {
            return 11f;
        }if (level < 城墙道具升级List[4])
        {
            return 12.5f;
        }else 
        {
            return 15f;
        }
    }
    
    public static float 低血量增伤血量值 => Get低血量增伤血量值();

    public static float Get低血量增伤血量值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.低血量增伤]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 30f;
        }if (level < 城墙道具升级List[2])
        {
            return 35f;
        }if (level < 城墙道具升级List[4])
        {
            return 40f;
        }else 
        {
            return 50f;
        }
    }
    
    public static float 低血量增伤值 => Get低血量增伤值();

    public static float Get低血量增伤值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.低血量增伤]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[1])
        {
            return 30f;
        }if (level < 城墙道具升级List[3])
        {
            return 40;
        }else 
        {
            return 50f;
        }
    }
    
    public static float Get低血量伤害减免血量值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.低血量伤害减免]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 30f;
        }if (level < 城墙道具升级List[2])
        {
            return 35f;
        }if (level < 城墙道具升级List[4])
        {
            return 40f;
        }else 
        {
            return 50f;
        }
    }
    
    public static float 低血量伤害减免值 => Get低血量伤害减免值();

    public static float Get低血量伤害减免值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.低血量伤害减免]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[1])
        {
            return 25;
        }if (level < 城墙道具升级List[3])
        {
            return 30;
        }else 
        {
            return 40f;
        }
    }
    
    public static float 高血量伤害减免值 => Get高血量伤害减免值();

    public static float Get高血量伤害减免值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.高血量伤害减免]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[1])
        {
            return 25;
        }if (level < 城墙道具升级List[3])
        {
            return 30;
        }else 
        {
            return 40f;
        }
    }
    
    public static float Get高血量伤害减免血量值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.高血量伤害减免]);
        if (level == 0)
        {
            return 1000;
        }else if (level < 城墙道具升级List[0])
        {
            return 70f;
        }if (level < 城墙道具升级List[2])
        {
            return 65f;
        }if (level < 城墙道具升级List[4])
        {
            return 60f;
        }else 
        {
            return 50f;
        }
    }
    
    
    public static float 高血量增伤血量值 => Get高血量增伤血量值();

    public static float Get高血量增伤血量值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.高血量增伤]);
        if (level == 0)
        {
            return 1000;
        }else if (level < 城墙道具升级List[0])
        {
            return 70f;
        }if (level < 城墙道具升级List[2])
        {
            return 65f;
        }if (level < 城墙道具升级List[4])
        {
            return 60f;
        }else 
        {
            return 50f;
        }
    }
    
    public static float 高血量增伤值 => Get高血量增伤值();

    public static float Get高血量增伤值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.高血量增伤]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[1])
        {
            return 30f;
        }if (level < 城墙道具升级List[3])
        {
            return 40;
        }else 
        {
            return 50f;
        }
    }
    
    public static float 每秒回血值 => Get每秒回血值();

    public static float Get每秒回血值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.每秒回血]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 0.5f;
        }if (level < 城墙道具升级List[1])
        {
            return 0.6f;
        }if (level < 城墙道具升级List[2])
        {
            return 0.8f;
        }if (level < 城墙道具升级List[3])
        {
            return 1.1f;
        }if (level < 城墙道具升级List[4])
        {
            return 1.5f;
        }else 
        {
            return 2f;
        }
    }
    
    public static float 免疫护盾间隔时间 => Get免疫护盾间隔时间();

    public static float Get免疫护盾间隔时间()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.免疫护盾]);
        if (level == 0)
        {
            return int.MaxValue;
        }else if (level < 城墙道具升级List[0])
        {
            return 5f;
        }if (level < 城墙道具升级List[1])
        {
            return 4.5f;
        }if (level < 城墙道具升级List[2])
        {
            return 4f;
        }if (level < 城墙道具升级List[3])
        {
            return 3.5f;
        }if (level < 城墙道具升级List[4])
        {
            return 3f;
        }else 
        {
            return 2.5f;
        }
    }
    
    public static float 开局护盾值 => Get开局护盾值();

    public static float Get开局护盾值()
    {
        int level = Get当前装备城墙道具等级(城墙道具属性ToDic[城墙道具属性Type.开局护盾]);
        if (level == 0)
        {
            return 0;
        }else if (level < 城墙道具升级List[0])
        {
            return 30f;
        }if (level < 城墙道具升级List[1])
        {
            return 35f;
        }if (level < 城墙道具升级List[2])
        {
            return 40f;
        }if (level < 城墙道具升级List[3])
        {
            return 50f;
        }if (level < 城墙道具升级List[4])
        {
            return 60f;
        }else 
        {
            return 80f;
        }
    }
    public static Dictionary<城墙道具Type, string> 城墙道具介绍Dic = new Dictionary<城墙道具Type, string>()
{
    { 城墙道具Type.None, "无" },
    { 城墙道具Type.不动明王阵, "佛门无上护法大阵，金光普照十方世界，万邪不侵，固若金汤，稳如泰山，巍然不动。" },
    { 城墙道具Type.不周山柱, "上古擎天之柱的远古残骸，坚不可摧，力可撑起一方天地之重，镇压万古，无人可撼。" },
    { 城墙道具Type.不朽魂晶, "蕴含上古大能不朽意志的传奇结晶，纵使身死道消，英魂亦不灭，永世长存，万古流芳。" },
    { 城墙道具Type.不死木, "枯而不朽的太古神木，蕴藏不死真意，死而复生，生生不息，轮回不止，永恒不灭。" },
    { 城墙道具Type.不灭玄石, "历经万劫雷火反复淬炼而不灭，亘古永存，坚硬至极，万法不可破，诸邪不可侵。" },
    { 城墙道具Type.九曲黄河阵, "暗合天地杀机的九曲大阵，蜿蜒十八弯，困敌于无形之中，杀机四伏，入者必陷其中。" },
    { 城墙道具Type.初源露, "天地初开时混沌中凝聚的第一滴灵露，蕴藏万物本源生机，一滴可润苍生，复苏天地万物。" },
    { 城墙道具Type.厚土珠, "大地之精所化的无上灵珠，厚德载物，可承万钧冲击之力，稳若大地，不可动摇分毫。" },
    { 城墙道具Type.不灭岩, "历经九重天雷地火反复淬炼而不碎，世间至坚，万古不灭，无可摧之，永世长存不朽。" },
    { 城墙道具Type.周天星斗大阵, "引周天三百六十五颗星辰之力，化漫天星斗为不灭守护屏障，笼罩八荒，镇压十方邪祟。" },
    { 城墙道具Type.土灵珠, "土元之力高度凝聚的先天灵珠，与大地深层共鸣，防御固若金汤，不可破，稳如泰山磐石。" },
    { 城墙道具Type.地髓晶, "大地深处精华凝结的万年晶石，蕴藏浑厚磅礴地脉之力，取之不尽用之不竭，源源不绝。" },
    { 城墙道具Type.大道本源, "万物运行之始，天地法则之源，一缕气息可定天地乾坤，演化无穷造化，玄妙不可言说。" },
    { 城墙道具Type.天命罗盘, "掌天命定吉凶祸福，可于绝境之中逆转一线天机，夺天地之造化生机，逆天改命扭转乾坤。" },
    { 城墙道具Type.天机石, "蕴含命运大道之力的远古异石，可窥探未来一线渺茫天机，料敌于先机，未卜先知洞察一切。" },
    { 城墙道具Type.天罡石, "三十六天罡星力凝结的无上神石，护体神光照耀十方，万法不侵，邪魔退避，诸恶莫敢近之。" },
    { 城墙道具Type.山河阵盘, "以山河为阵基天地为阵盘，可困锁镇压一方虚空世界，令万物不得出，鬼神亦难逃此阵。" },
    { 城墙道具Type.星辰沙, "九天星河碎裂后的远古沙砾，聚散无常，却可筑不灭之壁，御万般攻击，守护一方安宁净土。" },
    { 城墙道具Type.星辰铁, "星辰核心历经万载淬炼的玄铁，坚逾金刚，凡间神兵不可伤其分毫，至坚至硬无物可断。" },
    { 城墙道具Type.永恒之火, "混沌中诞生的天地不灭神火，生生不息，永恒不灭，可焚尽一切邪祟污秽，净化世间万恶。" },
    { 城墙道具Type.混沌磐石, "天地未开时混沌中诞生的远古之石，万法不破，亘古长存，永世不朽，乃万物之根基所在。" },
    { 城墙道具Type.灵兽骨粉, "上古异兽灵骨精心研磨而成，蕴含兽魂怨力，可守护一方安宁，震慑万妖，诸邪莫敢侵犯。" },
    { 城墙道具Type.灵石尘, "极品灵石风化后的细微碎末，虽微末却蕴含精纯灵气，聚沙成塔积少成多，可滋养万物生灵。" },
    { 城墙道具Type.灵藤蔓, "上古灵藤的坚韧藤蔓，柔韧不屈，可缠绕束缚万千敌，令其寸步难行，插翅亦难逃脱束缚。" },
    { 城墙道具Type.玄武石, "玄武神龟的远古背甲所化，天下至坚之物，可御万般攻击，稳如磐石，万古不动不可摧。" },
    { 城墙道具Type.玄黄之气, "开天辟地时的玄黄母气，可演化万物，乃天地之根基，万物之始源，玄妙无穷造化无尽。" },
    { 城墙道具Type.百年桃木, "历经百年风雨的桃木，可驱邪避煞，镇守一方平安，邪祟莫敢近之，乃辟邪安宅之良材。" },
    { 城墙道具Type.蛟龙骨, "千年蛟龙褪下的远古遗骨，蕴含龙威，百兽见之莫不震慑，俯首称臣，尽显万兽之王威严。" },
    { 城墙道具Type.血琥珀, "上古神兽精血滴落石化而成，历经万载方成此至宝，蕴藏神兽血脉之力，珍贵稀有举世罕见。" },
    { 城墙道具Type.轮回印记, "烙印了轮回之力的神秘印记，生死转换，涅槃可获重生，轮回不止不息，生灭循环永不断绝。" },
    { 城墙道具Type.雷击木, "遭受天雷轰击而不毁灭的神木，蕴含天地雷霆威严，可震慑世间一切邪祟，雷光所至万恶伏诛。" },
    { 城墙道具Type.鸿蒙灵根, "鸿蒙初判时诞生的先天灵根，蕴藏无穷生机与造化，乃万灵之根源，天地之始万物之母。" },
};
    public static List<int>城墙道具升级List = new List<int>(){3,6,10,15,25};
    public static Dictionary<城墙道具属性Type, List<string>> 城墙道具属性升级Info = new Dictionary<城墙道具属性Type, List<string>>()
    {
        { 
            城墙道具属性Type.涅槃, 
            new List<string>()
            {
                $"涅槃时恢复{HeroConfig.Get技能伤害string(50, 1)}的最大生命值",
                $"涅槃时无敌时间增加{HeroConfig.Get技能伤害string(1, 2)}",
                "每关涅槃次数+1",
                $"涅槃时恢复{HeroConfig.Get技能伤害string(80, 1)}的最大生命值",
                "每关涅槃次数+1"
            } 
        },
        { 
            城墙道具属性Type.泥沼, 
            new List<string>()
            {
                $"减速效果提升至{HeroConfig.Get技能伤害string(40, 1)}",
                $"减速范围增加{HeroConfig.Get技能伤害string(30, 1)}",
                $"减速效果提升至{HeroConfig.Get技能伤害string(50, 1)}",
                $"减速范围增加{HeroConfig.Get技能伤害string(60, 1)}",
                $"减速范围增加{HeroConfig.Get技能伤害string(100, 1)}"
            } 
        },
        { 
            城墙道具属性Type.冰冻, 
            new List<string>()
            {
                $"冻结时间增加{HeroConfig.Get技能伤害string(0.3f, 2)}",
                $"间隔时间缩短{HeroConfig.Get技能伤害string(2, 2)}",
                $"冻结时间增加{HeroConfig.Get技能伤害string(0.3f, 2)}",
                $"间隔时间缩短{HeroConfig.Get技能伤害string(2, 2)}",
                $"冻结时间增加{HeroConfig.Get技能伤害string(0.4f, 2)}",
            } 
        },
        
        { 
            城墙道具属性Type.杀怪回血 , 
            new List<string>()
            {
                $"击杀敌人恢复效果增加{HeroConfig.Get技能伤害string(10, 1)}",
                $"击杀敌人恢复效果增加{HeroConfig.Get技能伤害string(25, 1)}",
                $"击杀敌人恢复效果增加{HeroConfig.Get技能伤害string(45, 1)}",
                $"击杀敌人恢复效果增加{HeroConfig.Get技能伤害string(80, 1)}",
                $"击杀敌人恢复效果增加{HeroConfig.Get技能伤害string(120, 1)}",
            } 
        },
        { 
            城墙道具属性Type.杀怪增伤 , 
            new List<string>()
            {
                $"击杀敌人增伤效果增加{HeroConfig.Get技能伤害string(10, 1)}",
                $"击杀敌人增伤效果增加{HeroConfig.Get技能伤害string(25, 1)}",
                $"击杀敌人增伤效果增加{HeroConfig.Get技能伤害string(45, 1)}",
                $"击杀敌人增伤效果增加{HeroConfig.Get技能伤害string(80, 1)}",
                $"击杀敌人增伤效果增加{HeroConfig.Get技能伤害string(120, 1)}",
            } 
        },
        
        { 
            城墙道具属性Type.无敌 , 
            new List<string>()
            {
                $"间隔时间缩短{HeroConfig.Get技能伤害string(1, 2)}",
                $"无敌时间增加{HeroConfig.Get技能伤害string(0.2f, 2)}",
                $"间隔时间缩短{HeroConfig.Get技能伤害string(1, 2)}",
                $"无敌时间增加{HeroConfig.Get技能伤害string(0.3f, 2)}",
                $"间隔时间缩短{HeroConfig.Get技能伤害string(1, 2)}",
            } 
        },
        { 
            城墙道具属性Type.伤害减免 , 
            new List<string>()
            {
                $"城墙获得{HeroConfig.Get技能伤害string(22, 1)}的伤害减免",
                $"城墙获得{HeroConfig.Get技能伤害string(25, 1)}的伤害减免",
                $"城墙获得{HeroConfig.Get技能伤害string(28, 1)}的伤害减免",
                $"城墙获得{HeroConfig.Get技能伤害string(33, 1)}的伤害减免",
                $"城墙获得{HeroConfig.Get技能伤害string(40, 1)}的伤害减免",
            } 
        },
        { 
            城墙道具属性Type.每段时间护盾 , 
            new List<string>()
            {
                $"护盾效果增加{HeroConfig.Get技能伤害string(10, 1)}",
                $"间隔时间缩短{HeroConfig.Get技能伤害string(2, 2)}",
                $"护盾效果增加{HeroConfig.Get技能伤害string(25, 1)}",
                $"间隔时间缩短{HeroConfig.Get技能伤害string(2, 2)}",
                $"护盾效果增加{HeroConfig.Get技能伤害string(50, 1)}",
            } 
        },
        
        { 
            城墙道具属性Type.低血量增伤 , 
            new List<string>()
            {
                $"城墙血量低于{HeroConfig.Get技能伤害string(35, 1)}时,就可触发效果",
                $"伤害增加{HeroConfig.Get技能伤害string(40, 1)}",
                $"城墙血量低于{HeroConfig.Get技能伤害string(40, 1)}时,就可触发效果",
                $"伤害增加{HeroConfig.Get技能伤害string(50, 1)}",
                $"城墙血量低于{HeroConfig.Get技能伤害string(50, 1)}时,就可触发效果",
            } 
        },
        
        { 
            城墙道具属性Type.低血量伤害减免 , 
            new List<string>()
            {
                $"城墙血量低于{HeroConfig.Get技能伤害string(35, 1)}时,就可触发效果",
                $"伤害减免增加{HeroConfig.Get技能伤害string(30, 1)}",
                $"城墙血量低于{HeroConfig.Get技能伤害string(40, 1)}时,就可触发效果",
                $"伤害减免增加{HeroConfig.Get技能伤害string(40, 1)}",
                $"城墙血量低于{HeroConfig.Get技能伤害string(50, 1)}时,就可触发效果",
            } 
        },
        
        
        { 
            城墙道具属性Type.高血量增伤 , 
            new List<string>()
            {
                $"城墙血量高于{HeroConfig.Get技能伤害string(65, 1)}时,就可触发效果",
                $"伤害增加{HeroConfig.Get技能伤害string(40, 1)}",
                $"城墙血量高于{HeroConfig.Get技能伤害string(60, 1)}时,就可触发效果",
                $"伤害增加{HeroConfig.Get技能伤害string(50, 1)}",
                $"城墙血量高于{HeroConfig.Get技能伤害string(50, 1)}时,就可触发效果",
            } 
        },
        
        { 
            城墙道具属性Type.高血量伤害减免 , 
            new List<string>()
            {
                $"城墙血量高于{HeroConfig.Get技能伤害string(65, 1)}时,就可触发效果",
                $"伤害减免增加{HeroConfig.Get技能伤害string(30, 1)}",
                $"城墙血量高于{HeroConfig.Get技能伤害string(60, 1)}时,就可触发效果",
                $"伤害减免增加{HeroConfig.Get技能伤害string(40, 1)}",
                $"城墙血量高于{HeroConfig.Get技能伤害string(50, 1)}时,就可触发效果",
            } 
        },
        
        { 
            城墙道具属性Type.每秒回血 , 
            new List<string>()
            {
                $"每秒回血增加{HeroConfig.Get技能伤害string(0.1f, 1)}的最大生命值",
                $"每秒回血增加{HeroConfig.Get技能伤害string(0.2f, 1)}的最大生命值",
                $"每秒回血增加{HeroConfig.Get技能伤害string(0.3f, 1)}的最大生命值",
                $"每秒回血增加{HeroConfig.Get技能伤害string(0.4f, 1)}的最大生命值",
                $"每秒回血增加{HeroConfig.Get技能伤害string(0.5f, 1)}的最大生命值",
            } 
        },
        { 
            城墙道具属性Type.免疫护盾 , 
            new List<string>()
            {
                $"间隔时间减少{HeroConfig.Get技能伤害string(0.5f, 2)}",
                $"间隔时间减少{HeroConfig.Get技能伤害string(0.5f, 2)}",
                $"间隔时间减少{HeroConfig.Get技能伤害string(0.5f, 2)}",
                $"间隔时间减少{HeroConfig.Get技能伤害string(0.5f, 2)}",
                $"间隔时间减少{HeroConfig.Get技能伤害string(0.5f, 2)}",
            } 
        },
        { 
            城墙道具属性Type.开局护盾 , 
            new List<string>()
            {
                $"开局获得{HeroConfig.Get技能伤害string(35, 1)}最大生命值的护盾",
                $"开局获得{HeroConfig.Get技能伤害string(40, 1)}最大生命值的护盾",
                $"开局获得{HeroConfig.Get技能伤害string(50, 1)}最大生命值的护盾",
                $"开局获得{HeroConfig.Get技能伤害string(60, 1)}最大生命值的护盾",
                $"开局获得{HeroConfig.Get技能伤害string(80, 1)}最大生命值的护盾",
            } 
        },
    };

    public static Dictionary<城墙道具属性Type, string> 城墙道具属性Info = new Dictionary<城墙道具属性Type, string>()
    {
        { 城墙道具属性Type.涅槃 ,$"城墙血量低于0时,可涅槃一次,恢复{HeroConfig.Get技能伤害string(30,1)}的最大生命值,并无敌{HeroConfig.Get技能伤害string(2,2)}"},
        { 城墙道具属性Type.泥沼 ,$"敌人靠近城墙时,降低敌人{HeroConfig.Get技能伤害string(30,1)}的移动速度"},
        { 城墙道具属性Type.冰冻 ,$"每隔{HeroConfig.Get技能伤害string(10,2)}冻结所有敌人{HeroConfig.Get技能伤害string(0.5f,1)}"},

        { 城墙道具属性Type.杀怪回血 ,$"每击杀一个敌人,城墙恢复{HeroConfig.Get技能伤害string(1,1)}的最大生命值"},
        { 城墙道具属性Type.杀怪增伤 ,$"每击杀一个敌人,增加{HeroConfig.Get技能伤害string(0.5f,1)}的英雄伤害"},
        { 城墙道具属性Type.无敌 ,$"每间隔{HeroConfig.Get技能伤害string(10,2)},城墙无敌{HeroConfig.Get技能伤害string(1,2)}"},
        { 城墙道具属性Type.伤害减免 ,$"城墙获得{HeroConfig.Get技能伤害string(20,1)}的伤害减免"},
        { 城墙道具属性Type.每段时间护盾 ,$"每间隔{HeroConfig.Get技能伤害string(10,2)},城墙获得{HeroConfig.Get技能伤害string(10,1)}最大生命值的护盾"},

        { 城墙道具属性Type.低血量增伤 ,$"城墙血量低于{HeroConfig.Get技能伤害string(30,1)}时,增加{HeroConfig.Get技能伤害string(30,1)}的英雄伤害"},
        { 城墙道具属性Type.低血量伤害减免 ,$"城墙血量低于{HeroConfig.Get技能伤害string(30,1)}时,城墙获得{HeroConfig.Get技能伤害string(25,1)}的伤害减免"},
        { 城墙道具属性Type.高血量增伤 ,$"城墙血量高于{HeroConfig.Get技能伤害string(70,1)}时,增加{HeroConfig.Get技能伤害string(30,1)}的英雄伤害"},
        { 城墙道具属性Type.高血量伤害减免 ,$"城墙血量高于{HeroConfig.Get技能伤害string(70,1)}时,城墙获得{HeroConfig.Get技能伤害string(25,1)}的伤害减免"},
        { 城墙道具属性Type.每秒回血 ,$"城墙每秒恢复{HeroConfig.Get技能伤害string(0.5f,1)}的最大生命值"},
        { 城墙道具属性Type.免疫护盾 ,$"每间隔{HeroConfig.Get技能伤害string(5,2)}的获得一个免疫伤害的护盾,可叠加"},
        { 城墙道具属性Type.开局护盾 ,$"每关开局城墙获得{HeroConfig.Get技能伤害string(30,1)}的最大生命值护盾"},
    };
    public static Dictionary<城墙道具Type, 城墙道具属性Type> 城墙道具属性Dic = new Dictionary<城墙道具Type, 城墙道具属性Type>()
    {
        { 城墙道具Type.混沌磐石, 城墙道具属性Type.涅槃 },
        { 城墙道具Type.大道本源, 城墙道具属性Type.泥沼 },
        { 城墙道具Type.鸿蒙灵根, 城墙道具属性Type.冰冻 },

        { 城墙道具Type.轮回印记, 城墙道具属性Type.杀怪回血 },
        { 城墙道具Type.永恒之火, 城墙道具属性Type.杀怪增伤 },
        { 城墙道具Type.玄黄之气, 城墙道具属性Type.无敌 },
        { 城墙道具Type.不周山柱, 城墙道具属性Type.伤害减免 },
        { 城墙道具Type.不朽魂晶, 城墙道具属性Type.每段时间护盾 },

        { 城墙道具Type.周天星斗大阵, 城墙道具属性Type.低血量增伤 },
        { 城墙道具Type.天命罗盘, 城墙道具属性Type.低血量伤害减免 },
        { 城墙道具Type.九曲黄河阵, 城墙道具属性Type.高血量增伤 },
        { 城墙道具Type.不动明王阵, 城墙道具属性Type.高血量伤害减免 },
        { 城墙道具Type.天罡石, 城墙道具属性Type.每秒回血 },
        { 城墙道具Type.土灵珠, 城墙道具属性Type.免疫护盾 },
        { 城墙道具Type.不灭玄石, 城墙道具属性Type.开局护盾 },
    };
    
    public static Dictionary<城墙道具属性Type, 城墙道具Type> 城墙道具属性ToDic = new Dictionary<城墙道具属性Type, 城墙道具Type>()
    {
        { 城墙道具属性Type.涅槃, 城墙道具Type.混沌磐石 },
        { 城墙道具属性Type.泥沼, 城墙道具Type.大道本源 },
        { 城墙道具属性Type.冰冻, 城墙道具Type.鸿蒙灵根 },

        { 城墙道具属性Type.杀怪回血, 城墙道具Type.轮回印记 },
        { 城墙道具属性Type.杀怪增伤, 城墙道具Type.永恒之火 },
        { 城墙道具属性Type.无敌, 城墙道具Type.玄黄之气 },
        { 城墙道具属性Type.伤害减免, 城墙道具Type.不周山柱 },
        { 城墙道具属性Type.每段时间护盾, 城墙道具Type.不朽魂晶 },

        { 城墙道具属性Type.低血量增伤, 城墙道具Type.周天星斗大阵 },
        { 城墙道具属性Type.低血量伤害减免, 城墙道具Type.天命罗盘 },
        { 城墙道具属性Type.高血量增伤, 城墙道具Type.九曲黄河阵 },
        { 城墙道具属性Type.高血量伤害减免, 城墙道具Type.不动明王阵 },
        { 城墙道具属性Type.每秒回血, 城墙道具Type.天罡石 },
        { 城墙道具属性Type.免疫护盾, 城墙道具Type.土灵珠 },
        { 城墙道具属性Type.开局护盾, 城墙道具Type.不灭玄石 },
    };
    public static Dictionary<QualityType, int> 城墙解锁等级Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品 ,10},
        { QualityType.玄品 ,20},
        { QualityType.地品 ,30},
        { QualityType.天品 ,40},
        { QualityType.宇品 ,50},
        { QualityType.宙品 ,60},
        { QualityType.洪品 ,70},
        { QualityType.荒品 ,80},

    };

    public static QualityType Get城墙Quality()
    {
        if (PlayerData.S.城墙等级 <= 10)
        {
            return QualityType.黄品;
        }
        else if (PlayerData.S.城墙等级 <= 20)
        {
            return QualityType.玄品;
        }else if (PlayerData.S.城墙等级 <= 30)
        {
            return QualityType.地品;
        }else if (PlayerData.S.城墙等级 <= 40)
        {
            return QualityType.天品;
        }else if (PlayerData.S.城墙等级 <= 50)
        {
            return QualityType.宇品;
        }else if (PlayerData.S.城墙等级 <= 60)
        {
            return QualityType.宙品;
        }else if (PlayerData.S.城墙等级 <= 70)
        {
            return QualityType.洪品;
        }else
        {
            return QualityType.荒品;
        }
    }

    public static string Get城墙名()
    {
        if (PlayerData.S.城墙等级 <= 10)
        {
            return 城墙名Dic[QualityType.黄品];
        }
        else if (PlayerData.S.城墙等级 <= 20)
        {
            return 城墙名Dic[QualityType.玄品];
        }else if (PlayerData.S.城墙等级 <= 30)
        {
            return 城墙名Dic[QualityType.地品];
        }else if (PlayerData.S.城墙等级 <= 40)
        {
            return 城墙名Dic[QualityType.天品];
        }else if (PlayerData.S.城墙等级 <= 50)
        {
            return 城墙名Dic[QualityType.宇品];
        }else if (PlayerData.S.城墙等级 <= 60)
        {
            return 城墙名Dic[QualityType.宙品];
        }else if (PlayerData.S.城墙等级 <= 70)
        {
            return 城墙名Dic[QualityType.洪品];
        }else
        {
            return 城墙名Dic[QualityType.荒品];
        }
    }
    
    public static Dictionary<QualityType, string> 城墙名Dic = new Dictionary<QualityType, string>()
    {
        { QualityType.黄品 ,"白石垒"},
        { QualityType.玄品 ,"木灵墙"},
        { QualityType.地品 ,"青冥壁"},
        { QualityType.天品 ,"紫府玄关"},
        { QualityType.宇品 ,"古烬垣"},
        { QualityType.宙品 ,"血月赤垣"},
        { QualityType.洪品 ,"无极寂垒"},
        { QualityType.荒品 ,"太初遗垣"},

    };
    public static int Get城墙升级灵气()
    {
        if (PlayerData.S.城墙等级 < 10)
        {
            return 200;
        }else if (PlayerData.S.城墙等级 < 20)
        {
            return 500;
        }else if (PlayerData.S.城墙等级 < 30)
        {
            return 2000;
        }else if (PlayerData.S.城墙等级 < 40)
        {
            return 5000;
        }else if (PlayerData.S.城墙等级 < 50)
        {
            return 20000;
        }else if (PlayerData.S.城墙等级 < 60)
        {
            return 50000;
        }else if (PlayerData.S.城墙等级 < 70)
        {
            return 200000;
        }else
        {
            return 500000;
        }
    }

    public static int Get城墙基础血量()
    {
        if (PlayerData.S.城墙等级 <= 80)
        {
            return 城墙基础血量Dic[PlayerData.S.城墙等级]*2;
        }
        else
        {
            return 城墙基础血量Dic[80]*2+100000*(PlayerData.S.城墙等级 - 80);
        }
    }
    
    public static int Get城墙基础防御()
    {
        if (PlayerData.S.城墙等级 <= 80)
        {
            return 城墙基础防御Dic[PlayerData.S.城墙等级]*2;
        }
        else 
        {
            return 城墙基础血量Dic[80]*2+1000*(PlayerData.S.城墙等级 - 80);
        }
    }
    public static Dictionary<int, int> 城墙基础血量Dic = new Dictionary<int, int>()
    {
        {1,100},
        {2,120},
        {3,140},
        {4,160},
        {5,180},
        {6,200},
        {7,220},
        {8,240},
        {9,260},
        {10,300},
        
        {11,350},
        {12,400},
        {13,450},
        {14,500},
        {15,550},
        {16,600},
        {17,650},
        {18,700},
        {19,750},
        {20,800},
        
        {21,1000},
        {22,1200},
        {23,1400},
        {24,1600},
        {25,1800},
        {26,2000},
        {27,2200},
        {28,2400},
        {29,2600},
        {30,3000},
        
        {31,3500},
        {32,4000},
        {33,4500},
        {34,5000},
        {35,5500},
        {36,6000},
        {37,6500},
        {38,7000},
        {39,7500},
        {40,8000},
        
        {41,10000},
        {42,12000},
        {43,14000},
        {44,16000},
        {45,18000},
        {46,20000},
        {47,22000},
        {48,24000},
        {49,26000},
        {50,30000},
        
        {51,35000},
        {52,40000},
        {53,45000},
        {54,50000},
        {55,55000},
        {56,60000},
        {57,65000},
        {58,70000},
        {59,75000},
        {60,80000},
        
        {61,100000},
        {62,120000},
        {63,140000},
        {64,160000},
        {65,180000},
        {66,200000},
        {67,220000},
        {68,240000},
        {69,260000},
        {70,300000},
        
        {71,350000},
        {72,400000},
        {73,450000},
        {74,500000},
        {75,550000},
        {76,600000},
        {77,650000},
        {78,700000},
        {79,750000},
        {80,800000},
    };
    
    public static Dictionary<int, int> 城墙基础防御Dic = new Dictionary<int, int>()
    {
        {1,1},
        {2,1},
        {3,1},
        {4,1},
        {5,1},
        {6,2},
        {7,2},
        {8,2},
        {9,2},
        {10,3},
        
        {11,3},
        {12,4},
        {13,4},
        {14,5},
        {15,5},
        {16,6},
        {17,6},
        {18,7},
        {19,7},
        {20,8},
        
        {21,10},
        {22,12},
        {23,14},
        {24,16},
        {25,18},
        {26,20},
        {27,22},
        {28,24},
        {29,26},
        {30,30},
        
        {31,35},
        {32,40},
        {33,45},
        {34,50},
        {35,55},
        {36,60},
        {37,65},
        {38,70},
        {39,75},
        {40,80},
        
        {41,100},
        {42,120},
        {43,140},
        {44,160},
        {45,180},
        {46,200},
        {47,220},
        {48,240},
        {49,260},
        {50,300},
        
        {51,350},
        {52,400},
        {53,450},
        {54,500},
        {55,550},
        {56,600},
        {57,650},
        {58,700},
        {59,750},
        {60,800},
        
        {61,1000},
        {62,1200},
        {63,1400},
        {64,1600},
        {65,1800},
        {66,2000},
        {67,2200},
        {68,2400},
        {69,2600},
        {70,3000},
        
        {71,3500},
        {72,4000},
        {73,4500},
        {74,5000},
        {75,5500},
        {76,6000},
        {77,6500},
        {78,7000},
        {79,7500},
        {80,8000},
    };

    public static Dictionary<城墙道具Type, string> 城墙道具名Dic = new Dictionary<城墙道具Type, string>()
    {
        { 城墙道具Type.不动明王阵, "不动明王阵" },
        { 城墙道具Type.不周山柱, "不周山柱" },
        { 城墙道具Type.不朽魂晶, "不朽魂晶" },
        { 城墙道具Type.不死木, "不死木" },
        { 城墙道具Type.不灭玄石, "不灭玄石" },
        { 城墙道具Type.九曲黄河阵, "九曲黄河阵" },
        { 城墙道具Type.初源露, "初源露" },
        { 城墙道具Type.厚土珠, "厚土珠" },
        { 城墙道具Type.不灭岩, "反伤岩" },
        { 城墙道具Type.周天星斗大阵, "周天星斗大阵" },
        { 城墙道具Type.土灵珠, "土灵珠" },
        { 城墙道具Type.地髓晶, "地髓晶" },
        { 城墙道具Type.大道本源, "大道本源" },
        { 城墙道具Type.天命罗盘, "天命罗盘" },
        { 城墙道具Type.天机石, "天机石" },
        { 城墙道具Type.天罡石, "天罡石" },
        { 城墙道具Type.山河阵盘, "山河阵盘" },
        { 城墙道具Type.星辰沙, "星辰沙" },
        { 城墙道具Type.星辰铁, "星辰铁" },
        { 城墙道具Type.永恒之火, "永恒之火" },
        { 城墙道具Type.混沌磐石, "混沌磐石" },
        { 城墙道具Type.灵兽骨粉, "灵兽骨粉" },
        { 城墙道具Type.灵石尘, "灵石尘" },
        { 城墙道具Type.灵藤蔓, "灵藤蔓" },
        { 城墙道具Type.玄武石, "玄武石" },
        { 城墙道具Type.玄黄之气, "玄黄之气" },
        { 城墙道具Type.百年桃木, "百年桃木" },
        { 城墙道具Type.蛟龙骨, "蛟龙骨" },
        { 城墙道具Type.血琥珀, "血琥珀" },
        { 城墙道具Type.轮回印记, "轮回印记" },
        { 城墙道具Type.雷击木, "雷击木" },
        { 城墙道具Type.鸿蒙灵根, "鸿蒙灵根" },
    };

    public static Dictionary<道宝Quality, List<城墙道具Type>> 城墙道具列表Dic = new Dictionary<道宝Quality, List<城墙道具Type>>()
    {
        {
            道宝Quality.混沌至宝, new List<城墙道具Type>
            {
                城墙道具Type.混沌磐石,
                城墙道具Type.大道本源,
                城墙道具Type.鸿蒙灵根,
            }
        },
        {
            道宝Quality.先天至宝, new List<城墙道具Type>
            {
                城墙道具Type.轮回印记,
                城墙道具Type.永恒之火,
                城墙道具Type.玄黄之气,
                城墙道具Type.不周山柱,
                城墙道具Type.不朽魂晶,
            }
        },
        {
            道宝Quality.功德至宝, new List<城墙道具Type>
            {
                城墙道具Type.周天星斗大阵,
                城墙道具Type.天命罗盘,
                城墙道具Type.九曲黄河阵,
                城墙道具Type.不动明王阵,
                城墙道具Type.天罡石,
                城墙道具Type.土灵珠,
                城墙道具Type.不灭玄石,
            }
        },
        {
            道宝Quality.先天灵宝, new List<城墙道具Type>
            {
                城墙道具Type.初源露,
                城墙道具Type.不死木,
                城墙道具Type.厚土珠,
                城墙道具Type.天机石,
                城墙道具Type.山河阵盘,
                城墙道具Type.星辰沙,
                城墙道具Type.星辰铁,
            }
        },
        {
            道宝Quality.后天法宝, new List<城墙道具Type>
            {
                城墙道具Type.雷击木,
                城墙道具Type.血琥珀,
                城墙道具Type.蛟龙骨,
                城墙道具Type.百年桃木,
                城墙道具Type.玄武石,
                城墙道具Type.灵藤蔓,
                城墙道具Type.灵石尘,
                城墙道具Type.灵兽骨粉,
                城墙道具Type.地髓晶,
                城墙道具Type.不灭岩,
            }
        },
    };
    public static Dictionary<城墙道具Type, QualityType> 城墙道具QualityDic = new Dictionary<城墙道具Type, QualityType>()
    {
        { 城墙道具Type.None ,QualityType.黄品},

        { 城墙道具Type.混沌磐石 ,QualityType.荒品},
        { 城墙道具Type.大道本源 ,QualityType.荒品},
        { 城墙道具Type.鸿蒙灵根 ,QualityType.荒品},
        
        { 城墙道具Type.轮回印记 ,QualityType.洪品},
        { 城墙道具Type.永恒之火 ,QualityType.洪品},
        { 城墙道具Type.玄黄之气 ,QualityType.洪品},
        { 城墙道具Type.不周山柱 ,QualityType.洪品},
        { 城墙道具Type.不朽魂晶 ,QualityType.洪品},

        { 城墙道具Type.周天星斗大阵 ,QualityType.宙品},
        { 城墙道具Type.天命罗盘 ,QualityType.宙品},
        { 城墙道具Type.九曲黄河阵 ,QualityType.宙品},
        { 城墙道具Type.不动明王阵,QualityType.宙品},
        { 城墙道具Type.天罡石 ,QualityType.宙品},
        { 城墙道具Type.土灵珠 ,QualityType.宙品},
        { 城墙道具Type.不灭玄石 ,QualityType.宙品},

        { 城墙道具Type.初源露 ,QualityType.宇品},
        { 城墙道具Type.不死木 ,QualityType.宇品},
        { 城墙道具Type.厚土珠 ,QualityType.宇品},
        { 城墙道具Type.天机石 ,QualityType.宇品},
        { 城墙道具Type.山河阵盘 ,QualityType.宇品},
        { 城墙道具Type.星辰沙 ,QualityType.宇品},
        { 城墙道具Type.星辰铁 ,QualityType.宇品},

        { 城墙道具Type.雷击木 ,QualityType.天品},
        { 城墙道具Type.血琥珀 ,QualityType.天品},
        { 城墙道具Type.蛟龙骨 ,QualityType.天品},
        { 城墙道具Type.百年桃木 ,QualityType.天品},
        { 城墙道具Type.玄武石 ,QualityType.天品},
        { 城墙道具Type.灵藤蔓 ,QualityType.天品},
        { 城墙道具Type.灵石尘 ,QualityType.天品},
        { 城墙道具Type.灵兽骨粉 ,QualityType.天品},
        { 城墙道具Type.地髓晶 ,QualityType.天品},
        { 城墙道具Type.不灭岩 ,QualityType.天品},
    };

    public static Dictionary<QualityType, float> 城墙道具升级奖励Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.荒品,10f},
        { QualityType.洪品,3},
        { QualityType.宙品,1f},
        { QualityType.宇品,0.3f},
        { QualityType.天品,0.1f},
    };

    public static float Get城墙最大生命值()
    {
        float value = Get城墙基础血量()*属性config.总属性.城墙血量增幅;
        float count = 0;
        foreach (var item in PlayerData.S.城墙道具等级Dic)
        {
            count += 城墙道具升级奖励Dic[城墙道具QualityDic[item.Key]]/100f * item.Value;
        }

        foreach (var item in PlayerData.S.当前装备城墙道具Dic)
        {
            if (城墙道具QualityDic[item.Value] == QualityType.天品)
            {
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[0])
                {
                    count += 紫橙色道具升级奖励List[0]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[1])
                {
                    count += 紫橙色道具升级奖励List[1]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[2])
                {
                    count += 紫橙色道具升级奖励List[2]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[3])
                {
                    count += 紫橙色道具升级奖励List[3]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[4])
                {
                    count += 紫橙色道具升级奖励List[4]/100f;
                }
            }
        }

        return (int)(value * (1 + count));
    }
    
    public static int Get城墙防御()
    {
        int value = Get城墙基础防御();
        float count = 0;

        foreach (var item in PlayerData.S.当前装备城墙道具Dic)
        {
            if (城墙道具QualityDic[item.Value] == QualityType.宇品)
            {
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[0])
                {
                    count += 紫橙色道具升级奖励List[0]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[1])
                {
                    count += 紫橙色道具升级奖励List[1]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[2])
                {
                    count += 紫橙色道具升级奖励List[2]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[3])
                {
                    count += 紫橙色道具升级奖励List[3]/100f;
                }
                if (PlayerData.S.城墙道具等级Dic[item.Value] >= 城墙道具升级List[4])
                {
                    count += 紫橙色道具升级奖励List[4]/100f;
                }
            }
        }

        return (int)(value * (1 + count));
    }

    public static List<float> 紫橙色道具升级奖励List = new List<float>()
    {
        0.5f,
        1f,
        2f,
        3f,
        5f,
    };

    public static List<string> 紫色城墙道具升级Info = new List<string>()
    {
        { $"城墙最大生命值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[0], 1)}" },
        { $"城墙最大生命值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[1], 1)}" },
        { $"城墙最大生命值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[2], 1)}" },
        { $"城墙最大生命值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[3], 1)}" },
        { $"城墙最大生命值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[4], 1)}" },
    };
    
    public static List<string> 橙色城墙道具升级Info = new List<string>()
    {
        { $"城墙防御值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[0], 1)}" },
        { $"城墙防御值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[1], 1)}" },
        { $"城墙防御值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[2], 1)}" },
        { $"城墙防御值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[3], 1)}" },
        { $"城墙防御值增加{HeroConfig.Get技能伤害string(紫橙色道具升级奖励List[4], 1)}" },
    };
}
