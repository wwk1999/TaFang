using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 世界树关卡item : MonoBehaviour
{
    public GameObject 寻宝中;

     public TextMeshProUGUI 关卡名;
    public Image 当前icon;
    public Button bg;
    public GameObject 锁;
    public TextMeshProUGUI suoText;
    [NonSerialized] public int 层数;

    public string get数字(int count)
    {
        switch (count)
        {
            case 1:
                return "一";
            case 2:
                return "二";
            case 3:
                return "三";
            case 4:
                return "四";
            case 5:
                return "五";
            case 6:
                return "六";
            case 7:
                return "七";
            case 8:
                return "八";
            case 9:
                return "九";
            case 10:
                return "十";
        }

        return null;
    }
    public void SetItem()
    {
        寻宝中.gameObject.SetActive(PlayerData.S.世界树寻宝Dic[层数].寻宝);
        bool suo = PlayerData.S.JingJieType < 世界树Config.世界树关卡Dic[层数].jingJieType;
        if (suo)
        {
            关卡名.gameObject.SetActive(false);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮暗;
            当前icon.gameObject.SetActive(false);
            锁.gameObject.SetActive(true);
            suoText.text = JingJieConfig.JingJieNameDic[世界树Config.世界树关卡Dic[层数].jingJieType]+"解锁";
        }
        else
        {
            关卡名.gameObject.SetActive(true);
            关卡名.text = "第"+get数字(层数)+"层";
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮;
            当前icon.gameObject.SetActive(false);
            锁.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("世界树按钮点击",世界树按钮点击);
    }

    private void Awake()
    {
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前世界树层数=层数;
            ObserverModuleManager.S.SendEvent("世界树按钮点击",层数);
            PlayerData.S.清除世界树无用派遣英雄();
        });
        ObserverModuleManager.S.RegisterEvent("世界树按钮点击",世界树按钮点击);
    }
    public void 世界树按钮点击(object[] obj)
    {
        int count = (int)obj[0];
        if (count == 层数)
        {
            当前icon.gameObject.SetActive(true);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮亮;
        }
        else
        {
            当前icon.gameObject.SetActive(false);
            bool suo = PlayerData.S.JingJieType < 世界树Config.世界树关卡Dic[层数].jingJieType;
            if (suo)
            {
                bg.image.sprite = ResourcesConfig.凌霄宝殿按钮暗;
            }
            else
            {
                bg.image.sprite = ResourcesConfig.凌霄宝殿按钮;
            }
        }
    }
}
