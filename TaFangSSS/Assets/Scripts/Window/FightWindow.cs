using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightWindow : MonoBehaviour
{
    public Button exitButton;
    public Button 倍速Button1;
    public TextMeshProUGUI 倍速Text1;
    public Button 倍速Button2;
    public TextMeshProUGUI 倍速Text2;
    public Button 倍速Button3;
    public TextMeshProUGUI 倍速Text3;

    public Slider 关卡进度Slider;
    public TextMeshProUGUI 进度Text;
    public Animator 首领出现Animator;

    public void 首领出现(object[] obj)
    {
        首领出现Animator.gameObject.SetActive(true);
        首领出现Animator.Play("首领出现",0,0);
    }
    public void Set倍速Button()
    {
        switch (PlayerData.S.关卡倍速)
        {
            case 1:
                倍速Button1.image.sprite = ResourcesConfig.倍速按钮亮;
                倍速Text1.colorGradientPreset = ResourcesConfig.纯黄TMP;
                倍速Button2.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text2.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button3.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text3.colorGradientPreset = ResourcesConfig.黄TMP;
                break;
            case 1.5f:
                倍速Button2.image.sprite = ResourcesConfig.倍速按钮亮;
                倍速Text2.colorGradientPreset = ResourcesConfig.纯黄TMP;
                倍速Button1.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text1.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button3.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text3.colorGradientPreset = ResourcesConfig.黄TMP;
                break;
            case 2:
                倍速Button3.image.sprite = ResourcesConfig.倍速按钮亮;
                倍速Text3.colorGradientPreset = ResourcesConfig.纯黄TMP;
                倍速Button2.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text2.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button1.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text1.colorGradientPreset = ResourcesConfig.黄TMP;
                break;
        }
    }

    public GameObject 退出确认弹窗;

    public void 刷新关卡进度(object[] obj)
    {
        float count = (float)obj[0];
        关卡进度Slider.value = count;
        进度Text.text = (int)(count * 100f) + "%";
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("首领出现",首领出现);
        ObserverModuleManager.S.UnRegisterEvent("刷新关卡进度",刷新关卡进度);
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("首领出现",首领出现);
        ObserverModuleManager.S.RegisterEvent("刷新关卡进度",刷新关卡进度);
        Set倍速Button();
        exitButton.onClick.AddListener(() =>
        {
            Time.timeScale = 0;
            退出确认弹窗.gameObject.SetActive(true);
        });
        倍速Button1.onClick.AddListener(() =>
        {
            if (PlayerData.S.关卡倍速 == 1) return;
            ObserverModuleManager.S.SendEvent("倍速更改",PlayerData.S.关卡倍速,1);
            PlayerData.S.关卡倍速 = 1;
            Set倍速Button();
            Time.timeScale = 1;
        });
        倍速Button2.onClick.AddListener(() =>
        {
            if (PlayerData.S.JingJieType < JingJieType.元婴)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","元婴境界解锁");
                return;
            }
            if (PlayerData.S.关卡倍速 == 1.5f) return;
            ObserverModuleManager.S.SendEvent("倍速更改",PlayerData.S.关卡倍速,1.5f);
            PlayerData.S.关卡倍速 = 1.5f;
            Set倍速Button();
            Time.timeScale = 1.5f;
        });
        倍速Button3.onClick.AddListener(() =>
        {
            if (PlayerData.S.JingJieType < JingJieType.天仙)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","天仙境界解锁");
                return;
            }
            if (PlayerData.S.关卡倍速 == 2) return;
            ObserverModuleManager.S.SendEvent("倍速更改",PlayerData.S.关卡倍速,2);
            PlayerData.S.关卡倍速 = 2;
            Set倍速Button();
            Time.timeScale = 2;
        });
    }
}
