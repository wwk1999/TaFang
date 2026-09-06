using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 战斗界面丹药tem : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;
    [NonSerialized] public int index;
    

    public void SetItem()
    {
        if (PlayerData.S.战斗选择丹药Dic[index].丹药Type == 丹药Type.None)
        {
            icon.gameObject.SetActive(false);
            name.gameObject.SetActive(false);
            count.gameObject.SetActive(false);
            bg.sprite = ResourcesConfig.加号背景框1;
        }
        else
        {
            丹药Type type = PlayerData.S.战斗选择丹药Dic[index].丹药Type;
            QualityType qualityType = PlayerData.S.战斗选择丹药Dic[index].QualityType;
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(qualityType);
            icon.sprite = ResourcesConfig.Get丹药icon(type, qualityType);
            name.text = 丹药Config.丹药名Dic[type];
            count.text = (PlayerData.S.Get丹药数量(type, qualityType)+1).ToString();
        }
    }
}
