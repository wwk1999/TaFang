using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 肥料信息弹窗：悬停肥料时展示图标、名称、效果描述与数值
/// </summary>
public class 肥料信息弹窗 : MonoBehaviour
{
    public Image 图标;
    public TextMeshProUGUI 名称;
    public TextMeshProUGUI 类型;

    public TextMeshProUGUI 效果;
    public TextMeshProUGUI 数值;

    [NonSerialized] public 肥料Type 肥料Tyep;
    [NonSerialized] public QualityType QualityType;

    public void 打开(肥料Type type, QualityType quality)
    {
        肥料Tyep = type;
        QualityType = quality;
        gameObject.SetActive(true);
        SetItem();
    }

    public void SetItem()
    {
        图标.sprite = ResourcesConfig.Get肥料Icon(肥料Tyep, QualityType);
        名称.text = PropConfig.QualityNameDic[QualityType] + 灵植园Config.肥料名[肥料Tyep];
        名称.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        类型.text = "灵植肥料";

        获取效果文本(肥料Tyep, QualityType, out string 效果描述, out string 数值文本);
        效果.text = 效果描述;
        数值.text = 数值文本;
    }

    /// <summary>
    /// 根据肥料类型与品级返回效果描述与数值
    /// 提速：提升生长速度 / +X%
    /// 增产：增加产量 / +X%
    /// 异化：提高变异概率 / +X%
    /// 延时：延长成熟时间并增加产量 / ×(1+X)
    /// </summary>
    private static void 获取效果文本(肥料Type type, QualityType quality, out string 效果描述, out string 数值文本)
    {
        switch (type)
        {
            case 肥料Type.提速:
                效果描述 = "提升生长速度";
                数值文本 = $"+{灵植园Config.提速肥料数值[quality]:0.##}%";
                break;
            case 肥料Type.增产:
                效果描述 = "增加产量";
                数值文本 = $"+{灵植园Config.增产肥料数值[quality]:0.##}%";
                break;
            case 肥料Type.异化:
                效果描述 = "提高变异概率";
                数值文本 = $"+{灵植园Config.异化肥料数值[quality]:0.##}%";
                break;
            case 肥料Type.延时:
                float v = 灵植园Config.延时肥料数值[quality];
                效果描述 = "延长成熟时间并增加产量";
                数值文本 = $"×(1+{v:0.##})";
                break;
            default:
                效果描述 = "无";
                数值文本 = "";
                break;
        }
    }
}
