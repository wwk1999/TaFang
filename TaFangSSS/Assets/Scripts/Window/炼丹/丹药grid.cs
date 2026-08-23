using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹药grid : MonoBehaviour
{
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType QualityType;
    public Image bg;
    public Image icon;
    public Image 艺术字;
    public TextMeshProUGUI name;
    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type,QualityType);
        艺术字.sprite = ResourcesConfig.Get艺术字(QualityType);
        name.text = 丹药Config.丹药名Dic[丹药Type];
    }
}