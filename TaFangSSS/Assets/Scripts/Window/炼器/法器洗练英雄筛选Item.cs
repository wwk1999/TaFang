using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器洗练英雄筛选Item : MonoBehaviour
{
    [NonSerialized]public HeroType HeroType;
    public TextMeshProUGUI text;
    public Button btn;
    public void SetItem()
    {
        if (HeroType == HeroType.None)
        {
            text.text = "所有英雄";
        }
        else
        {
            text.text=HeroConfig.HeroNameDic[HeroType];
        }
    }

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("法器洗练英雄筛选",HeroType);
        });
    }
}
