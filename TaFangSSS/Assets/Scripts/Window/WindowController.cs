using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : XSingleton<WindowController>
{
   [NonSerialized]public GameObject MainWindow;
   [NonSerialized]public GameObject LevelWindow;
   [NonSerialized]public GameObject 招募Window;
   [NonSerialized]public GameObject 英雄Window;


   private void OnEnable()
   {
      Init();
   }

   public void Init()
   {
      MainWindow=Instantiate(Resources.Load<GameObject>("Prefabs/Window/MainWindow"));
      MainWindow.SetActive(true);
      StoreController.S.LoadStoreData();
   }
}
