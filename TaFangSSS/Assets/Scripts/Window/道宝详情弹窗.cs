using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 道宝详情弹窗 : MonoBehaviour
{
    public Button maskButton;

    public Button exitButton;
    public TextMeshProUGUI name;
    public TextMeshProUGUI info;
    public Image image;
    public Image 艺术字;
    public TextMeshProUGUI 当前效果;
    public TextMeshProUGUI 升级奖励;

    [NonSerialized] public 道宝Type 道宝Type;

    private void Awake()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show()
    {
        name.text = 道宝Config.道宝NameDic[道宝Type];
        info.text = 道宝Config.道宝InfoDic[道宝Type];
        image.sprite = ResourcesConfig.Get道宝Sprite(道宝Type);
        QualityType qualityType = 道宝Config.道宝QualityToQuality[道宝Config.道宝品质Dic[道宝Type]];
        艺术字.sprite = ResourcesConfig.Get艺术字(qualityType);
        当前效果.text = 道宝Config.单件升级奖励Dic[(int)qualityType - 4] * PlayerData.S.道宝LevelDic[道宝Type] + "%";
        升级奖励.text = "升级奖励：" + 道宝Config.单件升级奖励Dic[(int)qualityType - 4] + "%修炼速度";
    }
}
