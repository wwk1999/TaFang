using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 世界树当前收获item : MonoBehaviour
{
    [NonSerialized] public 道宝Type 道宝Type;
    [NonSerialized] public int count;
    public Image bg;
    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Count;

    public void SetItem()
    {
        QualityType qualityType = 道宝Config.道宝QualityToQuality[道宝Config.道宝品质Dic[道宝Type]];
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(qualityType);
        image.sprite = ResourcesConfig.Get道宝Sprite(道宝Type);
        Name.text = 道宝Config.道宝NameDic[道宝Type];
        Count.text = count.ToString();
    }
}
