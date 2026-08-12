using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 传道item : MonoBehaviour
{
    public Image bg;
    public TextMeshProUGUI name;
    public Image icon;
    public TextMeshProUGUI 功德count;
    public Button 传道Button;
    [NonSerialized]public QualityType qualityType;

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get传道背景框(qualityType);
        name.text=PropConfig.QualityNameDic[qualityType]+"传道";
        name.colorGradientPreset=ResourcesConfig.Get品质TMP(qualityType);
        icon.sprite=ResourcesConfig.Get传道icon(qualityType);
        功德count.text=功法Config.传道消耗Dic[qualityType].ToString();
        传道Button.image.sprite=ResourcesConfig.Get传道按钮(qualityType);
        switch (qualityType)
        {
            case QualityType.黄品:
                
                break;
        }
    }
}
