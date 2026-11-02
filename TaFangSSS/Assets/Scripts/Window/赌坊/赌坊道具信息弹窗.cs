using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 赌坊道具信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 效果;
    public TextMeshProUGUI count;
    [NonSerialized] public 赌坊道具Type Type;

    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get灵植背包格子(赌坊Config.道具配置[Type].QualityType);
        icon.sprite = ResourcesConfig.Get赌坊道具Sprite(赌坊Config.道具图标索引[Type]);
        name.text = 赌坊Config.道具配置[Type].名称;
        count.text = PlayerData.S.格式化数字(赌坊Config.道具配置[Type].价格);
        效果.text=赌坊Config.道具配置[Type].效果;
    }
}
