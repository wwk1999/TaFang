using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文融合信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 效果1;
    public TextMeshProUGUI 数值1;
    public TextMeshProUGUI 无暇1;
    
    public TextMeshProUGUI 效果2;
    public TextMeshProUGUI 数值2;
    public TextMeshProUGUI 无暇2;

    [NonSerialized] public 符文 符文;

    public void SetItem()
    {
        无暇1.gameObject.SetActive(符文.无暇);
        无暇1.colorGradientPreset = ResourcesConfig.Get品质TMP(符文.quality);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
        icon.sprite = ResourcesConfig.Get符文Sprite(符文.type, 符文.quality);
        name.text = 符文Config.符文名Dic[符文.type];
        品质.text=PropConfig.QualityNameDic[符文.quality];
        品质.colorGradientPreset = ResourcesConfig.Get品质TMP(符文.quality);
        效果1.text=符文Config.符文效果Dic[符文.type];
        if (符文.type == 符文Type.击杀怪物获得神通能量)
        {
            数值1.text = 符文.count.ToString("F2");
        }
        else
        {
            数值1.text = 符文.count.ToString("F1")+"%";
        }
        
        无暇2.gameObject.SetActive(符文.融合无暇);
        无暇2.colorGradientPreset = ResourcesConfig.Get品质TMP(符文.quality);
        效果2.text=符文Config.符文效果Dic[符文.融合type];
        if (符文.type == 符文Type.击杀怪物获得神通能量)
        {
            数值2.text = 符文.融合count.ToString("F2");
        }
        else
        {
            数值2.text = 符文.融合count.ToString("F1")+"%";
        }
    }
}
