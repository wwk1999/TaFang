using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 体质infoItem : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品阶;
    public TextMeshProUGUI 修炼速度;
    public TextMeshProUGUI desc;

    [NonSerialized] public 体质Type 体质type;

    public void SetItem()
    {
        name.text = 体质Config.体质名Dic[体质type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(体质Config.体质品质Dic[体质type]);
        品阶.text = 体质Config.Get体质品阶(体质type);
        修炼速度.text = 体质Config.体质修炼速度Dic[体质Config.体质品质Dic[体质type]] + "倍";
        desc.text = 体质Config.体质DescDic[体质type];
    }
}
