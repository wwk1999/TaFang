using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

public class 不周山英雄派遣itembg : MonoBehaviour, IPointerClickHandler
{
    public 不周山英雄派遣item 不周山英雄派遣item;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (不周山英雄派遣item.HeroType == HeroType.None)
            {
                return;
            }
            PlayerData.S.不周山英雄派遣Dic[HeroWindowController.S.当前不周山层数][不周山英雄派遣item.index] = HeroType.None;
            PlayerData.S.HeroDataDic[不周山英雄派遣item.HeroType].派遣=false;
            ObserverModuleManager.S.SendEvent("刷新不周山窗口");
        }
    }
}
