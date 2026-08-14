using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 突破弹窗 : MonoBehaviour
{
   public Button ExitButton;
   public GameObject Content;
   public 突破确认弹窗 突破确认弹窗;

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("显示突破确认弹窗",显示突破确认弹窗);
      ObserverModuleManager.S.UnRegisterEvent("Hide突破弹窗",Hide);
   }

   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      ObserverModuleManager.S.RegisterEvent("显示突破确认弹窗",显示突破确认弹窗);
      ObserverModuleManager.S.RegisterEvent("Hide突破弹窗",Hide);
   }

   public void 显示突破确认弹窗(object[] obj)
   {
      QualityType type = (QualityType)obj[0];
      突破确认弹窗.QualityType=type;
      突破确认弹窗.gameObject.SetActive(true);
   }

   public void Hide(object[] obj)
   {
      gameObject.SetActive(false);
   }

   private void OnEnable()
   {
      foreach (Transform item in Content.transform)
      {
         Destroy(item.gameObject);
      }

      var 黄品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      黄品.quality = QualityType.黄品;
      黄品.SetItem();

      var 玄品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      玄品.quality = QualityType.玄品;
      玄品.SetItem();
      
      var 地品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      地品.quality = QualityType.地品;
      地品.SetItem();
      
      var 天品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      天品.quality = QualityType.天品;
      天品.SetItem();
      
      var 宇品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      宇品.quality = QualityType.宇品;
      宇品.SetItem();
      
      var 宙品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      宙品.quality = QualityType.宙品;
      宙品.SetItem();
      
      var 洪品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      洪品.quality = QualityType.洪品;
      洪品.SetItem();
      
      var 荒品 = Instantiate(Resources.Load("Prefabs/Window/突破item"),Content.transform).GetComponent<突破item>();
      荒品.quality = QualityType.荒品;
      荒品.SetItem();
   }
}
