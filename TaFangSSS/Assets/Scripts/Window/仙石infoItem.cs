using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙石infoItem : MonoBehaviour
{
    [NonSerialized] public 仙石Type 仙石Type;
    [NonSerialized] public QualityType QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI 职业;
    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get仙石Sprite(仙石Type, QualityType);
        name.text = 仙石Config.仙石名Dic[仙石Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        desc.text=仙石Config.仙石DescDic[仙石Type];
        职业.text=PropConfig.QualityNameDic[QualityType];
    }
}
