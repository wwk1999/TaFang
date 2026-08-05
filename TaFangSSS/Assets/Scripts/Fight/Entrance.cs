using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Entrance : MonoBehaviour
{
   public GameObject 人物Parent;
   public Animator 围栏Animator;
   public Slider 血条Slider;
   public TextMeshProUGUI 当前血量;
   public TextMeshProUGUI 最大血量;
   public RectTransform 护盾;

   public void Set血条()
   {
       当前血量.text=FightController.S.城墙当前生命值.ToString(); 
       最大血量.text= 城墙Config.Get城墙最大生命值().ToString();
       血条Slider.maxValue = 城墙Config.Get城墙最大生命值();
       血条Slider.value = FightController.S.城墙当前生命值;
       护盾.offsetMin = new Vector2(FightController.S.Get护盾Left(),护盾.offsetMin.y);
       护盾.offsetMax = new Vector2(-FightController.S.Get护盾Right(),护盾.offsetMax.y);
   }
   public void 围栏受击(object[] obj)
   {
       if (FightController.S.城墙无敌Time > 0)
       {
           return;
       }

       if (FightController.S.免疫护盾次数 > 0)
       {
           FightController.S.免疫护盾次数--;
           return;
       }
      if (围栏Animator == null)
      {
         围栏Animator =GameObject.Find("围栏").GetComponent<Animator>();
      }
      float damage = (float)obj[0];
      damage -=城墙Config.Get城墙防御();
      属性config.领主总属性 属性 = new 属性config.领主总属性();
      float 城墙血量比例 = FightController.S.城墙当前生命值 / 城墙Config.Get城墙最大生命值();
      if (城墙血量比例 < 城墙Config.Get低血量伤害减免血量值()/ 100f)
      {
          damage *= (1f - 城墙Config.低血量伤害减免值 / 100f);
      }
      if (城墙血量比例 > 城墙Config.Get高血量伤害减免血量值()/ 100f)
      {
          damage *= (1f - 城墙Config.高血量伤害减免值 / 100f);
      }
      damage *= (1f - 属性.伤害减免);
      damage=Math.Max(damage,0);
      float y=(float)obj[1];
      围栏Animator.Play("围栏受击",0,0);
      FightController.S.Show伤害数字(PlayerData.S.格式化数字(damage),YuanSuType.物理,new Vector2(-5,y));
      if (FightController.S.城墙护盾值 >= damage)
      {
          FightController.S.城墙护盾值 -= (int)damage;
      }
      else
      {
          FightController.S.城墙当前生命值 -= (int)damage - FightController.S.城墙护盾值;
          FightController.S.城墙护盾值 = 0;
      }
      if (FightController.S.城墙当前生命值 <= 0)
      {
          if (FightController.S.涅槃次数 > 0)
          {
              FightController.S.涅槃次数--;
              FightController.S.城墙当前生命值 = (int)(城墙Config.Get城墙最大生命值() * (城墙Config.涅槃血量 / 100f));
              if (FightController.S.城墙无敌Time > 0)
              {
                  FightController.S.城墙无敌Time += 城墙Config.涅槃无敌时间;
              }
              else
              {
                  FightController.S.城墙无敌Time = 城墙Config.涅槃无敌时间;
              }
          }
          else
          {
              Time.timeScale = 0;
              FightController.S.战斗结束 = true;
              StartCoroutine(DelayShow失败弹窗());
          }  
      }
      Set血条();
   }

   public IEnumerator DelayShow失败弹窗()
   {
       yield return new WaitForSecondsRealtime(0.5f);
       Instantiate(Resources.Load("Prefabs/Window/失败弹窗"));
   }

   public void 设置护盾(object[] obj)
   {
       Set血条();
   }
   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("围栏受击",围栏受击);
      ObserverModuleManager.S.UnRegisterEvent("设置护盾",设置护盾);
   }  

   private void Start()
   {
      Application.targetFrameRate = 30;
      ObserverModuleManager.S.RegisterEvent("围栏受击",围栏受击);
      ObserverModuleManager.S.RegisterEvent("设置护盾",设置护盾);
      地图Type type = Get地图Type();
      ObserverModuleManager.S.SendEvent("设置地图",type);
      InitRenWu();
      Set血条();
      Init伤害面板();
      Set倍速();
      Canvas.ForceUpdateCanvases();
   }

   public void Set倍速()
   {
       Time.timeScale = PlayerData.S.关卡倍速;
   }

   public 地图Type Get地图Type()
   {
      switch (LevelConfig.当前主线关卡Type)
      {
         case 主线关卡Type.花果山:
                return 地图Type.森林;
            case 主线关卡Type.水帘洞:
                return 地图Type.森林;;
            case 主线关卡Type.蓬莱仙岛:
                return 地图Type.平原;;
            case 主线关卡Type.五行山:
                return 地图Type.雪地;
            case 主线关卡Type.傲来国:
                return 地图Type.平原;
            case 主线关卡Type.高老庄:
                return 地图Type.平原;
            case 主线关卡Type.女儿国:
                return 地图Type.平原;
            case 主线关卡Type.小雷音寺:
                return 地图Type.平原;
            case 主线关卡Type.平顶山:
                return 地图Type.平原;
            case 主线关卡Type.火焰山:
                return 地图Type.火山;
            case 主线关卡Type.芭蕉洞:
                return 地图Type.沙漠;
            case 主线关卡Type.流沙河:
                return 地图Type.沙漠;
            case 主线关卡Type.狮驼岭:
                return 地图Type.沙漠;
            case 主线关卡Type.东海龙宫:
                return 地图Type.海底;
            case 主线关卡Type.冥府:
                return 地图Type.火山;

            // ==================== 天庭篇（凌霄宝殿十大关 · 第16~23关）====================
            case 主线关卡Type.南天门:
            case 主线关卡Type.瑶池仙境:
            case 主线关卡Type.斩妖台:
            case 主线关卡Type.御马监:
            case 主线关卡Type.蟠桃园:
            case 主线关卡Type.兜率宫:
            case 主线关卡Type.紫微宫:
            case 主线关卡Type.昊天殿:
            case 主线关卡Type.登天路:
            case 主线关卡Type.欲界天:
            case 主线关卡Type.色界天:
            case 主线关卡Type.无色天:
            case 主线关卡Type.四梵天:
            case 主线关卡Type.玉清境清微天:
            case 主线关卡Type.上清境禹余天:
            case 主线关卡Type.太清境大赤天:
            case 主线关卡Type.大罗天:
                return 地图Type.天庭;
      }

      return 地图Type.混沌;
   }

   public void InitRenWu()
   {
      int index = 1;
      foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
      {
         if (item == HeroType.None)
         {
            continue;
         }
         var renwu = Instantiate(Resources.Load("Prefabs/Fight/人物Item"),人物Parent.transform).GetComponent<人物item>();
         renwu.heroType = item;
         renwu.SetItem();
         renwu.transform.localPosition = FightConfig.人物位置Dic[index];
         renwu.原始Pos = renwu.transform.position;
         FightController.S.人物items[item] = renwu;
         index++;
      }
   }

   public void Init伤害面板()
   {
       List<HeroType> heroTypes = new List<HeroType>();
       foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
       {
           if (item != HeroType.None)
           {
               FightController.S.当前英雄伤害Dic[item] = 0;
               heroTypes.Add(item);
           }
       }
       ObserverModuleManager.S.SendEvent("Init伤害面板",heroTypes);
   }
   
}
