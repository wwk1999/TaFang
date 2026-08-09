using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 设置界面 : MonoBehaviour
{
   public Button maskButton;
   public Button exitButton;
   public TMP_Dropdown  语言Dropdown;
   public TMP_Dropdown  分辨率Dropdown;
   public Slider BGMSlider;
   public Slider 音效Slider;
   public Toggle 窗口模式Toggle;

   public void Start()
   {
      BGMSlider.value = PlayerData.S.BGM音量;
      音效Slider.value = PlayerData.S.音效音量;
      窗口模式Toggle.isOn = PlayerData.S.是否窗口;
      switch (PlayerData.S.分辨率.x)
      {
         case 2560:
            分辨率Dropdown.value = 0;
            break;
         case 1920:
            分辨率Dropdown.value = 1;
            break;
         case 1366:
            分辨率Dropdown.value = 2;
            break;
      }
      
      maskButton.onClick.AddListener(() => { Destroy(gameObject); });
      exitButton.onClick.AddListener(() => { Destroy(gameObject); });
      BGMSlider.onValueChanged.AddListener(delegate
      {
         PlayerData.S.BGM音量 = BGMSlider.value;
         ObserverModuleManager.S.SendEvent("设置BGM音量");
      });
      音效Slider.onValueChanged.AddListener(delegate
      {
         PlayerData.S.音效音量 = 音效Slider.value;
         ObserverModuleManager.S.SendEvent("设置音效音量");
      });
      窗口模式Toggle.onValueChanged.AddListener(delegate
      {
         PlayerData.S.是否窗口=窗口模式Toggle.isOn;
         int x = (int)PlayerData.S.分辨率.x;
         int y = (int)PlayerData.S.分辨率.y;
         if (!窗口模式Toggle.isOn)
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
   );

   分辨率Dropdown.onValueChanged.AddListener(delegate
      {
         FullScreenMode mode = PlayerData.S.是否窗口 ? FullScreenMode.Windowed : FullScreenMode.ExclusiveFullScreen;
         switch (分辨率Dropdown.value)
         {
            case 0:
               PlayerData.S.分辨率 = new Vector2(2560, 1440);
               Screen.SetResolution(2560, 1440, mode);
               break;
            case 1:
               PlayerData.S.分辨率 = new Vector2(1920, 1080);
               Screen.SetResolution(1920, 1080, mode);
               break;
            case 2:
               PlayerData.S.分辨率 = new Vector2(1366, 768);
               Screen.SetResolution(1366, 768, mode);
               break;
         }
      });
   }
}
