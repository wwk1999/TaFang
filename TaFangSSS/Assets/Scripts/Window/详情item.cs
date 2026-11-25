using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 详情item : MonoBehaviour
{
    public TextMeshProUGUI info;
    [NonSerialized] public string text;

    public void SetItem()
    {
        info.text = text;
    }
}
