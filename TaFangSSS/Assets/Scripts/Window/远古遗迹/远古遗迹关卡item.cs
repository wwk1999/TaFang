using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 远古遗迹关卡item : MonoBehaviour
{
    [NonSerialized] public 神物Type 神物Type;
    public TextMeshProUGUI 关卡名;
    public Image 当前icon;
    public Button bg;
    public GameObject 锁;
    public GameObject 已获得;
    
    public void 遗迹关卡按钮点击(object[] obj)
    {
        神物Type Type = (神物Type)obj[0];
        if (Type == 神物Type)
        {
            当前icon.gameObject.SetActive(true);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮亮;
        }
        else
        {
            当前icon.gameObject.SetActive(false);
            bool suo = PlayerData.S.最大神物关卡 < 神物Type;
            已获得.SetActive(PlayerData.S.最大神物关卡>神物Type);            if (suo)
            {
                bg.image.sprite = ResourcesConfig.凌霄宝殿按钮暗;
            }
            else
            {
                bg.image.sprite = ResourcesConfig.凌霄宝殿按钮;
            }
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("遗迹关卡按钮点击",遗迹关卡按钮点击);
    }

    private void Awake()
    {
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前遗迹关卡Type = 神物Type;
            ObserverModuleManager.S.SendEvent("遗迹关卡按钮点击",神物Type);
        });
        ObserverModuleManager.S.RegisterEvent("遗迹关卡按钮点击",遗迹关卡按钮点击);
    }
    
    public void SetItem()
    {
        bool suo = PlayerData.S.最大神物关卡 < 神物Type;
        已获得.SetActive(PlayerData.S.最大神物关卡>神物Type);
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
            关卡名.text = 神物Config.神物名Dic[神物Type];
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮;
            当前icon.gameObject.SetActive(false);
            锁.gameObject.SetActive(false);
        }
    }
}
