using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 羁绊弹窗 : MonoBehaviour
{
    public Button exitButton;
    public Button maskButton;
    public GameObject 列表Content;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI info;
    public TextMeshProUGUI level;
    public TextMeshProUGUI 效果;
    public GameObject 成员Content;

    private void OnEnable()
    {
        Show列表();
        ObserverModuleManager.S.SendEvent("羁绊列表点击",羁绊Type.翻海断岳);
    }

    public void 羁绊列表点击(object[] obj)
    {
        羁绊Type type = (羁绊Type)obj[0];
        Show羁绊info(type);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("羁绊列表点击",羁绊列表点击);
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("羁绊列表点击",羁绊列表点击);
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Show列表()
    {
        foreach (Transform item in 列表Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var 羁绊 in 道宝Config.羁绊配置)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/羁绊列表item"), 列表Content.transform)
                .GetComponent<羁绊列表item>();
            item.羁绊Type = 羁绊.Key;
            item.SetItem();
        }
    }
    
    public void Show羁绊info(羁绊Type type)
    {
        icon.sprite=ResourcesConfig.Get羁绊Sprite(type);
        name.text = 道宝Config.羁绊配置[type].名称;
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(道宝Config.道宝QualityToQuality[道宝Config.羁绊配置[type].品质]);
        info.text = 道宝Config.羁绊配置[type].描述;
        level.text="LV."+道宝Config.Get羁绊Level(type);
        效果.text=道宝Config.羁绊配置[type].效果描述;
        foreach (Transform item in 成员Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var 道宝Type in 道宝Config.羁绊配置[type].所需道宝列表)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/羁绊成员item"), 成员Content.transform)
                .GetComponent<羁绊成员item>();
            item.道宝Type = 道宝Type;
            item.SetItem(); 
        }
    }
}
