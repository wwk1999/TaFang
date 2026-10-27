using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器打造item : MonoBehaviour
{
   public Button bg;
   public Image icon;
   public TextMeshProUGUI name;
   public GameObject gou;
   public TextMeshProUGUI count;
   public GameObject mask;
   [NonSerialized] public 法器Type 法器Type;
   [NonSerialized] public int 阶数 = 1;

   public void 刷新法器打造Panel(object[] obj)
   {
      gou.SetActive(法器Type==HeroWindowController.S.法器打造法器Type && 阶数==HeroWindowController.S.法器打造法器阶数);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新法器打造Panel",刷新法器打造Panel);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新法器打造Panel",刷新法器打造Panel);

      bg.onClick.AddListener(() =>
      {
         HeroWindowController.S.法器打造法器Type = 法器Type;
         HeroWindowController.S.法器打造法器阶数 = 阶数;
         ObserverModuleManager.S.SendEvent("刷新法器打造Panel");
      });
   }

   public void SetItem()
   {
      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.Get阶数对应品质(阶数));
      icon.sprite = ResourcesConfig.Get法器Sprite(法器Type, 阶数);
      name.text = 法器Config.Get法器Name(法器Type, 阶数);
      gou.gameObject.SetActive(false);
      int count1=法器Config.Get最大打造数量(法器Type, 阶数);
      count.text = count1.ToString();
      mask.gameObject.SetActive(count1==0);
   }
}
