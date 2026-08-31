using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 神通配置item : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    [NonSerialized] public HeroType HeroType;
    public void SetItem()
    {
        if (HeroType == HeroType.None) return;
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[HeroType]);
        icon.sprite=ResourcesConfig.GetHeroSprite(HeroType);
        name.text=HeroConfig.HeroNameDic[HeroType];
    }
}
