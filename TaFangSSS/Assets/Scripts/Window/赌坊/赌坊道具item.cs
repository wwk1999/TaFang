using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>赌坊道具背包中的单个道具：显示品质框、名称与持有数量，左键点击使用</summary>
public class 赌坊道具item : MonoBehaviour, IPointerClickHandler
{
    public Image bg;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    [NonSerialized] public 赌坊道具Type 道具Type;
    [NonSerialized] public bool 本轮已使用;

    private CanvasGroup 组;

    private void Awake()
    {
        组 = GetComponent<CanvasGroup>();
        if (组 == null)
        {
            组 = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void SetItem()
    {
        if (道具Type == 赌坊道具Type.None) return;

        道具配置 config = 赌坊Config.道具配置[道具Type];
        if (bg != null) bg.sprite = ResourcesConfig.Get道具背景框SpriteByPropType(config.QualityType);
        if (name != null) name.text = config.名称;

        float 数量 = 0;
        if (PlayerData.S != null && PlayerData.S.赌坊道具Dic != null)
        {
            PlayerData.S.赌坊道具Dic.TryGetValue(道具Type, out 数量);
        }

        if (count != null) count.text = PlayerData.S.格式化数字(数量);
        if (组 != null) 组.alpha = 数量 > 0 && !本轮已使用 ? 1f : 0.5f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;
        if (道具Type == 赌坊道具Type.None) return;
        ObserverModuleManager.S.SendEvent("赌坊道具Item点击", 道具Type);
    }
}
