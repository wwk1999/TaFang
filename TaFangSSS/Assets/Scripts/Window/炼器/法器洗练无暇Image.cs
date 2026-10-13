using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 法器洗练无暇Image : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject 弹窗;
    public void OnPointerEnter(PointerEventData eventData)
    {
        弹窗.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        弹窗.SetActive(false);
    }
}
