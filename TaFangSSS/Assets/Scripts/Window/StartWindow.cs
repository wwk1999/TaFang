using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
   public Button StartBtn;
   public Button 设置Btn;
   public Button 退出Btn;
   public Canvas canvas;

   private void Start()
   {
      QueueController.S.Init主页秘境itemQueue();
      ResourcesConfig.Init();
      ObserverModuleManager.S.SendEvent("播放BGM",true);
      StartBtn.onClick.AddListener(() =>
         {
            SceneManager.LoadScene("UIScene");
         }
      );
      设置Btn.onClick.AddListener(() =>
         {
            GameObject obj=Instantiate(Resources.Load("Prefabs/Window/设置界面"),canvas.transform)as GameObject;
            obj.transform.SetAsLastSibling();
         }
      );
      退出Btn.onClick.AddListener(() =>
      {
         Application.Quit();
      });
   }

   private void OnEnable()
   {
      ObserverModuleManager.S.SendEvent("播放BGM",true);
   }
}
