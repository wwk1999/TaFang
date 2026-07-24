using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 不周山当前收获item : MonoBehaviour
{
    [NonSerialized] public PropType 法则Type;
    [NonSerialized] public int count;
    public Image bg;
    public Image image;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Count;

    public void SetItem()
    {
        QualityType qualityType = 法则config.法则Quality[法则Type];
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(qualityType);
        image.sprite = ResourcesConfig.Get法则Sprite(法则config.法则英雄Dic[法则Type]);
        Name.text = 法则config.法则名Dic[法则config.法则英雄Dic[法则Type]];
        Count.text = count.ToString();
    }
}
