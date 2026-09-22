using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 符文确认附魔弹窗 : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Button 返回Button;
    public Button 确认Button;
    public Button maskButton;
    private void OnEnable()
    {
        name.text = 符文Config.符文名Dic[HeroWindowController.S.当前符文附魔符文.type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(HeroWindowController.S.当前符文附魔符文.quality);
    }

    private void Start()
    {
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前符文附魔法器.符文 = HeroWindowController.S.当前符文附魔符文;
            switch (HeroWindowController.S.当前符文附魔法器.符文.quality)
            {
                case QualityType.地品:
                    PlayerData.S.符文灵文List.Remove(HeroWindowController.S.当前符文附魔法器.符文);
                    break;
                case QualityType.宇品:
                    PlayerData.S.符文仙文List.Remove(HeroWindowController.S.当前符文附魔法器.符文);
                    break;
                case QualityType.宙品:
                    PlayerData.S.符文帝文List.Remove(HeroWindowController.S.当前符文附魔法器.符文);
                    break;
                case QualityType.洪品:
                    PlayerData.S.符文圣文List.Remove(HeroWindowController.S.当前符文附魔法器.符文);
                    break;
                case QualityType.荒品:
                    PlayerData.S.符文道文List.Remove(HeroWindowController.S.当前符文附魔法器.符文);
                    break;
            }

            HeroWindowController.S.当前符文附魔符文 = null;
            ObserverModuleManager.S.SendEvent("刷新符文附魔Panel");
            ObserverModuleManager.S.SendEvent("SendUIToast","附魔成功");
            gameObject.SetActive(false);
        });
    }
}
