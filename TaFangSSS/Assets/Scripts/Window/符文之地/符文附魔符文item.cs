using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文附魔符文item : MonoBehaviour
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
            HeroWindowController.S.当前符文附魔符文 = 符文;
            ObserverModuleManager.S.SendEvent("刷新符文附魔Panel");
        });
    }
    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
        icon.sprite = ResourcesConfig.Get符文Sprite(符文.type,符文Config.Quality对应符文品质[符文.quality]);
        name.text = 符文Config.符文名Dic[符文.type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(符文.quality);
        gou.SetActive(false);
    }
}
