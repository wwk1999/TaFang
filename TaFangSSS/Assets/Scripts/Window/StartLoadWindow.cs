using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 开始游戏后的加载窗口（StartLoadScene）：
/// 点击"开始游戏"先进入本场景，ResourcesConfig 的全量资源加载在协程里分帧执行，
/// 进度条/提示文本随真实进度刷新，主线程持续渲染不卡顿；加载完成后异步进入主界面。
/// </summary>
public class StartLoadWindow : MonoBehaviour
{
   public Slider loadSlider;
   public TextMeshProUGUI count;
   public TextMeshProUGUI tips;

   private static readonly string[] 小提示s =
   {
      "探索秘境可获得大法宝与资源~",
      "赌坊抽卡有概率获得稀有藏品哦~",
      "炼器镶嵌符文可以大幅提升战力~",
      "灵植园种出的灵植可以炼制丹药~",
      "通天塔层数越高奖励越丰厚~",
      "记得去领主府收取每日供奉收益~",
   };

   private const float 资源阶段占比 = 0.8f;   // ResourcesConfig 分帧加载占进度条 0~80%
   private float 目标进度;                     // 真实进度
   private float 显示进度;                     // 平滑追赶的显示进度

   private void Start()
   {
      if (loadSlider != null) loadSlider.value = 0;
      if (count != null) count.text = "0%";
      StartCoroutine(提示轮播());
      StartCoroutine(加载主界面流程());
   }

   private void Update()
   {
      // 显示进度平滑追赶真实进度，进度条不跳变；不用 Time.timeScale 以防外部归零
      显示进度 = Mathf.MoveTowards(显示进度, 目标进度, Time.unscaledDeltaTime * 1.2f);
      if (loadSlider != null) loadSlider.value = 显示进度;
      if (count != null) count.text = (int)(显示进度 * 100) + "%";
   }

   private IEnumerator 加载主界面流程()
   {
      // 阶段1（0~80%）：分帧加载 ResourcesConfig 全部资源，每批让出一帧渲染加载UI
      yield return StartCoroutine(ResourcesConfig.InitAsync(p => 目标进度 = p * 资源阶段占比));

      // 预热赌坊藏品百科 item 全局对象池（分帧实例化），首次打开百科弹窗不卡顿
      yield return StartCoroutine(QueueController.S.Init藏品百科itemQueue());

      // 阶段2（80~100%）：异步加载目标场景（首次进入进新手引导场景，否则进主界面 UIScene）
      string 目标场景 = PlayerData.S.是否首次进入游戏 ? "FirstScene" : "UIScene";
      AsyncOperation async = SceneManager.LoadSceneAsync(目标场景, LoadSceneMode.Single);
      async.allowSceneActivation = false;
      while (async.progress < 0.9f)
      {
         目标进度 = 资源阶段占比 + async.progress / 0.9f * (1f - 资源阶段占比);
         yield return null;
      }

      // 等进度条平滑走满后再激活场景，切换瞬间即进入主界面
      目标进度 = 1f;
      while (显示进度 < 0.999f) yield return null;
      async.allowSceneActivation = true;
   }

   private IEnumerator 提示轮播()
   {
      while (true)
      {
         if (tips != null) tips.text = "【小提示】" + 小提示s[Random.Range(0, 小提示s.Length)];
         yield return new WaitForSeconds(3f);
      }
   }
}
