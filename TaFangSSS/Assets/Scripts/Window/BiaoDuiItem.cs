using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BiaoDuiItem : MonoBehaviour
{
   public int 编号;
   public TextMeshProUGUI 编号Text;
   public GameObject InputObj;
   public TMP_InputField input;
   public Button bg;
   [NonSerialized]public bool IsZhanKai=false;


   public void HideInput(object[] obj)
   {
      InputObj.SetActive(false);
   }
   private void Start()
   {
      input.onValueChanged.AddListener(delegate
      {
         PlayerData.S.编队名List[编号-1]=input.text;
      });
      ObserverModuleManager.S.RegisterEvent("HideInput",HideInput);
      bg.onClick.AddListener(() =>
      {
         ObserverModuleManager.S.SendEvent("HideInput");
         InputObj.SetActive(true);
         input.text = PlayerData.S.编队名List[编号-1];
         int index = HeroWindowController.S.CurrentBianDui;
         HeroWindowController.S.CurrentBianDui = 编号;
         List<HeroType>list = new List<HeroType>();
         foreach (var item in PlayerData.S.出战英雄List[index-1])
         {
            if (item != HeroType.None)
            {
               list.Add(item);
            }
         }
         foreach (var item in PlayerData.S.出战英雄List[编号-1])
         {
            if (item != HeroType.None)
            {
               list.Add(item);
            }
         }
         ObserverModuleManager.S.SendEvent("交换英雄",list);
      });
   }

   private void OnEnable()
   {
      编号Text.text = 编号.ToString();
      InputObj.SetActive(false);
   }
}
