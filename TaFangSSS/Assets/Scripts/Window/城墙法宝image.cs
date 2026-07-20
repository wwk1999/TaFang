using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class 城墙法宝image : MonoBehaviour,IPointerDownHandler
{
    public 城墙法宝item 城墙法宝item;
    private Vector3 MousePos;
    private float 当前时间=0;
    private float 需要时间=0.2f;
    private bool IsSend = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        MousePos=Input.mousePosition;
    }
    IEnumerator DelaySetJiaoHuan()
    {
        yield return null;
        HeroWindowController.S.城墙IsDrag=false;
        HeroWindowController.S.城墙道具Type = 城墙道具Type.None;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ObserverModuleManager.S.SendEvent("解锁列表");
            IsSend = false;
            HeroWindowController.S.城墙IsDrag=false;
            StartCoroutine(DelaySetJiaoHuan());      
        }
        if (Input.GetMouseButton(0)&&Input.mousePosition==MousePos)
        {
            当前时间+=Time.deltaTime;
        }
        else
        {
            当前时间=0;
        }
        if (当前时间 >= 需要时间&& !IsSend)
        {
            ObserverModuleManager.S.SendEvent("锁定列表");
            HeroWindowController.S.城墙IsDrag=true;
            HeroWindowController.S.城墙道具Type = 城墙法宝item.type;
            IsSend = true;
        }
    }
}
