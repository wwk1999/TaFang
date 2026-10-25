using System.Collections;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 挂在种植item的背景Button上，鼠标悬停时弹出种子信息弹窗，移开关闭。
/// 依赖同物体上的 种植item 组件读取灵植类型。
/// </summary>
public class 种植itemImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private 种植item 种植item;
    private Coroutine 关闭协程;

    private void Awake()
    {
        种植item = GetComponent<种植item>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (关闭协程 != null)
        {
            StopCoroutine(关闭协程);
            关闭协程 = null;
        }

        if (种植item == null || 种植item.灵植Tyep == 灵植Type.None) return;

        var 界面 = GetComponentInParent<灵植园界面>();
        if (界面 == null || 界面.种子信息弹窗 == null) return;

        界面.种子信息弹窗.打开(种植item.灵植Tyep, 是否变异: false, 是否种子: true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var 界面 = GetComponentInParent<灵植园界面>();
        if (界面 == null || 界面.种子信息弹窗 == null) return;

        // 延迟关闭，避免弹窗刚好生成在指针下方导致立刻触发 Exit 又关掉
        if (关闭协程 != null) StopCoroutine(关闭协程);
        关闭协程 = StartCoroutine(延迟关闭(界面.种子信息弹窗));
    }

    private IEnumerator 延迟关闭(种子信息弹窗 弹窗)
    {
        yield return new WaitForSeconds(0.15f);
        if (弹窗 != null) 弹窗.gameObject.SetActive(false);
        关闭协程 = null;
    }
}

