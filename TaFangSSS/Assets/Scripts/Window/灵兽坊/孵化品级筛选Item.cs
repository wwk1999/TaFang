using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 孵化品级筛选Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public QualityType QualityType;

    public void SetItem()
    {
        if (QualityType == QualityType.None)
        {
            text.text = "所有";
        }
        else
        {
            text.text = PropConfig.QualityNameDic[QualityType];
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("孵化品级筛选", QualityType);
        });
    }
}
