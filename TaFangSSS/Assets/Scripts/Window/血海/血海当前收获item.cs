using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 血海当前收获item : MonoBehaviour
{
    [NonSerialized] public 道纹 道纹=new 道纹();
    [NonSerialized] public int count;
    public Image bg;
    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Count;

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(道纹.quality);
        image.sprite = ResourcesConfig.Get道纹Sprite(道纹.道纹Type,道纹.quality);
        Name.text = 道纹config.道纹名Dic[道纹.道纹Type];
        Count.text = count.ToString();
    }
}
