using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 招募成功item : MonoBehaviour
{
   [NonSerialized]public PropType propType;
   public Image bg;
   public TextMeshProUGUI name;
   public Image image;
   public void SetItem()
   {
      if (propType == PropType.None)
      {
         return;
      }
      name.text=PropConfig.PropNameDic[propType];
      image.sprite=PropConfig.GetPropSprite(propType);
      QualityType qualityType = PropConfig.PropQualityDic[propType];
      switch (qualityType)
      {
         case QualityType.黄品:
            bg.sprite = ResourcesConfig.道具背景框白;
            break;
         case QualityType.玄品:
            bg.sprite = ResourcesConfig.道具背景框绿;
            break;
         case QualityType.地品:
            bg.sprite = ResourcesConfig.道具背景框蓝;
            break;
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
