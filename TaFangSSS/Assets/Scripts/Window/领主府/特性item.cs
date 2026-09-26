using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 特性item : MonoBehaviour
{
   [NonSerialized]public 供奉特性Type  供奉特性Type;
   [NonSerialized]public 供奉品质Type  供奉品质Type;
   public Image bg;
   public TextMeshProUGUI name;

   public void SetItem()
   {
      bg.sprite = ResourcesConfig.Get供奉特性标签(供奉品质Type);
      name.text = 道场Config.供奉特性名Dic[供奉特性Type];
   }

}
