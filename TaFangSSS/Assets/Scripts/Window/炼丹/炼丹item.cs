using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 炼丹item : MonoBehaviour,IPointerClickHandler
{
    public Image bg;
    public Image icon;
    public Image mask;
    public TextMeshProUGUI counttext;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public int 阶数;
    [NonSerialized] public int count;
    [NonSerialized] public float 进度;
    [NonSerialized] public int index;
    public void SetItem()
    {
        QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
        mask.sprite = ResourcesConfig.Get丹药icon(丹药Type, 材料品质);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(材料品质);
        icon.sprite = ResourcesConfig.Get丹药icon(丹药Type, 材料品质);
        counttext.text = count.ToString();
        icon.fillAmount = 进度 / 100f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            PlayerData.S.丹药炼制List.RemoveAt(index);
            ObserverModuleManager.S.SendEvent("刷新丹药炼制区域");
        }
    }
}
