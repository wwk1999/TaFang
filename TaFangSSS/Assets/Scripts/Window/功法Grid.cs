using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 功法Grid : MonoBehaviour, IPointerClickHandler
{
    public Image bg;
    public TextMeshProUGUI count;
    public Image icon;
    [NonSerialized] public 功法Type 功法Type;
    public TextMeshProUGUI name;

    public void OnPointerClick(PointerEventData eventData)
    {
        // 判断是否是右键
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ObserverModuleManager.S.SendEvent("功法分解",功法Type);
        }
    }
    
    public void SetItem()
    {
        name.text = 功法Config.功法名Dic[功法Type];
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        count.text=PlayerData.S.功法数量Dic[功法Type].ToString();
        icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
    }
}
