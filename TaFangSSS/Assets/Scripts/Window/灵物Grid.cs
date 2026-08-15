using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵物Grid : MonoBehaviour
{
    [NonSerialized] public JingJieType JingJieType;
    [NonSerialized] public QualityType QualityType;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get突破灵物(JingJieType, QualityType);
        name.text = 灵物突破Config.突破灵物名Dic[JingJieType];
        count.text = PlayerData.S.Get灵物数量(JingJieType, QualityType).ToString();
    }
}
