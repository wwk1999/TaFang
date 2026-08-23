using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 服用根基丹药英雄item : MonoBehaviour
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
    public GameObject gou;

    public void 服用根基丹药英雄item点击(object[] obj)
    {
        HeroType type=(HeroType)obj[0];
        gou.SetActive(type==HeroType);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("服用根基丹药英雄item点击",服用根基丹药英雄item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("服用根基丹药英雄item点击",服用根基丹药英雄item点击);

        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.服用根基丹药英雄 = HeroType;
            ObserverModuleManager.S.SendEvent("服用根基丹药英雄item点击",HeroType);
        });
    }

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[HeroType]);
        元素icon.sprite = ResourcesConfig.Get元素Sprite(HeroConfig.HeroZhiYeDic[HeroType].yuanSuType);
        职业icon.sprite = ResourcesConfig.Get职业icon(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        name.text = HeroConfig.HeroNameDic[HeroType];
        int level = PlayerData.S.HeroDataDic[HeroType].Level;
        xx1.gameObject.SetActive(level >= 2);
        xx2.gameObject.SetActive(level >= 3);
        xx3.gameObject.SetActive(level >= 4);
        xx4.gameObject.SetActive(level >= 5);
        xx5.gameObject.SetActive(level >= 6);
        image.sprite = ResourcesConfig.GetHeroSprite(HeroType);
        gou.SetActive(false);
    }
}
