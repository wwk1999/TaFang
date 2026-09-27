using System;
using System.Collections;
using System.Collections.Generic;
using Config;
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
   public TextMeshProUGUI 申请列表标题;
   public TextMeshProUGUI 申请列表buttontext;
   private bool 显示申请列表 = true;
   
   //建筑界面
   public GameObject 建筑panel;
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
      建筑按钮.onClick.AddListener(() =>
      {
         显示供奉 = false;
         HeroWindowController.S.当前显示建筑Type = 建筑Type.领主府;
         Show城主府();
      });
      升级按钮.onClick.AddListener(() =>
      {
         float 需要灵气 = 0;
         float 需要矿石 = 0;
         float 需要玄铁 = 0;
         float 需要玉髓 = 0;
         switch (HeroWindowController.S.当前显示建筑Type)
         {
            case 建筑Type.矿场:
               需要灵气 = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要灵气;
               需要矿石 = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要矿石;
               需要玄铁 = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要玄铁;
               需要玉髓 = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].升级需要玉髓;
               break;
            case 建筑Type.玄铁洞:
               需要灵气 = 道场Config.玄铁洞配置[PlayerData.S.建筑等级Dic[建筑Type.玄铁洞]].升级需要灵气;
               需要矿石 = 道场Config.玄铁洞配置[PlayerData.S.建筑等级Dic[建筑Type.玄铁洞]].升级需要矿石;
               需要玄铁 = 道场Config.玄铁洞配置[PlayerData.S.建筑等级Dic[建筑Type.玄铁洞]].升级需要玄铁;
               需要玉髓 = 道场Config.玄铁洞配置[PlayerData.S.建筑等级Dic[建筑Type.玄铁洞]].升级需要玉髓;
               break;
            case 建筑Type.地脉:
               需要灵气 = 道场Config.地脉配置[PlayerData.S.建筑等级Dic[建筑Type.地脉]].升级需要灵气;
               需要矿石 = 道场Config.地脉配置[PlayerData.S.建筑等级Dic[建筑Type.地脉]].升级需要矿石;
               需要玄铁 = 道场Config.地脉配置[PlayerData.S.建筑等级Dic[建筑Type.地脉]].升级需要玄铁;
               需要玉髓 = 道场Config.地脉配置[PlayerData.S.建筑等级Dic[建筑Type.地脉]].升级需要玉髓;
               break;
            case 建筑Type.功德碑:
               需要灵气 = 道场Config.功德碑配置[PlayerData.S.建筑等级Dic[建筑Type.功德碑]].升级需要灵气;
               需要矿石 = 道场Config.功德碑配置[PlayerData.S.建筑等级Dic[建筑Type.功德碑]].升级需要矿石;
               需要玄铁 = 道场Config.功德碑配置[PlayerData.S.建筑等级Dic[建筑Type.功德碑]].升级需要玄铁;
               需要玉髓 = 道场Config.功德碑配置[PlayerData.S.建筑等级Dic[建筑Type.功德碑]].升级需要玉髓;
               break;
            
            case 建筑Type.炼丹室:
               需要灵气 = 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].升级需要灵气;
               需要矿石 = 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].升级需要矿石;
               需要玄铁 = 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].升级需要玄铁;
               需要玉髓 = 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].升级需要玉髓;
               break;
            
            case 建筑Type.炼器室:
               需要灵气 = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].升级需要灵气;
               需要矿石 = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].升级需要矿石;
               需要玄铁 = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].升级需要玄铁;
               需要玉髓 = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].升级需要玉髓;
               break;
            
            case 建筑Type.聚贤阁:
               需要灵气 = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].升级需要灵气;
               需要矿石 = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].升级需要矿石;
               需要玄铁 = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].升级需要玄铁;
               需要玉髓 = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].升级需要玉髓;
               break;
            
            case 建筑Type.坊市:
               需要灵气 = 道场Config.坊市配置[PlayerData.S.建筑等级Dic[建筑Type.坊市]].升级需要灵气;
               需要矿石 = 道场Config.坊市配置[PlayerData.S.建筑等级Dic[建筑Type.坊市]].升级需要矿石;
               需要玄铁 = 道场Config.坊市配置[PlayerData.S.建筑等级Dic[建筑Type.坊市]].升级需要玄铁;
               需要玉髓 = 道场Config.坊市配置[PlayerData.S.建筑等级Dic[建筑Type.坊市]].升级需要玉髓;
               break;
            
            case 建筑Type.领主府:
               需要灵气 = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].升级需要灵气;
               需要矿石 = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].升级需要矿石;
               需要玄铁 = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].升级需要玄铁;
               需要玉髓 = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].升级需要玉髓;
               break;
         }

         if (PlayerData.S.PropListDic[PropType.灵魂] < 需要灵气)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","灵气不足");
            return;
         }
         if (PlayerData.S.PropListDic[PropType.矿石] < 需要矿石)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","矿石不足");
            return;
         }
         if (PlayerData.S.PropListDic[PropType.玄铁] < 需要玄铁)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","玄铁不足");
            return;
         }
         if (PlayerData.S.PropListDic[PropType.玉髓] < 需要玉髓)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","玉髓不足");
            return;
         }

         PlayerData.S.PropListDic[PropType.灵魂] -= 需要灵气;
         PlayerData.S.PropListDic[PropType.矿石] -= 需要矿石;
         PlayerData.S.PropListDic[PropType.玄铁]-= 需要玄铁;
         PlayerData.S.PropListDic[PropType.玉髓] -= 需要玉髓;
         PlayerData.S.建筑等级Dic[HeroWindowController.S.当前显示建筑Type]++;
         ObserverModuleManager.S.SendEvent("SendUIToast","升级建筑成功");
         ObserverModuleManager.S.SendEvent("刷新领主府");
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
         if (item.Value > 0)
         {
            var 建筑 = Instantiate(Resources.Load("Prefabs/Window/领主府/建筑item"), 建筑列表.transform).GetComponent<建筑item>();
            建筑.建筑Type=item.Key;
            建筑.亮 = item.Key == HeroWindowController.S.当前显示建筑Type;
            建筑.SetItem();
         }
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
            {
               var 配置 = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.玄铁洞:
            {
               var 配置 = 道场Config.玄铁洞配置[PlayerData.S.建筑等级Dic[建筑Type.玄铁洞]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.地脉:
            {
               var 配置 = 道场Config.地脉配置[PlayerData.S.建筑等级Dic[建筑Type.地脉]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.功德碑:
            {
               var 配置 = 道场Config.功德碑配置[PlayerData.S.建筑等级Dic[建筑Type.功德碑]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.聚贤阁:
            {
               var 配置 = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.炼丹室:
            {
               var 配置 = 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.炼器室:
            {
               var 配置 = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.领主府:
            {
               var 配置 = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
         case 建筑Type.坊市:
            {
               var 配置 = 道场Config.坊市配置[PlayerData.S.建筑等级Dic[建筑Type.坊市]];
               添加升级材料item(配置.升级需要灵气, 配置.升级需要矿石, 配置.升级需要玄铁, 配置.升级需要玉髓);
               break;
            }
      }
   }

   
   private void 添加升级材料item(float 灵气, float 矿石, float 玄铁, float 玉髓)
   {
      if (灵气 > 0) 创建升级材料item(升级材料Type.灵气, 灵气);
      if (矿石 > 0) 创建升级材料item(升级材料Type.矿石, 矿石);
      if (玄铁 > 0) 创建升级材料item(升级材料Type.玄铁, 玄铁);
      if (玉髓 > 0) 创建升级材料item(升级材料Type.玉髓, 玉髓);
   }

   private void 创建升级材料item(升级材料Type 升级材料Type, float count)
   {
      var item = Instantiate(Resources.Load("Prefabs/Window/领主府/升级材料item"), 升级材料content.transform)
         .GetComponent<升级材料item>();
      item.升级材料Type = 升级材料Type;
      item.count = count;
      item.SetItem();
   }
   public void Show建筑信息()
   {
      建筑名.text = 道场Config.Get道场建筑名(HeroWindowController.S.当前显示建筑Type);
      icon.sprite = ResourcesConfig.Get道场建筑Sprite(HeroWindowController.S.当前显示建筑Type);
      info.text = 道场Config.建筑info[HeroWindowController.S.当前显示建筑Type];
      Show升级材料();
      Show升级效果();
   }

   public void Show升级效果()
   {
      foreach (Transform item in 升级效果content.transform)
      {
         Destroy(item.gameObject);
      }
      foreach (Transform item in 当前效果content.transform)
      {
         Destroy(item.gameObject);
      }

      switch (HeroWindowController.S.当前显示建筑Type)
      {
         case 建筑Type.炼丹室:
            var 当前炼丹速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前炼丹速度.info = "炼丹速度加成";
            当前炼丹速度.count = 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].速度加成+"%";
            当前炼丹速度.SetItem();
            
            var 升级炼丹速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级炼丹速度.info = "炼丹速度加成";
            升级炼丹速度.count = 道场Config.炼丹室配置[1+PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].速度加成+"%";
            升级炼丹速度.SetItem();
            
            
            var 当前最高炼丹品质 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前最高炼丹品质.info = "最高炼丹品质";
            当前最高炼丹品质.count = 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].最高炼制QualityType.ToString();
            当前最高炼丹品质.SetItem();
            
            var 升级最高炼丹品质 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级最高炼丹品质.info = "最高炼丹品质";
            升级最高炼丹品质.count = 道场Config.炼丹室配置[1+PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].最高炼制QualityType.ToString();
            升级最高炼丹品质.SetItem();
            break;
         
         
         
         case 建筑Type.炼器室:
            var 当前炼器速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前炼器速度.info = "炼器速度加成";
            当前炼器速度.count = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].速度加成+"%";
            当前炼器速度.SetItem();
            
            var 升级炼器速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级炼器速度.info = "炼器速度加成";
            升级炼器速度.count = 道场Config.炼器室配置[1+PlayerData.S.建筑等级Dic[建筑Type.炼器室]].速度加成+"%";
            升级炼器速度.SetItem();
            
            
            var 当前最高炼器品质 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前最高炼器品质.info = "最高炼器品质";
            当前最高炼器品质.count = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].最高炼制QualityType.ToString();
            当前最高炼器品质.SetItem();
            
            var 升级最高炼器品质 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级最高炼器品质.info = "最高炼器品质";
            升级最高炼器品质.count = 道场Config.炼器室配置[1+PlayerData.S.建筑等级Dic[建筑Type.炼器室]].最高炼制QualityType.ToString();
            升级最高炼器品质.SetItem();
            break;
         
         case 建筑Type.聚贤阁:
            var 当前招募概率列表 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 当前效果content.transform)
               .GetComponent<概率升级效果item>();
            当前招募概率列表.list = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].普通招募概率;
            当前招募概率列表.SetItem();
            
            var 升级招募概率列表 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 升级效果content.transform)
               .GetComponent<概率升级效果item>();
            升级招募概率列表.list = 道场Config.聚贤阁配置[1+PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].普通招募概率;
            升级招募概率列表.SetItem();
            
            var 当前招募概率列表1 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 当前效果content.transform)
               .GetComponent<概率升级效果item>();
            当前招募概率列表1.list = 道场Config.聚贤阁配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].高级招募概率;
            当前招募概率列表1.SetItem();
            
            var 升级招募概率列表1 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 升级效果content.transform)
               .GetComponent<概率升级效果item>();
            升级招募概率列表1.list = 道场Config.聚贤阁配置[1+PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].高级招募概率;
            升级招募概率列表1.SetItem();
            break;
         
         case 建筑Type.坊市:
            var 当前坊市概率列表 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 当前效果content.transform)
               .GetComponent<概率升级效果item>();
            当前坊市概率列表.list = 道场Config.坊市配置[PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].概率;
            当前坊市概率列表.SetItem();
            
            var 升级坊市概率列表 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 升级效果content.transform)
               .GetComponent<概率升级效果item>();
            升级坊市概率列表.list = 道场Config.坊市配置[1+PlayerData.S.建筑等级Dic[建筑Type.聚贤阁]].概率;
            升级坊市概率列表.SetItem();
            break;
         
         
         case 建筑Type.矿场:
            var 当前矿石速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前矿石速度.info = "矿石开采速度";
            当前矿石速度.count = 道场Config.矿场配置[PlayerData.S.建筑等级Dic[建筑Type.矿场]].数值+"/道年";
            当前矿石速度.SetItem();
            
            var 升级矿石速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级矿石速度.info = "矿石开采速度";
            升级矿石速度.count = 道场Config.矿场配置[1+PlayerData.S.建筑等级Dic[建筑Type.矿场]].数值+"/道年";
            升级矿石速度.SetItem();
            break;
         
         case 建筑Type.玄铁洞:
            var 当前玄铁速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前玄铁速度.info = "玄铁开采速度";
            当前玄铁速度.count = 道场Config.玄铁洞配置[PlayerData.S.建筑等级Dic[建筑Type.玄铁洞]].数值+"/道年";
            当前玄铁速度.SetItem();
            
            var 升级玄铁速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级玄铁速度.info = "玄铁开采速度";
            升级玄铁速度.count = 道场Config.玄铁洞配置[1+PlayerData.S.建筑等级Dic[建筑Type.玄铁洞]].数值+"/道年";
            升级玄铁速度.SetItem();
            break;
         
         case 建筑Type.地脉:
            var 当前玉髓速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前玉髓速度.info = "玉髓开采速度";
            当前玉髓速度.count = 道场Config.地脉配置[PlayerData.S.建筑等级Dic[建筑Type.地脉]].数值+"/道年";
            当前玉髓速度.SetItem();
            
            var 升级玉髓速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级玉髓速度.info = "玉髓开采速度";
            升级玉髓速度.count = 道场Config.地脉配置[1+PlayerData.S.建筑等级Dic[建筑Type.地脉]].数值+"/道年";
            升级玉髓速度.SetItem();
            break;
         
         case 建筑Type.功德碑:
            var 当前功德速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前功德速度.info = "功德生成速度";
            当前功德速度.count = 道场Config.功德碑配置[PlayerData.S.建筑等级Dic[建筑Type.功德碑]].数值+"/道年";
            当前功德速度.SetItem();
            
            var 升级功德速度 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级功德速度.info = "功德生成速度";
            升级功德速度.count = 道场Config.功德碑配置[1+PlayerData.S.建筑等级Dic[建筑Type.功德碑]].数值+"/道年";
            升级功德速度.SetItem();
            break;
         case 建筑Type.领主府:
            var 当前供奉个数 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前供奉个数.info = "最大供奉个数";
            当前供奉个数.count = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉个数.ToString();
            当前供奉个数.SetItem();
            
            var 升级供奉个数 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级供奉个数.info = "最大供奉个数";
            升级供奉个数.count = 道场Config.领主府配置[1+PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉个数.ToString();
            升级供奉个数.SetItem();
            
            var 当前供奉申请个数 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前供奉申请个数 .info = "供奉申请个数";
            当前供奉申请个数 .count = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数.ToString();
            当前供奉申请个数 .SetItem();
            
            var 升级供奉申请个数  = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级供奉申请个数 .info = "供奉申请个数";
            升级供奉申请个数 .count = 道场Config.领主府配置[1+PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数.ToString();
            升级供奉申请个数 .SetItem();
            
            
            var 当前供奉保留个数 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前供奉保留个数 .info = "供奉保留个数";
            当前供奉保留个数 .count = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉保留个数.ToString();
            当前供奉保留个数 .SetItem();
            
            var 升级供奉保留个数  = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级供奉保留个数 .info = "供奉保留个数";
            升级供奉保留个数 .count = 道场Config.领主府配置[1+PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉保留个数.ToString();
            升级供奉保留个数 .SetItem();
         
            var 当前每道年供奉申请个数 = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 当前效果content.transform)
               .GetComponent<数值升级效果item>();
            当前每道年供奉申请个数 .info = "每道年供奉申请个数";
            当前每道年供奉申请个数 .count = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].每道年供奉申请个数.ToString();
            当前每道年供奉申请个数 .SetItem();
            
            var 升级每道年供奉申请个数  = Instantiate(Resources.Load("Prefabs/Window/领主府/数值升级效果item"), 升级效果content.transform)
               .GetComponent<数值升级效果item>();
            升级每道年供奉申请个数 .info = "每道年供奉申请个数";
            升级每道年供奉申请个数 .count = 道场Config.领主府配置[1+PlayerData.S.建筑等级Dic[建筑Type.领主府]].每道年供奉申请个数.ToString();
            升级每道年供奉申请个数 .SetItem();
            
            var 当前概率列表 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 当前效果content.transform)
               .GetComponent<概率升级效果item>();
            当前概率列表.list = 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].招募概率列表;
            当前概率列表.SetItem();
            
            var 升级概率列表 = Instantiate(Resources.Load("Prefabs/Window/领主府/概率升级效果item"), 升级效果content.transform)
               .GetComponent<概率升级效果item>();
            升级概率列表.list = 道场Config.领主府配置[1+PlayerData.S.建筑等级Dic[建筑Type.领主府]].招募概率列表;
            升级概率列表.SetItem();
            break;
      }
   }
}
