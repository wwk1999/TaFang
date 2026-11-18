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
    [NonSerialized] public string 显示名;
    [NonSerialized] public bool 是宝箱;
    [NonSerialized] public int 宝箱品质值 = -1; // -1=所有

    public void SetItem()
    {
        if (!string.IsNullOrEmpty(显示名))
        {
            text.text = 显示名;
            return;
        }
        text.text = QualityType == QualityType.None ? "所有" : PropConfig.QualityNameDic[QualityType];
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            if (是宝箱) ObserverModuleManager.S.SendEvent("矿工背包宝箱品质筛选", 宝箱品质值);
            else ObserverModuleManager.S.SendEvent("矿工背包品质筛选", QualityType);
        });
    }
}
