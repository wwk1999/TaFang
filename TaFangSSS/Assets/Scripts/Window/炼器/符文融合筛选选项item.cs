using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文融合筛选选项item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 符文Type 符文Type;

    public void SetItem()
    {
        if (符文Type == 符文Type.None)
        {
            text.text = "无筛选";
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
            HeroWindowController.S.符文融合排序Type = 符文Type;
            ObserverModuleManager.S.SendEvent("隐藏符文融合筛选选项");
            ObserverModuleManager.S.SendEvent("刷新符文融合背包");
        });
    }
}
