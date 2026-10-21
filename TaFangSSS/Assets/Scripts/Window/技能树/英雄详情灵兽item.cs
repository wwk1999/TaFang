using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 英雄详情灵兽item : MonoBehaviour
{
   public Button bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI 阶段;
   public TextMeshProUGUI 血脉;
   public GameObject 头像;
   public Image 头像icon;
   [NonSerialized] public 灵兽 灵兽;
   [NonSerialized] public HeroType HeroType;

   private void Start()
   {
      bg.onClick.AddListener(() =>
      {
         if (灵兽 == null) return;
       
            // 一个英雄只能携带一只灵兽：先把当前英雄已装备的灵兽卸下
            var 灵兽列表 = PlayerData.S.灵兽列表;
            for (int i = 0; i < 灵兽列表.Count; i++)
            {
               if (灵兽列表[i].HeroType == HeroType)
               {
                  灵兽列表[i].HeroType = HeroType.None;
               }
            }
            灵兽.HeroType = HeroType;
            PlayerData.S.HeroDataDic[HeroType].灵兽 = 灵兽;
         ObserverModuleManager.S.SendEvent("刷新英雄详情界面");
      });
   }

   public void SetItem()
   {
      头像.SetActive(灵兽.HeroType != HeroType.None);
      if (灵兽.HeroType != HeroType.None)
      {
         头像icon.sprite = ResourcesConfig.GetHeroSprite(灵兽.HeroType);
      }
      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(灵兽.QualityType);
      icon.sprite = ResourcesConfig.Get灵兽Sprite(灵兽.灵兽Type);
      name.text = 灵兽坊Config.灵兽名[灵兽.灵兽Type];
      name.colorGradientPreset = ResourcesConfig.Get品质TMP(灵兽.QualityType);
      阶段.text = 灵兽坊Config.阶段Name[灵兽.阶段Type];
      血脉.text = 灵兽坊Config.血脉Name[灵兽.血脉Type];
   }
}
