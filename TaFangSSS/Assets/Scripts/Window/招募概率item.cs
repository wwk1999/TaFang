using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 招募概率item : MonoBehaviour
{
   [NonSerialized]public JingJieType jingJieType;
   [NonSerialized]public QualityType QualityType;
   [NonSerialized]public bool IsGaoJi=false;
   public Image LabelBg;
   public TextMeshProUGUI LabelText;
   public TextMeshProUGUI Title;
   public TextMeshProUGUI Count;

   public void SetItem()
   {   
      LabelText.text=PropConfig.QualityNameDic[QualityType];
      if (!IsGaoJi)
      {
         Count.text = ZhaoMuConfig.ZhaoMuGaiLvNormalDic[jingJieType][(int)QualityType-1].count.ToString();
      }
      else
      {
         Count.text = ZhaoMuConfig.ZhaoMuGaiLvGaoJiDic[jingJieType][(int)QualityType-1].count.ToString();
      }
      Title.text = PropConfig.QualityNameDic[QualityType]+"元神";
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
