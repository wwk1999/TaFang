using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽性别筛选Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 性别 性别;

    public void SetItem()
    {
        if (性别 == 性别.None)
        {
            text.text = "所有";
        }
        else
        {
            if (性别 == 性别.公)
            {
                text.text = "公";
            }
            else
            {
                text.text = "母";
            }
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("灵兽性别筛选",性别);
        });
    }
}
