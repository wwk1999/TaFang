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
    [NonSerialized] public int 阶数;
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            if (PlayerData.S.炼丹等级 < 丹药Config.Get炼丹等级要求(丹药Type, 阶数))
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "炼丹等级不足,无法学习丹方");
                return;
            }
            ObserverModuleManager.S.SendEvent("显示使用丹方弹窗", 丹药Type, 阶数);
        });
    }

    public void SetItem()
    {
        QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
        bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(材料品质);
        icon.sprite = ResourcesConfig.Get丹方icon(丹药Type, 材料品质); // 丹方icon按阶数对应的材料品质取
        name.text = $"{多语言Config.Get(丹药Config.丹方名Dic[丹药Type])}·{阶数}阶";
        count.text = PlayerData.S.Get丹方数量(丹药Type, 阶数).ToString();
    }
}
