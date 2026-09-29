using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 供奉数值信息弹窗 : MonoBehaviour
{
    public TextMeshProUGUI text;
    [NonSerialized]public 建筑Type type;

    public void SetItem()
    {
        text.text=道场Config.供奉数值Info[type];
    }
}
