using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 孔item : MonoBehaviour
{
   [NonSerialized] public 仙石Type 仙石Type=仙石Type.None;
   public Image icon;
   public void SetItem()
   {
      icon.gameObject.SetActive(仙石Type!=仙石Type.None);
   }
}
