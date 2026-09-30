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
    public GameObject 坊市窗口;
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
            if (PlayerData.S.建筑等级Dic[建筑Type.领主府] == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","筑基境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.领主府Window);
        });
        聚贤阁.onClick.AddListener(() =>
        {
            if (PlayerData.S.建筑等级Dic[建筑Type.聚贤阁] == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","筑基境界解锁");
                return;
            }
            WindowController.S.招募Window.gameObject.SetActive(true);
        });
        坊市.onClick.AddListener(() =>
        {
            if (PlayerData.S.建筑等级Dic[建筑Type.坊市] == 0)
            {
                if (PlayerData.S.历史最高境界 >= JingJieType.金丹)
                {
                    if (PlayerData.S.建筑等级Dic[建筑Type.坊市] == 0)
                    {
                        PlayerData.S.建筑等级Dic[建筑Type.坊市] = 1;
                    }
                    坊市窗口.gameObject.SetActive(true);
                }
                else
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","金丹境界解锁");
                    return;
                }
            }
            坊市窗口.gameObject.SetActive(true);        
        });
        炼丹室.onClick.AddListener(() =>
        {
            if (PlayerData.S.建筑等级Dic[建筑Type.炼丹室] == 0)
            {
                if (PlayerData.S.历史最高境界 >= JingJieType.元婴)
                {
                    if (PlayerData.S.建筑等级Dic[建筑Type.炼丹室] == 0)
                    {
                        PlayerData.S.建筑等级Dic[建筑Type.炼丹室] = 1;
                    }

                    WindowController.S.炼丹Window.gameObject.SetActive(true);
                }
                else
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast", "元婴境界解锁");
                    return;
                }
            }

        });
        炼器室.onClick.AddListener(() =>
        {
            if (PlayerData.S.建筑等级Dic[建筑Type.炼器室] == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","通关花果山解锁");
                return;
            }
            WindowController.S.炼器Window.gameObject.SetActive(true);
        });
        
    }
}
