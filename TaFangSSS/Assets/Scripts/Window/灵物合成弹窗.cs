using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 灵物合成弹窗 : MonoBehaviour
{
    public Toggle 玄Toggle;
    public Toggle 地Toggle;
    public Toggle 天Toggle;
    public Toggle 宇Toggle;
    public Toggle 宙Toggle;
    public Toggle 洪Toggle;
    private bool 玄=false;
    private bool 地=false;
    private bool 天=false;
    private bool 宇=false;
    private bool 宙=false;
    private bool 洪=false;
    public Button maskButton;
    public Button 合成Button;

    public void SetToggle显示()
    {
        玄Toggle.isOn = 玄;
        地Toggle.isOn = 地;
        天Toggle.isOn = 天;
        宇Toggle.isOn = 宇;
        宙Toggle.isOn = 宙;
        洪Toggle.isOn = 洪;
    }

    private void OnEnable()
    {
        SetToggle显示();
    }

    private void Start()
    {
        合成Button.onClick.AddListener(() =>
        {
            foreach (var item in JingJieConfig.JingJieNameDic)
            {
                foreach (var quality in PropConfig.QualityNameDic)
                {
                    int count = 0;
                    switch (quality.Key)
                    {
                        case QualityType.黄品:
                            if (玄)
                            {
                                count=PlayerData.S.Get灵物数量(item.Key,quality.Key)/10;
                            }
                            PlayerData.S.Set灵物数量(item.Key,quality.Key,PlayerData.S.Get灵物数量(item.Key,quality.Key)-10*count);
                            PlayerData.S.Set灵物数量(item.Key,quality.Key+1,PlayerData.S.Get灵物数量(item.Key,quality.Key+1)+count);
                            break;
                        case QualityType.玄品:
                            if (地)
                            {
                                count=PlayerData.S.Get灵物数量(item.Key,quality.Key)/10;
                            }
                            PlayerData.S.Set灵物数量(item.Key,quality.Key,PlayerData.S.Get灵物数量(item.Key,quality.Key)-10*count);
                            PlayerData.S.Set灵物数量(item.Key,quality.Key+1,PlayerData.S.Get灵物数量(item.Key,quality.Key+1)+count);
                            break;
                        case QualityType.地品:
                            if (天)
                            {
                                count=PlayerData.S.Get灵物数量(item.Key,quality.Key)/10;
                            }
                            PlayerData.S.Set灵物数量(item.Key,quality.Key,PlayerData.S.Get灵物数量(item.Key,quality.Key)-10*count);
                            PlayerData.S.Set灵物数量(item.Key,quality.Key+1,PlayerData.S.Get灵物数量(item.Key,quality.Key+1)+count);
                            break;
                        case QualityType.天品:
                            if (宇)
                            {
                                count=PlayerData.S.Get灵物数量(item.Key,quality.Key)/10;
                            }
                            PlayerData.S.Set灵物数量(item.Key,quality.Key,PlayerData.S.Get灵物数量(item.Key,quality.Key)-10*count);
                            PlayerData.S.Set灵物数量(item.Key,quality.Key+1,PlayerData.S.Get灵物数量(item.Key,quality.Key+1)+count);
                            break;
                        case QualityType.宇品:
                            if (宙)
                            {
                                count=PlayerData.S.Get灵物数量(item.Key,quality.Key)/10;
                            }
                            PlayerData.S.Set灵物数量(item.Key,quality.Key,PlayerData.S.Get灵物数量(item.Key,quality.Key)-10*count);
                            PlayerData.S.Set灵物数量(item.Key,quality.Key+1,PlayerData.S.Get灵物数量(item.Key,quality.Key+1)+count);
                            break;
                        case QualityType.宙品:
                            if (洪)
                            {
                                count=PlayerData.S.Get灵物数量(item.Key,quality.Key)/10;
                            }
                            PlayerData.S.Set灵物数量(item.Key,quality.Key,PlayerData.S.Get灵物数量(item.Key,quality.Key)-10*count);
                            PlayerData.S.Set灵物数量(item.Key,quality.Key+1,PlayerData.S.Get灵物数量(item.Key,quality.Key+1)+count);
                            break;
                    }
                }
            }
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        玄Toggle.onValueChanged.AddListener(delegate
        {
            玄=玄Toggle.isOn;
        });
        地Toggle.onValueChanged.AddListener(delegate
        {
            地=地Toggle.isOn;
        });
        天Toggle.onValueChanged.AddListener(delegate
        {
            天=天Toggle.isOn;
        });
        宇Toggle.onValueChanged.AddListener(delegate
        {
            宇=宇Toggle.isOn;
        });
        宙Toggle.onValueChanged.AddListener(delegate
        {
            宙=宙Toggle.isOn;
        });
        洪Toggle.onValueChanged.AddListener(delegate
        {
            洪=洪Toggle.isOn;
        });
    }
}
