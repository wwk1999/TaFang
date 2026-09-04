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
    [NonSerialized] public 仙石Type 仙石Type=仙石Type.None;
    [NonSerialized] public QualityType 仙石QualityType=QualityType.None;
    [NonSerialized] public 神物Type 神物Type=神物Type.None;
    [NonSerialized] public 道纹Type 道纹Type=道纹Type.None;
    [NonSerialized] public QualityType 道纹QualityType=QualityType.None;


    public void SetItem()
    {
        if (道纹Type != 道纹Type.None)
        {
            Name.text = 道纹config.道纹名Dic[道纹Type];
            Name.colorGradientPreset = ResourcesConfig.Get品质TMP(道纹QualityType);
            CountText.text = "";
            image.sprite=ResourcesConfig.Get道纹Sprite(道纹Type,道纹QualityType);
            bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(道纹QualityType);
            return;
        }
        if (神物Type != 神物Type.None)
        {
            Name.text = 神物Config.神物名Dic[神物Type];
            Name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType.宇品);
            CountText.text = "";
            image.sprite=ResourcesConfig.Get神物Icon(神物Type);
            bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.宇品);
            return;
        }
        if (仙石Type != 仙石Type.None)
        {
            Name.text = 仙石Config.仙石名Dic[仙石Type];
            Name.colorGradientPreset = ResourcesConfig.Get品质TMP(仙石QualityType);
            CountText.text = "";
            image.sprite=ResourcesConfig.Get仙石Sprite(仙石Type,仙石QualityType);
            bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(仙石QualityType);
            return;
        }
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
            Name.text = 灵物突破Config.突破灵物名Dic[PlayerData.S.当前轮回境界];
            Name.colorGradientPreset = ResourcesConfig.Get品质TMP(灵物QualityType);
            CountText.text = "";
            image.sprite=ResourcesConfig.Get突破灵物(PlayerData.S.当前轮回境界,灵物QualityType);
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
