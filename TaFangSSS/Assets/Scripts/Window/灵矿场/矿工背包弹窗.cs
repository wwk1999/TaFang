using System;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工背包弹窗 : MonoBehaviour
{
    public Button exitButton;
    public Button maskButton;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 标签;
    public TextMeshProUGUI 描述;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 数量;

    public Button 阶数筛选Button;
    public Button 品质筛选Button;
    public Button 排序Button;

    public Button 灵矿Button;
    public Button 装备Button;
    public Button 宝箱Button;
    public Button 宝物Button;

    public GameObject 背包;
    public Button 左箭头;
    public Button 右箭头;
    public TextMeshProUGUI num;

    public Button 分解Button;

    public Button 下拉区域mask;
    public GameObject 阶数下拉区域;
    public GameObject 品质下拉区域;
    public GameObject 排序下拉区域;
    public GameObject 阶数下拉区域Content;
    public GameObject 品质下拉区域Content;
    public Button 排序品质Button;
    public Button 排序阶数Button;
    public GameObject 右panel;

    private enum 背包类型
    {
        灵矿,
        装备,
        宝箱,
        宝物,
    }

    private class 背包条目
    {
        public 背包类型 类型;
        public int 阶数;
        public QualityType 品质;
        public 宝箱品质 宝箱品质;
        public int 数量;
        public 矿工装备 装备;
        public 宝物 宝物;
    }

    private static readonly QualityType[] 五种品质 =
    {
        QualityType.黄品, QualityType.地品, QualityType.宇品, QualityType.洪品, QualityType.荒品,
    };

    private const int 每页数量 = 32;

    private 背包类型 当前类型 = 背包类型.灵矿;
    private int 阶数筛选;
    private QualityType 品质筛选 = QualityType.None;
    private int 宝箱品质筛选 = -1; // -1=所有，其余对应宝箱品质枚举值
    private int 排序类型; // 0 默认，1 品质，2 阶数
    private int 当前页 = 1;
    private 背包条目 当前选中;
    private readonly List<背包条目> 条目列表 = new List<背包条目>();
    private readonly List<GameObject> 格子列表 = new List<GameObject>();

    private void OnEnable()
    {
        当前页 = 1;
        关闭下拉();
        刷新界面();
    }

    public void 刷新矿工背包(object[] obj)
    {
        刷新界面();
    }
    private void Start()
    {
        灵矿Button.onClick.AddListener(() => 切换类型(背包类型.灵矿));
        装备Button.onClick.AddListener(() => 切换类型(背包类型.装备));
        宝箱Button.onClick.AddListener(() => 切换类型(背包类型.宝箱));
        宝物Button.onClick.AddListener(() => 切换类型(背包类型.宝物));

        阶数筛选Button.onClick.AddListener(() => 打开下拉(阶数下拉区域));
        品质筛选Button.onClick.AddListener(() => 打开下拉(品质下拉区域));
        排序Button.onClick.AddListener(() => 打开下拉(排序下拉区域));
        下拉区域mask.onClick.AddListener(关闭下拉);

        排序品质Button.onClick.AddListener(() =>
        {
            排序类型 = 1;
            关闭下拉();
            当前页 = 1;
            刷新界面();
        });
        排序阶数Button.onClick.AddListener(() =>
        {
            排序类型 = 2;
            关闭下拉();
            当前页 = 1;
            刷新界面();
        });

        左箭头.onClick.AddListener(() =>
        {
            当前页--;
            刷新背包();
        });
        右箭头.onClick.AddListener(() =>
        {
            当前页++;
            刷新背包();
        });

        分解Button.onClick.AddListener(分解当前选中);
        exitButton.onClick.AddListener(() => gameObject.SetActive(false));
        maskButton.onClick.AddListener(() => gameObject.SetActive(false));
        ObserverModuleManager.S.RegisterEvent("刷新矿工背包",刷新矿工背包);
        ObserverModuleManager.S.RegisterEvent("矿工背包品质筛选", 矿工背包品质筛选);
        ObserverModuleManager.S.RegisterEvent("矿工背包宝箱品质筛选", 矿工背包宝箱品质筛选);
        ObserverModuleManager.S.RegisterEvent("矿工背包阶数筛选", 矿工背包阶数筛选);
        ObserverModuleManager.S.RegisterEvent("灵矿Grid点击", 灵矿Grid点击);
        ObserverModuleManager.S.RegisterEvent("矿工装备Grid点击", 矿工装备Grid点击);
        ObserverModuleManager.S.RegisterEvent("宝箱Grid点击", 宝箱Grid点击);
        ObserverModuleManager.S.RegisterEvent("宝物Grid点击", 宝物Grid点击);

        Init筛选();
        刷新界面();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新矿工背包",刷新矿工背包);
        ObserverModuleManager.S.UnRegisterEvent("矿工背包品质筛选", 矿工背包品质筛选);
        ObserverModuleManager.S.UnRegisterEvent("矿工背包宝箱品质筛选", 矿工背包宝箱品质筛选);
        ObserverModuleManager.S.UnRegisterEvent("矿工背包阶数筛选", 矿工背包阶数筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵矿Grid点击", 灵矿Grid点击);
        ObserverModuleManager.S.UnRegisterEvent("矿工装备Grid点击", 矿工装备Grid点击);
        ObserverModuleManager.S.UnRegisterEvent("宝箱Grid点击", 宝箱Grid点击);
        ObserverModuleManager.S.UnRegisterEvent("宝物Grid点击", 宝物Grid点击);
    }

    private void Init筛选()
    {
        foreach (Transform item in 阶数下拉区域Content.transform)
        {
            item.gameObject.SetActive(false);
            Destroy(item.gameObject);
        }

        foreach (Transform item in 品质下拉区域Content.transform)
        {
            item.gameObject.SetActive(false);
            Destroy(item.gameObject);
        }

        // 阶数筛选：灵矿/装备为 所有+1~10阶，宝箱/宝物只有所有
        int 最大阶数 = (当前类型 == 背包类型.灵矿 || 当前类型 == 背包类型.装备) ? 10 : 0;
        for (int i = 0; i <= 最大阶数; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/Window/灵矿场/阶数Item");
            var item = Instantiate(prefab, 阶数下拉区域Content.transform).GetComponent<阶数Item>();
            item.阶数 = i;
            item.SetItem();
        }

        GameObject 品质prefab = Resources.Load<GameObject>("Prefabs/Window/灵矿场/品质Item");
        if (当前类型 == 背包类型.宝箱)
        {
            // 宝箱品质筛选：所有/普通/卓越/至尊
            创建品质Item(品质prefab, -1, "所有");
            创建品质Item(品质prefab, (int)宝箱品质.普通, "普通");
            创建品质Item(品质prefab, (int)宝箱品质.卓越, "卓越");
            创建品质Item(品质prefab, (int)宝箱品质.至尊, "至尊");
        }
        else
        {
            // 灵矿/装备/宝物品质筛选：所有/普通/稀有/罕见/神话/永恒
            创建品质Item(品质prefab, QualityType.None, "所有");
            foreach (var 品质Type in 五种品质)
            {
                创建品质Item(品质prefab, 品质Type, Get品质显示名(品质Type));
            }
        }
    }

    private void 创建品质Item(GameObject prefab, QualityType 品质Type, string 显示名)
    {
        var item = Instantiate(prefab, 品质下拉区域Content.transform).GetComponent<品质Item>();
        item.QualityType = 品质Type;
        item.显示名 = 显示名;
        item.SetItem();
    }

    private void 创建品质Item(GameObject prefab, int 宝箱品质值, string 显示名)
    {
        var item = Instantiate(prefab, 品质下拉区域Content.transform).GetComponent<品质Item>();
        item.是宝箱 = true;
        item.宝箱品质值 = 宝箱品质值;
        item.显示名 = 显示名;
        item.SetItem();
    }

    private static string Get品质显示名(QualityType 品质Type)
    {
        switch (品质Type)
        {
            case QualityType.黄品: return "普通";
            case QualityType.地品: return "稀有";
            case QualityType.宇品: return "罕见";
            case QualityType.洪品: return "神话";
            case QualityType.荒品: return "永恒";
            default: return PropConfig.QualityNameDic[品质Type];
        }
    }

    private void 打开下拉(GameObject 下拉区域)
    {
        下拉区域mask.gameObject.SetActive(true);
        阶数下拉区域.SetActive(false);
        品质下拉区域.SetActive(false);
        排序下拉区域.SetActive(false);
        下拉区域.SetActive(true);
    }

    private void 关闭下拉()
    {
        阶数下拉区域.SetActive(false);
        品质下拉区域.SetActive(false);
        排序下拉区域.SetActive(false);
        下拉区域mask.gameObject.SetActive(false);
    }

    private void 切换类型(背包类型 类型)
    {
        if (当前类型 == 类型) return;

        当前类型 = 类型;
        阶数筛选 = 0;
        品质筛选 = QualityType.None;
        宝箱品质筛选 = -1;
        排序类型 = 0;
        当前页 = 1;
        当前选中 = null;
        Init筛选();
        刷新界面();
    }

    private void 刷新界面()
    {
        刷新类型按钮();
        刷新筛选文字();
        收集条目();
        排序条目();
        刷新背包();
    }

    private void 刷新类型按钮()
    {
        灵矿Button.image.sprite = 当前类型 == 背包类型.灵矿 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
        装备Button.image.sprite = 当前类型 == 背包类型.装备 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
        宝箱Button.image.sprite = 当前类型 == 背包类型.宝箱 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
        宝物Button.image.sprite = 当前类型 == 背包类型.宝物 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
    }

    private void 刷新筛选文字()
    {
        阶数筛选Button.GetComponentInChildren<TextMeshProUGUI>().text = 阶数筛选 == 0
            ? "所有"
            : PlayerData.S.Get阶数string(阶数筛选);
        品质筛选Button.GetComponentInChildren<TextMeshProUGUI>().text = 当前类型 == 背包类型.宝箱
            ? (宝箱品质筛选 < 0 ? "所有" : ((宝箱品质)宝箱品质筛选).ToString())
            : (品质筛选 == QualityType.None ? "所有" : Get品质显示名(品质筛选));
        排序Button.GetComponentInChildren<TextMeshProUGUI>().text =
            排序类型 == 0 ? "所有" : 排序类型 == 1 ? "品质" : "阶数";
    }

    private void 收集条目()
    {
        条目列表.Clear();
        switch (当前类型)
        {
            case 背包类型.灵矿:
                收集灵矿();
                break;
            case 背包类型.装备:
                收集装备();
                break;
            case 背包类型.宝箱:
                收集宝箱();
                break;
            case 背包类型.宝物:
                收集宝物();
                break;
        }
    }

    private void 收集灵矿()
    {
        for (int 阶 = 1; 阶 <= 10; 阶++)
        {
            if (阶数筛选 > 0 && 阶 != 阶数筛选) continue;

            foreach (var 品质Type in 五种品质)
            {
                if (品质筛选 != QualityType.None && 品质Type != 品质筛选) continue;

                int 数量 = PlayerData.S.Get灵矿数量(阶, 品质Type);
                if (数量 <= 0) continue;

                条目列表.Add(new 背包条目
                {
                    类型 = 背包类型.灵矿,
                    阶数 = 阶,
                    品质 = 品质Type,
                    数量 = 数量,
                });
            }
        }
    }

    private void 收集装备()
    {
        foreach (var 装备 in PlayerData.S.矿工装备列表)
        {
            if (装备 == null || 装备.矿工装备Type == 矿工装备Type.None) continue;
            if (阶数筛选 > 0 && 装备.阶数 != 阶数筛选) continue;
            if (品质筛选 != QualityType.None && 装备.QualityType != 品质筛选) continue;

            条目列表.Add(new 背包条目
            {
                类型 = 背包类型.装备,
                阶数 = 装备.阶数,
                品质 = 装备.QualityType,
                数量 = 1,
                装备 = 装备,
            });
        }
    }

    private void 收集宝箱()
    {
        foreach (宝箱品质 品质Type in Enum.GetValues(typeof(宝箱品质)))
        {
            if (宝箱品质筛选 >= 0 && (int)品质Type != 宝箱品质筛选) continue;

            int 数量 = PlayerData.S.Get宝箱数量(品质Type);
            if (数量 <= 0) continue;

            条目列表.Add(new 背包条目
            {
                类型 = 背包类型.宝箱,
                品质 = 宝箱对应品质(品质Type),
                宝箱品质 = 品质Type,
                数量 = 数量,
            });
        }
    }

    private void 收集宝物()
    {
        int 宝物类型数量 = Enum.GetValues(typeof(宝物Type)).Length;
        for (int i = 1; i < 宝物类型数量; i++)
        {
            var 宝物Type = (宝物Type)i;
            foreach (var 品质Type in 五种品质)
            {
                if (品质筛选 != QualityType.None && 品质Type != 品质筛选) continue;

                int 数量 = PlayerData.S.Get宝物数量(宝物Type, 品质Type);
                if (数量 <= 0) continue;

                条目列表.Add(new 背包条目
                {
                    类型 = 背包类型.宝物,
                    品质 = 品质Type,
                    数量 = 数量,
                    宝物 = new 宝物 { 宝物Type = 宝物Type, QualityType = 品质Type },
                });
            }
        }
    }

    private void 排序条目()
    {
        条目列表.Sort((a, b) =>
        {
            if (排序类型 == 2)
            {
                int 阶数比较 = b.阶数.CompareTo(a.阶数);
                if (阶数比较 != 0) return 阶数比较;
                return b.品质.CompareTo(a.品质);
            }

            // 默认/品质排序：品质降序，品质相同则阶数高的在前
            int 品质比较 = b.品质.CompareTo(a.品质);
            if (品质比较 != 0) return 品质比较;
            return b.阶数.CompareTo(a.阶数);
        });
    }

    private void 刷新背包()
    {
        foreach (var 格子 in 格子列表)
        {
            if (格子 != null) Destroy(格子);
        }
        格子列表.Clear();

        int 总页数 = Mathf.Max(1, Mathf.CeilToInt(条目列表.Count / (float)每页数量));
        当前页 = Mathf.Clamp(当前页, 1, 总页数);
        num.text = 当前页 + "/" + 总页数;

        if (当前选中 != null && !条目列表.Contains(当前选中)) 当前选中 = null;
        if (当前选中 == null && 条目列表.Count > 0) 当前选中 = 条目列表[0];

        int 开始索引 = (当前页 - 1) * 每页数量;
        int 本页数量 = Mathf.Min(每页数量, 条目列表.Count - 开始索引);
        for (int i = 0; i < 本页数量; i++)
        {
            var 格子 = 创建格子(条目列表[开始索引 + i]);
            if (格子 != null) 格子列表.Add(格子);
        }

        刷新信息();
    }

    private GameObject 创建格子(背包条目 条目)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Window/灵矿场/" + GetPrefab名(条目.类型));
        if (prefab == null) return null;

        GameObject 格子 = Instantiate(prefab, 背包.transform);
        bool 选中中 = 条目 == 当前选中;

        switch (条目.类型)
        {
            case 背包类型.灵矿:
                var 灵矿Grid = 格子.GetComponent<灵矿Grid>();
                灵矿Grid.阶数值 = 条目.阶数;
                灵矿Grid.品质 = 条目.品质;
                灵矿Grid.SetItem();
                灵矿Grid.选中.SetActive(选中中);
                break;
            case 背包类型.装备:
                var 装备Grid = 格子.GetComponent<矿工装备Grid>();
                装备Grid.矿工装备 = 条目.装备;
                装备Grid.SetItem();
                装备Grid.选中.SetActive(选中中);
                break;
            case 背包类型.宝箱:
                var 宝箱Grid = 格子.GetComponent<宝箱Grid>();
                宝箱Grid.品质 = 条目.宝箱品质;
                宝箱Grid.数量 = 条目.数量;
                宝箱Grid.SetItem();
                宝箱Grid.选中.SetActive(选中中);
                break;
            case 背包类型.宝物:
                var 宝物Grid = 格子.GetComponent<宝物Grid>();
                宝物Grid.宝物 = 条目.宝物;
                宝物Grid.SetItem();
                宝物Grid.选中.SetActive(选中中);
                break;
        }

        return 格子;
    }

    private void 刷新信息()
    {
        if (当前选中 == null)
        {
            右panel.SetActive(false);
            return;
        }
        右panel.SetActive(true);
        数量.text = PlayerData.S.格式化数字(当前选中.数量);
        switch (当前选中.类型)
        {
            case 背包类型.灵矿:
                var 灵矿配置 = 灵矿场Config.灵矿配置表[当前选中.阶数];
                icon.sprite = ResourcesConfig.Get灵矿Sprite(当前选中.阶数, 当前选中.品质);
                name.text = 灵矿配置.名称;
                标签.text = "灵矿·" + PlayerData.S.Get阶数string(当前选中.阶数);
                描述.text = 灵矿配置.介绍;
                品质.text = PropConfig.QualityNameDic[当前选中.品质];
                break;
            case 背包类型.装备:
                icon.sprite = ResourcesConfig.Get矿工装备Sprite(当前选中.装备.矿工装备Type, 当前选中.装备.阶数);
                name.text = 灵矿场Config.Get装备名称(当前选中.装备.矿工装备Type, 当前选中.装备.阶数);
                标签.text = "装备·" + PlayerData.S.Get阶数string(当前选中.装备.阶数);
                描述.text = 灵矿场Config.Get装备介绍(当前选中.装备.矿工装备Type, 当前选中.装备.阶数);
                品质.text = PropConfig.QualityNameDic[当前选中.装备.QualityType];
                break;
            case 背包类型.宝箱:
                icon.sprite = ResourcesConfig.Get宝箱Sprite(当前选中.宝箱品质);
                name.text = 当前选中.宝箱品质 + "宝箱";
                标签.text = "宝箱";
                描述.text = 灵矿场Config.宝箱介绍[当前选中.宝箱品质];
                品质.text = 当前选中.宝箱品质.ToString();
                break;
            case 背包类型.宝物:
                icon.sprite = ResourcesConfig.Get宝物Sprite(当前选中.宝物.宝物Type);
                name.text = 灵矿场Config.宝物名[当前选中.宝物.宝物Type];
                标签.text = "宝物";
                描述.text = 灵矿场Config.宝物描述[当前选中.宝物.宝物Type];
                品质.text = PropConfig.QualityNameDic[当前选中.宝物.QualityType];
                break;
        }
    }

    private void 分解当前选中()
    {
        if (当前选中 == null)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "请选择要分解的物品");
            return;
        }

        ObserverModuleManager.S.SendEvent("矿工背包分解", 当前选中.类型.ToString(), 当前选中.装备, 当前选中.宝物);
    }

    private void 矿工背包品质筛选(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;

        品质筛选 = (QualityType)obj[0];
        当前页 = 1;
        关闭下拉();
        刷新界面();
    }

    private void 矿工背包宝箱品质筛选(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;

        宝箱品质筛选 = (int)obj[0];
        当前页 = 1;
        关闭下拉();
        刷新界面();
    }

    private void 矿工背包阶数筛选(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;

        阶数筛选 = (int)obj[0];
        当前页 = 1;
        关闭下拉();
        刷新界面();
    }

    private void 灵矿Grid点击(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;

        var grid = obj[0] as 灵矿Grid;
        if (grid == null) return;

        当前选中 = 条目列表.Find(item => item.类型 == 背包类型.灵矿 && item.阶数 == grid.阶数值 && item.品质 == grid.品质);
        刷新信息();
    }

    private void 矿工装备Grid点击(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;

        var grid = obj[0] as 矿工装备Grid;
        if (grid == null) return;

        当前选中 = 条目列表.Find(item => item.类型 == 背包类型.装备 && item.装备 == grid.矿工装备);
        刷新信息();
    }

    private void 宝箱Grid点击(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;

        var grid = obj[0] as 宝箱Grid;
        if (grid == null) return;

        当前选中 = 条目列表.Find(item => item.类型 == 背包类型.宝箱 && item.宝箱品质 == grid.品质);
        刷新信息();
    }

    private void 宝物Grid点击(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;

        var grid = obj[0] as 宝物Grid;
        if (grid == null) return;

        当前选中 = 条目列表.Find(item => item.类型 == 背包类型.宝物 &&
                                          item.宝物.宝物Type == grid.宝物.宝物Type &&
                                          item.宝物.QualityType == grid.宝物.QualityType);
        刷新信息();
    }

    private static string GetPrefab名(背包类型 类型)
    {
        switch (类型)
        {
            case 背包类型.灵矿:
                return "灵矿Grid";
            case 背包类型.装备:
                return "矿工装备Grid";
            case 背包类型.宝箱:
                return "宝箱Grid";
            default:
                return "宝物Grid";
        }
    }

    private static QualityType 宝箱对应品质(宝箱品质 品质Type)
    {
        switch (品质Type)
        {
            case 宝箱品质.卓越:
                return QualityType.洪品;
            case 宝箱品质.至尊:
                return QualityType.荒品;
            default:
                return QualityType.地品;
        }
    }
}
