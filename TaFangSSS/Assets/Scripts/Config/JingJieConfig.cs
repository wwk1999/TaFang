using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Config;
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


public class JingJieConfig : MonoBehaviour
{
    public static Dictionary<JingJieType, List<long>> 突破材料Dic = new Dictionary<JingJieType, List<long>>()
    {
        { JingJieType.练气, new List<long>() { 300, 500, 800, 1200, 2000, 3000, 5000, 10000 } },
        { JingJieType.筑基, new List<long>() { 1000, 2000, 3000, 5000, 10000, 20000, 30000, 50000 } },
        { JingJieType.金丹, new List<long>() { 3000, 5000, 8000, 12000, 20000, 30000, 50000, 100000 } },
        { JingJieType.元婴, new List<long>() { 10000, 20000, 30000, 50000, 100000, 200000, 300000, 500000 } },
        { JingJieType.化神, new List<long>() { 30000, 50000, 80000, 120000, 200000, 300000, 500000, 1000000 } },
        { JingJieType.合体, new List<long>() { 100000, 200000, 300000, 500000, 1000000, 2000000, 3000000, 5000000 } },
        { JingJieType.大乘, new List<long>() { 300000, 500000, 800000, 1200000, 2000000, 3000000, 5000000, 10000000 } },
        { JingJieType.天仙, new List<long>() { 1000000, 2000000, 3000000, 5000000, 10000000, 20000000, 30000000, 50000000 } },
        { JingJieType.玄仙, new List<long>() { 3000000, 5000000, 8000000, 12000000, 20000000, 30000000, 50000000, 100000000 } },
        { JingJieType.金仙, new List<long>() { 10000000, 20000000, 30000000, 50000000, 100000000, 200000000, 300000000, 500000000 } },
        { JingJieType.太乙金仙, new List<long>() { 30000000, 50000000, 80000000, 120000000, 200000000, 300000000, 500000000, 1000000000 } },
        { JingJieType.大罗金仙, new List<long>() { 100000000, 200000000, 300000000, 500000000, 1000000000, 2000000000, 3000000000, 5000000000 } },
        { JingJieType.准圣, new List<long>() { 300000000, 500000000, 800000000, 1200000000, 2000000000, 3000000000, 5000000000, 10000000000 } },
        { JingJieType.圣人, new List<long>() { 1000000000, 2000000000, 3000000000, 5000000000, 10000000000, 20000000000, 30000000000, 50000000000 } },
        { JingJieType.天道圣人, new List<long>() { 3000000000, 5000000000, 8000000000, 12000000000, 20000000000, 30000000000, 50000000000, 100000000000 } },
        { JingJieType.大道圣人, new List<long>() { 10000000000, 20000000000, 30000000000, 50000000000, 100000000000, 200000000000, 300000000000, 500000000000 } },
        { JingJieType.混元圣人, new List<long>() { 30000000000, 50000000000, 80000000000, 120000000000, 200000000000, 300000000000, 500000000000, 1000000000000 } },
    };
    public static Dictionary<QualityType, float> 突破跟脚Dic = new Dictionary<QualityType, float>()
    {
        { QualityType.黄品, 1f },
        { QualityType.玄品, 1.1f },
        { QualityType.地品, 1.3f },
        { QualityType.天品, 1.6f },
        { QualityType.宇品, 2f },
        { QualityType.宙品, 3f },
        { QualityType.洪品, 5f },
        { QualityType.荒品, 10f },
    };
    public static Dictionary<JingJieType, int> JingJieAttributeDic =
        new Dictionary<JingJieType, int>()

    {
        { JingJieType.练气,50},
        { JingJieType.筑基,80},
        { JingJieType.金丹,120},
        { JingJieType.元婴,180},
        { JingJieType.化神,250},
        { JingJieType.合体,400},
        { JingJieType.大乘,600},
        { JingJieType.天仙,900},
        { JingJieType.玄仙,1400},
        { JingJieType.金仙,2100},
        { JingJieType.太乙金仙,3000},
        { JingJieType.大罗金仙,5000},
        { JingJieType.准圣,8000},
        { JingJieType.圣人,12000},
        { JingJieType.天道圣人,20000},
        { JingJieType.大道圣人,30000},
        { JingJieType.混元圣人,50000},
        { JingJieType.鸿蒙,100000},
    };

    public static float  跟脚 => Get跟脚();
    public static float 轮回系数 => 1+属性config.总属性.轮回系数*100f;
    public static float  Get跟脚()
    {
        float value = PlayerData.S.初始跟脚;
        value *= (1f + 丹药Config.Get造化丹药总值() / 100f);
        foreach (var item in PlayerData.S.当前轮回突破Dic)
        {
            if (item.Value != QualityType.None)
            {
                value*=突破跟脚Dic[item.Value];
            }
        }

        return value;
    }
    public static Dictionary<JingJieType, float> 每年秒数Dic = new Dictionary<JingJieType, float>()
    {
        { JingJieType.练气,600f},
        { JingJieType.筑基,550f},
        { JingJieType.金丹,500f},
        { JingJieType.元婴,450f},
        { JingJieType.化神,400f},
        { JingJieType.合体,350f},
        { JingJieType.大乘,300f},
        { JingJieType.天仙,250f},
        { JingJieType.玄仙,220f},
        { JingJieType.金仙,180f},
        { JingJieType.太乙金仙,150f},
        { JingJieType.大罗金仙,120f},
        { JingJieType.准圣,100f},
        { JingJieType.圣人,80f},
        { JingJieType.天道圣人,60f},
        { JingJieType.大道圣人,45f},
        { JingJieType.混元圣人,30f},
        { JingJieType.鸿蒙,20f},
    }; 
    public static float 每年基础修为 = 200f;
    public static float Get每秒增加修为()
    {
        return MathF.Round(每年基础修为*(属性config.总修炼速度加成) / 每年秒数Dic[PlayerData.S.当前轮回境界], 1);
    }

    public static string Get大数值(float i)
    {
        float value = i;
        if (value > 10000)
        {
            value /= 1000;
            return value+"K";
        }
        return value.ToString();
    }
   
    public static float 每秒增加修为 => Get每秒增加修为();
    
    public static Dictionary<JingJieType, float> 升级需要年数Dic = new Dictionary<JingJieType, float>()
    {
        { JingJieType.练气,0.5f},
        { JingJieType.筑基,1},
        { JingJieType.金丹,2},
        { JingJieType.元婴,4},
        { JingJieType.化神,10},
        { JingJieType.合体,20},
        { JingJieType.大乘,30},
        { JingJieType.天仙,50},
        { JingJieType.玄仙,100},
        { JingJieType.金仙,150},
        { JingJieType.太乙金仙,200},
        { JingJieType.大罗金仙,300},
        { JingJieType.准圣,500},
        { JingJieType.圣人,1000},
        { JingJieType.天道圣人,2000},
        { JingJieType.大道圣人,5000},
        { JingJieType.混元圣人,10000},
        { JingJieType.鸿蒙,30000},
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
