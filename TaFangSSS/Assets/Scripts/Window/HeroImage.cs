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
            image.color=Color.gray;
            HeroWindowController.S.IsJiaoHuan = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HeroWindowController.S.IsJiaoHuan = false;
        image.color=Color.white;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            image.color=Color.white;
            if (HeroWindowController.S.IsJiaoHuan)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (heroItem.HeroType == PlayerData.S.出战英雄List[HeroWindowController.S.CurrentBianDui - 1][i])
                    {
                        HeroType hero1 = PlayerData.S.出战英雄List[HeroWindowController.S.CurrentBianDui - 1][i];
                        HeroType hero2 = HeroWindowController.S.DragHero;
                        List<HeroType>list = new List<HeroType>();
                        list.Add(hero1);
                        list.Add(hero2);
                        PlayerData.S.出战英雄List[HeroWindowController.S.CurrentBianDui - 1][i] =
                            HeroWindowController.S.DragHero;
                        ObserverModuleManager.S.SendEvent("交换英雄",list);
                    }
                }
            }
        }
    }
}
