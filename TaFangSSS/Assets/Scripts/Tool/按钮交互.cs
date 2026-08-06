using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class 按钮交互 : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ObserverModuleManager.S.SendEvent("播放音效",音效Type.按钮点击);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(1.3f, 0.1f)).SetEase(Ease.InBack);
        mySequence.Append(transform.DOScale(1.2f, 0.1f)).SetEase(Ease.OutBack);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ObserverModuleManager.S.SendEvent("播放音效",音效Type.按钮进入);
        transform.DOScale(1.2f, 0.1f).SetEase(Ease.InBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.1f).SetEase(Ease.OutBack);
    }
}
