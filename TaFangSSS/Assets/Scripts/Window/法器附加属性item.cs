using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class 法器附加属性item : MonoBehaviour
{
   [NonSerialized] public 法器附加属性Type 法器附加属性Type;
   [NonSerialized] public float count;
   [NonSerialized] public bool 无暇;
   [NonSerialized] public QualityType QualityType;
   public TextMeshProUGUI text;
   public TextMeshProUGUI countText;
   public TextMeshProUGUI 无暇text;

   public void SetItem()
   {
      无暇text.gameObject.SetActive(无暇);
      无暇text.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
      // 词条只存基础值，品质倍率统一在此乘算展示，与Get法器属性保持同一数值口径
      float 倍率 = 1f;
      if (法器Config.法器品质倍率.TryGetValue(QualityType, out var 品质倍率)) 倍率 = 品质倍率;
      countText.text = (count * 倍率).ToString("F1")+"%";
      text.text = 法器Config.法器附加属性Desc[法器附加属性Type]+":";
   }
}
