using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 凌霄宝殿item : MonoBehaviour
{
  public TextMeshProUGUI 关卡名;
  public Image 当前icon;
  public Button bg;
  public GameObject 锁;
  public TextMeshProUGUI suoText;
  [NonSerialized] public 主线关卡Type 主线关卡Type;

  public void 凌霄宝殿按钮点击(object[] obj)
  {
    主线关卡Type Type = (主线关卡Type)obj[0];
    if (Type == 主线关卡Type)
    {
      当前icon.gameObject.SetActive(true);
      bg.image.sprite = ResourcesConfig.凌霄宝殿按钮亮;
    }
    else
    {
      当前icon.gameObject.SetActive(false);
      bool suo = PlayerData.S.最大主线关卡 < 主线关卡Type;
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
      HeroWindowController.S.当前凌霄宝殿Type = 主线关卡Type;
      ObserverModuleManager.S.SendEvent("凌霄宝殿按钮点击",主线关卡Type);
    });
    ObserverModuleManager.S.RegisterEvent("凌霄宝殿按钮点击",凌霄宝殿按钮点击);
  }

  private void OnDestroy()
  {
    ObserverModuleManager.S.UnRegisterEvent("凌霄宝殿按钮点击",凌霄宝殿按钮点击);
  }

  public void SetItem()
  {
    bool suo = PlayerData.S.最大主线关卡 < 主线关卡Type;
    if (suo)
    {
      关卡名.gameObject.SetActive(false);
      bg.image.sprite = ResourcesConfig.凌霄宝殿按钮暗;
      当前icon.gameObject.SetActive(false);
      锁.gameObject.SetActive(true);
      suoText.text = (int)(主线关卡Type - 15) + ". ???";
    }
    else
    {
      关卡名.gameObject.SetActive(true);
      关卡名.text = (int)(主线关卡Type - 15) + ". "+LevelConfig.主线关卡NameDic[主线关卡Type];
      bg.image.sprite = ResourcesConfig.凌霄宝殿按钮;
      当前icon.gameObject.SetActive(false);
      锁.gameObject.SetActive(false);
    }
  }
}
