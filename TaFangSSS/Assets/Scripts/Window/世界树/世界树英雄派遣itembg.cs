using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

public class 世界树英雄派遣itembg : MonoBehaviour, IPointerClickHandler
{
    public 世界树英雄派遣item 世界树英雄派遣item;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (世界树英雄派遣item.HeroType == HeroType.None)
            {
                return;
            }
            PlayerData.S.世界树英雄派遣Dic[HeroWindowController.S.当前世界树层数][世界树英雄派遣item.index] = HeroType.None;
            PlayerData.S.HeroDataDic[世界树英雄派遣item.HeroType].派遣=false;
            ObserverModuleManager.S.SendEvent("刷新世界树窗口");
        }
    }
}
