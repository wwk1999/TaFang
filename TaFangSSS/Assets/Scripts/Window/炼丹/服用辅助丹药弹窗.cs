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
    [NonSerialized] public int 阶段 = 1;

    /// <summary>该类型辅助丹药是否已服用过（任何品质任何阶数，只能服用一颗）</summary>
    private bool 已服用过()
    {
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= PlayerData.Get丹药最高阶段((QualityType)i); j++)
            {
                if (PlayerData.S.Get辅助丹药Buff(丹药Type, (QualityType)i, j) > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void Start()
    {
        服用按钮.onClick.AddListener(() =>
        {
            // 每种辅助丹药只能服用一颗：任何品质任何阶数服用过后即拦截
            if (已服用过())
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","每种辅助丹药只能服用一颗");
                return;
            }
            if (PlayerData.S.Get丹药数量(丹药Type, QualityType, 阶段) < 1)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","丹药数量不足");
                return;
            }
            PlayerData.S.Set辅助丹药Buff(丹药Type, QualityType, 1, 阶段);
            PlayerData.S.Set丹药数量(丹药Type, QualityType,PlayerData.S.Get丹药数量(丹药Type, QualityType, 阶段)-1, 阶段);
            ObserverModuleManager.S.SendEvent("SendUIToast","服用成功");
            ObserverModuleManager.S.SendEvent("刷新背包");
            ObserverModuleManager.S.SendEvent("刷新主页Buff");
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        // 只能服用一颗，滑条固定为 1
        数量Slider.minValue = 1;
        数量Slider.maxValue = 1;
        数量Slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnEnable()
    {
        数量Slider.minValue = 1;
        数量Slider.maxValue = 1;
        数量Slider.value = 1;
        count = 1;
        数量.text = "1";
    }

    void OnSliderValueChanged(float value)
    {
        数量Slider.value = 1;
        数量.text = "1";
        count = 1;
    }
    public void SetItem()
    {
        数量.text = "1";
        count = 1;
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type,QualityType);
        name.text = 丹药Config.丹药名Dic[丹药Type] + "·" + 阶段 + "阶";
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
    }
}
