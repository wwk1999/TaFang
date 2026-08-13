using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 功法选择item : MonoBehaviour
{
    public Button bg;
    public TextMeshProUGUI count;
    public Image icon;
    [NonSerialized] public 功法Type 功法Type;
    public TextMeshProUGUI name;
    public GameObject gou;
    public void SetItem()
    {
        gou.SetActive(false);
        name.text = 功法Config.功法名Dic[功法Type];
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        count.text=PlayerData.S.功法数量Dic[功法Type].ToString();
        icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
    }

    public void 功法选择(object[] obj)
    {
        功法Type type=(功法Type)obj[0];
        gou.SetActive(功法Type==type);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("功法选择",功法选择);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("功法选择",功法选择);
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前选择功法 = 功法Type;
            ObserverModuleManager.S.SendEvent("功法选择",功法Type);
        });
    }
}
