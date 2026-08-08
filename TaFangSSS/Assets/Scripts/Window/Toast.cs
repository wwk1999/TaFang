using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class Toast : MonoBehaviour
{
   public void SendUIToast(object[] obj)
   {
      if (obj.Length == 1)
      {
          string content = obj[0] as string;
          var toastItem=Instantiate(Resources.Load("Prefabs/Window/ToastItem"),transform).GetComponent<ToastItem>();
          toastItem.Content = content;
          toastItem.SetItem();
      }
      else
      {
         string name = obj[0] as string;
         QualityType quality = (QualityType)obj[1];
         int count = (int)obj[2];
         var toastItem=Instantiate(Resources.Load("Prefabs/Window/ToastItem"),transform).GetComponent<ToastItem>();
         toastItem.name = name;
         toastItem.quality = quality;
         toastItem.count = count;
         toastItem.SetItem();
      }
     
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("SendUIToast",SendUIToast);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("SendUIToast",SendUIToast);
   }
}
