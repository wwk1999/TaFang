using System;
using System.Collections.Generic;
using Config;

public enum 当前显示关卡类型
{
    None,
    主线关卡,
    凌霄宝殿,
    三十三重天,
    混沌虚空,
    不周山,
    世界树,
    通天塔,
    血海,
}
public class HeroWindowController:XSingleton<HeroWindowController>
{
    [NonSerialized] public 功法Type 当前选择功法 = 功法Type.None;

    //herowindow
    [NonSerialized] public bool IsDrag = false;
    [NonSerialized] public bool IsJiaoHuan = false;
    [NonSerialized] public HeroType DragHero = HeroType.None;
    [NonSerialized]public HeroItem 交换HeroItem;
    
    //道纹
    [NonSerialized]public bool 道纹IsDrag = false;
    [NonSerialized] public 道纹Type 道纹Type;
    [NonSerialized] public QualityType 道纹QualityType;

    [NonSerialized] public 当前显示关卡类型 当前显示关卡类型;
    [NonSerialized] public 主线关卡Type 当前主线关卡Type;
    [NonSerialized] public 主线关卡Type 当前凌霄宝殿Type;
    [NonSerialized] public 主线关卡Type 当前三十三重天Type;

    [NonSerialized] public int 显示混沌虚空层数 = 0; 

    //城墙
    [NonSerialized]public bool 城墙IsDrag = false;
    [NonSerialized] public 城墙道具Type 城墙道具Type;
    //通天塔
    [NonSerialized] public int 当前通天塔层数;
    [NonSerialized]public HeroType 通天塔当前选择派遣HeroType;
    [NonSerialized] public int 通天塔英雄派遣Index;
    
    //世界树
    [NonSerialized] public int 当前世界树层数;
    [NonSerialized]public HeroType 世界树当前选择派遣HeroType;
    [NonSerialized] public int 世界树英雄派遣Index;
    
    //血海
    [NonSerialized] public int 当前血海层数;
    [NonSerialized]public HeroType 血海当前选择派遣HeroType;
    [NonSerialized] public int 血海英雄派遣Index;
    
    //不周山
    [NonSerialized] public int 当前不周山层数;
    [NonSerialized]public HeroType 不周山当前选择派遣HeroType;
    [NonSerialized] public int 不周山英雄派遣Index;

    [NonSerialized] public bool 仙石拖拽 = false;
    [NonSerialized] public 仙石 仙石 = null;
    [NonSerialized] public 法器 仙石镶嵌panel当前法器 = null;
    [NonSerialized] public 法器 洗练panel当前法器 = null;
    [NonSerialized] public List<法器附加属性值> 洗练后词条 = null;
    [NonSerialized] public 仙石 重铸panel当前仙石 = null;
    [NonSerialized] public List<法器附加属性值> 仙石重铸后词条 = null;
    [NonSerialized] public 仙石Type 重铸后仙石Type;
    
    [NonSerialized]public 神物Type 当前遗迹关卡Type=神物Type.None;
    
    
    [NonSerialized] public 丹药Type 当前炼丹显示Type;
    [NonSerialized] public QualityType 当前炼丹显示QualityType;
    [NonSerialized] public HeroType 服用根基丹药英雄;
    
    
    [NonSerialized] public 丹药Type 当前选择丹药Type;
    [NonSerialized] public QualityType 当前选择丹药QualityType;

    
    [NonSerialized] public HeroType 当前神通配置选择英雄;

    [NonSerialized] public 法器 英雄详情界面当前选择法器;
    [NonSerialized] public 附加属性Type 当前选择排序类型;

    //法器的基础属性包含在最终伤害里
    public List<法器> Get排序法器(法器类型 法器类型, 附加属性Type 附加属性Type)
    {
        List<法器> list = new List<法器>();
        foreach (var item in PlayerData.S.法器列表)
        {
            if (法器Config.法器类型Dic[item.法器Type] == 法器类型)
            {
                list.Add(item);
            }
        }

        法器附加属性Type 对应法器属性 = 映射到法器附加属性Type(附加属性Type);

        list.Sort((a, b) =>
        {
            float sumA = 获取法器属性值(a, 对应法器属性);
            float sumB = 获取法器属性值(b, 对应法器属性);
            return sumB.CompareTo(sumA);
        });

        return list;
    }

    /// <summary>
    /// 装备附加属性类型 → 法器附加属性类型 的名称映射（两者枚举值不完全相同）
    /// </summary>
    private 法器附加属性Type 映射到法器附加属性Type(附加属性Type type)
    {
        switch (type)
        {
            case 附加属性Type.暴击率: return 法器附加属性Type.暴击率;
            case 附加属性Type.最终伤害: return 法器附加属性Type.最终伤害;
            case 附加属性Type.物理伤害: return 法器附加属性Type.物理伤害;
            case 附加属性Type.火焰伤害: return 法器附加属性Type.火焰伤害;
            case 附加属性Type.冰霜伤害: return 法器附加属性Type.冰霜伤害;
            case 附加属性Type.雷电伤害: return 法器附加属性Type.雷电伤害;
            case 附加属性Type.黑暗伤害: return 法器附加属性Type.黑暗伤害;
            case 附加属性Type.普通怪伤害增幅: return 法器附加属性Type.普通怪增伤;
            case 附加属性Type.精英怪伤害增幅: return 法器附加属性Type.精英怪增伤;
            case 附加属性Type.首领伤害增幅: return 法器附加属性Type.首领怪增伤;
            default: return 法器附加属性Type.None;
        }
    }

    /// <summary>
    /// 从法器聚合属性中取出单一属性的数值（含仙石加成，与战斗口径一致）
    /// </summary>
    private float 获取法器属性值(法器 法器, 法器附加属性Type type)
    {
        if (type == 法器附加属性Type.None) return 0f;
        法器属性 属性 = 法器Config.Get法器属性(法器);
        switch (type)
        {
            case 法器附加属性Type.暴击率: return 属性.暴击率;
            case 法器附加属性Type.暴击伤害: return 属性.暴击伤害;
            case 法器附加属性Type.火焰伤害: return 属性.火焰伤害;
            case 法器附加属性Type.雷电伤害: return 属性.雷电伤害;
            case 法器附加属性Type.黑暗伤害: return 属性.黑暗伤害;
            case 法器附加属性Type.冰霜伤害: return 属性.冰霜伤害;
            case 法器附加属性Type.物理伤害: return 属性.物理伤害;
            case 法器附加属性Type.最终伤害: return 属性.最终伤害;
            case 法器附加属性Type.普通怪增伤: return 属性.普通怪增伤;
            case 法器附加属性Type.精英怪增伤: return 属性.精英怪增伤;
            case 法器附加属性Type.首领怪增伤: return 属性.首领怪增伤;
            case 法器附加属性Type.火焰穿透: return 属性.火焰穿透;
            case 法器附加属性Type.雷电穿透: return 属性.雷电穿透;
            case 法器附加属性Type.物理穿透: return 属性.物理穿透;
            case 法器附加属性Type.冰霜穿透: return 属性.冰霜穿透;
            case 法器附加属性Type.黑暗穿透: return 属性.黑暗穿透;
            default: return 0f;
        }
    }

}
