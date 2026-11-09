using Config;
using TMPro;
using UnityEngine;

/// <summary>
/// 全局多语言兜底：事件驱动，不做定时轮询。
/// 文本每次重新生成时，给还没挂 多语言Text 的自动补上；
/// 切语言时再整体扫一遍兜底。这样弹窗/列表项无论怎么创建都不会漏翻译。
/// </summary>
public class 多语言管理器 : MonoBehaviour
{
    private static 多语言管理器 _实例;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void 启动()
    {
        if (_实例 != null) return;
        var 对象 = new GameObject("[多语言管理器]");
        DontDestroyOnLoad(对象);
        _实例 = 对象.AddComponent<多语言管理器>();
    }

    private void OnEnable()
    {
        多语言Config.语言变化事件 += 扫描并翻译;
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(文本变化);
    }

    private void OnDisable()
    {
        多语言Config.语言变化事件 -= 扫描并翻译;
        TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(文本变化);
    }

    /// <summary>
    /// 文本每次重新生成时触发（TMP 只在文本真正变化/首次显示时发这个事件）。
    /// 没挂组件的补挂（挂上立即翻译），挂了的刷新，用于处理脚本后来写入的中文。
    /// </summary>
    private static void 文本变化(Object 对象)
    {
        if (!(对象 is TMP_Text 文本) || 文本 == null) return;
        var 组件 = 文本.GetComponent<多语言Text>();
        if (组件 != null)
        {
            组件.刷新外部();
            return;
        }
        尝试挂载(文本);
    }

    /// <summary>手动整体扫描一遍（切语言时调用，兜底覆盖所有已存在的文本）。</summary>
    public static void 扫描并翻译()
    {
        var 文本列表 = Object.FindObjectsOfType<TMP_Text>(true);
        for (int i = 0; i < 文本列表.Length; i++)
        {
            尝试挂载(文本列表[i]);
        }
    }

    private static void 尝试挂载(TMP_Text 文本)
    {
        if (文本 == null) return;
        if (文本.GetComponent<多语言Text>() != null) return;
        // 下拉框/输入框内部文本由控件自己管理，跳过
        if (文本.GetComponentInParent<TMP_Dropdown>() != null) return;
        if (文本.GetComponentInParent<TMP_InputField>() != null) return;

        文本.gameObject.AddComponent<多语言Text>();
    }
}
