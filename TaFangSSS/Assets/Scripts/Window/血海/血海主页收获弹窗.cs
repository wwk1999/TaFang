using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 血海主页收获弹窗 : MonoBehaviour
{
    public Button 收获Button;
    public GameObject content;

    public void 刷新主页血海收获弹窗(object[] obj)
    {
        foreach (Transform item in content.transform)
        {
            var 秘境item = item.gameObject.GetComponent<主页秘境item>();
            if (秘境item == null) continue;
            item.gameObject.SetActive(false);
            QueueController.S.主页秘境itemQueue.Enqueue(秘境item);
        }

        var list = PlayerData.S.获取血海所有道具();
        foreach (var item in list)
        {
            主页秘境item 秘境item = null;
            while (QueueController.S.主页秘境itemQueue.Count > 0)
            {
                var dequeued = QueueController.S.主页秘境itemQueue.Dequeue();
                if (dequeued != null)
                {
                    秘境item = dequeued;
                    break;
                }
            }
            if (秘境item == null)
            {
                秘境item = Instantiate(Resources.Load("Prefabs/Window/主页秘境item")).GetComponent<主页秘境item>();
            }
            秘境item.transform.SetParent(content.transform);
            秘境item.quality = item.Key.quality;
            秘境item.sprite = ResourcesConfig.Get道纹Sprite(item.Key.道纹Type,item.Key.quality);
            秘境item.count=item.Value;
            秘境item.name=道纹config.道纹名Dic[item.Key.道纹Type];
            秘境item.SetItem();
            秘境item.gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新主页血海收获弹窗",刷新主页血海收获弹窗);
    }

    private void OnEnable()
    {
        ObserverModuleManager.S.RegisterEvent("刷新主页血海收获弹窗",刷新主页血海收获弹窗);
        收获Button.onClick.RemoveAllListeners();
        收获Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.StartCoroutine(PlayerData.S.收获血海());
            刷新主页血海收获弹窗(null);
            gameObject.SetActive(false);
        });
        刷新主页血海收获弹窗(null);
    }
}