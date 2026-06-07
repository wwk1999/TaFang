using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
   public Button StartBtn;

   private void Start()
   {
      StartBtn.onClick.AddListener(() =>
         {
            gameObject.SetActive(false);
            WindowController.S.MainWindow.gameObject.SetActive(true);
         }
      );
   }
}
