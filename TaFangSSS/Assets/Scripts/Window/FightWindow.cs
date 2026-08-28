using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightWindow : MonoBehaviour
{
    public GameObject 对话框;
    public TextMeshProUGUI 对话框Text;
    public Button 引导Button;
    public GameObject 引导mask;
    public Canvas canvas;
    public Button 设置Button;
    public Button exitButton;
    public Button 倍速Button1;
    public TextMeshProUGUI 倍速Text1;
    public Button 倍速Button2;
    public TextMeshProUGUI 倍速Text2;
    public Button 倍速Button3;
    public TextMeshProUGUI 倍速Text3;
    public Button 倍速Button4;
    public TextMeshProUGUI 倍速Text4;
    public Button 倍速Button5;
    public TextMeshProUGUI 倍速Text5;
    public Slider 关卡进度Slider;
    public TextMeshProUGUI 进度Text;
    public Animator 首领出现Animator;

    private int 引导Count = 0;
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
                倍速Button4.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text4.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button5.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text5.colorGradientPreset = ResourcesConfig.黄TMP;
                break;
            case 1.5f:
                倍速Button2.image.sprite = ResourcesConfig.倍速按钮亮;
                倍速Text2.colorGradientPreset = ResourcesConfig.纯黄TMP;
                倍速Button1.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text1.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button3.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text3.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button4.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text4.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button5.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text5.colorGradientPreset = ResourcesConfig.黄TMP;
                break;
            case 2:
                倍速Button3.image.sprite = ResourcesConfig.倍速按钮亮;
                倍速Text3.colorGradientPreset = ResourcesConfig.纯黄TMP;
                倍速Button2.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text2.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button1.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text1.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button4.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text4.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button5.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text5.colorGradientPreset = ResourcesConfig.黄TMP;
                break;
            
            case 2.5f:
                倍速Button4.image.sprite = ResourcesConfig.倍速按钮亮;
                倍速Text4.colorGradientPreset = ResourcesConfig.纯黄TMP;
                倍速Button2.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text2.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button1.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text1.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button3.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text3.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button5.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text5.colorGradientPreset = ResourcesConfig.黄TMP;
                break;
            
            case 3:
                倍速Button5.image.sprite = ResourcesConfig.倍速按钮亮;
                倍速Text5.colorGradientPreset = ResourcesConfig.纯黄TMP;
                倍速Button2.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text2.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button1.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text1.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button4.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text4.colorGradientPreset = ResourcesConfig.黄TMP;
                倍速Button3.image.sprite = ResourcesConfig.倍速按钮暗;
                倍速Text3.colorGradientPreset = ResourcesConfig.黄TMP;
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
        ObserverModuleManager.S.UnRegisterEvent("通关新手引导",通关新手引导);
        ObserverModuleManager.S.UnRegisterEvent("首领出现",首领出现);
        ObserverModuleManager.S.UnRegisterEvent("刷新关卡进度",刷新关卡进度);
    }

    public void 通关新手引导(object[] obj)
    {
        对话框.gameObject.SetActive(true);
        引导Button.gameObject.SetActive(true);
        引导mask.gameObject.SetActive(true);
    }
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("通关新手引导",通关新手引导);
        ObserverModuleManager.S.RegisterEvent("首领出现",首领出现);
        ObserverModuleManager.S.RegisterEvent("刷新关卡进度",刷新关卡进度);
        Set倍速Button();
        引导Button.onClick.AddListener(() =>
        {
            if (引导Count == 0)
            {
                引导Count++;
                对话框Text.text = "还有洞天秘境可以获得突破时需要的灵物，远古遗迹里可以获得效果强大的神物。";
            }else if (引导Count == 1)
            {
                引导Count++;
                对话框Text.text = "更多的功能会随着道友的境界提升而一步步解锁，后面就交给道友自己摸索啦，祝道友早日证道大罗！";
            }
            else if (引导Count == 2)
            {
                对话框.gameObject.SetActive(false);
                引导Button.gameObject.SetActive(false);
                引导mask.gameObject.SetActive(false);
            }
        });
        exitButton.onClick.AddListener(() =>
        {
            Time.timeScale = 0;
            退出确认弹窗.gameObject.SetActive(true);
        });
        设置Button.onClick.AddListener(() =>
        {
            GameObject obj=Instantiate(Resources.Load("Prefabs/Window/设置界面"),canvas.transform)as GameObject;
            obj.transform.SetAsLastSibling();
        });
        倍速Button1.onClick.AddListener(() =>
        {
            if (PlayerData.S.关卡倍速 == 1) return;
            PlayerData.S.关卡倍速 = 1;
            Set倍速Button();
            Time.timeScale = 1;
        });
        倍速Button2.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.元婴)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","元婴境界解锁");
                return;
            }
            if (PlayerData.S.关卡倍速 == 1.5f) return;
            PlayerData.S.关卡倍速 = 1.5f;
            Set倍速Button();
            Time.timeScale = 1.5f;
        });
        倍速Button3.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.天仙)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","天仙境界解锁");
                return;
            }
            if (PlayerData.S.关卡倍速 == 2) return;
            PlayerData.S.关卡倍速 = 2;
            Set倍速Button();
            Time.timeScale = 2;
        });
        
        倍速Button4.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.大罗金仙)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","大罗金仙境界解锁");
                return;
            }
            if (PlayerData.S.关卡倍速 == 2.5f) return;
            PlayerData.S.关卡倍速 = 2.5f;
            Set倍速Button();
            Time.timeScale = 2.5f;
        });
        
        倍速Button5.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < JingJieType.大道圣人)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","大道圣人境界解锁");
                return;
            }
            if (PlayerData.S.关卡倍速 == 3) return;
            PlayerData.S.关卡倍速 = 3;
            Set倍速Button();
            Time.timeScale = 3;
        });
    }
}
