using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 城墙列表item : MonoBehaviour
{
    [NonSerialized]public 道宝Quality quality;
    public Image bg;
    public TextMeshProUGUI title;
    public GameObject content;
    public ScrollRect  ScrollView;

    public void 锁定列表(object[] obj)
    {
        ScrollView.horizontal=false;
    }
    public void 解锁列表(object[] obj)
    {
        ScrollView.horizontal=true;
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("锁定列表",锁定列表);
        ObserverModuleManager.S.RegisterEvent("解锁列表",解锁列表);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("锁定列表",锁定列表);
        ObserverModuleManager.S.UnRegisterEvent("解锁列表",解锁列表);
    }

    public void SetItem()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        bg.sprite=ResourcesConfig.Get道宝标签Sprite(quality);
        title.text=道宝Config.道宝QualityNameDic[quality];
        List<城墙道具Type> list =城墙Config.城墙道具列表Dic[quality];
        foreach (var item in list)
        {
            var 城墙item = Instantiate(Resources.Load("Prefabs/Window/城墙法宝item"), content.transform)
                .GetComponent<城墙法宝item>();
            城墙item.type = item;
            城墙item.SetItem();
        }
        
        switch (quality)
        {
            case 道宝Quality.混沌至宝:
                title.colorGradientPreset = ResourcesConfig.荒TMP;
                break;
            case 道宝Quality.先天至宝:
                title.colorGradientPreset = ResourcesConfig.洪TMP;
                break;
            case 道宝Quality.功德至宝:
                title.colorGradientPreset = ResourcesConfig.宙TMP;
                break;
            case 道宝Quality.先天灵宝:
                title.colorGradientPreset = ResourcesConfig.宇TMP;
                break;
            case 道宝Quality.后天法宝:
                title.colorGradientPreset = ResourcesConfig.天TMP;
                break;
        }
        
    }
}
