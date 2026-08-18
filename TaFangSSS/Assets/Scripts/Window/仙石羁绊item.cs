using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 仙石羁绊item : MonoBehaviour
{
    [NonSerialized] public 仙石Type 仙石Type;
    [NonSerialized] public int 数量;
    public TextMeshProUGUI text;
    public TextMeshProUGUI info;

    public void SetItem()
    {
        text.text = 仙石Config.仙石名Dic[仙石Type] + "（" + 数量 + "）";
        info.text = "宝石效果+" + 仙石Config.仙石羁绊效果Dic[数量] + "%";
    }
}
