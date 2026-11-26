using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 矿工装备洗练弹窗 : MonoBehaviour
{
    public Image bg;                       // 图片/bg，品质背景框
    public Image icon;      
    public TextMeshProUGUI 阶数;
    // 图片/icon
    public TextMeshProUGUI name;
    public TextMeshProUGUI 类型count;       // 装备类型
    public TextMeshProUGUI info;
    public 装备属性Item[] 属性;             // 依次：挖掘速度、固定收益、挖宝速度、成长速度
    public TextMeshProUGUI 当前矿工粉尘;
    public TextMeshProUGUI 需要矿工粉尘;
    public Button 洗练Button;
    public Button maskButton;

    public Button 挖掘速度锁;
    public Button 固定收益锁;
    public Button 成长速度锁;
    public Button 挖宝速度锁;

    public 矿工装备洗练无暇提示弹窗 矿工装备洗练无暇提示弹窗;
    
    [NonSerialized] public 矿工装备 矿工装备;

    private void OnEnable()
    {
        SetItem();
    }

    public void 矿工装备确认洗练(object[] obj)
    {
        SetItem();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("矿工装备确认洗练",矿工装备确认洗练);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("矿工装备确认洗练",矿工装备确认洗练);
        Canvas.ForceUpdateCanvases();
        挖掘速度锁.onClick.AddListener(() =>
        {
            矿工装备.挖掘速度洗练锁 = !矿工装备.挖掘速度洗练锁;
            SetItem();
        });
        固定收益锁.onClick.AddListener(() =>
        {
            矿工装备.固定收益洗练锁 = !矿工装备.固定收益洗练锁;
            SetItem();
        });
        成长速度锁.onClick.AddListener(() =>
        {
            矿工装备.成长速度洗练锁 = !矿工装备.成长速度洗练锁;
            SetItem();
        });
        挖宝速度锁.onClick.AddListener(() =>
        {
            矿工装备.挖宝时间洗练锁 = !矿工装备.挖宝时间洗练锁;
            SetItem();
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        洗练Button.onClick.AddListener(() =>
        {
            var 价格=灵矿场Config.Get装备洗练粉尘(矿工装备.阶数, 矿工装备.QualityType) * Math.Pow(2, Get锁个数(矿工装备));
            if (PlayerData.S.矿工粉尘 < 价格)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","矿工粉尘不足");
                return;
            }
            
            if (!矿工装备.挖掘速度洗练锁 && 矿工装备.挖掘速度无暇)
            {
                矿工装备洗练无暇提示弹窗.矿工装备 = 矿工装备;
                矿工装备洗练无暇提示弹窗.gameObject.SetActive(true);
                return;
            }
            if (!矿工装备.固定收益洗练锁 && 矿工装备.固定收益无暇)
            {
                矿工装备洗练无暇提示弹窗.矿工装备 = 矿工装备;
                矿工装备洗练无暇提示弹窗.gameObject.SetActive(true);
                return;
            }
            if (!矿工装备.成长速度洗练锁 && 矿工装备.成长速度无暇)
            {
                矿工装备洗练无暇提示弹窗.矿工装备 = 矿工装备;
                矿工装备洗练无暇提示弹窗.gameObject.SetActive(true);
                return;
            }
            if (!矿工装备.挖宝时间洗练锁 && 矿工装备.挖宝时间无暇)
            {
                矿工装备洗练无暇提示弹窗.矿工装备 = 矿工装备;
                矿工装备洗练无暇提示弹窗.gameObject.SetActive(true);
                return;
            }

            PlayerData.S.矿工粉尘 -= (float)价格;
        // 复制一份配置值，避免随机加成直接改到静态配置表
        四维属性 配置四维 = 灵矿场Config.装备四维属性[矿工装备.阶数];
        四维属性 基础四维属性 = new 四维属性()
        {
            挖掘速度 = 配置四维.挖掘速度,
            固定收益 = 配置四维.固定收益,
            挖宝时间 = 配置四维.挖宝时间,
            成长速度 = 配置四维.成长速度,
        };
        bool 挖掘速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 成长速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 挖宝速度无暇 = Random.Range(0f, 100f) < 1f;
        bool 固定收益无暇 = Random.Range(0f, 100f) < 1f;
        if (!挖掘速度无暇) 基础四维属性.挖掘速度 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        if (!挖宝速度无暇) 基础四维属性.挖宝时间 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        if (!成长速度无暇) 基础四维属性.成长速度 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        if (!固定收益无暇) 基础四维属性.固定收益 *= Random.Range(灵矿场Config.装备随机最小区间, 灵矿场Config.装备随机最大区间);
        switch (矿工装备.QualityType)
        {
            case QualityType.地品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[1];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[1];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[1];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[1];
                break;
            case QualityType.宇品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[2];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[2];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[2];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[2];
                break;
            case QualityType.洪品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[3];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[3];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[3];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[3];
                break;
            case QualityType.荒品:
                基础四维属性.挖掘速度 *= 灵矿场Config.品质倍率[4];
                基础四维属性.挖宝时间 *= 灵矿场Config.品质倍率[4];
                基础四维属性.成长速度 *= 灵矿场Config.品质倍率[4];
                基础四维属性.固定收益 *= 灵矿场Config.品质倍率[4];
                break;
        }
        if (挖掘速度无暇) 基础四维属性.挖掘速度 *= 灵矿场Config.无暇倍率;
        if (成长速度无暇) 基础四维属性.成长速度 *= 灵矿场Config.无暇倍率;
        if (固定收益无暇) 基础四维属性.固定收益 *= 灵矿场Config.无暇倍率;
        if (挖宝速度无暇) 基础四维属性.挖宝时间 *= 灵矿场Config.无暇倍率;
        if(!矿工装备.固定收益洗练锁)矿工装备.固定收益无暇 = 固定收益无暇;
        if(!矿工装备.成长速度洗练锁)矿工装备.成长速度无暇 = 成长速度无暇;
        if(!矿工装备.挖掘速度洗练锁)矿工装备.挖掘速度无暇 = 挖掘速度无暇;
        if(!矿工装备.挖宝时间洗练锁)矿工装备.挖宝时间无暇 = 挖宝速度无暇;
        
        if(!矿工装备.固定收益洗练锁)矿工装备.基础四维.固定收益 = 基础四维属性.固定收益;
        if(!矿工装备.成长速度洗练锁)矿工装备.基础四维.成长速度 = 基础四维属性.成长速度;
        if(!矿工装备.挖掘速度洗练锁)矿工装备.基础四维.挖掘速度 = 基础四维属性.挖掘速度;
        if(!矿工装备.挖宝时间洗练锁)矿工装备.基础四维.挖宝时间 = 基础四维属性.挖宝时间;
        PlayerData.S.任务完成字典[任务Type.洗练矿工装备] = true;
        ObserverModuleManager.S.SendEvent("刷新任务栏");
        SetItem();
        });
    }

    public void SetItem()
    {
        if (矿工装备 == null || 矿工装备.矿工装备Type == 矿工装备Type.None)
        {
            gameObject.SetActive(false);
            return;
        }

        挖掘速度锁.image.sprite = 矿工装备.挖掘速度洗练锁 ? ResourcesConfig.灵矿场锁:ResourcesConfig.灵矿场解锁;
        固定收益锁.image.sprite = 矿工装备.固定收益洗练锁 ? ResourcesConfig.灵矿场锁:ResourcesConfig.灵矿场解锁;
        成长速度锁.image.sprite = 矿工装备.成长速度洗练锁 ? ResourcesConfig.灵矿场锁:ResourcesConfig.灵矿场解锁;
        挖宝速度锁.image.sprite = 矿工装备.挖宝时间洗练锁 ? ResourcesConfig.灵矿场锁:ResourcesConfig.灵矿场解锁;

        需要矿工粉尘.text = PlayerData.S.格式化数字(灵矿场Config.Get装备洗练粉尘(矿工装备.阶数, 矿工装备.QualityType)*Math.Pow(2,Get锁个数(矿工装备)));
        当前矿工粉尘.text = PlayerData.S.格式化数字(PlayerData.S.矿工粉尘);
        阶数.text = PlayerData.S.Get阶数string(矿工装备.阶数);
        bg.sprite = ResourcesConfig.Get灵植背包格子(矿工装备.QualityType);
        icon.sprite = ResourcesConfig.Get矿工装备Sprite(矿工装备.矿工装备Type, 矿工装备.阶数);
        name.text = 灵矿场Config.Get装备名称(矿工装备.矿工装备Type, 矿工装备.阶数);
        类型count.text = 矿工装备.矿工装备Type.ToString();
        info.text = 灵矿场Config.Get装备介绍(矿工装备.矿工装备Type, 矿工装备.阶数);
        Set属性();
    }

    private int Get锁个数(矿工装备 装备)
    {
        int value = 0;
        if (装备.挖掘速度洗练锁) value += 1;
        if (装备.固定收益洗练锁) value += 1;
        if (装备.成长速度洗练锁) value += 1;
        if (装备.挖宝时间洗练锁) value += 1;
        return value;
    }
    private void Set属性()
    {
        四维属性 四维 = 矿工装备.基础四维 ?? new 四维属性();
        float[] 上限 = Get属性上限();

        if (属性 == null || 属性.Length < 4) return;

        属性[0].SetItem("挖掘速度", 四维.挖掘速度, 矿工装备.挖掘速度无暇, 上限[0],矿工装备.QualityType);
        属性[1].SetItem("固定收益", 四维.固定收益, 矿工装备.固定收益无暇, 上限[1],矿工装备.QualityType);
        属性[2].SetItem("挖宝速度", 四维.挖宝时间, 矿工装备.挖宝时间无暇, 上限[2],矿工装备.QualityType);
        属性[3].SetItem("成长速度", 四维.成长速度, 矿工装备.成长速度无暇, 上限[3],矿工装备.QualityType);
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
            配置.挖掘速度 * 随机上限 *灵矿场Config.品质倍率[索引],
            配置.固定收益 * 随机上限 *灵矿场Config.品质倍率[索引],
            配置.挖宝时间 * 随机上限 *灵矿场Config.品质倍率[索引],
            配置.成长速度 * 随机上限 *灵矿场Config.品质倍率[索引],
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
