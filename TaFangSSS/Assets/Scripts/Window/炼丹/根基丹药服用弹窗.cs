using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 根基丹药服用弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button exitButton;
    public Button 服用Button;
    public GameObject content;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized]public QualityType QualityType;

    private void Start()
    {
        服用Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.服用根基丹药英雄 == HeroType.None)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择英雄");
                return;
            }
            PlayerData.S.Set英雄根基丹药服用(HeroWindowController.S.服用根基丹药英雄,丹药Type,QualityType,PlayerData.S.Get英雄根基丹药服用(HeroWindowController.S.服用根基丹药英雄,丹药Type,QualityType)+1);
            PlayerData.S.Set丹药数量(丹药Type,QualityType,PlayerData.S.Get丹药数量(丹药Type,QualityType)-1);
            ObserverModuleManager.S.SendEvent("刷新背包");
            ObserverModuleManager.S.SendEvent("SendUIToast","服用丹药成功");
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        HeroWindowController.S.服用根基丹药英雄 = HeroType.None;
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in HeroConfig.HeroNameDic)
        {
            if (丹药Config.丹药元素类型Dic[丹药Type] == YuanSuType.None)
            {
                if (PlayerData.S.Get英雄根基丹药服用(item.Key, 丹药Type, QualityType) < 5)
                {
                    var 英雄item=Instantiate(Resources.Load("Prefabs/Window/炼丹界面/服用根基丹药英雄item"),content.transform).GetComponent<服用根基丹药英雄item>();
                    英雄item.HeroType = item.Key;
                    英雄item.SetItem();
                }
            }
            else
            {
                if (HeroConfig.HeroZhiYeDic[item.Key].yuanSuType == 丹药Config.丹药元素类型Dic[丹药Type] &&
                    PlayerData.S.Get英雄根基丹药服用(item.Key, 丹药Type, QualityType) < 5)
                {
                    var 英雄item=Instantiate(Resources.Load("Prefabs/Window/炼丹界面/服用根基丹药英雄item"),content.transform).GetComponent<服用根基丹药英雄item>();
                    英雄item.HeroType = item.Key;
                    英雄item.SetItem();
                }
            }
        }
    }
}
