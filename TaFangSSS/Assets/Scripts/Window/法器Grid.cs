using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器Grid : MonoBehaviour
{
    [NonSerialized] public 法器 法器;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;

    public GameObject 头像;
    public Image 头像icon;

    public GameObject 已装备Obj;
    public void SetItem()
    {
        if (法器.HeroType != HeroType.None)
        {
            头像.SetActive(true);
            头像icon.sprite = ResourcesConfig.GetHeroSprite(法器.HeroType);
        }
        else
        {
            头像.SetActive(false);
        }
        已装备Obj.SetActive(法器.HeroType!=HeroType.None);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器.品质);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
        name.text = 法器Config.法器名Dic[法器.法器Type];
    }
}
