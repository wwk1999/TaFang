using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵物信息弹窗 : MonoBehaviour
{
    [NonSerialized]public JingJieType JingJieType;
    [NonSerialized]public QualityType QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI desc;

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get突破灵物(JingJieType, QualityType);
        name.text = 灵物突破Config.突破灵物名Dic[JingJieType];
        品质.text=PropConfig.QualityNameDic[QualityType];
        品质.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        desc.text="突破"+JingJieConfig.JingJieNameDic[JingJieType]+"境界的核心材料";
    }
}
