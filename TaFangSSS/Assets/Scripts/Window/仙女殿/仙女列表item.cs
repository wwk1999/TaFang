using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙女列表item : MonoBehaviour
{
    public Image bg;
    public GameObject content;
    public Image 头像;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 等级;
    public Image 进度条;
    public GameObject 锁;

    [NonSerialized] public 仙子Type 仙子Type;
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
        ObserverModuleManager.S.SendEvent("仙女Item点击", 仙子Type);
    }

    public void SetItem()
    {
        var 仙女 = PlayerData.S.仙女Dic[仙子Type];
        bool 已解锁 = 仙女.解锁;
        bg.sprite = 是否选中 ? ResourcesConfig.仙子列表背景框亮 : ResourcesConfig.仙子列表背景框;
        content.SetActive(已解锁);
        锁.SetActive(!已解锁);
        if (按钮 != null) 按钮.interactable = 已解锁;

        if (!已解锁) return;

        头像.sprite = ResourcesConfig.Get仙子头像(仙子Type);
        name.text = 阴阳殿Config.仙子名Dic[仙子Type];

        int 上限 = 阴阳殿Config.Get好感度升级经验(仙女.好感度等级);
        等级.text = "LV." + 仙女.好感度等级;
        进度条.fillAmount = 上限 > 0 ? Mathf.Clamp01((float)仙女.好感度经验 / 上限) : 0f;
    }
}
