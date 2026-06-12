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

public class JingJieAttribute
{
    public float Attack;
    public float CritDamage;
    public float FinalDamage;
}

public class JingJieConfig : MonoBehaviour
{
    public static Dictionary<JingJieType, JingJieAttribute> JingJieAttributeDic =
        new Dictionary<JingJieType, JingJieAttribute>()

    {
        { JingJieType.练气,new JingJieAttribute(){Attack = 10}},
        { JingJieType.筑基,new JingJieAttribute(){Attack = 20}},
        { JingJieType.金丹,new JingJieAttribute(){Attack = 40}},
        { JingJieType.元婴,new JingJieAttribute(){Attack = 70}},
        { JingJieType.化神,new JingJieAttribute(){Attack = 120}},
        { JingJieType.合体,new JingJieAttribute(){Attack = 180}},
        { JingJieType.大乘,new JingJieAttribute(){Attack = 250}},
        { JingJieType.天仙,new JingJieAttribute(){Attack = 350,CritDamage = 10}},
        { JingJieType.玄仙,new JingJieAttribute(){Attack = 500,CritDamage = 15}},
        { JingJieType.金仙,new JingJieAttribute(){Attack = 700,CritDamage = 20}},
        { JingJieType.太乙金仙,new JingJieAttribute(){Attack = 1000,CritDamage = 25}},
        { JingJieType.大罗金仙,new JingJieAttribute(){Attack = 1500,CritDamage = 30}},
        { JingJieType.准圣,new JingJieAttribute(){Attack = 2000,CritDamage = 35}},
        { JingJieType.圣人,new JingJieAttribute(){Attack = 3000,CritDamage = 50,FinalDamage = 10}},
        { JingJieType.天道圣人,new JingJieAttribute(){Attack = 5000,CritDamage = 60,FinalDamage = 20}},
        { JingJieType.大道圣人,new JingJieAttribute(){Attack = 10000,CritDamage = 70,FinalDamage = 30}},
        { JingJieType.混元圣人,new JingJieAttribute(){Attack = 20000,CritDamage = 80,FinalDamage = 40}},
        { JingJieType.鸿蒙,new JingJieAttribute(){Attack = 50000,CritDamage = 100,FinalDamage = 60}},
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
