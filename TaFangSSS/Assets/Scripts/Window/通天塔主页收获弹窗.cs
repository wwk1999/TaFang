using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 通天塔主页收获弹窗 : MonoBehaviour
{
    public Button 收获Button;
    public GameObject content;

    public void 刷新主页通天塔收获弹窗(object[] obj)
    {
        foreach (Transform item in content.transform)
        {
            var 秘境item = item.gameObject.GetComponent<主页秘境item>();
            if (秘境item == null) continue;
            item.gameObject.SetActive(false);
            QueueController.S.主页秘境itemQueue.Enqueue(秘境item);
        }

        var list = PlayerData.S.获取通天塔所有道具();
        foreach (var item in list)
        {
            var 秘境item = QueueController.S.主页秘境itemQueue.Count > 0
                ? QueueController.S.主页秘境itemQueue.Dequeue()
                : Instantiate(Resources.Load("Prefabs/Window/主页秘境item")).GetComponent<主页秘境item>();
            秘境item.transform.SetParent(content.transform);
            秘境item.quality = 城墙Config.城墙道具QualityDic[item.Key];
            秘境item.sprite = ResourcesConfig.Get城墙Sprite(item.Key);
            秘境item.count=item.Value;
            秘境item.name=城墙Config.城墙道具名Dic[item.Key];
            秘境item.SetItem();
            秘境item.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新主页通天塔收获弹窗",刷新主页通天塔收获弹窗);
    }

    private void OnEnable()
    {
        ObserverModuleManager.S.RegisterEvent("刷新主页通天塔收获弹窗",刷新主页通天塔收获弹窗);
        收获Button.onClick.RemoveAllListeners();
        收获Button.onClick.AddListener(() =>
        {
            PlayerData.S.收获通天塔();
            刷新主页通天塔收获弹窗(null);
        });
        刷新主页通天塔收获弹窗(null);
    }
}
