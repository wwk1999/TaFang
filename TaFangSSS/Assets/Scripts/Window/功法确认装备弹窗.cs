using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 功法确认装备弹窗 : MonoBehaviour
{
   [NonSerialized]public HeroType heroType;
   public Button maskbutton;
   public Button 返回按钮;
   public Button 确认按钮;

   private void Start()
   {
      返回按钮.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      maskbutton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      确认按钮.onClick.AddListener(() =>
      {
         // 库存检查：弹窗打开期间库存可能已被其他操作消耗，
         // 无校验直接扣会扣成负数，负数在背包里永不显示（传道抽到+1仍是负数不可见）
         if (PlayerData.S.功法数量Dic[HeroWindowController.S.当前选择功法] < 1)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","功法数量不足");
            return;
         }
         PlayerData.S.HeroDataDic[heroType].功法Type = HeroWindowController.S.当前选择功法;
         PlayerData.S.HeroDataDic[heroType].功法等级 = 1;
         PlayerData.S.HeroDataDic[heroType].功法星级 = 0;
         PlayerData.S.HeroDataDic[heroType].功法经验 = 0;
         PlayerData.S.功法数量Dic[HeroWindowController.S.当前选择功法]--;
         ObserverModuleManager.S.SendEvent("刷新英雄功法");
         ObserverModuleManager.S.SendEvent("隐藏功法选择弹窗");
         ObserverModuleManager.S.SendEvent("刷新英雄卡片功法",heroType);
         gameObject.SetActive(false);
      });
   }
}
