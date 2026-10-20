using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 灵兽itemImage : MonoBehaviour,IPointerClickHandler
{
    public 灵兽item 灵兽item;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            灵兽item.灵兽.锁 = !灵兽item.灵兽.锁;
            ObserverModuleManager.S.SendEvent("灵兽Item锁");
        }
    }
}
