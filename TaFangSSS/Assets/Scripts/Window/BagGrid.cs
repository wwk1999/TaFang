using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BagGrid : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI count;
    public Image bg;
    [NonSerialized]public PropType propType;

    public void SetItem()
    {
        image.sprite = ResourcesConfig.GetPropSprite(propType);
        bg.sprite = ResourcesConfig.Get道具背景框Sprite(propType);
        count.text = PlayerData.S.PropListDic[propType].ToString();
    }
}
