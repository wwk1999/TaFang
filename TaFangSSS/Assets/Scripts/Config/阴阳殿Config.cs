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
    public float 加宇品以上概率;
    public float 一炉双器概率;
    public float 加荒品概率;
    public float 加分解粉尘;
    public float 加法器无暇洗练概率;
    
    public float 功法层数速度;
    public float 功法层数效果;
    public float 加功法分解粉尘;
    public float 加荒品功法概率;
    public float 传道功德消耗减少;
    public float 每道年传道次数翻倍;
    
    public float 符文效果;
    public float 宇品以上符文掉落概率;
    public float 荒品掉落概率;
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
    
    public float 仙女效果;
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

public class 阴阳殿Config
{
    public static Dictionary<仙子Type, string> 仙子名Dic = new Dictionary<仙子Type, string>()
    {
        {仙子Type.伤害,"水清漪"},
        {仙子Type.炼丹,"水清漪"},
        {仙子Type.炼器,"水清漪"},
        {仙子Type.功法,"水清漪"},
        {仙子Type.符文,"水清漪"},
        {仙子Type.领主装备,"水清漪"},
        {仙子Type.灵兽,"水清漪"},
        {仙子Type.合欢,"水清漪"},
        {仙子Type.掉宝,"水清漪"},
        {仙子Type.时间流速,"水清漪"},
    };
}
