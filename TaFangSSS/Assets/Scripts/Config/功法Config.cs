using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 功法Type
{
    None,
    // 战士系列
    战士白,
    战士绿,
    战士蓝,
    战士紫,
    战士粉,
    战士红,
    战士橙,
    战士彩,
    // 射手系列
    射手白,
    射手绿,
    射手蓝,
    射手紫,
    射手粉,
    射手红,
    射手橙,
    射手彩,
    // 控制系列
    控制白,
    控制绿,
    控制蓝,
    控制紫,
    控制粉,
    控制红,
    控制橙,
    控制彩,
    // 辅助系列
    辅助白,
    辅助绿,
    辅助蓝,
    辅助紫,
    辅助粉,
    辅助红,
    辅助橙,
    辅助彩,
    // 法师系列
    法师白,
    法师绿,
    法师蓝,
    法师紫,
    法师粉,
    法师红,
    法师橙,
    法师彩,
}

public enum 功法属性Type
{
    None,
    攻击距离,
    冷却缩减,
    暴击伤害,
    控制效果,
    辅助效果,
}

public class 功法属性Item
{
    public 功法属性Type 功法属性Type;
    public float count;
}

public class 功法Config
{
    public static Dictionary<功法Type, string> 功法名Dic = new Dictionary<功法Type, string>()
    {
        // 战士系列
        { 功法Type.战士白, "莽牛劲" },
        { 功法Type.战士绿, "开山诀" },
        { 功法Type.战士蓝, "碎岳拳" },
        { 功法Type.战士紫, "霸体金身" },
        { 功法Type.战士粉, "蚩尤战血" },
        { 功法Type.战士红, "刑天舞干戚" },
        { 功法Type.战士橙, "大巫真身" },
        { 功法Type.战士彩, "混沌开天经" },

        // 射手系列
        { 功法Type.射手白, "穿杨诀" },
        { 功法Type.射手绿, "逐风箭" },
        { 功法Type.射手蓝, "落星弓" },
        { 功法Type.射手紫, "破虚神眼" },
        { 功法Type.射手粉, "九日落日箭" },
        { 功法Type.射手红, "射日神弓" },
        { 功法Type.射手橙, "太阴凝光诀" },
        { 功法Type.射手彩, "天道诛仙矢" },

        // 控制系列
        { 功法Type.控制白, "缠藤术" },
        { 功法Type.控制绿, "定身咒" },
        { 功法Type.控制蓝, "画地为牢" },
        { 功法Type.控制紫, "六合锁天阵" },
        { 功法Type.控制粉, "八荒困仙阵" },
        { 功法Type.控制红, "三千烦恼丝" },
        { 功法Type.控制橙, "九幽镇魂咒" },
        { 功法Type.控制彩, "混沌囚笼" },

        // 辅助系列
        { 功法Type.辅助白, "养气诀" },
        { 功法Type.辅助绿, "济世经" },
        { 功法Type.辅助蓝, "回春功" },
        { 功法Type.辅助紫, "造化诀" },
        { 功法Type.辅助粉, "众生渡" },
        { 功法Type.辅助红, "万象回春法" },
        { 功法Type.辅助橙, "天道符箓" },
        { 功法Type.辅助彩, "无极造化决" },

        // 法师系列
        { 功法Type.法师白, "聚灵诀" },
        { 功法Type.法师绿, "凝神咒" },
        { 功法Type.法师蓝, "化元功" },
        { 功法Type.法师紫, "神念御天" },
        { 功法Type.法师粉, "万法归宗" },
        { 功法Type.法师红, "通玄经" },
        { 功法Type.法师橙, "混元道果" },
        { 功法Type.法师彩, "万法本源" },
    };

    public static Dictionary<功法Type, 功法属性Item> 功法属性Dic = new Dictionary<功法Type, 功法属性Item>()
    {
        { 功法Type.战士白, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 0.5f } },
        { 功法Type.战士绿, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 0.7f } },
        { 功法Type.战士蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 1f } },
        { 功法Type.战士紫, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 1.3f } },
        { 功法Type.战士橙, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 1.8f } },
        { 功法Type.战士粉, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 2.4f } },
        { 功法Type.战士红, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 3 } },
        { 功法Type.战士彩, new 功法属性Item() { 功法属性Type = 功法属性Type.攻击距离, count = 4 } },

        { 功法Type.法师白, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 10f } },
        { 功法Type.法师绿, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 15f } },
        { 功法Type.法师蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 25f } },
        { 功法Type.法师紫, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 40f } },
        { 功法Type.法师橙, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 70 } },
        { 功法Type.法师粉, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 110 } },
        { 功法Type.法师红, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 180 } },
        { 功法Type.法师彩, new 功法属性Item() { 功法属性Type = 功法属性Type.暴击伤害, count = 300 } },

        { 功法Type.辅助白, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 5f } },
        { 功法Type.辅助绿, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 10f } },
        { 功法Type.辅助蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 15f } },
        { 功法Type.辅助紫, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 25f } },
        { 功法Type.辅助橙, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 40f } },
        { 功法Type.辅助粉, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 60f } },
        { 功法Type.辅助红, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 90 } },
        { 功法Type.辅助彩, new 功法属性Item() { 功法属性Type = 功法属性Type.辅助效果, count = 150 } },

        { 功法Type.控制白, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 5f } },
        { 功法Type.控制绿, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 10f } },
        { 功法Type.控制蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 15f } },
        { 功法Type.控制紫, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 25f } },
        { 功法Type.控制橙, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 40f } },
        { 功法Type.控制粉, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 60f } },
        { 功法Type.控制红, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 90 } },
        { 功法Type.控制彩, new 功法属性Item() { 功法属性Type = 功法属性Type.控制效果, count = 150 } },

        { 功法Type.射手白, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 5f } },
        { 功法Type.射手绿, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 10f } },
        { 功法Type.射手蓝, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 18f } },
        { 功法Type.射手紫, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 30f } },
        { 功法Type.射手橙, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 50f } },
        { 功法Type.射手粉, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 80f } },
        { 功法Type.射手红, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 120f } },
        { 功法Type.射手彩, new 功法属性Item() { 功法属性Type = 功法属性Type.冷却缩减, count = 200f } },
    };

    public static Dictionary<QualityType, int> 传道消耗Dic = new Dictionary<QualityType, int>()
    {
        { QualityType.黄品, 100 },
        { QualityType.玄品, 300 },
        { QualityType.地品, 1000 },
        { QualityType.天品, 3000 },
        { QualityType.宇品, 10000 },
        { QualityType.宙品, 30000 },
        { QualityType.洪品, 100000 },
        { QualityType.荒品, 1000000 },
    };

    public static Dictionary<QualityType, List<float>> 传道概率Dic = new Dictionary<QualityType, List<float>>()
    {
        { QualityType.黄品, new List<float>() { 100, 0, 0, 0, 0, 0, 0, 0 } },
        { QualityType.玄品, new List<float>() { 70, 30, 0, 0, 0, 0, 0, 0 } },
        { QualityType.地品, new List<float>() { 35, 50, 25, 0, 0, 0, 0, 0 } },
        { QualityType.天品, new List<float>() { 10, 30, 40, 20, 0, 0, 0, 0 } },
        { QualityType.宇品, new List<float>() { 0, 15, 40, 30, 15, 0, 0, 0 } },
        { QualityType.宙品, new List<float>() { 0, 10, 25, 30, 25, 10, 0, 0 } },
        { QualityType.洪品, new List<float>() { 0, 0, 10, 25, 40, 20, 5, 0 } },
        { QualityType.荒品, new List<float>() { 100, 0, 0, 14, 40, 30, 15, 1 } },
    };

    public static 功法Type Get功法(QualityType qualityType)
    {
        switch (qualityType)
        {
            case QualityType.黄品:
                int random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士白;
                    case 2: return 功法Type.法师白;
                    case 3: return 功法Type.辅助白;
                    case 4: return 功法Type.控制白;
                    case 5: return 功法Type.射手白;
                }

                break;

            case QualityType.玄品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士绿;
                    case 2: return 功法Type.法师绿;
                    case 3: return 功法Type.辅助绿;
                    case 4: return 功法Type.控制绿;
                    case 5: return 功法Type.射手绿;
                }

                break;

            case QualityType.地品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士蓝;
                    case 2: return 功法Type.法师蓝;
                    case 3: return 功法Type.辅助蓝;
                    case 4: return 功法Type.控制蓝;
                    case 5: return 功法Type.射手蓝;
                }

                break;

            case QualityType.天品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士紫;
                    case 2: return 功法Type.法师紫;
                    case 3: return 功法Type.辅助紫;
                    case 4: return 功法Type.控制紫;
                    case 5: return 功法Type.射手紫;
                }

                break;

            case QualityType.宙品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士粉;
                    case 2: return 功法Type.法师粉;
                    case 3: return 功法Type.辅助粉;
                    case 4: return 功法Type.控制粉;
                    case 5: return 功法Type.射手粉;
                }

                break;

            case QualityType.洪品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士红;
                    case 2: return 功法Type.法师红;
                    case 3: return 功法Type.辅助红;
                    case 4: return 功法Type.控制红;
                    case 5: return 功法Type.射手红;
                }

                break;

            case QualityType.宇品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士橙;
                    case 2: return 功法Type.法师橙;
                    case 3: return 功法Type.辅助橙;
                    case 4: return 功法Type.控制橙;
                    case 5: return 功法Type.射手橙;
                }

                break;

            case QualityType.荒品:
                random = Random.Range(1, 6);
                switch (random)
                {
                    case 1: return 功法Type.战士彩;
                    case 2: return 功法Type.法师彩;
                    case 3: return 功法Type.辅助彩;
                    case 4: return 功法Type.控制彩;
                    case 5: return 功法Type.射手彩;
                }

                break;
        }
        return 功法Type.None;
    }

    public static 功法Type 传道(QualityType qualityType)
    {
        List<float> list = 传道概率Dic[qualityType];
        int index = 0;
        float count = 0;
        float random = Random.Range(0, 100);
        foreach (var item in list)
        {
            count += item;
            if (random <= count)
            {
                break;
            }
            index++;
        }

        switch (index)
        {
            case 0:
                return Get功法(QualityType.黄品);
            case 1:
                return Get功法(QualityType.玄品);
            case 2:
                return Get功法(QualityType.地品);
            case 3:
                return Get功法(QualityType.天品);
            case 4:
                return Get功法(QualityType.宇品);
            case 5:
                return Get功法(QualityType.宙品);
            case 6:
                return Get功法(QualityType.洪品);
            case 7:
                return Get功法(QualityType.荒品);
        }

        return 功法Type.None;
    }
}
