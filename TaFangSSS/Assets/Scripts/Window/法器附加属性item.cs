using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 法器附加属性item : MonoBehaviour
{
   [NonSerialized] public 法器附加属性Type 法器附加属性Type;
   [NonSerialized] public float count;
   public TextMeshProUGUI text;
   public TextMeshProUGUI countText;


   public void SetItem()
   {
      countText.text = count.ToString("F1")+"%";
      text.text = 法器Config.法器附加属性Desc[法器附加属性Type]+":";
   }
}
