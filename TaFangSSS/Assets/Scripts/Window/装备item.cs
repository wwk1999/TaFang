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
    });
  }

  public void SetItem()
  {
    QualityType quality=EquipConfig.GetEquipQuality(PlayerData.S.EquipLevelDic[EquipType]);
    bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(quality);
    image.sprite=ResourcesConfig.GetEquipSprite(EquipType,quality);
    Level.text=PlayerData.S.EquipLevelDic[EquipType].ToString();
    Name.text = 多语言Config.Get(EquipType.ToString());
  }
}
