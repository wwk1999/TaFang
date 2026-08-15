using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 洞天掉落Item : MonoBehaviour
{
    [NonSerialized]public PropType PropType=PropType.None;
    [NonSerialized]public QualityType QualityType;
    public Image bg;
    public Image image;

    public void SetItem()
    {
        if (PropType==PropType.None)
        {
            image.sprite = ResourcesConfig.Get突破灵物(PlayerData.S.JingJieType, QualityType);
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        }
        else
        {
            image.sprite = ResourcesConfig.GetPropSprite(PropType);
            bg.sprite = ResourcesConfig.Get道具背景框Sprite(PropType);
        }
    }
}
