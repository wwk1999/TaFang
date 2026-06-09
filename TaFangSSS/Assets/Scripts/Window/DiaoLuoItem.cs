using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class DiaoLuoItem : MonoBehaviour
{
    [NonSerialized]public PropType propType;
    public Image bg;
    public Image image;

    public void SetItem()
    {
        switch (propType)
        {
            case PropType.灵魂:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.灵魂;
                break;
            case PropType.领主经验值:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.领主经验值;
                break;
            case PropType.法师经验值:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.法师经验值;
                break;
            case PropType.战士经验值:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.战士经验值;
                break;
            case PropType.控制经验值:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.控制经验值;
                break;
            case PropType.辅助经验值:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.辅助经验值;
                break;
            case PropType.射手经验值:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.射手经验值;
                break;
            case PropType.全职业经验值:
                bg.sprite = ResourcesConfig.道具背景框紫;
                image.sprite = ResourcesConfig.全职业经验值;
                break;
            case PropType.衣服锻造石:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.衣服锻造石;
                break;
            case PropType.头盔锻造石:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.头盔锻造石;
                break;
            case PropType.护手锻造石:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.护手锻造石;
                break;
            case PropType.项链锻造石:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.项链锻造石;
                break;
            case PropType.戒指锻造石:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.戒指锻造石;
                break;
            case PropType.鞋子锻造石:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.鞋子锻造石;
                break;
            case PropType.招募卷:
                bg.sprite = ResourcesConfig.道具背景框蓝;
                image.sprite = ResourcesConfig.招募卷;
                break;
        }
    }
}
