using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Toast : MonoBehaviour
{
   public void SendUIToast(object[] obj)
   {
      string content = obj[0] as string;
      var toastItem=Instantiate(Resources.Load("Prefabs/Window/ToastItem"),transform).GetComponent<ToastItem>();
      toastItem.Content = content;
      toastItem.SetItem();
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
