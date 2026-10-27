using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器打造信息弹窗 : MonoBehaviour
{
   public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI 职业;
   public TextMeshProUGUI 词条数量;
   public TextMeshProUGUI 伤害增幅;
   public TextMeshProUGUI 孔数;

   [NonSerialized] public 法器Type 法器type;
   [NonSerialized] public int 阶数 = 1;

   public void SetItem()
   {
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.Get阶数对应品质(阶数));
      icon.sprite = ResourcesConfig.Get法器Sprite(法器type, 阶数);
      name.text = 法器Config.Get法器Name(法器type, 阶数);
      职业.text="职业："+法器Config.法器职业Dic[法器type];
      词条数量.text="0";
      伤害增幅.text = 法器Config.Get法器基础伤害(阶数, QualityType.黄品) + "%";
      孔数.text = "0";
   }
}
