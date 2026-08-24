using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹方Grid : MonoBehaviour
{
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType QualityType;
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            if (PlayerData.S.炼丹等级 < 丹药Config.Get炼制丹药等级(丹药Type, QualityType))
            {
                ObserverModuleManager.S.SendEvent("炼丹等级不足,无法学习丹方");
                return;
            }
            ObserverModuleManager.S.SendEvent("显示使用丹方弹窗",丹药Type,QualityType);
        });
    }

    public void SetItem()
    {
        bg.image.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite=ResourcesConfig.Get丹方icon(丹药Type,QualityType);
        name.text = 丹药Config.丹方名Dic[丹药Type];
        count.text = PlayerData.S.Get丹方数量(丹药Type, QualityType).ToString();
    }

}
