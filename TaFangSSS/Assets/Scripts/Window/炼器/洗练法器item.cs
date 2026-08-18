using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 洗练法器item : MonoBehaviour
{
    [NonSerialized] public 法器 法器 = null;
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public GameObject gou;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器.法器Type]);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
        name.text = 法器Config.法器名Dic[法器.法器Type];
        gou.SetActive(HeroWindowController.S.洗练panel当前法器==法器);
    }
    
    

    private void Start()
    {
        bg.onClick.AddListener(() =>
            {
                HeroWindowController.S.洗练panel当前法器 = 法器;
                ObserverModuleManager.S.SendEvent("洗练法器点击",法器);
            }
        );
    }
}
