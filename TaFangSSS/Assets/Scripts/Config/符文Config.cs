using System.Collections.Generic;
using Config;

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
    
    每层黑暗印记加伤,
    引爆时造成范围爆炸,
    
    雷属性打易电状态加伤害,
    增强易电效果,
    
    取消冰冻每冰冻概率增伤,
    冰减速效果,
    
    每有一个异常状态增伤,
    没有异常状态增伤,
    清除异常状态增伤,//每一个加伤
    //高品质英雄增伤,
    //低品质英雄增伤,
}

public class 符文属性
{
    public float 击杀怪物获得神通能量;
    public float 击杀怪物减少神通冷却;
    public float 技能伤害减少神通伤害增加;
    public float 技能伤害增加不能释放神通;
    public float 献祭自身加强相邻英雄;
    
    public float 火同气连枝;
    public float 冰同气连枝;
    public float 黑暗同气连枝;
    public float 雷电同气连枝;
    public float 物理同气连枝;
    public float 战士同气连枝;
    public float 射手同气连枝;
    public float 控制同气连枝;
    public float 法师同气连枝;
    public float 辅助同气连枝;
    public float 辅助印记增伤;
    
    public float 元素每有一个不同增伤;
    public float 职业每有一个不同增伤;
    
    public float 对怪物的第一次伤害增加;
    public float 对怪物攻击次数越多越加伤害;
    public float 加强碎甲效果;
    public float 碎甲为0时加伤害;
    
    public float 每层火焰灼烧加伤;
    
    public float  每层黑暗印记加伤;
    public float 引爆时造成范围爆炸;
    
    public float 雷属性打易电状态加伤害;
    public float 增强易电效果;
    
    public float 取消冰冻每冰冻概率增伤;
    public float 冰减速效果;
    
    public float 每有一个异常状态增伤;
    public float 没有异常状态增伤;
    public float 清除异常状态增伤;
}

public class 符文
{
    public 符文Type type;
    public QualityType quality;
    public float count;
    public bool 锁=false;
    public bool 融合;
    public 符文Type 融合type;
    public float 融合count;
    public bool 融合无暇;
    public bool 无暇;
}
public class 符文Config
{
    /// <summary>
    /// 取符文数值范围：List索引 = (int)quality - 1，即 黄玄地天宇宙洪荒 对应 0~7
    /// </summary>
    public static minmax Get符文minmax(符文Type type, QualityType quality)
    {
        int index = (int)quality - 1;
        if (!符文配置Dic.TryGetValue(type, out var list) || index < 0 || index >= list.Count) return null;
        return list[index];
    }

    public static 符文属性 Get英雄符文属性(HeroType heroType)
    {
        符文属性 属性 = new 符文属性();

        // 符文石镶嵌在英雄的法器上，一个法器只能镶嵌一个。
        // 一个英雄最多戴4件法器（武器/衣服/头盔/鞋子），直接读英雄装备槽，
        // 遍历每件法器的镶嵌符文，按其 type 累加到对应字段（同类型多件法器相加）
        if (!PlayerData.S.HeroDataDic.TryGetValue(heroType, out var heroData) || heroData == null) return 属性;
        法器[] 法器s = { heroData.武器, heroData.衣服, heroData.头盔, heroData.鞋子 };
        foreach (法器 法器 in 法器s)
        {
            if (法器 == null) continue;
            符文 符文 = 法器.符文;
            if (符文 == null || 符文.type == 符文Type.None) continue;
            // 融合且主副符文都是无暇时，两个词条额外×10，叠加无暇自身×3，共×30
            float 额外倍数 = (符文.无暇 && 符文.融合 && 符文.融合无暇) ? 10f : 1f;
            // 无暇符文词条效果增幅3倍
            加符文属性(属性, 符文.type, 符文.count, 符文.无暇, 额外倍数);
            if (符文.融合 && 符文.融合type != 符文Type.None)
            {
                加符文属性(属性, 符文.融合type, 符文.融合count, 符文.融合无暇, 额外倍数);
            }
        }
        return 属性;
    }

    /// <summary>按符文类型把词条数值累加到属性上</summary>
    private static void 加符文属性(符文属性 属性, 符文Type 符文Type, float count, bool 无暇, float 额外倍数)
    {
        float 数值 = count * (无暇 ? 3f : 1f) * 额外倍数;
        switch (符文Type)
            {
                case 符文Type.击杀怪物获得神通能量: 属性.击杀怪物获得神通能量 += 数值; break;
                case 符文Type.击杀怪物减少神通冷却: 属性.击杀怪物减少神通冷却 += 数值; break;
                case 符文Type.技能伤害减少神通伤害增加: 属性.技能伤害减少神通伤害增加 += 数值; break;
                case 符文Type.技能伤害增加不能释放神通: 属性.技能伤害增加不能释放神通 += 数值; break;
                case 符文Type.献祭自身加强相邻英雄: 属性.献祭自身加强相邻英雄 += 数值; break;
                case 符文Type.火同气连枝: 属性.火同气连枝 += 数值; break;
                case 符文Type.冰同气连枝: 属性.冰同气连枝 += 数值; break;
                case 符文Type.黑暗同气连枝: 属性.黑暗同气连枝 += 数值; break;
                case 符文Type.雷电同气连枝: 属性.雷电同气连枝 += 数值; break;
                case 符文Type.物理同气连枝: 属性.物理同气连枝 += 数值; break;
                case 符文Type.战士同气连枝: 属性.战士同气连枝 += 数值; break;
                case 符文Type.射手同气连枝: 属性.射手同气连枝 += 数值; break;
                case 符文Type.控制同气连枝: 属性.控制同气连枝 += 数值; break;
                case 符文Type.法师同气连枝: 属性.法师同气连枝 += 数值; break;
                case 符文Type.辅助同气连枝: 属性.辅助同气连枝 += 数值; break;
                case 符文Type.辅助印记增伤: 属性.辅助印记增伤 += 数值; break;
                case 符文Type.元素每有一个不同增伤: 属性.元素每有一个不同增伤 += 数值; break;
                case 符文Type.职业每有一个不同增伤: 属性.职业每有一个不同增伤 += 数值; break;
                case 符文Type.对怪物的第一次伤害增加: 属性.对怪物的第一次伤害增加 += 数值; break;
                case 符文Type.对怪物攻击次数越多越加伤害: 属性.对怪物攻击次数越多越加伤害 += 数值; break;
                case 符文Type.加强碎甲效果: 属性.加强碎甲效果 += 数值; break;
                case 符文Type.碎甲为0时加伤害: 属性.碎甲为0时加伤害 += 数值; break;
                case 符文Type.每层火焰灼烧加伤: 属性.每层火焰灼烧加伤 += 数值; break;
                case 符文Type.每层黑暗印记加伤: 属性.每层黑暗印记加伤 += 数值; break;
                case 符文Type.引爆时造成范围爆炸: 属性.引爆时造成范围爆炸 += 数值; break;
                case 符文Type.雷属性打易电状态加伤害: 属性.雷属性打易电状态加伤害 += 数值; break;
                case 符文Type.增强易电效果: 属性.增强易电效果 += 数值; break;
                case 符文Type.取消冰冻每冰冻概率增伤: 属性.取消冰冻每冰冻概率增伤 += 数值; break;
                case 符文Type.冰减速效果: 属性.冰减速效果 += 数值; break;
                case 符文Type.每有一个异常状态增伤: 属性.每有一个异常状态增伤 += 数值; break;
                case 符文Type.没有异常状态增伤: 属性.没有异常状态增伤 += 数值; break;
                case 符文Type.清除异常状态增伤: 属性.清除异常状态增伤 += 数值; break;
            }
    }

    public static Dictionary<符文Type, string> 符文名Dic = new Dictionary<符文Type, string>()
    {
        { 符文Type.None, "" },

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
        { 符文Type.对怪物攻击次数越多越加伤害, "重诛" },
        { 符文Type.加强碎甲效果, "裂甲" },
        { 符文Type.碎甲为0时加伤害, "碎魂" },

        { 符文Type.每层火焰灼烧加伤, "焚身" },

        { 符文Type.每层黑暗印记加伤, "暗印" },
        { 符文Type.引爆时造成范围爆炸, "爆印" },

        { 符文Type.雷属性打易电状态加伤害, "雷引" },
        { 符文Type.增强易电效果, "引雷" },

        { 符文Type.取消冰冻每冰冻概率增伤, "碎霜" },
        { 符文Type.冰减速效果, "寒滞" },

        { 符文Type.每有一个异常状态增伤, "万厄" },
        { 符文Type.没有异常状态增伤, "无垢" },
        { 符文Type.清除异常状态增伤, "清道" },
    };

    public static Dictionary<QualityType, float> 符文分解Dictionary = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 100 },
        { QualityType.玄品, 300 },
        { QualityType.地品, 1000 },
        { QualityType.天品, 3000 },
        { QualityType.宇品, 10000 },
        { QualityType.宙品, 50000 },
        { QualityType.洪品, 500000 },
        { QualityType.荒品, 10000000 },
    };
    public static Dictionary<QualityType, float> 符文洗练Dictionary = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 50 },
        { QualityType.玄品, 150 },
        { QualityType.地品, 500 },
        { QualityType.天品, 1500 },
        { QualityType.宇品, 5000 },
        { QualityType.宙品, 25000 },
        { QualityType.洪品, 250000 },
        { QualityType.荒品, 5000000 },
    };
    public static Dictionary<符文Type, string> 符文效果Dic = new Dictionary<符文Type, string>()
    {
        { 符文Type.击杀怪物获得神通能量, "击杀敌人获得神通能量" },
        { 符文Type.击杀怪物减少神通冷却, "击杀敌人减少神通冷却" },
        { 符文Type.技能伤害减少神通伤害增加, "技能伤害减少50%增加神通伤害" },
        { 符文Type.技能伤害增加不能释放神通, "技能伤害增加不能释放神通" },
        { 符文Type.辅助印记增伤, "每辅助一次英雄添加圣灵印记,每层圣灵印记增伤" },

        { 符文Type.献祭自身加强相邻英雄, "献祭自身加强相邻英雄" },
        { 符文Type.火同气连枝, "每上场一个火元素英雄增加火焰伤害" },
        { 符文Type.冰同气连枝, "每上场一个冰元素英雄增加冰霜伤害" },
        { 符文Type.黑暗同气连枝, "每上场一个黑暗元素英雄增加黑暗伤害" },
        { 符文Type.雷电同气连枝, "每上场一个雷电元素英雄增加雷电伤害" },
        { 符文Type.物理同气连枝, "每上场一个物理英雄增加物理伤害" },
        { 符文Type.战士同气连枝, "每上场一个战士英雄增加战士伤害" },
        { 符文Type.射手同气连枝, "每上场一个射手英雄增加射手伤害" },
        { 符文Type.控制同气连枝, "每上场一个控制英雄增加控制伤害" },
        { 符文Type.法师同气连枝, "每上场一个法师英雄增加法师伤害" },
        { 符文Type.辅助同气连枝, "每上场一个辅助英雄增加所有伤害" },

        { 符文Type.元素每有一个不同增伤, "每上场一个不同元素英雄增伤" },
        { 符文Type.职业每有一个不同增伤, "每上场一个不同职业英雄增伤" },

        { 符文Type.对怪物的第一次伤害增加, "对敌人的第一次伤害增伤" },
        { 符文Type.对怪物攻击次数越多越加伤害, "对同一敌人攻击次数加伤" },
        { 符文Type.加强碎甲效果, "加强碎甲效果" },
        { 符文Type.碎甲为0时加伤害, "敌人防御为0时增伤" },

        { 符文Type.每层火焰灼烧加伤, "每层火焰灼烧加伤" },

        { 符文Type.每层黑暗印记加伤, "每层黑暗印记加伤" },
        { 符文Type.引爆时造成范围爆炸, "黑暗印记引爆时造成范围爆炸" },

        { 符文Type.雷属性打易电状态加伤害, "雷属性打易电状态的敌人增伤" },
        { 符文Type.增强易电效果, "增强易电效果" },

        { 符文Type.取消冰冻每冰冻概率增伤, "冰元素每冰冻概率增伤,但不能冰冻" },
        { 符文Type.冰减速效果, "增强冰元素减速效果" },

        { 符文Type.每有一个异常状态增伤, "敌人每有一个异常状态增伤" },
        { 符文Type.没有异常状态增伤, "敌人没有异常状态时增伤" },
        { 符文Type.清除异常状态增伤, "敌人每有一个异常增伤,但会清除敌人异常" },
    };

    // List索引 = (int)QualityType - 1，即 黄(0) 玄(1) 地(2) 天(3) 宇(4) 宙(5) 洪(6) 荒(7)
    public static Dictionary<符文Type, List<minmax>> 符文配置Dic = new Dictionary<符文Type, List<minmax>>()
    {
        {
            符文Type.击杀怪物获得神通能量, new List<minmax>()
            {
                new minmax() { min = 0.11f, max = 0.16f }, new minmax() { min = 0.13f, max = 0.2f },
                new minmax() { min = 0.16f, max = 0.24f }, new minmax() { min = 0.2f, max = 0.29f },
                new minmax() { min = 0.24f, max = 0.36f }, new minmax() { min = 0.4f, max = 0.6f },
                new minmax() { min = 0.64f, max = 0.96f }, new minmax() { min = 1.2f, max = 1.8f }
            }
        },
        {
            符文Type.击杀怪物减少神通冷却, new List<minmax>()
            {
                new minmax() { min = 0.53f, max = 0.8f }, new minmax() { min = 0.65f, max = 0.98f },
                new minmax() { min = 0.8f, max = 1.2f }, new minmax() { min = 0.98f, max = 1.47f },
                new minmax() { min = 1.2f, max = 1.8f }, new minmax() { min = 1.6f, max = 2.4f },
                new minmax() { min = 2.4f, max = 3.6f }, new minmax() { min = 4f, max = 6f }
            }
        },
        {
            符文Type.技能伤害减少神通伤害增加, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },
        {
            符文Type.技能伤害增加不能释放神通, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },

        {
            符文Type.献祭自身加强相邻英雄, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.火同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.冰同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.黑暗同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.雷电同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.物理同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.战士同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.射手同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.控制同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.法师同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.辅助同气连枝, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.辅助印记增伤, new List<minmax>()
            {
                new minmax() { min = 7f, max = 13f }, new minmax() { min = 8f, max = 16f },
                new minmax() { min = 10f, max = 20f }, new minmax() { min = 12f, max = 24f },
                new minmax() { min = 20f, max = 40f }, new minmax() { min = 40f, max = 100f },
                new minmax() { min = 100f, max = 200f }, new minmax() { min = 200f, max = 500f }
            }
        },

        {
            符文Type.元素每有一个不同增伤, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.职业每有一个不同增伤, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },

        {
            符文Type.对怪物的第一次伤害增加, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },
        {
            符文Type.对怪物攻击次数越多越加伤害, new List<minmax>()
            {
                new minmax() { min = 7f, max = 13f }, new minmax() { min = 8f, max = 16f },
                new minmax() { min = 10f, max = 20f }, new minmax() { min = 12f, max = 24f },
                new minmax() { min = 20f, max = 40f }, new minmax() { min = 40f, max = 100f },
                new minmax() { min = 100f, max = 200f }, new minmax() { min = 200f, max = 500f }
            }
        },
        {
            符文Type.加强碎甲效果, new List<minmax>()
            {
                new minmax() { min = 11f, max = 16f }, new minmax() { min = 13f, max = 20f },
                new minmax() { min = 16f, max = 24f }, new minmax() { min = 20f, max = 29f },
                new minmax() { min = 24f, max = 36f }, new minmax() { min = 40f, max = 60f },
                new minmax() { min = 64f, max = 96f }, new minmax() { min = 120f, max = 180f }
            }
        },
        {
            符文Type.碎甲为0时加伤害, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },

        {
            符文Type.每层火焰灼烧加伤, new List<minmax>()
            {
                new minmax() { min = 7f, max = 13f }, new minmax() { min = 8f, max = 16f },
                new minmax() { min = 10f, max = 20f }, new minmax() { min = 12f, max = 24f },
                new minmax() { min = 20f, max = 40f }, new minmax() { min = 40f, max = 100f },
                new minmax() { min = 100f, max = 200f }, new minmax() { min = 200f, max = 500f }
            }
        },

        {
            符文Type.每层黑暗印记加伤, new List<minmax>()
            {
                new minmax() { min = 7f, max = 13f }, new minmax() { min = 8f, max = 16f },
                new minmax() { min = 10f, max = 20f }, new minmax() { min = 12f, max = 24f },
                new minmax() { min = 20f, max = 40f }, new minmax() { min = 40f, max = 100f },
                new minmax() { min = 100f, max = 200f }, new minmax() { min = 200f, max = 500f }
            }
        },
        {
            符文Type.引爆时造成范围爆炸, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },

        {
            符文Type.雷属性打易电状态加伤害, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },
        {
            符文Type.增强易电效果, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },

        {
            符文Type.取消冰冻每冰冻概率增伤, new List<minmax>()
            {
                new minmax() { min = 7f, max = 13f }, new minmax() { min = 8f, max = 16f },
                new minmax() { min = 10f, max = 20f }, new minmax() { min = 12f, max = 24f },
                new minmax() { min = 20f, max = 40f }, new minmax() { min = 40f, max = 100f },
                new minmax() { min = 100f, max = 200f }, new minmax() { min = 200f, max = 500f }
            }
        },
        {
            符文Type.冰减速效果, new List<minmax>()
            {
                new minmax() { min = 5f, max = 8f }, new minmax() { min = 7f, max = 10f },
                new minmax() { min = 8f, max = 12f }, new minmax() { min = 10f, max = 15f },
                new minmax() { min = 12f, max = 20f }, new minmax() { min = 20f, max = 30f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 50f, max = 100f }
            }
        },

        {
            符文Type.每有一个异常状态增伤, new List<minmax>()
            {
                new minmax() { min = 20f, max = 33f }, new minmax() { min = 24f, max = 41f },
                new minmax() { min = 30f, max = 50f }, new minmax() { min = 37f, max = 61f },
                new minmax() { min = 50f, max = 100f }, new minmax() { min = 100f, max = 200f },
                new minmax() { min = 200f, max = 400f }, new minmax() { min = 400f, max = 1000f }
            }
        },
        {
            符文Type.没有异常状态增伤, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },
        {
            符文Type.清除异常状态增伤, new List<minmax>()
            {
                new minmax() { min = 53f, max = 80f }, new minmax() { min = 65f, max = 98f },
                new minmax() { min = 80f, max = 120f }, new minmax() { min = 98f, max = 147f },
                new minmax() { min = 120f, max = 200f }, new minmax() { min = 200f, max = 400f },
                new minmax() { min = 400f, max = 800f }, new minmax() { min = 800f, max = 2000f }
            }
        },
    };
}
