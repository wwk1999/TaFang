using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : XSingleton<WindowController>
{
   [NonSerialized]public GameObject StartWindow;
   [NonSerialized]public GameObject MainWindow;
   [NonSerialized]public GameObject LevelWindow;
   [NonSerialized]public GameObject 招募Window;

   private void OnEnable()
   {
      Init();
   }

   public void Init()
   {
      StartWindow=Instantiate(Resources.Load<GameObject>("Prefabs/Window/StartWindow"));
      MainWindow=Instantiate(Resources.Load<GameObject>("Prefabs/Window/MainWindow"));
      StartWindow.SetActive(true);
      MainWindow.SetActive(false);
      StoreController.S.LoadStoreData();
   }
}
