using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 道纹grid : MonoBehaviour
{
   [NonSerialized] public 道纹Type 道纹Type;
   [NonSerialized] public QualityType QualityType;

   public Image bg;
   public Image image;
   public TextMeshProUGUI count;
   public TextMeshProUGUI name;

   public void SetItem()
   {
      name.text = 道纹config.道纹名Dic[道纹Type];
      image.sprite = ResourcesConfig.Get道文Sprite(道纹Type, QualityType);
      count.text=PlayerData.S.道纹List[(道纹Type,QualityType)].ToString();
      switch (QualityType)
      {
         case QualityType.天品:
            bg.sprite = ResourcesConfig.道具背景框紫;
            break;
         case QualityType.宇品:
            bg.sprite = ResourcesConfig.道具背景框橙;
            break;
         case QualityType.宙品:
            bg.sprite = ResourcesConfig.道具背景框粉;
            break;
         case QualityType.洪品:
            bg.sprite = ResourcesConfig.道具背景框红;
            break;
         case QualityType.荒品:
            bg.sprite = ResourcesConfig.道具背景框彩;
            break;
      }
   }
   
}
