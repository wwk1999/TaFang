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
            bg.image.sprite = ResourcesConfig.Get灵植背包格子(灵植园Config.灵植品质Dic[灵植Type]);
            name.text = 灵植园Config.灵植名[灵植Type];
            count.text = 灵植园Config.灵植价格Dic[灵植Type].ToString();
            icon.sprite = ResourcesConfig.Get灵植种子Sprite(灵植Type);
            icon.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
        else
        {
            bg.image.sprite = ResourcesConfig.Get灵植背包格子(quality);
            name.text = 灵植园Config.肥料名[肥料Type];
            count.text = 灵植园Config.Get肥料价格(肥料Type,quality).ToString();
            icon.sprite = ResourcesConfig.Get肥料Icon(肥料Type,quality);
            icon.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
