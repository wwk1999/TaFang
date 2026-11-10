using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 丹方品质item : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public Button bg;
    public Image mask;
    public TextMeshProUGUI name;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public int 阶数;

   public void SetItem()
   {
       name.text = 丹药Config.Get阶数string(阶数)+丹药Config.丹药名Dic[丹药Type];
       mask.gameObject.SetActive(false);
    }

   private void Start()
   {
       bg.onClick.AddListener(() =>
       {
           
       });
   }

   public void OnPointerEnter(PointerEventData eventData)
    {
        mask.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mask.gameObject.SetActive(false);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        HeroWindowController.S.当前炼丹显示Type = 丹药Type;
        HeroWindowController.S.当前炼丹显示阶数= 阶数;
        ObserverModuleManager.S.SendEvent("刷新炼丹界面");
    }
}
