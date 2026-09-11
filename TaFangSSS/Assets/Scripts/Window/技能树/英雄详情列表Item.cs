using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 英雄详情列表Item : MonoBehaviour
{
    public Button bg;
    public Image image;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 职业;
    public TextMeshProUGUI 元素;
    public TextMeshProUGUI 境界;

    [NonSerialized] public HeroType HeroType;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("英雄详情英雄点击",HeroType);
        });
    }

    public void SetItem()
    {
        bg.image.sprite=ResourcesConfig.Get英雄背景框(HeroConfig.HeroQualityDic[HeroType]);
        image.sprite=ResourcesConfig.GetHeroSprite(HeroType);
        name.text = HeroConfig.HeroNameDic[HeroType];
        职业.text = HeroConfig.Get职业Name(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        境界.text = 英雄技能树Config.Get英雄境界String(英雄技能树Config.Get英雄境界Type(PlayerData.S.HeroDataDic[HeroType].境界));
        switch (HeroConfig.HeroZhiYeDic[HeroType].yuanSuType)
        {
            case YuanSuType.冰:
                元素.text = "冰霜";
                break;
            case YuanSuType.黑暗:
                元素.text = "黑暗";
                break;
            case YuanSuType.火:
                元素.text = "火焰";
                break;
            case YuanSuType.物理:
                元素.text = "物理";
                break;
            case YuanSuType.电:
                元素.text = "雷电";
                break;
        }
    }
}
