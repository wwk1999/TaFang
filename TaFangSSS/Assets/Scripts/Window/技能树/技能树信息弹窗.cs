using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;

public class 技能树信息弹窗 : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI 当前等级Text;
    public TextMeshProUGUI 最大等级Text;
    public TextMeshProUGUI info;
    [NonSerialized] public HeroType HeroType;
    [NonSerialized] public 技能Type 技能Type;
    [NonSerialized] public int 最大等级;
    [NonSerialized] public int 当前等级;

    public void SetItem()
    {
        name.text = 英雄技能树Config.技能名Dic[技能Type];
        当前等级Text.text=当前等级.ToString();
        最大等级Text.text=最大等级.ToString();
        info.text = 英雄技能树Config.Get技能info(HeroType, 技能Type);
    }
}
