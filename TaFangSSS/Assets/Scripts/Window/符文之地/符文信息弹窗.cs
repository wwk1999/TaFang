using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 效果;
    public TextMeshProUGUI 数值;

    [NonSerialized] public 符文 符文;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
        icon.sprite = ResourcesConfig.Get符文Sprite(符文.type, 符文Config.Quality对应符文品质[符文.quality]);
        name.text = 符文Config.符文名Dic[符文.type];
        品质.text=PropConfig.QualityNameDic[符文.quality];
        品质.colorGradientPreset = ResourcesConfig.Get品质TMP(符文.quality);
        效果.text=符文Config.符文效果Dic[符文.type];
        if (符文.type == 符文Type.击杀怪物获得神通能量)
        {
            数值.text = 符文.count.ToString("F2");
        }
        else
        {
            数值.text = 符文.count.ToString("F1")+"%";
        }
    }
}
