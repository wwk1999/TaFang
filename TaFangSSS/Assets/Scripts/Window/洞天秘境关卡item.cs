using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 洞天秘境关卡item : MonoBehaviour
{
    [NonSerialized] public JingJieType JingJieType;
    public GameObject suo;
    public Button bg;
    public Image 当前icon;
    public TextMeshProUGUI 关卡名;

    public void SetItem()
    {
        if (PlayerData.S.当前轮回境界 == JingJieType)
        {
            suo.SetActive(false);
            关卡名.gameObject.SetActive(true);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮亮;
            当前icon.gameObject.SetActive(true);
            关卡名.text=JingJieConfig.JingJieNameDic[JingJieType]+"境";
        }
        else
        {
            suo.SetActive(true);
            关卡名.gameObject.SetActive(false);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮暗;
            当前icon.gameObject.SetActive(false);
        }
    }
}
