using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 领主府 : MonoBehaviour
{
   public Button 供奉按钮;
   public Button 建筑按钮;
   public TextMeshProUGUI 当前供奉个数;
   public TextMeshProUGUI 当前最大供奉个数;
   public TextMeshProUGUI 当前供奉申请个数;
   public TextMeshProUGUI 当前最大供奉申请个数;
   public TextMeshProUGUI 当前供奉保留个数;
   public TextMeshProUGUI 当前最大供奉保留个数;
   public Button 自动拒绝凡品;
   public Button 自动拒绝灵品;
   public Button 自动拒绝仙品;
   public Button 自动拒绝圣品;
   public GameObject 当前供奉Content;
   public GameObject 供奉申请Content;
   public Button 申请列表Button;
   public GameObject 供奉panel;
   public GameObject 建筑panel;

   private bool 显示供奉 = true;
   private bool 显示申请列表 = true;

   public void 刷新城主府(object[] obj)
   {
      Show城主府();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新城主府",刷新城主府);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新城主府",刷新城主府);
      供奉按钮.onClick.AddListener(() =>
      {
         显示供奉 = true;
         Show城主府();
      });
      申请列表Button.onClick.AddListener(() =>
      {
         显示申请列表 = !显示申请列表;
         Show申请或保留列表();
      });
   }

   public void Set切换Button()
   {
      if (显示供奉)
      {
         供奉按钮.image.sprite = ResourcesConfig.红按钮;
         建筑按钮.image.sprite = ResourcesConfig.黑按钮;
      }
      else
      {
         供奉按钮.image.sprite = ResourcesConfig.黑按钮;
         建筑按钮.image.sprite = ResourcesConfig.红按钮;
      }
   }
   public void Show供奉信息()
   {
      当前供奉个数.text = PlayerData.S.当前供奉列表.Count.ToString();
      当前最大供奉个数.text = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉个数.ToString();
      当前供奉申请个数.text = PlayerData.S.供奉申请列表.Count.ToString();
      当前最大供奉申请个数.text = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数.ToString();
      当前供奉保留个数.text = PlayerData.S.供奉保留列表.Count.ToString();
      当前最大供奉保留个数.text = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉保留个数.ToString();
      if (PlayerData.S.自动拒绝凡品供奉)
      {
         自动拒绝凡品.image.sprite = ResourcesConfig.toggle亮;
      }
      else
      {
         自动拒绝凡品.image.sprite = ResourcesConfig.toggle暗;
      }
      
      if (PlayerData.S.自动拒绝灵品供奉)
      {
         自动拒绝灵品.image.sprite = ResourcesConfig.toggle亮;
      }
      else
      {
         自动拒绝灵品.image.sprite = ResourcesConfig.toggle暗;
      }
      
      if (PlayerData.S.自动拒绝仙品供奉)
      {
         自动拒绝仙品.image.sprite = ResourcesConfig.toggle亮;
      }
      else
      {
         自动拒绝仙品.image.sprite = ResourcesConfig.toggle暗;
      }
      
      if (PlayerData.S.自动拒绝圣品供奉)
      {
         自动拒绝圣品.image.sprite = ResourcesConfig.toggle亮;
      }
      else
      {
         自动拒绝圣品.image.sprite = ResourcesConfig.toggle暗;
      }
   }

   public void Show当前供奉列表()
   {
      foreach (Transform item in 当前供奉Content.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in PlayerData.S.当前供奉列表)
      {
         var 当前供奉 = Instantiate(Resources.Load("Prefabs/Window/领主府/当前供奉item"),当前供奉Content.transform).GetComponent<当前供奉item>();
         当前供奉.供奉 = item;
         当前供奉.SetItem();
      }
   }

   public void Show城主府()
   {
      if (显示供奉)
      {
         Set切换Button();
         Show供奉面板();
         供奉panel.SetActive(true);
         建筑panel.SetActive(false);
      }
      else
      {
         
      }
   }
   public void Show申请或保留列表()
   {
      foreach (Transform item in 供奉申请Content.transform)
      {
         Destroy(item.gameObject);
      }
      if (显示申请列表)
      {
         申请列表Button.image.sprite = ResourcesConfig.toggle亮;
         foreach (var item in PlayerData.S.供奉申请列表)
         {
            var 供奉 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉申请item"),供奉申请Content.transform).GetComponent<供奉申请item>();
            供奉.供奉 = item;
            供奉.SetItem();
         }
      }
      else
      {
         申请列表Button.image.sprite = ResourcesConfig.toggle暗;
         foreach (var item in PlayerData.S.供奉保留列表)
         {
            var 供奉 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉保留item"),供奉申请Content.transform).GetComponent<供奉保留item>();
            供奉.供奉 = item;
            供奉.SetItem();
         }
      }
   }

   public void Show供奉面板()
   {
      Show供奉信息();
      Show当前供奉列表();
      Show申请或保留列表();
   }
}
