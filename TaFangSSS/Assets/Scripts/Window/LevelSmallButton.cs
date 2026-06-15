using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSmallButton : MonoBehaviour
{
    public LevelSmallType levelSmallType;
    public Image LevelIcon;
    public TextMeshProUGUI LevelName;
    public Button LevelButton;
    public GameObject mask;
    public GameObject Suo;

    private void Start()
    {
        LevelButton.onClick.AddListener(() =>
        {
            LevelConfig.CurrentLevelSmallType=levelSmallType;
            ObserverModuleManager.S.SendEvent("LevelSamllButton", levelSmallType);
        });
    }

    private void OnEnable()
    {
        switch (PlayerData.S.LevelSmallJieSuoDic[levelSmallType])
        {
            case false:
                LevelButton.interactable=false;
                mask.SetActive(true);
                Suo.SetActive(true);
                break;
            case true:
                LevelButton.interactable=true;
                mask.SetActive(false);
                Suo.SetActive(false);
                break;
        }
        switch (levelSmallType)
        {
            case LevelSmallType.花果山:
                LevelIcon.sprite = ResourcesConfig.花果山;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.花果山];
                break;
            case LevelSmallType.水帘洞:
                LevelIcon.sprite = ResourcesConfig.水帘洞;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.水帘洞];
                break;
            case LevelSmallType.傲来国:
                LevelIcon.sprite = ResourcesConfig.傲来国;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.傲来国];
                break;
            case LevelSmallType.东海龙宫:
                LevelIcon.sprite = ResourcesConfig.东海龙宫;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.东海龙宫];
                break;
            case LevelSmallType.蓬莱仙岛:
                LevelIcon.sprite = ResourcesConfig.蓬莱仙岛;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.蓬莱仙岛];
                break;
            case LevelSmallType.五行山:
                LevelIcon.sprite = ResourcesConfig.五行山;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.五行山];
                break;
            case LevelSmallType.高老庄:
                LevelIcon.sprite = ResourcesConfig.高老庄;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.高老庄];
                break;
            case LevelSmallType.平顶山:
                LevelIcon.sprite = ResourcesConfig.平顶山;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.平顶山];
                break;
            case LevelSmallType.车迟国:
                LevelIcon.sprite = ResourcesConfig.车迟国;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.车迟国];
                break;
            case LevelSmallType.女儿国:
                LevelIcon.sprite = ResourcesConfig.女儿国;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.女儿国];
                break;
            case LevelSmallType.火焰山:
                LevelIcon.sprite = ResourcesConfig.火焰山;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.火焰山];
                break;
            case LevelSmallType.盘丝洞:
                LevelIcon.sprite = ResourcesConfig.盘丝洞;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.盘丝洞];
                break;
            case LevelSmallType.狮驼岭:
                LevelIcon.sprite = ResourcesConfig.狮驼岭;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.狮驼岭];
                break;
            case LevelSmallType.天竺国:
                LevelIcon.sprite = ResourcesConfig.天竺国;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.天竺国];
                break;
            case LevelSmallType.小雷音寺:
                LevelIcon.sprite = ResourcesConfig.小雷音寺;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.小雷音寺];
                break;
            case LevelSmallType.流沙河:
                LevelIcon.sprite = ResourcesConfig.流沙河;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.流沙河];
                break;
            case LevelSmallType.芭蕉洞:
                LevelIcon.sprite = ResourcesConfig.芭蕉洞;
                LevelName.text = LevelConfig.LevelSmallNameDic[LevelSmallType.芭蕉洞];
                break;

            default:
                break;
        }
    }
}
