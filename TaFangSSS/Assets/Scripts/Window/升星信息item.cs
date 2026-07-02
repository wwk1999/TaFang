using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 升星信息item : MonoBehaviour
{
    public GameObject xx1;
    public GameObject xx2;
    public GameObject xx3;
    public GameObject xx4;
    public GameObject xx5;
    public TextMeshProUGUI 星级info;
    public GameObject suo;
    [NonSerialized] public int 星级;
    [NonSerialized] public string text;
    [NonSerialized] public bool 锁;
    [NonSerialized] public bool Is法则=false;
    public TextMeshProUGUI 法则等级;
    public TextMeshProUGUI 法则text;

    

    public void SetItem()
    {
        suo.SetActive(锁);
        if (Is法则 == false)
        {
            星级info.text = text;
            星级info.gameObject.SetActive(true);
            法则text.gameObject.SetActive(false);
            法则等级.gameObject.SetActive(false);
            switch (星级)
            {
                case 1:
                    xx1.gameObject.SetActive(true);
                    xx2.gameObject.SetActive(false);
                    xx3.gameObject.SetActive(false);
                    xx4.gameObject.SetActive(false);
                    xx5.gameObject.SetActive(false);
                    break;
                case 2:
                    xx1.gameObject.SetActive(true);
                    xx2.gameObject.SetActive(true);
                    xx3.gameObject.SetActive(false);
                    xx4.gameObject.SetActive(false);
                    xx5.gameObject.SetActive(false);
                    break;
                case 3:
                    xx1.gameObject.SetActive(true);
                    xx2.gameObject.SetActive(true);
                    xx3.gameObject.SetActive(true);
                    xx4.gameObject.SetActive(false);
                    xx5.gameObject.SetActive(false);
                    break;
                case 4:
                    xx1.gameObject.SetActive(true);
                    xx2.gameObject.SetActive(true);
                    xx3.gameObject.SetActive(true);
                    xx4.gameObject.SetActive(true);
                    xx5.gameObject.SetActive(false);
                    break;
                case 5:
                    xx1.gameObject.SetActive(true);
                    xx2.gameObject.SetActive(true);
                    xx3.gameObject.SetActive(true);
                    xx4.gameObject.SetActive(true);
                    xx5.gameObject.SetActive(true);
                    break;
            }
        }
        else
        {
            法则text.text = text;
            星级info.gameObject.SetActive(false);
            法则text.gameObject.SetActive(true);
            xx1.gameObject.SetActive(false);
            xx2.gameObject.SetActive(false);
            xx3.gameObject.SetActive(false);
            xx4.gameObject.SetActive(false);
            xx5.gameObject.SetActive(false);
            法则等级.gameObject.SetActive(true);
            switch (星级)
            {
                case 1:
                    法则等级.text = "LV：5";
                    break;
                case 2:
                    法则等级.text = "LV：10";
                    break;
                case 3:
                    法则等级.text = "LV：15";
                    break;
                case 4:
                    法则等级.text = "LV：20";
                    break;
                case 5:
                    法则等级.text = "LV：25";
                    break;
            }
        }
    }
}
