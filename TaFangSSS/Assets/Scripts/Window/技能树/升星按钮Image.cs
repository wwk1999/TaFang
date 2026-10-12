using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 升星按钮Image : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject 信息弹窗;
    public void OnPointerEnter(PointerEventData eventData)
    {
        信息弹窗.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        信息弹窗.gameObject.SetActive(false);
    }
}