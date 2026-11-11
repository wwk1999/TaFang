using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 娲皇宫格子item : MonoBehaviour
{
    public Button bg;
    public TextMeshProUGUI count;
    [NonSerialized] public int 层数;

    public void SetItem()
    {
        count.text = 层数.ToString();
        bg.image.sprite = ResourcesConfig.混沌虚空格子暗;
    }

    public void 娲皇宫格子点击(object[] obj)
    {
        int count = (int)obj[0];
        if (count == 层数)
        {
            bg.image.sprite = ResourcesConfig.混沌虚空格子亮;
        }
        else
        {
            bg.image.sprite = ResourcesConfig.混沌虚空格子暗;
        }
        ObserverModuleManager.S.SendEvent("刷新娲皇宫窗口");
    }
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("娲皇宫格子点击",娲皇宫格子点击);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("混沌虚空格子点击",娲皇宫格子点击);
    }

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("娲皇宫格子点击",层数);
        });
    }
}
