using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JingJieType
{
    None,
    练气,
    筑基,
    金丹,
    元婴,
    化神,
    合体,
    大乘,
    天仙,
    玄仙,
    金仙,
    太乙金仙,
    大罗金仙,
    准圣,
    圣人,
    天道圣人,    
    大道圣人,
    混元圣人,
    鸿蒙,
}

public enum 突破Type
{
    None,
    凡,
    灵,
    仙,
    圣,
    荒,
}

public class JingJieConfig : MonoBehaviour
{
    public static Dictionary<突破Type, float> 突破跟脚Dic = new Dictionary<突破Type, float>()
    {
        { 突破Type.凡, 1f },
        { 突破Type.灵, 1.1f },
        { 突破Type.仙, 1.2f },
        { 突破Type.圣, 1.3f },
        { 突破Type.荒, 1.5f },

    };
    public static Dictionary<JingJieType, int> JingJieAttributeDic =
        new Dictionary<JingJieType, int>()

    {
        { JingJieType.练气,10},
        { JingJieType.筑基,20},
        { JingJieType.金丹,40},
        { JingJieType.元婴,70},
        { JingJieType.化神,120},
        { JingJieType.合体,200},
        { JingJieType.大乘,300},
        { JingJieType.天仙,500},
        { JingJieType.玄仙,800},
        { JingJieType.金仙,1200},
        { JingJieType.太乙金仙,1800},
        { JingJieType.大罗金仙,3000},
        { JingJieType.准圣,5000},
        { JingJieType.圣人,8000},
        { JingJieType.天道圣人,12000},
        { JingJieType.大道圣人,20000},
        { JingJieType.混元圣人,30000},
        { JingJieType.鸿蒙,50000},
    };
    
    
    public static Dictionary<JingJieType, int> JingJieExpDic =
        new Dictionary<JingJieType, int>()

        {
            { JingJieType.练气,100},
            { JingJieType.筑基,200},
            { JingJieType.金丹,500},
            { JingJieType.元婴,1000},
            { JingJieType.化神,2000},
            { JingJieType.合体,3000},
            { JingJieType.大乘,5000},
            { JingJieType.天仙,10000},
            { JingJieType.玄仙,15000},
            { JingJieType.金仙,20000},
            { JingJieType.太乙金仙,30000},
            { JingJieType.大罗金仙,40000},
            { JingJieType.准圣,50000},
            { JingJieType.圣人,100000},
            { JingJieType.天道圣人,150000},
            { JingJieType.大道圣人,200000},
            { JingJieType.混元圣人,250000},
            { JingJieType.鸿蒙,500000},
        };
    
    
    public static Dictionary<JingJieType, string> JingJieNameDic = 
        new Dictionary<JingJieType, string>()
        {
            { JingJieType.练气, "练气" },
            { JingJieType.筑基, "筑基" },
            { JingJieType.金丹, "金丹" },
            { JingJieType.元婴, "元婴" },
            { JingJieType.化神, "化神" },
            { JingJieType.合体, "合体" },
            { JingJieType.大乘, "大乘" },
            { JingJieType.天仙, "天仙" },
            { JingJieType.玄仙, "玄仙" },
            { JingJieType.金仙, "金仙" },
            { JingJieType.太乙金仙, "太乙金仙" },
            { JingJieType.大罗金仙, "大罗金仙" },
            { JingJieType.准圣, "准圣" },
            { JingJieType.圣人, "圣人" },
            { JingJieType.天道圣人, "天道圣人" },
            { JingJieType.大道圣人, "大道圣人" },
            { JingJieType.混元圣人, "混元圣人" },
            { JingJieType.鸿蒙, "鸿蒙" }
        };
}
