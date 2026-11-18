using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 当前佩戴宝物信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image 图片;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI info;
    public TextMeshProUGUI 效果;

    [NonSerialized] public 宝物 宝物;

    public void SetItem()
    {
        if (宝物 == null || 宝物.宝物Type == 宝物Type.None)
        {
            gameObject.SetActive(false);
            return;
        }

        bg.sprite = ResourcesConfig.Get灵植背包格子(宝物.QualityType);
        图片.sprite = ResourcesConfig.Get宝物Sprite(宝物.宝物Type);
        name.text = 灵矿场Config.宝物名[宝物.宝物Type];
        品质.text = 灵矿场Config.Get品质显示名(宝物.QualityType);
        info.text = 灵矿场Config.宝物描述[宝物.宝物Type];
        效果.text = 灵矿场Config.Get宝物效果(宝物.宝物Type, 宝物.QualityType);
    }
}
