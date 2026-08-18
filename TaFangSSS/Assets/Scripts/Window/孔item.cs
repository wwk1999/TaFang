using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 孔item : MonoBehaviour
{
   [NonSerialized] public 仙石 仙石=null;
   public Image icon;
   public Image bg;
   public void SetItem()
   {
      if (仙石.type == 仙石Type.None)
      {
         bg.sprite = ResourcesConfig.孔背景框;
         icon.gameObject.SetActive(false);
      }
      else
      {
         icon.gameObject.SetActive(true);
         bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(仙石.quality);
         icon.sprite = ResourcesConfig.Get仙石Sprite(仙石.type, 仙石.quality);
      }
   }
}
