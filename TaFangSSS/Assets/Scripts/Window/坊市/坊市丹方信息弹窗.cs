using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 坊市丹方信息弹窗 : MonoBehaviour
{
   [NonSerialized] public 丹药Type 丹药Type;
   [NonSerialized] public int 阶数;
   public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI 类型;
   public TextMeshProUGUI info;
   public TextMeshProUGUI 等级;
   public TextMeshProUGUI 丹药名;
   public TextMeshProUGUI 丹药介绍;

   public void SetItem()
   {
      QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(材料品质);
      icon.sprite = ResourcesConfig.Get丹药icon(丹药Type, 材料品质); // 丹方icon按阶数对应的材料品质取
      name.text = $"{丹药Config.丹方名Dic[丹药Type]}·{阶数}阶";
      name.colorGradientPreset = ResourcesConfig.Get品质TMP(材料品质);
      类型.text = 丹药Config.丹药类型String[丹药Config.丹药类型Dic[丹药Type]];
      info.text = 丹药Config.丹方DescDic[丹药Type];
      等级.text = $"炼丹等级Lv{丹药Config.Get炼丹等级要求(丹药Type, 阶数)}";
      丹药名.text = $"{丹药Config.丹药名Dic[丹药Type]}·{阶数}阶";
      丹药介绍.text = 丹药Config.Get丹药Desc(丹药Type, 材料品质);
   }
}
