using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 神物Grid : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI name;
    public Image bg;
    [NonSerialized]public 神物Type type;
    public void SetItem()
    {
        image.sprite = ResourcesConfig.Get神物Icon(type);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.宇品);
        name.text = 神物Config.神物名Dic[type];
    }
}
