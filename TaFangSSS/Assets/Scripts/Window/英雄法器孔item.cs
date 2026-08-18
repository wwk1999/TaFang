using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 英雄法器孔item : MonoBehaviour
{
    [NonSerialized] public 仙石 仙石;
    public Image bg;
    public Image icon;

    public void SetItem()
    {
        if (仙石.type == 仙石Type.None)
        {
            bg.sprite = ResourcesConfig.孔背景框;
            icon.gameObject.SetActive(false);
        }
        else
        {
            icon.gameObject.SetActive(true);
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(仙石.quality);
            icon.sprite = ResourcesConfig.Get仙石Sprite(仙石.type, 仙石.quality);
        }
    }
}
