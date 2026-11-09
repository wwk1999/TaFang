using Config;
using TMPro;
using UnityEngine;

/// <summary>
/// 多语言辅助工具：给窗口下所有 TMP 文本自动挂载 多语言Text。
/// 字体回退：主中文字体（演示魁本楷书 SDF）已配置 4 个语言字体为 Fallback Font Assets，
/// 全项目统一使用该中文字体即可，运行时无需额外处理。
/// </summary>
public static class 多语言工具
{
    /// <summary>
    /// 给窗口（含未激活的子物体）下所有 TMP 文本自动补 多语言Text 组件。
    /// 已经有的不会重复添加，可反复调用。
    /// </summary>
    public static void 翻译窗口(Transform root)
    {
        if (root == null) return;
        var 文本列表 = root.GetComponentsInChildren<TMP_Text>(true);
        for (int i = 0; i < 文本列表.Length; i++)
        {
            var 文本 = 文本列表[i];
            // 下拉框/输入框内部文本由控件自己管理，跳过
            if (文本.GetComponentInParent<TMP_Dropdown>() != null) continue;
            if (文本.GetComponentInParent<TMP_InputField>() != null) continue;
            if (文本.GetComponent<多语言Text>() == null)
            {
                文本.gameObject.AddComponent<多语言Text>();
            }
        }
    }
}
