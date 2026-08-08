using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 背包Grid信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI quality;
    public TextMeshProUGUI info;

    [NonSerialized] public PropType PropType;
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
        icon.sprite=ResourcesConfig.GetPropSprite(PropType);
        name.text = PropConfig.PropNameDic[PropType];
        quality.text=PropConfig.QualityNameDic[QualityType];
        quality.colorGradientPreset=ResourcesConfig.Get品质TMP(QualityType);
        info.text = PropConfig.道具信息InfoDic[PropConfig.PropTypeTo道具信息[PropType]];
    }
}
