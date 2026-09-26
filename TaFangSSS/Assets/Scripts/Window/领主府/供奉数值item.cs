using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 供奉数值item : MonoBehaviour
{
   [NonSerialized] public 建筑Type 建筑Type;
   [NonSerialized] public float count;
   public TextMeshProUGUI name;
   public Image icon;
   public TextMeshProUGUI countText;

   public void SetItem()
   {
      name.text = 道场Config.Get领主数值string(建筑Type);
      icon.sprite = ResourcesConfig.Get领主数值icon(建筑Type);
      countText.text = count.ToString("F0");
   }
}
