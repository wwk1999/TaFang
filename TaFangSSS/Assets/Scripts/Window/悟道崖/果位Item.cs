using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class 果位Item : MonoBehaviour
{
    [Header("内容")]
    public Image icon;
    public TextMeshProUGUI nameText;
    public Image bg;

    [Header("数据")]
    public 大道Type 大道Type = 大道Type.None;
    
    /// <summary>
    /// 填充果位数据
    /// </summary>
    public void SetItem(大道Type type)
    {
        大道Type = type;
        if (type == 大道Type.None)
        {
            gameObject.SetActive(false);
            return;
        }
        switch (悟道崖Config.大道配置[type].大道等级Type)
        {
            case 大道等级Type.基础大道:
                bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.天品);
                break;
            case 大道等级Type.上等大道:
                bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.宇品);
                break;
            case 大道等级Type.至尊大道:
                bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.洪品);
                break;
            case 大道等级Type.本源大道:
                bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.荒品);
                break;
        }
        gameObject.SetActive(true);

        大道配置 config = 悟道崖Config.大道配置[type];

        if (icon != null) icon.sprite = ResourcesConfig.Get果位Icon(type);
        if (nameText != null) nameText.text = config.果位名;
    }
}
