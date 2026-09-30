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
   [NonSerialized]public GameObject 领主府Window;



   private void Awake()
   {
      base.Awake();
      Init();
   }

   public void Init()
   {
      MainWindow=Instantiate(Resources.Load<GameObject>("Prefabs/Window/MainWindow"));
      MainWindow.SetActive(true);
   }

   /// <summary>
   /// 显示窗口并强制刷新 UGUI 全局画布排序。
   /// additive 双场景并存/SetActive 切换后，Overlay Canvas 的全局排序缓存可能不重建
   /// （Game视图层级错误、Scene视图正常，手动改一次任意 Canvas.sortingOrder 即恢复）。
   /// 这里通过切换 Canvas.enabled 让其重新注册，等价于手动改 sortingOrder 触发的全局重排。
   /// </summary>
   public void 打开窗口(GameObject window)
   {
      window.SetActive(true);
      强制刷新画布排序(window);
   }

   public static void 强制刷新画布排序(GameObject window)
   {
      if (window == null) return;
      var canvas = window.GetComponent<Canvas>();
      if (canvas != null && canvas.renderMode == RenderMode.ScreenSpaceOverlay)
      {
         // 用 sortingOrder +1 再还原触发 UGUI 全局画布排序缓存重建
         // （Canvas.enabled 切换不触发全局重排，只有 sortingOrder setter 才会标脏全局列表）
         int order = canvas.sortingOrder;
         canvas.sortingOrder = order + 1;
         canvas.sortingOrder = order;
      }
      Canvas.ForceUpdateCanvases();
   }
}
