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
            int 当前值 = PlayerData.S.PropListDic[PropType.功德];
            int need = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][0];
            当前.text = 当前值.ToString();
            需要值.text = JingJieConfig.Get大数值(need);
            bgButton.interactable = PlayerData.S.PropListDic[PropType.功德] >= JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][0];
            bgButton.onClick.AddListener(() =>
            {
                ObserverModuleManager.S.SendEvent("显示突破确认弹窗",突破Type.凡);
            });
            break;
         case 突破Type.灵:
             bgButton.image.sprite = ResourcesConfig.突破背景灵;
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值1 = PlayerData.S.PropListDic[PropType.功德];
             int need1 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][1];
             当前.text = 当前值1.ToString();
             需要值.text = JingJieConfig.Get大数值(need1);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.功德] >= need1;
             bgButton.onClick.AddListener(() =>
             {
                 ObserverModuleManager.S.SendEvent("显示突破确认弹窗",突破Type.灵);
             });
             break;
         case 突破Type.仙:
             bgButton.image.sprite = ResourcesConfig.突破背景仙;
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值2= PlayerData.S.PropListDic[PropType.功德];
             int need2 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][2];
             当前.text = 当前值2.ToString();
             需要值.text = JingJieConfig.Get大数值(need2);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.功德] >= need2;
             bgButton.onClick.AddListener(() =>
             {
                 ObserverModuleManager.S.SendEvent("显示突破确认弹窗",突破Type.仙);
             });
             break;
         case 突破Type.圣:
             bgButton.image.sprite = ResourcesConfig.突破背景圣;
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值3 = PlayerData.S.PropListDic[PropType.功德];
             int need3 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][3];
             当前.text = 当前值3.ToString();
             需要值.text = JingJieConfig.Get大数值(need3);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.功德] >= need3;
             bgButton.onClick.AddListener(() =>
             {
                 ObserverModuleManager.S.SendEvent("显示突破确认弹窗",突破Type.圣);
             });
             break;
         case 突破Type.荒:
             bgButton.image.sprite = ResourcesConfig.突破背景荒;
             跟脚.text = "跟脚X" + JingJieConfig.突破跟脚Dic[突破Type];
             int 当前值4 = PlayerData.S.PropListDic[PropType.功德];
             int need4 = JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][4];
             当前.text = 当前值4.ToString();
             需要值.text = JingJieConfig.Get大数值(need4);
             bgButton.interactable = PlayerData.S.PropListDic[PropType.功德] >= need4;
             bgButton.onClick.AddListener(() =>
             {
                 ObserverModuleManager.S.SendEvent("显示突破确认弹窗",突破Type.荒);
             });
             break;
      }
   }
}
