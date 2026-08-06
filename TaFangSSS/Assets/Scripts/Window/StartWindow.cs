using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
   public Button StartBtn;

   private void Start()
   {
      ObserverModuleManager.S.SendEvent("播放BGM",true);
      StartBtn.onClick.AddListener(() =>
         {
            SceneManager.LoadScene("UIScene");
         }
      );
   }

   private void OnEnable()
   {
      ObserverModuleManager.S.SendEvent("播放BGM",true);
   }
}
