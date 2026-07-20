using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 城墙装备item : MonoBehaviour
{
   [NonSerialized] public QualityType 城墙装备QualityType;
   [NonSerialized] public 城墙道具Type 城墙道具Type;
   public Image bg;
   public GameObject content;
   public GameObject suo;
   public TextMeshProUGUI SuoText;
   public Image icon;
   public Image 艺术字;
   public TextMeshProUGUI Name;
   public TextMeshProUGUI level;

   public void SetItem()
   {
      int 解锁等级=城墙Config.城墙解锁等级Dic[城墙装备QualityType];
      if (PlayerData.S.城墙等级 < 解锁等级)
      {
         bg.sprite=ResourcesConfig.Get城墙装备背景框(QualityType.黄品);
         content.gameObject.SetActive(false);
         suo.gameObject.SetActive(true);
         SuoText.text = "LV." + 解锁等级 + "解锁";
      }
      else
      {
         suo.gameObject.SetActive(false);
         if (城墙道具Type == 城墙道具Type.None)
         {
            bg.sprite=ResourcesConfig.Get城墙装备背景框(QualityType.黄品);
            content.gameObject.SetActive(false);
         }
         else
         {
            content.gameObject.SetActive(true);
            QualityType quality = 城墙Config.城墙道具QualityDic[城墙道具Type];
            bg.sprite=ResourcesConfig.Get城墙装备背景框(quality);
            icon.sprite = ResourcesConfig.Get城墙Sprite(城墙道具Type);
            艺术字.sprite=ResourcesConfig.Get艺术字(quality);
            Name.text = 城墙Config.城墙道具名Dic[城墙道具Type];
            level.text = "LV." + PlayerData.S.城墙道具等级Dic[城墙道具Type];
         }
      }
   }
}
