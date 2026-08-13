using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 功法选择弹窗 : MonoBehaviour
{
    public GameObject content;
    public Button 装备按钮;
    public Button maskbutton;
    [NonSerialized] public HeroType HeroType;

    private void OnEnable()
    {
        HeroWindowController.S.当前选择功法 = 功法Type.None;
        Show();
    }

    public void 隐藏功法选择弹窗(object[] obj)
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("隐藏功法选择弹窗",隐藏功法选择弹窗);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("隐藏功法选择弹窗",隐藏功法选择弹窗);
        maskbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        装备按钮.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前选择功法 == 功法Type.None)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择功法");
                return;
            }
            ObserverModuleManager.S.SendEvent("显示英雄功法确认弹窗",HeroType);
        });
    }

    public void Show()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.功法数量Dic)
        {
            if (item.Value > 0&&功法Config.功法职业Dic[item.Key]==HeroConfig.HeroZhiYeDic[HeroType].zhiYeType)
            {
                var baggrid = Instantiate(Resources.Load("Prefabs/Window/功法选择item"), content.transform).GetComponent<功法选择item>();
                baggrid.功法Type = item.Key;
                baggrid.SetItem();
            }
        }
    }
}
