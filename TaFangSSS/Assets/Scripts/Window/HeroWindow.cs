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
   public GameObject 对话框;
   public TextMeshProUGUI 对话框Text;
   public Button 引导Button;
   public GameObject 引导小手;
   public Transform 拖动trans;
   public 功法选择弹窗 功法选择弹窗;
   public 功法确认装备弹窗 功法确认装备弹窗;
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
   public 英雄详情弹窗 英雄详情弹窗;

   private int 引导count = 0;
   public void 交换英雄(object[] obj)
   {
      ResetHeroPanel();
      List<HeroType> list = new List<HeroType>();
      list=(List<HeroType>)obj[0];
      foreach (var item in list)
      {
         if (item != HeroType.None)
         {
             HeroList[item].SetItem();
         }
      }

      if (PlayerData.S.是否首次进入英雄界面)
      {
         引导count++;
         对话框Text.text = "已经出战成功啦,下面让我们进行第一场战斗吧！";
         引导小手.gameObject.SetActive(false);
         引导Button.gameObject.SetActive(true);
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
      foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
      {
         count++;
         var HeroItem=Instantiate(Resources.Load("Prefabs/Window/HeroItem"),HeroPanelContent.transform).GetComponent<HeroItem>();
         if (PlayerData.S.历史最高境界<(JingJieType)count)
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

   public void 英雄详情弹窗Show(object[] obj)
   {
      HeroType heroType = (HeroType)obj[0];
      英雄详情弹窗.HeroType=heroType;
      英雄详情弹窗.gameObject.SetActive(true);
   }

   public void 升星刷新(object[] obj)
   {
      HeroType heroType = (HeroType)obj[0];
      HeroList[heroType].SetItem();
      暴击伤害Text.text = 属性config.Get英雄暴击伤害增幅() + "%";
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新英雄卡片功法",升星刷新);
      ObserverModuleManager.S.UnRegisterEvent("显示功法选择弹窗",显示功法选择弹窗);
      ObserverModuleManager.S.UnRegisterEvent("显示英雄功法确认弹窗",显示英雄功法确认弹窗);
      ObserverModuleManager.S.UnRegisterEvent("法则升级", 法则升级);
      ObserverModuleManager.S.UnRegisterEvent("升星刷新", 升星刷新);
      ObserverModuleManager.S.UnRegisterEvent("英雄详情弹窗",英雄详情弹窗Show);
   }

   public void 法则升级(object[] obj)
   {
      暴击伤害Text.text = 属性config.Get英雄暴击伤害增幅() + "%";
   }

   public void 显示英雄功法确认弹窗(object[] obj)
   {
      功法确认装备弹窗.heroType = (HeroType)obj[0];
      功法确认装备弹窗.gameObject.SetActive(true);
   }

   public void 显示功法选择弹窗(object[] obj)
   {
      功法选择弹窗.HeroType = (HeroType)obj[0];
      功法选择弹窗.gameObject.SetActive(true);
   }
   
   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新英雄卡片功法",升星刷新);
      ObserverModuleManager.S.RegisterEvent("显示功法选择弹窗",显示功法选择弹窗);
      ObserverModuleManager.S.RegisterEvent("显示英雄功法确认弹窗",显示英雄功法确认弹窗);
      ObserverModuleManager.S.RegisterEvent("法则升级", 法则升级);
      ObserverModuleManager.S.RegisterEvent("升星刷新", 升星刷新);
      ObserverModuleManager.S.RegisterEvent("英雄详情弹窗",英雄详情弹窗Show);
      var s = HeroWindowController.S;
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      引导Button.onClick.AddListener(() =>
      {
         if (引导count == 0)
         {
             对话框.transform.localPosition = 拖动trans.localPosition;
             对话框Text.text = "先长按一段时间,然后拖动英雄到备战栏上就出战成功了。";
             引导小手.gameObject.SetActive(true);
             引导Button.gameObject.SetActive(false);
         }else if (引导count == 1)
         {
            对话框.gameObject.SetActive(false);
            gameObject.SetActive(false);
            PlayerData.S.是否首次进入英雄界面 = false;
            ObserverModuleManager.S.SendEvent("关卡新手引导");
         }
        
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

      foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
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
      ExitButton.gameObject.SetActive(true);
      if (PlayerData.S.是否首次进入英雄界面)
      {
         ExitButton.gameObject.SetActive(false);
         对话框.gameObject.SetActive(true);
         引导Button.gameObject.SetActive(true);
      }
      暴击伤害Text.text = 属性config.Get英雄暴击伤害增幅() + "%";
      ShowHeroList();
      ResetHeroPanel();
   }
}
