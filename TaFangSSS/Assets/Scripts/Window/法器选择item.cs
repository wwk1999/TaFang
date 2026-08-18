using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器选择item : MonoBehaviour
{
    [NonSerialized] public 法器 法器;
    public Button bg;
    public Image icon;
    public GameObject gou;
    public TextMeshProUGUI name;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器.法器Type]);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
        gou.SetActive(false);
        name.text = 法器Config.法器名Dic[法器.法器Type];
    }

    public void 法器选择Item点击(object[] obj)
    {
        法器 i = obj[0] as 法器;
        gou.SetActive(i==法器);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("法器选择Item点击",法器选择Item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("法器选择Item点击",法器选择Item点击);
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("法器选择Item点击",法器);
        });
    }
}
