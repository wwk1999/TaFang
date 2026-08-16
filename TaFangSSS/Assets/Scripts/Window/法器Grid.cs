using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器Grid : MonoBehaviour
{
    [NonSerialized] public 法器 法器;
    public Image bg;
    public Image icon;
    public Image 艺术字;
    public TextMeshProUGUI name;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器.法器Type]);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
        艺术字.sprite = ResourcesConfig.Get艺术字(法器Config.法器品质Dic[法器.法器Type]);
        name.text = 法器Config.法器名Dic[法器.法器Type];
    }
}
