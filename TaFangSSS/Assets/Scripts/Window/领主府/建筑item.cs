using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 建筑item : MonoBehaviour
{
   public Button bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI 等级;

   [NonSerialized] public 建筑Type 建筑Type;

   public void SetItem()
   {
      icon.sprite = ResourcesConfig.Get道场Sprite(建筑Type);
      bg.image.sprite = ResourcesConfig.建筑item暗;
      name.text = 道场Config.Get道场建筑名(建筑Type);
      等级.text="等级："+PlayerData.S.建筑等级Dic[建筑Type].ToString();
   }
}
