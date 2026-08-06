using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 道纹item : MonoBehaviour, IDropHandler
{
   [NonSerialized]public EquipType equipType;
   [NonSerialized]public QualityType 解锁境界;
   [NonSerialized] public bool Is解锁;
   [NonSerialized] public 道纹Type 道纹Type;
   [NonSerialized]public QualityType 道纹QualityType;

   public GameObject content;
   public GameObject hero;
   public Image heroImage;
   public Image bg;
   public Image image;
   public Image 艺术字;
   public TextMeshProUGUI name;
   public TextMeshProUGUI desc;
   public GameObject 锁mask;
   public TextMeshProUGUI 锁desc;

  
   public void OnDrop(PointerEventData eventData)
   {
      if (HeroWindowController.S.道纹IsDrag)
      {
         if (道纹config.检查装备专属道纹(HeroWindowController.S.道纹Type))
         {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

            ObserverModuleManager.S.SendEvent("SendUIToast","专属道纹只能镶嵌一个");
         }
         else
         {
            道纹Type = HeroWindowController.S.道纹Type;
            道纹QualityType=HeroWindowController.S.道纹QualityType;
            SetItem();
            switch (解锁境界)
            {
               case QualityType.天品:
                  PlayerData.S.装备道纹List[equipType][0].道纹Type = HeroWindowController.S.道纹Type;
                  PlayerData.S.装备道纹List[equipType][0].quality = HeroWindowController.S.道纹QualityType;
                  break;
               case QualityType.宇品:
                  PlayerData.S.装备道纹List[equipType][1].道纹Type = HeroWindowController.S.道纹Type;
                  PlayerData.S.装备道纹List[equipType][1].quality = HeroWindowController.S.道纹QualityType;
                  break;
               case QualityType.宙品:
                  PlayerData.S.装备道纹List[equipType][2].道纹Type = HeroWindowController.S.道纹Type;
                  PlayerData.S.装备道纹List[equipType][2].quality = HeroWindowController.S.道纹QualityType;
                  break;
               case QualityType.洪品:
                  PlayerData.S.装备道纹List[equipType][3].道纹Type = HeroWindowController.S.道纹Type;
                  PlayerData.S.装备道纹List[equipType][3].quality = HeroWindowController.S.道纹QualityType;
                  break;
               case QualityType.荒品:
                  PlayerData.S.装备道纹List[equipType][4].道纹Type = HeroWindowController.S.道纹Type;
                  PlayerData.S.装备道纹List[equipType][4].quality = HeroWindowController.S.道纹QualityType;
                  break;

            }
         }
      }
   }
   public void SetItem()
   {
      if (!Is解锁)
      {
         锁mask.SetActive(true);
         switch (解锁境界)
         {
            case QualityType.天品:
               锁desc.text = "天品解锁";
               break;
            case QualityType.宇品:
               锁desc.text = "宇品解锁";
               break;
            case QualityType.宙品:
               锁desc.text = "宙品解锁";
               break;
            case QualityType.洪品:
               锁desc.text = "洪品解锁";
               break;
            case QualityType.荒品:
               锁desc.text = "荒品解锁";
               break;
         }
      }
      else
      {
         if (道纹Type == 道纹Type.None)
         {
            content.gameObject.SetActive(false);
            return;
         }
         content.gameObject.SetActive(true);
         if (道纹config.是否专属道纹(道纹Type))
         {
            hero.SetActive(true);
            heroImage.sprite = ResourcesConfig.GetHeroSprite(道纹config.道纹ToHeroDic[道纹Type]);
         }
         else
         {
            hero.SetActive(false);
         }
         锁mask.SetActive(false);
         image.sprite = ResourcesConfig.Get道纹Sprite(道纹Type, 道纹QualityType);
         艺术字.sprite = ResourcesConfig.Get艺术字(道纹QualityType);
         bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(道纹QualityType);
         name.text = 道纹config.道纹名Dic[道纹Type];
         desc.text = 道纹config.Get道文info(道纹Type, 道纹QualityType);
      }
   }
}
