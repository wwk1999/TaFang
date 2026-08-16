using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 孔item : MonoBehaviour
{
   [NonSerialized] public 仙石 仙石=null;
   public Image icon;
   public void SetItem()
   {
      icon.gameObject.SetActive(仙石.quality!=QualityType.None);
   }
}
