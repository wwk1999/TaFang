using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 道宝item : MonoBehaviour
{
   [NonSerialized] public 道宝Type 道宝Type;
   public GameObject mask;
   public TextMeshProUGUI level;
   public TextMeshProUGUI name;
   public Button bg;
   public Image icon;

   public void SetItem()
   {
      icon.sprite = ResourcesConfig.Get道宝Sprite(道宝Type);
      name.text = 道宝Config.道宝NameDic[道宝Type];
      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(道宝Config.道宝QualityToQuality[道宝Config.道宝品质Dic[道宝Type]]);
      
      if (PlayerData.S.道宝LevelDic[道宝Type] == 0)
      {
         mask.SetActive(true);
         level.gameObject.SetActive(false);
      }
      else
      {
         mask.SetActive(false);
         level.gameObject.SetActive(true);
      }
   }
}
