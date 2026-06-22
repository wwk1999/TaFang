using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 附加属性item : MonoBehaviour
{
   public Image bg;
   public TextMeshProUGUI labeltext;
   public TextMeshProUGUI info;
   public Button Suo;
   public GameObject mask;
   public TextMeshProUGUI masktext;
   [NonSerialized] public 附加属性Type 附加属性Type;
   [NonSerialized]public QualityType QualityType;
   [NonSerialized]public bool IsSuo=false;
   [NonSerialized]public QualityType JieSuoQualityType;
   [NonSerialized]public EquipType EquipType;

   public void SetItem()
   {
      if (EquipConfig.GetEquipQuality(EquipType) < JieSuoQualityType)
      {
         mask.SetActive(true);
         masktext.text = PropConfig.QualityNameDic[JieSuoQualityType] + "解锁";
      }
      else
      {
         mask.SetActive(false);
         bg.sprite = ResourcesConfig.Get标签背景(QualityType);
         labeltext.text=PropConfig.QualityNameDic[QualityType];
         info.text = EquipConfig.附加属性NameDic[附加属性Type] + "+" + EquipConfig.附加属性数值Dic[附加属性Type][(int)(QualityType-2)]+"%";
         if (IsSuo)
         {
            Suo.image.sprite = ResourcesConfig.锁;
         }
         else
         {
            Suo.image.sprite = ResourcesConfig.解锁;
         }
      }
   }
}
