using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 强化装备item : MonoBehaviour
{
   public Button bg;
   public TextMeshProUGUI Name;
   public Image image;
   public TextMeshProUGUI level;
   [NonSerialized]public EquipType equipType;
   [NonSerialized]public EquipType clickType;


   public void 强化弹窗装备点击(object[] obj)
   {
      EquipType Type = (EquipType)obj[0];
      if (Type == equipType)
      {
         bg.image.sprite = ResourcesConfig.强化窗口装备背景框亮;
      }
      else
      {
         bg.image.sprite = ResourcesConfig.强化窗口装备背景框暗;
      }
   }

   private void Awake()
   {
      ObserverModuleManager.S.RegisterEvent("强化弹窗装备点击",强化弹窗装备点击);
      bg.onClick.AddListener(() =>
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.按钮点击);
         ObserverModuleManager.S.SendEvent("强化装备Item点击",equipType);
      });
   }

   public void SetItem()
   {
      level.text="+"+PlayerData.S.EquipLevelDic[equipType];
      if (equipType == clickType)
      {
         bg.image.sprite = ResourcesConfig.强化窗口装备背景框亮;
      }
      else
      {
         bg.image.sprite = ResourcesConfig.强化窗口装备背景框暗;

      }
      image.sprite=ResourcesConfig.GetEquipSprite(equipType,EquipConfig.GetEquipQuality(equipType));
      Name.text = 多语言Config.Get(equipType.ToString());
   }
}
