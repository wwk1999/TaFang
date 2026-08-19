using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

public class 遗迹掉落ItemImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [Header("弹窗设置")]
    [Tooltip("弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string popupPrefabPath = "Prefabs/Window/远古遗迹/遗迹掉落信息弹窗";
    
    [Tooltip("弹窗偏移量（相对于鼠标位置）")]
    [SerializeField] private Vector2 popupOffset = new Vector2(0, 0);
    
    [Tooltip("是否在鼠标移出时立即销毁")]
    [SerializeField] private bool destroyOnExit = true;

    public 遗迹掉落Item 遗迹掉落Item;
    // 当前显示的弹窗实例
    private GameObject currentPopup;
    // 弹窗所在的Canvas
    private Canvas targetCanvas;
    // 鼠标是否在当前Image内
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
    
    /// <summary>
    /// 显示弹窗
    /// </summary>
    private void ShowPopup(Vector2 mousePosition)
    {
        // 如果已经有弹窗，先销毁
        if (currentPopup != null)
        {
            DestroyPopup();
        }
        
        // 加载弹窗预制体
        GameObject popupPrefab = Resources.Load<GameObject>(popupPrefabPath);
        // 在Canvas下创建弹窗
        currentPopup = Instantiate(popupPrefab, targetCanvas.transform);
        遗迹掉落信息弹窗 弹窗 = currentPopup.GetComponent<遗迹掉落信息弹窗>();
        弹窗.type = PropConfig.PropTypeTo道具信息[遗迹掉落Item.PropType];
        弹窗.神物Type = 遗迹掉落Item.神物Type;
        弹窗.SetItem();
        // 设置弹窗的位置
        UpdatePopupPosition(mousePosition);
        currentPopup.transform.SetAsLastSibling();
    }
    
    /// <summary>
    /// 更新弹窗位置
    /// </summary>
    private void UpdatePopupPosition(Vector2 mousePosition)
    {
        if (currentPopup == null) return;
        
        RectTransform rectTransform = currentPopup.GetComponent<RectTransform>();
        if (rectTransform == null) return;
        
        // 将鼠标位置转换为Canvas本地坐标
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
            // 如果转换失败，使用屏幕坐标直接设置
            rectTransform.position = mousePosition + popupOffset;
        }
    }
    
    /// <summary>
    /// 销毁弹窗
    /// </summary>
    private void DestroyPopup()
    {
        if (currentPopup != null)
        {
            Destroy(currentPopup);
            currentPopup = null;
        }
    }
    
    /// <summary>
    /// 在组件被禁用时销毁弹窗
    /// </summary>
    private void OnDisable()
    {
        DestroyPopup();
    }
    
    /// <summary>
    /// 在对象被销毁时清理弹窗
    /// </summary>
    private void OnDestroy()
    {
        DestroyPopup();
    }
}
