using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 英雄派遣item : MonoBehaviour
{
    [NonSerialized] public HeroType HeroType;
    public Image 元素icon;
    public Image 职业icon;
    public TextMeshProUGUI name;
    public Image xx1;
    public Image xx2;
    public Image xx3;
    public Image xx4;
    public Image xx5;
    public Image image;
    public Button bg;
    public GameObject content;

    public void SetItem()
    {
        if (HeroType == HeroType.None)
        {
            bg.image.sprite = ResourcesConfig.加号背景框;
            content.SetActive(false);
        }
        else
        {
            bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[HeroType]);
            content.SetActive(true);
            元素icon.sprite=ResourcesConfig.Get元素Sprite(HeroConfig.HeroZhiYeDic[HeroType].yuanSuType);
            职业icon.sprite = ResourcesConfig.Get职业icon(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
            name.text=HeroConfig.HeroNameDic[HeroType];
            int level=PlayerData.S.HeroDataDic[HeroType].Level;
            xx1.gameObject.SetActive(level>=2);
            xx2.gameObject.SetActive(level>=3);
            xx3.gameObject.SetActive(level>=4);
            xx4.gameObject.SetActive(level>=5);
            xx5.gameObject.SetActive(level>=6);
            image.sprite=ResourcesConfig.GetHeroSprite(HeroType);
        }
    }
}
