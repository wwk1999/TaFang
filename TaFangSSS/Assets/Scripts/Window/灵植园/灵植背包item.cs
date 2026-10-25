using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum 灵植背包物品Type
{
    种子,
    肥料,
    作物,
}

public class 灵植背包item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI count;

    [NonSerialized] public 灵植背包物品Type 物品类型;
    [NonSerialized] public 灵植Type 灵植Tyep;
    [NonSerialized] public 肥料Type 肥料Tyep;
    [NonSerialized] public QualityType QualityType;
    [NonSerialized] public bool 是否变异;

    public void SetItem()
    {
        switch (物品类型)
        {
            case 灵植背包物品Type.种子:
                Set种子();
                break;
            case 灵植背包物品Type.肥料:
                Set肥料();
                break;
            case 灵植背包物品Type.作物:
                Set作物();
                break;
        }
    }

    private void Set种子()
    {
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(灵植园Config.灵植品质Dic[灵植Tyep]);
        icon.sprite = ResourcesConfig.Get灵植种子Sprite(灵植Tyep);
        name.text = 灵植园Config.灵植名[灵植Tyep];
        count.text = PlayerData.S.格式化数字(PlayerData.S.种子Dic[灵植Tyep]);
        icon.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void Set肥料()
    {
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(QualityType);
        icon.sprite = ResourcesConfig.Get肥料Icon(肥料Tyep, QualityType);
        name.text = 灵植园Config.肥料名[肥料Tyep];
        count.text = PlayerData.S.格式化数字(PlayerData.S.Get肥料数量(肥料Tyep, QualityType));
        icon.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    private void Set作物()
    {
        bg.image.sprite = ResourcesConfig.Get灵植背包格子(灵植园Config.灵植品质Dic[灵植Tyep]);
        icon.sprite = 是否变异
            ? ResourcesConfig.Get灵植变异收获Sprite(灵植Tyep)
            : ResourcesConfig.Get灵植收获Sprite(灵植Tyep);
        name.text = 是否变异
            ? "变异·" + 灵植园Config.灵植名[灵植Tyep]
            : 灵植园Config.灵植名[灵植Tyep];
        float 数量 = 是否变异
            ? PlayerData.S.变异收获Dic[灵植Tyep]
            : PlayerData.S.普通收获Dic[灵植Tyep];
        count.text = PlayerData.S.格式化数字(数量);
        icon.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
    }
}
