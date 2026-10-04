using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 坊市仙石信息弹窗 : MonoBehaviour
{
    [NonSerialized] public 仙石Type 仙石Type;
    [NonSerialized] public QualityType 仙石QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 词条数量;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(仙石QualityType);
        icon.sprite = ResourcesConfig.Get仙石Sprite(仙石Type, 仙石QualityType);
        name.text = 仙石Config.仙石名Dic[仙石Type];
        品质.text = PropConfig.QualityNameDic[仙石QualityType];
        词条数量.text = "1-3";
    }
}
