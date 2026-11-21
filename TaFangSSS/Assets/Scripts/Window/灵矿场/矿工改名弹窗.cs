using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工改名弹窗 : MonoBehaviour
{
   [NonSerialized] public 矿工 矿工;
   public Button 确认Button;
   public Button 取消Button;
   public Button maskButton;
   public TMP_InputField input;

   private void Start()
   {
      取消Button.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      maskButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      确认Button.onClick.AddListener(() =>
      {
         if (input.text.Length <= 0)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","请输入矿工名");
            return;
         }
         矿工.name=input.text;
         ObserverModuleManager.S.SendEvent("矿工改名",矿工);
         gameObject.SetActive(false);
      });
   }
}
