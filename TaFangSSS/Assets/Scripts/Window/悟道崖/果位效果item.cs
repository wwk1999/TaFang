using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 果位效果item : MonoBehaviour
{
    public TextMeshProUGUI text;
    [NonSerialized] public 大道效果item 大道效果item;

    public void SetItem()
    {
        text.text = 悟道崖Config.Get果位效果(大道效果item);
    }
}
