using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 服用辅助丹药弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 数量;

    public Slider 数量Slider;
    public Button 服用按钮;
    private int count=1;

    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType QualityType;

    private void Start()
    {
        服用按钮.onClick.AddListener(() =>
        {
            PlayerData.S.Set辅助丹药Buff(丹药Type, QualityType, PlayerData.S.Get辅助丹药Buff(丹药Type, QualityType) + count);
            PlayerData.S.Set丹药数量(丹药Type, QualityType,PlayerData.S.Get丹药数量(丹药Type, QualityType)-count);
            ObserverModuleManager.S.SendEvent("SendUIToast","服用成功");
            ObserverModuleManager.S.SendEvent("刷新背包");
            ObserverModuleManager.S.SendEvent("刷新主页Buff");
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        数量Slider.maxValue = PlayerData.S.Get丹药数量(丹药Type, QualityType);
        if (PlayerData.S.Get丹药数量(丹药Type, QualityType) <= 1)
        {
           数量Slider.minValue = 0; 
        }
        else
        {
            数量Slider.minValue = 1;
        }
        数量Slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnEnable()
    {
        数量Slider.maxValue = PlayerData.S.Get丹药数量(丹药Type, QualityType);
        if (PlayerData.S.Get丹药数量(丹药Type, QualityType) <= 1)
        {
            数量Slider.minValue = 0; 
        }
        else
        {
            数量Slider.minValue = 1;
        }
    }

    void OnSliderValueChanged(float value)
    {
        if (PlayerData.S.Get丹药数量(丹药Type, QualityType) == 1)
        {
            数量Slider.value=数量Slider.maxValue;
            return;
        }
        int newCount=(int)value;
        数量Slider.value=newCount;
        数量.text=newCount.ToString();
        count=newCount;
    }
    public void SetItem()
    {
        数量.text = "1";
        int count = PlayerData.S.Get丹药数量(丹药Type, QualityType);
        if (count > 1)
        {
            数量Slider.value = 数量Slider.minValue;
        }
        else
        {
            数量Slider.value = 数量Slider.maxValue;
        }
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type,QualityType);
        name.text = 丹药Config.丹药名Dic[丹药Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        品质.text = "品质："+PropConfig.QualityNameDic[QualityType];
    }
}
