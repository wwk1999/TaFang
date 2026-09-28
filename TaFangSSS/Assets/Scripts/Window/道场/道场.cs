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
    public Button 灵兽坊;
    public Button 双修殿;
    private void Start()
    {
        矿场.image.alphaHitTestMinimumThreshold = 0.1f;
        玄铁洞.image.alphaHitTestMinimumThreshold = 0.1f;
        地脉.image.alphaHitTestMinimumThreshold = 0.1f;
        领主府.image.alphaHitTestMinimumThreshold = 0.1f;
        聚贤阁.image.alphaHitTestMinimumThreshold = 0.1f;
        坊市.image.alphaHitTestMinimumThreshold = 0.1f;
        炼丹室.image.alphaHitTestMinimumThreshold = 0.1f;
        炼器室.image.alphaHitTestMinimumThreshold = 0.1f;
        双修殿.image.alphaHitTestMinimumThreshold = 0.1f;
        灵兽坊.image.alphaHitTestMinimumThreshold = 0.1f;
        功德碑.image.alphaHitTestMinimumThreshold = 0.1f;

        领主府.onClick.AddListener(() =>
        {
            WindowController.S.领主府Window.gameObject.SetActive(true);
        });
    }
}
