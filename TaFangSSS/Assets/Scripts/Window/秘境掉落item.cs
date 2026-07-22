using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 秘境掉落item : MonoBehaviour
{
   [NonSerialized]public QualityType Quality;
   public Image bg;

   public void SetItem()
   {
      bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(Quality);
   }
}
