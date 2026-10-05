using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙石排序选项item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 法器附加属性Type 法器附加属性Type;

    public void SetItem()
    {
        if (法器附加属性Type == 法器附加属性Type.None)
        {
            text.text = "无排序";
        }
        else
        {
            text.text = "按" + 法器Config.法器附加属性Desc[法器附加属性Type] + "排序";
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前仙石排序附加属性Type = 法器附加属性Type;
            ObserverModuleManager.S.SendEvent("隐藏排序选项");
            ObserverModuleManager.S.SendEvent("刷新仙石镶嵌背包");
        });
    }
}
