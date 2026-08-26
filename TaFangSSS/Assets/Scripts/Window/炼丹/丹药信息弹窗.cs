using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum 丹药显示Type
{
    None,
    背包,
    战斗弹窗,
    战斗选择弹窗,
}
public class 丹药信息弹窗 : MonoBehaviour
{
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI info;
    public TextMeshProUGUI tip;

    [NonSerialized] public 丹药显示Type 丹药显示Type = 丹药显示Type.背包;
    public void SetItem()
    {
        switch (丹药显示Type)
        {
            case 丹药显示Type.背包:
                tip.text = "(右键服用丹药)";
                break;
            case 丹药显示Type.战斗弹窗:
                tip.text = "(右键取消佩戴)";
                break;
            case 丹药显示Type.战斗选择弹窗:
                tip.text = "";
                break;
        }
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite=ResourcesConfig.Get丹药icon(丹药Type,QualityType);
        name.text=丹药Config.丹药名Dic[丹药Type];
        类型.text = 丹药Config.丹药类型String[丹药Config.丹药类型Dic[丹药Type]];
        info.text = 丹药Config.Get丹药Desc(丹药Type, QualityType);
    }
}
