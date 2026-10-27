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
    public Image 锁;
    public void SetItem()
    {
        if (符文.锁)
        {
            锁.gameObject.SetActive(true);
            锁.sprite = ResourcesConfig.锁;
        }
        else
        {
            锁.gameObject.SetActive(false);
            锁.sprite = ResourcesConfig.解锁;
        }
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
        icon.sprite = ResourcesConfig.Get符文Sprite(符文.type,符文.quality);
        艺术字.sprite = ResourcesConfig.Get艺术字(符文.quality);
        name.text = 符文Config.符文名Dic[符文.type];
    }
}
