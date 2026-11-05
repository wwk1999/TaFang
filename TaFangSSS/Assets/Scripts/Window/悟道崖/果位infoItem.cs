using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 果位infoItem : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 等级;

    [NonSerialized] public 大道Type 大道Type;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(悟道崖Config.大道等级品质[悟道崖Config.大道配置[大道Type].大道等级Type]);
        icon.sprite = ResourcesConfig.Get果位Icon(大道Type);
        name.text = 悟道崖Config.大道配置[大道Type].果位名;
        等级.text = 悟道崖Config.果位等级[悟道崖Config.大道配置[大道Type].大道等级Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(悟道崖Config.大道等级品质[悟道崖Config.大道配置[大道Type].大道等级Type]);
    }
}
