using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 符文之地道具信息弹窗 : MonoBehaviour
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI 品质;
    [NonSerialized]public PropType  propType;
    [NonSerialized]public QualityType  QualityType;

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
        if (propType == PropType.None)
        {
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            icon.sprite = ResourcesConfig.问号;
            name.text = PropConfig.QualityNameDic[QualityType]+"符文";
            desc.text = "获得随机一道"+PropConfig.QualityNameDic[QualityType]+"符文";
            品质.text = "品质:" + PropConfig.QualityNameDic[QualityType];
        }
        else
        {
            bg.sprite = ResourcesConfig.Get道具背景框Sprite(propType);
            icon.sprite=ResourcesConfig.GetPropSprite(propType);            icon.sprite = ResourcesConfig.问号;
            name.text = PropConfig.PropNameDic[propType];
            desc.text = PropConfig.道具信息InfoDic[PropConfig.PropTypeTo道具信息[propType]];
            var list=符文之地Config.符文之地掉落Dic[HeroWindowController.S.当前符文之地Type];
            foreach (var item in list)
            {
                if (item.PropType == propType)
                {
                    品质.text = "掉落数量:" + item.minCount + "-" + item.maxCount;
                }
            }
        }
    }
}
