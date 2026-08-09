using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
   public Button StartBtn;
   public Button 设置Btn;
   public Button 退出Btn;
   public Canvas canvas;

   // 在引擎初始化完成、Splash 显示之前直接读存档设置分辨率，
   // 避免"先全屏一帧再切回存档模式"的闪烁
   [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
   private static void ApplySavedDisplaySettings()
   {
      try
      {
         var path = Path.Combine(Application.persistentDataPath, "TaFangStore.json");
         if (!File.Exists(path)) return;
         var json = File.ReadAllText(path);
         var data = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json);
         if (data?.Player == null) return;

         int x = (int)data.Player.分辨率.x;
         int y = (int)data.Player.分辨率.y;
         if (x <= 0 || y <= 0) { x = 1920; y = 1080; }

         var mode = data.Player.是否窗口 ? FullScreenMode.Windowed : FullScreenMode.ExclusiveFullScreen;
         Screen.fullScreenMode = mode;
         Screen.SetResolution(x, y, mode);
      }
      catch
      {
         // 存档损坏等情况忽略，沿用 Player Settings 默认值
      }
   }

   private void Awake()
   {
      // 存档已在 BeforeSplashScreen 阶段应用；此处兜底，防止存档读取失败或切换场景后状态丢失
      int x = (int)PlayerData.S.分辨率.x;
      int y = (int)PlayerData.S.分辨率.y;
      if (!PlayerData.S.是否窗口)
      {
         Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
         Screen.SetResolution(x, y, FullScreenMode.ExclusiveFullScreen);
      }
      else
      {
         Screen.fullScreenMode = FullScreenMode.Windowed;
         Screen.SetResolution(x, y, FullScreenMode.Windowed);
      }
   }

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
