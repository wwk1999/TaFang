using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 城墙法宝item : MonoBehaviour
{
   [NonSerialized]public 城墙道具Type type;
   public Image bg;
   public Button img;
   public TextMeshProUGUI name;
   public TextMeshProUGUI level;
   public GameObject mask;
   
   public void SetItem()
   {
      if (PlayerData.S.城墙道具等级Dic[type] == 0)
      {
         mask.gameObject.SetActive(true);
         level.gameObject.SetActive(false);
      }
      else
      {
         mask.gameObject.SetActive(false);
         level.gameObject.SetActive(true);
      }
      level.text="LV."+PlayerData.S.城墙道具等级Dic[type];
      QualityType quality=城墙Config.城墙道具QualityDic[type];
      bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(quality);
      img.image.sprite = ResourcesConfig.Get城墙Sprite(type);
      name.text = 城墙Config.城墙道具名Dic[type];
   }
}
