using System;
using Config;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class 伤害数字 : MonoBehaviour
{
    public TextMeshProUGUI 数字;
    public CanvasGroup canvasGroup;

    [NonSerialized] public YuanSuType YuanSuType = YuanSuType.None;
    [NonSerialized] public string text;
    [NonSerialized] public bool is回血;
    [NonSerialized] public bool is暴击 = false;

    private Tween _tween;
    private RectTransform _数字Rect;

    // 四角色（左上/右上/左下/右下），与原 TMP 渐变预设资源完全一致
    private static readonly VertexGradient 物理渐变 = new VertexGradient(
        new Color(0.48235297f, 0.48235297f, 0.49411768f),
        new Color(0.48235297f, 0.48235297f, 0.49411768f),
        new Color(0.8431373f, 0.8431373f, 0.83921576f),
        new Color(0.8431373f, 0.8431373f, 0.83921576f));
    private static readonly VertexGradient 冰渐变 = new VertexGradient(
        new Color(0.07450981f, 0.27450982f, 0.75294125f),
        new Color(0.07450981f, 0.27450982f, 0.75294125f),
        new Color(0.7058824f, 0.8745099f, 0.9490197f),
        new Color(0.7058824f, 0.8745099f, 0.9490197f));
    private static readonly VertexGradient 火渐变 = new VertexGradient(
        new Color(0.89019614f, 0.14901961f, 0.015686275f),
        new Color(0.89019614f, 0.14901961f, 0.015686275f),
        new Color(0.9921569f, 0.86274517f, 0.32156864f),
        new Color(0.9921569f, 0.86274517f, 0.32156864f));
    private static readonly VertexGradient 电渐变 = new VertexGradient(
        new Color(0.83921576f, 0.5803922f, 0.027450982f),
        new Color(0.83921576f, 0.5803922f, 0.027450982f),
        new Color(0.9921569f, 0.9490197f, 0.5176471f),
        new Color(0.9921569f, 0.9490197f, 0.5176471f));
    private static readonly VertexGradient 黑暗渐变 = new VertexGradient(
        new Color(0.18823531f, 0.08627451f, 0.34117648f),
        new Color(0.18823531f, 0.08627451f, 0.34117648f),
        new Color(0.8352942f, 0.6745098f, 0.95294124f),
        new Color(0.8352942f, 0.6745098f, 0.95294124f));
    private static readonly VertexGradient 回血渐变 = new VertexGradient(
        new Color(0.016629264f, 0.735849f, 0f),
        new Color(0.016629264f, 0.735849f, 0f),
        new Color(0.13546348f, 1f, 0f),
        new Color(0.13546348f, 1f, 0f));
    private static readonly VertexGradient 暴击渐变 = new VertexGradient(
        new Color(1f, 0f, 0.06809378f),
        new Color(1f, 0f, 0.06809378f),
        new Color(1f, 0.747714f, 0.066037595f),
        new Color(1f, 0.747714f, 0.066037595f));

    public void Hide()
    {
        _tween?.Kill();
        _tween = null;
        QueueController.S.伤害数字Queue.Enqueue(this);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _tween?.Kill();
        _tween = null;
    }

    private void OnEnable()
    {
        if (_数字Rect == null) _数字Rect = 数字.rectTransform;

        // 文本内容（暴击保留"暴击"前缀）
        数字.text = is暴击 ? "暴击" + text : text;

        // 顶点渐变色：纯顶点色不打断合批，替代原来 7 个不同颜色的 TMP
        数字.enableVertexGradient = true;
        if (is回血) 数字.colorGradient = 回血渐变;
        else if (is暴击) 数字.colorGradient = 暴击渐变;
        else
        {
            switch (YuanSuType)
            {
                case YuanSuType.冰: 数字.colorGradient = 冰渐变; break;
                case YuanSuType.火: 数字.colorGradient = 火渐变; break;
                case YuanSuType.电: 数字.colorGradient = 电渐变; break;
                case YuanSuType.黑暗: 数字.colorGradient = 黑暗渐变; break;
                default: 数字.colorGradient = 物理渐变; break;
            }
        }

        // 还原动画初始状态（与原 Animator 曲线一致）
        canvasGroup.alpha = 1f;
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        _数字Rect.anchoredPosition = Vector2.zero;

        _tween?.Kill();
        var seq = DOTween.Sequence();
        // 0~0.17s：1.3 缩放到 1（弹出）
        seq.Append(transform.DOScale(1f, 0.167f).SetEase(Ease.OutQuad));
        // 0~0.5s：上浮 0.297（线性）
        seq.Join(_数字Rect.DOAnchorPosY(0.297f, 0.5f).SetEase(Ease.Linear));
        // 0.33~0.5s：CanvasGroup 淡出（不重建文本网格）
        seq.Insert(0.333f, canvasGroup.DOFade(0f, 0.167f).SetEase(Ease.Linear));
        seq.OnComplete(Hide);
        _tween = seq;
    }
}
