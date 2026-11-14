using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaoLuoItem : MonoBehaviour
{
    [NonSerialized]public PropType propType;
    [NonSerialized] public float count;
    public Image bg;
    public Image image;
    public TextMeshProUGUI name;

    public void SetItem()
    {
        name.text=PropConfig.PropNameDic[propType];
        image.sprite=ResourcesConfig.GetPropSprite(propType);
        bg.sprite = ResourcesConfig.Get道具背景框Sprite(propType);
    }
}
