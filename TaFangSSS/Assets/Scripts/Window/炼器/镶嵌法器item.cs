using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 镶嵌法器item : MonoBehaviour
{
   [NonSerialized] public 法器 法器 = null;
   public Button bg;
   public Image icon;
   public TextMeshProUGUI name;
   public GameObject gou;

   public void SetItem()
   {
      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器.法器Type]);
      icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
      name.text = 法器Config.法器名Dic[法器.法器Type];
      gou.SetActive(HeroWindowController.S.仙石镶嵌panel当前法器==法器);
   }

   public void 镶嵌法器点击(object[] obj)
   {
      法器 法器1 = obj[0] as 法器;
      gou.SetActive(法器1==法器);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("镶嵌法器点击",镶嵌法器点击);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("镶嵌法器点击",镶嵌法器点击);
      bg.onClick.AddListener(() =>
         {
            HeroWindowController.S.仙石镶嵌panel当前法器 = 法器;
            ObserverModuleManager.S.SendEvent("镶嵌法器点击",法器);
         }
      );
   }
}
