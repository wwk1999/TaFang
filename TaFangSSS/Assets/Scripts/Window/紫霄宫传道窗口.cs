using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 紫霄宫传道窗口 : MonoBehaviour
{
    public TextMeshProUGUI 传道次数;
    public Button exitButton;
    public GameObject Content;
    public Button 查看按钮;
    public GameObject 概率弹窗;
    public Toggle 消耗传道次数Toggle;
    public Toggle 传道所有Toggle;

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新传道界面",刷新传道界面);
    }

    public void 刷新传道界面(object[] obj)
    {
        消耗传道次数Toggle.isOn = PlayerData.S.消耗传道次数;
        传道次数.text = PlayerData.S.剩余传道次数.ToString();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新传道界面",刷新传道界面);
        概率弹窗.gameObject.SetActive(false);
        查看按钮.onClick.AddListener(() =>
        {
            概率弹窗.gameObject.SetActive(true);
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        消耗传道次数Toggle.onValueChanged.AddListener(delegate
        {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
            PlayerData.S.消耗传道次数 = 消耗传道次数Toggle.isOn;
            Show();
        });    
        传道所有Toggle.onValueChanged.AddListener(delegate
        {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
            PlayerData.S.传道所有 = 传道所有Toggle.isOn;
        }); 
    }

   

    private void OnEnable()
    {
        消耗传道次数Toggle.isOn = PlayerData.S.消耗传道次数;
        传道所有Toggle.isOn = PlayerData.S.传道所有;

        Show();
    }

    public void Show()
    {
        传道次数.text = PlayerData.S.剩余传道次数.ToString();
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PropConfig.QualityNameDic)
        {
            var 传道item = Instantiate(Resources.Load("Prefabs/Window/传道item"), Content.transform).GetComponent<传道item>();
            传道item.qualityType = item.Key;
            传道item.SetItem();
        }
    }
}
