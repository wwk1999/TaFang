using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KaPaiItem : MonoBehaviour
{
   [NonSerialized]public HeroType heroType;
   [NonSerialized] public int BianDui = 0;
   public Button bg;
   public GameObject 出战icon;
   public Image 职业icon;
   public Image image;
   public TextMeshProUGUI Name;
   public TextMeshProUGUI Level;
   public Slider Exp;
   public TextMeshProUGUI CurrentExp;
   public TextMeshProUGUI MaxExp;
   public GameObject 合成Obj;
   public Button 合成mask;
   public GameObject 升级Obj;
   public GameObject ActiveMask;

   public void SetItem()
   {
      int level = PlayerData.S.HeroDataDic[heroType].Level;
      int exp = PlayerData.S.HeroDataDic[heroType].元神;
      Exp.maxValue = HeroConfig.HeroExpDic[level].元神;
      Exp.value = exp;
      CurrentExp.text=exp.ToString();
      MaxExp.text=HeroConfig.HeroExpDic[level].元神.ToString();
      image.sprite=ResourcesConfig.GetHeroSprite(heroType);
      Name.text=HeroConfig.HeroNameDic[heroType];
      Level.text=level.ToString();
      if (level > 0 && exp >= HeroConfig.HeroExpDic[level].元神)
      {
         升级Obj.SetActive(true);
      }
      else
      {
         升级Obj.SetActive(false);
      }
      if (level == 0 && exp >= HeroConfig.HeroExpDic[level].元神)
      {
         合成Obj.gameObject.SetActive(true);
      }
      else
      {
         合成Obj.gameObject.SetActive(false);
      }

      if (level == 0)
      {
         ActiveMask.SetActive(true);
      }
      else
      {
         ActiveMask.SetActive(false);
      }
      出战icon.gameObject.SetActive(false);
      foreach (var item in PlayerData.S.出战英雄List[BianDui])
      {
         if (item == heroType)
         {
            出战icon.gameObject.SetActive(true);
         }
      }

      switch (HeroConfig.HeroQualityDic[heroType])
      {
         case QualityType.黄品:
            bg.image.sprite = ResourcesConfig.UI人物背景框白;
            break;
         case QualityType.玄品:
            bg.image.sprite = ResourcesConfig.UI人物背景框绿;
            break;
         case QualityType.地品:
            bg.image.sprite = ResourcesConfig.UI人物背景框蓝;
            break;
         case QualityType.天品:
            bg.image.sprite = ResourcesConfig.UI人物背景框紫;
            break;
         case QualityType.宇品:
            bg.image.sprite = ResourcesConfig.UI人物背景框橙;
            break;
         case QualityType.宙品:
            bg.image.sprite = ResourcesConfig.UI人物背景框粉;
            break;
         case QualityType.洪品:
            bg.image.sprite = ResourcesConfig.UI人物背景框红;
            break;
         case QualityType.荒品:
            bg.image.sprite = ResourcesConfig.UI人物背景框彩;
            break;
      }

      switch (HeroConfig.HeroZhiYeDic[heroType])
      {
         case ZhiYeType.射手:
            职业icon.sprite = ResourcesConfig.射手;
            break;
         case ZhiYeType.战士:
            职业icon.sprite = ResourcesConfig.战士;
            break;
         case ZhiYeType.辅助:
            职业icon.sprite = ResourcesConfig.辅助;
            break;
         case ZhiYeType.法师:
            职业icon.sprite = ResourcesConfig.法师;
            break;
         case ZhiYeType.控制:
            职业icon.sprite = ResourcesConfig.控制;
            break;
      }
   }
}
