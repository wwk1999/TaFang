using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 孵化池item : MonoBehaviour
{
    public Button button;
    public GameObject 孵化中OBj;
    public TextMeshProUGUI 父血脉;
    public TextMeshProUGUI 父名字;
    public GameObject 父Content;

    public TextMeshProUGUI 母血脉;
    public TextMeshProUGUI 母名字;
    public GameObject 母Content;


    public Image 进度条;
    public TextMeshProUGUI count;
    [NonSerialized] public 孵化池 孵化池;
    public void SetItem()
    {
        button.image.sprite = ResourcesConfig.建筑item暗;
        孵化中OBj.SetActive(孵化池.孵化中);
        进度条.fillAmount = 孵化池.当前道年 / 孵化池.需要道年;
        count.text = (孵化池.当前道年 / 孵化池.需要道年).ToString("F1") + "%";
        if (孵化池.父 != null)
        {
            父Content.SetActive(true);
            父血脉.text = 灵兽坊Config.血脉Name[孵化池.父.血脉Type];
            父名字.text = 灵兽坊Config.灵兽名[孵化池.父.灵兽Type];
            父名字.colorGradientPreset = ResourcesConfig.Get品质TMP(孵化池.父.QualityType);
            父血脉.colorGradientPreset = ResourcesConfig.Get品质TMP((QualityType)孵化池.父.血脉Type);
        }
        else
        {
            父Content.SetActive(false);
        }
        
        if (孵化池.母 != null)
        {
            母Content.SetActive(true);
            母血脉.text = 灵兽坊Config.血脉Name[孵化池.母.血脉Type];
            母名字.text = 灵兽坊Config.灵兽名[孵化池.母.灵兽Type];
            母名字.colorGradientPreset = ResourcesConfig.Get品质TMP(孵化池.母.QualityType);
            母血脉.colorGradientPreset = ResourcesConfig.Get品质TMP((QualityType)孵化池.母.血脉Type);
        }
        else
        {
            母Content.SetActive(false);
        }
    }
}
