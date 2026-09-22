using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 熔炼Item : MonoBehaviour,IPointerClickHandler
{
    public Image bg;
    public Image icon;
    [NonSerialized] public 符文 符文;
    public int index;
    public void SetItem()
    {
        if (符文 == null)
        {
            icon.gameObject.SetActive(false);
        }
        else
        {      
            icon.gameObject.SetActive(true);  
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(符文.quality);
            icon.sprite=ResourcesConfig.Get符文Sprite(符文.type,符文Config.Quality对应符文品质[符文.quality]);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            switch (index)
            {
                case 1:
                    HeroWindowController.S.符文熔炼选择1 = null;
                    break;
                case 2:
                    HeroWindowController.S.符文熔炼选择2 = null;
                    break;
                case 3:
                    HeroWindowController.S.符文熔炼选择3 = null;
                    break;
                case 4:
                    HeroWindowController.S.符文熔炼选择4 = null;
                    break;
            }
            ObserverModuleManager.S.SendEvent("刷新符文熔炼Panel");
        }
    }
}
