using System;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 仙女灵植item : MonoBehaviour
{
    public Image bg;
    public Image icon;

    [NonSerialized] public 灵植Type 灵植Type;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get灵植背包格子(灵植园Config.灵植品质Dic[灵植Type]);
        icon.sprite = ResourcesConfig.Get灵植收获Sprite(灵植Type);
    }
}
