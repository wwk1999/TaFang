using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器信息符文item : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public Image icon;
    public TextMeshProUGUI 无暇Text;
    [NonSerialized] public 符文Type 符文Type;
    [NonSerialized] public QualityType QualityType;
    [NonSerialized] public float count;
    [NonSerialized] public bool 无暇;
    public void SetItem()
    {
        无暇Text.gameObject.SetActive(无暇);
        无暇Text.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        icon.sprite = ResourcesConfig.Get符文Sprite(符文Type, QualityType);
        name.text = 符文Config.符文名Dic[符文Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        desc.text = 符文Config.Get符文效果(符文Type,count);
    }
}
