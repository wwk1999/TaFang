using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 招募item : MonoBehaviour
{
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI 标签;
    public Image icon;
    public Image bg;
    public TextMeshProUGUI 挖掘速度;
    public TextMeshProUGUI 固定收益;
    public TextMeshProUGUI 成长速度;
    public TextMeshProUGUI 挖宝速度;
    public GameObject 词条列表;
    public TextMeshProUGUI 灵魂;
    public Button 招募Button;
    public GameObject 已招募;
    [NonSerialized] public 矿工 矿工;

    private void Start()
    {
        招募Button.onClick.AddListener(() =>
        {
            float 价格 = 灵矿场Config.Get矿工价格(矿工.阶数, 矿工.QualityType);
            if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
                return;
            }

            if (PlayerData.S.矿工列表.Count >= 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级].人数)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","矿工人数已满");
                return;
            }

            PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
            PlayerData.S.矿工列表.Add(矿工);
            矿工.已被招募 = true;
            SetItem();
            ObserverModuleManager.S.SendEvent("矿工招募");
        });
    }

    public void SetItem()
    {
        招募Button.gameObject.SetActive(!矿工.已被招募);
        已招募.gameObject.SetActive(矿工.已被招募);
        灵魂.text = "灵魂"+灵矿场Config.Get矿工价格(矿工.阶数, 矿工.QualityType);
        类型.text = 灵矿场Config.矿工类型string[矿工.矿工类型];
        标签.text = PlayerData.S.Get阶数string(矿工.阶数) + "·" + 灵矿场Config.矿工品质string[矿工.QualityType];
        icon.sprite = ResourcesConfig.Get矿工头像(矿工.矿工类型, 矿工.阶数, 矿工.QualityType);
        bg.sprite = ResourcesConfig.Get灵矿场招募卡片(矿工.QualityType);
        挖掘速度.text = 矿工.基础四维.挖掘速度.ToString();
        固定收益.text = 矿工.基础四维.固定收益.ToString();
        成长速度.text = 矿工.基础四维.成长速度.ToString();
        挖宝速度.text = 矿工.基础四维.挖宝时间.ToString();
        foreach (Transform item in 词条列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in 矿工.词条列表)
        {
            var 词条 = Instantiate(Resources.Load("Prefabs/Window/灵矿场/矿工词条item"), 词条列表.transform)
                .GetComponent<矿工词条item>();
            词条.矿工词条类型 = item;
            词条.quality = 矿工.QualityType;
            词条.SetItem();
        }
    }
}
