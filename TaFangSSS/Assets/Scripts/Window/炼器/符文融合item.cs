using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文融合item : MonoBehaviour
{
    [NonSerialized] public 符文 符文 = null;
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public GameObject gou;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
        icon.sprite = ResourcesConfig.Get符文Sprite(符文.type, 符文.quality);
        name.text = 符文Config.符文名Dic[符文.type];
        bool 已选 = HeroWindowController.S.符文融合主符文 == 符文 || HeroWindowController.S.符文融合副符文 == 符文;
        gou.SetActive(已选);
    }

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("符文融合点击", 符文);
        });
    }
}
