using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 修为item : MonoBehaviour
{
    [NonSerialized] public float 修为;
    public TextMeshProUGUI text;

    public void SetItem()
    {
        text.text = "修为+" + 修为;
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
