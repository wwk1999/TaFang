using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工词条item : MonoBehaviour
{
    public Image bg;
    public TextMeshProUGUI name;
    [NonSerialized] public 矿工词条类型 矿工词条类型;
    [NonSerialized]public QualityType quality;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get供奉特性标签(quality);
        name.text = 灵矿场Config.矿工词条名[矿工词条类型];
    }
}
