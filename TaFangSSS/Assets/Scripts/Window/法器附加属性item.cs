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
      countText.text = count.ToString("F1")+"%";
      text.text = 法器Config.法器附加属性Desc[法器附加属性Type]+":";
   }
}
