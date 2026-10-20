using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 孵化灵兽item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public Image 性别;
    public GameObject 头像;
    public Image 头像Image;
    [NonSerialized] public 灵兽 灵兽;

   
    

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前选择孵化池 == null)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择孵化池");
                return;
            }
            else
            {
                if (HeroWindowController.S.当前选择孵化池.孵化中)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","当前孵化池正在孵化");
                    return;
                }
                else
                {
                    if (!灵兽.是否在孵化)
                    {
                        if ((int)灵兽.血脉Type > (int)灵兽.阶段Type)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast",
                                $"{灵兽坊Config.血脉Name[灵兽.血脉Type]}血脉需要{灵兽坊Config.阶段Name[(阶段Type)灵兽.血脉Type]}阶段才可孵化");
                            return;
                        }
                        else
                        {
                            if (灵兽.性别 == global::性别.公)
                            {
                                HeroWindowController.S.当前选择孵化池.父 = 灵兽;
                            }
                            else
                            {
                                HeroWindowController.S.当前选择孵化池.母 = 灵兽;
                            }

                            ObserverModuleManager.S.SendEvent("孵化灵兽点击");
                        }
                    }
                    else
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToast", "当前灵兽正在孵化中");
                        return;
                    }
                }
            }
        });
    }

    public void SetItem()
    {
        头像.SetActive(灵兽.HeroType!=HeroType.None);
        头像Image.sprite = ResourcesConfig.GetHeroSprite(灵兽.HeroType);
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(灵兽.QualityType);
        icon.sprite = ResourcesConfig.Get灵兽Sprite(灵兽.灵兽Type);
        name.text = 灵兽坊Config.灵兽名[灵兽.灵兽Type];
        if (灵兽.性别 == global::性别.母)
        {
            性别.sprite = ResourcesConfig.母;
        }
        else
        {
            性别.sprite = ResourcesConfig.公;
        }
    }
}
