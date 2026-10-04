using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 坊市法器信息弹窗 : MonoBehaviour
{
   [NonSerialized] public 法器Type 法器Type;
   public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI 职业;
   public TextMeshProUGUI 基础伤害;
   public TextMeshProUGUI 词条;
   public TextMeshProUGUI 孔数;

   public void SetItem()
   {
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器Type]);
      icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
      name.text = 法器Config.法器名Dic[法器Type];
      职业.text = HeroConfig.Get职业Name(法器Config.法器职业Dic[法器Type]);
      基础伤害.text = 法器Config.法器基础属性Dic[法器Config.法器品质Dic[法器Type]].ToString();
      QualityType qualityType=法器Config.法器品质Dic[法器Type];
      词条.text = ((int)qualityType).ToString();
      孔数.text = "0-"+(int)qualityType;
   }
}
