using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;

public class 灵植商店itemImage : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public 灵植商店item 灵植商店item;

    [Header("弹窗设置")]
    [Tooltip("种子弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string 种子弹窗路径 = "Prefabs/Window/灵植园/种子信息弹窗";

    [Tooltip("肥料弹窗预制体路径（相对于Resources文件夹）")]
    [SerializeField] private string 肥料弹窗路径 = "Prefabs/Window/灵植园/肥料信息弹窗";

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
        if (灵植商店item == null || targetCanvas == null) return;

        DestroyPopup();

        if (灵植商店item.灵植Type != 灵植Type.None)
        {
            GameObject prefab = Resources.Load<GameObject>(种子弹窗路径);
            if (prefab == null) return;
            currentPopup = Instantiate(prefab, targetCanvas.transform);
            var 弹窗 = currentPopup.GetComponent<种子信息弹窗>();
            弹窗.灵植Tyep = 灵植商店item.灵植Type;
            弹窗.是否变异 = false;
            弹窗.是否种子 = true;
            弹窗.SetItem();
        }
        else if (灵植商店item.肥料Type != 肥料Type.None)
        {
            GameObject prefab = Resources.Load<GameObject>(肥料弹窗路径);
            if (prefab == null) return;
            currentPopup = Instantiate(prefab, targetCanvas.transform);
            var 弹窗 = currentPopup.GetComponent<肥料信息弹窗>();
            弹窗.肥料Tyep = 灵植商店item.肥料Type;
            弹窗.QualityType = 灵植商店item.quality;
            弹窗.SetItem();
        }
        else
        {
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right) return;
        if (灵植商店item == null) return;

        float 价格;
        if (灵植商店item.灵植Type != 灵植Type.None)
        {
            价格 = 灵植园Config.灵植价格Dic[灵植商店item.灵植Type];
        }
        else if (灵植商店item.肥料Type != 肥料Type.None)
        {
            价格 = 灵植园Config.Get肥料价格(灵植商店item.肥料Type, 灵植商店item.quality);
        }
        else
        {
            return;
        }

        // 按住 Shift 一次购买 10 个，否则 1 个
        int 数量 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 10 : 1;
        float 总价 = 价格 * 数量;
        if (PlayerData.S.青石 < 总价)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "青石不足");
            return;
        }

        PlayerData.S.青石 -= 总价;
        ObserverModuleManager.S.SendEvent("Set青石");

        string 物品名;
        if (灵植商店item.灵植Type != 灵植Type.None)
        {
            PlayerData.S.种子Dic[灵植商店item.灵植Type] += 数量;
            物品名 = 灵植园Config.灵植名[灵植商店item.灵植Type];
        }
        else
        {
            var 肥料数量 = PlayerData.S.Get肥料数量(灵植商店item.肥料Type, 灵植商店item.quality);
            PlayerData.S.Set肥料数量(灵植商店item.肥料Type, 灵植商店item.quality, 肥料数量 + 数量);
            物品名 = PropConfig.QualityNameDic[灵植商店item.quality] + 灵植园Config.肥料名[灵植商店item.肥料Type];
        }

        string 数量后缀 = 数量 > 1 ? $" X{数量}" : "";
        ObserverModuleManager.S.SendEvent("SendUIToast", $"购买成功：{物品名}{数量后缀}");
    }
}
