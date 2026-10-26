using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹药升阶弹窗 : MonoBehaviour
{
    /// <summary>升一阶需要消耗的同品质同阶数丹药数量</summary>
    public const int 升阶消耗数量 = 4;

    public Button maskButton;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 阶段;
    public TextMeshProUGUI 数量;

    public Slider 数量Slider;
    public Button 升阶按钮;
    private int count = 1;

    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType QualityType;
    [NonSerialized] public int 阶段数 = 1;

    private void Start()
    {
        升阶按钮.onClick.AddListener(() =>
        {
            // 实时读取库存作为唯一依据，杜绝滑条残留值把数量扣成负数
            int 当前数量 = PlayerData.S.Get丹药数量(丹药Type, QualityType, 阶段数);
            int 可合成次数 = 当前数量 / 升阶消耗数量;
            if (count <= 0 || count > 可合成次数)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "丹药数量不足");
                SetSliderRange();
                return;
            }
            if (阶段数 >= PlayerData.Get丹药最高阶段(QualityType))
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "该丹药已是最高阶段");
                return;
            }
            PlayerData.S.Set丹药数量(丹药Type, QualityType, 当前数量 - count * 升阶消耗数量, 阶段数);
            PlayerData.S.Set丹药数量(丹药Type, QualityType,
                PlayerData.S.Get丹药数量(丹药Type, QualityType, 阶段数 + 1) + count, 阶段数 + 1);
            ObserverModuleManager.S.SendEvent("SendUIToast", "升阶成功");
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        数量Slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnEnable()
    {
        // 每次打开重置合成次数，防止沿用上一次会话的残留值
        SetSliderRange();
    }

    /// <summary>按当前库存刷新滑条范围：上界 = 可合成次数，最少可合成 1 次</summary>
    private void SetSliderRange()
    {
        int 可合成次数 = Mathf.Max(1, PlayerData.S.Get丹药数量(丹药Type, QualityType, 阶段数) / 升阶消耗数量);
        数量Slider.minValue = 1;
        数量Slider.maxValue = 可合成次数;
        count = 1;
        数量.text = "1";
        // 只能合成 1 次时滑条无拖动空间，直接顶到上限
        if (可合成次数 > 1)
        {
            数量Slider.value = 数量Slider.minValue;
        }
        else
        {
            数量Slider.value = 数量Slider.maxValue;
        }
    }

    void OnSliderValueChanged(float value)
    {
        int newCount = (int)value;
        if (newCount < 1)
        {
            newCount = 1;
        }
        数量Slider.value = newCount;
        数量.text = newCount.ToString();
        count = newCount;
    }

    public void SetItem()
    {
        SetSliderRange();
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type, QualityType);
        name.text = 丹药Config.丹药名Dic[丹药Type] + "·" + 阶段数 + "阶";
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        // 展示本次升阶前后的阶段变化
        阶段.text = 阶段数 + "阶 → " + (阶段数 + 1) + "阶";
    }
}
