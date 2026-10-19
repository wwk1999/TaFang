using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽血脉筛选Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 血脉Type 血脉Type;

    public void SetItem()
    {
        if (血脉Type == 血脉Type.None)
        {
            text.text = "所有";
        }
        else
        {
            text.text = 灵兽坊Config.血脉Name[血脉Type];
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("灵兽血脉筛选",血脉Type);
        });
    }
}
