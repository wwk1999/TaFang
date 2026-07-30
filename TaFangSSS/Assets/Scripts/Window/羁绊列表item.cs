using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 羁绊列表item : MonoBehaviour
{
    public Image 当前icon;
    public Image icon;
    public Button bg;
    public TextMeshProUGUI nameText;
    [NonSerialized] public 羁绊Type 羁绊Type;

    public void SetItem()
    {
        当前icon.gameObject.SetActive(false);
        icon.sprite = ResourcesConfig.Get羁绊Sprite(羁绊Type);
        bg.image.sprite = ResourcesConfig.Get羁绊背景框(道宝Config.道宝QualityToQuality[道宝Config.羁绊配置[羁绊Type].品质]);
        nameText.text = 道宝Config.羁绊配置[羁绊Type].名称;
        nameText.colorGradientPreset = ResourcesConfig.Get品质TMP(道宝Config.道宝QualityToQuality[道宝Config.羁绊配置[羁绊Type].品质]);
    }

    public void 羁绊列表点击(object[] obj)
    {
        羁绊Type type = (羁绊Type)obj[0];
        当前icon.gameObject.SetActive(type==羁绊Type);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("羁绊列表点击",羁绊列表点击);
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("羁绊列表点击",羁绊列表点击);
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("羁绊列表点击",羁绊Type);
        });
    }
}
