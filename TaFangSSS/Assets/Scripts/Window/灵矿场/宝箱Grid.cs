using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 宝箱Grid : MonoBehaviour,IPointerClickHandler
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI count;
    public TextMeshProUGUI name;
    public GameObject 选中;

    [NonSerialized] public 宝箱品质 品质;
    [NonSerialized] public int 数量;

    public void SetItem()
    {
        QualityType 背景品质 = Get背景品质(品质);
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(背景品质);
        icon.sprite = ResourcesConfig.Get宝箱Sprite(品质);
        count.text = PlayerData.S.格式化数字(数量);
        name.text = 品质 + "宝箱";
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(背景品质);
        选中.SetActive(false);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("宝箱Grid点击", 宝箱Grid点击);
        bg.onClick.AddListener(() => ObserverModuleManager.S.SendEvent("宝箱Grid点击", this));
    }

    private void 宝箱Grid点击(object[] obj)
    {
        宝箱Grid item = obj[0] as 宝箱Grid;
        选中.SetActive(item == this);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("宝箱Grid点击", 宝箱Grid点击);
    }

    // 普通→蓝，卓越→红，至尊→彩
    private static QualityType Get背景品质(宝箱品质 quality)
    {
        switch (quality)
        {
            case 宝箱品质.卓越:
                return QualityType.洪品;
            case 宝箱品质.至尊:
                return QualityType.荒品;
            default:
                return QualityType.地品;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            灵矿场Config.开宝箱(品质);
            PlayerData.S.宝箱Dic[品质] --;
            ObserverModuleManager.S.SendEvent("刷新矿工背包");
        }
    }
}
