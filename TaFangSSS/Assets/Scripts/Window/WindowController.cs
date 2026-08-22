using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : XSingleton<WindowController>
{
   [NonSerialized]public GameObject MainWindow;
   [NonSerialized]public GameObject 招募Window;
   [NonSerialized]public GameObject 英雄Window;
   [NonSerialized]public GameObject 储物袋Window;
   [NonSerialized]public GameObject 道宝Window;
   [NonSerialized]public GameObject 城墙Window;
   [NonSerialized]public GameObject 炼器Window;
   [NonSerialized]public GameObject 炼丹Window;


   private void Awake()
   {
      Init();
   }

   public void Init()
   {
      MainWindow=Instantiate(Resources.Load<GameObject>("Prefabs/Window/MainWindow"));
      MainWindow.SetActive(true);
   }
}
