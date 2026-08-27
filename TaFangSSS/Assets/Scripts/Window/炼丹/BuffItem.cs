using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffItem : MonoBehaviour
{
   public Image bg;
   public Image icon;
   public TextMeshProUGUI count;
   [NonSerialized] public 丹药Type 丹药type;
   [NonSerialized] public QualityType QualityType;

   public void SetItem()
   {
      icon.sprite = ResourcesConfig.GetBuffIcon(丹药type, QualityType);
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
      count.text = PlayerData.S.Get辅助丹药Buff(丹药type, QualityType).ToString();
   }
}
