using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 灵植商店itemImage : MonoBehaviour,IPointerClickHandler
{
    public 灵植商店item 灵植商店item;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            float count = 0;
        }
    }
}
