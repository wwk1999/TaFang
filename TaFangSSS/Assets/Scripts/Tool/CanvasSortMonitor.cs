using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 诊断工具：监控所有【根 Canvas】的状态变化（sortingOrder / 激活 / enabled）。
/// 只有根 Canvas 的变化才会触发 UGUI 全局排序重建，嵌套 Canvas 不影响全局排序。
/// 出现“过几秒窗口显示不对”的 bug 时，看 Console 里最后一条 [CanvasSortMonitor] 日志
/// 就知道是谁在背后作妖。定位完 bug 后删除此文件。
/// </summary>
public class CanvasSortMonitor : MonoBehaviour
{
    private class Snap { public int order; public bool active; public bool enabled; }
    private static CanvasSortMonitor _inst;
    private readonly Dictionary<Canvas, Snap> _last = new Dictionary<Canvas, Snap>();
    private float _t;
    private float _timer;

    [RuntimeInitializeOnLoadMethod]
    static void Init()
    {
        if (_inst != null) return;
        _inst = new GameObject("CanvasSortMonitor").AddComponent<CanvasSortMonitor>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        _t += Time.unscaledDeltaTime;
        _timer += Time.unscaledDeltaTime;
        if (_timer < 0.2f) return; // 5 次/秒轮询，避免每帧 FindObjectsOfType 开销
        _timer = 0f;

        foreach (var c in FindObjectsOfType<Canvas>(true))
        {
            if (c == null || !c.isRootCanvas) continue; // 只跟踪根 Canvas
            var cur = new Snap { order = c.sortingOrder, active = c.gameObject.activeInHierarchy, enabled = c.enabled };
            if (!_last.TryGetValue(c, out var s))
            {
                _last[c] = cur;
                Debug.Log($"[CanvasSortMonitor] {_t:F1}s 新根Canvas: {路径(c)} order={cur.order} active={cur.active} mode={c.renderMode}");
            }
            else if (s.order != cur.order || s.active != cur.active || s.enabled != cur.enabled)
            {
                Debug.Log($"[CanvasSortMonitor] {_t:F1}s 变化: {路径(c)} | order {s.order}->{cur.order} | active {s.active}->{cur.active} | enabled {s.enabled}->{cur.enabled}");
                _last[c] = cur;
            }
        }

        // 清理已销毁的
        List<Canvas> dead = null;
        foreach (var k in _last.Keys)
        {
            if (k == null) { (dead ??= new List<Canvas>()).Add(k); }
        }
        if (dead != null) foreach (var d in dead) _last.Remove(d);
    }

    private string 路径(Canvas c)
    {
        var t = c.transform;
        string p = t.name;
        while (t.parent != null) { t = t.parent; p = t.name + "/" + p; }
        return $"[{c.gameObject.scene.name}] {p}";
    }
}
