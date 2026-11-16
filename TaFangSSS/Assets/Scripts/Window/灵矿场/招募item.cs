using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 招募item : MonoBehaviour
{
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI 标签;
    public Image icon;
    public Image bg;
    public TextMeshProUGUI 挖掘速度;
    public TextMeshProUGUI 固定收益;
    public TextMeshProUGUI 成长速度;
    public TextMeshProUGUI 挖宝速度;
    public GameObject 词条列表;
    public TextMeshProUGUI 灵魂;
    public Button 招募Button;
    [NonSerialized] public 矿工 矿工;

    public void SetItem()
    {
        类型.text = 灵矿场Config.矿工类型string[矿工.矿工类型];
        标签.text = PlayerData.S.Get阶数string(矿工.阶数) + "·" + 灵矿场Config.矿工品质string[矿工.QualityType];
        
    }
}
