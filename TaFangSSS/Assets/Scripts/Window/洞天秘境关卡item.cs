using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 洞天秘境关卡item : MonoBehaviour
{
    [NonSerialized]public JingJieType jingJieType;
    public TextMeshProUGUI 关卡名;
    public Image 当前icon;
    public Button bg;
    public GameObject 锁;
    
    public void SetItem()
    {
        bool suo = PlayerData.S.JingJieType != jingJieType;
        if (suo)
        {
            关卡名.gameObject.SetActive(false);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮暗;
            当前icon.gameObject.SetActive(false);
            锁.gameObject.SetActive(true);
        }
        else
        {
            关卡名.gameObject.SetActive(true);
            关卡名.text = JingJieConfig.JingJieNameDic[PlayerData.S.JingJieType]+"境";
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮;
            当前icon.gameObject.SetActive(false);
            锁.gameObject.SetActive(false);
        }
    }
}
