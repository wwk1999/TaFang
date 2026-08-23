using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹药信息弹窗 : MonoBehaviour
{
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI info;
    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite=ResourcesConfig.Get丹药icon(丹药Type,QualityType);
        name.text=丹药Config.丹药名Dic[丹药Type];
        类型.text = 丹药Config.丹药类型String[丹药Config.丹药类型Dic[丹药Type]];
        info.text = 丹药Config.Get丹药Desc(丹药Type, QualityType);
    }
}
