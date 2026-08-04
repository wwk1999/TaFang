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
    public static Dictionary<JingJieType, List<int>> 突破材料Dic = new Dictionary<JingJieType, List<int>>()
    {
        { JingJieType.练气, new List<int>() { 100, 120, 150, 200, 300 } },
        { JingJieType.筑基, new List<int>() { 200, 240, 300, 400, 600 } },
        { JingJieType.金丹, new List<int>() { 400, 480, 600, 800, 1200 } },
        { JingJieType.元婴, new List<int>() { 800, 960, 1200, 1600, 2400 } },
        { JingJieType.化神, new List<int>() { 1600, 1920, 2400, 3200, 4800 } },
        { JingJieType.合体, new List<int>() { 3200, 3840, 4800, 6400, 9600 } },
        { JingJieType.大乘, new List<int>() { 6000, 8000, 10000, 13000, 20000 } },
        { JingJieType.天仙, new List<int>() { 13000, 15000, 20000, 25000, 38000 } },
        { JingJieType.玄仙, new List<int>() { 25000, 30000, 38000, 50000, 75000 } },
        { JingJieType.金仙, new List<int>() { 50000, 60000, 75000, 100000, 150000 } },
        { JingJieType.太乙金仙, new List<int>() { 100000, 120000, 150000, 200000, 300000 } },
        { JingJieType.大罗金仙, new List<int>() { 200000, 250000, 300000, 400000, 600000 } },
        { JingJieType.准圣, new List<int>() { 400000, 500000, 600000, 800000, 1200000 } },
        { JingJieType.圣人, new List<int>() { 800000, 100000, 1200000, 1600000, 2500000 } },
        { JingJieType.天道圣人, new List<int>() { 1600000, 2000000, 2500000, 3200000, 5000000 } },
        { JingJieType.大道圣人, new List<int>() { 3200000, 4000000, 5000000, 6500000,  10000000 } },
        { JingJieType.混元圣人, new List<int>() { 6500000, 8000000, 10000000, 13000000, 20000000 } },
    };
    public static Dictionary<突破Type, float> 突破跟脚Dic = new Dictionary<突破Type, float>()
    {
        { 突破Type.凡, 1f },
        { 突破Type.灵, 1.1f },
        { 突破Type.仙, 1.2f },
        { 突破Type.圣, 1.3f },
        { 突破Type.荒, 1.4f },

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

    public static float 跟脚 => Get跟脚();

    public static float Get跟脚()
    {
        float value = 1;
        foreach (var item in PlayerData.S.突破Dic)
        {
            if (item.Value != 突破Type.None)
            {
                value*=JingJieConfig.突破跟脚Dic[item.Value];
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
        return MathF.Round(每年基础修为*(1f+属性config.总修炼速度加成/100f) / 每年秒数Dic[PlayerData.S.JingJieType], 1);
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
   
    public static float 每秒增加修为 = Get每秒增加修为();
    
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
