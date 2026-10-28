using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文融合品质筛选Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public QualityType qualityType;

    public void SetItem()
    {
        if (qualityType == QualityType.None)
        {
            text.text = "全部";
        }
        else
        {
            text.text = PropConfig.QualityNameDic[qualityType];
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            HeroWindowController.S.符文融合品质筛选 = qualityType;
            ObserverModuleManager.S.SendEvent("隐藏符文融合品质筛选");
            ObserverModuleManager.S.SendEvent("刷新符文融合背包");
        });
    }
}
