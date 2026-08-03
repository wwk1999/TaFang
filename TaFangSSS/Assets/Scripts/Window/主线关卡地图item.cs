using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 主线关卡地图item : MonoBehaviour
{
    public Button image;
    public GameObject 标签;
    public TextMeshProUGUI name;
    public 主线关卡Type 主线关卡Type;

    private void Start()
    {
        image.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.主线关卡;
            HeroWindowController.S.当前主线关卡Type = 主线关卡Type;
            ObserverModuleManager.S.SendEvent("显示主线关卡弹窗",主线关卡Type);
        });
    }

    private void OnEnable()
    {
        SetItem();
    }

    public void SetItem()
    {
        if (PlayerData.S.最大主线关卡 < 主线关卡Type)
        {
            标签.gameObject.SetActive(false);
            image.image.raycastTarget = false;
        }
        else
        {
            标签.gameObject.SetActive(true);
            image.image.raycastTarget = true;
            name.text = LevelConfig.主线关卡NameDic[主线关卡Type];
        }
    }
}
