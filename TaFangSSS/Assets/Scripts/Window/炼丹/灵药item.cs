using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵药item : MonoBehaviour
{
    [NonSerialized] public 灵药Type 灵药Type;
    [NonSerialized] public QualityType QualityType;
    // [重构] 新增：造化丹药时用灵植、显示固定数量
    [NonSerialized] public bool 是造化灵植;
    [NonSerialized] public 灵植Type 灵植Type;
    [NonSerialized] public int 显示数量;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI Count;

    public void SetItem()
    {
        if (是造化灵植)
        {
            // 造化丹药材料：显示灵植icon/名称，固定数量
            icon.gameObject.SetActive(true);
            icon.sprite = ResourcesConfig.Get灵植成熟Sprite(灵植Type);
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            name.text = 灵植园Config.灵植名[灵植Type];
            float 普通库存 = PlayerData.S.普通收获Dic.TryGetValue(灵植Type, out var 普通数) ? 普通数 : 0;
            float 变异库存 = PlayerData.S.变异收获Dic.TryGetValue(灵植Type, out var 变异数) ? 变异数 : 0;
            int 总库存 = (int)(普通库存 + 变异库存);
            Count.text = $"{总库存}/{显示数量}";
        }
        else if (灵药Type == 灵药Type.None)
        {
            icon.gameObject.SetActive(false);
            bg.sprite = ResourcesConfig.加号背景框1;
            name.text = "";
            Count.text = "";
        }
        else
        {
            icon.gameObject.SetActive(true);
            icon.sprite = ResourcesConfig.Get灵药Icon(灵药Type, QualityType);
            bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            name.text = 丹药Config.灵药名Dic[灵药Type];
            int 库存 = PlayerData.S.Get灵药数量(灵药Type, QualityType);
            Count.text = 显示数量 > 0 ? $"{库存}/{显示数量}" : 库存.ToString();
        }
    }
}
