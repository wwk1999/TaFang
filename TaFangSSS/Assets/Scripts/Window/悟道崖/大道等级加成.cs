using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 大道等级加成 : MonoBehaviour
{
    public TextMeshProUGUI desc;
    [NonSerialized]public 大道Type type;

    public void SetItem()
    {
        string str1="";
        string str2="";
        大道等级Type 大道等级 = 悟道崖Config.大道配置[type].大道等级Type;
        var 奖励 = 悟道崖Config.大道等级奖励[大道等级];
        switch (奖励.大道等级固定奖励Type)
        {
            case 大道等级固定奖励Type.伤害增幅:
                str1 = "伤害增幅";
                break;
            case 大道等级固定奖励Type.跟脚:
                str1 = "跟脚";
                break;
            case 大道等级固定奖励Type.真灵:
                str1 = "真灵";
                break;
        }

        str2 = 奖励.count + "%";
        desc.text=str1 +"+"+ str2;
    }
}
