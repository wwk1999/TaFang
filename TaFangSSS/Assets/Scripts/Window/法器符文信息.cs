using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 法器符文信息 : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI count;
    [NonSerialized] public 符文 符文;

    public void SetItem()
    {
        name.text = 符文Config.符文名Dic[符文.type];
        desc.text = 符文Config.符文效果Dic[符文.type];
        if (HeroWindowController.S.熔炼后符文.type == 符文Type.击杀怪物获得神通能量)
        {
            count.text = 符文.count.ToString("F2");
        }
        else
        {
            count.text = 符文.count.ToString("F1")+"%";
        }
    }
}
