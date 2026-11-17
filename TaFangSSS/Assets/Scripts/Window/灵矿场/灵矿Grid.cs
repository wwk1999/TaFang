using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵矿Grid : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI 阶数;
    public TextMeshProUGUI count;
    public TextMeshProUGUI name;
    public GameObject 选中;

    [NonSerialized] public int 阶数值;
    [NonSerialized] public QualityType 品质;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(品质);
        icon.sprite = ResourcesConfig.Get灵矿Sprite(阶数值, 品质);
        阶数.text = PlayerData.S.Get阶数string(阶数值);
        阶数.colorGradientPreset = ResourcesConfig.Get品质TMP(品质);
        count.text = PlayerData.S.格式化数字(PlayerData.S.Get灵矿数量(阶数值, 品质));
        name.text = 品质 + "灵矿";
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(品质);
        选中.SetActive(false);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("灵矿Grid点击", 灵矿Grid点击);
        bg.onClick.AddListener(() => ObserverModuleManager.S.SendEvent("灵矿Grid点击", this));
    }

    private void 灵矿Grid点击(object[] obj)
    {
        灵矿Grid item = obj[0] as 灵矿Grid;
        选中.SetActive(item == this);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("灵矿Grid点击", 灵矿Grid点击);
    }
}
