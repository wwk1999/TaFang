using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 挂载到任何带有RectTransform的游戏对象上，实现鼠标拖拽跟随移动。
/// 物体跟随鼠标的移动方向和距离，而不是直接跳到鼠标位置。
/// </summary>
public class DraggableRectTransform : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Tooltip("是否限制拖拽范围在父RectTransform内（通常为Canvas）")]
    public bool clampToParent = true;

    [Tooltip("是否在开始拖拽时改变颜色（如果有Image组件）")]
    public bool visualFeedback = true;

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 previousMousePosition;  // 上一帧的鼠标位置
    private Vector2 startPosition;          // 拖拽开始时的物体位置

    // 用于视觉反馈的可选引用
    private UnityEngine.UI.Image imageComponent;
    private Color originalColor;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        
        imageComponent = GetComponent<UnityEngine.UI.Image>();
        if (imageComponent != null)
        {
            originalColor = imageComponent.color;
        }

        if (canvas == null)
        {
            Debug.LogError("DraggableRectTransform: 找不到Canvas，请确保对象在Canvas下。");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 记录开始拖拽时的鼠标位置（屏幕坐标）
        previousMousePosition = eventData.position;
        
        // 记录开始拖拽时的物体位置（世界坐标或本地坐标，这里用世界坐标方便计算）
        startPosition = rectTransform.position;

        // 视觉反馈
        if (visualFeedback && imageComponent != null)
        {
            imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.7f);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas == null) return;

        // 计算鼠标在屏幕上的移动量（像素）
        Vector2 mouseDelta = eventData.position - previousMousePosition;
        
        // 更新上一帧鼠标位置
        previousMousePosition = eventData.position;

        // 将鼠标移动量从屏幕坐标转换为世界坐标（或UI坐标）
        // 使用Canvas的RectTransform来计算缩放比例
        RectTransform canvasRect = canvas.transform as RectTransform;
        Vector2 worldDelta;
        
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            // Screen Space Overlay模式下，屏幕像素直接对应UI单位
            worldDelta = mouseDelta;
        }
        else
        {
            // 其他模式（Camera或World Space），需要根据Canvas的缩放进行转换
            // 获取Canvas的缩放比例
            float canvasScale = canvasRect.localScale.x;
            worldDelta = mouseDelta / canvasScale;
        }

        // 应用移动（世界坐标）
        Vector3 newPosition = rectTransform.position + (Vector3)worldDelta;
        
        // 如果启用边界限制，先计算限制后的位置
        if (clampToParent)
        {
            newPosition = ClampPositionToParent(newPosition);
        }
        
        // 应用新位置
        rectTransform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 恢复视觉反馈
        if (visualFeedback && imageComponent != null)
        {
            imageComponent.color = originalColor;
        }
    }

    /// <summary>
    /// 限制位置在父RectTransform范围内
    /// </summary>
    private Vector3 ClampPositionToParent(Vector3 targetPosition)
    {
        RectTransform parent = rectTransform.parent as RectTransform;
        if (parent == null) return targetPosition;

        // 获取父Rect的边界（世界坐标）
        Vector3[] parentCorners = new Vector3[4];
        parent.GetWorldCorners(parentCorners);
        Vector3 parentMin = parentCorners[0];
        Vector3 parentMax = parentCorners[2];

        // 获取子Rect的边界（世界坐标）
        Vector3[] childCorners = new Vector3[4];
        rectTransform.GetWorldCorners(childCorners);

        // 计算子物体的半尺寸（世界坐标）
        Vector3 childHalfSize = (childCorners[2] - childCorners[0]) * 0.5f;
        
        // 计算限制范围（世界坐标），使子物体完全在父物体内
        float minX = parentMin.x + childHalfSize.x;
        float maxX = parentMax.x - childHalfSize.x;
        float minY = parentMin.y + childHalfSize.y;
        float maxY = parentMax.y - childHalfSize.y;

        // 如果父物体比子物体小，则居中
        if (minX > maxX)
        {
            float centerX = (parentMin.x + parentMax.x) * 0.5f;
            minX = centerX - childHalfSize.x;
            maxX = centerX + childHalfSize.x;
        }
        if (minY > maxY)
        {
            float centerY = (parentMin.y + parentMax.y) * 0.5f;
            minY = centerY - childHalfSize.y;
            maxY = centerY + childHalfSize.y;
        }

        // 限制目标位置
        Vector3 clampedPos = targetPosition;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
        clampedPos.y = Mathf.Clamp(clampedPos.y, minY, maxY);
        
        return clampedPos;
    }

    /// <summary>
    /// 获取当前拖拽状态（供外部查询）
    /// </summary>
    public bool IsDragging { get; private set; }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        IsDragging = true;
        OnDrag(eventData);
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        IsDragging = true;
        OnBeginDrag(eventData);
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        IsDragging = false;
        OnEndDrag(eventData);
    }

#if UNITY_EDITOR
    // 编辑器下调试：绘制拖拽范围
    void OnDrawGizmosSelected()
    {
        if (clampToParent && rectTransform != null && rectTransform.parent != null)
        {
            RectTransform parent = rectTransform.parent as RectTransform;
            if (parent != null)
            {
                Gizmos.color = new Color(0, 1, 0, 0.3f);
                Vector3[] corners = new Vector3[4];
                parent.GetWorldCorners(corners);
                for (int i = 0; i < 4; i++)
                {
                    Gizmos.DrawLine(corners[i], corners[(i + 1) % 4]);
                }
            }
        }
    }
#endif
}