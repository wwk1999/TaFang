using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 赌坊item : MonoBehaviour
{
    public Image bg;
    public TextMeshProUGUI name;
    public Image icon;
    public TextMeshProUGUI count;
    public GameObject 首仓价格;

    [NonSerialized] public 赌坊Type 赌坊Type;
    [NonSerialized] public bool 是否选中;

    private Button 按钮;

    private void Awake()
    {
        if (bg == null) return;
        // 预制体只有背景 Image，运行时在根节点补按钮；点击子节点图形会向上冒泡到根节点按钮
        bg.raycastTarget = true;
        按钮 = GetComponent<Button>();
        if (按钮 == null) 按钮 = gameObject.AddComponent<Button>();
        按钮.targetGraphic = bg;
        按钮.onClick.AddListener(点击);
    }

    private void OnDestroy()
    {
        if (按钮 != null) 按钮.onClick.RemoveListener(点击);
    }

    private void 点击()
    {
        if (赌坊Type == 赌坊Type.None) return;
        ObserverModuleManager.S.SendEvent("赌坊Item点击", 赌坊Type);
    }

    public void SetItem()
    {
        if (bg == null) return;

        bg.sprite = 是否选中 ? ResourcesConfig.Get赌坊Icon亮(赌坊Type) : ResourcesConfig.Get赌坊Icon(赌坊Type);

        // 未选中也显示名称和首仓价格，只有图标区分亮/暗
        bool 显示信息 = 赌坊Type != 赌坊Type.None;
        name.gameObject.SetActive(显示信息);
        首仓价格.SetActive(显示信息);
        if (!显示信息) return;

        name.text = 赌坊Config.赌坊配置[赌坊Type].name;
        icon.sprite = ResourcesConfig.GetPropSprite(PropType.灵魂);
        count.text = PlayerData.S.格式化数字(赌坊Config.赌坊配置[赌坊Type].首仓价格);
    }
}
