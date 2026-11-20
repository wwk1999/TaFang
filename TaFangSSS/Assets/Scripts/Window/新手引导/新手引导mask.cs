using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 新手引导mask : MonoBehaviour
{
    public Image 英雄引导mask;
    public Image 引导小手;
    public Image 英雄上阵小手;
    public GameObject 辅助mask;
    public 引导maskType 界面;
    public void 引导mask(object[] obj)
    {
        引导maskType 引导maskType = (引导maskType)obj[0];
        if (引导maskType != 界面) return;
        switch (引导maskType)
        {
            case 引导maskType.英雄按钮:
                英雄引导mask.gameObject.SetActive(true);
                辅助mask.gameObject.SetActive(true);
                引导小手.gameObject.SetActive(true);
                英雄上阵小手.gameObject.SetActive(false);
                break;
            case 引导maskType.英雄上阵:
                英雄引导mask.gameObject.SetActive(false);
                辅助mask.gameObject.SetActive(false);
                引导小手.gameObject.SetActive(false);
                英雄上阵小手.gameObject.SetActive(true);
                break;
        }
    }

    public void 清除引导小手(object[] obj)
    {
        英雄引导mask.gameObject.SetActive(false);
        辅助mask.gameObject.SetActive(false);
        引导小手.gameObject.SetActive(false);
        英雄上阵小手.gameObject.SetActive(false);
    }
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("清除引导小手",清除引导小手);
        ObserverModuleManager.S.RegisterEvent("引导mask",引导mask);
    }

    private void Start()
    {
        英雄引导mask.alphaHitTestMinimumThreshold = 0.1f;
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("清除引导小手",清除引导小手);
        ObserverModuleManager.S.UnRegisterEvent("引导mask",引导mask);
    }
}
