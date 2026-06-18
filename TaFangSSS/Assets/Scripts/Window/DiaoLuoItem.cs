using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class DiaoLuoItem : MonoBehaviour
{
    [NonSerialized]public PropType propType;
    public Image bg;
    public Image image;

    public void SetItem()
    {
        image.sprite=ResourcesConfig.GetPropSprite(propType);
        bg.sprite = ResourcesConfig.Get道具背景框Sprite(propType);
    }
}
