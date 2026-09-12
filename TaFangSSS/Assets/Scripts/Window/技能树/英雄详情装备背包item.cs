using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 英雄详情装备背包item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public GameObject gou;
    [NonSerialized] public 法器 法器;

    public void SetItem()
    {
        gou.SetActive(false);
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器.法器Type]);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
    }

    public void 英雄详情界面装备点击(object[] obj)
    {
        法器 item = obj[0] as 法器;
        gou.SetActive(法器==item);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("英雄详情界面装备点击",英雄详情界面装备点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("英雄详情界面装备点击",英雄详情界面装备点击);
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.英雄详情界面当前选择法器 = 法器;
            ObserverModuleManager.S.SendEvent("英雄详情界面装备点击",法器);
        });
    }
}
