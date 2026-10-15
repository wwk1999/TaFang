using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文附魔排序选项item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 符文Type 符文Type;

    public void SetItem()
    {
        if (符文Type == 符文Type.None)
        {
            text.text = "无排序";
        }
        else
        {
            text.text = 符文Config.符文名Dic[符文Type];
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前符文附魔排序Type = 符文Type;
            ObserverModuleManager.S.SendEvent("隐藏符文附魔排序选项");
            ObserverModuleManager.S.SendEvent("刷新符文附魔背包");
        });
    }
}
