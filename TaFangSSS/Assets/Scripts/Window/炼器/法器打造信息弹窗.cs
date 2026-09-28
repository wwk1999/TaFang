using System;
using System.Collections;
using System.Collections.Generic;
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

   public void SetItem()
   {
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器type]);
      icon.sprite = ResourcesConfig.Get法器Sprite(法器type);
      name.text = 法器Config.法器名Dic[法器type];
      职业.text="职业："+法器Config.法器职业Dic[法器type];
      词条数量.text=((int)法器Config.法器品质Dic[法器type]).ToString();
      伤害增幅.text = 法器Config.法器基础属性Dic[法器Config.法器品质Dic[法器type]] + "%";
      孔数.text = "0-" + (int)法器Config.法器品质Dic[法器type];
   }
}
