using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 功法分解弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 职业;
    public TextMeshProUGUI 数量;
    public TextMeshProUGUI 获得经验;

    public Slider 数量Slider;
    public Button 分解按钮;
    private int count=1;

    [NonSerialized] public 功法Type 功法Type;

    private void Start()
    {
        分解按钮.onClick.AddListener(() =>
        {
            PlayerData.S.PropListDic[PropType.功法经验] += 功法Config.功法分解经验[功法Config.功法TypeQualityDic[功法Type]] * count;
            PlayerData.S.功法数量Dic[功法Type] -= count;
            ObserverModuleManager.S.SendEvent("SendUIToast","分解成功");
            ObserverModuleManager.S.SendEvent("刷新背包");

            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        数量Slider.maxValue = PlayerData.S.功法数量Dic[功法Type];
        if (PlayerData.S.功法数量Dic[功法Type] <= 1)
        {
           数量Slider.minValue = 0; 
        }
        else
        {
            数量Slider.minValue = 1;
        }
        数量Slider.onValueChanged.AddListener(OnSliderValueChanged);
        获得经验.text=功法Config.功法分解经验[功法Config.功法TypeQualityDic[功法Type]].ToString();
    }

    void OnSliderValueChanged(float value)
    {
        if (PlayerData.S.功法数量Dic[功法Type] == 1)
        {
            数量Slider.value=数量Slider.maxValue;
            return;
        }
        int newCount=(int)value;
        数量Slider.value=newCount;
        数量.text=newCount.ToString();
        count=newCount;
        获得经验.text=(newCount*功法Config.功法分解经验[功法Config.功法TypeQualityDic[功法Type]]).ToString();
    }
    public void SetItem()
    {
        数量.text = "1";
        int count = PlayerData.S.功法数量Dic[功法Type];
        if (count > 1)
        {
            数量Slider.value = 数量Slider.minValue;
        }
        else
        {
            数量Slider.value = 数量Slider.maxValue;
        }
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
        name.text = 功法Config.功法名Dic[功法Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(功法Config.功法TypeQualityDic[功法Type]);
        职业.text = "职业："+功法Config.功法职业Dic[功法Type];
    }
}
