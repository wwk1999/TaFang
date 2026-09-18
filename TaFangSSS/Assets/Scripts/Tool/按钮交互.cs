using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 按钮交互 : MonoBehaviour,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler
{
    public float 按钮进入scale = 1.1f;
    public float 按钮点击scale = 1.2f;
    public Sprite 进入图片;
    public Sprite 离开图片;

    public GameObject 标签暗;
    public GameObject 标签亮;
    public void OnPointerDown(PointerEventData eventData)
    {
        ObserverModuleManager.S.SendEvent("播放音效",音效Type.按钮点击);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(按钮点击scale, 0.1f)).SetEase(Ease.InBack);
        mySequence.Append(transform.DOScale(按钮进入scale, 0.1f)).SetEase(Ease.OutBack);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (进入图片 != null)
        {
            GetComponent<Image>().sprite = 进入图片;
        }

        if (标签暗 != null&&标签亮 != null)
        {
            标签暗.gameObject.SetActive(false);
            标签亮.gameObject.SetActive(true);
        }
        ObserverModuleManager.S.SendEvent("播放音效",音效Type.按钮进入);
        transform.DOScale(按钮进入scale, 0.1f).SetEase(Ease.InBack);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (离开图片 != null)
        {
            GetComponent<Image>().sprite = 离开图片;
        }
        if (标签暗 != null&&标签亮 != null)
        {
            标签暗.gameObject.SetActive(true);
            标签亮.gameObject.SetActive(false);
        }
        transform.DOScale(1f, 0.1f).SetEase(Ease.OutBack);
    }
}
