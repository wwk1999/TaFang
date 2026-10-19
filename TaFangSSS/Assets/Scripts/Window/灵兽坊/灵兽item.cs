using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public Image 性别;
    public Image 锁;
    public GameObject gou;
    public GameObject 头像;
    public Image 头像Image;
    [NonSerialized] public 灵兽 灵兽;

    public void 灵兽Item点击(object[] obj)
    {
        灵兽 item = obj[0] as 灵兽;
        if (item != null && 灵兽 == item)
        {
            gou.SetActive(true);
        }
        else
        {
            gou.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("灵兽Item点击",灵兽Item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("灵兽Item点击",灵兽Item点击);
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前选择灵兽 = 灵兽;
            ObserverModuleManager.S.SendEvent("灵兽Item点击",灵兽);
        });
    }

    public void SetItem()
    {
        gou.SetActive(false);
        头像.SetActive(灵兽.HeroType!=HeroType.None);
        头像Image.sprite = ResourcesConfig.GetHeroSprite(灵兽.HeroType);
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(灵兽.QualityType);
        icon.sprite = ResourcesConfig.Get灵兽Sprite(灵兽.灵兽Type);
        name.text = 灵兽坊Config.灵兽名[灵兽.灵兽Type];
        if (灵兽.性别 == global::性别.母)
        {
            性别.sprite = ResourcesConfig.母;
        }
        else
        {
            性别.sprite = ResourcesConfig.公;
        }
        锁.gameObject.SetActive(灵兽.锁);
    }
    
}
