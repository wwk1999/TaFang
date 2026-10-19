using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽元素筛选Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public YuanSuType YuanSuType;

    public void SetItem()
    {
        if (YuanSuType == YuanSuType.None)
        {
            text.text = "所有";
        }
        else
        {
            text.text = HeroConfig.Get元素string(YuanSuType);
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("灵兽元素筛选",YuanSuType);
        });
    }
}
