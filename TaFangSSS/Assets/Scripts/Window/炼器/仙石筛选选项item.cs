using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙石筛选选项item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 仙石Type 仙石Type;

    public void SetItem()
    {
        if (仙石Type == 仙石Type.None)
        {
            text.text = "全部";
        }
        else
        {
            text.text = 仙石Config.仙石名Dic[仙石Type];
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前筛选仙石type = 仙石Type;
            ObserverModuleManager.S.SendEvent("隐藏筛选选项");
            ObserverModuleManager.S.SendEvent("刷新仙石镶嵌背包");
        });
    }
}
