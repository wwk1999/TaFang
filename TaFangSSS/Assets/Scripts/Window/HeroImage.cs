using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroImage : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image image;
    public HeroItem heroItem;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (HeroWindowController.S.IsDrag)
        {
            if (heroItem.HeroType != HeroType.None)
            {
                image.color=Color.gray;
            }
            HeroWindowController.S.IsJiaoHuan = true;
            HeroWindowController.S.交换HeroItem=heroItem;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HeroWindowController.S.IsJiaoHuan = false;
        if (heroItem.HeroType != HeroType.None)
        {
            image.color=Color.white;
            StartCoroutine(Delay交换HeroItem());
        }
    }

    IEnumerator Delay交换HeroItem()
    {
        yield return null;
        HeroWindowController.S.交换HeroItem=null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (heroItem.HeroType != HeroType.None)
            {
                image.color=Color.white;
            }
            if (HeroWindowController.S.IsJiaoHuan)
            {
                List<HeroType>list = new List<HeroType>();
                list.Add(PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1][HeroWindowController.S.交换HeroItem.Index-1]);
                list.Add(HeroWindowController.S.DragHero);
                for (int i = 0; i < 5; i++)
                {
                    if (PlayerData.S.出战英雄List[PlayerData.S.当前出战编队 - 1][i] == HeroWindowController.S.DragHero)
                    {
                        PlayerData.S.出战英雄List[PlayerData.S.当前出战编队 - 1][i] = HeroType.None;
                    }
                }
                PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1][HeroWindowController.S.交换HeroItem.Index-1]=
                    HeroWindowController.S.DragHero;
                ObserverModuleManager.S.SendEvent("交换英雄",list);
            }
        }
    }
}
