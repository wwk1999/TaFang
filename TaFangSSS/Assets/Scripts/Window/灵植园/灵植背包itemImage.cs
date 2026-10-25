using Config;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 挂在灵植背包item的背景Button上，鼠标悬停时按物品类型弹对应信息弹窗：
/// 种子 → 种子信息弹窗，肥料 → 肥料信息弹窗，作物 → 作物信息弹窗。
/// 弹窗跟随鼠标移动，移开销毁。
/// </summary>
public class 灵植背包itemImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [Header("弹窗设置")]
    [Tooltip("种子弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string 种子弹窗路径 = "Prefabs/Window/灵植园/种子信息弹窗";

    [Tooltip("肥料弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string 肥料弹窗路径 = "Prefabs/Window/灵植园/肥料信息弹窗";

    [Tooltip("作物弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string 作物弹窗路径 = "Prefabs/Window/灵植园/作物信息弹窗";

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
        DestroyPopup();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (isHovering && currentPopup != null)
        {
            UpdatePopupPosition(eventData.position);
        }
    }

    private void ShowPopup(Vector2 mousePosition)
    {
        灵植背包item item = GetComponentInParent<灵植背包item>();
        if (item == null || targetCanvas == null) return;

        DestroyPopup();

        switch (item.物品类型)
        {
            case 灵植背包物品Type.种子:
                if (item.灵植Tyep == 灵植Type.None) return;
                GameObject 种子prefab = Resources.Load<GameObject>(种子弹窗路径);
                if (种子prefab == null) return;
                currentPopup = Instantiate(种子prefab, targetCanvas.transform);
                var 种子弹窗 = currentPopup.GetComponent<种子信息弹窗>();
                种子弹窗.灵植Tyep = item.灵植Tyep;
                种子弹窗.是否变异 = false;
                种子弹窗.是否种子 = true;
                种子弹窗.SetItem();
                break;

            case 灵植背包物品Type.肥料:
                if (item.肥料Tyep == 肥料Type.None) return;
                GameObject 肥料prefab = Resources.Load<GameObject>(肥料弹窗路径);
                if (肥料prefab == null) return;
                currentPopup = Instantiate(肥料prefab, targetCanvas.transform);
                var 肥料弹窗 = currentPopup.GetComponent<肥料信息弹窗>();
                肥料弹窗.肥料Tyep = item.肥料Tyep;
                肥料弹窗.QualityType = item.QualityType;
                肥料弹窗.SetItem();
                break;

            case 灵植背包物品Type.作物:
                if (item.灵植Tyep == 灵植Type.None) return;
                GameObject 作物prefab = Resources.Load<GameObject>(作物弹窗路径);
                if (作物prefab == null) return;
                currentPopup = Instantiate(作物prefab, targetCanvas.transform);
                var 作物弹窗 = currentPopup.GetComponent<作物信息弹窗>();
                作物弹窗.灵植Tyep = item.灵植Tyep;
                作物弹窗.是否变异 = item.是否变异;
                作物弹窗.SetItem();
                break;

            default:
                return;
        }

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

    private void OnDisable()
    {
        isHovering = false;
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

        RectTransform canvasRect = targetCanvas.GetComponent<RectTransform>();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect, mousePosition, targetCanvas.worldCamera, out Vector2 localPoint))
        {
            rectTransform.localPosition = localPoint;
        }
        else
        {
            rectTransform.position = mousePosition;
        }
    }
}
