using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 任务区域 : MonoBehaviour
{
   public Button 箭头Button;
   public GameObject content;

   public void Show()
   {
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }

      foreach (var item in PlayerData.S.当前任务列表)
      {
         if (任务Config.任务配置[item].任务类型 == 任务类型.主线任务)
         {
            var 任务item = Instantiate(Resources.Load("Prefabs/Window/任务/任务item"), content.transform)
               .GetComponent<任务item>();
            任务item.任务Type = item;
            任务item.SetItem();
         }
      }
      
      foreach (var item in PlayerData.S.当前任务列表)
      {
         if (任务Config.任务配置[item].任务类型 == 任务类型.支线任务)
         {
            var 任务item = Instantiate(Resources.Load("Prefabs/Window/任务/任务item"), content.transform)
               .GetComponent<任务item>();
            任务item.任务Type = item;
            任务item.SetItem();
         }
      }
   }

   private void OnEnable()
   {
      Show();
   }

   public void 刷新任务栏(object[] obj)
   {
      Show();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新任务栏",刷新任务栏);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新任务栏",刷新任务栏);
      箭头Button.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
   }
}
