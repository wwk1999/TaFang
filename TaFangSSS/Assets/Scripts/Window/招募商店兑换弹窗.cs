using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 招募商店兑换弹窗 : MonoBehaviour
{
   public TextMeshProUGUI Name;
   public TextMeshProUGUI Description;
   public Button Jia;
   public Button Jian;
   public TextMeshProUGUI JiFen;
   public TextMeshProUGUI Count;
   public Image bg;
   public Image image;
   public Button DuiHuanButton;
   [NonSerialized] public PropType Type;
   public Button mask;
   private int count = 1;
   public Button exitbutton;

   public void DuiHuan()
   {
      PlayerData.S.HeroDataDic[PropConfig.PropToHeroDic[Type]].元神+=count;
      ObserverModuleManager.S.SendEvent("SendUIToast","兑换成功");
   }
   private void Start()
   {
      exitbutton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      Jia.onClick.AddListener(() =>
      {
         count++;
         Count.text = count.ToString();
      });
      
      Jian.onClick.AddListener(() =>
      {
         count--;
         count=Math.Max(count,1);
         Count.text = count.ToString();
      });
      DuiHuanButton.onClick.AddListener(() =>
      {
         DuiHuan();
      });
      mask.onClick.AddListener(() =>
         {
            gameObject.SetActive(false);
         });
   }

   public void SetItem()
   {
      Name.text=HeroConfig.HeroNameDic[PropConfig.PropToHeroDic[Type]];
      Description.text=HeroConfig.HeroDescDic[PropConfig.PropToHeroDic[Type]];
      image.sprite = ResourcesConfig.GetHeroSprite(PropConfig.PropToHeroDic[Type]);
      JiFen.text = ZhaoMuConfig.招募商店价格Dic[Type].ToString();
      switch (PropConfig.PropQualityDic[Type])
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
