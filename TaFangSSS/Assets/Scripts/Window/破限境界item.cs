using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 破限境界item : MonoBehaviour
{
    public Button bg;
    public TextMeshProUGUI name;
    [NonSerialized]public JingJieType jingJieType;

    public void SetItem()
    {
        name.text = JingJieConfig.JingJieNameDic[jingJieType];
        if (HeroWindowController.S.破限弹窗境界 == jingJieType)
        {
            bg.image.sprite = ResourcesConfig.破限按钮亮;
        }
        else
        {
            bg.image.sprite = ResourcesConfig.破限按钮暗;
        }
    }

    public void 破限境界item点击(object[] obj)
    {
        if (HeroWindowController.S.破限弹窗境界 == jingJieType)
        {
            bg.image.sprite = ResourcesConfig.破限按钮亮;
        }
        else
        {
            bg.image.sprite = ResourcesConfig.破限按钮暗;
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("破限境界item点击",破限境界item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("破限境界item点击",破限境界item点击);
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.破限弹窗境界=jingJieType;
            ObserverModuleManager.S.SendEvent("破限境界item点击");
        });
    }
}
