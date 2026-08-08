using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 伤害面板item : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public Slider slider;
    public TextMeshProUGUI count;
    public TextMeshProUGUI 比例text;

    [NonSerialized]public HeroType heroType;
    [NonSerialized]public float 比例;
    [NonSerialized] public float damage;

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[heroType]);
        icon.sprite=ResourcesConfig.GetHeroSprite(heroType);
        slider.value = 比例;
        比例text.text=(int)(比例*100)+"%";
        count.text = PlayerData.S.格式化数字(damage);
    }
}
