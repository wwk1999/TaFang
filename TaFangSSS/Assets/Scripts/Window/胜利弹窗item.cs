using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 胜利弹窗item : MonoBehaviour
{
    public Image bg;
    public Image image;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI Name;
    [NonSerialized] public PropType Type;
    [NonSerialized] public long count;
    [NonSerialized] public QualityType 灵物QualityType=QualityType.None;
    [NonSerialized] public 法器Type 法器Type=法器Type.None;


    public void SetItem()
    {
        if (法器Type != 法器Type.None)
        {
            Name.text = 法器Config.法器名Dic[法器Type];
            Name.colorGradientPreset = ResourcesConfig.Get品质TMP(法器Config.法器品质Dic[法器Type]);
            CountText.text = "";
            image.sprite=ResourcesConfig.Get法器Sprite(法器Type);
            bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器Type]);
            return;
        }
        if (灵物QualityType != QualityType.None)
        {
            Name.text = 灵物突破Config.突破灵物名Dic[PlayerData.S.JingJieType];
            Name.colorGradientPreset = ResourcesConfig.Get品质TMP(灵物QualityType);
            CountText.text = "";
            image.sprite=ResourcesConfig.Get突破灵物(PlayerData.S.JingJieType,灵物QualityType);
            bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(灵物QualityType);
            return;
        }
        
        Name.text = PropConfig.PropNameDic[Type];
        Name.colorGradientPreset = ResourcesConfig.Get品质TMP(PropConfig.PropQualityDic[Type]);
        CountText.text = PlayerData.S.格式化数字(count);
        image.sprite=ResourcesConfig.GetPropSprite(Type);
        bg.sprite=ResourcesConfig.Get道具背景框Sprite(Type); 
        
        
    }
}
