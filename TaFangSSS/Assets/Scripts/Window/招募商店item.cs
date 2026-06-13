using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 招募商店item : MonoBehaviour
{
    [NonSerialized] public PropType type;
    public Button bg;
    public Image image;
    public TextMeshProUGUI count;
    public TextMeshProUGUI name;
    [NonSerialized]public 招募商店兑换弹窗 招募商店兑换窗口;

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            招募商店兑换窗口.Type = type;
            招募商店兑换窗口.SetItem();
            招募商店兑换窗口.gameObject.SetActive(true);
        });
    }

    public void SetItem()
    {
        image.sprite=ResourcesConfig.GetHeroSprite(PropConfig.PropToHeroDic[type]);
        name.text = HeroConfig.HeroNameDic[PropConfig.PropToHeroDic[type]];
        count.text = ZhaoMuConfig.招募商店价格Dic[type].ToString();
        switch (HeroConfig.HeroQualityDic[PropConfig.PropToHeroDic[type]])
        {
            case QualityType.黄品:
                bg.image.sprite = ResourcesConfig.道具背景框白;
                break;
            case QualityType.玄品:
                bg.image.sprite = ResourcesConfig.道具背景框绿;
                break;
            case QualityType.地品:
                bg.image.sprite = ResourcesConfig.道具背景框蓝;
                break;
            case QualityType.天品:
                bg.image.sprite = ResourcesConfig.道具背景框紫;
                break;
            case QualityType.宇品:
                bg.image.sprite = ResourcesConfig.道具背景框橙;
                break;
            case QualityType.宙品:
                bg.image.sprite = ResourcesConfig.道具背景框粉;
                break;
            case QualityType.洪品:
                bg.image.sprite = ResourcesConfig.道具背景框红;
                break;
            case QualityType.荒品:
                bg.image.sprite = ResourcesConfig.道具背景框彩;
                break;
        }
    }
}
