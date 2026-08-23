using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵药grid : MonoBehaviour
{
    [NonSerialized] public 灵药Type 灵药Type;
    [NonSerialized] public QualityType QualityType;
    public Image bg;
    public Image icon;
    public Image 艺术字;
    public TextMeshProUGUI name;
    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get灵药Icon(灵药Type,QualityType);
        艺术字.sprite = ResourcesConfig.Get艺术字(QualityType);
        name.text = 丹药Config.灵药名Dic[灵药Type];
    }
}
