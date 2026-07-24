using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 血海英雄派遣弹窗item : MonoBehaviour
{
    [NonSerialized] public QualityType 需要品质;
    [NonSerialized] public int 需要星级;
    [NonSerialized] public YuanSuType 需要元素;
    [NonSerialized] public ZhiYeType 需要职业;
    [NonSerialized] public HeroType HeroType;
    public Button bg;
    public GameObject mask;
    public TextMeshProUGUI maskText;
    public Image gou;
    public Image image;
    public Image 元素icon;
    public Image 职业icon;
    public TextMeshProUGUI name;
    public Image xx1;
    public Image xx2;
    public Image xx3;
    public Image xx4;
    public Image xx5;

    public void 点击(object[] obj)
    {
        HeroType heroType = (HeroType)obj[0];   
        HeroWindowController.S.血海当前选择派遣HeroType = heroType;
        if (heroType == HeroType)
        {
            gou.gameObject.SetActive(true);
        }
        else
        {
            gou.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("点击",点击);
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("点击",点击);
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("点击",HeroType);
        });
    }

    public void SetItem()
    {
        mask.SetActive(false);
        gou.gameObject.SetActive(false);
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[HeroType]);
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
        if (PlayerData.S.HeroDataDic[HeroType].派遣)
        {
            mask.SetActive(true);
            maskText.text = "派遣中";
        }else if ((需要品质!=QualityType.None&&HeroConfig.HeroQualityDic[HeroType] < 需要品质) || PlayerData.S.HeroDataDic[HeroType].Level < 需要星级 + 1 ||
                  (需要元素 != YuanSuType.None && 需要元素 != HeroConfig.HeroZhiYeDic[HeroType].yuanSuType) ||
                  (需要职业 != ZhiYeType.None && 需要职业 != HeroConfig.HeroZhiYeDic[HeroType].zhiYeType))
        {
            mask.SetActive(true);
            maskText.text = "条件不符合";
        }
    }
}
