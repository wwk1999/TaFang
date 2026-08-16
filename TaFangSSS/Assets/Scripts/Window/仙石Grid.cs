using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙石Grid : MonoBehaviour
{
    [NonSerialized] public 仙石 仙石;
    public Image bg;
    public Image icon;
    public Image 艺术字;
    public TextMeshProUGUI name;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(仙石.quality);
        icon.sprite = ResourcesConfig.Get仙石Sprite(仙石.type,仙石.quality);
        艺术字.sprite = ResourcesConfig.Get艺术字(仙石.quality);
        name.text = 仙石Config.仙石名Dic[仙石.type];
    }
}
