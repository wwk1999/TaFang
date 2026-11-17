using UnityEngine;
using UnityEngine.EventSystems;

// 背包格子上悬浮显示信息弹窗的通用逻辑，子类只需提供弹窗路径和数据
public abstract class GridImageBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [SerializeField] private string popupPrefabPath;
    [SerializeField] private Vector2 popupOffset = Vector2.zero;

    private GameObject currentPopup;
    private Canvas targetCanvas;
    private bool isHovering;

    protected abstract string 默认弹窗路径 { get; }
    protected virtual bool 可显示 { get { return true; } }
    protected abstract void 设置弹窗(GameObject 弹窗对象);
    protected virtual void 右键点击() { }

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
        DestroyPopup();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (isHovering && currentPopup != null)
        {
            UpdatePopupPosition(eventData.position);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            右键点击();
        }
    }

    private void ShowPopup(Vector2 mousePosition)
    {
        DestroyPopup();
        if (!可显示) return;

        string path = string.IsNullOrEmpty(popupPrefabPath) ? 默认弹窗路径 : popupPrefabPath;
        GameObject popupPrefab = Resources.Load<GameObject>(path);
        if (popupPrefab == null) return;

        currentPopup = Instantiate(popupPrefab, targetCanvas.transform);
        设置弹窗(currentPopup);
        UpdatePopupPosition(mousePosition);
        currentPopup.transform.SetAsLastSibling();
    }

    private void DestroyPopup()
    {
        if (currentPopup != null)
        {
            Destroy(currentPopup);
            currentPopup = null;
        }
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

    private void OnDisable()
    {
        DestroyPopup();
    }

    private void OnDestroy()
    {
        DestroyPopup();
    }
}
