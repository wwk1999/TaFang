using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文附魔法器item : MonoBehaviour
{
   public Button bg;
   public Image icon;
   public TextMeshProUGUI name;
   public GameObject gou;
   public GameObject 出战;
   [NonSerialized] public 法器 法器;

   public void SetItem()
   {
      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器.法器Type]);
      icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
      name.text = 法器Config.法器名Dic[法器.法器Type];
      name.colorGradientPreset = ResourcesConfig.Get品质TMP(法器Config.法器品质Dic[法器.法器Type]);
      gou.SetActive(false);
      出战.SetActive(法器.HeroType!=HeroType.None);
   }
}
