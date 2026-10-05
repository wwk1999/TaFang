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
    [NonSerialized] public 附加属性Type 附加属性Type;

    public void SetItem()
    {
        text.text = EquipConfig.Get排序String(附加属性Type);
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前仙石排序附加属性Type = 附加属性Type;
            ObserverModuleManager.S.SendEvent("隐藏排序选项");
            ObserverModuleManager.S.SendEvent("刷新仙石镶嵌背包");
        });
    }
}
