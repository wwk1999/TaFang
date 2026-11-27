using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 当前装备item : MonoBehaviour, IPointerClickHandler
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI 阶数;
    public TextMeshProUGUI name;
    [NonSerialized] public 矿工 矿工;
    [NonSerialized] public 矿工装备 矿工装备;

    public void SetItem()
    {
        if (矿工装备 == null)
        {
            bg.sprite = ResourcesConfig.灵植背包格子空;
            icon.gameObject.SetActive(false);
            阶数.gameObject.SetActive(false);
            name.text = 矿工装备.矿工装备Type.ToString();
            return;
        }

        bg.sprite = ResourcesConfig.Get灵植背包格子(矿工装备.QualityType);
        icon.sprite = ResourcesConfig.Get矿工装备Sprite(矿工装备.矿工装备Type,矿工装备.阶数);
        阶数.text = PlayerData.S.Get阶数string(矿工装备.阶数);
        name.text = 矿工装备.矿工装备Type.ToString();
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(矿工装备.QualityType);
        icon.gameObject.SetActive(true);
        阶数.gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && 矿工 != null && 矿工装备 != null)
        {
            ObserverModuleManager.S.SendEvent("卸下矿工装备", 矿工, 矿工装备);
        }
    }
}
