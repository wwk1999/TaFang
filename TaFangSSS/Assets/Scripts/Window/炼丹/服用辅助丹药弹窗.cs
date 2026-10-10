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
            if (count < 1)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择服用数量");
                return;
            }
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
            // 恰好剩 1 颗时强制选中它。count 必须同步重置，
            // 否则沿用上一次的服用数量（吃1颗却加60颗效果的根因）
            数量Slider.value = 数量Slider.maxValue;
            count = 1;
            数量.text = "1";
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
        // 重置服用数量字段。原代码这里声明了同名局部变量 int count，
        // 把字段遮蔽了，导致字段保留上一次的值（60）没被重置
        count = 1;
        int 背包数量 = PlayerData.S.Get丹药数量(丹药Type, QualityType);
        if (背包数量 > 1)
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
    }
}
