using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class 大道item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("背景")] 
    public Button 背景框Button;
    public GameObject bg暗;
    public GameObject bg亮;
    public Image bg;
    public GameObject 勾;
    [Header("内容")]
    public Image icon;
    public GameObject 问号节点;
    public TextMeshProUGUI nameText;
    public GameObject 等级节点;
    public GameObject 经验节点;
    public Image 进度条;

    [Header("数据")]
    public 大道Type 大道Type = 大道Type.None;

    public void 刷新悟道崖当前参悟界面(object[] obj)
    {
        SetItem(大道Type);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新悟道崖当前悟道界面",刷新悟道崖当前参悟界面);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新悟道崖当前悟道界面",刷新悟道崖当前参悟界面);
        // 默认显示暗背景
        SetBgState(false);
        背景框Button.onClick.AddListener(() =>
        {
            if (PlayerData.S.大道配置[大道Type].等级 <= 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","大道未解锁");
                return;
            }
            PlayerData.S.当前参悟大道Type = 大道Type;
            ObserverModuleManager.S.SendEvent("刷新悟道崖界面");
            ObserverModuleManager.S.SendEvent("刷新悟道崖当前悟道界面");
        });
    }

    /// <summary>
    /// 设置背景状态 true=亮 false=暗
    /// </summary>
    private void SetBgState(bool isHover)
    {
        if (bg暗 != null) bg暗.SetActive(!isHover);
        if (bg亮 != null) bg亮.SetActive(isHover);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetBgState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetBgState(false);
    }
    

    /// <summary>
    /// 填充大道数据
    /// </summary>
    public void SetItem(大道Type type)
    {
        大道Type = type;
        if (type == 大道Type.None)
        {
            gameObject.SetActive(false);
            return;
        }

        勾.gameObject.SetActive(PlayerData.S.当前参悟大道Type==type);
        switch (悟道崖Config.大道配置[type].大道等级Type)
        {
           case 大道等级Type.基础大道:
               bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.地品);
               break;
           case 大道等级Type.上等大道:
               bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.宇品);
               break;
           case 大道等级Type.至尊大道:
               bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.洪品);
               break;
           case 大道等级Type.本源大道:
               bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType.荒品);
               break;
        }
        gameObject.SetActive(true);

        大道配置 config = 悟道崖Config.大道配置[type];
        大道 data = PlayerData.S.大道配置[type];

        bool 未解锁 = data.等级 <= 0;

        // 图标（未解锁显示问号节点，已解锁显示真实icon）
        if (问号节点 != null) 问号节点.SetActive(未解锁);
        if (icon != null)
        {
            icon.gameObject.SetActive(!未解锁);
            if (!未解锁) icon.sprite = ResourcesConfig.Get大道Icon(type);
        }

        // 名称
        if (nameText != null)
        {
            nameText.text = 未解锁 ? "？？？？？" : config.name;
        }

        // 等级、经验（未解锁时隐藏）
        if (等级节点 != null) 等级节点.SetActive(!未解锁);
        if (经验节点 != null) 经验节点.SetActive(!未解锁);

        if (!未解锁)
        {
            if (等级节点 != null)
            {
                TextMeshProUGUI 等级Text = 等级节点.GetComponentInChildren<TextMeshProUGUI>();
                if (等级Text != null) 等级Text.text = "LV." + data.等级.ToString("F0");
            }

            // 经验与进度条
            大道等级Type levelType = config.大道等级Type;
            if (悟道崖Config.大道经验.TryGetValue(levelType, out float 单级经验))
            {
                if (经验节点 != null)
                {
                    TextMeshProUGUI[] texts = 经验节点.GetComponentsInChildren<TextMeshProUGUI>();
                    if (texts.Length >= 2)
                    {
                        texts[0].text = Mathf.Min(data.经验, 单级经验).ToString("F0");
                        texts[2].text = 单级经验.ToString("F0");
                    }
                }
                if (进度条 != null) 进度条.fillAmount = Mathf.Clamp01(data.经验 / 单级经验);
            }
        }
        else if (进度条 != null)
        {
            进度条.fillAmount = 0;
        }
    }
}
