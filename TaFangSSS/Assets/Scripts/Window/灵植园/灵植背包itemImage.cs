using Config;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 挂在灵植背包item的背景Button上，鼠标悬停时按物品类型弹对应信息弹窗：
/// 种子 → 种子信息弹窗，肥料 → 肥料信息弹窗，作物 → 作物信息弹窗。
/// 弹窗跟随鼠标移动，移开销毁。
/// </summary>
public class 灵植背包itemImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerClickHandler
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

    /// <summary>
    /// 右键点击作物：服用 1 个；按住 Shift 右键：服用 min(持有数量, 剩余可服用次数) 个
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;

        灵植背包item item = GetComponentInParent<灵植背包item>();
        if (item == null || item.物品类型 != 灵植背包物品Type.作物) return;
        if (item.灵植Tyep == 灵植Type.None) return;

        var 次数Dic = item.是否变异 ? PlayerData.S.变异服用次数Dic : PlayerData.S.普通服用次数Dic;
        var 收获Dic = item.是否变异 ? PlayerData.S.变异收获Dic : PlayerData.S.普通收获Dic;
        int 已服用 = 次数Dic != null && 次数Dic.TryGetValue(item.灵植Tyep, out int c) ? c : 0;
        int 剩余可服用 = 灵植园Config.最大服用次数 - 已服用;
        float 持有数量 = 收获Dic != null && 收获Dic.TryGetValue(item.灵植Tyep, out float n) ? n : 0;

        if (剩余可服用 <= 0)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达最大服用次数");
            return;
        }
        if (持有数量 <= 0)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "数量不足");
            return;
        }

        bool 批量 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        int 服用数量 = 批量 ? (int)Mathf.Min(持有数量, 剩余可服用) : 1;

        int 成功数量 = 0;
        for (int i = 0; i < 服用数量; i++)
        {
            if (PlayerData.S.服用灵植(item.灵植Tyep, item.是否变异)) 成功数量++;
            else break;
        }
        if (成功数量 <= 0) return;

        string 物品名 = (item.是否变异 ? "变异·" : "") + 灵植园Config.灵植名[item.灵植Tyep];
        string 数量后缀 = 成功数量 > 1 ? $" X{成功数量}" : "";
        ObserverModuleManager.S.SendEvent("SendUIToast", $"服用成功：{物品名}{数量后缀}");

        // 服用后数量/次数都变了，关掉悬停弹窗并刷新背包
        DestroyPopup();
        var 窗口 = GetComponentInParent<灵植背包窗口>();
        if (窗口 != null) 窗口.Show背包();
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
