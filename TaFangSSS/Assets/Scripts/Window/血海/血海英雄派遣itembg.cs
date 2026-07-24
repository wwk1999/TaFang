using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

public class 血海英雄派遣itembg : MonoBehaviour, IPointerClickHandler
{
    public 血海英雄派遣item 血海英雄派遣item;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (血海英雄派遣item.HeroType == HeroType.None)
            {
                return;
            }
            PlayerData.S.血海英雄派遣Dic[HeroWindowController.S.当前血海层数][血海英雄派遣item.index] = HeroType.None;
            PlayerData.S.HeroDataDic[血海英雄派遣item.HeroType].派遣=false;
            ObserverModuleManager.S.SendEvent("刷新血海窗口");
        }
    }
}
