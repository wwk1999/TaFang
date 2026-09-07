using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI隐藏工具 : MonoBehaviour, IPointerClickHandler
{
    [Header("要控制的GameObject")]
    public GameObject targetObject; // 在Inspector中拖入你要隐藏的GameObject

    void Start()
    {
        // 可选：确保Image有Raycast Target勾选，否则无法响应点击
        if (TryGetComponent<Image>(out Image img))
        {
            img.raycastTarget = true;
        }
    }

    // 当点击到这个Image时触发
    public void OnPointerClick(PointerEventData eventData)
    {
        // 点击到Image本身，不做隐藏（或你可以选择其他逻辑）
        Debug.Log("点击到了Image本身");
        // 例如你可以让目标显示
        if (targetObject != null)
            targetObject.SetActive(true);
    }

    void Update()
    {
        // 鼠标左键按下时检测
        if (Input.GetMouseButtonDown(0))
        {
            // 检查是否点击在UI上
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // 点击在非UI区域，隐藏目标
                if (targetObject != null)
                {
                    targetObject.SetActive(false);
                    Debug.Log("点击在UI外，隐藏目标");
                }
            }
            else
            {
                // 点击在UI上，但不一定是这个Image
                // 通过Raycast检测是否点击到了本Image
                PointerEventData pointerData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                };

                var results = new System.Collections.Generic.List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerData, results);

                bool hitThisImage = false;
                foreach (var result in results)
                {
                    if (result.gameObject == gameObject)
                    {
                        hitThisImage = true;
                        break;
                    }
                }

                // 如果点击在UI上但没有点中这个Image，则隐藏目标
                if (!hitThisImage && targetObject != null)
                {
                    targetObject.SetActive(false);
                    Debug.Log("点击了其他UI，隐藏目标");
                }
            }
        }
    }
}