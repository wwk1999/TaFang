using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 符文融合itemImage : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [Header("弹窗设置")]
    [Tooltip("弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string popupPrefabPath = "Prefabs/Window/符文之地/符文信息弹窗";
    
    [Tooltip("弹窗偏移量（相对于鼠标位置）")]
    [SerializeField] private Vector2 popupOffset = new Vector2(0, 0);
    
    [Tooltip("是否在鼠标移出时立即销毁")]
    [SerializeField] private bool destroyOnExit = true;
    // 当前显示的弹窗实例
    private GameObject currentPopup;
    // 弹窗所在的Canvas
    private Canvas targetCanvas;
    // 鼠标是否在当前Image内
    private bool isHovering = false;
    public 符文融合item 符文融合item;
    
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
        // 如果已经有弹窗，先销毁
        if (currentPopup != null)
        {
            DestroyPopup();
        }

        var 符文 = 符文融合item.符文;
        if (符文 == null) return;

        if (符文.融合)
        {
            GameObject popupPrefab = Resources.Load<GameObject>("Prefabs/Window/符文之地/符文融合信息弹窗");
            if (popupPrefab == null) { Debug.LogError("符文融合信息弹窗预制体不存在"); return; }
            currentPopup = Instantiate(popupPrefab, targetCanvas.transform);
            符文融合信息弹窗 弹窗 = currentPopup.GetComponent<符文融合信息弹窗>();
            弹窗.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            弹窗.符文 = 符文;
            弹窗.SetItem();
        }
        else
        {
            GameObject popupPrefab = Resources.Load<GameObject>(popupPrefabPath);
            if (popupPrefab == null) { Debug.LogError("符文信息弹窗预制体不存在: " + popupPrefabPath); return; }
            currentPopup = Instantiate(popupPrefab, targetCanvas.transform);
            符文信息弹窗 弹窗 = currentPopup.GetComponent<符文信息弹窗>();
            弹窗.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            弹窗.符文 = 符文;
            弹窗.SetItem();
        }
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
        
        // 将鼠标位置转换为Canvas本地坐标
        Vector2 localPoint;
        RectTransform canvasRect = targetCanvas.GetComponent<RectTransform>();

        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                mousePosition + popupOffset,
                targetCanvas.worldCamera,
                out localPoint))
        {
            // 如果转换失败，使用屏幕坐标直接设置
            rectTransform.position = mousePosition + popupOffset;
        }
        else
        {
            rectTransform.localPosition = localPoint;
        }
    }
}
