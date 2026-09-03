using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 伤害面板item : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI count;
    public TextMeshProUGUI 比例text;
    public RectTransform 技能;
    public RectTransform 神通;
    [NonSerialized]public HeroType heroType;
    [NonSerialized]public float 总比例;
    [NonSerialized]public float 神通比例;
    [NonSerialized]public float 技能比例;
    [NonSerialized] public float damage;

    public void SetItem()
    {
        float 总长 = 总比例 * 254.1f;
        技能.sizeDelta = new Vector2(总长 * 技能比例, 技能.sizeDelta.y);
        神通.sizeDelta = new Vector2(总长 * 神通比例, 技能.sizeDelta.y);
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[heroType]);
        icon.sprite=ResourcesConfig.GetHeroSprite(heroType);
        比例text.text=(int)(总比例*100)+"%";
        count.text = PlayerData.S.格式化数字(damage);
    }
}
