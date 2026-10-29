using System;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵植赠送窗口 : MonoBehaviour
{
    public Button mask;
    public GameObject 背包;

    public Button 左翻页;
    public Button 右翻页;
    public TextMeshProUGUI 页数;

    public 仙女殿界面 主界面;

    [NonSerialized] public 仙子Type 当前仙子 = 仙子Type.None;

    private const int 每页个数 = 18;
    private const int 最大好感等级 = 100;

    private readonly List<灵植赠送item数据> 当前列表 = new List<灵植赠送item数据>();
    private int 当前页数 = 1;

    private void OnEnable()
    {
        当前页数 = 1;
        Show背包();
    }

    private void Start()
    {
        mask.onClick.AddListener(() => { gameObject.SetActive(false); });

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
    }

    public void Show背包()
    {
        收集数据();

        int 总页数 = Mathf.Max(1, Mathf.CeilToInt(当前列表.Count / (float)每页个数));
        当前页数 = Mathf.Clamp(当前页数, 1, 总页数);

        清空列表(背包.transform);

        int 开始 = (当前页数 - 1) * 每页个数;
        int 数量 = Mathf.Min(每页个数, 当前列表.Count - 开始);
        for (int i = 0; i < 数量; i++)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/仙女殿/灵植赠送Item"), 背包.transform)
                .GetComponent<灵植赠送item>();
            var 数据 = 当前列表[开始 + i];
            item.窗口 = this;
            item.灵植Tyep = 数据.灵植Type;
            item.是否变异 = 数据.是否变异;
            item.SetItem();
        }

        页数.text = 当前页数.ToString();
    }

    private void 收集数据()
    {
        当前列表.Clear();

        foreach (var pair in PlayerData.S.普通收获Dic)
        {
            if (pair.Value > 0)
            {
                当前列表.Add(new 灵植赠送item数据() { 灵植Type = pair.Key, 是否变异 = false });
            }
        }

        foreach (var pair in PlayerData.S.变异收获Dic)
        {
            if (pair.Value > 0)
            {
                当前列表.Add(new 灵植赠送item数据() { 灵植Type = pair.Key, 是否变异 = true });
            }
        }

        当前列表.Sort((a, b) =>
        {
            QualityType qa = 灵植园Config.灵植品质Dic[a.灵植Type];
            QualityType qb = 灵植园Config.灵植品质Dic[b.灵植Type];
            if (qa != qb) return qb.CompareTo(qa);
            return a.是否变异.CompareTo(b.是否变异);
        });
    }

    private void 清空列表(Transform content)
    {
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            var child = content.GetChild(i).gameObject;
            child.SetActive(false);
            Destroy(child);
        }
    }

    public void 单次赠送(灵植Type 灵植Type, bool 是否变异, 灵植赠送item item)
    {
        float 数量 = Get数量(灵植Type, 是否变异);
        if (数量 < 1f) return;

        Set数量(灵植Type, 是否变异, 数量 - 1f);
        int 获得好感 = Get单次好感(灵植Type, 是否变异);
        增加好感(获得好感);

        if (Get数量(灵植Type, 是否变异) < 1f) Show背包();
        else item.SetItem();

        发送赠送Toast(灵植Type, 是否变异, 1, 获得好感);
        刷新主界面();
    }

    public void 一键赠送(灵植Type 灵植Type, bool 是否变异)
    {
        float 数量 = Get数量(灵植Type, 是否变异);
        int 份数 = Mathf.FloorToInt(数量);
        if (份数 <= 0) return;

        Set数量(灵植Type, 是否变异, 0f);
        int 单次好感 = Get单次好感(灵植Type, 是否变异);
        long 总好感 = (long)单次好感 * 份数;
        增加好感(总好感);

        Show背包();
        发送赠送Toast(灵植Type, 是否变异, 份数, 总好感);
        刷新主界面();
    }

    private void 发送赠送Toast(灵植Type 灵植Type, bool 是否变异, int 份数, long 好感)
    {
        string 名称 = (是否变异 ? "变异·" : "") + 灵植园Config.灵植名[灵植Type];
        ObserverModuleManager.S.SendEvent("SendUIToast",
            $"赠送 {名称}×{PlayerData.S.格式化数字(份数)}，好感+{PlayerData.S.格式化数字((double)好感)}");
    }

    private int Get单次好感(灵植Type 灵植Type, bool 是否变异)
    {
        int 基础 = 灵植园Config.灵植赠送好感度Dic[灵植Type];
        bool 是喜好 = 阴阳殿Config.仙子喜好灵植dic[当前仙子].Contains(灵植Type);

        var 仙子加成 = 属性config.仙子总属性;
        float 倍率 = 1f + 仙子加成.好感度增加 / 100f;
        if (是喜好) 倍率 *= 2f * (1f + 仙子加成.喜好灵植额外加好感 / 100f);
        if (是否变异) 倍率 *= 灵植园Config.变异倍数 * (1f + 仙子加成.变异灵植额外加好感 / 100f);
        return Mathf.RoundToInt(基础 * 倍率);
    }

    private void 增加好感(long 获得)
    {
        if (当前仙子 == 仙子Type.None) return;

        var 仙女 = PlayerData.S.仙女Dic[当前仙子];
        if (!仙女.解锁) return;

        if (仙女.好感度等级 >= 最大好感等级)
        {
            仙女.好感度经验 = 0;
            return;
        }

        long 经验 = 仙女.好感度经验 + 获得;
        while (仙女.好感度等级 < 最大好感等级)
        {
            int 需求 = 阴阳殿Config.Get好感度升级经验(仙女.好感度等级);
            if (需求 <= 0 || 经验 < 需求) break;
            经验 -= 需求;
            仙女.好感度等级++;
        }

        仙女.好感度经验 = 仙女.好感度等级 >= 最大好感等级 ? 0 : (int)经验;
    }

    private static float Get数量(灵植Type 灵植Type, bool 是否变异)
    {
        return 是否变异
            ? PlayerData.S.变异收获Dic[灵植Type]
            : PlayerData.S.普通收获Dic[灵植Type];
    }

    private static void Set数量(灵植Type 灵植Type, bool 是否变异, float 数量)
    {
        if (是否变异) PlayerData.S.变异收获Dic[灵植Type] = 数量;
        else PlayerData.S.普通收获Dic[灵植Type] = 数量;
    }

    private void 刷新主界面()
    {
        if (主界面 != null) 主界面.刷新当前仙女信息();
    }
}

public class 灵植赠送item数据
{
    public 灵植Type 灵植Type;
    public bool 是否变异;
}
