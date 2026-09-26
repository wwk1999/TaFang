using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 道场 : MonoBehaviour
{
    public Button 矿场;
    public Button 玄铁洞;
    public Button 地脉;
    public Button 功德碑;
    public Button 领主府;
    public Button 坊市;
    public Button 聚贤阁;
    public Button 炼丹室;
    public Button 炼器室;
    public GameObject 领主符Window;

    private void Start()
    {
        领主府.onClick.AddListener(() =>
        {
            领主符Window.SetActive(true);
        });
    }
}
