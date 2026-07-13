using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 突破item : MonoBehaviour
{
    public TextMeshProUGUI 当前;
    public TextMeshProUGUI 需要值;
    public TextMeshProUGUI 跟脚;
   public Button bgButton;
   [NonSerialized] public 突破Type 突破Type;

   public void SetItem()
   { 
       bgButton.onClick.RemoveAllListeners();
      switch (突破Type)
      {
         case 突破Type.凡:
            bgButton.image.sprite = ResourcesConfig.突破背景凡;
            跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
            int 当前值 = PlayerData.S.PropListDic[PropType.破镜珠];
            int need = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][0];
            当前.text = 当前值.ToString();
            需要值.text = JingJieConfig.Get大数值(need);
            bgButton.interactable = PlayerData.S.PropListDic[PropType.破镜珠] >= JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][0];
            bgButton.onClick.AddListener(() =>
            {
                PlayerData.S.PropListDic[PropType.破镜珠] -= need;
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
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值1 = PlayerData.S.PropListDic[PropType.破镜珠];
             int need1 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][1];
             当前.text = 当前值1.ToString();
             需要值.text = JingJieConfig.Get大数值(need1);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.破镜珠] >= need1;
             bgButton.onClick.AddListener(() =>
             {
                 PlayerData.S.PropListDic[PropType.破镜珠] -= need1;
                 PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.灵;
                 PlayerData.S.JingJieType++;
                 PlayerData.S.Exp = 0;
                 ObserverModuleManager.S.SendEvent("突破成功");
                 ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                 ObserverModuleManager.S.SendEvent("Hide突破弹窗");

             });
             break;
         case 突破Type.仙:
             bgButton.image.sprite = ResourcesConfig.突破背景仙;
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值2= PlayerData.S.PropListDic[PropType.破镜珠];
             int need2 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][2];
             当前.text = 当前值2.ToString();
             需要值.text = JingJieConfig.Get大数值(need2);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.破镜珠] >= need2;
             bgButton.onClick.AddListener(() =>
             {
                 PlayerData.S.PropListDic[PropType.破镜珠] -= need2;
                 PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.仙;
                 PlayerData.S.JingJieType++;
                 PlayerData.S.Exp = 0;
                 ObserverModuleManager.S.SendEvent("突破成功");
                 ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                 ObserverModuleManager.S.SendEvent("Hide突破弹窗");

             });
             break;
         case 突破Type.圣:
             bgButton.image.sprite = ResourcesConfig.突破背景圣;
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值3 = PlayerData.S.PropListDic[PropType.破镜珠];
             int need3 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][3];
             当前.text = 当前值3.ToString();
             需要值.text = JingJieConfig.Get大数值(need3);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.破镜珠] >= need3;
             bgButton.onClick.AddListener(() =>
             {
                 PlayerData.S.PropListDic[PropType.破镜珠] -= need3;
                 PlayerData.S.突破Dic[PlayerData.S.JingJieType] = 突破Type.圣;
                 PlayerData.S.JingJieType++;
                 PlayerData.S.Exp = 0;
                 ObserverModuleManager.S.SendEvent("突破成功");
                 ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
                 ObserverModuleManager.S.SendEvent("Hide突破弹窗");

             });
             break;
         case 突破Type.荒:
             bgButton.image.sprite = ResourcesConfig.突破背景荒;
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值4 = PlayerData.S.PropListDic[PropType.破镜珠];
             int need4 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][4];
             当前.text = 当前值4.ToString();
             需要值.text = JingJieConfig.Get大数值(need4);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.破镜珠] >= need4;
             bgButton.onClick.AddListener(() =>
             {
                 PlayerData.S.PropListDic[PropType.破镜珠] -= need4;
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
