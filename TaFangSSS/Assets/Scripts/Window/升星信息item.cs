using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 升星信息item : MonoBehaviour
{
    public GameObject xx2;
    public GameObject xx3;
    public GameObject xx4;
    public GameObject xx5;
    public TextMeshProUGUI info;
    public GameObject suo;
    [NonSerialized] public int 星级;
    [NonSerialized] public string text;
    [NonSerialized] public bool 锁;

    public void SetItem()
    {
        info.text = text;
        suo.SetActive(锁);
        switch (星级)
        {
            case 1:
                xx2.gameObject.SetActive(false);
                xx3.gameObject.SetActive(false);
                xx4.gameObject.SetActive(false);
                xx5.gameObject.SetActive(false);
                break;
            case 2:
                xx3.gameObject.SetActive(false);
                xx4.gameObject.SetActive(false);
                xx5.gameObject.SetActive(false);
                break;
            case 3:
                xx4.gameObject.SetActive(false);
                xx5.gameObject.SetActive(false);
                break;
            case 4:
                xx5.gameObject.SetActive(false);
                break;
        }
    }
}
