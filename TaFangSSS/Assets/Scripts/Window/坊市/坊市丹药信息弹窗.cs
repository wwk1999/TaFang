using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 坊市丹药信息弹窗 : MonoBehaviour
{
    [NonSerialized]public 丹药Type 丹药Type;
    [NonSerialized] public QualityType 丹药QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI info;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(丹药QualityType);
        icon.sprite = ResourcesConfig.Get丹方icon(丹药Type, 丹药QualityType);
        name.text = 丹药Config.丹方名Dic[丹药Type];
        类型.text = 丹药Config.丹药类型String[丹药Config.丹药类型Dic[丹药Type]];
        info.text = 丹药Config.Get丹药Desc(丹药Type,丹药QualityType);
    }
}
