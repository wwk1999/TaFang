using System;
using System.Collections.Generic;
using Config;
using UnityEngine;

public enum 道纹Type
{
    None,
    增加百分比攻击力,
    增加战士伤害,
    增加法师伤害,
    增加控制伤害,
    增加射手伤害,
    增加小怪伤害,
    增加物理伤害,
    增加雷电伤害,
    增加冰霜伤害,
    增加黑暗伤害,
    增加火焰伤害,
    增加精英怪和首领伤害,
    城墙低血增加伤害,
    击杀精英怪城墙回血,
    城墙血量百分比,
    城墙免疫伤害,
    城墙满血时加伤害,
    英雄暴击率,
    伤害在范围内浮动,
    无视抗性,
    战士对靠近城墙敌人伤害增高,
    射手对远距离敌人伤害增高,
    控制冷却缩减,
    法师暴击率,
    辅助被辅助英雄伤害增幅,
    
    
    三味真火无视抗性百分比,
    孙悟空每秒增加伤害,
    碧霄冰龙有概率再次释放,
    琼霄定身衰减效果减少,
    云霄最终伤害,
    后羿距离越远伤害越高,
    羲和灼烧伤害,
    常曦有概率冻结敌人,
    女娲增加被辅助冷却缩减,
    通天每次暴击增加伤害,
    老子旋风体积越大伤害越高,
    元始每次释放有概率增加火种数量,
    鸿钧每释放陨石增加伤害,
    盘古每击杀敌人增加伤害,
}

public class 道纹
{
    public 道纹Type 道纹Type;
    public QualityType quality;

    /// <summary>
    /// 判断两个道纹是否相等（类型和品质都相同）
    /// </summary>
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        道纹 other = (道纹)obj;
        return this.道纹Type == other.道纹Type && this.quality == other.quality;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(道纹Type, quality);
    }

    /// <summary>
    /// 重载 == 和 != 运算符，方便使用
    /// </summary>
    public static bool operator ==(道纹 a, 道纹 b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(道纹 a, 道纹 b)
    {
        return !(a == b);
    }
}

public class 道纹config
{
    //为了每次都拿到最新值，所以用Func<float>
    public static Dictionary<道纹Type, Func<float>> 专属道纹值Dic = new Dictionary<道纹Type, Func<float>>()
{
    { 道纹Type.三味真火无视抗性百分比, () => Get道纹数值(道纹Type.三味真火无视抗性百分比) },
    { 道纹Type.孙悟空每秒增加伤害, () => Get道纹数值(道纹Type.孙悟空每秒增加伤害) },
    { 道纹Type.碧霄冰龙有概率再次释放, () => Get道纹数值(道纹Type.碧霄冰龙有概率再次释放) },
    { 道纹Type.琼霄定身衰减效果减少, () => Get道纹数值(道纹Type.琼霄定身衰减效果减少) },
    { 道纹Type.云霄最终伤害, () => Get道纹数值(道纹Type.云霄最终伤害) },
    { 道纹Type.后羿距离越远伤害越高, () => Get道纹数值(道纹Type.后羿距离越远伤害越高) },
    { 道纹Type.羲和灼烧伤害, () => Get道纹数值(道纹Type.羲和灼烧伤害) },
    { 道纹Type.常曦有概率冻结敌人, () => Get道纹数值(道纹Type.常曦有概率冻结敌人) },
    { 道纹Type.女娲增加被辅助冷却缩减, () => Get道纹数值(道纹Type.女娲增加被辅助冷却缩减) },
    { 道纹Type.通天每次暴击增加伤害, () => Get道纹数值(道纹Type.通天每次暴击增加伤害) },
    { 道纹Type.老子旋风体积越大伤害越高, () => Get道纹数值(道纹Type.老子旋风体积越大伤害越高) },
    { 道纹Type.元始每次释放有概率增加火种数量, () => Get道纹数值(道纹Type.元始每次释放有概率增加火种数量) },
    { 道纹Type.鸿钧每释放陨石增加伤害, () => Get道纹数值(道纹Type.鸿钧每释放陨石增加伤害) },
    { 道纹Type.盘古每击杀敌人增加伤害, () => Get道纹数值(道纹Type.盘古每击杀敌人增加伤害) },
};

   
    public static bool 检查装备专属道纹(道纹Type type)
    {
        if (!是否专属道纹(type))
        {
            return false;
        }
        else
        {
            foreach (var item in PlayerData.S.装备道纹List[EquipType.头盔])
            {
                if (item != null && item.道纹Type == type)
                {
                    return true;
                }
            }
            foreach (var item in PlayerData.S.装备道纹List[EquipType.护手])
            {
                if (item != null && item.道纹Type == type)
                {
                    return true;
                }
            }
            foreach (var item in PlayerData.S.装备道纹List[EquipType.戒指])
            {
                if (item != null && item.道纹Type == type)
                {
                    return true;
                }
            }
            foreach (var item in PlayerData.S.装备道纹List[EquipType.鞋子])
            {
                if (item != null && item.道纹Type == type)
                {
                    return true;
                }
            }
            foreach (var item in PlayerData.S.装备道纹List[EquipType.项链])
            {
                if (item != null && item.道纹Type == type)
                {
                    return true;
                }
            }
            foreach (var item in PlayerData.S.装备道纹List[EquipType.衣服])
            {
                if (item != null && item.道纹Type == type)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public static bool 是否专属道纹(道纹Type type)
    {
        return (int)type >= 26;
    }
    
    public static Dictionary<道纹Type, HeroType> 道纹ToHeroDic = new Dictionary<道纹Type, HeroType>()
    {
        { 道纹Type.三味真火无视抗性百分比, HeroType.哪吒 },
        { 道纹Type.孙悟空每秒增加伤害, HeroType.孙悟空 },
        { 道纹Type.碧霄冰龙有概率再次释放, HeroType.碧霄 },
        { 道纹Type.琼霄定身衰减效果减少, HeroType.琼霄 },
        { 道纹Type.云霄最终伤害, HeroType.云霄 },
        { 道纹Type.后羿距离越远伤害越高, HeroType.后羿 },
        { 道纹Type.羲和灼烧伤害, HeroType.羲和 },
        { 道纹Type.常曦有概率冻结敌人, HeroType.常羲 },
        { 道纹Type.女娲增加被辅助冷却缩减, HeroType.女娲 },
        { 道纹Type.通天每次暴击增加伤害, HeroType.通天 },
        { 道纹Type.老子旋风体积越大伤害越高, HeroType.老子 },
        { 道纹Type.元始每次释放有概率增加火种数量, HeroType.元始 },
        { 道纹Type.鸿钧每释放陨石增加伤害, HeroType.鸿钧 },
        { 道纹Type.盘古每击杀敌人增加伤害, HeroType.盘古 },
    };
    
    public static Dictionary<EquipType, Vector2> 道纹弹窗Pos = new Dictionary<EquipType, Vector2>()
    {
        { EquipType.衣服, new Vector2(-248, -80) },
        { EquipType.戒指, new Vector2(-250, -80) },
        { EquipType.项链, new Vector2(-700, -80) },
        { EquipType.鞋子, new Vector2(-700, -80) },
        { EquipType.头盔, new Vector2(-492, -80) },
        { EquipType.护手, new Vector2(-492, -80) },
    };
    public static string Get道文info(道纹Type type, QualityType quality)
    {
        int qIndex = (int)quality-4;
        float val = 0;
        bool hasVal = 道纹数值Dic.ContainsKey(type);
        if (hasVal) val = 道纹数值Dic[type][qIndex];

        switch (type)
        {
            case 道纹Type.None:
                return "";


            case 道纹Type.增加百分比攻击力:
                return $"增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>的攻击力"; // 没有百分号，保持不变

            case 道纹Type.增加战士伤害:
                return $"增加战士<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>伤害";

            case 道纹Type.增加法师伤害:
                return $"增加法师<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>伤害";

            case 道纹Type.增加控制伤害:
                return $"增加控制<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>伤害";

            case 道纹Type.增加射手伤害:
                return $"增加射手<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>伤害";

            case 道纹Type.增加物理伤害:
                return $"物理伤害增幅<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";
            case 道纹Type.增加黑暗伤害:
                return $"黑暗伤害增幅<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";
            case 道纹Type.增加雷电伤害:
                return $"雷电伤害增幅<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";
            case 道纹Type.增加火焰伤害:
                return $"火焰伤害增幅<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";
            case 道纹Type.增加冰霜伤害:
                return $"冰霜伤害增幅<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.增加小怪伤害:
                return $"对小怪伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.增加精英怪和首领伤害:
                return $"对精英和首领伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.城墙低血增加伤害:
                return $"城墙血量低于30%时伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.击杀精英怪城墙回血:
                return $"击杀精英怪回复城墙<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>血量";

            case 道纹Type.城墙血量百分比:
                return $"增加城墙<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>血量";

            case 道纹Type.城墙免疫伤害:
                return $"城墙免疫<color=green>{val}</color>次伤害";

            case 道纹Type.城墙满血时加伤害:
                return $"城墙满血时伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.英雄暴击率:
                return $"英雄暴击率增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.伤害在范围内浮动:
                return $"伤害在<color=green>80%-{HeroConfig.Get技能伤害string(val,1)}</color>之间浮动";

            case 道纹Type.无视抗性:
                return $"无视敌人<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>抗性";

            case 道纹Type.战士对靠近城墙敌人伤害增高:
                return $"战士对靠近城墙的敌人增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>的伤害";
                ;

            case 道纹Type.射手对远距离敌人伤害增高:
                return $"射手对远距离敌人增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>的伤害";

            case 道纹Type.控制冷却缩减:
                return $"控制技能冷却缩减增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.法师暴击率:
                return $"法师暴击率增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.辅助被辅助英雄伤害增幅:
                return $"被辅助英雄伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            
            
            
            
            
            case 道纹Type.三味真火无视抗性百分比:
                return $"三味真火无视抗性<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.孙悟空每秒增加伤害:
                return $"孙悟空每秒增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>伤害";

            case 道纹Type.碧霄冰龙有概率再次释放:
                return $"碧霄冰龙有<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>概率再次释放";

            case 道纹Type.琼霄定身衰减效果减少:
                return $"琼霄定身衰减效果减少<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.云霄最终伤害:
                return $"云霄暴击率增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.后羿距离越远伤害越高:
                return $"后羿距离每增加1，伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.羲和灼烧伤害:
                return $"羲和灼烧伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.常曦有概率冻结敌人:
                return $"月华冰封阵有<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>概率冻结敌人";

            case 道纹Type.女娲增加被辅助冷却缩减:
                return $"被补天净化咒辅助英雄冷却缩减增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.通天每次暴击增加伤害:
                return $"通天每次暴击增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>伤害";

            case 道纹Type.老子旋风体积越大伤害越高:
                return $"老子太清玄冰风每增大<color=green>1%</color>体积，伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.元始每次释放有概率增加火种数量:
                return $"元始释放技能有<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>概率增加火种数量(最大为10)";

            case 道纹Type.鸿钧每释放陨石增加伤害:
                return $"鸿钧每释放一个陨石，伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            case 道纹Type.盘古每击杀敌人增加伤害:
                return $"盘古每击杀一个敌人，伤害增加<color=green>{HeroConfig.Get技能伤害string(val,1)}</color>";

            default:
                return "未知道纹";
        }
    }

    public static float Get道纹数值(道纹Type type)
    {
        float count = 0;
        foreach (var item in PlayerData.S.装备道纹List[EquipType.头盔])
        {
            if (item.道纹Type == type)
            {
                count += 道纹数值Dic[type][(int)(item.quality - 4)]/100f;
            }
        }
        foreach (var item in PlayerData.S.装备道纹List[EquipType.衣服])
        {
            if (item.道纹Type == type)
            {
                count += 道纹数值Dic[type][(int)(item.quality - 4)]/100f;
            }
        }
        foreach (var item in PlayerData.S.装备道纹List[EquipType.项链])
        {
            if (item.道纹Type == type)
            {
                count += 道纹数值Dic[type][(int)(item.quality - 4)]/100f;
            }
        }
        foreach (var item in PlayerData.S.装备道纹List[EquipType.鞋子])
        {
            if (item.道纹Type == type)
            {
                count += 道纹数值Dic[type][(int)(item.quality - 4)]/100f;
            }
        }
        foreach (var item in PlayerData.S.装备道纹List[EquipType.戒指])
        {
            if (item.道纹Type == type)
            {
                count += 道纹数值Dic[type][(int)(item.quality - 4)]/100f;
            }
        }
        foreach (var item in PlayerData.S.装备道纹List[EquipType.护手])
        {
            if (item.道纹Type == type)
            {
                count += 道纹数值Dic[type][(int)(item.quality - 4)]/100f;
            }
        }
        return count;
    }

    public static Dictionary<道纹Type, List<float>> 道纹数值Dic = new Dictionary<道纹Type, List<float>>()
    {
        { 道纹Type.增加百分比攻击力, new List<float>() { 5, 10, 15, 20, 30 } },
        { 道纹Type.增加战士伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加法师伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加控制伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加射手伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加小怪伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加物理伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加黑暗伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加冰霜伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加雷电伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加火焰伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.增加精英怪和首领伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.城墙低血增加伤害, new List<float>() { 15, 20, 30, 50, 80 } },
        { 道纹Type.击杀精英怪城墙回血, new List<float>() { 5, 10, 15, 20, 30 } },
        { 道纹Type.城墙血量百分比, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.城墙免疫伤害, new List<float>() { 3, 5, 8, 12, 20 } },
        { 道纹Type.城墙满血时加伤害, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.英雄暴击率, new List<float>() { 3, 5, 8, 12, 20 } },
        { 道纹Type.伤害在范围内浮动, new List<float>() { 30, 40, 50, 70, 100 } },
        { 道纹Type.无视抗性, new List<float>() { 5, 10, 15, 20, 30 } },
        { 道纹Type.战士对靠近城墙敌人伤害增高, new List<float>() { 15, 20, 30, 50, 80 } },
        { 道纹Type.射手对远距离敌人伤害增高, new List<float>() { 15, 20, 30, 50, 80 } },
        { 道纹Type.控制冷却缩减, new List<float>() { 5, 10, 15, 20, 30 } },
        { 道纹Type.法师暴击率, new List<float>() { 5, 10, 15, 20, 30 } },
        { 道纹Type.辅助被辅助英雄伤害增幅, new List<float>() { 15, 20, 30, 50, 80 } },
        
        
        
        
        { 道纹Type.三味真火无视抗性百分比, new List<float>() { 15, 20, 30, 50, 80 } },
        { 道纹Type.孙悟空每秒增加伤害, new List<float>() { 0.3f, 0.45f, 0.6f, 0.8f, 1 } },
        { 道纹Type.碧霄冰龙有概率再次释放, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.琼霄定身衰减效果减少, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.云霄最终伤害, new List<float>() { 15, 20, 30, 50, 80 } },
        { 道纹Type.后羿距离越远伤害越高, new List<float>() { 2, 4, 6, 8, 12 } },
        { 道纹Type.羲和灼烧伤害, new List<float>() { 15, 20, 30, 50, 80 } },
        { 道纹Type.常曦有概率冻结敌人, new List<float>() { 5, 10, 15, 20, 30 } },
        { 道纹Type.女娲增加被辅助冷却缩减, new List<float>() { 5, 10, 15, 20, 30 } },
        { 道纹Type.通天每次暴击增加伤害, new List<float>() { 0.3f, 0.45f, 0.6f, 0.8f, 1 } },
        { 道纹Type.老子旋风体积越大伤害越高, new List<float>() { 0.5f, 0.7f, 1f, 1.4f, 2 } },
        { 道纹Type.元始每次释放有概率增加火种数量, new List<float>() { 10, 15, 20, 30, 50 } },
        { 道纹Type.鸿钧每释放陨石增加伤害, new List<float>() { 1, 1.5f, 2, 3, 5 } },
        { 道纹Type.盘古每击杀敌人增加伤害, new List<float>() { 5, 10, 15, 20, 30 } }
    };

    public static Dictionary<道纹Type, string> 道纹名Dic = new Dictionary<道纹Type, string>()
    {
        { 道纹Type.增加百分比攻击力, "锋锐" },
        { 道纹Type.增加战士伤害, "战意" },
        { 道纹Type.增加法师伤害, "咒力" },
        { 道纹Type.增加控制伤害, "束魂" },
        { 道纹Type.增加射手伤害, "矢锋" },
        { 道纹Type.增加小怪伤害, "清道" },
        { 道纹Type.增加物理伤害, "破军" },
        { 道纹Type.增加黑暗伤害, "暗蚀" },
        { 道纹Type.增加雷电伤害, "雷霆" },
        { 道纹Type.增加火焰伤害, "焚烬" },
        { 道纹Type.增加冰霜伤害, "霜寒" },
        { 道纹Type.增加精英怪和首领伤害, "斩首" },
        { 道纹Type.城墙低血增加伤害, "绝命" },
        { 道纹Type.击杀精英怪城墙回血, "饮血" },
        { 道纹Type.城墙血量百分比, "固垒" },
        { 道纹Type.城墙免疫伤害, "不破" },
        { 道纹Type.城墙满血时加伤害, "恃强" },
        { 道纹Type.英雄暴击率, "致命" },
        { 道纹Type.伤害在范围内浮动, "无常" },
        { 道纹Type.无视抗性, "破法" },
        { 道纹Type.战士对靠近城墙敌人伤害增高, "镇关" },
        { 道纹Type.射手对远距离敌人伤害增高, "千里" },
        { 道纹Type.控制冷却缩减, "回响" },
        { 道纹Type.法师暴击率, "心炎" },
        { 道纹Type.辅助被辅助英雄伤害增幅, "扶摇" },
        { 道纹Type.三味真火无视抗性百分比, "焚天" },
        { 道纹Type.孙悟空每秒增加伤害, "齐天战意" },
        { 道纹Type.碧霄冰龙有概率再次释放, "冰龙回响" },
        { 道纹Type.琼霄定身衰减效果减少, "定身" },
        { 道纹Type.云霄最终伤害, "云破" },
        { 道纹Type.后羿距离越远伤害越高, "落日" },
        { 道纹Type.羲和灼烧伤害, "曦日灼" },
        { 道纹Type.常曦有概率冻结敌人, "寒月" },
        { 道纹Type.女娲增加被辅助冷却缩减, "补天" },
        { 道纹Type.通天每次暴击增加伤害, "截天" },
        { 道纹Type.老子旋风体积越大伤害越高, "玄风" },
        { 道纹Type.元始每次释放有概率增加火种数量, "始火" },
        { 道纹Type.鸿钧每释放陨石增加伤害, "鸿蒙陨" },
        { 道纹Type.盘古每击杀敌人增加伤害, "开天" }
    };
}
