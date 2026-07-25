using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class Entrance : MonoBehaviour
{
   public GameObject 人物Parent;
   public Animator 围栏Animator;

   public void 围栏受击(object[] obj)
   {
      if (围栏Animator == null)
      {
         围栏Animator =GameObject.Find("围栏").GetComponent<Animator>();
      }
      float damage = (float)obj[0];
      float y=(float)obj[1];
      围栏Animator.Play("围栏受击",0,0);
      FightController.S.Show伤害数字(damage,YuanSuType.物理,new Vector2(-5,y));
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("围栏受击",围栏受击);
   }

   private void Start()
   {
      Application.targetFrameRate = 30;
      ObserverModuleManager.S.RegisterEvent("围栏受击",围栏受击);
      地图Type type = Get地图Type();
      ObserverModuleManager.S.SendEvent("设置地图",type);
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

      return 地图Type.沙漠;
   }

   public void InitRenWu()
   {
      int index = 1;
      foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.CurrentBianDui-1])
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

   private void Awake()
   {
      InitRenWu();
   }
}
