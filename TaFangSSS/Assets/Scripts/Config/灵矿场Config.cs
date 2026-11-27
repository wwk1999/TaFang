using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 矿工类型
{
    None,
    全脉矿工,
    多宝矿工,//挖宝箱快
    守脉矿工,//固定收益
    疾行矿工,//挖掘速度
    秀灵矿工,//成长速度
}

public enum 矿工装备Type
{
    None,
    稿子,
    衣服,
    护手,
    罗盘,
}

public enum 宝箱品质
{
    普通,
    卓越,
    至尊,
}
public enum 矿工词条类型
{
    None,
    百分比加挖掘速度,
    百分比加固定收益,
    百分比加挖宝速度,
    百分比加成长速度,
}

public class 宝物属性
{
    public float 加挖掘速度;
    public float 加固定收益;
    public float 加挖宝速度;
    public float 加成长速度;
    
    public float 加秀灵矿工成长速度;
    public float 加多宝矿工挖宝时间;
    public float 加守脉矿工固定收益;
    public float 加疾行矿工挖掘速度;
    
    public float 挖宝概率两个白;
    public float 灵矿价格上涨;
    public float 装备效果;
    public float 刷新价格降低;
    public float 装备分解增多;
    public float 解雇增多;
    public float 招募价格;
    public float 等级效果;
    public float 升星效果;
}
public enum 宝物Type
{
    None,
    加挖掘速度,
    加固定收益,
    加挖宝速度,
    加成长速度,
    
    加秀灵矿工成长速度,
    加多宝矿工挖宝时间,
    加守脉矿工固定收益,
    加疾行矿工挖掘速度,
    
    挖宝概率两个白,
    灵矿价格上涨,
    装备效果,
    刷新价格降低,
    装备分解增多,
    解雇增多,
    
    招募价格,
    等级效果,
    升星效果,
}
public enum 土层Type
{
    None,
    黑土浅层,
    岩石矿层,
    赤铜矿层,
    玄铁深层,
    金玉灵层,
    紫晶幻层,
    地火熔层,
    深渊暗层,
    归墟混元层,
    太初本源层,
    无量空处层,
}

public class 矿工人数上限配置
{
    public int 人数;
    public float 升级灵魂;
}
public class 宝物佩戴上限配置
{
    public int 个数;
    public float 升级灵魂;
}

public class 矿工招募概率配置
{
    public List<float> 招募概率 = new List<float>();
    public float 升级灵魂;
}

public class 矿工阶数上限配置
{
    public int 阶数;
    public float 升级灵魂;
}

public class 宝箱品质概率配置
{
    public List<float> 宝箱概率 = new List<float>();
    public float 升级灵魂;
}

public class 四维属性
 {
     public float 挖掘速度;
     public float 固定收益;
     public float 挖宝时间;
     public float 成长速度;
 }

public class 矿工
{
    public QualityType QualityType;
    public string name;
    public 矿工类型 矿工类型;
    public int 阶数;
    public 四维属性 基础四维=new 四维属性();
    public List<矿工词条类型> 词条列表 = new List<矿工词条类型>();
    public int 等级;
    public float 经验;
    public int 星级;
    public bool 已被招募;
    public 矿工装备 罗盘=null;
    public 矿工装备 稿子=null;
    public 矿工装备 护手=null;
    public 矿工装备 衣服=null;
    public float 当前挖宝时间 = 0;
}

public class 矿工装备
{
    public 矿工装备Type 矿工装备Type;
    public 四维属性 基础四维;
    public int 阶数;
    public QualityType QualityType;
    public bool 挖掘速度无暇;
    public bool 固定收益无暇;
    public bool 挖宝时间无暇;
    public bool 成长速度无暇;
    public bool 挖掘速度洗练锁;
    public bool 固定收益洗练锁;
    public bool 挖宝时间洗练锁;
    public bool 成长速度洗练锁;
    public bool 锁;
    public 矿工 矿工 = null;
}

public class 灵矿配置
{
    public int 阶数;
    public string 名称;
    public string 介绍;
    public float 价格;
}

public class 宝物
{
    public 宝物Type 宝物Type;
    public QualityType QualityType;
}

public enum 宝箱物品Type
{
    None,
    灵矿,
    装备,
    宝物,
}
public class 灵矿场Config
{
    public static List<minmax> 矿工位置 = new List<minmax>()
    {
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 300, max = 0 },
        new minmax() { min = -300, max = 0 },
        new minmax() { min = 600, max = 0 },
        new minmax() { min = -600, max = 0 },
        new minmax() { min = 880, max = 0 },
        new minmax() { min = -880, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
        new minmax() { min = 0, max = 0 },
    };
    public static Dictionary<宝物Type, string> 宝物名 = new Dictionary<宝物Type, string>()
    {
        { 宝物Type.None, "无" },
        { 宝物Type.加挖掘速度, "穿山印" },
        { 宝物Type.加固定收益, "聚宝盆" },
        { 宝物Type.加挖宝速度, "寻龙镜" },
        { 宝物Type.加成长速度, "悟道珠" },

        { 宝物Type.加秀灵矿工成长速度, "秀灵露" },
        { 宝物Type.加多宝矿工挖宝时间, "多宝塔" },
        { 宝物Type.加守脉矿工固定收益, "守脉符" },
        { 宝物Type.加疾行矿工挖掘速度, "疾行靴" },

        { 宝物Type.挖宝概率两个白, "双宝璧" },
        { 宝物Type.灵矿价格上涨, "点金石" },
        { 宝物Type.装备效果, "铸灵鼎" },
        { 宝物Type.刷新价格降低, "省元符" },
        { 宝物Type.装备分解增多, "归元炉" },
        { 宝物Type.解雇增多, "散灵符" },

        { 宝物Type.招募价格, "聚贤令" },
        { 宝物Type.等级效果, "登天阶" },
        { 宝物Type.升星效果, "星辰砂" },
    };
    public static Dictionary<宝物Type, string> 宝物效果名 = new Dictionary<宝物Type, string>()
    {
        { 宝物Type.None, "无" },
        { 宝物Type.加挖掘速度, "破石穿山" },
        { 宝物Type.加固定收益, "坐享灵脉" },
        { 宝物Type.加挖宝速度, "寻龙探宝" },
        { 宝物Type.加成长速度, "悟道通玄" },

        { 宝物Type.加秀灵矿工成长速度, "毓秀钟灵" },
        { 宝物Type.加多宝矿工挖宝时间, "宝光长明" },
        { 宝物Type.加守脉矿工固定收益, "守脉固元" },
        { 宝物Type.加疾行矿工挖掘速度, "疾行如风" },

        { 宝物Type.挖宝概率两个白, "双宝临门" },
        { 宝物Type.灵矿价格上涨, "点石成金" },
        { 宝物Type.装备效果, "器灵共鸣" },
        { 宝物Type.刷新价格降低, "开源节流" },
        { 宝物Type.装备分解增多, "化器归元" },
        { 宝物Type.解雇增多, "散灵聚财" },

        { 宝物Type.招募价格, "广纳贤才" },
        { 宝物Type.等级效果, "登阶问道" },
        { 宝物Type.升星效果, "星辉淬体" },
    };
    public static float Get装备分解粉尘(int 阶数, QualityType qualityType)
    {
        阶数 = Mathf.Clamp(阶数, 1, 10);
        float 基础 = 装备分解粉尘[阶数];
        基础 *= 装备分解品质粉尘倍数[Get装备品质索引(qualityType)];
        基础 *= (1f + 当前总宝物属性.装备分解增多 / 100f);
        return 基础;
    }
    
    public static float Get装备洗练粉尘(int 阶数, QualityType qualityType)
    {
        阶数 = Mathf.Clamp(阶数, 1, 10);
        float 基础 = 装备洗练粉尘[阶数];
        基础 *= 装备分解品质粉尘倍数[Get装备品质索引(qualityType)];
        return 基础;
    }


    public static float Get宝物格子升级碎片(int 等级)
    {
        return 等级 + 1;
    }

    public static Dictionary<QualityType, float> 宝物分解碎片 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品 ,1},
        { QualityType.地品 ,3},
        { QualityType.宇品 ,6},
        { QualityType.洪品 ,15},
        { QualityType.荒品 ,50},
    };

    public static float Get宝物碎片(QualityType qualityType)
    {
        float 基础=宝物分解碎片[qualityType];
        return 基础;
    }
   

    // 装备/宝物只使用黄、地、宇、洪、荒五种品质，枚举值不连续，这里映射到 0~4
    private static int Get装备品质索引(QualityType qualityType)
    {
        switch (qualityType)
        {
            case QualityType.地品:
                return 1;
            case QualityType.宇品:
                return 2;
            case QualityType.洪品:
                return 3;
            case QualityType.荒品:
                return 4;
            default:
                return 0;
        }
    }
    public static List<float>装备分解品质粉尘倍数=new List<float>(){1,2,4,10,30};
    public static Dictionary<int, float> 装备分解粉尘 = new Dictionary<int, float>()
    {
        { 1, 100 },
        { 2, 300 },
        { 3, 1000 },
        { 4, 3000 },
        { 5, 10000 },
        { 6, 30000 },
        { 7, 100000 },
        { 8, 300000 },
        { 9, 1000000 },
        { 10, 3000000 },
    };
    
    public static Dictionary<int, float> 装备洗练粉尘 = new Dictionary<int, float>()
    {
        { 1, 30 },
        { 2, 100 },
        { 3, 300 },
        { 4, 1000 },
        { 5, 3000 },
        { 6, 10000 },
        { 7, 30000 },
        { 8, 100000 },
        { 9, 300000 },
        { 10, 1000000 },
    };
    public static string Get总宝物效果(宝物Type 宝物Type)
    {
        if (宝物Type == 宝物Type.None) return string.Empty;

        var 属性 = 当前总宝物属性;
        string 数值 = ((int)Get总宝物数值(宝物Type, 属性)).ToString();
        switch (宝物Type)
        {
            case 宝物Type.加挖掘速度:
                return "所有矿工挖掘速度+" + 数值 + "%";
            case 宝物Type.加固定收益:
                return "所有矿工固定收益+" + 数值 + "%";
            case 宝物Type.加挖宝速度:
                return "所有矿工挖宝速度+" + 数值 + "%";
            case 宝物Type.加成长速度:
                return "所有矿工成长速度+" + 数值 + "%";

            case 宝物Type.加秀灵矿工成长速度:
                return "秀灵矿工成长速度+" + 数值 + "%";
            case 宝物Type.加多宝矿工挖宝时间:
                return "多宝矿工挖宝时间+" + 数值 + "%";
            case 宝物Type.加守脉矿工固定收益:
                return "守脉矿工固定收益+" + 数值 + "%";
            case 宝物Type.加疾行矿工挖掘速度:
                return "疾行矿工挖掘速度+" + 数值 + "%";

            case 宝物Type.挖宝概率两个白:
                return "挖宝时" + 数值 + "%概率一次挖出两个宝箱";
            case 宝物Type.灵矿价格上涨:
                return "灵矿出售价格+" + 数值 + "%";
            case 宝物Type.装备效果:
                return "矿工装备效果+" + 数值 + "%";
            case 宝物Type.刷新价格降低:
                return "招募刷新价格-" + 数值 + "%";
            case 宝物Type.装备分解增多:
                return "装备分解收益+" + 数值 + "%";
            case 宝物Type.解雇增多:
                return "解雇矿工返还+" + 数值 + "%";

            case 宝物Type.招募价格:
                return "招募矿工价格-" + 数值 + "%";
            case 宝物Type.等级效果:
                return "矿工等级效果+" + 数值 + "%";
            case 宝物Type.升星效果:
                return "矿工升星效果+" + 数值 + "%";
        }

        return string.Empty;
    }

    // 取汇总后的宝物属性值（对应 宝物属性 的字段）
    public static float Get总宝物数值(宝物Type 宝物Type, 宝物属性 属性)
    {
        switch (宝物Type)
        {
            case 宝物Type.加挖掘速度: return 属性.加挖掘速度;
            case 宝物Type.加固定收益: return 属性.加固定收益;
            case 宝物Type.加挖宝速度: return 属性.加挖宝速度;
            case 宝物Type.加成长速度: return 属性.加成长速度;

            case 宝物Type.加秀灵矿工成长速度: return 属性.加秀灵矿工成长速度;
            case 宝物Type.加多宝矿工挖宝时间: return 属性.加多宝矿工挖宝时间;
            case 宝物Type.加守脉矿工固定收益: return 属性.加守脉矿工固定收益;
            case 宝物Type.加疾行矿工挖掘速度: return 属性.加疾行矿工挖掘速度;

            case 宝物Type.挖宝概率两个白: return 属性.挖宝概率两个白;
            case 宝物Type.灵矿价格上涨: return 属性.灵矿价格上涨;
            case 宝物Type.装备效果: return 属性.装备效果;
            case 宝物Type.刷新价格降低: return 属性.刷新价格降低;
            case 宝物Type.装备分解增多: return 属性.装备分解增多;
            case 宝物Type.解雇增多: return 属性.解雇增多;

            case 宝物Type.招募价格: return 属性.招募价格;
            case 宝物Type.等级效果: return 属性.等级效果;
            case 宝物Type.升星效果: return 属性.升星效果;
        }
        return 0;
    }

    // 灵矿场品质显示名：黄→普通、地→稀有、宇→罕见、洪→神话、荒→永恒
    public static string Get品质显示名(QualityType qualityType)
    {
        switch (qualityType)
        {
            case QualityType.黄品: return "普通";
            case QualityType.地品: return "稀有";
            case QualityType.宇品: return "罕见";
            case QualityType.洪品: return "神话";
            case QualityType.荒品: return "永恒";
            default: return PropConfig.QualityNameDic[qualityType];
        }
    }

    public static string Get宝物效果(宝物Type 宝物Type, QualityType qualityType)
    {
        if (宝物Type == 宝物Type.None) return string.Empty;

        string 数值 = Get宝物属性(宝物Type, qualityType).ToString("0");
        switch (宝物Type)
        {
            case 宝物Type.加挖掘速度:
                return "所有矿工挖掘速度+" + 数值 + "%";
            case 宝物Type.加固定收益:
                return "所有矿工固定收益+" + 数值 + "%";
            case 宝物Type.加挖宝速度:
                return "所有矿工挖宝速度+" + 数值 + "%";
            case 宝物Type.加成长速度:
                return "所有矿工成长速度+" + 数值 + "%";

            case 宝物Type.加秀灵矿工成长速度:
                return "秀灵矿工成长速度+" + 数值 + "%";
            case 宝物Type.加多宝矿工挖宝时间:
                return "多宝矿工挖宝时间+" + 数值 + "%";
            case 宝物Type.加守脉矿工固定收益:
                return "守脉矿工固定收益+" + 数值 + "%";
            case 宝物Type.加疾行矿工挖掘速度:
                return "疾行矿工挖掘速度+" + 数值 + "%";

            case 宝物Type.挖宝概率两个白:
                return "挖宝时"+数值+"%概率一次挖出两个宝箱";
            case 宝物Type.灵矿价格上涨:
                return "灵矿出售价格+" + 数值 + "%";
            case 宝物Type.装备效果:
                return "矿工装备效果+" + 数值 + "%";
            case 宝物Type.刷新价格降低:
                return "招募刷新价格-" + 数值 + "%";
            case 宝物Type.装备分解增多:
                return "装备分解收益+" + 数值 + "%";
            case 宝物Type.解雇增多:
                return "解雇矿工返还+" + 数值 + "%";

            case 宝物Type.招募价格:
                return "招募矿工价格-" + 数值 + "%";
            case 宝物Type.等级效果:
                return "矿工等级效果+" + 数值 + "%";
            case 宝物Type.升星效果:
                return "矿工升星效果+" + 数值 + "%";
        }

        return string.Empty;
    }
    public static Dictionary<宝物Type, string> 宝物描述 = new Dictionary<宝物Type, string>()
    {
        { 宝物Type.None, "无" },

        // ===== 基础增益 =====
        { 宝物Type.加挖掘速度,     "古印蕴有穿山之能，佩戴后挖掘速度提升，破岩如穿纸。" },
        { 宝物Type.加固定收益,     "盆底聚气生财，矿工固定收益提升，日进斗金。" },
        { 宝物Type.加挖宝速度,     "镜照地脉，寻龙点穴，挖宝速度大幅提升。" },
        { 宝物Type.加成长速度,     "珠中藏道，矿工悟性大增，成长速度提升。" },

        // ===== 矿工专属 =====
        { 宝物Type.加秀灵矿工成长速度, "灵露滋养，秀灵矿工成长速度提升，灵秀更胜往昔。" },
        { 宝物Type.加多宝矿工挖宝时间, "塔镇多宝，多宝矿工挖宝时间延长，财源滚滚。" },
        { 宝物Type.加守脉矿工固定收益, "符守地脉，守脉矿工固定收益提升，稳如磐石。" },
        { 宝物Type.加疾行矿工挖掘速度, "靴踏疾风，疾行矿工挖掘速度提升，快若奔雷。" },

        // ===== 挖宝与收益 =====
        { 宝物Type.挖宝概率两个白,  "双璧合一，挖宝时更易一次得双白，好事成双。" },
        { 宝物Type.灵矿价格上涨,    "金石点化，灵矿出售价格上涨，点石成金。" },
        { 宝物Type.装备效果,        "鼎炼灵装，装备效果提升，器灵共鸣。" },
        { 宝物Type.刷新价格降低,    "符省元宝，刷新价格降低，开源节流。" },
        { 宝物Type.装备分解增多,    "炉归元材，装备分解所得增多，化零为整。" },
        { 宝物Type.解雇增多,        "符散灵契，解雇返还增多，好聚好散。" },

        // ===== 招募与成长 =====
        { 宝物Type.招募价格,        "令牌聚贤，招募价格降低，广纳良才。" },
        { 宝物Type.等级效果,        "阶登天梯，等级效果提升，步步登高。" },
        { 宝物Type.升星效果,        "砂聚星辰，升星效果提升，星光璀璨。" },
    };
    public static 土层Type Get当前层()
    {
        foreach (var item in 土层米数)
        {
            if (PlayerData.S.灵矿场当前米数 < item.Value)
            {
                return  item.Key-1;
            }
        }
        return 土层Type.太初本源层;
    }

    public static Dictionary<矿工词条类型, string> 矿工词条名 = new Dictionary<矿工词条类型, string>()
    {
        { 矿工词条类型.百分比加挖掘速度 ,"掘速如风"},
        { 矿工词条类型.百分比加固定收益 ,"聚灵纳财"},
        { 矿工词条类型.百分比加挖宝速度 ,"寻龙觅宝"},
        { 矿工词条类型.百分比加成长速度 ,"悟道通玄"},

    };

    public static void 刷新招募列表(int 阶数)
    {
        var 概率 = 矿工招募概率配置[PlayerData.S.矿洞矿工招募概率等级];
        PlayerData.S.当前招募矿工列表.Clear();
        for (int i = 0; i < 5; i++)
        {
            float random = Random.Range(0f, 100f);
            if (random < 概率.招募概率[4])
            {
                矿工 矿工 = 生成招募矿工((矿工类型)Random.Range(1,6),阶数, QualityType.荒品);
                PlayerData.S.当前招募矿工列表.Add(矿工);
            }else if (random < 概率.招募概率[4]+概率.招募概率[3])
            {
                矿工 矿工 = 生成招募矿工((矿工类型)Random.Range(1,6),阶数, QualityType.洪品);
                PlayerData.S.当前招募矿工列表.Add(矿工);
            }else if (random < 概率.招募概率[4]+概率.招募概率[3]+概率.招募概率[2])
            {
                矿工 矿工 = 生成招募矿工((矿工类型)Random.Range(1,6),阶数, QualityType.宇品);
                PlayerData.S.当前招募矿工列表.Add(矿工);
            }else if (random < 概率.招募概率[1]+概率.招募概率[2]+概率.招募概率[3]+概率.招募概率[4])
            {
                矿工 矿工 = 生成招募矿工((矿工类型)Random.Range(1,6),阶数, QualityType.地品);
                PlayerData.S.当前招募矿工列表.Add(矿工);
            }else 
            {
                矿工 矿工 = 生成招募矿工((矿工类型)Random.Range(1,6),阶数, QualityType.黄品);
                PlayerData.S.当前招募矿工列表.Add(矿工);
            }
        }
        
    }

    public static Dictionary<宝箱品质, string> 宝箱介绍 = new Dictionary<宝箱品质, string>()
    {
        { 宝箱品质.普通 ,"普通宝箱，最高可开出稀有品质物品"},
        { 宝箱品质.卓越 ,"卓越宝箱，最高可开出神话品质物品"},
        { 宝箱品质.至尊 ,"至尊宝箱，最高可开出永恒品质物品"},

    };

    public static Dictionary<QualityType, float> 灵矿品质倍率 = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品 ,1},
        { QualityType.地品 ,2},
        { QualityType.宇品 ,4},
        { QualityType.洪品 ,10},
        { QualityType.荒品 ,30},
    };
    public static float Get灵矿价格(int 阶数, QualityType qualityType)
    {
        float 基础价格 = 灵矿配置表[阶数].价格;
        基础价格 *= (1f+当前总宝物属性.灵矿价格上涨 / 100f);
        基础价格*=灵矿品质倍率[qualityType];
        return 基础价格;
    }
    public static Dictionary<int, 灵矿配置> 灵矿配置表 = new Dictionary<int, 灵矿配置>()
    {
        {
            1, new 灵矿配置
            {
                阶数 = 1,
                名称 = "黑土灵石",
                介绍 = "黑土浅层中凝结的粗浅灵石，杂质颇多。",
                价格 = 150f,
            }
        },
        {
            2, new 灵矿配置
            {
                阶数 = 2,
                名称 = "岩石灵髓",
                介绍 = "岩石矿层深处孕育的灵髓，质地坚硬，是寻常矿工赖以糊口的矿料。",
                价格 = 500f,
            }
        },
        {
            3, new 灵矿配置
            {
                阶数 = 3,
                名称 = "赤铜灵砂",
                介绍 = "赤铜矿层伴生的灵砂，色泽赤红如火，磨碎后可炼器，矿市之中颇为抢手。",
                价格 = 2000f,
            }
        },
        {
            4, new 灵矿配置
            {
                阶数 = 4,
                名称 = "玄铁灵矿",
                介绍 = "玄铁深层所出的灵矿，沉重异常，是打造中品法器的上佳材料。",
                价格 = 10000f,
            }
        },
        {
            5, new 灵矿配置
            {
                阶数 = 5,
                名称 = "金玉灵精",
                介绍 = "金玉灵层中灵气凝聚而成的精华，温润生辉，多为世家争相囤积之物。",
                价格 = 50000f,
            }
        },
        {
            6, new 灵矿配置
            {
                阶数 = 6,
                名称 = "紫晶幻髓",
                介绍 = "紫晶幻层独有的幻髓，流光变幻不定，是炼制幻术法宝与高阶阵盘的珍材。",
                价格 = 300000f,
            }
        },
        {
            7, new 灵矿配置
            {
                阶数 = 7,
                名称 = "地火熔晶",
                介绍 = "地火熔层经万年地火淬炼而成的熔晶，内蕴地火之力，唯有大能方能开采。",
                价格 = 1500000f,
            }
        },
        {
            8, new 灵矿配置
            {
                阶数 = 8,
                名称 = "深渊暗金",
                介绍 = "深渊暗层独有的暗金，不反光、不显灵，却沉重如岳，矿工称之为\"哑金\"。",
                价格 = 8000000f,
            }
        },
        {
            9, new 灵矿配置
            {
                阶数 = 9,
                名称 = "归墟混元石",
                介绍 = "归墟混元层中混元之气凝结而成的奇石，纵是仙门大宗也视之为镇派之宝。",
                价格 = 40000000f,
            }
        },
        {
            10, new 灵矿配置
            {
                阶数 = 10,
                名称 = "太初本源晶",
                介绍 = "太初本源层的最深处，天地未开时的一缕本源之力凝成此晶，得之可窥大道。",
                价格 = 200000000f,
            }
        },
    };

    public static float 基础挖宝箱年数 = 0.2f;
    public static float 基础每道年固定收益 = 3000;
    public static float 基础每道年挖掘米数 = 80;
    public static float 基础每道年增加经验 = 100;
    public static float 随机最小区间 = 0.7f;//矿工
    public static float 随机最大区间 = 1.3f;
    public static float 装备随机最小区间 = 0.65f;//装备
    public static float 装备随机最大区间 = 1.35f;
    public static float 其余矿工倍数 = 2f;
    public static float 均衡矿工倍数 = 1.25f;
    public static float 词条概率 = 15;

    public static Dictionary<int, float> 土层挖宝时间倍数 = new Dictionary<int, float>()
    {
        { 1, 1 },
        { 2, 2 },
        { 3, 4f },
        { 4, 6f },
        { 5, 8 },
        { 6, 10f },
        { 7, 13f },
        { 8, 16f },
        { 9, 20f },
        { 10, 25f },
    };

public static List<string> 矿工名称List = new List<string>()
{
    // ===== 100 个两字 =====
    "凌寒", "萧然", "叶尘", "顾北", "沈墨", "陆玄", "楚风", "江澈", "林渊", "苏夜",
    "秦朗", "白羽", "洛衡", "云策", "谢珩", "韩煜", "温岐", "宋澜", "裴晏", "卫峥",
    "许沧", "方朔", "程砚", "邵陵", "唐渡", "傅霄", "蒋陌", "杜衡", "阮溪", "魏然",
    "齐曜", "尹川", "霍青", "孟迟", "段誉", "卢照", "高珩", "夏岚", "钟离", "严冽",
    "贺兰", "龙渊", "凤仪", "慕容", "欧阳", "司马", "上官", "诸葛", "东方", "独孤",
    "南宫", "西门", "轩辕", "公孙", "令狐", "皇甫", "尉迟", "长孙", "宇文", "司徒",
    "申屠", "太史", "端木", "百里", "呼延", "东郭", "南门", "北堂", "西陵", "中行",
    "澹台", "公冶", "宗政", "濮阳", "淳于", "单于", "赫连", "拓跋", "鲜于", "闾丘",
    "子车", "颛孙", "巫马", "公西", "漆雕", "乐正", "壤驷", "公良", "宰父", "谷梁",
    "晋楚", "闫法", "汝鄢", "涂钦", "段干", "南荣", "第五", "微生", "羊舌", "梁丘",

    // ===== 300 个三字 =====
    "顾北辰", "叶孤城", "陆沉舟", "萧无涯", "沈青崖", "楚云飞", "江照影", "林听风", "苏望舒", "秦关月",
    "白泽川", "叶凡", "云中鹤", "谢仙客", "韩非子", "温故知", "宋玉书", "裴航远", "卫庄生", "许由心",
    "方外士", "程门雪", "邵平瓜", "唐突西", "傅说岩", "蒋干云", "韩立", "阮籍啸", "魏武鞭", "齐物论",
    "尹喜关", "霍去病", "孟尝君", "段玉裁", "卢仝茶", "高渐离", "夏禹王", "钟馗剑", "严光钓", "贺铸词",
    "龙且勇", "凤雏才", "慕白首", "欧冶子", "司南指", "上善水", "诸健行", "东君令", "独钓雪", "南星耀",
    "西子湖", "轩窗月", "公瑾瑾", "令仪容", "皇舆图", "尉缭子", "长庚星", "宇文化", "司晨鸡", "申生孝",
    "太清境", "端方士", "百川海", "呼风雀", "东篱菊", "南山寿", "北冥鱼", "西昆玉", "中流柱", "澹泊志",
    "公明灯", "宗元柳", "濮上音", "淳风朴", "单骑走", "赫曦光", "拓荒牛", "鲜克有", "闾巷深", "子衿青",
    "颛顼帝", "端居正", "巫山云", "公休沐", "漆园吏", "乐天派", "壤父歌", "公输巧", "宰予昼", "谷雨茶",
    "晋阳城", "闫闾里", "汝南月", "涂山氏", "段桥柳", "东野旷", "南华经", "第五伦", "微之诗", "羊角风",
    "梁父吟", "左思赋", "东阿王", "西蜀道", "南浦云", "北固楼", "夏口渡", "万石君", "闻韶乐", "赫日明",
    "皇天厚", "澹然心", "公田禾", "公度尺", "宗周礼", "濮水钓", "淳朴风", "单父琴", "太和春", "申白辩",
    "公沙穆", "仲尼师", "钟山雨", "长卿赋", "宇内清", "司农谷", "鲜卑骑", "空同山", "闾阎扑", "子产仁",
    "亓官礼", "司城守", "仉氏训", "子渊乐", "颛民安", "端直行", "巫咸卜", "公叔文", "漆身吞", "乐正音",
    "壤土沃", "公若愚", "拓落志", "夹谷会", "宰国政", "谷口耕", "段氏礼", "百里奚", "东胡马", "南越王",
    "呼韩邪", "归雁门", "羊续悬", "微子启", "梁鸿案", "左慈术", "东皇太", "西王母", "南伯子", "公玉带",
    "公祖句", "公夏首", "南史笔", "北史书", "东史简", "西史册", "南燕王", "北燕王", "东燕王", "西燕王",
    "南郑伯", "北郑伯", "东郑伯", "西郑伯", "上郑伯", "下郑伯", "左郑伯", "右郑伯", "前郑伯", "后郑伯",
    "太祝祷", "太史书", "太傅训", "仲父言", "叔父教", "季父诲", "孟父训", "公父语", "王父命", "长父令",
    "宇文泰", "慕容冲", "独孤信", "南宫适", "东方朔", "西门豹", "轩辕辙", "令狐楚", "凌虚子", "萧逸才",
    "叶擎天", "顾瞻前", "沈潜渊", "陆游诗", "楚辞章", "江淹笔", "林逋梅", "苏武魂", "秦观词", "白起兵",
    "洛滨赋", "云台将", "谢安棋", "韩愈文", "温峤玉", "宋慈案", "裴度印", "卫青骑", "许逊剑", "方腊旗",
    "程颐理", "邵雍数", "唐寅画", "傅山医", "蒋琬才", "杜牧诗", "阮咸琴", "魏征谏", "齐桓霸", "尹文辩",
    "霍光辅", "孟轲仁", "段颎将", "卢植儒", "高适诗", "夏竦谋", "钟繇书", "严助策", "贺循礼", "龙城将",
    "凤翔舞", "慕荣华", "欧鹭盟", "司牧守", "上宫雅", "诸冯耕", "东陵瓜", "独步天", "南冠客", "西冷印",
    "轩冕贵", "公车书", "令名远", "皇路清", "尉候望", "长亭晚", "宇文化", "司契信", "申旦明", "太初元",
    "端冕正", "百越地", "呼卢喝", "东作耕", "南讹化", "北朔雪", "西成收", "中正衡", "澹荡风", "公庭断",
    "宗匠手", "濮达道", "淳厚德", "单阏岁", "赫怒威", "拓提山", "鲜食味", "闾左居", "子墨守", "颛蒙开",
    "端策谋", "巫祝祷", "公族亲", "漆书经", "乐职守", "壤歌谣", "公忠义", "宰木拱", "谷风清", "晋贤士",
    "闫闾门", "汝坟诗", "涂轨正", "段干木", "东郭履", "南郭竽", "第五伦", "微生高", "凌霜剑", "萧瑟秋",

    // ===== 100 个四字 =====
    "凌寒傲雪", "萧然物外", "叶尘不染", "顾北望南", "沈墨成川", "陆玄问道", "楚风拂柳", "江澈见底", "林渊听泉", "苏夜观星",
    "秦朗照月", "白羽凌空", "洛衡持正", "云策千里", "谢珩鸣玉", "韩煜生辉", "温岐守拙", "宋澜观海", "裴晏临风", "卫峥立雪",
    "许沧踏浪", "方朔偷桃", "程砚磨墨", "邵陵怀古", "唐渡横舟", "傅霄冲汉", "蒋陌寻幽", "杜衡采芝", "阮溪钓月", "魏然独立",
    "齐曜东方", "尹川赴海", "霍青踏岳", "孟迟待旦", "段誉凌波", "卢照邻家", "高珩击磬", "夏岚出岫", "钟离抱朴", "严冽凝霜",
    "贺兰牧马", "龙渊藏剑", "凤仪栖梧", "慕容复国", "欧阳修文", "司马长卿", "上官婉儿", "诸葛观星", "东方既白", "独孤求败",
    "南宫问天", "西门吹雪", "轩辕黄帝", "公孙大娘", "令狐冲虚", "皇甫嵩岳", "尉迟敬德", "长孙无忌", "宇文成都", "司徒空明",
    "申屠裂石", "太史公书", "端木遗风", "百里挑一", "呼延灼灼", "东郭先生", "南门守正", "北堂萱草", "西陵松柏", "中行说客",
    "澹台灭明", "公冶长鸣", "宗政怀远", "濮阳兴雨", "淳于缇萦", "单于射雕", "赫连勃勃", "拓跋珪璋", "鲜于仲通", "闾丘避世",
    "子车奄息", "颛孙师儒", "巫马施仁", "公西赤诚", "漆雕开明", "乐正子春", "壤驷赤心", "公良孺子", "宰父守约", "谷梁赤文"
};

public static 宝物属性 当前总宝物属性 => Get当前宝物属性();
public static float 星星加成 = 10;
public static float 月亮加成 = 80;
public static float 太阳加成 = 600;
public static float 钻石加成 = 5000;

public static float Get星级加成(int 星级)
{
    功法星级 功法星级 = 功法Config.Get功法星级(星级);
    float value = 0;
    value += 钻石加成 * 功法星级.钻石;
    value += 太阳加成 * 功法星级.太阳;
    value += 月亮加成 * 功法星级.月亮;
    value += 星星加成 * 功法星级.星星;
    return  value;
}

public static float Get矿工挖宝箱时间(矿工 矿工)
{
    var 属性 = Get矿工最终四维属性(矿工);
    return 基础挖宝箱年数*土层挖宝时间倍数[(int)Get当前层()] / (1f + 属性.挖宝时间 / 100f);
}
public static float Get矿工每道年增加经验(矿工 矿工)
{
    var 属性 = Get矿工最终四维属性(矿工);
    return 基础每道年增加经验 * (1f + 属性.成长速度 / 100f);
}
public static void 矿工挖宝()
{
    var 宝箱概率 = 宝箱品质概率配置[PlayerData.S.矿洞宝箱品质概率等级];
    float random = Random.Range(0, 100f);
    if (random < 宝箱概率.宝箱概率[2])
    {
        PlayerData.S.Set宝箱数量(宝箱品质.至尊, PlayerData.S.Get宝箱数量(宝箱品质.至尊)+1);
    }else if (random < 宝箱概率.宝箱概率[2] + 宝箱概率.宝箱概率[1])
    {
        PlayerData.S.Set宝箱数量(宝箱品质.卓越, PlayerData.S.Get宝箱数量(宝箱品质.卓越)+1);
    }
    else
    {
        PlayerData.S.Set宝箱数量(宝箱品质.普通, PlayerData.S.Get宝箱数量(宝箱品质.普通)+1);
    }
}
public static 宝物属性 Get当前宝物属性()
{
    宝物属性 宝物属性 = new 宝物属性();
    foreach (var item in PlayerData.S.当前宝物)
    {
        if (item.Value != null && item.Value.宝物Type != 宝物Type.None)
        {
            switch (item.Value.宝物Type)
            {
                case 宝物Type.加挖掘速度:
                    宝物属性.加挖掘速度+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.加固定收益:
                    宝物属性.加固定收益+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.加挖宝速度:
                    宝物属性.加挖宝速度+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.加成长速度:
                    宝物属性.加成长速度+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.加秀灵矿工成长速度:
                    宝物属性.加秀灵矿工成长速度+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.加多宝矿工挖宝时间:
                    宝物属性.加多宝矿工挖宝时间+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.加守脉矿工固定收益:
                    宝物属性.加守脉矿工固定收益+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.加疾行矿工挖掘速度:
                    宝物属性.加疾行矿工挖掘速度+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.挖宝概率两个白:
                    宝物属性.挖宝概率两个白+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.灵矿价格上涨:
                    宝物属性.灵矿价格上涨+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.装备效果:
                    宝物属性.装备效果+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.刷新价格降低:
                    宝物属性.刷新价格降低+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.装备分解增多:
                    宝物属性.装备分解增多+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.解雇增多:
                    宝物属性.解雇增多+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.招募价格:
                    宝物属性.招募价格+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.等级效果:
                    宝物属性.等级效果+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
                case 宝物Type.升星效果:
                    宝物属性.升星效果+=Get宝物属性(item.Value.宝物Type,item.Value.QualityType)*(1f+PlayerData.S.宝物佩戴格子等级[item.Key]/100f);
                    break;
            }
        }
    }

    return 宝物属性;
}
public static string Get矿工名称(矿工类型 矿工类型)
{
    if (矿工类型 != 矿工类型.秀灵矿工)
    {
        return 矿工名称List[Random.Range(0,矿工名称List.Count)];
    }
    else
    {
        return 道场Config.女供奉名List[Random.Range(0, 道场Config.女供奉名List.Count)];
    }
}
public static 矿工 生成招募矿工(矿工类型 矿工类型, int 阶数, QualityType qualityType)
    {
        矿工 矿工 = new 矿工();
        矿工.name = 矿工类型string[矿工类型];
        矿工.QualityType = qualityType;
        List<矿工词条类型> 矿工词条 = new List<矿工词条类型>();
        for (int i = 0; i < 3; i++)
        {
            if (Random.Range(0f, 100f) < 词条概率)
            {
                矿工词条.Add((矿工词条类型)Random.Range(1,5));
            }
        }
        矿工.词条列表 = 矿工词条;
        四维属性 基础四维 = new 四维属性();
        基础四维.挖掘速度=矿工阶数基础四维属性[阶数].挖掘速度;
        基础四维.挖宝时间=矿工阶数基础四维属性[阶数].挖宝时间;
        基础四维.成长速度=矿工阶数基础四维属性[阶数].成长速度;
        基础四维.固定收益=矿工阶数基础四维属性[阶数].固定收益;
        float 词条挖掘速度 = 0;
        float 词条固定收益 = 0;
        float 词条挖宝速度 = 0;
        float 词条成长速度 = 0;
        foreach (var item in 矿工词条)
        {
            switch (item)
            {
                case 矿工词条类型.百分比加挖掘速度:
                    词条挖掘速度+= Get矿工词条属性(item, qualityType);
                    break;
                case 矿工词条类型.百分比加固定收益:
                    词条固定收益+= Get矿工词条属性(item, qualityType);
                    break;
                case 矿工词条类型.百分比加挖宝速度:
                    词条挖宝速度+= Get矿工词条属性(item, qualityType);
                    break;
                case 矿工词条类型.百分比加成长速度:
                    词条成长速度+= Get矿工词条属性(item, qualityType);
                    break;
            }
        }
        基础四维.挖掘速度 *= (1f+词条挖掘速度/100f);
        基础四维.固定收益 *= (1f+词条固定收益/100f);
        基础四维.挖宝时间 *= (1f+词条挖宝速度/100f);
        基础四维.成长速度 *= (1f+词条成长速度/100f);
        
        基础四维.固定收益 *= Random.Range(随机最小区间, 随机最大区间);
        基础四维.成长速度 *= Random.Range(随机最小区间, 随机最大区间);
        基础四维.挖宝时间 *= Random.Range(随机最小区间, 随机最大区间);
        基础四维.挖掘速度 *= Random.Range(随机最小区间, 随机最大区间);
        switch (矿工类型)
        {
            case 矿工类型.全脉矿工:
                基础四维.固定收益 *= 均衡矿工倍数;
                基础四维.成长速度 *= 均衡矿工倍数;
                基础四维.挖宝时间 *= 均衡矿工倍数;
                基础四维.挖掘速度 *= 均衡矿工倍数;
                break;
            case 矿工类型.多宝矿工:
                基础四维.挖宝时间 *= 其余矿工倍数;
                break;
            case 矿工类型.守脉矿工:
                基础四维.固定收益 *= 其余矿工倍数;
                break;
            case 矿工类型.疾行矿工:
                基础四维.挖掘速度 *= 其余矿工倍数;
                break;
            case 矿工类型.秀灵矿工:
                基础四维.成长速度 *= 其余矿工倍数;
                break;
        }
        switch (qualityType)
        {
            case QualityType.地品:
                基础四维.固定收益 *= 品质倍率[1];
                基础四维.成长速度 *= 品质倍率[1];
                基础四维.挖宝时间 *= 品质倍率[1];
                基础四维.挖掘速度 *= 品质倍率[1];
                break;
            case QualityType.宇品:
                基础四维.固定收益 *= 品质倍率[2];
                基础四维.成长速度 *= 品质倍率[2];
                基础四维.挖宝时间 *= 品质倍率[2];
                基础四维.挖掘速度 *= 品质倍率[2];
                break;
            case QualityType.洪品:
                基础四维.固定收益 *= 品质倍率[3];
                基础四维.成长速度 *= 品质倍率[3];
                基础四维.挖宝时间 *= 品质倍率[3];
                基础四维.挖掘速度 *= 品质倍率[3];
                break;
            case QualityType.荒品:
                基础四维.固定收益 *= 品质倍率[4];
                基础四维.成长速度 *= 品质倍率[4];
                基础四维.挖宝时间 *= 品质倍率[4];
                基础四维.挖掘速度 *= 品质倍率[4];
                break;
        }

        矿工.基础四维 = 基础四维;
        矿工.等级 = 1;
        矿工.护手 = null;
        矿工.星级 = 0;
        矿工.矿工类型 = 矿工类型;
        矿工.经验 = 0;
        矿工.稿子 = null;
        矿工.罗盘 = null;
        矿工.衣服 = null;
        矿工.阶数 = 阶数;
        矿工.name = 矿工类型string[矿工类型];
        return 矿工;
    }

    
    public static float 无暇倍率 = 2;

    
    public static 矿工装备 生成矿工装备(int 阶数, QualityType qualityType)
    {
        矿工装备 矿工装备 = new 矿工装备();
        矿工装备.QualityType = qualityType;
        矿工装备.阶数 = 阶数;
        矿工装备.矿工装备Type = (矿工装备Type)Random.Range(1, 5);
        // 复制一份配置值，避免随机加成直接改到静态配置表
        四维属性 配置四维 = 装备四维属性[阶数];
        四维属性 基础四维属性 = new 四维属性()
        {
            挖掘速度 = 配置四维.挖掘速度,
            固定收益 = 配置四维.固定收益,
            挖宝时间 = 配置四维.挖宝时间,
            成长速度 = 配置四维.成长速度,
        };
        bool 挖掘速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 成长速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 挖宝速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 固定收益无暇 = Random.Range(0f, 100f) < 1f;
        if (!挖掘速度无暇) 基础四维属性.挖掘速度 *= Random.Range(装备随机最小区间, 装备随机最大区间);
        if (!挖宝速度无暇) 基础四维属性.挖宝时间 *= Random.Range(装备随机最小区间, 装备随机最大区间);
        if (!成长速度无暇) 基础四维属性.成长速度 *= Random.Range(装备随机最小区间, 装备随机最大区间);
        if (!固定收益无暇) 基础四维属性.固定收益 *= Random.Range(装备随机最小区间, 装备随机最大区间);
        switch (qualityType)
        {
            case QualityType.地品:
                基础四维属性.挖掘速度 *= 品质倍率[1];
                基础四维属性.挖宝时间 *= 品质倍率[1];
                基础四维属性.成长速度 *= 品质倍率[1];
                基础四维属性.固定收益 *= 品质倍率[1];
                break;
            case QualityType.宇品:
                基础四维属性.挖掘速度 *= 品质倍率[2];
                基础四维属性.挖宝时间 *= 品质倍率[2];
                基础四维属性.成长速度 *= 品质倍率[2];
                基础四维属性.固定收益 *= 品质倍率[2];
                break;
            case QualityType.洪品:
                基础四维属性.挖掘速度 *= 品质倍率[3];
                基础四维属性.挖宝时间 *= 品质倍率[3];
                基础四维属性.成长速度 *= 品质倍率[3];
                基础四维属性.固定收益 *= 品质倍率[3];
                break;
            case QualityType.荒品:
                基础四维属性.挖掘速度 *= 品质倍率[4];
                基础四维属性.挖宝时间 *= 品质倍率[4];
                基础四维属性.成长速度 *= 品质倍率[4];
                基础四维属性.固定收益 *= 品质倍率[4];
                break;
        }
        if (挖掘速度无暇) 基础四维属性.挖掘速度 *= 无暇倍率;
        if (成长速度无暇) 基础四维属性.成长速度 *= 无暇倍率;
        if (固定收益无暇) 基础四维属性.固定收益 *= 无暇倍率;
        if (挖宝速度无暇) 基础四维属性.挖宝时间 *= 无暇倍率;
        矿工装备.固定收益无暇 = 固定收益无暇;
        矿工装备.成长速度无暇 = 成长速度无暇;
        矿工装备.挖掘速度无暇 = 挖掘速度无暇;
        矿工装备.挖宝时间无暇 = 挖宝速度无暇;
        矿工装备.基础四维 = 基础四维属性;
        return 矿工装备;
    }

    public static 四维属性 四维属性相加(四维属性 四维属性1, 四维属性 四维属性2)
    {
        四维属性 四维属性 = new 四维属性();
        四维属性.挖掘速度 = 四维属性1.挖掘速度 + 四维属性2.挖掘速度;
        四维属性.固定收益 = 四维属性1.固定收益 + 四维属性2.固定收益;
        四维属性.挖宝时间 = 四维属性1.挖宝时间 + 四维属性2.挖宝时间;
        四维属性.成长速度 = 四维属性1.成长速度 + 四维属性2.成长速度;
        return 四维属性;
    }
    public static 四维属性 Get矿工最终四维属性(矿工 矿工)
    {
        四维属性 基础四维 = 矿工.基础四维;
        四维属性 装备四维属性 = new 四维属性();
        if (矿工.护手 != null) 装备四维属性 = 四维属性相加(装备四维属性,矿工.护手.基础四维);
        if (矿工.罗盘 != null) 装备四维属性 = 四维属性相加(装备四维属性,矿工.罗盘.基础四维);
        if (矿工.衣服 != null) 装备四维属性 = 四维属性相加(装备四维属性,矿工.衣服.基础四维);
        if (矿工.稿子 != null) 装备四维属性 = 四维属性相加(装备四维属性,矿工.稿子.基础四维);
        装备四维属性.挖掘速度 *= (1f + 当前总宝物属性.装备效果 / 100f);
        装备四维属性.成长速度 *= (1f + 当前总宝物属性.装备效果 / 100f);
        装备四维属性.固定收益 *= (1f + 当前总宝物属性.装备效果 / 100f);
        装备四维属性.挖宝时间 *= (1f + 当前总宝物属性.装备效果 / 100f);
        基础四维=四维属性相加(基础四维,装备四维属性);
        基础四维.挖掘速度*= (1f + 当前总宝物属性.加挖掘速度 / 100f);
        基础四维.固定收益*= (1f + 当前总宝物属性.加固定收益 / 100f);
        基础四维.成长速度*= (1f + 当前总宝物属性.加成长速度 / 100f);
        基础四维.挖宝时间*= (1f + 当前总宝物属性.加挖宝速度 / 100f);
        switch (矿工.矿工类型)
        {
            case 矿工类型.多宝矿工:
                基础四维.挖宝时间*= (1f + 当前总宝物属性.加多宝矿工挖宝时间 / 100f);
                break;
            case 矿工类型.秀灵矿工:
                基础四维.成长速度*= (1f + 当前总宝物属性.加秀灵矿工成长速度 / 100f);
                break;
            case 矿工类型.守脉矿工:
                基础四维.固定收益*= (1f + 当前总宝物属性.加守脉矿工固定收益 / 100f);
                break;
            case 矿工类型.疾行矿工:
                基础四维.挖掘速度*= (1f + 当前总宝物属性.加疾行矿工挖掘速度 / 100f);
                break;
        }
        基础四维.挖掘速度 *= 矿工等级挖掘固定倍率表[矿工.等级]*(1f+当前总宝物属性.等级效果/100f);
        基础四维.固定收益 *= 矿工等级挖掘固定倍率表[矿工.等级]*(1f+当前总宝物属性.等级效果/100f);
        
        基础四维.挖掘速度 *=(1f+Get星级加成(矿工.星级)/100f*(1f+当前总宝物属性.升星效果/100f));
        基础四维.固定收益 *=(1f+Get星级加成(矿工.星级)/100f*(1f+当前总宝物属性.升星效果/100f));

        
        return 基础四维;
    }

    public static float Get总挖掘速度()
    {
        float 挖掘速度 = 0;
        foreach (var item in PlayerData.S.矿工列表)
        {
            挖掘速度+=基础每道年挖掘米数 *(1f+Get矿工最终四维属性(item).挖掘速度/100f);
        }

        return 挖掘速度;
    }
    
    public static float Get总固定收益()
    {
        float 固定收益 = 0;
        foreach (var item in PlayerData.S.矿工列表)
        {
            固定收益+=基础每道年固定收益 *(1f+Get矿工最终四维属性(item).固定收益/100f);
        }

        return 固定收益;
    }
    public static List<float> 普通宝箱品质概率 = new List<float>() { 80, 20, 0, 0, 0 };
    public static List<float> 卓越宝箱品质概率 = new List<float>() { 17, 60, 20, 3, 0 };
    public static List<float> 至尊宝箱品质概率 = new List<float>() { 0, 0, 89, 10, 1 };


    public static List<float> 品质倍率 = new List<float>() { 1, 1.2f, 1.6f, 2.5f, 5f };

    public static List<float> 装备挖掘速度品质倍率 = new List<float>() { 1, 1.2f, 1.6f, 2.5f, 5f };
    public static List<float> 装备固定收益品质倍率 = new List<float>() { 1, 1.2f, 1.6f, 2.5f, 5f };
    public static List<float> 装备成长速度品质倍率 = new List<float>() { 1, 1.1f, 1.3f, 1.5f, 2f };
    public static List<float> 装备挖宝速度品质倍率 = new List<float>() { 1, 1.1f, 1.3f, 1.5f, 2f };

  

    public static string Get装备名称(矿工装备Type type, int 阶数)
    {
        if (type == 矿工装备Type.None || 阶数 <= 0)
            return string.Empty;

        // 每种装备每一阶的独特名称，索引 = 阶数（1~10 阶）
        string[] 名称表;
        switch (type)
        {
            case 矿工装备Type.稿子:
                名称表 = new[]
                {
                    "", // 0 阶占位
                    "锈铁镐", // 1
                    "粗钢镐", // 2
                    "玄铁镐", // 3
                    "寒晶镐", // 4
                    "灵银镐", // 5
                    "赤炎镐", // 6
                    "星陨镐", // 7
                    "紫霄破岳镐", // 8
                    "太虚开天镐", // 9
                    "混沌辟地镐", // 10
                };
                break;

            case 矿工装备Type.衣服:
                名称表 = new[]
                {
                    "",
                    "粗布矿衣", // 1
                    "牛皮矿袍", // 2
                    "玄铁矿甲", // 3
                    "寒晶矿袍", // 4
                    "灵银法袍", // 5
                    "赤炎矿衣", // 6
                    "星陨战袍", // 7
                    "紫霄灵甲", // 8
                    "太虚道袍", // 9
                    "混沌不灭衣", // 10
                };
                break;

            case 矿工装备Type.护手:
                名称表 = new[]
                {
                    "",
                    "麻布护手", // 1
                    "皮革护手", // 2
                    "玄铁护手", // 3
                    "寒晶护手", // 4
                    "灵银护手", // 5
                    "赤炎护手", // 6
                    "星陨护手", // 7
                    "紫霄灵纹护手", // 8
                    "太虚缚龙护手", // 9
                    "混沌擒天护手", // 10
                };
                break;

            case 矿工装备Type.罗盘:
                名称表 = new[]
                {
                    "",
                    "木制寻脉盘", // 1
                    "铜制寻脉盘", // 2
                    "玄铁定脉盘", // 3
                    "寒晶探脉盘", // 4
                    "灵银寻龙盘", // 5
                    "赤炎辨脉盘", // 6
                    "星陨窥脉盘", // 7
                    "紫霄通天盘", // 8
                    "太虚定乾坤盘", // 9
                    "混沌衍天盘", // 10
                };
                break;

            default:
                return string.Empty;
        }

        if (阶数 >= 名称表.Length)
            return 名称表[名称表.Length - 1]; // 超出上限取最高阶

        return 名称表[阶数];
    }
public static string Get装备介绍(矿工装备Type type, int 阶数)
{
    if (type == 矿工装备Type.None || 阶数 <= 0)
        return string.Empty;

    // 每种装备每一阶的独特介绍，索引 = 阶数（1~10 阶）
    string[] 介绍表;
    switch (type)
    {
        case 矿工装备Type.稿子:
            介绍表 = new[]
            {
                "", // 0 阶占位
                "一把锈迹斑斑的铁镐，勉强能敲开浅层矿脉，是每个矿工起步的伙伴。", // 1
                "粗钢锻造的矿镐，刃口结实耐用，足以应付常见的岩石与矿层。", // 2
                "玄铁打造的矿镐，沉重而锋利，破岩如切豆腐，深井作业也不在话下。", // 3
                "以寒晶为刃的矿镐，镐身透着寒气，敲击时能震裂坚硬矿脉。", // 4
                "灵银铸成的矿镐，隐隐有灵光流转，能感应地下矿脉的走向。", // 5
                "赤炎矿镐，镐头炽热如焰，一击可熔开顽固矿层。", // 6
                "星陨矿镐，以天外陨铁锻造，挥动时有星辉洒落，开山裂石。", // 7
                "紫霄破岳镐，紫气缠绕，一镐落下可撼动山岳，是宗师级矿工的象征。", // 8
                "太虚开天镐，镐身似有虚空之力，一挥便可开辟天地，掘穿万丈岩层。", // 9
                "混沌辟地镐，传说中开天辟地之器，握于手中，山河矿脉皆可一念而破。", // 10
            };
            break;

        case 矿工装备Type.衣服:
            介绍表 = new[]
            {
                "",
                "粗布缝制的矿衣，能挡些尘土碎石，聊胜于无。", // 1
                "牛皮矿袍，耐磨抗刮，适合在碎石堆里摸爬滚打。", // 2
                "玄铁矿甲，坚硬厚重，能抵御落石与矿洞中的意外冲击。", // 3
                "寒晶矿袍，衣料沁凉，可隔绝地底酷热与矿火侵袭。", // 4
                "灵银法袍，银纹流转，能抵御矿脉中溢出的浊气。", // 5
                "赤炎矿衣，衣上隐有火纹，可抗高温与熔岩热浪。", // 6
                "星陨战袍，陨铁丝织成，坚韧异常，星辉护体。", // 7
                "紫霄灵甲，紫气护身，能挡下深层矿洞中的灵气冲击。", // 8
                "太虚道袍，衣袂飘飘却坚不可摧，虚空之力护住周身。", // 9
                "混沌不灭衣，传说穿之可避万劫，矿洞崩塌亦难伤分毫。", // 10
            };
            break;

        case 矿工装备Type.护手:
            介绍表 = new[]
            {
                "",
                "麻布护手，简单裹住双手，防止磨破皮肉。", // 1
                "皮革护手，柔韧贴合，握镐时更稳当。", // 2
                "玄铁护手，铁甲护指，能挡住飞溅的碎石。", // 3
                "寒晶护手，触手生凉，可缓解长时间挖矿的灼热。", // 4
                "灵银护手，灵光附于指节，挥镐时更省力。", // 5
                "赤炎护手，掌心隐有热力，握持炽热矿镐也不烫手。", // 6
                "星陨护手，陨铁打造，坚固轻巧，挥动如风。", // 7
                "紫霄灵纹护手，灵纹缠绕指间，可引导矿脉灵气。", // 8
                "太虚缚龙护手，传说能缚住地底蛟龙之力，握力惊人。", // 9
                "混沌擒天护手，一双手可擒天揽地，挖矿如探囊取物。", // 10
            };
            break;

        case 矿工装备Type.罗盘:
            介绍表 = new[]
            {
                "",
                "木制寻脉盘，指针简陋，只能大概感知附近的矿脉。", // 1
                "铜制寻脉盘，刻度清晰，能较准确地指出矿脉方向。", // 2
                "玄铁定脉盘，盘身沉稳，可锁定地下矿脉的位置。", // 3
                "寒晶探脉盘，晶针灵敏，能探知深层矿脉的寒意。", // 4
                "灵银寻龙盘，银针游走如龙，善寻大矿脉。", // 5
                "赤炎辨脉盘，以热辨矿，能区分不同矿种的脉络。", // 6
                "星陨窥脉盘，借星辉窥探地脉，矿藏分布一目了然。", // 7
                "紫霄通天盘，紫气通天，可感应方圆百里的矿脉走向。", // 8
                "太虚定乾坤盘，盘转乾坤，能定地下矿脉之根本。", // 9
                "混沌衍天盘，传说可衍算天地矿藏，一盘的指引胜过千军万马。", // 10
            };
            break;

        default:
            return string.Empty;
    }

    if (阶数 >= 介绍表.Length)
        return 介绍表[介绍表.Length - 1]; // 超出上限取最高阶

    return 介绍表[阶数];
}
   

    public static float Get宝物属性(宝物Type 宝物Type, QualityType qualityType)
    {
        switch (宝物Type)
        {
            case 宝物Type.加挖掘速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 宝物Type.加固定收益:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 宝物Type.加挖宝速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 宝物Type.加成长速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 宝物Type.加秀灵矿工成长速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 20;
                    case QualityType.地品:
                        return 40;
                    case QualityType.宇品:
                        return 80;
                    case QualityType.洪品:
                        return 150;
                    case QualityType.荒品:
                        return 500;
                }

                break;

            case 宝物Type.加多宝矿工挖宝时间:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 20;
                    case QualityType.地品:
                        return 40;
                    case QualityType.宇品:
                        return 80;
                    case QualityType.洪品:
                        return 150;
                    case QualityType.荒品:
                        return 500;
                }

                break;


            case 宝物Type.加守脉矿工固定收益:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 20;
                    case QualityType.地品:
                        return 40;
                    case QualityType.宇品:
                        return 80;
                    case QualityType.洪品:
                        return 150;
                    case QualityType.荒品:
                        return 500;
                }

                break;

            case 宝物Type.加疾行矿工挖掘速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 20;
                    case QualityType.地品:
                        return 40;
                    case QualityType.宇品:
                        return 80;
                    case QualityType.洪品:
                        return 150;
                    case QualityType.荒品:
                        return 500;
                }

                break;

            case 宝物Type.挖宝概率两个白:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 3;
                    case QualityType.地品:
                        return 6;
                    case QualityType.宇品:
                        return 10;
                    case QualityType.洪品:
                        return 15;
                    case QualityType.荒品:
                        return 25;
                }

                break;

            case 宝物Type.灵矿价格上涨:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 宝物Type.装备效果:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 5;
                    case QualityType.地品:
                        return 10;
                    case QualityType.宇品:
                        return 15;
                    case QualityType.洪品:
                        return 25;
                    case QualityType.荒品:
                        return 50;
                }

                break;

            case 宝物Type.刷新价格降低:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 30;
                    case QualityType.洪品:
                        return 50;
                    case QualityType.荒品:
                        return 100;
                }

                break;

            case 宝物Type.装备分解增多:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 30;
                    case QualityType.洪品:
                        return 50;
                    case QualityType.荒品:
                        return 100;
                }

                break;

            case 宝物Type.解雇增多:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 30;
                    case QualityType.洪品:
                        return 50;
                    case QualityType.荒品:
                        return 100;
                }

                break;
            
            case 宝物Type.招募价格:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 30;
                    case QualityType.洪品:
                        return 50;
                    case QualityType.荒品:
                        return 100;
                }
                
                break;
            
            case 宝物Type.等级效果:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 30;
                    case QualityType.洪品:
                        return 50;
                    case QualityType.荒品:
                        return 100;
                }

                break;
            
            case 宝物Type.升星效果:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 30;
                    case QualityType.洪品:
                        return 50;
                    case QualityType.荒品:
                        return 100;
                }

                break;
        }

        return 0;
    }

    public static float Get矿工词条属性(矿工词条类型 矿工词条类型, QualityType qualityType)
    {
        switch (矿工词条类型)
        {
            case 矿工词条类型.百分比加挖掘速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 矿工词条类型.百分比加固定收益:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 矿工词条类型.百分比加挖宝速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;

            case 矿工词条类型.百分比加成长速度:
                switch (qualityType)
                {
                    case QualityType.黄品:
                        return 10;
                    case QualityType.地品:
                        return 20;
                    case QualityType.宇品:
                        return 40;
                    case QualityType.洪品:
                        return 80;
                    case QualityType.荒品:
                        return 200;
                }

                break;
        }

        return 0;
    }

    public static Dictionary<int, float> 矿工经验表 = new Dictionary<int, float>()
    {
        { 1, 100 },
        { 2, 200 },
        { 3, 300 },
        { 4, 400 },
        { 5, 500 },
        { 6, 600 },
        { 7, 700 },
        { 8, 800 },
        { 9, 900 },
        { 10, 1000 },
        { 11, 1300 },
        { 12, 1600 },
        { 13, 1900 },
        { 14, 2200 },
        { 15, 2500 },
        { 16, 2800 },
        { 17, 3100 },
        { 18, 3400 },
        { 19, 3700 },
        { 20, 4000 },
        { 21, 5000 },
        { 22, 6000 },
        { 23, 7000 },
        { 24, 8000 },
        { 25, 9000 },
        { 26, 10000 },
        { 27, 11000 },
        { 28, 12000 },
        { 29, 13000 },
        { 30, 14000 },
        { 31, 17000 },
        { 32, 20000 },
        { 33, 23000 },
        { 34, 26000 },
        { 35, 29000 },
        { 36, 32000 },
        { 37, 35000 },
        { 38, 38000 },
        { 39, 41000 },
        { 40, 44000 },
        { 41, 53000 },
        { 42, 62000 },
        { 43, 71000 },
        { 44, 80000 },
        { 45, 89000 },
        { 46, 98000 },
        { 47, 107000 },
        { 48, 116000 },
        { 49, 125000 },
        { 50, 134000 },
        { 51, 161000 },
        { 52, 188000 },
        { 53, 215000 },
        { 54, 242000 },
        { 55, 269000 },
        { 56, 296000 },
        { 57, 323000 },
        { 58, 350000 },
        { 59, 377000 },
        { 60, 404000 },
        { 61, 485000 },
        { 62, 566000 },
        { 63, 647000 },
        { 64, 728000 },
        { 65, 809000 },
        { 66, 890000 },
        { 67, 971000 },
        { 68, 1052000 },
        { 69, 1133000 },
        { 70, 1214000 },
        { 71, 1457000 },
        { 72, 1700000 },
        { 73, 1943000 },
        { 74, 2186000 },
        { 75, 2429000 },
        { 76, 2672000 },
        { 77, 2915000 },
        { 78, 3158000 },
        { 79, 3401000 },
        { 80, 3644000 },
        { 81, 4373000 },
        { 82, 5102000 },
        { 83, 5831000 },
        { 84, 6560000 },
        { 85, 7289000 },
        { 86, 8018000 },
        { 87, 8747000 },
        { 88, 9476000 },
        { 89, 10205000 },
        { 90, 10934000 },
        { 91, 13121000 },
        { 92, 15308000 },
        { 93, 17495000 },
        { 94, 19682000 },
        { 95, 21869000 },
        { 96, 24056000 },
        { 97, 26243000 },
        { 98, 28430000 },
        { 99, 30617000 },
        { 100, 32804000 },
        { 101, 39365000 },
        { 102, 45926000 },
        { 103, 52487000 },
        { 104, 59048000 },
        { 105, 65609000 },
        { 106, 72170000 },
        { 107, 78731000 },
        { 108, 85292000 },
        { 109, 91853000 },
        { 110, 98414000 },
        { 111, 118097000 },
        { 112, 137780000 },
        { 113, 157463000 },
        { 114, 177146000 },
        { 115, 196829000 },
        { 116, 216512000 },
        { 117, 236195000 },
        { 118, 255878000 },
        { 119, 275561000 },
        { 120, 295244000 },
        { 121, 354293000 },
        { 122, 413342000 },
        { 123, 472391000 },
        { 124, 531440000 },
        { 125, 590489000 },
        { 126, 649538000 },
        { 127, 708587000 },
        { 128, 767636000 },
        { 129, 826685000 },
        { 130, 885734000 },
        { 131, 1062785000 },
        { 132, 1239836000 },
        { 133, 1416887000 },
        { 134, 1593938000 },
        { 135, 1770989000 },
        { 136, 1948040000 },
        { 137, 2125091000 },
        { 138, 2302142000 },
        { 139, 2479193000 },
        { 140, 2656244000 },
        { 141, 3187493000 },
        { 142, 3718742000 },
        { 143, 4249991000 },
        { 144, 4781240000 },
        { 145, 5312489000 },
        { 146, 5843738000 },
        { 147, 6374987000 },
        { 148, 6906236000 },
        { 149, 7437485000 },
        { 150, 7968734000 },
    };
    

    public static float Get矿工价格(int 阶数, QualityType qualityType)
    {
        switch (qualityType)
        {
            case QualityType.黄品:
                return 矿工基础招募价格[阶数] * 矿工品质价格倍数[0]/ (1 + 当前总宝物属性.招募价格 / 100f);
            case QualityType.地品:
                return 矿工基础招募价格[阶数] * 矿工品质价格倍数[1]/ (1 + 当前总宝物属性.招募价格 / 100f);
            case QualityType.宇品:
                return 矿工基础招募价格[阶数] * 矿工品质价格倍数[2]/ (1 + 当前总宝物属性.招募价格 / 100f);
            case QualityType.洪品:
                return 矿工基础招募价格[阶数] * 矿工品质价格倍数[3]/ (1 + 当前总宝物属性.招募价格 / 100f);
            case QualityType.荒品:
                return 矿工基础招募价格[阶数] * 矿工品质价格倍数[4];
        }

        return 0;
    }
    public static List<float> 矿工品质价格倍数 = new List<float>() { 1, 2, 5, 15, 100 };

    public static float Get刷新价格(int 阶数)
    {
        return 矿工基础刷新价格[阶数] / (1 + 当前总宝物属性.刷新价格降低 / 100f);
    }
    public static Dictionary<int, float> 矿工基础刷新价格 = new Dictionary<int, float>()
    {
        { 1, 100 },
        { 2, 300 },
        { 3, 1000 },
        { 4, 3000 },
        { 5, 10000 },
        { 6, 30000 },
        { 7, 100000 },
        { 8, 300000 },
        { 9, 1000000 },
        { 10, 3000000 },
    };
    public static Dictionary<int, float> 矿工基础招募价格 = new Dictionary<int, float>()
    {
        { 1, 300 },
        { 2, 900 },
        { 3, 3000 },
        { 4, 9000 },
        { 5, 30000 },
        { 6, 90000 },
        { 7, 300000 },
        { 8, 900000 },
        { 9, 3000000 },
        { 10, 9000000 },
    };
    
    public static Dictionary<int, float> 矿工等级挖掘固定倍率表 = new Dictionary<int, float>()
    {
        { 1, 1 },
        { 2, 1.01f },
        { 3, 1.02f },
        { 4, 1.03f },
        { 5, 1.04f },
        { 6, 1.05f },
        { 7, 1.06f },
        { 8, 1.07f },
        { 9, 1.08f },
        { 10, 1.09f },
        { 11, 1.11f },
        { 12, 1.13f },
        { 13, 1.15f },
        { 14, 1.17f },
        { 15, 1.19f },
        { 16, 1.21f },
        { 17, 1.23f },
        { 18, 1.25f },
        { 19, 1.27f },
        { 20, 1.29f },
        { 21, 1.33f },
        { 22, 1.37f },
        { 23, 1.41f },
        { 24, 1.45f },
        { 25, 1.49f },
        { 26, 1.53f },
        { 27, 1.57f },
        { 28, 1.61f },
        { 29, 1.65f },
        { 30, 1.69f },
        { 31, 1.77f },
        { 32, 1.85f },
        { 33, 1.93f },
        { 34, 2.01f },
        { 35, 2.09f },
        { 36, 2.17f },
        { 37, 2.25f },
        { 38, 2.33f },
        { 39, 2.41f },
        { 40, 2.49f },
        { 41, 2.65f },
        { 42, 2.81f },
        { 43, 2.97f },
        { 44, 3.13f },
        { 45, 3.29f },
        { 46, 3.45f },
        { 47, 3.61f },
        { 48, 3.77f },
        { 49, 3.93f },
        { 50, 4.09f },
        { 51, 4.41f },
        { 52, 4.73f },
        { 53, 5.05f },
        { 54, 5.37f },
        { 55, 5.69f },
        { 56, 6.01f },
        { 57, 6.33f },
        { 58, 6.65f },
        { 59, 6.97f },
        { 60, 7.29f },
        { 61, 7.93f },
        { 62, 8.57f },
        { 63, 9.21f },
        { 64, 9.85f },
        { 65, 10.49f },
        { 66, 11.13f },
        { 67, 11.77f },
        { 68, 12.41f },
        { 69, 13.05f },
        { 70, 13.69f },
        { 71, 14.97f },
        { 72, 16.25f },
        { 73, 17.53f },
        { 74, 18.81f },
        { 75, 20.09f },
        { 76, 21.37f },
        { 77, 22.65f },
        { 78, 23.93f },
        { 79, 25.21f },
        { 80, 26.49f },
        { 81, 29.05f },
        { 82, 31.61f },
        { 83, 34.17f },
        { 84, 36.73f },
        { 85, 39.29f },
        { 86, 41.85f },
        { 87, 44.41f },
        { 88, 46.97f },
        { 89, 49.53f },
        { 90, 52.09f },
        { 91, 57.21f },
        { 92, 62.33f },
        { 93, 67.45f },
        { 94, 72.57f },
        { 95, 77.69f },
        { 96, 82.81f },
        { 97, 87.93f },
        { 98, 93.05f },
        { 99, 98.17f },
        { 100, 103.29f },
        { 101, 113.53f },
        { 102, 123.77f },
        { 103, 134.01f },
        { 104, 144.25f },
        { 105, 154.49f },
        { 106, 164.73f },
        { 107, 174.97f },
        { 108, 185.21f },
        { 109, 195.45f },
        { 110, 205.69f },
        { 111, 226.17f },
        { 112, 246.65f },
        { 113, 267.13f },
        { 114, 287.61f },
        { 115, 308.09f },
        { 116, 328.57f },
        { 117, 349.05f },
        { 118, 369.53f },
        { 119, 390.01f },
        { 120, 410.49f },
        { 121, 451.45f },
        { 122, 492.41f },
        { 123, 533.37f },
        { 124, 574.33f },
        { 125, 615.29f },
        { 126, 656.25f },
        { 127, 697.21f },
        { 128, 738.17f },
        { 129, 779.13f },
        { 130, 820.09f },
        { 131, 902.01f },
        { 132, 983.93f },
        { 133, 1065.85f },
        { 134, 1147.77f },
        { 135, 1229.69f },
        { 136, 1311.61f },
        { 137, 1393.53f },
        { 138, 1475.45f },
        { 139, 1557.37f },
        { 140, 1639.29f },
        { 141, 1803.13f },
        { 142, 1966.97f },
        { 143, 2130.81f },
        { 144, 2294.65f },
        { 145, 2458.49f },
        { 146, 2622.33f },
        { 147, 2786.17f },
        { 148, 2950.01f },
        { 149, 3113.85f },
        { 150, 3277.69f },
    };

    public static Dictionary<矿工类型, string> 矿工类型string = new Dictionary<矿工类型, string>()
    {
        { 矿工类型.多宝矿工, "多宝矿工" },
        { 矿工类型.守脉矿工, "守脉矿工" },
        { 矿工类型.疾行矿工, "疾行矿工" },
        { 矿工类型.全脉矿工, "全脉矿工" },
        { 矿工类型.秀灵矿工, "秀灵矿工" },
    };

    public static Dictionary<QualityType, string> 矿工品质string = new Dictionary<QualityType, string>()
    {
        { QualityType.黄品 ,"普通"},
        { QualityType.地品 ,"稀有"},
        { QualityType.宇品 ,"罕见"},
        { QualityType.洪品 ,"神话"},
        { QualityType.荒品 ,"永恒"},
    };

    public static Dictionary<int, 四维属性> 装备四维属性 = new Dictionary<int, 四维属性>()
    {
        { 1, new 四维属性() { 挖掘速度 = 10, 成长速度 = 10, 固定收益 = 10, 挖宝时间 = 5, } },
        { 2, new 四维属性() { 挖掘速度 = 20, 成长速度 = 15, 固定收益 = 20, 挖宝时间 = 10, } },
        { 3, new 四维属性() { 挖掘速度 = 40, 成长速度 = 25, 固定收益 = 40, 挖宝时间 = 15, } },
        { 4, new 四维属性() { 挖掘速度 = 80, 成长速度 = 50, 固定收益 = 80, 挖宝时间 = 25, } },
        { 5, new 四维属性() { 挖掘速度 = 180, 成长速度 = 100, 固定收益 = 180, 挖宝时间 = 50, } },
        { 6, new 四维属性() { 挖掘速度 = 400, 成长速度 = 200, 固定收益 = 400, 挖宝时间 = 100, } },
        { 7, new 四维属性() { 挖掘速度 = 1000, 成长速度 = 400, 固定收益 = 1000, 挖宝时间 = 200, } },
        { 8, new 四维属性() { 挖掘速度 = 2000, 成长速度 = 800, 固定收益 = 2000, 挖宝时间 = 400, } },
        { 9, new 四维属性() { 挖掘速度 = 4000, 成长速度 = 1500, 固定收益 = 4000, 挖宝时间 = 800, } },
        { 10, new 四维属性() { 挖掘速度 = 10000, 成长速度 = 3000, 固定收益 = 10000, 挖宝时间 = 1500, } },
    };
    public static Dictionary<int, 四维属性> 矿工阶数基础四维属性 = new Dictionary<int, 四维属性>()
    {
        { 1, new 四维属性() { 挖掘速度 = 30, 固定收益 = 30, 成长速度 = 20, 挖宝时间 = 10 } },
        { 2, new 四维属性() { 挖掘速度 = 70, 固定收益 = 70, 成长速度 = 40, 挖宝时间 = 20 } },
        { 3, new 四维属性() { 挖掘速度 = 160, 固定收益 = 160, 成长速度 = 80, 挖宝时间 = 40 } },
        { 4, new 四维属性() { 挖掘速度 = 350, 固定收益 = 350, 成长速度 = 150, 挖宝时间 = 80 } },
        { 5, new 四维属性() { 挖掘速度 = 800, 固定收益 = 800, 成长速度 = 300, 挖宝时间 = 150 } },
        { 6, new 四维属性() { 挖掘速度 = 1800, 固定收益 = 1800, 成长速度 = 600, 挖宝时间 = 300 } },
        { 7, new 四维属性() { 挖掘速度 = 4000, 固定收益 = 4000, 成长速度 = 1200, 挖宝时间 = 600 } },
        { 8, new 四维属性() { 挖掘速度 = 9000, 固定收益 = 9000, 成长速度 = 2500, 挖宝时间 = 1200 } },
        { 9, new 四维属性() { 挖掘速度 = 20000, 固定收益 = 20000, 成长速度 = 5000, 挖宝时间 = 2500 } },
        { 10, new 四维属性() { 挖掘速度 = 50000, 固定收益 = 50000, 成长速度 = 10000, 挖宝时间 = 5000 } },
    };

    public static Dictionary<int, 矿工人数上限配置> 矿工人数上限配置 = new Dictionary<int, 矿工人数上限配置>()
    {
        { 1, new 矿工人数上限配置() { 人数 = 1, 升级灵魂 = 1000 } },
        { 2, new 矿工人数上限配置() { 人数 = 2, 升级灵魂 = 3000 } },
        { 3, new 矿工人数上限配置() { 人数 = 3, 升级灵魂 = 6000 } },
        { 4, new 矿工人数上限配置() { 人数 = 4, 升级灵魂 = 12000 } },
        { 5, new 矿工人数上限配置() { 人数 = 5, 升级灵魂 = 20000 } },
        { 6, new 矿工人数上限配置() { 人数 = 6, 升级灵魂 = 32000 } },
        { 7, new 矿工人数上限配置() { 人数 = 7, 升级灵魂 = 50000 } },
        { 8, new 矿工人数上限配置() { 人数 = 8, 升级灵魂 = 80000 } },
        { 9, new 矿工人数上限配置() { 人数 = 9, 升级灵魂 = 120000 } },
        { 10, new 矿工人数上限配置() { 人数 = 10, 升级灵魂 = 180000 } },
        { 11, new 矿工人数上限配置() { 人数 = 11, 升级灵魂 = 260000 } },
        { 12, new 矿工人数上限配置() { 人数 = 12, 升级灵魂 = 350000 } },
        { 13, new 矿工人数上限配置() { 人数 = 13, 升级灵魂 = 550000 } },
        { 14, new 矿工人数上限配置() { 人数 = 14, 升级灵魂 = 800000 } },
        { 15, new 矿工人数上限配置() { 人数 = 15, 升级灵魂 = 1100000 } },
        { 16, new 矿工人数上限配置() { 人数 = 16, 升级灵魂 = 1500000 } },
        { 17, new 矿工人数上限配置() { 人数 = 17, 升级灵魂 = 2200000 } },
        { 18, new 矿工人数上限配置() { 人数 = 18, 升级灵魂 = 3000000 } },
        { 19, new 矿工人数上限配置() { 人数 = 19, 升级灵魂 = 4000000 } },
        { 20, new 矿工人数上限配置() { 人数 = 20, 升级灵魂 = 6000000 } },
        { 21, new 矿工人数上限配置() { 人数 = 21, 升级灵魂 = 9000000 } },
        { 22, new 矿工人数上限配置() { 人数 = 22, 升级灵魂 = 13000000 } },
        { 23, new 矿工人数上限配置() { 人数 = 23, 升级灵魂 = 20000000 } },
        { 24, new 矿工人数上限配置() { 人数 = 24, 升级灵魂 = 30000000 } },
        { 25, new 矿工人数上限配置() { 人数 = 25, 升级灵魂 = 45000000 } },
        { 26, new 矿工人数上限配置() { 人数 = 26, 升级灵魂 = 70000000 } },
        { 27, new 矿工人数上限配置() { 人数 = 27, 升级灵魂 = 100000000 } },
        { 28, new 矿工人数上限配置() { 人数 = 28, 升级灵魂 = 130000000 } },
        { 29, new 矿工人数上限配置() { 人数 = 29, 升级灵魂 = 180000000 } },
        { 30, new 矿工人数上限配置() { 人数 = 30, 升级灵魂 = 250000000 } },
        { 31, new 矿工人数上限配置() { 人数 = 31, 升级灵魂 = 350000000 } },
    };

    public static void Get宝箱()
    {
        var 概率 = 宝箱品质概率配置[PlayerData.S.矿洞宝箱品质概率等级].宝箱概率;
        float random=Random.Range(0, 100f);
        if (random < 概率[0])
        {
            PlayerData.S.宝箱Dic[宝箱品质.普通]++;
        }else if (random < 概率[1]+概率[0])
        {
            PlayerData.S.宝箱Dic[宝箱品质.卓越]++;
        }else 
            PlayerData.S.宝箱Dic[宝箱品质.至尊]++;
    }

    public static Dictionary<宝箱品质, List<float>> 开宝箱品质配置 = new Dictionary<宝箱品质, List<float>>()
    {
        { 宝箱品质.普通 ,new List<float>(){70,30,0,0,0}},
        { 宝箱品质.卓越 ,new List<float>(){0,67,30,3,0}},
        { 宝箱品质.至尊 ,new List<float>(){0,0,89,10,1}},
    };

    public static (string 名称, QualityType 品质) 开宝箱(宝箱品质 品质)
    {
        if (PlayerData.S.Get宝箱数量(品质) <= 0)
        {
            return (null, QualityType.黄品);
        }

        PlayerData.S.Set宝箱数量(品质, PlayerData.S.Get宝箱数量(品质) - 1);

        // 宝箱品质决定开出物品的品质，再决定物品类型
        QualityType 物品品质 = Roll宝箱物品品质(开宝箱品质配置[品质]);
        宝箱物品Type 物品类型 = Roll宝箱物品类型();

        // 第一层出第一阶，随当前土层提升
        int 阶数 = Mathf.Clamp((int)Get当前层(), 1, 10);

        string 名称 = string.Empty;
        switch (物品类型)
        {
            case 宝箱物品Type.灵矿:
                PlayerData.S.Set灵矿数量(阶数, 物品品质, PlayerData.S.Get灵矿数量(阶数, 物品品质) + 1);
                名称 = 灵矿配置表[阶数].名称;
                break;
            case 宝箱物品Type.装备:
                var 装备 = 生成矿工装备(阶数, 物品品质);
                PlayerData.S.矿工装备列表.Add(装备);
                名称 = Get装备名称(装备.矿工装备Type, 阶数);
                break;
            case 宝箱物品Type.宝物:
                var 随机宝物Type = (宝物Type)Random.Range(1, (int)宝物Type.升星效果 + 1);
                PlayerData.S.Set宝物数量(随机宝物Type, 物品品质,
                    PlayerData.S.Get宝物数量(随机宝物Type, 物品品质) + 1);
                名称 = 宝物名[随机宝物Type];
                break;
        }
        PlayerData.S.任务完成字典[任务Type.开宝箱] = true;
        ObserverModuleManager.S.SendEvent("刷新任务栏");
        return (名称, 物品品质);
    }

    private static QualityType Roll宝箱物品品质(List<float> 概率)
    {
        QualityType[] 品质列表 =
        {
            QualityType.黄品, QualityType.地品, QualityType.宇品, QualityType.洪品, QualityType.荒品,
        };

        float random = Random.Range(0f, 100f);
        float 累计 = 0;
        for (int i = 0; i < 品质列表.Length && i < 概率.Count; i++)
        {
            累计 += 概率[i];
            if (random < 累计) return 品质列表[i];
        }

        return QualityType.黄品;
    }

    private static 宝箱物品Type Roll宝箱物品类型()
    {
        float 总概率 = 0;
        foreach (var item in 开宝箱物品概率)
        {
            总概率 += item.Value;
        }

        float random = Random.Range(0f, 总概率);
        float 累计 = 0;
        foreach (var item in 开宝箱物品概率)
        {
            累计 += item.Value;
            if (random < 累计) return item.Key;
        }

        return 宝箱物品Type.灵矿;
    }
    public static Dictionary<宝箱物品Type, float> 开宝箱物品概率 = new Dictionary<宝箱物品Type, float>()
    {
        { 宝箱物品Type.灵矿 ,80},
        { 宝箱物品Type.装备 ,15},
        { 宝箱物品Type.宝物 ,5},
    };
    public static Dictionary<int, 宝箱品质概率配置> 宝箱品质概率配置 = new Dictionary<int, 宝箱品质概率配置>()
    {
        { 1, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 90, 10, 0 }, 升级灵魂 = 5000 } },
        { 2, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 80, 20, 0 }, 升级灵魂 = 20000 } },
        { 3, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 70, 30, 0 }, 升级灵魂 = 100000 } },
        { 4, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 60, 40, 0 }, 升级灵魂 = 500000 } },
        { 5, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 49, 50, 1 }, 升级灵魂 = 3000000 } },
        { 6, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 38, 60, 2 }, 升级灵魂 = 15000000 } },
        { 7, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 27, 70, 3 }, 升级灵魂 = 80000000 } },
        { 8, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 16, 80, 4 }, 升级灵魂 = 300000000 } },
        { 9, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 5, 90, 5 }, 升级灵魂 = 1500000000 } },
        { 10, new 宝箱品质概率配置() { 宝箱概率 = new List<float>() { 0, 94, 6 }, 升级灵魂 = 999999999999 } },
    };
    
    public static Dictionary<int, 矿工招募概率配置> 矿工招募概率配置 = new Dictionary<int, 矿工招募概率配置>()
    {
        { 1, new 矿工招募概率配置() { 招募概率 = new List<float>() { 75, 25, 0 ,0,0}, 升级灵魂 = 5000 } },
        { 2, new 矿工招募概率配置() { 招募概率 = new List<float>() { 60, 40, 0 ,0,0}, 升级灵魂 = 20000 } },
        { 3, new 矿工招募概率配置() { 招募概率 = new List<float>() { 45, 55, 10 ,0,0}, 升级灵魂 = 100000 } },
        { 4, new 矿工招募概率配置() { 招募概率 = new List<float>() { 10, 70, 20 ,0,0}, 升级灵魂 = 500000 } },
        { 5, new 矿工招募概率配置() { 招募概率 = new List<float>() { 0, 70, 30 ,0,0}, 升级灵魂 = 3000000 } },
        { 6, new 矿工招募概率配置() { 招募概率 = new List<float>() { 0, 55, 40 ,5,0}, 升级灵魂 = 15000000 } },
        { 7, new 矿工招募概率配置() { 招募概率 = new List<float>() { 0, 40, 50 ,10,0}, 升级灵魂 = 80000000 } },
        { 8, new 矿工招募概率配置() { 招募概率 = new List<float>() { 0, 25, 60 ,15,0}, 升级灵魂 = 300000000 } },
        { 9, new 矿工招募概率配置() { 招募概率 = new List<float>() { 0, 0, 79 ,20,1}, 升级灵魂 = 1500000000 } },
        { 10, new 矿工招募概率配置() { 招募概率 = new List<float>() { 0, 0, 73 ,25,2}, 升级灵魂 = 8000000000 } },
    };

    public static Dictionary<int, 矿工阶数上限配置> 矿工阶数上限配置 = new Dictionary<int, 矿工阶数上限配置>()
    {
        { 1, new 矿工阶数上限配置() { 阶数 = 1, 升级灵魂 = 5000 } },
        { 2, new 矿工阶数上限配置() { 阶数 = 2, 升级灵魂 = 20000 } },
        { 3, new 矿工阶数上限配置() { 阶数 = 3, 升级灵魂 = 100000 } },
        { 4, new 矿工阶数上限配置() { 阶数 = 4, 升级灵魂 = 500000 } },
        { 5, new 矿工阶数上限配置() { 阶数 = 5, 升级灵魂 = 3000000 } },
        { 6, new 矿工阶数上限配置() { 阶数 = 6, 升级灵魂 = 15000000 } },
        { 7, new 矿工阶数上限配置() { 阶数 = 7, 升级灵魂 = 80000000 } },
        { 8, new 矿工阶数上限配置() { 阶数 = 8, 升级灵魂 = 300000000 } },
        { 9, new 矿工阶数上限配置() { 阶数 = 9, 升级灵魂 = 1500000000 } },
        { 10, new 矿工阶数上限配置() { 阶数 = 10, 升级灵魂 = 8000000000 } },
    };
    
    public static Dictionary<int, 宝物佩戴上限配置> 宝物佩戴上限配置 = new Dictionary<int, 宝物佩戴上限配置>()
    {
        { 1, new 宝物佩戴上限配置() { 个数 = 1, 升级灵魂 = 5000 } },
        { 2, new 宝物佩戴上限配置() { 个数 = 2, 升级灵魂 = 20000 } },
        { 3, new 宝物佩戴上限配置() { 个数 = 3, 升级灵魂 = 100000 } },
        { 4, new 宝物佩戴上限配置() { 个数 = 4, 升级灵魂 = 500000 } },
        { 5, new 宝物佩戴上限配置() { 个数 = 5, 升级灵魂 = 3000000 } },
        { 6, new 宝物佩戴上限配置() { 个数 = 6, 升级灵魂 = 15000000 } },
        { 7, new 宝物佩戴上限配置() { 个数 = 7, 升级灵魂 = 80000000 } },
        { 8, new 宝物佩戴上限配置() { 个数 = 8, 升级灵魂 = 300000000 } },
        { 9, new 宝物佩戴上限配置() { 个数 = 9, 升级灵魂 = 1500000000 } },
        { 10, new 宝物佩戴上限配置() { 个数 = 10, 升级灵魂 = 8000000000 } },
    };

    public static Dictionary<土层Type, float> 土层米数 = new Dictionary<土层Type, float>()
    {
        { 土层Type.黑土浅层, 0 },
        { 土层Type.岩石矿层, 1000 },
        { 土层Type.赤铜矿层, 10000 },
        { 土层Type.玄铁深层, 100000 },
        { 土层Type.金玉灵层, 1000000 },
        { 土层Type.紫晶幻层, 20000000 },
        { 土层Type.地火熔层, 500000000 },
        { 土层Type.深渊暗层, 10000000000 },
        { 土层Type.归墟混元层,200000000000 },
        { 土层Type.太初本源层, 10000000000000 },
        { 土层Type.无量空处层, 999999999999999999 },
    };
    
    public static Dictionary<土层Type, string> 土层名称 = new Dictionary<土层Type, string>()
    {
        { 土层Type.黑土浅层, "黑土浅层"},
        { 土层Type.岩石矿层, "岩石矿层" },
        { 土层Type.赤铜矿层, "赤铜矿层" },
        { 土层Type.玄铁深层, "玄铁深层" },
        { 土层Type.金玉灵层, "金玉灵层" },
        { 土层Type.紫晶幻层, "紫晶幻层" },
        { 土层Type.地火熔层, "地火熔层" },
        { 土层Type.深渊暗层, "深渊暗层" },
        { 土层Type.归墟混元层, "归墟混元层" },
        { 土层Type.太初本源层, "太初本源层" },
    };

    public static float Get矿工升星价格(int 阶数, QualityType qualityType)
    {
        float 基础 = 基础升星碎片[阶数];
        switch (qualityType)
        {
            case QualityType.黄品:
                基础*=升星品质倍数[0];
                break;
            case QualityType.地品:
                基础*=升星品质倍数[1];
                break;
            case QualityType.宇品:
                基础*=升星品质倍数[2];
                break;
            case QualityType.洪品:
                基础*=升星品质倍数[3];
                break;
            case QualityType.荒品:
                基础*=升星品质倍数[4];
                break;
        }

        return 基础;
    }
    
    public static float Get矿工分解价格(int 阶数, QualityType qualityType)
    {
        float 基础 = 基础矿工分解碎片[阶数];
        switch (qualityType)
        {
            case QualityType.黄品:
                基础*=升星品质倍数[0];
                break;
            case QualityType.地品:
                基础*=升星品质倍数[1];
                break;
            case QualityType.宇品:
                基础*=升星品质倍数[2];
                break;
            case QualityType.洪品:
                基础*=升星品质倍数[3];
                break;
            case QualityType.荒品:
                基础*=升星品质倍数[4];
                break;
        }
        return 基础;
    }

    public static List<float> 升星品质倍数 = new List<float>() { 1,2,4,8,15};

    public static Dictionary<int, float> 基础升星碎片 = new Dictionary<int, float>()
    {
        {1,100},
        {2,300},
        {3,1000},
        {4,3000},
        {5,10000},
        {6,30000},
        {7,100000},
        {8,300000},
        {9,1000000},
        {10,3000000},
    };
    
    public static Dictionary<int, float> 基础矿工分解碎片 = new Dictionary<int, float>()
    {
        {1,30},
        {2,100},
        {3,300},
        {4,1000},
        {5,3000},
        {6,10000},
        {7,30000},
        {8,100000},
        {9,300000},
        {10,1000000},
    };


}
