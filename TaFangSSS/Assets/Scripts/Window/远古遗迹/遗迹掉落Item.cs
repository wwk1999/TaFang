using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 遗迹掉落Item : MonoBehaviour
{
    [NonSerialized]public PropType PropType=PropType.None;
    [NonSerialized]public 神物Type 神物Type;
    public Image bg;
    public Image image;

    public void SetItem()
    {
        if (PropType==PropType.None)
        {
            image.sprite = ResourcesConfig.Get神物Icon(神物Type);
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.宇品);
        }
        else
        {
            image.sprite = ResourcesConfig.GetPropSprite(PropType);
            bg.sprite = ResourcesConfig.Get道具背景框Sprite(PropType);
        }
    }
}
