using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 装备信息弹窗 : MonoBehaviour
{
    public Image bg;                       // 图片/bg，品质背景框
    public Image icon;                     // 图片/icon
    public TextMeshProUGUI name;
    public TextMeshProUGUI 类型count;       // 装备类型
    public TextMeshProUGUI info;
    public 装备属性Item[] 属性;             // 依次：挖掘速度、固定收益、挖宝速度、成长速度
    public TextMeshProUGUI 粉尘;

    [NonSerialized] public 矿工装备 矿工装备;

    public void SetItem()
    {
        if (矿工装备 == null || 矿工装备.矿工装备Type == 矿工装备Type.None)
        {
            gameObject.SetActive(false);
            return;
        }

        bg.sprite = ResourcesConfig.Get灵植背包格子(矿工装备.QualityType);
        icon.sprite = ResourcesConfig.Get矿工装备Sprite(矿工装备.矿工装备Type, 矿工装备.阶数);
        name.text = 灵矿场Config.Get装备名称(矿工装备.矿工装备Type, 矿工装备.阶数);
        类型count.text = 矿工装备.矿工装备Type.ToString();
        info.text = 灵矿场Config.Get装备介绍(矿工装备.矿工装备Type, 矿工装备.阶数);
        Set属性();
        粉尘.text = PlayerData.S.格式化数字(
            灵矿场Config.Get装备分解粉尘(矿工装备.阶数, 矿工装备.QualityType)) + "粉尘";
    }

    private void Set属性()
    {
        四维属性 四维 = 矿工装备.基础四维 ?? new 四维属性();
        float[] 上限 = Get属性上限();

        if (属性 == null || 属性.Length < 4) return;

        属性[0].SetItem("挖掘速度", 四维.挖掘速度, 矿工装备.挖掘速度无暇, 上限[0]);
        属性[1].SetItem("固定收益", 四维.固定收益, 矿工装备.固定收益无暇, 上限[1]);
        属性[2].SetItem("挖宝速度", 四维.挖宝时间, 矿工装备.挖宝时间无暇, 上限[2]);
        属性[3].SetItem("成长速度", 四维.成长速度, 矿工装备.成长速度无暇, 上限[3]);
    }

    // 同阶同品质、未触发无暇时的属性上限，用于进度条比例
    private float[] Get属性上限()
    {
        int 阶数 = Mathf.Clamp(矿工装备.阶数, 1, 10);
        四维属性 配置 = 灵矿场Config.装备四维属性[阶数];
        int 索引 = Get品质索引(矿工装备.QualityType);
        float 随机上限 = 灵矿场Config.装备随机最大区间;

        return new float[]
        {
            配置.挖掘速度 * 随机上限 * 灵矿场Config.装备挖掘速度品质倍率[索引]*(1f+灵矿场Config.当前总宝物属性.装备效果/100f),
            配置.固定收益 * 随机上限 * 灵矿场Config.装备固定收益品质倍率[索引]*(1f+灵矿场Config.当前总宝物属性.装备效果/100f),
            配置.挖宝时间 * 随机上限 * 灵矿场Config.装备挖宝速度品质倍率[索引]*(1f+灵矿场Config.当前总宝物属性.装备效果/100f),
            配置.成长速度 * 随机上限 * 灵矿场Config.装备成长速度品质倍率[索引]*(1f+灵矿场Config.当前总宝物属性.装备效果/100f),
        };
    }

    private static int Get品质索引(QualityType qualityType)
    {
        switch (qualityType)
        {
            case QualityType.地品:
                return 1;
            case QualityType.宇品:
                return 2;
            case QualityType.洪品:
                return 3;
            case QualityType.荒品:
                return 4;
            default:
                return 0;
        }
    }
}
