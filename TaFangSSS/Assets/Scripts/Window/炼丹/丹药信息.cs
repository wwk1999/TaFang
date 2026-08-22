using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹药信息 : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 炼制等级;
    public TextMeshProUGUI 增加经验;
    public TextMeshProUGUI 需要时间;
    public TextMeshProUGUI 功效;
    public TextMeshProUGUI 灵药1;
    public TextMeshProUGUI 灵药2;
    public TextMeshProUGUI 灵药3;
    public TextMeshProUGUI 灵药4;
    [NonSerialized]public 丹药Type 丹药Type;
    [NonSerialized]public QualityType QualityType;

    public void SetItem()
    {
        name.text = 丹药Config.丹药名Dic[丹药Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite=ResourcesConfig.Get丹药icon(丹药Type,QualityType);
        类型.text = 丹药Config.丹药类型String[丹药Config.丹药类型Dic[丹药Type]];
        品质.text=PropConfig.QualityNameDic[QualityType];
        丹药类型 丹药类型 = 丹药Config.丹药类型Dic[丹药Type];
        功效.text = 丹药Config.Get丹药Desc(丹药Type, QualityType);
        灵药1.text = 丹药Config.灵药名Dic[丹药Config.丹方Dic[丹药Type][0]];
        灵药2.text = 丹药Config.灵药名Dic[丹药Config.丹方Dic[丹药Type][1]];
        灵药3.text = 丹药Config.灵药名Dic[丹药Config.丹方Dic[丹药Type][2]];
        灵药4.text = 丹药Config.灵药名Dic[丹药Config.丹方Dic[丹药Type][3]];
        switch (丹药类型)
        {
            case 丹药类型.战斗丹药:
                炼制等级.text = 丹药Config.战斗丹药炼制等级Dic[QualityType].ToString();
                增加经验.text=丹药Config.战斗丹药经验Dic[QualityType].ToString();
                需要时间.text=丹药Config.战斗丹药炼制时间Dic[QualityType].ToString();
                break;
            case 丹药类型.辅助丹药:
                炼制等级.text = 丹药Config.辅助丹药炼制等级Dic[QualityType].ToString();
                增加经验.text=丹药Config.辅助丹药经验Dic[QualityType].ToString();
                需要时间.text=丹药Config.辅助丹药炼制时间Dic[QualityType].ToString();
                break;
            case 丹药类型.根基丹药:
                炼制等级.text = 丹药Config.根基丹药炼制等级Dic[QualityType].ToString();
                增加经验.text=丹药Config.根基丹药经验Dic[QualityType].ToString();
                需要时间.text=丹药Config.根基丹药炼制时间Dic[QualityType].ToString();
                break;
            case 丹药类型.造化丹药:
                炼制等级.text = 丹药Config.造化丹药炼制等级Dic[QualityType].ToString();
                增加经验.text=丹药Config.造化丹药经验Dic[QualityType].ToString();
                需要时间.text=丹药Config.造化丹药炼制时间Dic[QualityType].ToString();
                break;
        }
    }
}
