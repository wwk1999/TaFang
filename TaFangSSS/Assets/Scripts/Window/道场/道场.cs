using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 道场 : MonoBehaviour
{
    public Button 领主府;
    public Button 坊市;
    public Button 聚贤阁;
    public Button 炼丹室;
    public Button 炼器室;
    public Button 灵兽坊;
    public Button 灵植园;
    public Button 双修殿;
    public Button 赌坊;
    public Button 悟道崖;
    public Button 灵矿场;
    public GameObject 建筑解锁obj;
    public TextMeshProUGUI 建筑解锁;

    public GameObject 坊市窗口;

    public void 刷新建筑解锁(object[] obj)
    {
        if (道场Config.建筑解锁String.ContainsKey(PlayerData.S.历史最高境界))
        {
            建筑解锁obj.gameObject.SetActive(true);
            建筑解锁.text = 道场Config.建筑解锁String[PlayerData.S.历史最高境界];
        }
        else
        {
            建筑解锁obj.gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新建筑解锁",刷新建筑解锁);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新建筑解锁",刷新建筑解锁);
        if (道场Config.建筑解锁String.ContainsKey(PlayerData.S.历史最高境界))
        {
            建筑解锁obj.gameObject.SetActive(true);
            建筑解锁.text = 道场Config.建筑解锁String[PlayerData.S.历史最高境界];
        }
        else
        {
            建筑解锁obj.gameObject.SetActive(false);
        }
        领主府.image.alphaHitTestMinimumThreshold = 0.1f;
        聚贤阁.image.alphaHitTestMinimumThreshold = 0.1f;
        坊市.image.alphaHitTestMinimumThreshold = 0.1f;
        炼丹室.image.alphaHitTestMinimumThreshold = 0.1f;
        炼器室.image.alphaHitTestMinimumThreshold = 0.1f;
        双修殿.image.alphaHitTestMinimumThreshold = 0.1f;
        灵兽坊.image.alphaHitTestMinimumThreshold = 0.1f;
        灵植园.image.alphaHitTestMinimumThreshold = 0.1f;
        赌坊.image.alphaHitTestMinimumThreshold = 0.1f;
        悟道崖.image.alphaHitTestMinimumThreshold = 0.1f;
        灵矿场.image.alphaHitTestMinimumThreshold = 0.1f;
        领主府.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.筑基)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","筑基境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.领主府Window);
        });
        
        灵兽坊.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.合体)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","合体境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.灵兽坊Window);
        });
        
        灵植园.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.元婴)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","元婴境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.灵植园Window);
        });
        
        双修殿.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.天仙)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","天仙境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.仙女阁Window);
        });
        
        赌坊.onClick.AddListener(() =>
        {
                if (PlayerData.S.历史最高境界 >= JingJieType.大乘)
                {
                    WindowController.S.打开窗口(WindowController.S.赌坊Window);
                }
                else
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","大乘境界解锁");
                    return;
                }
        });
        悟道崖.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.玄仙)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","玄仙境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.悟道崖Window);
        });
        
        灵矿场.onClick.AddListener(() =>
        {
            WindowController.S.打开窗口(WindowController.S.灵矿场Window);
        });
        聚贤阁.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.筑基)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","筑基境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.招募Window);
        });
        坊市.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.金丹)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","金丹境界解锁");
                return;
            }
            WindowController.S.打开窗口(坊市窗口);
        });
        炼丹室.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.化神)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","化神境界解锁");
                return;
            }
            WindowController.S.打开窗口(WindowController.S.炼丹Window);
        });
        炼器室.onClick.AddListener(() =>
        {
            WindowController.S.炼器Window.gameObject.SetActive(true);
        });
        
    }
}
