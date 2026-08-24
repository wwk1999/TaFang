using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 分解确认弹窗 : MonoBehaviour
{
    [NonSerialized] public 分解类型 分解类型 = 分解类型.None;
    [NonSerialized] public 法器 法器 = null;
    [NonSerialized] public 仙石 仙石 = null;

    public TextMeshProUGUI name;
    public Button 返回Button;
    public Button 确认Button;
    public Button maskButton;

    private void Start()
    {
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            if (分解类型 == 分解类型.仙石)
            {
                PlayerData.S.PropListDic[PropType.仙石精华] += 仙石Config.仙石分解Dic[仙石.quality];
                PlayerData.S.仙石列表.Remove(仙石);
            }
            else
            {
                PlayerData.S.PropListDic[PropType.法器粉尘] += 法器Config.法器分解Dic[法器Config.法器品质Dic[法器.法器Type]];
                PlayerData.S.法器列表.Remove(法器);
            }
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        if (分解类型 == 分解类型.仙石)
        {
            name.text = 仙石Config.仙石名Dic[仙石.type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(仙石.quality);
        }
        else
        {
            name.text = 法器Config.法器名Dic[法器.法器Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(法器Config.法器品质Dic[法器.法器Type]);
        }
    }
}
