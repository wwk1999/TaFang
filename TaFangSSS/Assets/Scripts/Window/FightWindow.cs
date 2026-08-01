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

    private void Awake()
    {
        exitButton.onClick.AddListener(() =>
        {
            Time.timeScale = 0;
            退出确认弹窗.gameObject.SetActive(true);
        });
        倍速Button1.onClick.AddListener(() =>
        {
            PlayerData.S.关卡倍速 = 1;
            Set倍速Button();
            Time.timeScale = 1;
        });
        倍速Button2.onClick.AddListener(() =>
        {
            PlayerData.S.关卡倍速 = 1.5f;
            Set倍速Button();
            Time.timeScale = 1.5f;
        });
        倍速Button3.onClick.AddListener(() =>
        {
            PlayerData.S.关卡倍速 = 2;
            Set倍速Button();
            Time.timeScale = 2;
        });
    }
}
