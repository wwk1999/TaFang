using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 大道infoItem : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 等级;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI level;

    [NonSerialized] public 大道Type 大道Type;

    public void SetItem()
    {
        bg.sprite = ResourcesConfig.Get灵植背包格子(悟道崖Config.大道等级品质[悟道崖Config.大道配置[大道Type].大道等级Type]);
        icon.sprite = ResourcesConfig.Get大道Icon(大道Type);
        name.text = 悟道崖Config.大道配置[大道Type].name;
        等级.text = 悟道崖Config.大道等级名[悟道崖Config.大道配置[大道Type].大道等级Type];
        desc.text = 悟道崖Config.大道配置[大道Type].介绍;
        level.text = "LV." + PlayerData.S.大道配置[大道Type].等级;
    }
}
