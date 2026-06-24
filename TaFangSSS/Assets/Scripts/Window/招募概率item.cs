using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 招募概率item : MonoBehaviour
{
   [NonSerialized]public string StringType;

   [NonSerialized]public float Count;
   [NonSerialized]public QualityType QualityType;
   public Image LabelBg;
   public TextMeshProUGUI LabelText;
   public TextMeshProUGUI Title;
   public TextMeshProUGUI CountText;

   public void SetItem()
   {   
      LabelText.text=PropConfig.QualityNameDic[QualityType];
      CountText.text = Count+"%";
      Title.text = PropConfig.QualityNameDic[QualityType]+StringType;
      switch (QualityType)
      {
         case QualityType.黄品:
            LabelBg.sprite = ResourcesConfig.品质标签白;
            break;
         case QualityType.玄品:
            LabelBg.sprite = ResourcesConfig.品质标签绿;
            break;
         case QualityType.地品:
            LabelBg.sprite = ResourcesConfig.品质标签蓝;
            break;
         case QualityType.天品:
            LabelBg.sprite = ResourcesConfig.品质标签紫;
            break;
         case QualityType.宇品:
            LabelBg.sprite = ResourcesConfig.品质标签橙;
            break;
         case QualityType.宙品:
            LabelBg.sprite = ResourcesConfig.品质标签粉;
            break;
         case QualityType.洪品:
            LabelBg.sprite = ResourcesConfig.品质标签红;
            break;
         case QualityType.荒品:
            LabelBg.sprite = ResourcesConfig.品质标签彩;
            break;
      }
   }
}
