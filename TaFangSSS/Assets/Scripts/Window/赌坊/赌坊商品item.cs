using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>赌坊道具商品：右键直接使用道具，价格按当前赌坊的道具价格倍率计算</summary>
public class 赌坊商品item : MonoBehaviour, IPointerClickHandler
{
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    [NonSerialized] public 赌坊道具Type 道具Type;

    public void SetItem()
    {
        if (道具Type == 赌坊道具Type.None) return;

        道具配置 config = 赌坊Config.道具配置[道具Type];
        bg.sprite = ResourcesConfig.Get灵植背包格子(config.QualityType);
        name.text = config.名称;
        if (icon != null && 赌坊Config.道具图标索引.TryGetValue(道具Type, out int 图标索引))
        {
            icon.sprite = ResourcesConfig.Get赌坊道具Sprite(图标索引);
        }
        count.text = PlayerData.S.格式化数字(赌坊Config.Get道具价格(PlayerData.S.赌坊存档.当前赌坊Type, 道具Type));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (道具Type == 赌坊道具Type.None) return;

        // 右键直接使用，由赌坊界面校验轮次、灵气并结算
        ObserverModuleManager.S.SendEvent("赌坊道具使用", 道具Type);
    }
}
