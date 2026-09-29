using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 特性信息弹窗 : MonoBehaviour
{
    public TextMeshProUGUI text;
    [NonSerialized]public 供奉特性Type  供奉特性Type;
    [NonSerialized]public 供奉品质Type  供奉品质type;

    public void SetItem()
    {
        text.text = 道场Config.Get供奉特性Info(供奉特性Type, 供奉品质type);
    }
}
