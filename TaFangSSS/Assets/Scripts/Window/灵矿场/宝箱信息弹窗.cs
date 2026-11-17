using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 宝箱信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image 图片;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI info;

    [NonSerialized] public 宝箱品质 宝箱品质;

    public void SetItem()
    {
        switch (宝箱品质)
        {
            case 宝箱品质.普通:
                bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.地品);
                break;
            case 宝箱品质.卓越:
                bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.洪品);
                break;
            case 宝箱品质.至尊:
                bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.荒品);
                break;
        }
        

        图片.sprite = ResourcesConfig.Get宝箱Sprite(宝箱品质);
        name.text = 宝箱品质 + "宝箱";
        品质.text = 宝箱品质.ToString();
        info.text = 灵矿场Config.宝箱介绍[宝箱品质];
    }
    
}
