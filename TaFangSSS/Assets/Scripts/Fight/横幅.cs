using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class 横幅 : MonoBehaviour
{
    public void 播放神通横幅(object[] obj)
    {
        HeroType heroType=(HeroType)obj[0];
        var prefab = Resources.Load("Prefabs/Fight/横幅item") as GameObject;
        prefab.SetActive(false);
        var item=Instantiate(prefab,transform).GetComponent<横幅item>();
        item.HeroType = heroType;
        item.transform.SetAsLastSibling();
        prefab.SetActive(true);
        item.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("播放英雄神通",播放神通横幅);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("播放英雄神通",播放神通横幅);
    }
}
