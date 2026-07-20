using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

public class 城墙装备bg : MonoBehaviour, IDropHandler
{
    public 城墙装备item 城墙装备item;
    public void OnDrop(PointerEventData eventData)
    {
        if (HeroWindowController.S.城墙IsDrag)
        {
            for (int i=1;i<=8;i++)
            {
                if (PlayerData.S.当前装备城墙道具Dic[(QualityType)i] == HeroWindowController.S.城墙道具Type)
                {
                    PlayerData.S.当前装备城墙道具Dic[(QualityType)i] = 城墙道具Type.None;
                }
            }
            PlayerData.S.当前装备城墙道具Dic[城墙装备item.城墙装备QualityType] = HeroWindowController.S.城墙道具Type;
            ObserverModuleManager.S.SendEvent("刷新城墙界面");
        }
    }
}
