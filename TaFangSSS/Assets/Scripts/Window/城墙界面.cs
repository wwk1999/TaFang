using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 城墙界面 : MonoBehaviour
{
    public Button exitbutton;
    public GameObject 左装备COntent;
    public GameObject 右装备COntent;
    public Image Icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI level;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI defense;
    public TextMeshProUGUI quality;
    public Button 升级button;
    public GameObject 列表Content;
    public Image 鼠标Image;
    public ScrollRect  ScrollView;
    public RectTransform canvasRectTransform;


    public void Update()
    {
        if (HeroWindowController.S.城墙IsDrag)
        {
            ScrollView.vertical=false;
            Vector2 localPoint;
            bool isInside = RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRectTransform, 
                Input.mousePosition, 
                null,
                out localPoint
            );
            鼠标Image.gameObject.SetActive(true);
            鼠标Image.rectTransform.localPosition = localPoint;
            鼠标Image.sprite = ResourcesConfig.Get城墙Sprite(HeroWindowController.S.城墙道具Type);
        } else
        {
            ScrollView.vertical=true;
            鼠标Image.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        Icon.sprite = ResourcesConfig.Get城墙Icon();
        name.text = 城墙Config.Get城墙名();
        level.text = PlayerData.S.城墙等级.ToString();
        hp.text = 城墙Config.Get城墙基础血量().ToString();
        defense.text = 城墙Config.Get城墙基础防御().ToString();
        quality.text = 城墙Config.Get城墙Quality().ToString();
        quality.colorGradientPreset = ResourcesConfig.Get品质TMP(城墙Config.Get城墙Quality());
        foreach (Transform item in 左装备COntent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 右装备COntent.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 列表Content.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i <= 4; i++)
        {
            var 装备item = Instantiate(Resources.Load("Prefabs/Window/城墙装备item"), 左装备COntent.transform)
                .GetComponent<城墙装备item>();
            装备item.城墙装备QualityType = (QualityType)i;
            装备item.城墙道具Type = PlayerData.S.当前装备城墙道具Dic[(QualityType)i];
            装备item.SetItem();
        }

        for (int i = 5; i <= 8; i++)
        {
            var 装备item = Instantiate(Resources.Load("Prefabs/Window/城墙装备item"), 右装备COntent.transform)
                .GetComponent<城墙装备item>();
            装备item.城墙装备QualityType = (QualityType)i;
            装备item.城墙道具Type = PlayerData.S.当前装备城墙道具Dic[(QualityType)i];
            装备item.SetItem();
        }

        foreach (var item in 城墙Config.城墙道具列表Dic)
        {
            var 列表item = Instantiate(Resources.Load("Prefabs/Window/城墙列表item"), 列表Content.transform)
                .GetComponent<城墙列表item>();
            列表item.quality = item.Key;
            列表item.SetItem();
        }
    }

    private void OnEnable()
    {
        Show();
    }

    public void 刷新城墙界面(object[] obj)
    {
        Show();
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新城墙界面",刷新城墙界面);
        exitbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
