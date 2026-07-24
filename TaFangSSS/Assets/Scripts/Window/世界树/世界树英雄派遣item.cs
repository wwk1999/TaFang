using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 世界树英雄派遣item : MonoBehaviour
{
    [NonSerialized] public HeroType HeroType;
    [NonSerialized] public int index;
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
    public GameObject mask;
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("世界树英雄派遣Item刷新",世界树英雄派遣Item刷新);
    }
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("世界树英雄派遣Item刷新",世界树英雄派遣Item刷新);
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.世界树英雄派遣Index = index;
            ObserverModuleManager.S.SendEvent("显示世界树英雄派遣弹窗");
        });
    }

    public void 世界树英雄派遣Item刷新(object[] obj)
    {
        SetItem();
    }

    public void SetItem()
    {
        mask.SetActive(PlayerData.S.世界树寻宝Dic[HeroWindowController.S.当前世界树层数].寻宝);
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
