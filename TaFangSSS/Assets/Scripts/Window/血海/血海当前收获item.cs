using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 血海当前收获item : MonoBehaviour
{
    [NonSerialized] public 灵药Type 灵药Type=灵药Type.None;
    [NonSerialized] public QualityType QualityType=QualityType.None;

    [NonSerialized] public int count;
    public Image bg;
    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Count;

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        image.sprite = ResourcesConfig.Get灵药Icon(灵药Type,QualityType);
        Name.text = 丹药Config.灵药名Dic[灵药Type];
        Count.text = count.ToString();
    }
}
