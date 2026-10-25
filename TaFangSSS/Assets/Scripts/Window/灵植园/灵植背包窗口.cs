using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 灵植背包窗口 : MonoBehaviour
{
    public Button mask;
    public GameObject 背包;

    public Button 作物Button;
    public Button 种子Button;
    public Button 肥料Button;

    public Button 左翻页;
    public Button 右翻页;
    public TextMeshProUGUI 页数;

    private const int 每页个数 = 24;
    private readonly List<灵植背包item数据> 当前列表 = new List<灵植背包item数据>();
    private 灵植背包物品Type 当前类型 = 灵植背包物品Type.作物;
    private int 当前页数 = 1;

    private void OnEnable()
    {
        当前页数 = 1;
        Show背包();
    }

    private void Start()
    {
        mask.onClick.AddListener(() => { gameObject.SetActive(false); });

        作物Button.onClick.AddListener(() => { 当前类型 = 灵植背包物品Type.作物; 当前页数 = 1; Show背包(); });
        种子Button.onClick.AddListener(() => { 当前类型 = 灵植背包物品Type.种子; 当前页数 = 1; Show背包(); });
        肥料Button.onClick.AddListener(() => { 当前类型 = 灵植背包物品Type.肥料; 当前页数 = 1; Show背包(); });

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
        刷新Tab样式();

        收集当前类型数据();

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
            var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植背包item"), 背包.transform)
                .GetComponent<灵植背包item>();
            var 数据 = 当前列表[开始 + i];
            item.物品类型 = 数据.物品类型;
            item.灵植Tyep = 数据.灵植Tyep;
            item.肥料Tyep = 数据.肥料Tyep;
            item.QualityType = 数据.QualityType;
            item.是否变异 = 数据.是否变异;
            item.SetItem();
        }

        页数.text = 当前页数.ToString();
    }

    private void 收集当前类型数据()
    {
        当前列表.Clear();

        switch (当前类型)
        {
            case 灵植背包物品Type.作物:
                // 普通作物（数量>0 才显示）
                foreach (var pair in PlayerData.S.普通收获Dic)
                {
                    if (pair.Value > 0)
                    {
                        当前列表.Add(new 灵植背包item数据()
                        {
                            物品类型 = 灵植背包物品Type.作物,
                            灵植Tyep = pair.Key,
                            是否变异 = false,
                        });
                    }
                }
                // 变异作物
                foreach (var pair in PlayerData.S.变异收获Dic)
                {
                    if (pair.Value > 0)
                    {
                        当前列表.Add(new 灵植背包item数据()
                        {
                            物品类型 = 灵植背包物品Type.作物,
                            灵植Tyep = pair.Key,
                            是否变异 = true,
                        });
                    }
                }
                按品质排序();
                break;

            case 灵植背包物品Type.种子:
                foreach (var pair in PlayerData.S.种子Dic)
                {
                    if (pair.Value > 0)
                    {
                        当前列表.Add(new 灵植背包item数据()
                        {
                            物品类型 = 灵植背包物品Type.种子,
                            灵植Tyep = pair.Key,
                        });
                    }
                }
                按品质排序();
                break;

            case 灵植背包物品Type.肥料:
                // 品质从高到低，类型 1~4
                for (int i = (int)QualityType.荒品; i >= (int)QualityType.黄品; i--)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        var 类型 = (肥料Type)j;
                        var 品质 = (QualityType)i;
                        if (PlayerData.S.Get肥料数量(类型, 品质) > 0)
                        {
                            当前列表.Add(new 灵植背包item数据()
                            {
                                物品类型 = 灵植背包物品Type.肥料,
                                肥料Tyep = 类型,
                                QualityType = 品质,
                            });
                        }
                    }
                }
                break;
        }
    }

    private void 按品质排序()
    {
        当前列表.Sort((a, b) =>
        {
            QualityType qa = a.物品类型 == 灵植背包物品Type.肥料 ? a.QualityType : 灵植园Config.灵植品质Dic[a.灵植Tyep];
            QualityType qb = b.物品类型 == 灵植背包物品Type.肥料 ? b.QualityType : 灵植园Config.灵植品质Dic[b.灵植Tyep];
            return qb.CompareTo(qa);
        });
    }

    private void 刷新Tab样式()
    {
        作物Button.image.sprite = 当前类型 == 灵植背包物品Type.作物 ? ResourcesConfig.红按钮 : ResourcesConfig.黑按钮;
        种子Button.image.sprite = 当前类型 == 灵植背包物品Type.种子 ? ResourcesConfig.红按钮 : ResourcesConfig.黑按钮;
        肥料Button.image.sprite = 当前类型 == 灵植背包物品Type.肥料 ? ResourcesConfig.红按钮 : ResourcesConfig.黑按钮;
    }
}

public class 灵植背包item数据
{
    public 灵植背包物品Type 物品类型;
    public 灵植Type 灵植Tyep;
    public 肥料Type 肥料Tyep;
    public QualityType QualityType;
    public bool 是否变异;
}
