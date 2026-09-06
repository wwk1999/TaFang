using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 体质Type
{
    None,
    凡体,
    火焰伤害灵体,
    寒冰伤害灵体,
    雷电伤害灵体,
    黑暗伤害灵体,
    物理伤害灵体,
    战士伤害灵体,
    法师伤害灵体,
    射手伤害灵体,
    辅助伤害灵体,
    控制伤害灵体,
    
    最终伤害仙体,
    暴击伤害仙体,
    攻击速度仙体,
    丹药仙体,
    寻宝仙体,
    功法仙体,//功法升级速度加快
    法器仙体,//增强法器效果
    
    火焰伤害仙体,
    寒冰伤害仙体,
    雷电伤害仙体,
    黑暗伤害仙体,
    物理伤害仙体,
    战士伤害仙体,
    法师伤害仙体,
    射手伤害仙体,
    辅助伤害仙体,
    控制伤害仙体,
    
    元素伤害圣体,
    职业伤害圣体,
    最终伤害圣体,
    暴击伤害圣体,
    攻击速度圣体,
    丹药圣体,
    寻宝圣体,
    功法圣体,//功法升级速度加快
    法器圣体,//增强法器效果
    
    丹药道体,
    寻宝道体,
    轮回道体,
    长生道体,
    时间道体,
}

public class 体质总属性
{
    public float 火焰伤害=0;
    public float 雷电伤害=0;
    public float 冰霜伤害=0;
    public float 物理伤害=0;
    public float 黑暗伤害=0;
    
    public float 战士伤害=0;
    public float 射手伤害=0;
    public float 法师伤害=0;
    public float 控制伤害=0;
    public float 辅助伤害=0;
    
    public float 最终伤害=0;
    public float 暴击伤害=0;
    public float 攻击速度=0;
    
    public float 丹药效果=0;
    public float 炼丹速度=0;
    public float 炼丹经验加成=0;
    public float 掉宝率=0;
    public float 功法经验加成=0;
    public float 功法每层效果=0;
    public float 法器效果加成=0;
    
    public float 轮回系数=0;
    public float 轮回次数加伤害=0;
    public float 每道年增加伤害=0;
    public float 时间流速加成=0;
}
public class 体质Config
{
    public static string Get体质品阶(体质Type type)
    {
        QualityType QualityType = 体质品质Dic[type];
        switch (QualityType)
        {
            case QualityType.黄品:
                return "凡体";
            case QualityType.地品:
                return "灵体";
            case QualityType.宇品:
                return "仙体";
            case QualityType.洪品:
                return "圣体";
            case QualityType.荒品:
                return "道体";
        }

        return "凡体";
    }

    public static 体质总属性 当前体质总属性 => 体质属性Dic[PlayerData.S.当前体质];
    public static Dictionary<体质Type, 体质总属性> 体质属性Dic = new Dictionary<体质Type, 体质总属性>()
    {
        { 体质Type.凡体 ,new 体质总属性()},
        { 体质Type.寒冰伤害灵体 ,new 体质总属性(){冰霜伤害 = 50}},
        { 体质Type.火焰伤害灵体 ,new 体质总属性(){火焰伤害 = 50}},
        { 体质Type.物理伤害灵体 ,new 体质总属性(){物理伤害 = 50}},
        { 体质Type.黑暗伤害灵体 ,new 体质总属性(){黑暗伤害 = 50}},
        { 体质Type.雷电伤害灵体 ,new 体质总属性(){雷电伤害 = 50}},
        { 体质Type.战士伤害灵体 ,new 体质总属性(){战士伤害 = 50}},
        { 体质Type.射手伤害灵体 ,new 体质总属性(){射手伤害 = 50}},
        { 体质Type.法师伤害灵体 ,new 体质总属性(){法师伤害 = 50}},
        { 体质Type.辅助伤害灵体 ,new 体质总属性(){辅助伤害 = 50}},
        { 体质Type.控制伤害灵体 ,new 体质总属性(){控制伤害 = 50}},
        
        { 体质Type.寒冰伤害仙体 ,new 体质总属性(){冰霜伤害 = 200}},
        { 体质Type.火焰伤害仙体 ,new 体质总属性(){火焰伤害 = 200}},
        { 体质Type.物理伤害仙体 ,new 体质总属性(){物理伤害 = 200}},
        { 体质Type.黑暗伤害仙体 ,new 体质总属性(){黑暗伤害 = 200}},
        { 体质Type.雷电伤害仙体 ,new 体质总属性(){雷电伤害 = 200}},
        { 体质Type.战士伤害仙体 ,new 体质总属性(){战士伤害 = 200}},
        { 体质Type.射手伤害仙体 ,new 体质总属性(){射手伤害 = 200}},
        { 体质Type.法师伤害仙体 ,new 体质总属性(){法师伤害 = 200}},
        { 体质Type.辅助伤害仙体 ,new 体质总属性(){辅助伤害 = 200}},
        { 体质Type.控制伤害仙体 ,new 体质总属性(){控制伤害 = 200}},
        { 体质Type.寻宝仙体 ,new 体质总属性(){掉宝率 = 60}},
        { 体质Type.功法仙体 ,new 体质总属性(){功法经验加成 =100,功法每层效果 = 30}},
        { 体质Type.丹药仙体 ,new 体质总属性(){丹药效果 = 40,炼丹经验加成 = 60,炼丹速度 = 60}},
        { 体质Type.攻击速度仙体 ,new 体质总属性(){攻击速度 = 60,最终伤害 = 60}},
        { 体质Type.最终伤害仙体 ,new 体质总属性(){最终伤害 = 120}},
        { 体质Type.暴击伤害仙体 ,new 体质总属性(){暴击伤害 = 150}},
        { 体质Type.法器仙体 ,new 体质总属性(){法器效果加成 = 40}},
        
        { 体质Type.丹药圣体 ,new 体质总属性(){丹药效果 = 80,炼丹经验加成 = 150,炼丹速度 = 150}},
        { 体质Type.元素伤害圣体 ,new 体质总属性(){火焰伤害 = 300,冰霜伤害 = 300,物理伤害 = 300,雷电伤害 = 300,黑暗伤害 = 300}},
        { 体质Type.功法圣体 ,new 体质总属性(){功法经验加成 = 250,功法每层效果 = 100}},
        { 体质Type.寻宝圣体 ,new 体质总属性(){掉宝率 = 150}},
        { 体质Type.攻击速度圣体 ,new 体质总属性(){攻击速度 = 120,最终伤害 = 120}},
        { 体质Type.职业伤害圣体 ,new 体质总属性(){战士伤害 = 300,射手伤害 = 300,辅助伤害 = 300,法师伤害 = 300,控制伤害 = 300}},
        { 体质Type.暴击伤害圣体 ,new 体质总属性(){暴击伤害 = 300}},
        { 体质Type.最终伤害圣体 ,new 体质总属性(){最终伤害 = 300}},
        { 体质Type.法器圣体 ,new 体质总属性(){法器效果加成 = 80}},

        { 体质Type.丹药道体 ,new 体质总属性(){丹药效果 = 200,炼丹经验加成 = 500,炼丹速度 = 500}},
        { 体质Type.寻宝道体 ,new 体质总属性(){掉宝率 = 300}},
        { 体质Type.长生道体 ,new 体质总属性(){每道年增加伤害 = 1}},
        { 体质Type.轮回道体 ,new 体质总属性(){轮回系数 = 3,轮回次数加伤害 = 10}},
        { 体质Type.时间道体 ,new 体质总属性(){时间流速加成 = 200}},

    };
    public static Dictionary<体质Type, string> 体质名Dic = new Dictionary<体质Type, string>()
    {
        { 体质Type.None, "无" },
        { 体质Type.凡体, "凡体" },
        // 灵体
        { 体质Type.火焰伤害灵体, "阳灵体" },
        { 体质Type.寒冰伤害灵体, "霜灵体" },
        { 体质Type.雷电伤害灵体, "雷灵体" },
        { 体质Type.黑暗伤害灵体, "幽影灵体" },
        { 体质Type.物理伤害灵体, "金刚灵体" },
        { 体质Type.战士伤害灵体, "虎贲灵体" },
        { 体质Type.法师伤害灵体, "灵枢灵体" },
        { 体质Type.射手伤害灵体, "穿云灵体" },
        { 体质Type.辅助伤害灵体, "甘霖灵体" },
        { 体质Type.控制伤害灵体, "囚笼灵体" },
        // 仙体
        { 体质Type.最终伤害仙体, "破妄仙体" },
        { 体质Type.暴击伤害仙体, "天命仙体" },
        { 体质Type.攻击速度仙体, "流光仙体" },
        { 体质Type.丹药仙体, "丹心仙体" },
        { 体质Type.寻宝仙体, "宝光仙体" },
        { 体质Type.功法仙体, "通明仙体" },
        { 体质Type.法器仙体, "御灵仙体" },
        { 体质Type.火焰伤害仙体, "大日仙体" },
        { 体质Type.寒冰伤害仙体, "寒狱仙体" },
        { 体质Type.雷电伤害仙体, "紫霄仙体" },
        { 体质Type.黑暗伤害仙体, "九幽仙体" },
        { 体质Type.物理伤害仙体, "须弥仙体" },
        { 体质Type.战士伤害仙体, "破军仙体" },
        { 体质Type.法师伤害仙体, "天枢仙体" },
        { 体质Type.射手伤害仙体, "逐日仙体" },
        { 体质Type.辅助伤害仙体, "沐霖仙体" },
        { 体质Type.控制伤害仙体, "镇狱仙体" },
        // 圣体
        { 体质Type.元素伤害圣体, "五行圣体" },
        { 体质Type.职业伤害圣体, "万象圣体" },
        { 体质Type.最终伤害圣体, "归墟圣体" },
        { 体质Type.暴击伤害圣体, "劫运圣体" },
        { 体质Type.攻击速度圣体, "浮光圣体" },
        { 体质Type.丹药圣体, "玄丹圣体" },
        { 体质Type.寻宝圣体, "天机圣体" },
        { 体质Type.功法圣体, "道衍圣体" },
        { 体质Type.法器圣体, "万器圣体" },
        // 道体
        { 体质Type.丹药道体, "造化道体" },
        { 体质Type.寻宝道体, "寻龙道体" },
        { 体质Type.轮回道体, "轮回道体" },
        { 体质Type.长生道体, "长生道体" },
        { 体质Type.时间道体, "刹那道体" },
    };
    public static Dictionary<体质Type, string> 体质DescDic = new Dictionary<体质Type, string>()
{
    { 体质Type.None, "无特殊体质" },
    { 体质Type.凡体, "凡俗之体，根骨平平，无任何先天禀赋" },

    // 灵体
    { 体质Type.火焰伤害灵体, "阳火之体，天性亲火，于烈焰中修行事半功倍" },
    { 体质Type.寒冰伤害灵体, "霜寒之体，身负冰魄，极寒之地如履平地" },
    { 体质Type.雷电伤害灵体, "雷蕴之体，天生御雷，引九天雷霆淬炼己身" },
    { 体质Type.黑暗伤害灵体, "幽影之体，融于暗夜，隐匿潜伏如同本能" },
    { 体质Type.物理伤害灵体, "金刚之体，筋骨如铁，纯粹肉身之力远超同侪" },
    { 体质Type.战士伤害灵体, "虎贲之体，战意勃发，近身搏杀天赋绝伦" },
    { 体质Type.法师伤害灵体, "灵枢之体，通晓法理，参悟术法远超常人" },
    { 体质Type.射手伤害灵体, "穿云之体，目贯苍穹，箭出必中百步之外" },
    { 体质Type.辅助伤害灵体, "甘霖之体，心怀济世，辅助之术浑然天成" },
    { 体质Type.控制伤害灵体, "囚笼之体，善缚敌手，控场困锁信手拈来" },

    // 仙体
    { 体质Type.火焰伤害仙体, "大日之体，火中真灵，万火俯首焚天煮海" },
    { 体质Type.寒冰伤害仙体, "寒狱之体，冰魄凝魂，一念霜封千里之地" },
    { 体质Type.雷电伤害仙体, "紫霄之体，雷霆加身，驭九天之电如臂使指" },
    { 体质Type.黑暗伤害仙体, "九幽之体，暗影共鸣，深得幽冥之力真传" },
    { 体质Type.物理伤害仙体, "须弥之体，肉身成岳，力可开山断岳万法不侵" },
    { 体质Type.战士伤害仙体, "破军之体，战意如虹，愈战愈勇所向披靡" },
    { 体质Type.法师伤害仙体, "天枢之体，法道天选，仙术奥义一点即通" },
    { 体质Type.射手伤害仙体, "逐日之体，箭道通神，千里穿杨例不虚发" },
    { 体质Type.辅助伤害仙体, "沐霖之体，泽被苍生，辅助之术出神入化" },
    { 体质Type.控制伤害仙体, "镇狱之体，困锁大道，万敌入阵如陷泥沼" },
    { 体质Type.最终伤害仙体, "破妄之体，直指本源，出手便是极致之威" },
    { 体质Type.暴击伤害仙体, "天命之体，气运所钟，招招致命直取要害" },
    { 体质Type.攻击速度仙体, "流光之体，身法如电，出手之迅疾难以捕捉" },
    { 体质Type.丹药仙体, "丹心之体，通晓药性，炼丹制药天赋异禀" },
    { 体质Type.寻宝仙体, "宝光之体，身怀灵犀，天材地宝无所遁形" },
    { 体质Type.功法仙体, "通明之体，过目不忘，功法修行一日千里" },
    { 体质Type.法器仙体, "御灵之体，法器亲和，驱使法宝威力倍增" },

    // 圣体
    { 体质Type.元素伤害圣体, "五行之体，万化由心，天地元素尽在掌控之中" },
    { 体质Type.职业伤害圣体, "万象之体，诸道皆通，各职业战技信手拈来" },
    { 体质Type.最终伤害圣体, "归墟之体，触及大道尽头，出手便为极限之威" },
    { 体质Type.暴击伤害圣体, "劫运之体，洞悉破绽，一击必中无可躲避" },
    { 体质Type.攻击速度圣体, "浮光之体，动静如幻，瞬息之间已历千百回合" },
    { 体质Type.丹药圣体, "玄丹之体，药道圣姿，丹成异象药力超凡" },
    { 体质Type.寻宝圣体, "天机之体，洞悉机缘，世间奇珍尽入彀中" },
    { 体质Type.功法圣体, "道衍之体，法理天成，任何功法一触即通" },
    { 体质Type.法器圣体, "万器之体，万宝朝宗，法宝在手即化至强" },

    // 道体
    { 体质Type.丹药道体, "造化之体，天地为炉，万物为药，丹道至高" },
    { 体质Type.寻宝道体, "寻龙之体，望气堪舆，天下龙脉宝穴无所不察" },
    { 体质Type.轮回道体, "轮回之体，历劫不灭，百世积累道果归于一身" },
    { 体质Type.长生道体, "长生之体，寿元无尽，与天地同寿日月同辉" },
    { 体质Type.时间道体, "刹那之体，超脱岁月，掌光阴流转万古为瞬" },
};
    public static Dictionary<体质Type, QualityType> 体质品质Dic = new Dictionary<体质Type, QualityType>()
    {
        { 体质Type.None, QualityType.None },
        { 体质Type.凡体, QualityType.黄品 },
        // 灵体
        { 体质Type.火焰伤害灵体, QualityType.地品 },
        { 体质Type.寒冰伤害灵体, QualityType.地品 },
        { 体质Type.雷电伤害灵体, QualityType.地品 },
        { 体质Type.黑暗伤害灵体, QualityType.地品 },
        { 体质Type.物理伤害灵体, QualityType.地品 },
        { 体质Type.战士伤害灵体, QualityType.地品 },
        { 体质Type.法师伤害灵体, QualityType.地品 },
        { 体质Type.射手伤害灵体, QualityType.地品 },
        { 体质Type.辅助伤害灵体, QualityType.地品 },
        { 体质Type.控制伤害灵体, QualityType.地品 },
        // 仙体
        { 体质Type.最终伤害仙体, QualityType.宇品 },
        { 体质Type.暴击伤害仙体, QualityType.宇品 },
        { 体质Type.攻击速度仙体, QualityType.宇品 },
        { 体质Type.丹药仙体, QualityType.宇品 },
        { 体质Type.寻宝仙体, QualityType.宇品 },
        { 体质Type.功法仙体, QualityType.宇品 },
        { 体质Type.法器仙体, QualityType.宇品 },
        { 体质Type.火焰伤害仙体, QualityType.宇品 },
        { 体质Type.寒冰伤害仙体, QualityType.宇品 },
        { 体质Type.雷电伤害仙体, QualityType.宇品 },
        { 体质Type.黑暗伤害仙体, QualityType.宇品 },
        { 体质Type.物理伤害仙体, QualityType.宇品 },
        { 体质Type.战士伤害仙体, QualityType.宇品 },
        { 体质Type.法师伤害仙体, QualityType.宇品 },
        { 体质Type.射手伤害仙体, QualityType.宇品 },
        { 体质Type.辅助伤害仙体, QualityType.宇品 },
        { 体质Type.控制伤害仙体, QualityType.宇品 },
        // 圣体
        { 体质Type.元素伤害圣体, QualityType.洪品 },
        { 体质Type.职业伤害圣体, QualityType.洪品 },
        { 体质Type.最终伤害圣体, QualityType.洪品 },
        { 体质Type.暴击伤害圣体, QualityType.洪品 },
        { 体质Type.攻击速度圣体, QualityType.洪品 },
        { 体质Type.丹药圣体, QualityType.洪品 },
        { 体质Type.寻宝圣体, QualityType.洪品 },
        { 体质Type.功法圣体, QualityType.洪品 },
        { 体质Type.法器圣体, QualityType.洪品 },
        // 道体
        { 体质Type.丹药道体, QualityType.荒品 },
        { 体质Type.寻宝道体, QualityType.荒品 },
        { 体质Type.轮回道体, QualityType.荒品 },
        { 体质Type.长生道体, QualityType.荒品 },
        { 体质Type.时间道体, QualityType.荒品 },
    };
    
    public static Dictionary<QualityType, List<体质Type>> 体质列表Dic = new Dictionary<QualityType, List<体质Type>>()
    {
        {
            QualityType.黄品, new List<体质Type>
            {
                体质Type.凡体,
            }
        },
        {
            QualityType.地品, new List<体质Type>
            {
                体质Type.火焰伤害灵体,
                体质Type.寒冰伤害灵体,
                体质Type.雷电伤害灵体,
                体质Type.黑暗伤害灵体,
                体质Type.物理伤害灵体,
                体质Type.战士伤害灵体,
                体质Type.法师伤害灵体,
                体质Type.射手伤害灵体,
                体质Type.辅助伤害灵体,
                体质Type.控制伤害灵体,
            }
        },
        {
            QualityType.宇品, new List<体质Type>
            {
                体质Type.最终伤害仙体,
                体质Type.暴击伤害仙体,
                体质Type.攻击速度仙体,
                体质Type.丹药仙体,
                体质Type.寻宝仙体,
                体质Type.功法仙体,
                体质Type.法器仙体,
                体质Type.火焰伤害仙体,
                体质Type.寒冰伤害仙体,
                体质Type.雷电伤害仙体,
                体质Type.黑暗伤害仙体,
                体质Type.物理伤害仙体,
                体质Type.战士伤害仙体,
                体质Type.法师伤害仙体,
                体质Type.射手伤害仙体,
                体质Type.辅助伤害仙体,
                体质Type.控制伤害仙体,
            }
        },
        {
            QualityType.洪品, new List<体质Type>
            {
                体质Type.元素伤害圣体,
                体质Type.职业伤害圣体,
                体质Type.最终伤害圣体,
                体质Type.暴击伤害圣体,
                体质Type.攻击速度圣体,
                体质Type.丹药圣体,
                体质Type.寻宝圣体,
                体质Type.功法圣体,
                体质Type.法器圣体,
            }
        },
        {
            QualityType.荒品, new List<体质Type>
            {
                体质Type.丹药道体,
                体质Type.寻宝道体,
                体质Type.轮回道体,
                体质Type.长生道体,
                体质Type.时间道体,
            }
        },
    };

    public static Dictionary<QualityType, int> 体质修炼速度Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品, 1 },
        { QualityType.地品, 3 },
        { QualityType.宇品, 10 },
        { QualityType.洪品, 30 },
        { QualityType.荒品, 100 },
    };

    public static QualityType Get轮回体质品质(float 跟脚)
    {
        List<float> list = null;
        if (跟脚 < 10)
        {
            list = new List<float>(){80,20,0,0,0};
        }else if (跟脚 < 100)
        {
            list = new List<float>(){50,50,0,0,0};
        }
        else if (跟脚 < 1000)
        {
            list = new List<float>(){25,60,15,0,0};
        }else if (跟脚 < 10000)
        {
            list = new List<float>(){0,70,30,0,0};
        }else if (跟脚 < 100000)
        {
            list = new List<float>(){0,40,50,10,0};
        }else if (跟脚 < 1000000)
        {
            list = new List<float>(){0,10,60,30,0};
        }else if (跟脚 < 10000000)
        {
            list = new List<float>(){0,0,45,50,5};
        }else if (跟脚 < 100000000)
        {
            list = new List<float>(){0,0,15,70,15};
        }
        else if (跟脚 < 1000000000)
        {
            list = new List<float>(){0,0,0,70,30};
        }
        else if (跟脚 < 10000000000)
        {
            list = new List<float>(){0,0,0,50,50};
        }
        else if (跟脚 < 100000000000)
        {
            list = new List<float>(){0,0,0,20,80};
        }
        else
        {
            list = new List<float>(){0,0,0,0,100};
        }

        var random = Random.Range(0, 100f);
        float count = 0;
        for (int i = 0; i <= 5; i++)
        {
            count += list[i];
            if (random <= count)
            {
                switch (i)
                {
                    case 0:
                        return QualityType.黄品;
                    case 1:
                        return QualityType.地品;
                    case 2:
                        return QualityType.宇品;
                    case 3:
                        return QualityType.洪品;
                    case 4:
                        return QualityType.荒品;

                }
            }
        }

        return QualityType.黄品;
    }

    public static 体质Type Get轮回体质()
    {
        QualityType qualityType = Get轮回体质品质(JingJieConfig.跟脚);
        var list=体质列表Dic[qualityType];
        int random = Random.Range(0, list.Count);
        return list[random];
    }
}
