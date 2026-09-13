using System.Collections.Generic;
using Config;

public enum 符文品质Type
{
    None,
    灵文,
    仙文,
    帝文,
    圣文,
    道文,
}

public enum 符文Type
{
    None,
    击杀怪物获得神通能量,
    击杀怪物减少神通冷却,
    技能伤害减少神通伤害增加,
    技能伤害增加不能释放神通,
    
    献祭自身加强相邻英雄,
    火同气连枝,//队伍中每有一个火系英雄，加火焰伤害3
    冰同气连枝,
    黑暗同气连枝,
    雷电同气连枝,
    物理同气连枝,
    战士同气连枝,
    射手同气连枝,
    控制同气连枝,
    法师同气连枝,
    辅助同气连枝,
    辅助印记增伤,
    
    元素每有一个不同增伤,
    职业每有一个不同增伤,
    
    对怪物的第一次伤害增加,
    对怪物攻击次数越多越加伤害,
    加强碎甲效果,
    碎甲为0时加伤害,
    
    每层火焰灼烧加伤,
    死亡后留下火焰,//火焰伤害为灼伤伤害的百分比
    
    每层黑暗印记加伤,
    引爆时造成范围爆炸,
    
    雷属性打易电状态加伤害,
    增强易电效果,
    
    取消冰冻每冰冻概率增伤,
    冰减速效果,
    
    每有一个异常状态增伤,
    没有异常状态增伤,
    
    //高品质英雄增伤,
    //低品质英雄增伤,
}

public class 符文Config
{
    public static Dictionary<符文品质Type, QualityType> 符文品质对应Quality = new Dictionary<符文品质Type, QualityType>()
    {
        { 符文品质Type.灵文, QualityType.地品 },
        { 符文品质Type.仙文, QualityType.宇品 },
        { 符文品质Type.帝文, QualityType.宙品 },
        { 符文品质Type.圣文, QualityType.洪品 },
        { 符文品质Type.道文, QualityType.荒品 },
    };

    public static Dictionary<符文Type, string> 符文名Dic = new Dictionary<符文Type, string>()
    {
        { 符文Type.击杀怪物获得神通能量, "噬魂" },
        { 符文Type.击杀怪物减少神通冷却, "斩业" },
        { 符文Type.技能伤害减少神通伤害增加, "舍末" },
        { 符文Type.技能伤害增加不能释放神通, "禁法" },
        { 符文Type.辅助印记增伤, "圣灵" },

        { 符文Type.献祭自身加强相邻英雄, "燃身" },
        { 符文Type.火同气连枝, "赤炎" },
        { 符文Type.冰同气连枝, "玄冰" },
        { 符文Type.黑暗同气连枝, "幽暗" },
        { 符文Type.雷电同气连枝, "紫雷" },
        { 符文Type.物理同气连枝, "体脉" },
        { 符文Type.战士同气连枝, "战魄" },
        { 符文Type.射手同气连枝, "射星" },
        { 符文Type.控制同气连枝, "禁锁" },
        { 符文Type.法师同气连枝, "灵法" },
        { 符文Type.辅助同气连枝, "辅道" },

        { 符文Type.元素每有一个不同增伤, "万象" },
        { 符文Type.职业每有一个不同增伤, "百道" },

        { 符文Type.对怪物的第一次伤害增加, "破煞" },
        { 符文Type.对怪物攻击次数越多越加伤害, "叠诛" },
        { 符文Type.加强碎甲效果, "裂甲" },
        { 符文Type.碎甲为0时加伤害, "碎魂" },

        { 符文Type.每层火焰灼烧加伤, "焚身" },
        { 符文Type.死亡后留下火焰, "遗火" },

        { 符文Type.每层黑暗印记加伤, "暗印" },
        { 符文Type.引爆时造成范围爆炸, "爆印" },

        { 符文Type.雷属性打易电状态加伤害, "雷引" },
        { 符文Type.增强易电效果, "引雷" },

        { 符文Type.取消冰冻每冰冻概率增伤, "碎霜" },
        { 符文Type.冰减速效果, "寒滞" },

        { 符文Type.每有一个异常状态增伤, "万厄" },
        { 符文Type.没有异常状态增伤, "无垢" },

    };

    public static Dictionary<符文Type, List<minmax>> 符文配置Dic = new Dictionary<符文Type, List<minmax>>()
    {
        {
            符文Type.击杀怪物获得神通能量, new List<minmax>()
            {
                new minmax() { min = 0.16f, max = 0.24f }, new minmax() { min = 0.24f, max = 0.36f },
                new minmax() { min = 0.4f, max = 0.6f }, new minmax() { min = 0.64f, max = 0.96f },
                new minmax() { min = 1.2f, max = 1.8f }
            }
        },
        {
            符文Type.击杀怪物减少神通冷却, new List<minmax>()
            {
                new minmax() { min = 0.8f, max = 1.2f }, new minmax() { min = 1.2f, max = 1.8f },
                new minmax() { min = 1.6f, max = 2.4f }, new minmax() { min = 2.4f, max = 3.6f },
                new minmax() { min = 4f, max = 6f }
            }
        },
        {
            符文Type.技能伤害减少神通伤害增加, new List<minmax>()
            {
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 120f, max = 180f }, new minmax() { min = 144f, max = 216f },
                new minmax() { min = 200f, max = 300f }
            }
        },
        {
            符文Type.技能伤害增加不能释放神通, new List<minmax>()
            {
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 120f, max = 180f }, new minmax() { min = 144f, max = 216f },
                new minmax() { min = 200f, max = 300f }
            }
        },

        {
            符文Type.献祭自身加强相邻英雄, new List<minmax>()
            {
                new minmax() { min = 24f, max = 36f }, new minmax() { min = 40f, max = 60f },
                new minmax() { min = 64f, max = 96f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 160f, max = 240f }
            }
        },
        {
            符文Type.火同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.冰同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.黑暗同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.雷电同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.物理同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.战士同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.射手同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.控制同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.法师同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.辅助同气连枝, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.辅助印记增伤, new List<minmax>()
            {
                new minmax() { min = 8f, max = 12f }, new minmax() { min = 12f, max = 18f },
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }
            }
        },

        {
            符文Type.元素每有一个不同增伤, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.职业每有一个不同增伤, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },

        {
            符文Type.对怪物的第一次伤害增加, new List<minmax>()
            {
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 120f, max = 180f }, new minmax() { min = 144f, max = 216f },
                new minmax() { min = 200f, max = 300f }
            }
        },
        {
            符文Type.对怪物攻击次数越多越加伤害, new List<minmax>()
            {
                new minmax() { min = 8f, max = 12f }, new minmax() { min = 12f, max = 18f },
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }
            }
        },
        {
            符文Type.加强碎甲效果, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.碎甲为0时加伤害, new List<minmax>()
            {
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 120f, max = 180f }, new minmax() { min = 144f, max = 216f },
                new minmax() { min = 200f, max = 300f }
            }
        },

        {
            符文Type.每层火焰灼烧加伤, new List<minmax>()
            {
                new minmax() { min = 8f, max = 12f }, new minmax() { min = 12f, max = 18f },
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }
            }
        },
        {
            符文Type.死亡后留下火焰, new List<minmax>()
            {
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 120f, max = 180f }, new minmax() { min = 144f, max = 216f },
                new minmax() { min = 200f, max = 300f }
            }
        },

        {
            符文Type.每层黑暗印记加伤, new List<minmax>()
            {
                new minmax() { min = 8f, max = 12f }, new minmax() { min = 12f, max = 18f },
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }
            }
        },
        {
            符文Type.引爆时造成范围爆炸, new List<minmax>()
            {
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 120f, max = 180f }, new minmax() { min = 144f, max = 216f },
                new minmax() { min = 200f, max = 300f }
            }
        },

        {
            符文Type.雷属性打易电状态加伤害, new List<minmax>()
            {
                new minmax() { min = 24f, max = 36f }, new minmax() { min = 40f, max = 60f },
                new minmax() { min = 64f, max = 96f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 160f, max = 240f }
            }
        },
        {
            符文Type.增强易电效果, new List<minmax>()
            {
                new minmax() { min = 24f, max = 36f }, new minmax() { min = 40f, max = 60f },
                new minmax() { min = 64f, max = 96f }, new minmax() { min = 96f, max = 144f },
                new minmax() { min = 160f, max = 240f }
            }
        },

        {
            符文Type.取消冰冻每冰冻概率增伤, new List<minmax>()
            {
                new minmax() { min = 3, max = 5 }, new minmax() { min = 5, max = 8 },
                new minmax() { min = 8, max = 12 }, new minmax() { min = 12, max = 18 },
                new minmax() { min = 18, max = 30f }
            }
        },
        {
            符文Type.冰减速效果, new List<minmax>()
            {
                new minmax() { min = 8f, max = 12f }, new minmax() { min = 12f, max = 18f },
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }
            }
        },

        {
            符文Type.每有一个异常状态增伤, new List<minmax>()
            {
                new minmax() { min = 8f, max = 12f }, new minmax() { min = 12f, max = 18f },
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }
            }
        },
        {
            符文Type.没有异常状态增伤, new List<minmax>()
            {
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 24f, max = 36f },
                new minmax() { min = 40f, max = 60f }, new minmax() { min = 64f, max = 96f },
                new minmax() { min = 120f, max = 180f }
            }
        },
    };
}
