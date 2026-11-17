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
        品质.text = PropConfig.QualityNameDic[品质Type];
        info.text = 灵矿配置.介绍;
        灵石.text = "灵石"+PlayerData.S.格式化数字(灵矿配置.价格);
    }
    
}
