using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 道纹信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI quality;
    public TextMeshProUGUI info;

    [NonSerialized] public 道纹Type 道纹Type;
    [NonSerialized] public QualityType QualityType;

    private void FollowMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 targetPos = mousePos ;
        transform.position = targetPos;
    }

    private void Update()
    {
        FollowMouse();
    }
    public void SetItem()
    {
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
        icon.sprite=ResourcesConfig.Get道纹Sprite(道纹Type, QualityType);
        name.text = 道纹config.道纹名Dic[道纹Type];
        quality.text=PropConfig.QualityNameDic[QualityType];
        quality.colorGradientPreset=ResourcesConfig.Get品质TMP(QualityType);
        info.text = 道纹config.Get道文info(道纹Type, QualityType);
    }

}
