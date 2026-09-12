using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 英雄详情功法item : MonoBehaviour
{
    public Button bg;
    public Image image;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    [NonSerialized] public 功法Type 功法Type;
    [NonSerialized] public HeroType HeroType;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前选择功法 = 功法Type;
            ObserverModuleManager.S.SendEvent("显示装备功法弹窗",HeroType);
        });
    }

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        image.sprite = ResourcesConfig.Get功法Sprite(功法Type);
        name.text = 功法Config.功法名Dic[功法Type];
        count.text=PlayerData.S.功法数量Dic[功法Type].ToString();
    }
}
