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
   [NonSerialized] public QualityType 品质;
   [NonSerialized] public int 阶数;
   public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI 职业;
   public TextMeshProUGUI 基础伤害;
   public TextMeshProUGUI 词条;
   public TextMeshProUGUI 孔数;

   public void SetItem()
   {
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(品质);
      icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
      name.text = 法器Config.法器名Dic[法器Type];
      name.colorGradientPreset = ResourcesConfig.Get品质TMP(品质);
      职业.text = HeroConfig.Get职业Name(法器Config.法器职业Dic[法器Type]);
      基础伤害.text = 法器Config.法器基础属性Dic[阶数].ToString();
      词条.text = "0";
      孔数.text = "0";
   }
}
