using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 全局效果item : MonoBehaviour
{
   public TextMeshProUGUI name;
   public TextMeshProUGUI desc;
   [NonSerialized] public 宝物Type 宝物Type;

   public void SetItem()
   {
      name.text = 灵矿场Config.宝物效果名[宝物Type];
      desc.text = 灵矿场Config.Get总宝物效果(宝物Type);
   }
}
