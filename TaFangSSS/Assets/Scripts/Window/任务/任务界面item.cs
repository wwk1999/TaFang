using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 任务界面item : MonoBehaviour
{
    public GameObject 已完成;
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public Button bg;
    [NonSerialized] public 任务Type 任务Type;

    public void 任务界面item点击(object[] obj)
    {
        SetItem();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("任务界面item点击",任务界面item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("任务界面item点击",任务界面item点击);
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前显示任务Type = 任务Type;
            ObserverModuleManager.S.SendEvent("任务界面item点击");
        });
    }

    public void SetItem()
    {
        已完成.SetActive(PlayerData.S.任务完成字典[任务Type]);
        任务类型 任务类型 = 任务Config.任务配置[任务Type].任务类型;
        string 类型 = 任务类型 == 任务类型.主线任务 ? "[主线]" : "[支线]";
        name.text = 类型 + 任务Config.任务配置[任务Type].任务名;
        desc.text = 任务Config.任务配置[任务Type].任务目标;
        if (任务Type == HeroWindowController.S.当前显示任务Type)
        {
            bg.image.sprite = ResourcesConfig.建筑item亮;
        }
        else
        {
            bg.image.sprite = ResourcesConfig.建筑item暗;
        }
    }
}
