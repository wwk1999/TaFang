using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 供奉数值item : MonoBehaviour
{
   [NonReorderable] public 建筑Type 建筑Type;
   [NonSerialized] public float count;
   public TextMeshProUGUI name;
   public Image icon;
   public TextMeshProUGUI countText;
   
}
