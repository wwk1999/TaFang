using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 丹方品质item : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public void OnPointerEnter(PointerEventData eventData)
    {
        bg.image.enabled = true;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        bg.image.enabled = false;
    }

    private void OnEnable()
    {
        SetItem();
        Canvas.ForceUpdateCanvases();
    }

    public void SetItem()
    {
        bg.image.enabled = false;
    }
}
