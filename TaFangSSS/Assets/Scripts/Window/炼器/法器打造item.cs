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

   [NonSerialized] public 法器Type 法器Type;

   public void 刷新法器打造Panel(object[] obj)
   {
      gou.SetActive(法器Type==HeroWindowController.S.法器打造法器Type);
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
         ObserverModuleManager.S.SendEvent("刷新法器打造Panel");
      });
   }

   public void SetItem()
   {
      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器Type]);
      icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
      name.text = 法器Config.法器名Dic[法器Type];
      gou.gameObject.SetActive(false);
   }
}
