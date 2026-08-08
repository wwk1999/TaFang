using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 主页秘境item : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI nameText;
    public Image icon;
    public Image bg;
    
    [NonSerialized]public QualityType quality;
    [NonSerialized] public int count;
    [NonSerialized] public string name;
    [NonSerialized]public Sprite sprite;
    public void SetItem()
    {
        countText.text = count.ToString();
        nameText.text = name;
        icon.sprite = sprite;
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(quality);
        nameText.colorGradientPreset=ResourcesConfig.Get品质TMP(quality);
    }
}
