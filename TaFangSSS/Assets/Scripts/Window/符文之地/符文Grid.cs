using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文Grid : MonoBehaviour
{
    [NonSerialized] public 符文 符文;
    public Image bg;
    public Image icon;
    public Image 艺术字;
    public TextMeshProUGUI name;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
        icon.sprite = ResourcesConfig.Get符文Sprite(符文.type,符文Config.Quality对应符文品质[符文.quality]);
        艺术字.sprite = ResourcesConfig.Get艺术字(符文.quality);
        name.text = 符文Config.符文名Dic[符文.type];
    }
}
