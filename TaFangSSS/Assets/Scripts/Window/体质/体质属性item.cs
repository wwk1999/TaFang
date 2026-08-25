using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 体质属性item : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI countText;
    [NonSerialized] public string name;
    [NonSerialized] public float count;

    public void SetItem()
    {
        nameText.text = name;
        countText.text = count+"%";
    }
}
