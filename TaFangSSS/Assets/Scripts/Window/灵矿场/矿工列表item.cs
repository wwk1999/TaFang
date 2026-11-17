using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工列表item : MonoBehaviour
{
    public Button bg;
    public TextMeshProUGUI name;
    [NonSerialized] public int 阶数;

    public void 矿工列表item点击(object[] obj)
    {
        SetItem();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("矿工列表item点击",矿工列表item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("矿工列表item点击",矿工列表item点击);
        bg.onClick.AddListener(() =>
        {
            if (阶数 > 灵矿场Config.矿工阶数上限配置[PlayerData.S.矿洞矿工阶数等级].阶数)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","矿洞等级不足");
                return;
            }
            HeroWindowController.S.灵矿场当前招募阶数 = 阶数;
            ObserverModuleManager.S.SendEvent("矿工列表item点击");
        });
    }

    public void SetItem()
    {
        name.text = PlayerData.S.Get阶数string(阶数);
        if (HeroWindowController.S.灵矿场当前招募阶数 == 阶数)
        {
            bg.image.sprite = ResourcesConfig.灵矿场按钮亮;
            name.color = Color.white;
        }
        else
        {
            bg.image.sprite = ResourcesConfig.灵矿场按钮暗;
            name.color = Color.black;
        }
    }
}
