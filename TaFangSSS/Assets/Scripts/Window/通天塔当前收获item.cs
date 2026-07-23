using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 通天塔当前收获item : MonoBehaviour
{
    [NonSerialized] public 城墙道具Type 城墙道具Type;
    [NonSerialized] public int count;
    public Image bg;
    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Count;

    public void SetItem()
    {
        QualityType qualityType = 城墙Config.城墙道具QualityDic[城墙道具Type];
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(qualityType);
        image.sprite = ResourcesConfig.Get城墙Sprite(城墙道具Type);
        Name.text = 城墙Config.城墙道具名Dic[城墙道具Type];
        Count.text = count.ToString();
    }
}
