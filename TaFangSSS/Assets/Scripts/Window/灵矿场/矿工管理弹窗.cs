using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工管理弹窗 : MonoBehaviour
{
    public Button 升星Button;
    public Button 解雇Button;

    public TextMeshProUGUI 矿工升星碎片;
    public TextMeshProUGUI 矿工分解碎片;

    public 矿工改名弹窗 矿工改名弹窗;
    public GameObject 矿工信息Content;
    public TextMeshProUGUI 等级;
    public TextMeshProUGUI 当前经验;
    public TextMeshProUGUI 最大经验;
    public Image 经验进度条;
    public Button exitButton;
    public Button maskButton;
    public GameObject 矿工列表;
    public GameObject 当前装备;
    public Image 矿工立绘;
    public TextMeshProUGUI 挖掘速度;
    public TextMeshProUGUI 固定收益;
    public TextMeshProUGUI 成长速度;
    public TextMeshProUGUI 挖宝速度;
    public GameObject 特性content;
    public GameObject 背包;
    public Button 全部Button;
    public Button 罗盘Button;
    public Button 稿子Button;
    public Button 衣服Button;
    public Button 护手Button;
    public Button 左翻页;
    public Button 右翻页;
    public TextMeshProUGUI 页数;

    private const int 每页个数 = 20;
    private readonly List<矿工装备> 当前列表 = new List<矿工装备>();
    private 矿工装备Type 当前类型 = 矿工装备Type.None;
    private int 当前页数 = 1;
    [NonSerialized] public 矿工 当前矿工;
    [NonSerialized] public 矿工装备 当前选择矿工装备;

    private void OnEnable()
    {
        当前类型 = 矿工装备Type.None;
        当前页数 = 1;
        当前选择矿工装备 = null;
        if (!PlayerData.S.矿工列表.Contains(当前矿工))
        {
            当前矿工 = PlayerData.S.矿工列表.Count > 0 ? PlayerData.S.矿工列表[0] : null;
            HeroWindowController.S.矿工管理弹窗当前矿工 = 当前矿工;
        }
        刷新界面();
    }

    public void 显示矿工改名弹窗(object[] obj)
    {
        矿工改名弹窗.矿工 = obj[0] as 矿工;
        矿工改名弹窗.gameObject.SetActive(true);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("显示矿工改名弹窗",显示矿工改名弹窗);
        ObserverModuleManager.S.RegisterEvent("矿工管理Item点击", 矿工管理Item点击);
        ObserverModuleManager.S.RegisterEvent("矿工装备背包Item点击", 矿工装备背包Item点击);
        ObserverModuleManager.S.RegisterEvent("佩戴矿工装备", 佩戴矿工装备);
        ObserverModuleManager.S.RegisterEvent("卸下矿工装备", 卸下矿工装备);

        exitButton.onClick.AddListener(() => gameObject.SetActive(false));
        maskButton.onClick.AddListener(() => gameObject.SetActive(false));
        全部Button.onClick.AddListener(() => Set筛选(矿工装备Type.None));
        罗盘Button.onClick.AddListener(() => Set筛选(矿工装备Type.罗盘));
        稿子Button.onClick.AddListener(() => Set筛选(矿工装备Type.稿子));
        衣服Button.onClick.AddListener(() => Set筛选(矿工装备Type.衣服));
        护手Button.onClick.AddListener(() => Set筛选(矿工装备Type.护手));
        左翻页.onClick.AddListener(() =>
        {
            if (当前页数 <= 1) return;
            当前页数--;
            Show背包();
        });
        右翻页.onClick.AddListener(() =>
        {
            int 总页数 = Mathf.CeilToInt(当前列表.Count / (float)每页个数);
            if (当前页数 >= 总页数) return;
            当前页数++;
            Show背包();
        });
        升星Button.onClick.AddListener(() =>
        {
            if (当前矿工 == null) return;
            float 价格 = 灵矿场Config.Get矿工升星价格(当前矿工.阶数, 当前矿工.QualityType);
            if (PlayerData.S.矿工碎片 < 价格)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","矿工碎片不足");
                return;
            }

            PlayerData.S.矿工碎片 -= 价格;
            当前矿工.星级++;
            Show矿工信息();
            ObserverModuleManager.S.SendEvent("矿工升星",当前矿工);
            ObserverModuleManager.S.SendEvent("SendUIToast","升星成功");
        });
        
        解雇Button.onClick.AddListener(() =>
        {
            if (当前矿工 == null) return;
            if (当前矿工.护手 != null)
            {
                当前矿工.护手.矿工 = null;
            }
            if (当前矿工.稿子 != null)
            {
                当前矿工.稿子.矿工 = null;
            }
            if (当前矿工.罗盘 != null)
            {
                当前矿工.罗盘.矿工 = null;
            }
            if (当前矿工.衣服 != null)
            {
                当前矿工.衣服.矿工 = null;
            }
            float 价格 = 灵矿场Config.Get矿工分解价格(当前矿工.阶数, 当前矿工.QualityType);
            PlayerData.S.矿工碎片 += 价格;
            PlayerData.S.矿工列表.Remove(当前矿工);
            当前矿工 = null;
            HeroWindowController.S.矿工管理弹窗当前矿工 = null;
            Show矿工信息();
            Show矿工列表();
            Show当前装备();
            Show背包();
            ObserverModuleManager.S.SendEvent("矿工解雇");

            ObserverModuleManager.S.SendEvent("SendUIToast","解雇成功");
        });
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("显示矿工改名弹窗",显示矿工改名弹窗);
        ObserverModuleManager.S.UnRegisterEvent("矿工管理Item点击", 矿工管理Item点击);
        ObserverModuleManager.S.UnRegisterEvent("矿工装备背包Item点击", 矿工装备背包Item点击);
        ObserverModuleManager.S.UnRegisterEvent("佩戴矿工装备", 佩戴矿工装备);
        ObserverModuleManager.S.UnRegisterEvent("卸下矿工装备", 卸下矿工装备);
    }

    public void 刷新界面()
    {
        Show矿工列表();
        Show当前装备();
        Show矿工信息();
        Show背包();
    }

    public void Show矿工列表()
    {
        foreach (Transform item in 矿工列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var data in PlayerData.S.矿工列表)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/灵矿场/矿工管理item"), 矿工列表.transform)
                .GetComponent<矿工管理item>();
            item.矿工 = data;
            item.SetItem();
            item.选中.SetActive(data == 当前矿工);
        }
    }

    public void Show当前装备()
    {
        foreach (Transform item in 当前装备.transform)
        {
            if (item.GetComponent<当前装备item>() != null)
            {
                Destroy(item.gameObject);
            }
        }

        if (当前矿工 == null)
        {
            矿工立绘.gameObject.SetActive(false);
            return;
        }

        矿工立绘.gameObject.SetActive(true);
        矿工立绘.sprite = ResourcesConfig.Get矿工立绘(当前矿工.矿工类型, 当前矿工.阶数, 当前矿工.QualityType);
        Add当前装备(矿工装备Type.罗盘);
        Add当前装备(矿工装备Type.稿子);
        Add当前装备(矿工装备Type.衣服);
        Add当前装备(矿工装备Type.护手);
    }

    private void Add当前装备(矿工装备Type type)
    {
        var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/灵矿场/当前装备item"), 当前装备.transform)
            .GetComponent<当前装备item>();
        item.矿工 = 当前矿工;
        item.矿工装备 = Get装备(当前矿工, type);
        item.SetItem();
    }

    public void Show矿工信息()
    {
        foreach (Transform item in 特性content.transform)
        {
            Destroy(item.gameObject);
        }

        if (当前矿工 == null)
        {
            矿工信息Content.gameObject.SetActive(false);
            return;
        }

        矿工升星碎片.text = PlayerData.S.格式化数字(灵矿场Config.Get矿工升星价格(当前矿工.阶数, 当前矿工.QualityType));
        矿工分解碎片.text = PlayerData.S.格式化数字(灵矿场Config.Get矿工分解价格(当前矿工.阶数, 当前矿工.QualityType));
        矿工信息Content.gameObject.SetActive(true);
        等级.text = "LV."+当前矿工.等级;
        当前经验.text = PlayerData.S.格式化数字(当前矿工.经验);
        最大经验.text = PlayerData.S.格式化数字(灵矿场Config.矿工经验表[当前矿工.等级]);
        经验进度条.fillAmount = 当前矿工.经验 / 灵矿场Config.矿工经验表[当前矿工.等级];
        四维属性 属性 = 灵矿场Config.Get矿工最终四维属性(当前矿工);
        挖掘速度.text = PlayerData.S.格式化数字(属性.挖掘速度);
        固定收益.text = PlayerData.S.格式化数字(属性.固定收益);
        成长速度.text = PlayerData.S.格式化数字(属性.成长速度);
        挖宝速度.text = PlayerData.S.格式化数字(属性.挖宝时间);

        foreach (var data in 当前矿工.词条列表)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/灵矿场/矿工词条item"), 特性content.transform)
                .GetComponent<矿工词条item>();
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(150,43.5f);
            item.矿工词条类型 = data;
            item.quality = 当前矿工.QualityType;
            item.SetItem();
        }
    }

    public void Show背包()
    {
        当前列表.Clear();
        foreach (var item in PlayerData.S.矿工装备列表)
        {
            if (item != null && (当前类型 == 矿工装备Type.None || item.矿工装备Type == 当前类型))
            {
                当前列表.Add(item);
            }
        }

        当前列表.Sort((a, b) =>
        {
            int 品质比较 = b.QualityType.CompareTo(a.QualityType);
            return 品质比较 != 0 ? 品质比较 : b.阶数.CompareTo(a.阶数);
        });

        int 总页数 = Mathf.Max(1, Mathf.CeilToInt(当前列表.Count / (float)每页个数));
        当前页数 = Mathf.Clamp(当前页数, 1, 总页数);
        foreach (Transform item in 背包.transform)
        {
            Destroy(item.gameObject);
        }

        int 开始 = (当前页数 - 1) * 每页个数;
        int 数量 = Mathf.Min(每页个数, 当前列表.Count - 开始);
        for (int i = 0; i < 数量; i++)
        {
            var data = 当前列表[开始 + i];
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/灵矿场/矿工装备背包item"), 背包.transform)
                .GetComponent<矿工装备背包item>();
            item.矿工装备 = data;
            item.SetItem();
            item.选中.SetActive(data == 当前选择矿工装备);
        }

        页数.text = 当前页数.ToString();
        刷新筛选按钮();
    }

    private void Set筛选(矿工装备Type type)
    {
        当前类型 = type;
        当前页数 = 1;
        当前选择矿工装备 = null;
        Show背包();
    }

    private void 刷新筛选按钮()
    {
        全部Button.image.sprite = 当前类型 == 矿工装备Type.None ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
        罗盘Button.image.sprite = 当前类型 == 矿工装备Type.罗盘 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
        稿子Button.image.sprite = 当前类型 == 矿工装备Type.稿子 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
        衣服Button.image.sprite = 当前类型 == 矿工装备Type.衣服 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
        护手Button.image.sprite = 当前类型 == 矿工装备Type.护手 ? ResourcesConfig.灵矿场按钮亮 : ResourcesConfig.灵矿场按钮暗;
    }

    public void 矿工管理Item点击(object[] obj)
    {
        矿工 miner = obj[0] as 矿工;
        if (miner == null || !PlayerData.S.矿工列表.Contains(miner)) return;
        当前矿工 = miner;
        HeroWindowController.S.矿工管理弹窗当前矿工 = 当前矿工;
        Show当前装备();
        Show矿工信息();
    }

    public void 矿工装备背包Item点击(object[] obj)
    {
        当前选择矿工装备 = obj[0] as 矿工装备;
    }

    public void 佩戴矿工装备(object[] obj)
    {
        佩戴装备(obj[0] as 矿工装备);
    }

    public void 佩戴装备(矿工装备 装备)
    {
        if (当前矿工 == null || 装备 == null || 装备.矿工装备Type == 矿工装备Type.None) return;
        if (!PlayerData.S.矿工装备列表.Contains(装备)) return;
        if (Get装备(当前矿工, 装备.矿工装备Type) == 装备) return;

        // 同一件装备只能被一名矿工佩戴，先从其他矿工身上卸下。
        foreach (var miner in PlayerData.S.矿工列表)
        {
            if (miner == null || miner == 当前矿工) continue;
            if (Get装备(miner, 装备.矿工装备Type) != 装备) continue;
            Set装备(miner, 装备.矿工装备Type, null);
        }

        // 直接替换对应部位，旧装备仍保留在已获得装备列表中。
        矿工装备 旧装备 = Get装备(当前矿工, 装备.矿工装备Type);
        if (旧装备 != null) 旧装备.矿工 = null;
        Set装备(当前矿工, 装备.矿工装备Type, 装备);
        装备.矿工 = 当前矿工;
        当前选择矿工装备 = null;
        Show当前装备();
        Show矿工信息();
        Show背包();
        刷新开采信息();
    }

    public void 卸下矿工装备(object[] obj)
    {
        if (obj.Length < 2) return;
        卸下装备(obj[0] as 矿工, obj[1] as 矿工装备);
    }

    public void 卸下装备(矿工 miner, 矿工装备 装备)
    {
        if (miner == null || 装备 == null || 装备.矿工装备Type == 矿工装备Type.None) return;
        if (Get装备(miner, 装备.矿工装备Type) != 装备) return;

        // 装备列表保存全部已获得装备，卸下时只清空对应部位。
        Set装备(miner, 装备.矿工装备Type, null);
        装备.矿工 = null;

        if (当前矿工 == miner)
        {
            当前选择矿工装备 = 装备;
            Show当前装备();
            Show矿工信息();
            Show背包();
            刷新开采信息();
        }
    }

    private void 刷新开采信息()
    {
        灵矿场界面 界面 = GetComponentInParent<灵矿场界面>();
        if (界面 != null)
        {
            界面.Show开采信息();
        }
    }

    private static 矿工装备 Get装备(矿工 miner, 矿工装备Type type)
    {
        switch (type)
        {
            case 矿工装备Type.罗盘:
                return miner.罗盘;
            case 矿工装备Type.稿子:
                return miner.稿子;
            case 矿工装备Type.衣服:
                return miner.衣服;
            case 矿工装备Type.护手:
                return miner.护手;
        }
        return null;
    }

    private static void Set装备(矿工 miner, 矿工装备Type type, 矿工装备 装备)
    {
        switch (type)
        {
            case 矿工装备Type.罗盘:
                miner.罗盘 = 装备;
                break;
            case 矿工装备Type.稿子:
                miner.稿子 = 装备;
                break;
            case 矿工装备Type.衣服:
                miner.衣服 = 装备;
                break;
            case 矿工装备Type.护手:
                miner.护手 = 装备;
                break;
        }
    }
}
