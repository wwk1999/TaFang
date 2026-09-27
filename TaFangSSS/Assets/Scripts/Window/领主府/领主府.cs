using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 领主府 : MonoBehaviour
{
   public Button 退出按钮;
   private bool 显示供奉 = true;
   public Button 供奉按钮;
   public Button 建筑按钮;
   
   //供奉界面
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
   public TextMeshProUGUI 申请列表标题;
   public TextMeshProUGUI 申请列表buttontext;
   private bool 显示申请列表 = true;
   
   //建筑界面
   public GameObject 建筑Panel;
   public TextMeshProUGUI 矿石速度;
   public TextMeshProUGUI 玄铁速度;
   public TextMeshProUGUI 玉髓速度;
   public TextMeshProUGUI 功德速度;
   public GameObject 建筑列表;
   public TextMeshProUGUI 建筑名;
   public Image icon;
   public TextMeshProUGUI info;
   public GameObject 升级材料content;
   public GameObject 当前效果content;
   public GameObject 升级效果content;
   public Button 升级按钮;

   private void OnEnable()
   {
      Show城主府();
      Canvas.ForceUpdateCanvases();
   }

   public void 刷新城主府(object[] obj)
   {
      Show城主府();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新领主府",刷新城主府);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新",刷新城主府);

      ObserverModuleManager.S.RegisterEvent("刷新领主府",刷新城主府);
      退出按钮.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      自动拒绝凡品.onClick.AddListener(() =>
      {
         PlayerData.S.自动拒绝凡品供奉 = !PlayerData.S.自动拒绝凡品供奉;
         Show供奉信息();
      });
      自动拒绝灵品.onClick.AddListener(() =>
      {
         PlayerData.S.自动拒绝灵品供奉 = !PlayerData.S.自动拒绝灵品供奉;
         Show供奉信息();
      });
      自动拒绝仙品.onClick.AddListener(() =>
      {
         PlayerData.S.自动拒绝仙品供奉 = !PlayerData.S.自动拒绝仙品供奉;
         Show供奉信息();
      });
      自动拒绝圣品.onClick.AddListener(() =>
      {
         PlayerData.S.自动拒绝圣品供奉 = !PlayerData.S.自动拒绝圣品供奉;
         Show供奉信息();
      });
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
         Set切换Button();
         Show建筑面板();
         供奉panel.SetActive(false);
         建筑panel.SetActive(true);
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
         申请列表标题.text = "供奉申请列表";
         申请列表buttontext.text = "申请列表";
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
         申请列表标题.text = "供奉保留列表";
         申请列表buttontext.text = "保留列表";
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


   public void Show道场信息()
   {
      矿石速度.text = 道场Config.Get矿石速度().ToString("F0");
      玄铁速度.text = 道场Config.Get玄铁速度().ToString("F0");
      玉髓速度.text = 道场Config.Get玉髓速度().ToString("F0");
      功德速度.text = 道场Config.Get功德速度().ToString("F0");
   }

   public void Show建筑面板()
   {
      Show道场信息();
      Show建筑列表();
      Show建筑信息();
   }
   public void Show建筑列表()
   {
      foreach (Transform item in 建筑列表.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in PlayerData.S.建筑等级Dic)
      {
         var 建筑 = Instantiate(Resources.Load("Prefabs/Window/领主府/建筑item"), 建筑列表.transform).GetComponent<建筑item>();
         建筑.建筑Type=item.Key;
         建筑.亮 = item.Key == HeroWindowController.S.当前显示建筑Type;
         建筑.SetItem();
      }
   }

   public void Show升级材料()
   {
      foreach (Transform item in 升级材料content.transform)
      {
         Destroy(item.gameObject);
      }

      switch (HeroWindowController.S.当前显示建筑Type)
      {
         case 建筑Type.矿场:
            if (道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要灵气 > 0)
            {
               var 灵气 = Instantiate(Resources.Load("Prefabs/Window/领主府/升级材料item"), 升级材料content.transform)
                  .GetComponent<升级材料item>();
               灵气.升级材料Type = 升级材料Type.灵气;
               灵气.count = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要灵气;
               灵气.SetItem();
            }
            if (道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要矿石 > 0)
            {
               var 矿石 = Instantiate(Resources.Load("Prefabs/Window/领主府/升级材料item"), 升级材料content.transform)
                  .GetComponent<升级材料item>();
               矿石.升级材料Type = 升级材料Type.矿石;
               矿石.count = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要矿石;
               矿石.SetItem();
            }
            
            if (道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要玄铁 > 0)
            {
               var 玄铁 = Instantiate(Resources.Load("Prefabs/Window/领主府/升级材料item"), 升级材料content.transform)
                  .GetComponent<升级材料item>();
               玄铁.升级材料Type = 升级材料Type.玄铁;
               玄铁.count = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要玄铁;
               玄铁.SetItem();
            }
            
            if (道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要玉髓 > 0)
            {
               var 玉髓 = Instantiate(Resources.Load("Prefabs/Window/领主府/升级材料item"), 升级材料content.transform)
                  .GetComponent<升级材料item>();
               玉髓.升级材料Type = 升级材料Type.玉髓;
               玉髓.count = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要玉髓;
               玉髓.SetItem();
            }
            break;
      }
   }
   public void Show建筑信息()
   {
      建筑名.text = 道场Config.Get道场建筑名(HeroWindowController.S.当前显示建筑Type);
      icon.sprite = ResourcesConfig.Get道场建筑Sprite(HeroWindowController.S.当前显示建筑Type);
      info.text = 道场Config.建筑info[HeroWindowController.S.当前显示建筑Type];
      
   }
}
