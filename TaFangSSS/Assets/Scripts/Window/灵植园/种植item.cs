using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 种植item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;
    [NonSerialized] public 灵植Type 灵植Tyep;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get作物品质背景框(灵植园Config.灵植品质Dic[灵植Tyep]);
        icon.sprite = ResourcesConfig.Get灵植种子Sprite(灵植Tyep);
        name.text = 灵植园Config.灵植名[灵植Tyep];
        count.text = PlayerData.S.种子Dic[灵植Tyep].ToString();
    }
}
