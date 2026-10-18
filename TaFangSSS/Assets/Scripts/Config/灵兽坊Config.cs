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
    public float 最终伤害;
    public float 暴击伤害;
    public float 元素伤害;
}
public class 灵兽坊Config
{
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
        灵兽.阶段Type = 阶段Type.None;
        灵兽.道龄 = 0;
        float 最大资质 = 品级最大资质[qualityType] * 血脉倍数[(int)(灵兽.血脉Type - 1)];
        灵兽.最终伤害 = Random.Range(0f, 最大资质);
        灵兽.元素伤害 = Random.Range(0f, 最大资质);
        灵兽.暴击伤害 = Random.Range(0f, 最大资质);
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
        55,25,12,5,2,0.89f,0.1f,0.01f
    };

}
