using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 无暇弹窗Image : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject 弹窗;
    public void OnPointerEnter(PointerEventData eventData)
    {
        弹窗.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        弹窗.gameObject.SetActive(false);
    }
}
