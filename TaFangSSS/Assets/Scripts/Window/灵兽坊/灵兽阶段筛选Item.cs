using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽阶段筛选Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 阶段Type 阶段Type;

    public void SetItem()
    {
        if (阶段Type == 阶段Type.None)
        {
            text.text = "所有";
        }
        else
        {
            text.text = 灵兽坊Config.阶段Name[阶段Type];
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("灵兽阶段筛选",阶段Type);
        });
    }
}
