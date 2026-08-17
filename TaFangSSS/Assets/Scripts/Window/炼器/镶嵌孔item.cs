using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 镶嵌孔item : MonoBehaviour,IDropHandler
{
    [NonSerialized] public 仙石 仙石;
    [NonSerialized] public int index = 0;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;

    public void OnDrop(PointerEventData eventData)
    {
        if (HeroWindowController.S.仙石 != null)
        {
            ObserverModuleManager.S.SendEvent("显示仙石镶嵌确认弹窗",HeroWindowController.S.仙石,index,HeroWindowController.S.仙石镶嵌panel当前法器);
        }
    }
    public void SetItem()
    {
        if (仙石.type == 仙石Type.None)
        {
            bg.sprite = ResourcesConfig.孔背景框;
            icon.gameObject.SetActive(false);
            name.gameObject.SetActive(false);
        }
        else
        {
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(仙石.quality);
            icon.gameObject.SetActive(true);
            name.gameObject.SetActive(true);
            icon.sprite=ResourcesConfig.Get仙石Sprite(仙石.type,仙石.quality);
            name.text=仙石Config.仙石名Dic[仙石.type];
        }
    }
}
