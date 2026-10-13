using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 法器魂器 : MonoBehaviour
{
    [NonSerialized] public 法器 法器;
    public TextMeshProUGUI level;
    public Image Slider;
    public TextMeshProUGUI 当前经验;
    public TextMeshProUGUI 最大经验text;

    public void SetItem()
    {
        level.text = "LV." + 法器.魂器等级;
        float 最大经验 = 功法Config.Get功法升级经验(法器.魂器等级);
        Slider.fillAmount = 法器.魂器经验 / 最大经验;
        当前经验.text = 法器.魂器经验.ToString();
        最大经验text.text = 最大经验.ToString();
    }
}
