using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹药选择Item : MonoBehaviour
{
   public Button bg;
   public Image icon;
   public GameObject gou;
   public TextMeshProUGUI name;
   public TextMeshProUGUI count;
   [NonSerialized] public 丹药Type 丹药Type;
   [NonSerialized] public QualityType QualityType;
   [NonSerialized] public int 阶段 = 1;

   public void SetItem()
   {
      name.text = 丹药Config.丹药名Dic[丹药Type] + "·" + 阶段 + "阶";
      count.text = PlayerData.S.Get丹药数量(丹药Type, QualityType, 阶段).ToString();
      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
      icon.sprite=ResourcesConfig.Get丹药icon(丹药Type,QualityType);
      gou.SetActive(false);
   }

   public void 丹药选择点击(object[] obj)
   {
      丹药Type 丹药Type1 = (丹药Type)obj[0];
      QualityType QualityType1 = (QualityType)obj[1];
      int 阶段1 = (int)obj[2];
      if (丹药Type1 == 丹药Type && QualityType1 == QualityType && 阶段1 == 阶段)
      {
         gou.SetActive(true);
      }
      else
      {
         gou.SetActive(false);
      }
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("丹药选择点击",丹药选择点击);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("丹药选择点击",丹药选择点击);
      bg.onClick.AddListener(() =>
      {
         HeroWindowController.S.当前选择丹药Type = 丹药Type;
         HeroWindowController.S.当前选择丹药QualityType = QualityType;
         HeroWindowController.S.当前选择丹药阶段 = 阶段;
         ObserverModuleManager.S.SendEvent("丹药选择点击",丹药Type,QualityType,阶段);
      });
   }
}
