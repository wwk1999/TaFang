using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 功法信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 职业;
    public TextMeshProUGUI info;
    public TextMeshProUGUI 基础属性;
    public TextMeshProUGUI 每重加成;
    [NonSerialized] public 功法Type 功法Type;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
        name.text = 功法Config.功法名Dic[功法Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(功法Config.功法TypeQualityDic[功法Type]);
        职业.text = "职业："+功法Config.功法职业Dic[功法Type];
        info.text = 功法Config.功法介绍Dic[功法Type];
        基础属性.text = 功法Config.Get功法基础属性String(功法Type);
        ZhiYeType zhiYeType = 功法Config.功法职业Dic[功法Type];
        float 最终伤害 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[功法Type]] ;
        float 辅助值 = 功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]] ;
        if (zhiYeType == ZhiYeType.辅助)
        {
            每重加成.text = $"被辅助英雄伤害+<color=green>{辅助值}%</color>";
        }
        else
        {
            每重加成.text = $"英雄最终伤害+<color=green>{最终伤害}%</color>";
        }
    }
}
