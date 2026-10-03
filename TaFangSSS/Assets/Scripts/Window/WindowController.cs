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
   /// </summary>
   public void 打开窗口(GameObject window)
   {
      // 先激活，再延迟刷新：窗口未激活时其 Canvas 不在全局排序列表里，改了也没用
      window.SetActive(true);
      强制刷新画布排序(window);
   }

   /// <summary>
   /// 必须跨帧：同帧内 +N 再改回，帧末 sortingOrder 最终值未变，
   /// UGUI 会跳过全局排序重建（之前几轮修复偶发无效的根因）。
   /// 跨帧后新值至少被渲染一帧，全局排序列表一定重建。
   /// </summary>
   public static void 强制刷新画布排序(GameObject window)
   {
      if (window == null) return;
      // 弹窗类节点通常不自带 Canvas（继承父窗口的），往父级找到实际承载它的画布
      var canvas = window.GetComponentInParent<Canvas>();
      if (canvas == null || canvas.renderMode != RenderMode.ScreenSpaceOverlay) return;
      // 用 WindowController 做协程宿主（DontDestroyOnLoad），避免窗口被关闭时协程中断
      S.StartCoroutine(延迟刷新画布排序协程(canvas));
   }

   private static IEnumerator 延迟刷新画布排序协程(Canvas canvas)
   {
      // 等一帧：让本帧激活/注册的 Canvas 完成 UGUI 注册
      yield return null;
      if (canvas == null) yield break;
      int order = canvas.sortingOrder;
      canvas.sortingOrder = order + 1;   // 新值持续到下一帧渲染 → 强制 UGUI 重建全局排序
      yield return null;                 // 让新值真实渲染一帧
      if (canvas != null) canvas.sortingOrder = order;  // 恢复原值（同样会触发一次重排）
   }
}
