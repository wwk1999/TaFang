using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 英雄详情当前装备item : MonoBehaviour
{
   public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   [NonSerialized] public 法器 法器;
   public void SetItem()
   {
      if (法器 == null)
      {
         bg.sprite = ResourcesConfig.装备背景框;
         icon.gameObject.SetActive(false);
         name.gameObject.SetActive(false);
         return;
      }
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器.品质);
      icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type, 法器.阶数);
      name.text = 法器Config.Get法器Name(法器.法器Type, 法器.阶数);
      name.colorGradientPreset = ResourcesConfig.Get品质TMP(法器.品质);
   }
}
