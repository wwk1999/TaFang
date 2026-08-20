using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 道具信息弹窗 : MonoBehaviour
{
   public Image bg;
   public Image icon;
   public TextMeshProUGUI name;
   public TextMeshProUGUI desc;
   public TextMeshProUGUI 数量;
   [NonSerialized]public 道具信息Type  type;
   [NonSerialized] public 主线关卡Type 主线关卡Type;

   private void FollowMouse()
   {
      Vector2 mousePos = Input.mousePosition;
      Vector2 targetPos = mousePos ;
      transform.position = targetPos;
   }

   private void Update()
   {
      FollowMouse();
   }

   public void SetItem()
   {
      bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(PropConfig.道具信息品质Dic[type]);
      icon.sprite = PropConfig.Get道具信息Sprite(type);
      name.text = PropConfig.道具信息NameDic[type];
      desc.text = PropConfig.道具信息InfoDic[type];
      switch (type)
      {
         case 道具信息Type.功德:
         case 道具信息Type.头盔锻造石:
         case 道具信息Type.射手经验值:
         case 道具信息Type.戒指锻造石:
         case 道具信息Type.战士经验值:
         case 道具信息Type.护手锻造石:
         case 道具信息Type.招募卷:
         case 道具信息Type.控制经验值:
         case 道具信息Type.法师经验值:
         case 道具信息Type.洗练石:
         case 道具信息Type.灵魂:
         case 道具信息Type.衣服锻造石:
         case 道具信息Type.辅助经验值:
         case 道具信息Type.鞋子锻造石:
         case 道具信息Type.项链锻造石:
         case 道具信息Type.高级招募卷:
            HashSet<LevelDiaoLuo> list=LevelConfig.LevelDiaoLuoDic[主线关卡Type];
            if (主线关卡Type == 主线关卡Type.混沌虚空)
            {
               var value=LevelConfig.Get混沌虚空奖励(HeroWindowController.S.显示混沌虚空层数,PropConfig.道具信息ToPropType[type]);
               数量.text = "掉落数量:" + value.min + "-" + value.max;
            }
            else
            {
               foreach (var item in list)
               {
                  if (item.PropType == PropConfig.道具信息ToPropType[type])
                  {
                     数量.text = "掉落数量:" + item.minCount + "-" + item.maxCount;
                  }
               }
            }

            break;

         case 道具信息Type.道宝紫:
         case 道具信息Type.道宝橙:
         case 道具信息Type.道宝粉:
         case 道具信息Type.道宝红:
         case 道具信息Type.道宝彩:
         case 道具信息Type.法则橙:
         case 道具信息Type.法则粉:
         case 道具信息Type.法则红:
         case 道具信息Type.法则彩:
         case 道具信息Type.城墙紫:
         case 道具信息Type.城墙橙:
         case 道具信息Type.城墙粉:
         case 道具信息Type.城墙红:
         case 道具信息Type.城墙彩:
         case 道具信息Type.灵药白:
         case 道具信息Type.灵药绿:
         case 道具信息Type.灵药蓝:
         case 道具信息Type.灵药紫:
         case 道具信息Type.灵药橙:
         case 道具信息Type.灵药粉:
         case 道具信息Type.灵药红:
         case 道具信息Type.灵药彩:
            数量.text = "品质:" + PropConfig.QualityNameDic[PropConfig.道具信息品质Dic[type]];
            break;
      }
   }
}
