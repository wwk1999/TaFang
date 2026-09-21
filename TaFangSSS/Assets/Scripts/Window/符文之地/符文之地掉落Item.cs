using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 符文之地掉落Item : MonoBehaviour
{
    [NonSerialized]public PropType PropType;
    [NonSerialized]public QualityType QualityType;
    public Image bg;
    public Image image;
    public void SetItem()
    {
        if (PropType == PropType.None)
        {
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        }
        else
        {
            bg.sprite = ResourcesConfig.Get道具背景框Sprite(PropType);
            image.sprite=ResourcesConfig.GetPropSprite(PropType);
        }
    }
}
