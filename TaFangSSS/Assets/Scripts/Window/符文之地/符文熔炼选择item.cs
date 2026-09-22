using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文熔炼选择item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public GameObject gou;
    [NonSerialized] public 符文 符文;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            if (符文 == HeroWindowController.S.符文熔炼选择1 || 符文 == HeroWindowController.S.符文熔炼选择2 ||
                符文 == HeroWindowController.S.符文熔炼选择3 || 符文 == HeroWindowController.S.符文熔炼选择4)
            {
                return;
            }
            if (HeroWindowController.S.符文熔炼选择1 == null)
            {
                HeroWindowController.S.符文熔炼选择1 = 符文;
                HeroWindowController.S.熔炼后符文 = null;
                ObserverModuleManager.S.SendEvent("刷新符文熔炼Panel");
                return;
            }
            if (HeroWindowController.S.符文熔炼选择2 == null)
            {
                HeroWindowController.S.符文熔炼选择2 = 符文;
                HeroWindowController.S.熔炼后符文 = null;

                ObserverModuleManager.S.SendEvent("刷新符文熔炼Panel");
                return;
            }
            if (HeroWindowController.S.符文熔炼选择3 == null)
            {
                HeroWindowController.S.符文熔炼选择3 = 符文;
                HeroWindowController.S.熔炼后符文 = null;

                ObserverModuleManager.S.SendEvent("刷新符文熔炼Panel");
                return;
            }
            if (HeroWindowController.S.符文熔炼选择4 == null)
            {
                HeroWindowController.S.符文熔炼选择4 = 符文;
                HeroWindowController.S.熔炼后符文 = null;

                ObserverModuleManager.S.SendEvent("刷新符文熔炼Panel");
                return;
            }
            ObserverModuleManager.S.SendEvent("熔炼符文已满");
        });
    }

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
        icon.sprite=ResourcesConfig.Get符文Sprite(符文.type,符文Config.Quality对应符文品质[符文.quality]);
        name.text = 符文Config.符文名Dic[符文.type];
        gou.SetActive(符文==HeroWindowController.S.符文熔炼选择1||符文==HeroWindowController.S.符文熔炼选择2||符文==HeroWindowController.S.符文熔炼选择3||符文==HeroWindowController.S.符文熔炼选择4);
    }
}
