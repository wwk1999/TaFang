using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 娲皇秘宝宝库 : MonoBehaviour
{
    public Button maskButton;
    public GameObject content;
    public Button 左箭头;
    public Button 右箭头;
    public TextMeshProUGUI num;
    public TextMeshProUGUI 气运;

    // 每页固定显示27个秘宝
    private const int 每页数量 = 27;

    private int 页数 = 1;
    private int 最大页数 = 1;
    private readonly List<秘宝> 秘宝列表 = new List<秘宝>();

    private void Awake()
    {
        构建秘宝列表();
    }

    public void 刷新娲皇秘宝宝库(object[] obj)
    {
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新娲皇秘宝宝库",刷新娲皇秘宝宝库);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新娲皇秘宝宝库",刷新娲皇秘宝宝库);
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        左箭头.onClick.AddListener(() =>
        {
            if (页数 <= 1)
            {
                return;
            }

            Show(页数 - 1);
        });
        右箭头.onClick.AddListener(() =>
        {
            if (页数 >= 最大页数)
            {
                return;
            }

            Show(页数 + 1);
        });
    }

    // 秘宝类型固定，只在启动时构建一次，翻页时直接复用，避免重复遍历枚举
    private void 构建秘宝列表()
    {
        秘宝列表.Clear();
        for (int i = 1; i < Enum.GetValues(typeof(秘宝Type)).Length; i++)
        {
            秘宝Type 秘宝类型 = (秘宝Type)i;
            if (秘宝类型 == 秘宝Type.暴击次数)
            {
                // 暴击次数每个地点只有一个，不区分等级
                var 暴击次数秘宝 = new 秘宝();
                暴击次数秘宝.秘宝Type = 秘宝类型;
                暴击次数秘宝.秘宝地点 = 秘宝地点.娲皇宫;
                秘宝列表.Add(暴击次数秘宝);
                continue;
            }

            for (int j = 1; j < 5; j++)
            {
                var 秘宝数据 = new 秘宝();
                秘宝数据.秘宝Type = 秘宝类型;
                秘宝数据.秘宝地点 = 秘宝地点.娲皇宫;
                秘宝数据.等级 = j;
                秘宝列表.Add(秘宝数据);
            }
        }

        最大页数 = Mathf.Max(1, Mathf.CeilToInt(秘宝列表.Count / (float)每页数量));
        页数 = Mathf.Clamp(页数, 1, 最大页数);
    }
    
    public void Show()
    {
        Show(页数);
    }

    private void OnEnable()
    {
        Show();
    }

    public void Show(int page)
    {
        气运.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.娲皇气运]);
        if (秘宝列表.Count == 0)
        {
            构建秘宝列表();
        }

        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        页数 = Mathf.Clamp(page, 1, 最大页数);
        int start = (页数 - 1) * 每页数量;
        int end = Mathf.Min(start + 每页数量, 秘宝列表.Count);
        for (int i = start; i < end; i++)
        {
            var data = 秘宝列表[i];
            var item = Instantiate(Resources.Load("Prefabs/Window/天外天/秘宝Grid"), content.transform)
                .GetComponent<秘宝Grid>();
            item.秘宝Type = data.秘宝Type;
            item.秘宝地点 = data.秘宝地点;
            item.等级 = data.等级;
            item.SetItem();
        }

        if (num != null)
        {
            num.text = 页数.ToString();
        }
    }
}
