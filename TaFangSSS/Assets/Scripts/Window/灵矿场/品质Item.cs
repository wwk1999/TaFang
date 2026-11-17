using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 品质Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public QualityType QualityType;

    public void SetItem()
    {
        text.text = QualityType == QualityType.None ? "所有" : PropConfig.QualityNameDic[QualityType];
    }

    private void Start()
    {
        btn.onClick.AddListener(() => ObserverModuleManager.S.SendEvent("矿工背包品质筛选", QualityType));
    }
}
