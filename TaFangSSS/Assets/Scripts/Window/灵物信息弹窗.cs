using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵物信息弹窗 : MonoBehaviour
{
    [NonSerialized] public JingJieType JingJieType;
    [NonSerialized] public QualityType QualityType;
    [NonSerialized] public PropType ProType;

    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 品质text;

    public TextMeshProUGUI 数量;

    public TextMeshProUGUI desc;

    public void SetItem()
    {
        if (ProType == PropType.None)
        {
            品质.gameObject.SetActive(true);
            品质text.gameObject.SetActive(true);
            数量.gameObject.SetActive(false);
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            icon.sprite = ResourcesConfig.Get突破灵物(JingJieType, QualityType);
            name.text = 灵物突破Config.突破灵物名Dic[JingJieType];
            品质.text = PropConfig.QualityNameDic[QualityType];
            品质.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            desc.text = "突破" + JingJieConfig.JingJieNameDic[JingJieType] + "境界的核心材料";
        }
        else
        {
            品质.gameObject.SetActive(false);
            品质text.gameObject.SetActive(false);
            数量.gameObject.SetActive(true);
            bg.sprite = ResourcesConfig.Get道具背景框Sprite(ProType);
            icon.sprite = ResourcesConfig.GetPropSprite(ProType);
            name.text = PropConfig.PropNameDic[ProType];
            if (ProType == PropType.功德)
            {
                数量.text = "掉落数量：" + PlayerData.S.格式化数字(灵物突破Config.洞天普通掉落Dic[new 洞天关卡Item() { JingJieType = PlayerData.S.JingJieType, qualityType = QualityType }][1].maxCount) + "-" + PlayerData.S.格式化数字(灵物突破Config.洞天普通掉落Dic[new 洞天关卡Item() { JingJieType = PlayerData.S.JingJieType, qualityType = QualityType }][1].minCount);
            }else if (ProType == PropType.灵魂)
            {
                数量.text = "掉落数量：" + PlayerData.S.格式化数字(灵物突破Config.洞天普通掉落Dic[new 洞天关卡Item() { JingJieType = PlayerData.S.JingJieType, qualityType = QualityType }][0].maxCount) + "-" + PlayerData.S.格式化数字(灵物突破Config.洞天普通掉落Dic[new 洞天关卡Item() { JingJieType = PlayerData.S.JingJieType, qualityType = QualityType }][0].minCount);
            }
            desc.text = PropConfig.道具信息InfoDic[PropConfig.PropTypeTo道具信息[ProType]];
        }
    }
}
