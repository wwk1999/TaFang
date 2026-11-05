using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 前置大道item : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI level;
    [NonSerialized] public 大道Type 大道Type;

    public void SetItem()
    {
        if (大道Type == 大道Type.None)
        {
            name.text = "无";
            level.text = "";
        }
        else
        {
            name.text = 悟道崖Config.大道配置[大道Type].name;
            level.text = "LV." + PlayerData.S.大道配置[大道Type].等级;
        }
    }
}
