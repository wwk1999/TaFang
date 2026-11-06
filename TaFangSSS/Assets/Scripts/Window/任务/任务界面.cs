using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 任务界面 : MonoBehaviour
{
    public GameObject 任务列表;

    public GameObject 任务信息;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 目标;
    public TextMeshProUGUI 详情;
    public TextMeshProUGUI 灵气;
    public Button 完成任务按钮;

    public void Show任务信息()
    {
        if (HeroWindowController.S.当前显示任务Type == 任务Type.None)
        {
            任务信息.SetActive(false);
            return;
        }

        完成任务按钮.interactable = PlayerData.S.任务完成字典[HeroWindowController.S.当前显示任务Type];
        任务类型 任务类型 = 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务类型;
        string 类型 = 任务类型 == 任务类型.主线任务 ? "[主线]" : "[支线]";
        name.text = 类型 + 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务名;
        目标.text = 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务目标;
        详情.text = 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务详情;
        灵气.text = "灵气X" + 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].灵气;
    }

    public void 刷新列表()
    {
        foreach (Transform item in 任务列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.当前任务列表)
        {
            if (任务Config.任务配置[item].任务类型 == 任务类型.主线任务)
            {
                var 任务item = Instantiate(Resources.Load("Prefabs/Window/任务/任务界面item"), 任务列表.transform)
                    .GetComponent<任务界面item>();
                任务item.任务Type = item;
                任务item.SetItem();
            }
        }
        
        foreach (var item in PlayerData.S.当前任务列表)
        {
            if (任务Config.任务配置[item].任务类型 == 任务类型.支线任务)
            {
                var 任务item = Instantiate(Resources.Load("Prefabs/Window/任务/任务界面item"), 任务列表.transform)
                    .GetComponent<任务界面item>();
                任务item.任务Type = item;
                任务item.SetItem();
            }
        }
    }

    private void OnEnable()
    {
        HeroWindowController.S.当前显示任务Type = 任务Type.None;
        刷新列表();
        Show任务信息();
    }

    public void 任务界面item点击(object[] obj)
    {
        Show任务信息();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("任务界面item点击",任务界面item点击);
        完成任务按钮.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("SendUIToast","任务完成,获得灵气X"+任务Config.任务配置[HeroWindowController.S.当前显示任务Type].灵气);
            HeroWindowController.S.当前显示任务Type = 任务Type.None;
            PlayerData.S.当前任务列表.Remove(HeroWindowController.S.当前显示任务Type);
            刷新列表();
        });
    }

    public void 添加任务()
    {
        switch (HeroWindowController.S.当前显示任务Type)
        {
            case 任务Type.花果山:
                任务Config.添加任务(任务Type.水帘洞);
                break;
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("任务界面item点击",任务界面item点击);
    }
}
