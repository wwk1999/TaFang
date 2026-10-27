using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 打造item : MonoBehaviour,IPointerClickHandler
{
    public Image bg;
    public Image icon;
    public Image mask;
    public TextMeshProUGUI counttext;
    [NonSerialized] public 法器Type 法器Type;
    [NonSerialized] public QualityType 品质;
    [NonSerialized] public int count;
    [NonSerialized] public float 进度;
    [NonSerialized] public int index;
    public void SetItem()
    {
        mask.sprite=ResourcesConfig.Get法器Sprite(法器Type);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(品质);
        icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
        counttext.text = count.ToString();
        icon.fillAmount = 进度 / 100f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            PlayerData.S.打造List.RemoveAt(index);
            ObserverModuleManager.S.SendEvent("刷新法器打造区域");
        }
    }
}
