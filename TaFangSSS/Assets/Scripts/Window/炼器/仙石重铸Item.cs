using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙石重铸Item : MonoBehaviour
{
    [NonSerialized] public 仙石 仙石 = null;
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public GameObject gou;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(仙石.quality);
        icon.sprite = ResourcesConfig.Get仙石Sprite(仙石.type,仙石.阶数);
        name.text = 仙石Config.Get仙石Name(仙石.type, 仙石.阶数);
        gou.SetActive(HeroWindowController.S.重铸panel当前仙石==仙石);
    }
    
    

    private void Start()
    {
        bg.onClick.AddListener(() =>
            {
                HeroWindowController.S.重铸panel当前仙石 = 仙石;
                ObserverModuleManager.S.SendEvent("重铸仙石点击",仙石);
            }
        );
    }
}