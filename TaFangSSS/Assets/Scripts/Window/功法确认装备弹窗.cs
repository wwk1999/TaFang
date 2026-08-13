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
