using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 城墙道具升级信息item : MonoBehaviour
{
   public TextMeshProUGUI level;
   public TextMeshProUGUI info;
   public Image suo;
   public Image gou;
   [NonSerialized] public 城墙道具Type 城墙道具Type;
   [NonSerialized] public int 解锁level;

   public void SetItem()
   {
      int 等级 = PlayerData.S.城墙道具等级Dic[城墙道具Type];
      bool 解锁 = 等级 >= 解锁level;
      level.text = 解锁level + "级";
      switch (解锁level)
      {
         case 3:
            info.text=城墙Config.城墙道具属性升级Info[城墙Config.城墙道具属性Dic[城墙道具Type]][0];
            break;
         case 6:
            info.text=城墙Config.城墙道具属性升级Info[城墙Config.城墙道具属性Dic[城墙道具Type]][1];
            break;
         case 10:
            info.text=城墙Config.城墙道具属性升级Info[城墙Config.城墙道具属性Dic[城墙道具Type]][2];
            break;
         case 15:
            info.text=城墙Config.城墙道具属性升级Info[城墙Config.城墙道具属性Dic[城墙道具Type]][3];
            break;
         case 25:
            info.text=城墙Config.城墙道具属性升级Info[城墙Config.城墙道具属性Dic[城墙道具Type]][4];
            break;
      }
      if (解锁)
      {
         gou.gameObject.SetActive(true);
         suo.gameObject.SetActive(false);
      }
      else
      {
         gou.gameObject.SetActive(false);
         suo.gameObject.SetActive(true);
      }
   }
}
