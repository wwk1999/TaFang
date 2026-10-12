using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 开始炼制Image : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   public GameObject 炼制提示;
   public void OnPointerEnter(PointerEventData eventData)
   {
      炼制提示.gameObject.SetActive(true);
   }

   public void OnPointerExit(PointerEventData eventData)
   {
      炼制提示.gameObject.SetActive(false);
   }
}
