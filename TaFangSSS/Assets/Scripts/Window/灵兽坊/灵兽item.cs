using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵兽item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public Image 性别;
    public Image 元素;

    [NonSerialized] public 灵兽 灵兽;

    public void SetItem()
    {
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

        元素.sprite = ResourcesConfig.Get元素Sprite(灵兽.元素Type);
    }
    
}
