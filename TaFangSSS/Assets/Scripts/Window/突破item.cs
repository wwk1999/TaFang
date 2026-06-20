using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 突破item : MonoBehaviour
{
   public Button bgButton;
   public TextMeshProUGUI count;
   [NonSerialized] public 突破Type 突破Type;

   public void SetItem()
   { 
       bgButton.onClick.RemoveAllListeners();
      switch (突破Type)
      {
         case 突破Type.凡:
            bgButton.image.sprite = ResourcesConfig.突破背景凡;
            count.text = (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2).ToString();
            bgButton.interactable = PlayerData.S.PropListDic[PropType.领主经验值] >=
                                    (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2);
            bgButton.onClick.AddListener(() =>
            {
                PlayerData.S.PropListDic[PropType.领主经验值] -=
                    (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2);
                PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.凡;
                PlayerData.S.JingJieType++;
                PlayerData.S.Exp = 0;
                ObserverModuleManager.S.SendEvent("突破成功");
                ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                ObserverModuleManager.S.SendEvent("Hide突破弹窗");

            });
            break;
         case 突破Type.灵:
            bgButton.image.sprite = ResourcesConfig.突破背景灵;
            bgButton.interactable = PlayerData.S.PropListDic[PropType.领主经验值] >=
                                    (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2*1.2f);
            count.text = (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2*1.2f).ToString();
            bgButton.onClick.AddListener(() =>
            {
                PlayerData.S.PropListDic[PropType.领主经验值] -=
                    (int)(JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2*1.2f);
                PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.灵;
                PlayerData.S.JingJieType++;
                PlayerData.S.Exp = 0;
                ObserverModuleManager.S.SendEvent("突破成功");
                ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                ObserverModuleManager.S.SendEvent("Hide突破弹窗");

            });
            break;
         case 突破Type.仙:
            bgButton.interactable = PlayerData.S.PropListDic[PropType.领主经验值] >=
                                    (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2*1.5f);
            bgButton.image.sprite = ResourcesConfig.突破背景仙;
            count.text = (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2*1.5f).ToString();
            bgButton.onClick.AddListener(() =>
            {
                PlayerData.S.PropListDic[PropType.领主经验值] -=
                    (int)(JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] / 2*1.5f);
                PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.仙;
                PlayerData.S.JingJieType++;
                PlayerData.S.Exp = 0;
                ObserverModuleManager.S.SendEvent("突破成功");
                ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                ObserverModuleManager.S.SendEvent("Hide突破弹窗");

            });
            break;
         case 突破Type.圣:
            bgButton.interactable = PlayerData.S.PropListDic[PropType.领主经验值] >=
                                    (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] );
            bgButton.image.sprite = ResourcesConfig.突破背景圣;
            count.text = (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] ).ToString();
            bgButton.onClick.AddListener(() =>
            {
                PlayerData.S.PropListDic[PropType.领主经验值] -=
                    (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType]);
                PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.圣;
                PlayerData.S.JingJieType++;
                PlayerData.S.Exp = 0;
                ObserverModuleManager.S.SendEvent("突破成功");
                ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                ObserverModuleManager.S.SendEvent("Hide突破弹窗");

            });
            break;
         case 突破Type.荒:
            bgButton.interactable = PlayerData.S.PropListDic[PropType.领主经验值] >=
                                    (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] *1.5f);
            bgButton.image.sprite = ResourcesConfig.突破背景荒;
            count.text = (JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] *1.5f).ToString();
            bgButton.onClick.AddListener(() =>
            {
                PlayerData.S.PropListDic[PropType.领主经验值] -=
                    (int)(JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] *1.5f);
                PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.荒;
                PlayerData.S.JingJieType++;
                PlayerData.S.Exp = 0;
                ObserverModuleManager.S.SendEvent("突破成功");
                ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                ObserverModuleManager.S.SendEvent("Hide突破弹窗");

            });

            break;
      }
   }
}
