using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹药grid : MonoBehaviour
{
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public QualityType QualityType;
    public Button bg;
    public Image icon;
    public Image 艺术字;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            var 丹药类型=丹药Config.丹药类型Dic[丹药Type];
            if (丹药类型 == 丹药类型.辅助丹药)
            {
                ObserverModuleManager.S.SendEvent("服用辅助丹药弹窗",丹药Type,QualityType);
            }
            if (丹药类型 == 丹药类型.根基丹药)
            {
                ObserverModuleManager.S.SendEvent("服用根基丹药",丹药Type,QualityType);
            }
            if (丹药类型 == 丹药类型.造化丹药)
            {
                if (PlayerData.S.当前轮回造化丹药QualityType != QualityType.None)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","当前轮回已经服用过造化丹");
                    return;
                }
                ObserverModuleManager.S.SendEvent("显示服用造化丹药确认弹窗",QualityType);
            }
        });
    }

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type,QualityType);
        艺术字.sprite = ResourcesConfig.Get艺术字(QualityType);
        name.text = 丹药Config.丹药名Dic[丹药Type];
        count.text = PlayerData.S.Get丹药数量(丹药Type, QualityType).ToString();
    }
}