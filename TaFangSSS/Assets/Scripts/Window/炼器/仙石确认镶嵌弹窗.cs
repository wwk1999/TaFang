using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙石确认镶嵌弹窗 : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Button 返回Button;
    public Button 确认Button;
    [NonSerialized] public 法器 法器;
    [NonSerialized] public 仙石 仙石;
    [NonSerialized] public int index;

    private void OnEnable()
    {
        name.text = 仙石Config.仙石名Dic[仙石.type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(仙石.quality);
    }

    private void Start()
    {
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            PlayerData.S.仙石列表.Remove(仙石);
            法器.仙石list[index] = 仙石;
            ObserverModuleManager.S.SendEvent("刷新仙石镶嵌Panel");
            gameObject.SetActive(false);
        });
    }
}
