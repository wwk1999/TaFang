using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 装备item : MonoBehaviour
{
  public Button bgButton;
  public Image bg;
  public Image image;
  public TextMeshProUGUI Name;
  public TextMeshProUGUI Level;
  [NonSerialized]public EquipType EquipType;

  private void Start()
  {
    bgButton.onClick.AddListener(() =>
    {
      ObserverModuleManager.S.SendEvent("播放音效",音效Type.按钮点击);
      ObserverModuleManager.S.SendEvent("Show道纹弹窗",EquipType);
    });
  }

  public void SetItem()
  {
    QualityType quality=EquipConfig.GetEquipQuality(PlayerData.S.EquipLevelDic[EquipType]);
    bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(quality);
    image.sprite=ResourcesConfig.GetEquipSprite(EquipType,quality);
    Level.text=PlayerData.S.EquipLevelDic[EquipType].ToString();
    switch (EquipType)
    {
      case EquipType.头盔:
        Name.text = "头盔";
        break;
      case EquipType.衣服:
        Name.text = "衣服";
        break;
      case EquipType.鞋子:
        Name.text = "鞋子";
        break;
      case EquipType.护手:
        Name.text = "护手";
        break;
      case EquipType.项链:
        Name.text = "项链";
        break;
      case EquipType.戒指:
        Name.text = "戒指";
        break;
    }
  }
}
