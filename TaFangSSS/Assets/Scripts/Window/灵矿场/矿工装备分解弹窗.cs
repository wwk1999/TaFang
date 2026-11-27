using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工装备分解弹窗 : MonoBehaviour
{
    // 品质5种：黄品(普通)/地品(稀有)/宇品(罕见)/洪品(神话)/荒品(永恒)
    public Button[] 品质Button = new Button[5];
    // 阶数10种：1~10
    public Button[] 阶数Button = new Button[10];
    public Button 分解Button;
    public Button maskButton;
   

    private static readonly QualityType[] 品质映射 =
    {
        QualityType.黄品, QualityType.地品, QualityType.宇品, QualityType.洪品, QualityType.荒品
    };

    private static readonly string[] 品质显示名 = { "普通", "稀有", "罕见", "神话", "永恒" };

    private static readonly string[] 阶数显示名 =
    {
        "一阶", "二阶", "三阶", "四阶", "五阶", "六阶", "七阶", "八阶", "九阶", "十阶"
    };

    // 未勾选时勾选框 icon 的透明度（已不用，保留占位）
    private const float 未勾选透明度 = 0.35f;

    private void OnEnable()
    {
        刷新Button显示名();
        从存档恢复筛选();
        刷新预估();
    }

    private void Start()
    {
        for (int i = 0; i < 品质Button.Length; i++)
        {
            int idx = i;
            品质Button[i].onClick.AddListener(() => 品质勾选翻转(idx));
        }
        for (int i = 0; i < 阶数Button.Length; i++)
        {
            int idx = i;
            阶数Button[i].onClick.AddListener(() => 阶数勾选翻转(idx));
        }
        分解Button.onClick.AddListener(执行分解);
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    private void 刷新Button显示名()
    {
        for (int i = 0; i < 品质Button.Length; i++)
        {
            var text = 品质Button[i].GetComponentInChildren<TextMeshProUGUI>();
            if (text != null) text.text = 品质显示名[i];
        }
        for (int i = 0; i < 阶数Button.Length; i++)
        {
            var text = 阶数Button[i].GetComponentInChildren<TextMeshProUGUI>();
            if (text != null) text.text = 阶数显示名[i];
        }
    }

    private void 从存档恢复筛选()
    {
        for (int i = 0; i < 品质Button.Length; i++)
            设置Button勾选(品质Button[i],
                i < PlayerData.S.装备分解品质筛选.Length && PlayerData.S.装备分解品质筛选[i]);
        for (int i = 0; i < 阶数Button.Length; i++)
            设置Button勾选(阶数Button[i],
                i < PlayerData.S.装备分解阶数筛选.Length && PlayerData.S.装备分解阶数筛选[i]);
    }

    /// <summary>设置按钮勾选状态，直接改 Button.image.sprite</summary>
    private void 设置Button勾选(Button btn, bool 勾选)
    {
        btn.image.sprite = 勾选 ? ResourcesConfig.灵矿场勾选框亮 : ResourcesConfig.灵矿场勾选框暗;
    }

    private bool 读品质勾选(int 索引)
    {
        return 索引 < PlayerData.S.装备分解品质筛选.Length
               && PlayerData.S.装备分解品质筛选[索引];
    }

    private bool 读阶数勾选(int 索引)
    {
        return 索引 < PlayerData.S.装备分解阶数筛选.Length
               && PlayerData.S.装备分解阶数筛选[索引];
    }

    private void 品质勾选翻转(int 索引)
    {
        bool 新值 = !读品质勾选(索引);
        PlayerData.S.装备分解品质筛选[索引] = 新值;
        设置Button勾选(品质Button[索引], 新值);
        刷新预估();
    }

    private void 阶数勾选翻转(int 索引)
    {
        bool 新值 = !读阶数勾选(索引);
        PlayerData.S.装备分解阶数筛选[索引] = 新值;
        设置Button勾选(阶数Button[索引], 新值);
        刷新预估();
    }

    /// <summary>当前勾选的品质是否包含给定品质</summary>
    private bool 品质勾选(QualityType q)
    {
        for (int i = 0; i < 品质映射.Length; i++)
            if (品质映射[i] == q)
                return 读品质勾选(i);
        return false;
    }

    /// <summary>当前勾选的阶数是否包含给定阶数(1~10)</summary>
    private bool 阶数勾选(int 阶数)
    {
        int idx = 阶数 - 1;
        if (idx < 0 || idx >= 10) return false;
        return 读阶数勾选(idx);
    }

    private void 刷新预估()
    {
        float 预估 = 计算预估粉尘();
    }

    /// <summary>遍历矿工装备列表，按筛选条件计算总粉尘（含跳过锁与已穿戴装备）</summary>
    private float 计算预估粉尘()
    {
        float 总计 = 0;
        foreach (var 装备 in PlayerData.S.矿工装备列表)
        {
            if (装备 == null) continue;
            if (装备.锁) continue;
            if (装备.矿工 != null) continue;
            if (!品质勾选(装备.QualityType)) continue;
            if (!阶数勾选(装备.阶数)) continue;
            总计 += 灵矿场Config.Get装备分解粉尘(装备.阶数, 装备.QualityType);
        }
        return 总计;
    }

    private void 执行分解()
    {
        // 收集要分解的装备索引（倒序移除避免索引错位）
        var 待分解索引 = new List<int>();
        float 总粉尘 = 0;
        int 装备数 = 0;

        for (int i = 0; i < PlayerData.S.矿工装备列表.Count; i++)
        {
            var 装备 = PlayerData.S.矿工装备列表[i];
            if (装备 == null) continue;
            if (装备.锁) continue;
            if (装备.矿工 != null) continue;
            if (!品质勾选(装备.QualityType)) continue;
            if (!阶数勾选(装备.阶数)) continue;

            待分解索引.Add(i);
            总粉尘 += 灵矿场Config.Get装备分解粉尘(装备.阶数, 装备.QualityType);
            装备数++;
        }

        if (装备数 == 0)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "没有符合条件的装备可分解");
            return;
        }

        // 倒序移除
        for (int i = 待分解索引.Count - 1; i >= 0; i--)
            PlayerData.S.矿工装备列表.RemoveAt(待分解索引[i]);

        PlayerData.S.矿工粉尘 += 总粉尘;

        ObserverModuleManager.S.SendEvent("刷新矿工背包");
        ObserverModuleManager.S.SendEvent("SendUIToast",
            $"分解装备 x{装备数}，获得矿工粉尘 {PlayerData.S.格式化数字((int)总粉尘)}");

        刷新预估();
        gameObject.SetActive(false);
    }
}
