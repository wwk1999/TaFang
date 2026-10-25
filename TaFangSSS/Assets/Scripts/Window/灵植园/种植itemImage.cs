using Config;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 挂在种植item的背景Button上，鼠标悬停时在鼠标位置弹出种子信息弹窗，跟随鼠标移动，移开销毁。
/// 参考 BagGridImage 实现。
/// </summary>
public class 种植itemImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [Header("弹窗设置")]
    [Tooltip("弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string popupPrefabPath = "Prefabs/Window/灵植园/种子信息弹窗";

    [Tooltip("弹窗偏移量（相对于鼠标位置）")]
    [SerializeField] private Vector2 popupOffset = new Vector2(0, 0);

    [Tooltip("是否在鼠标移出时立即销毁")]
    [SerializeField] private bool destroyOnExit = true;

    private GameObject currentPopup;
    private Canvas targetCanvas;
    private bool isHovering = false;

    private void Start()
    {
        targetCanvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        ShowPopup(eventData.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        if (destroyOnExit)
        {
            DestroyPopup();
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (isHovering && currentPopup != null)
        {
            UpdatePopupPosition(eventData.position);
        }
    }

    private void DestroyPopup()
    {
        if (currentPopup != null)
        {
            Destroy(currentPopup);
            currentPopup = null;
        }
    }

    private void ShowPopup(Vector2 mousePosition)
    {
        种植item item = GetComponentInParent<种植item>();
        if (item == null || item.灵植Tyep == 灵植Type.None) return;

        DestroyPopup();

        GameObject popupPrefab = Resources.Load<GameObject>(popupPrefabPath);
        if (popupPrefab == null) return;

        currentPopup = Instantiate(popupPrefab, targetCanvas.transform);
        种子信息弹窗 弹窗 = currentPopup.GetComponent<种子信息弹窗>();
        弹窗.灵植Tyep = item.灵植Tyep;
        弹窗.是否变异 = false;
        弹窗.是否种子 = true;
        弹窗.SetItem();

        UpdatePopupPosition(mousePosition);
        currentPopup.transform.SetAsLastSibling();
    }

    private void OnDisable()
    {
        DestroyPopup();
    }

    private void OnDestroy()
    {
        DestroyPopup();
    }

    private void UpdatePopupPosition(Vector2 mousePosition)
    {
        if (currentPopup == null) return;

        RectTransform rectTransform = currentPopup.GetComponent<RectTransform>();
        if (rectTransform == null) return;

        Vector2 localPoint;
        RectTransform canvasRect = targetCanvas.GetComponent<RectTransform>();

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                mousePosition + popupOffset,
                targetCanvas.worldCamera,
                out localPoint))
        {
            rectTransform.localPosition = localPoint;
        }
        else
        {
            rectTransform.position = mousePosition + popupOffset;
        }
    }
}
