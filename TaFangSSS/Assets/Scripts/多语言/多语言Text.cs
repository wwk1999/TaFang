using Config;
using TMPro;
using UnityEngine;

/// <summary>
/// 挂在任意 TMP 文本上，用「简体中文原文」作为 key 自动翻译。
/// 语言切换时自动刷新；同时按需求开启自动字号（最大值=当前字号，最小值=12）。
///
/// 一般不需要手动挂：多语言工具.翻译窗口(root) 会给窗口下所有 TMP 自动补上。
/// </summary>
[DisallowMultipleComponent]
public class 多语言Text : MonoBehaviour
{
    [Tooltip("留空则自动取当前文本作为简体中文原文")]
    [SerializeField] private string 简体中文原文;

    private TMP_Text _text;
    private string _上次译文;
    private bool _已初始化;

    public string 原文 => 简体中文原文;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        if (_text == null) _text = GetComponent<TMP_Text>();
        if (_text == null) return;

        多语言Config.语言变化事件 += 刷新;
        初始化();
        Apply(多语言Config.Get(简体中文原文));

        // 兜底：即使没跑编辑器里的批量工具，也保证字号自适应
        if (!_text.enableAutoSizing)
        {
            float 当前字号 = _text.fontSize;
            if (当前字号 < 1f) 当前字号 = _text.fontSizeMax >= 1f ? _text.fontSizeMax : 36f;
            _text.fontSizeMax = Mathf.Max(12f, 当前字号);
            _text.fontSizeMin = 12f;
            _text.enableAutoSizing = true;
        }
        else if (_text.fontSizeMin < 12f)
        {
            _text.fontSizeMin = 12f;
        }
    }

    private void OnDisable()
    {
        多语言Config.语言变化事件 -= 刷新;
    }

    private void 初始化()
    {
        if (_已初始化 || _text == null) return;
        _已初始化 = true;
        if (string.IsNullOrEmpty(简体中文原文))
        {
            采集原文();
        }
        else
        {
            string 还原 = 多语言Config.还原原文(简体中文原文);
            if (还原 != null) 简体中文原文 = 还原;
        }
    }

    /// <summary>取当前显示文本作为原文；如果是其他语言的译文，先反查回简中 key。</summary>
    private void 采集原文()
    {
        if (_text == null) return;
        string 当前 = _text.text;
        if (string.IsNullOrEmpty(当前)) return;
        简体中文原文 = 多语言Config.还原原文(当前) ?? 当前;
    }

    private void 刷新()
    {
        if (!_已初始化) 初始化();
        if (_text == null) return;

        // 代码后来改了文本（比如换了一个物品），把新文本当作新原文
        if (!string.IsNullOrEmpty(_text.text) && _text.text != _上次译文)
        {
            采集原文();
        }
        Apply(多语言Config.Get(简体中文原文));
    }

    /// <summary>供 多语言管理器 在文本被外部改动时调用。</summary>
    public void 刷新外部()
    {
        刷新();
    }

    private void Apply(string 译文)
    {
        if (_text == null) _text = GetComponent<TMP_Text>();
        _上次译文 = 译文;
        if (_text != null) _text.text = 译文;
    }

    /// <summary>代码动态指定词条时用，会立即按当前语言翻译。</summary>
    public void 设置原文(string 原文)
    {
        简体中文原文 = 原文;
        已初始化标记();
        Apply(多语言Config.Get(原文));
    }

    private void 已初始化标记()
    {
        _已初始化 = true;
    }
}
