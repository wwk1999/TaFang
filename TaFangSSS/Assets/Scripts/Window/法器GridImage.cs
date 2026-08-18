using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class 法器GridImage : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
   [Header("弹窗设置")]
    [Tooltip("弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string popupPrefabPath = "Prefabs/Window/法器信息弹窗";
    
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
    public 法器Grid 法器Grid;
    
     private void Start()
    {
        targetCanvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ObserverModuleManager.S.SendEvent("显示确认分解弹窗",分解类型.法器,法器Grid.法器);
        }
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
        
        // 加载弹窗预制体
        GameObject popupPrefab = Resources.Load<GameObject>(popupPrefabPath);
        // 在Canvas下创建弹窗
        currentPopup = Instantiate(popupPrefab, targetCanvas.transform);
        // 防止弹窗拦截射线导致OnPointerEnter/Exit反复触发
        CanvasGroup cg = currentPopup.GetComponent<CanvasGroup>();
        if (cg == null) cg = currentPopup.AddComponent<CanvasGroup>();
        cg.blocksRaycasts = false;
        法器信息弹窗 弹窗 = currentPopup.GetComponent<法器信息弹窗>();
        弹窗.法器 = 法器Grid.法器;
        弹窗.SetItem();
        // 设置弹窗的位置
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
}
