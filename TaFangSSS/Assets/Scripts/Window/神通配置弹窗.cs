using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 神通配置弹窗 : MonoBehaviour
{
    public GameObject 神通Content;
    public GameObject 英雄contnt;
    public Button 添加Button;
    public Button 删除Button;
    public Button ExitButton;
    public Button maskButton;

    public void 刷新神通列表()
    {
        foreach (Transform item in 神通Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in PlayerData.S.神通配置List)
        {
            var 神通item = Instantiate(Resources.Load("Prefabs/Window/神通配置item"), 神通Content.transform)
                .GetComponent<神通配置item>();
            神通item.HeroType = item;
            神通item.SetItem();
        }
    }

    public void 刷新英雄列表()
    {
        foreach (Transform item in 英雄contnt.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队 - 1])
        {
            if(item==HeroType.None) continue;
            var 神通item = Instantiate(Resources.Load("Prefabs/Window/神通配置英雄item"), 英雄contnt.transform)
                .GetComponent<神通配置英雄item>();
            神通item.HeroType = item;
            神通item.SetItem();
        }
    }
    private void OnEnable()
    {
        foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队 - 1])
        {
            if (item != HeroType.None)
            {
                HeroWindowController.S.当前神通配置选择英雄 = item;
                break;
            }
        }
        刷新英雄列表();
        刷新神通列表();
        ObserverModuleManager.S.SendEvent("神通配置item点击",HeroWindowController.S.当前神通配置选择英雄);
    }

    private void Start()
    {
        添加Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前神通配置选择英雄 == HeroType.None)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择英雄");
                return;
            }
            PlayerData.S.神通配置List.Add(HeroWindowController.S.当前神通配置选择英雄);
            刷新神通列表();
            if (PlayerData.S.是否首次配置神通)
            {
                ObserverModuleManager.S.SendEvent("新手引导添加神通");
            }
        });
        删除Button.onClick.AddListener(() =>
        {
            if (PlayerData.S.神通配置List.Count > 0)
            {
                PlayerData.S.神通配置List.RemoveAt( PlayerData.S.神通配置List.Count-1);
                刷新神通列表();
            }
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            if (PlayerData.S.是否首次配置神通)
            {
                ObserverModuleManager.S.SendEvent("退出神通配置");
                PlayerData.S.是否首次配置神通 = false;
            }
        });
    }
}
