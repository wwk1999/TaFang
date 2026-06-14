using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroWindow : MonoBehaviour
{
   public Button ExitButton;
   public GameObject HeroPanelContent;
   public Button JiBanButton;
   public Button ShouJiButton;
   public TextMeshProUGUI 暴击伤害Text;
   public GameObject HeroListContent;
   [NonSerialized]public Dictionary<HeroType,KaPaiItem> HeroList = new Dictionary<HeroType, KaPaiItem>();
   [NonSerialized] public int BianDui = 0;
   public void SetHeroListOrder()
   {
      foreach (var item in HeroList)
      {
         item.Value.gameObject.transform.SetAsLastSibling();
      }

      foreach (var item in PlayerData.S.出战英雄List[BianDui])
      {
         HeroList[item].gameObject.transform.SetAsFirstSibling();
      }
   }
   public void ShowHeroList()
   {
      foreach (Transform item in HeroListContent.transform)
      {
         Destroy(item.gameObject);
      }

      HeroList.Clear();
      foreach (var item in HeroConfig.HeroNameDic)
      {
         var kapaiItem = Instantiate(Resources.Load("Prefabs/Window/KaPaiItem"), HeroListContent.transform)
            .GetComponent<KaPaiItem>();
         kapaiItem.heroType = item.Key;
         kapaiItem.SetItem();
         HeroList.Add(kapaiItem.heroType, kapaiItem);
      }

      SetHeroListOrder();
   }

   private void OnEnable()
   {
      ShowHeroList();
   }
}
