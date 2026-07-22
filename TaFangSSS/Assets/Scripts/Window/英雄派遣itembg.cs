using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

public class 英雄派遣itembg : MonoBehaviour, IPointerClickHandler
{
    public 英雄派遣item 英雄派遣item;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (英雄派遣item.HeroType == HeroType.None)
            {
                return;
            }
            PlayerData.S.通天塔英雄派遣Dic[HeroWindowController.S.当前通天塔层数][英雄派遣item.index] = HeroType.None;
            PlayerData.S.HeroDataDic[英雄派遣item.HeroType].派遣=false;
            ObserverModuleManager.S.SendEvent("刷新通天塔窗口");
        }
    }
}
