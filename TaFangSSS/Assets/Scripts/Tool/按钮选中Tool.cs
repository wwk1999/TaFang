using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 按钮选中Tool : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private GameObject 暗;
    private GameObject 亮;

    private void Awake()
    {
        暗 = gameObject.transform.Find("暗").gameObject;
        亮 = gameObject.transform.Find("亮").gameObject;
        亮.gameObject.SetActive(false);
        暗.gameObject.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        暗.gameObject.SetActive(false);
        亮.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        亮.gameObject.SetActive(false);
        暗.gameObject.SetActive(true);
    }
}
