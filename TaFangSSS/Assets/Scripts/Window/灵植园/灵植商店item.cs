using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵植商店item : MonoBehaviour
{
    public Button bg;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;
    public Image icon;
    [NonSerialized] public 灵植Type 灵植Type;
    [NonSerialized] public 肥料Type 肥料Type;
    [NonSerialized] public QualityType quality;

    public void SetItem()
    {
        if (灵植Type != 灵植Type.None)
        {
            bg.image.sprite = ResourcesConfig.Get作物品质背景框(灵植园Config.灵植品质Dic[灵植Type]);
            name.text = 灵植园Config.灵植名[灵植Type];
            count.text = 灵植园Config.灵植价格Dic[灵植Type].ToString();
            icon.sprite = ResourcesConfig.Get灵植种子Sprite(灵植Type);
        }
        else
        {
            bg.image.sprite = ResourcesConfig.Get作物品质背景框(quality);
            name.text = 灵植园Config.肥料名[肥料Type];
            count.text = 灵植园Config.Get肥料价格(肥料Type,quality).ToString();
            icon.sprite = ResourcesConfig.Get肥料Icon(肥料Type,quality);
        }
    }
}
