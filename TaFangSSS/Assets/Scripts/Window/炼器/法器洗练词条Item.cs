using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 法器洗练词条Item : MonoBehaviour
{
   public TextMeshProUGUI text;
   [NonSerialized] public 法器附加属性值 法器附加属性值;

   public void SetItem()
   {
      text.text = 法器Config.法器附加属性Desc[法器附加属性值.法器附加属性Type] + "+" +
                  $"<color=green>{法器附加属性值.count.ToString("F1")}%</color>";
   }
}
