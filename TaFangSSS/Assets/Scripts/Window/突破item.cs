using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 突破item : MonoBehaviour
{
    public Image 背景框;
    public TextMeshProUGUI 突破name;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI 灵物名;
    public TextMeshProUGUI 功德count;
    public Button 突破Button;
    [NonSerialized]public QualityType quality;
    
    public void SetItem()
    {
        背景框.sprite = ResourcesConfig.Get传道背景框(quality);
        突破name.text = PropConfig.QualityNameDic[quality] + "突破";
        突破name.colorGradientPreset=ResourcesConfig.Get品质TMP(quality);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(quality);
        icon.sprite=ResourcesConfig.Get突破灵物(PlayerData.S.JingJieType, quality);
        灵物名.text = 灵物突破Config.突破灵物名Dic[PlayerData.S.JingJieType];
        灵物名.colorGradientPreset=ResourcesConfig.Get品质TMP(quality);
        功德count.text=PlayerData.S.格式化数字(JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][(int)(quality-1)]);
    }

    public void Start()
    {
        突破Button.onClick.AddListener(() =>
        {
            if (PlayerData.S.Get灵物数量(PlayerData.S.JingJieType, quality) <= 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
                return;
            }

            if (PlayerData.S.PropListDic[PropType.功德] < JingJieConfig.突破材料Dic[PlayerData.S.JingJieType][(int)(quality - 1)])
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","功德不足");
                return;
            }
            ObserverModuleManager.S.SendEvent("显示突破确认弹窗");
        });
    }
}
