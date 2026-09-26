using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class 品质概率item : MonoBehaviour
{
    public TextMeshProUGUI text;
    [NonSerialized] public string 品质;
    [NonSerialized] public float 概率;

    public void SetItem()
    {
        text.text = 品质 + "：" + 概率 + "%";
    }

}
