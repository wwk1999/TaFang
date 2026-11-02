using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
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

        var list = 赌坊Config.品质藏品列表[QualityType];
        foreach (var item in list)
        {
            if (PlayerData.S.藏品仓库Dic.ContainsKey(item) && PlayerData.S.藏品仓库Dic[item] > 0)
            {
                var 藏品item=Instantiate(Resources.Load("Prefabs/Window/赌坊/藏品仓库item"),content.transform).GetComponent<藏品仓库item>();
                藏品item.藏品Type = item;
                藏品item.SetItem(item);
            }
            
        }
        switch (QualityType)
        {
            case QualityType.荒品:
                title.colorGradientPreset = ResourcesConfig.荒TMP;
                标签背景.sprite = ResourcesConfig.道宝标签彩;
                break;
            case QualityType.洪品:
                title.colorGradientPreset = ResourcesConfig.洪TMP;
                标签背景.sprite = ResourcesConfig.道宝标签红;
                break;
            case QualityType.宙品:
                title.colorGradientPreset = ResourcesConfig.宙TMP;
                标签背景.sprite = ResourcesConfig.道宝标签粉;
                break;
        }
    }
}
