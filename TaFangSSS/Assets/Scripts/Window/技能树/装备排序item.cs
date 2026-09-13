using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 装备排序item : MonoBehaviour
{
    public Button icon;
    public TextMeshProUGUI text;
    public GameObject gou;
    [NonSerialized] public 附加属性Type 附加属性Type;
    public void SetItem()
    {
        gou.SetActive(false);
        text.text = EquipConfig.Get排序String(附加属性Type);
    }

    public void 装备排序点击(object[] obj)
    {
        
        附加属性Type type = (附加属性Type)obj[0];
        gou.SetActive(type==附加属性Type);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("装备排序点击",装备排序点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("装备排序点击",装备排序点击);
        icon.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前排序附加属性Type = 附加属性Type;
            ObserverModuleManager.S.SendEvent("装备排序点击",附加属性Type);
        });
    }
}
