using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum 坊市道具类型
{
    None,
    法器,
    仙石,
    丹药,
    丹方,
}
public class 坊市item : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Image icon;
    public Image bg;
    public Image iconBg;
    public TextMeshProUGUI desc;
    public Button 购买Button;
    public TextMeshProUGUI 价格;
    [NonSerialized] public 法器Type 法器Type;
    [NonSerialized] public 仙石Type 仙石Type;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public 丹药Type 丹方Type;
    [NonSerialized] public QualityType QualityType;
    public void SetItem()
    {
        if (法器Type != 法器Type.None)
        {
            name.text = 法器Config.法器名Dic[法器Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(法器Config.法器品质Dic[法器Type]);
            icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
            bg.sprite = ResourcesConfig.Get传道背景框(法器Config.法器品质Dic[法器Type]);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器Type]);
            desc.text = 法器Config.法器descDic[法器Type];
            价格.text = PlayerData.S.格式化数字(坊市Config.法器价格Dic[法器Config.法器品质Dic[法器Type]]);
        }
        
        if (仙石Type != 仙石Type.None)
        {
            name.text = 仙石Config.仙石名Dic[仙石Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get仙石Sprite(仙石Type,QualityType);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 仙石Config.仙石DescDic[仙石Type];
            价格.text = PlayerData.S.格式化数字(坊市Config.仙石价格Dic[QualityType]);
        }
        
        if (丹药Type != 丹药Type.None)
        {
            name.text = 丹药Config.丹药名Dic[丹药Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get丹药icon(丹药Type,QualityType);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 丹药Config.Get丹药Desc(丹药Type,QualityType);
            价格.text = PlayerData.S.格式化数字(丹药Config.Get丹药价格(丹药Type,QualityType));
        }
        
        if (丹方Type != 丹药Type.None)
        {
            name.text = 丹药Config.丹方名Dic[丹方Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get丹药icon(丹方Type,QualityType);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 丹药Config.丹方DescDic[丹方Type];
            价格.text = PlayerData.S.格式化数字(丹药Config.Get丹方价格(丹方Type,QualityType));
        }
    }
}
