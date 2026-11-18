using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵矿信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image 图片;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI info;
    public TextMeshProUGUI 灵石;

    [NonSerialized] public int 阶数;
    [NonSerialized] public QualityType 品质Type;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get灵植背包格子(品质Type);
        var 灵矿配置 = 灵矿场Config.灵矿配置表[Mathf.Clamp(阶数, 1, 10)];
        图片.sprite = ResourcesConfig.Get灵矿Sprite(阶数, 品质Type);
        name.text = 灵矿配置.名称;
        switch (品质Type)
        {
            case QualityType.黄品:
                品质.text = "普通";
                break;
            case QualityType.地品:
                品质.text = "稀有";
                break;
            case QualityType.宇品:
                品质.text = "罕见";
                break;
            case QualityType.洪品:
                品质.text = "神话";
                break;
            case QualityType.荒品:
                品质.text = "永恒";
                break;
        }
        info.text = 灵矿配置.介绍;
        灵石.text = "灵石"+PlayerData.S.格式化数字(灵矿场Config.Get灵矿价格(阶数, 品质Type));
    }
    
}
