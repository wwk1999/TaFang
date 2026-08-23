using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹方信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI desc;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType  QualityType;

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite=ResourcesConfig.Get丹方icon(丹药Type,QualityType);
        name.text = 丹药Config.丹方名Dic[丹药Type];
        品质.text=PropConfig.QualityNameDic[QualityType];
        desc.text = 丹药Config.丹方DescDic[丹药Type];
    }
}
