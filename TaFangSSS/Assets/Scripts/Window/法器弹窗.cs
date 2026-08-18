using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class 法器弹窗 : MonoBehaviour
{
    public 法器选择弹窗 法器选择弹窗;
    public 英雄详情弹窗 英雄详情弹窗;
    public GameObject content;
    [NonSerialized]HeroType HeroType;
    public void 显示法器选择弹窗(object[] obj)
    {
        HeroType HeroType = (HeroType)obj[0];
        法器类型 法器类型=(法器类型)obj[1];
        法器选择弹窗.HeroType=HeroType;
        法器选择弹窗.法器类型 = 法器类型;
        法器选择弹窗.gameObject.SetActive(true);
    }

    public void Show()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        var 武器 = Instantiate(Resources.Load("Prefabs/Window/英雄法器item"), content.transform).GetComponent<英雄法器item>();
        武器.HeroType=HeroType;
        武器.法器类型 = 法器类型.武器;
        武器.SetItem();
        
        var 衣服 = Instantiate(Resources.Load("Prefabs/Window/英雄法器item"), content.transform).GetComponent<英雄法器item>();
        衣服.HeroType=HeroType;
        衣服.法器类型 = 法器类型.衣服;
        衣服.SetItem();
        
        var 头盔 = Instantiate(Resources.Load("Prefabs/Window/英雄法器item"), content.transform).GetComponent<英雄法器item>();
        头盔.HeroType=HeroType;
        头盔.法器类型 = 法器类型.头盔;
        头盔.SetItem();
        
        var 鞋子 = Instantiate(Resources.Load("Prefabs/Window/英雄法器item"), content.transform).GetComponent<英雄法器item>();
        鞋子.HeroType=HeroType;
        鞋子.法器类型 = 法器类型.鞋子;
        鞋子.SetItem();
    }
    private void OnEnable()
    {
        HeroType=英雄详情弹窗.HeroType;
       Show();
    }

    public void 法器装备刷新(object[] obj)
    {
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("法器装备刷新",法器装备刷新);

        ObserverModuleManager.S.UnRegisterEvent("显示法器选择弹窗",显示法器选择弹窗);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("法器装备刷新",法器装备刷新);
        ObserverModuleManager.S.RegisterEvent("显示法器选择弹窗",显示法器选择弹窗);
    }
}
