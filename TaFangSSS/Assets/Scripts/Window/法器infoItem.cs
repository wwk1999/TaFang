using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器infoItem : MonoBehaviour
{
    [NonSerialized] public 法器Type 法器Type;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI 职业;
    public GameObject tip;
    public TextMeshProUGUI 基础属性count;

    public void SetItem()
    {
        基础属性count.text = 法器Config.法器基础属性Dic[法器Config.法器品质Dic[法器Type]]+"%";
        tip.gameObject.SetActive(法器Config.法器职业Dic[法器Type]==ZhiYeType.辅助);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器Type]);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
        name.text = 法器Config.法器名Dic[法器Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(法器Config.法器品质Dic[法器Type]);
        desc.text=法器Config.法器descDic[法器Type];
        职业.text=HeroConfig.Get职业Name(法器Config.法器职业Dic[法器Type]);
    }
}
