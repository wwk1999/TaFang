using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 宝物Grid : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI count;
    public TextMeshProUGUI name;
    public GameObject 选中;

    [NonSerialized] public 宝物 宝物;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(宝物.QualityType);
        icon.sprite = ResourcesConfig.Get宝物Sprite(宝物.宝物Type);
        count.text = PlayerData.S.格式化数字(PlayerData.S.Get宝物数量(宝物.宝物Type, 宝物.QualityType));
        name.text = 灵矿场Config.宝物名[宝物.宝物Type];
        选中.SetActive(false);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("宝物Grid点击", 宝物Grid点击);
        bg.onClick.AddListener(() => ObserverModuleManager.S.SendEvent("宝物Grid点击", this));
    }

    private void 宝物Grid点击(object[] obj)
    {
        宝物Grid item = obj[0] as 宝物Grid;
        选中.SetActive(item == this);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("宝物Grid点击", 宝物Grid点击);
    }
}
