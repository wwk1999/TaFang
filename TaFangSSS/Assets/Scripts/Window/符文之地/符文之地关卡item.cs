using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文之地关卡item : MonoBehaviour
{
    public TextMeshProUGUI 关卡名;
    public Image 当前icon;
    public Button bg;
    public GameObject 锁;
    public TextMeshProUGUI suoText;
    [NonSerialized] public 符文之地Type 符文之地Type;
    
    
    
    public void 符文之地按钮点击(object[] obj)
    {
        符文之地Type Type = (符文之地Type)obj[0];
        if (Type == 符文之地Type)
        {
            当前icon.gameObject.SetActive(true);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮亮;
        }
        else
        {
            当前icon.gameObject.SetActive(false);
            bool suo = PlayerData.S.符文之地最大关卡 < 符文之地Type;
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
    
    
    private void Awake()
    {
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前符文之地Type = 符文之地Type;
            ObserverModuleManager.S.SendEvent("符文之地按钮点击",符文之地Type);
        });
        ObserverModuleManager.S.RegisterEvent("符文之地按钮点击",符文之地按钮点击);
    }
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("符文之地按钮点击",符文之地按钮点击);
    }
    
    public void SetItem()
    {
        bool suo = PlayerData.S.符文之地最大关卡 < 符文之地Type;
        if (suo)
        {
            关卡名.gameObject.SetActive(false);
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮暗;
            当前icon.gameObject.SetActive(false);
            锁.gameObject.SetActive(true);
            suoText.text = (int)(符文之地Type) + ". ???";
        }
        else
        {
            关卡名.gameObject.SetActive(true);
            关卡名.text = (int)(符文之地Type) + ". "+符文之地Config.符文之地关卡名Dic[符文之地Type];
            bg.image.sprite = ResourcesConfig.凌霄宝殿按钮;
            当前icon.gameObject.SetActive(false);
            锁.gameObject.SetActive(false);
        }
    }
}
