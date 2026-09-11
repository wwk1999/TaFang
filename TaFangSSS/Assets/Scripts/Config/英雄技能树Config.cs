using System;
using System.Collections.Generic;
using Config;

public enum 技能Type{
    None,
    
    //星级
    英雄伤害,
    技能冷却缩减,
    击退距离,
    效果范围,
    瑶池减速效果,
    瑶池持续时间,
    龟丞相减速,
    
    妲己效果,
    妲己持续时间,
    孙悟空挥棒次数,
    琼霄控制时长,
    
    
    女娲效果,
    女娲持续时间,
    
    元始火种个数,
    火种旋转速度,
    元始下场时间,
    玄冰风弹道速度减少,
    玄冰风每秒增长速度增加,
    无极天火数量,
    混沌开天拳出拳数量增加,
    
    
    //神通
    神通冷却时间,
    神通伤害1,
    神通伤害2,

    神通能量,
    
    //辅助
    被辅助英雄伤害,
    被辅助英雄暴击率,
    被辅助英雄暴击伤害,
    
    //新增
    技能伤害1,
    技能伤害2,
    射手分裂,
    射手穿透,
    
    物理伤害,
    雷电伤害,
    黑暗伤害,
    火焰伤害,
    冰霜伤害,
    
    火焰灼烧伤害,
    火焰灼烧时间,
    火焰灼烧最大层数,
    
    冰减速,
    冰概率冰冻,
    冰冻时间,
    冰冻增伤,
    
    易电状态概率,
    易电状态时间,
    易电状态伤害,
    
    
    黑暗印记储存伤害,
    黑暗印记减少引爆层数,
    黑暗印记增加引爆层数,

    物理碎甲怪物百分比,
    物理碎甲领主攻击百分比,
    物理无抗性加伤害,
    
    增加所有英雄伤害,
    
    寻宝速度,
    概率紫变橙,
    概率橙变粉,
    概率粉变红,
    概率红变彩,
    概率提升数量,  
    
    暴击率,
    暴击伤害,
    普通怪增伤,
    精英怪增伤,
    首领怪增伤,
    石敢当锤子速度,
    
    被辅助英雄普通怪伤害,
    被辅助英雄精英怪伤害,
    被辅助英雄首领怪伤害,
    被辅助元素伤害,
    
    哪吒神通数量,
    碧霄神通数量,
    羲和神通数量,
    
    被辅助英雄技能伤害,
    女娲神通效果,
}

public class 英雄技能item
{
    public 技能Type 技能Type;
    public bool 是否有前置=false;
    public float count;
    public int 最大等级;
}

public enum 英雄境界Type
{
    None,
    寻道,
    悟道,
    入道,
    证道,
}

public class 英雄技能树Config
{
    
    public static Dictionary<QualityType, float> 英雄最高境界Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品 ,5},
        { QualityType.玄品 ,10},
        { QualityType.地品 ,15},
        { QualityType.天品 ,20},
        { QualityType.宇品 ,25},
        { QualityType.宙品 ,30},
        { QualityType.洪品 ,35},
        { QualityType.荒品 ,40},
    };
    public static Dictionary<QualityType, float> 增加所有英雄伤害Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品 ,1},
        { QualityType.玄品 ,2},
        { QualityType.地品 ,3},
        { QualityType.天品 ,5},
        { QualityType.宇品 ,8},
        { QualityType.宙品 ,12},
        { QualityType.洪品 ,18},
        { QualityType.荒品 ,30},
    };
    public static 技能Type Get英雄技能Type(HeroType heroType, int 行, int 列)
    {
        // 1. 判断英雄是否存在
        if (!英雄技能树Dic.TryGetValue(heroType, out var 技能树))
        {
            return 技能Type.None;
        }

        // 2. 判断列是否越界
        if (列 < 0 || 列 > 8)
        {
            return 技能Type.None;
        }

        var 当前行 = 技能树[行-1];
        

        // 4. 返回对应技能节点的技能Type
        return 当前行[列-1].技能Type;
    }
    public static Dictionary<HeroType, List<List<英雄技能item>>> 英雄技能树Dic = new Dictionary<HeroType, List<List<英雄技能item>>>()
    {
        {
            HeroType.丹童,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.火焰伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.黄品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        {
            HeroType.河伯,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.冰霜伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        {
            HeroType.土地,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.击退距离, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.黑暗伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.黄品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        {
            HeroType.瑶池仙女,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.瑶池减速效果, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.瑶池持续时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.黄品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
        
        {
            HeroType.石敢当,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.石敢当锤子速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.物理伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲怪物百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
        
        {
            HeroType.龟丞相,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.龟丞相减速, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.冰霜伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰减速, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
        {
            HeroType.玄女,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = false, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.雷电伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态概率, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
        
        {
            HeroType.太白金星,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.射手穿透, 是否有前置 = false, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.雷电伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态概率, 是否有前置 = true, 最大等级 = 10, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.玄品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
        
        {
            HeroType.多闻天王,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.射手穿透, 是否有前置 = false, 最大等级 = 2, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.黑暗伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记储存伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记减少引爆层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
         {
            HeroType.广目天王,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.黑暗伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记储存伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记减少引爆层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
         
         
          {
            HeroType.雷震子,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = false, 最大等级 = 2, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.雷电伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态概率, 是否有前置 = true, 最大等级 = 10, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
          
          
          
           {
            HeroType.月老,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.射手穿透, 是否有前置 = false, 最大等级 = 2, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.火焰伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.地品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 2, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
           
           
           {
            HeroType.嫦娥,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.雷电伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态概率, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           {
            HeroType.杨戬,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.射手穿透, 是否有前置 = false, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.雷电伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态概率, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.易电状态伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           {
            HeroType.妲己,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄暴击率, 是否有前置 = true, 最大等级 = 3, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 6 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄普通怪伤害, 是否有前置 = true, 最大等级 = 3, count = 6 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.妲己效果, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.妲己持续时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = false, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           {
            HeroType.牛魔王,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.物理伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲怪物百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲领主攻击百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.天品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           {
            HeroType.孙悟空,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.孙悟空挥棒次数, 是否有前置 = false, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.物理伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲怪物百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲领主攻击百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           {
            HeroType.哪吒,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.哪吒神通数量, 是否有前置 = false, 最大等级 = 3, count = 1 },

                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.火焰伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 4 },                   
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           
           {
            HeroType.碧霄,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.碧霄神通数量, 是否有前置 = false, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.冰霜伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰减速, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰概率冰冻, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻时间, 是否有前置 = true, 最大等级 = 3, count = 0.3f },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           {
            HeroType.琼霄,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.琼霄控制时长, 是否有前置 = false, 最大等级 = 3, count = 0.3f },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.黑暗伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记储存伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记减少引爆层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记增加引爆层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记储存伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宇品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           {
            HeroType.羲和,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.羲和神通数量, 是否有前置 = true, 最大等级 = 2, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.火焰伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           {
            HeroType.常羲,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.冰霜伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰减速, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰概率冰冻, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻时间, 是否有前置 = true, 最大等级 = 3, count = 0.3f },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           
           {
            HeroType.后羿,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.射手穿透, 是否有前置 = false, 最大等级 = 4, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.射手分裂, 是否有前置 = false, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.物理伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲怪物百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲领主攻击百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           
           
           {
            HeroType.云霄,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.效果范围, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.冰霜伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰减速, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰概率冰冻, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻时间, 是否有前置 = true, 最大等级 = 3, count = 0.3f },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.宙品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           {
            HeroType.女娲,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄暴击率, 是否有前置 = true, 最大等级 = 3, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 6 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄普通怪伤害, 是否有前置 = true, 最大等级 = 3, count = 6 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄精英怪伤害, 是否有前置 = true, 最大等级 = 3, count = 6 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄首领怪伤害, 是否有前置 = true, 最大等级 = 3, count = 6 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助英雄技能伤害, 是否有前置 = true, 最大等级 = 3, count = 8 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.女娲持续时间, 是否有前置 = false, 最大等级 = 3, count = 0.5f },
                    new 英雄技能item() { 技能Type = 技能Type.女娲效果, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.女娲神通效果, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.被辅助元素伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
        
           
           
           
           {
            HeroType.元始,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害1, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.元始火种个数, 是否有前置 = false, 最大等级 = 3, count = 1f },
                    new 英雄技能item() { 技能Type = 技能Type.火种旋转速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.元始下场时间, 是否有前置 = false, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.火焰伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           {
            HeroType.通天,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害1, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.射手穿透, 是否有前置 = false, 最大等级 = 5, count = 1f },
                    new 英雄技能item() { 技能Type = 技能Type.射手分裂, 是否有前置 = true, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.黑暗伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记储存伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记减少引爆层数, 是否有前置 = false, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记增加引爆层数, 是否有前置 = false, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记储存伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记减少引爆层数, 是否有前置 = false, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.黑暗印记增加引爆层数, 是否有前置 = false, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           
           {
            HeroType.老子,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害1, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.玄冰风弹道速度减少, 是否有前置 = true, 最大等级 = 3, count = 5f },
                    new 英雄技能item() { 技能Type = 技能Type.玄冰风每秒增长速度增加, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.冰霜伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰减速, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰概率冰冻, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻时间, 是否有前置 = true, 最大等级 = 3, count = 0.3f },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.冰冻增伤, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.洪品] },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.None, 是否有前置 = true, 最大等级 = 1, count = 8 },
                },
            }
        },
           
           
           
           
           {
            HeroType.鸿钧,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害1, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害1, 是否有前置 = true, 最大等级 = 5, count = 5 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.无极天火数量, 是否有前置 = true, 最大等级 = 1, count = 1f },
                    new 英雄技能item() { 技能Type = 技能Type.无极天火数量, 是否有前置 = true, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.无极天火数量, 是否有前置 = true, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.火焰伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧时间, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧伤害, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.火焰灼烧最大层数, 是否有前置 = true, 最大等级 = 3, count = 1 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率红变彩, 是否有前置 = true, 最大等级 = 5, count = 1 },
                },
            }
        },
           
           
           
           
           {
            HeroType.盘古,
            new List<List<英雄技能item>>()
            {
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击率, 是否有前置 = true, 最大等级 = 3, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.暴击伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.普通怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.精英怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.首领怪增伤, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.技能伤害1, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害1, 是否有前置 = true, 最大等级 = 5, count = 5 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.技能冷却缩减, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.混沌开天拳出拳数量增加, 是否有前置 = true, 最大等级 = 1, count = 1f },
                    new 英雄技能item() { 技能Type = 技能Type.混沌开天拳出拳数量增加, 是否有前置 = true, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.混沌开天拳出拳数量增加, 是否有前置 = true, 最大等级 = 1, count = 1 },
                    new 英雄技能item() { 技能Type = 技能Type.神通冷却时间, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通能量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.神通伤害2, 是否有前置 = true, 最大等级 = 5, count = 5 },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.物理伤害, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲怪物百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理碎甲领主攻击百分比, 是否有前置 = true, 最大等级 = 3, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                    new 英雄技能item() { 技能Type = 技能Type.物理无抗性加伤害, 是否有前置 = true, 最大等级 = 3, count = 10 },
                },
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = false, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                    new 英雄技能item() { 技能Type = 技能Type.增加所有英雄伤害, 是否有前置 = true, 最大等级 = 5, count = 增加所有英雄伤害Dic[QualityType.荒品] },
                },
                
                new List<英雄技能item>()
                {
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = false, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率紫变橙, 是否有前置 = true, 最大等级 = 5, count = 4 },
                    new 英雄技能item() { 技能Type = 技能Type.概率橙变粉, 是否有前置 = true, 最大等级 = 5, count = 3 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率粉变红, 是否有前置 = true, 最大等级 = 5, count = 2 },
                    new 英雄技能item() { 技能Type = 技能Type.寻宝速度, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率提升数量, 是否有前置 = true, 最大等级 = 5, count = 5 },
                    new 英雄技能item() { 技能Type = 技能Type.概率红变彩, 是否有前置 = true, 最大等级 = 5, count = 1 },
                },
            }
        },
    };

    public static string Get英雄境界String(英雄境界Type type)
    {
        switch (type)
        {
            case 英雄境界Type.入道:
                return "入道";
            case 英雄境界Type.悟道:
                return "悟道";
            case 英雄境界Type.证道:
                return "证道";
            case 英雄境界Type.寻道:
                return "寻道";
        }

        return "";
    }
    
    public static 英雄境界Type Get英雄境界Type(int count)
    {
        if (count <= 10)
        {
            return 英雄境界Type.寻道;
        }else if (count <= 20)
        {
            return 英雄境界Type.悟道;
        }else if (count <= 30)
        {
            return 英雄境界Type.入道;
        }else if (count <= 40)
        {
            return 英雄境界Type.证道;
        }
        return 英雄境界Type.None;
    }
}
