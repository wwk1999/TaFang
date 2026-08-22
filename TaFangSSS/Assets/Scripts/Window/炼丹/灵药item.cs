using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵药item : MonoBehaviour
{
    [NonSerialized] public 灵药Type 灵药Type;
    [NonSerialized]public QualityType QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;

    public void SetItem()
    {
        if (灵药Type == 灵药Type.None)
        {
            icon.gameObject.SetActive(false);
            bg.sprite = ResourcesConfig.加号背景框1;
            name.text = "";
        }
        else
        {
            icon.gameObject.SetActive(true);
            icon.sprite=ResourcesConfig.Get灵药Icon(灵药Type, QualityType);
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            name.text = 丹药Config.灵药名Dic[灵药Type];
        }
    }
}
