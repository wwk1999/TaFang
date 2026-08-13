using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 传道item : MonoBehaviour
{
    public Image bg;
    public TextMeshProUGUI name;
    public Image icon;
    public TextMeshProUGUI 功德count;
    public Button 传道Button;
    [NonSerialized]public QualityType qualityType;

    private void Start()
    {
        传道Button.onClick.AddListener(() =>
            {
                if (PlayerData.S.剩余传道次数 <= 0)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","传道次数不足");
                    return;
                }

                if (PlayerData.S.PropListDic[PropType.功德] < 功法Config.传道消耗Dic[qualityType])
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","功德不足");
                    return;
                }
                功法Type type=功法Config.传道(qualityType);
                ObserverModuleManager.S.SendEvent("SendUIToast",功法Config.功法名Dic[type],功法Config.功法TypeQualityDic[type],1);
                PlayerData.S.功法数量Dic[type]++;
                PlayerData.S.剩余传道次数--;
                ObserverModuleManager.S.SendEvent("刷新主页面");
                ObserverModuleManager.S.SendEvent("刷新传道界面");
            }
        );
    }

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get传道背景框(qualityType);
        name.text=PropConfig.QualityNameDic[qualityType]+"传道";
        name.colorGradientPreset=ResourcesConfig.Get品质TMP(qualityType);
        icon.sprite=ResourcesConfig.Get传道icon(qualityType);
        功德count.text=功法Config.传道消耗Dic[qualityType].ToString();
        传道Button.image.sprite=ResourcesConfig.Get传道按钮(qualityType);
        switch (qualityType)
        {
            case QualityType.黄品:
                
                break;
        }
    }
}
