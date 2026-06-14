using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class HeroWindow : MonoBehaviour
{
   public Button ExitButton;
   public GameObject HeroPanelContent;
   public Button JiBanButton;
   public Button ShouJiButton;
   public TextMeshProUGUI 暴击伤害Text;
   public GameObject HeroListContent;
   [NonSerialized]public Dictionary<HeroType,KaPaiItem> HeroList = new Dictionary<HeroType, KaPaiItem>();
   public Image 鼠标Image;
   public RectTransform canvasRectTransform;
   public ScrollRect  ScrollView;

   public void 交换英雄(object[] obj)
   {
      ResetHeroPanel();
      List<HeroType> list = new List<HeroType>();
      list=(List<HeroType>)obj[0];
      foreach (var item in list)
      {
         HeroList[item].SetItem();
      }
      SetHeroListOrder();
   }
   public void ResetHeroPanel()
   {
      foreach (Transform item in HeroPanelContent.transform)
      {
         Destroy(item.gameObject);
      }

      int count = 0;
      foreach (var item in PlayerData.S.出战英雄List[HeroWindowController.S.CurrentBianDui-1])
      {
         count++;
         var HeroItem=Instantiate(Resources.Load("Prefabs/Window/HeroItem"),HeroPanelContent.transform).GetComponent<HeroItem>();
         if (item == HeroType.None)
         {
            HeroItem.IsSuo = true;
         }
         else
         {
            HeroItem.HeroType = item;
         }
         HeroItem.Index=count;
         HeroItem.SetItem();
      }
   }
   private void Start()
   {
      var s = HeroWindowController.S;
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      ObserverModuleManager.S.RegisterEvent("交换英雄",交换英雄);
   }

   private void Update()
   {
      if (HeroWindowController.S.IsDrag)
      {
         ScrollView.vertical=false;
         Vector2 localPoint;
         bool isInside = RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform, 
            Input.mousePosition, 
            null,
            out localPoint
         );
         鼠标Image.gameObject.SetActive(true);
         鼠标Image.sprite = ResourcesConfig.GetHeroSprite(HeroWindowController.S.DragHero);
         鼠标Image.rectTransform.localPosition = localPoint;
      }
      else
      {
         ScrollView.vertical=true;
         鼠标Image.gameObject.SetActive(false);
      }
   }

   public void SetHeroListOrder()
   {
      foreach (var item in HeroList)
      {
         item.Value.gameObject.transform.SetAsLastSibling();
      }

      foreach (var item in PlayerData.S.出战英雄List[HeroWindowController.S.CurrentBianDui-1])
      {
         if (item != HeroType.None)
         {
             HeroList[item].gameObject.transform.SetAsFirstSibling();
         }
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
      ResetHeroPanel();
   }
}
