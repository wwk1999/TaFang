using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 神通配置英雄item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 能量;
    public TextMeshProUGUI cd;
    public GameObject gou;

    [NonSerialized] public HeroType HeroType;
    public void SetItem()
    {
        if (HeroType == HeroType.None) return;
        bg.image.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[HeroType]);
        icon.sprite=ResourcesConfig.GetHeroSprite(HeroType);
        name.text=HeroConfig.HeroNameDic[HeroType];
        能量.text = HeroConfig.英雄神通配置Dic[HeroType].能量.ToString();
        cd.text = HeroConfig.英雄神通配置Dic[HeroType].能量.ToString();
        gou.SetActive(false);
    }

    public void 神通配置item点击(object[] obj)
    {
        HeroType heroType = (HeroType)obj[0];
        gou.SetActive(heroType==HeroType);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("神通配置item点击",神通配置item点击);
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("神通配置item点击",神通配置item点击);
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前神通配置选择英雄 = HeroType;
            ObserverModuleManager.S.SendEvent("神通配置item点击",HeroType);
        });
    }
}
