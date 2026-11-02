using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 藏品仓库种类item : MonoBehaviour
{
    [NonSerialized] public QualityType QualityType;
    public Image 标签背景;
    public TextMeshProUGUI title;
    public GameObject content;
    
    
    public void SetItem()
    {
        title.text = PropConfig.QualityNameDic[QualityType]+"藏物";
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        var list = 道宝Config.道宝品质列表[道宝Quality];
        foreach (var item in list)
        {
            var 道宝item=Instantiate(Resources.Load("Prefabs/Window/道宝item"),content.transform).GetComponent<道宝item>();
            道宝item.道宝Type = item;
            道宝item.SetItem();
        }
        switch (QualityType)
        {
            case 道宝Quality.混沌至宝:
                title.colorGradientPreset = ResourcesConfig.荒TMP;
                标签背景.sprite = ResourcesConfig.道宝标签彩;
                break;
            case 道宝Quality.先天至宝:
                title.colorGradientPreset = ResourcesConfig.洪TMP;
                标签背景.sprite = ResourcesConfig.道宝标签红;
                break;
            case 道宝Quality.功德至宝:
                title.colorGradientPreset = ResourcesConfig.宙TMP;
                标签背景.sprite = ResourcesConfig.道宝标签粉;
                break;
            case 道宝Quality.先天灵宝:
                title.colorGradientPreset = ResourcesConfig.宇TMP;
                标签背景.sprite = ResourcesConfig.道宝标签橙;
                break;
            case 道宝Quality.后天法宝:
                title.colorGradientPreset = ResourcesConfig.天TMP;
                标签背景.sprite = ResourcesConfig.道宝标签紫;
                break;
        }
    }
}
