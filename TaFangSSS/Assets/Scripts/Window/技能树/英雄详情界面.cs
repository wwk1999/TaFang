using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum 英雄详情界面显示类型
{
    None,
    法器,
    功法,
    境界,
}
public class 英雄详情界面 : MonoBehaviour
{
    public GameObject 英雄列表content;
    public Button 境界Button;
    public Button 功法Button;
    public Button 法器Button;
    
    public Button 境界亮Button;
    public Button 功法亮Button;
    public Button 法器亮Button;
    
    public Button 重置Button;
    public Button 提升境界Button;
    public Button 退出Button;

    public GameObject 技能Content;
    private HeroType 当前heroType=HeroType.丹童;
    private 英雄详情界面显示类型 显示类型 = 英雄详情界面显示类型.境界;

    public void 设置Button()
    {
        switch (显示类型)
        {
            case 英雄详情界面显示类型.境界:
                境界亮Button.gameObject.SetActive(true);
                境界Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                法器亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.功法:
                功法亮Button.gameObject.SetActive(true);
                功法Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                法器亮Button.gameObject.SetActive(false);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.法器:
                法器亮Button.gameObject.SetActive(true);
                法器Button.gameObject.SetActive(false);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                break;
        }
    }
    public void 刷新界面()
    {
        switch (显示类型)
        {
            case 英雄详情界面显示类型.境界:
                设置Button();
                Show技能面板();
                break;
        }
    }

    private void OnEnable()
    {
        刷新界面();
    }

    public void Show技能面板()
    {
        foreach (Transform item in 技能Content.transform)
        {
            Destroy(item.gameObject);
            for (int i = 1; i <= 5; i++)
            {
                var 技能树行item = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树行item"), 技能Content.transform)
                    .GetComponent<技能树行item>();
                技能树行item.行 = i;
                技能树行item.HeroType = 当前heroType;
                技能树行item.SetItem();
            }
        }
    }
}
