using UnityEngine;
using UnityEngine.EventSystems;

public class FullEventDebug : MonoBehaviour, 
    IPointerUpHandler, 
    IPointerDownHandler, 
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IScrollHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.LogError($"✅ OnPointerUp - {gameObject.name}");
        Debug.LogError("1111");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.LogError($"⏬ OnPointerDown - {gameObject.name}");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.LogError($"🖱️ OnPointerClick - {gameObject.name}");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.LogError($"⬆️ OnPointerEnter - {gameObject.name}");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.LogError($"⬇️ OnPointerExit - {gameObject.name}");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.LogError($"↗️ OnBeginDrag - {gameObject.name}");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 不打印避免刷屏
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.LogError($"↘️ OnEndDrag - {gameObject.name}");
    }

    public void OnScroll(PointerEventData eventData)
    {
        Debug.LogError($"🔄 OnScroll - {gameObject.name}");
    }

    void Start()
    {
        Debug.LogError($"脚本已挂载到 {gameObject.name}");
    }
}