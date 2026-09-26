using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 升级材料item : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI countText;
    [NonSerialized] public 升级材料Type 升级材料Type;
    [NonSerialized] public float count;

    public void SetItem()
    {
        countText.text = count.ToString();
        switch (升级材料Type)
        {
            case 升级材料Type.灵气:
                name.text = "灵气";
                icon.sprite = ResourcesConfig.灵魂;
                break;
            case 升级材料Type.矿石:
                name.text = "矿石";
                icon.sprite = ResourcesConfig.矿石;
                break;
            case 升级材料Type.玄铁:
                name.text = "玄铁";
                icon.sprite = ResourcesConfig.玄铁;
                break;
            case 升级材料Type.玉髓:
                name.text = "玉髓";
                icon.sprite = ResourcesConfig.玉髓;
                break;
        }
    }
}
