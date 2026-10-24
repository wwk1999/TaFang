using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 种植item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;
    [NonSerialized] public 灵植Type 灵植Tyep;
    [NonSerialized] public QualityType QualityType;

    public void SetItem()
    {
        
    }
}
