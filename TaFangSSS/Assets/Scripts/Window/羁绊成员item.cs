using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 羁绊成员item : MonoBehaviour
{
    public GameObject mask;
    public Image icon;
    public Image bg;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI nameText;
    [NonSerialized] public 道宝Type 道宝Type;

    public void SetItem()
    {
        icon.sprite = ResourcesConfig.Get道宝Sprite(道宝Type);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(道宝Config.道宝QualityToQuality[道宝Config.道宝品质Dic[道宝Type]]);
        int level=PlayerData.S.道宝LevelDic[道宝Type];
        levelText.text = "LV." + PlayerData.S.道宝LevelDic[道宝Type];
        levelText.gameObject.SetActive(level>0);
        mask.gameObject.SetActive(level==0);
        nameText.text = 道宝Config.道宝NameDic[道宝Type];
        nameText.colorGradientPreset = ResourcesConfig.Get品质TMP(道宝Config.道宝QualityToQuality[道宝Config.道宝品质Dic[道宝Type]]);
    }
}
