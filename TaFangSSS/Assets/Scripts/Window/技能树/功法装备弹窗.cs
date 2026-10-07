using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 功法装备弹窗 : MonoBehaviour
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
         var 新功法 = HeroWindowController.S.当前选择功法;
         var 旧功法 = PlayerData.S.HeroDataDic[heroType].功法Type;
         // 重复装备同一本：英雄已经穿着，无事可做，直接关窗
         if (旧功法 == 新功法)
         {
             ObserverModuleManager.S.SendEvent("SendUIToast","功法类型相同");
            gameObject.SetActive(false);
            return;
         }
         // 库存检查：没有存货就拒绝，否则数量会被扣成负数，
         // 负数在背包里永不显示，玩家表现为"抽到了却背包没有"
         if (PlayerData.S.功法数量Dic[新功法] < 1)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","功法数量不足");
            return;
         }
      
         PlayerData.S.HeroDataDic[heroType].功法Type = 新功法;
         PlayerData.S.HeroDataDic[heroType].功法等级 = 1;
         PlayerData.S.HeroDataDic[heroType].功法星级 = 0;
         PlayerData.S.HeroDataDic[heroType].功法经验 = 0;
         PlayerData.S.功法数量Dic[新功法]--;
         ObserverModuleManager.S.SendEvent("刷新英雄详情界面");
         ObserverModuleManager.S.SendEvent("刷新英雄卡片功法",heroType);
         gameObject.SetActive(false);
      });
    }
}
