using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 数值升级效果item : MonoBehaviour
{
    public TextMeshProUGUI infotext;
    public TextMeshProUGUI counttext;
    [NonSerialized] public string info;
    [NonSerialized] public string count;

    public void SetItem()
    {
        infotext.text=info;
        counttext.text=count;
    }
}
