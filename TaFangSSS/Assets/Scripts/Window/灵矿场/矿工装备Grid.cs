using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工装备Grid : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI 阶数;
    public TextMeshProUGUI name;
    public GameObject 选中;

    [NonSerialized] public 矿工装备 矿工装备;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(矿工装备.QualityType);
        icon.sprite = ResourcesConfig.Get矿工装备Sprite(矿工装备.矿工装备Type, 矿工装备.阶数);
        阶数.text = PlayerData.S.Get阶数string(矿工装备.阶数);
        阶数.colorGradientPreset = ResourcesConfig.Get品质TMP(矿工装备.QualityType);
        name.text = 灵矿场Config.Get装备名称(矿工装备.矿工装备Type, 矿工装备.阶数);
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(矿工装备.QualityType);
        选中.SetActive(false);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("矿工装备Grid点击", 矿工装备Grid点击);
        bg.onClick.AddListener(() => ObserverModuleManager.S.SendEvent("矿工装备Grid点击", this));
    }

    private void 矿工装备Grid点击(object[] obj)
    {
        矿工装备Grid item = obj[0] as 矿工装备Grid;
        选中.SetActive(item == this);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("矿工装备Grid点击", 矿工装备Grid点击);
    }
}
