using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 胜利弹窗item : MonoBehaviour
{
    public Image bg;
    public Image image;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI Name;
    [NonSerialized] public PropType Type;
    [NonSerialized] public long count;


    public void SetItem()
    {
        Name.text = PropConfig.PropNameDic[Type];
        CountText.text=count.ToString();
        image.sprite=ResourcesConfig.GetPropSprite(Type);
        bg.sprite=ResourcesConfig.Get道具背景框Sprite(Type);
    }
}
