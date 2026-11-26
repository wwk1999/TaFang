using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 灵矿场界面 : MonoBehaviour
{
    public GameObject 矿工content;
    public Button exitButton;
    public Button 详情Button;
    public TextMeshProUGUI 灵石Count;

    //开采信息
    public TextMeshProUGUI 当前层;
    public TextMeshProUGUI 当前米;
    public TextMeshProUGUI 下一层米数;
    public TextMeshProUGUI 当前灵矿;
    public TextMeshProUGUI 挖掘速度;
    public TextMeshProUGUI 灵石收益;

    //按钮
    public Button 招募Button;
    public Button 矿工Button;
    public Button 矿洞Button;
    public Button 背包Button;
    public Button 宝物Button;

    public Button 返回领地Button;
    
    //弹窗
    public GameObject 招募界面;
    public GameObject 矿工界面;
    public GameObject 矿洞界面;
    public GameObject 背包界面;
    public GameObject 宝物界面;
    public GameObject 详情界面;
    //背景
    public GameObject 背景1;
    public GameObject 背景2;
    public GameObject 背景3;
    public GameObject 背景4;
    public GameObject 背景5;
    public GameObject 背景6;
    public GameObject 背景7;
    public GameObject 背景8;
    public GameObject 背景9;
    public GameObject 背景10;
    
    public GameObject 土层1;
    public GameObject 土层2;
    public GameObject 土层3;
    public GameObject 土层4;
    public GameObject 土层5;
    public GameObject 土层6;
    public GameObject 土层7;
    public GameObject 土层8;
    public GameObject 土层9;
    public GameObject 土层10;

    private void OnEnable()
    {
        Show矿工();
        刷新灵石();
        Show背景土层();
        Show开采信息();
    }

    public void 刷新开采信息(object[] obj)
    {
        刷新灵石();
        Show开采信息();
        Show背景土层();
    }

    public void Show矿工()
    {
        foreach (Transform item in 矿工content.transform)
        {
            Destroy(item.gameObject);
        }

        List<矿工item> 矿工item列表 = new List<矿工item>();
        foreach (var item in PlayerData.S.矿工列表)
        {
            var 矿工 = Instantiate(Resources.Load("Prefabs/Window/灵矿场/矿工item"), 矿工content.transform)
                .GetComponent<矿工item>();
            矿工.矿工 = item;
            矿工.SetItem();
            矿工item列表.Add(矿工);
        }

        Set矿工随机位置(矿工item列表);
    }

    private void Set矿工随机位置(List<矿工item> items)
    {
        const float 左边界 = -900f;
        const float 右边界 = 900f;
        const float 最小间距 = 100f;

        int 数量 = items.Count;
        if (数量 == 0) return;

        float 总宽度 = 右边界 - 左边界;
        float 可用宽度 = 总宽度 - (数量 - 1) * 最小间距;

        // 人数过多，无法保证最小间距时退化为均匀分布
        if (可用宽度 < 0)
        {
            float 间距 = 总宽度 / Mathf.Max(1, 数量 - 1);
            for (int i = 0; i < 数量; i++)
            {
                items[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(左边界 + i * 间距, 0);
            }
            return;
        }

        // 在剩余空间内随机偏移并排序，保证相邻 x 间距不小于 100
        float[] 偏移 = new float[数量];
        for (int i = 0; i < 数量; i++)
        {
            偏移[i] = Random.Range(0f, 可用宽度);
        }
        Array.Sort(偏移);

        for (int i = 0; i < 数量; i++)
        {
            float x = 左边界 + i * 最小间距 + 偏移[i];
            items[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("矿工解雇",矿工解雇);
        ObserverModuleManager.S.UnRegisterEvent("矿工招募",矿工招募);
        ObserverModuleManager.S.UnRegisterEvent("刷新开采信息",刷新开采信息);
    }

    public void 矿工招募(object[] obj)
    {
        Show矿工();
    }

    public void 矿工解雇(object[] obj)
    {
        Show矿工();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("矿工解雇",矿工解雇);
        ObserverModuleManager.S.RegisterEvent("矿工招募",矿工招募);
        ObserverModuleManager.S.RegisterEvent("刷新开采信息",刷新开采信息);
        if (PlayerData.S.是否首次进入灵矿场)
        {
            ObserverModuleManager.S.SendEvent("剧情对话",200,新手对话Type.灵矿场);
            PlayerData.S.是否首次进入灵矿场=false;
        }
        详情Button.onClick.AddListener(() =>
        {
            详情界面.SetActive(false);
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        返回领地Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        招募Button.onClick.AddListener(() =>
        {
            招募界面.gameObject.SetActive(true);
        });
        
        矿工Button.onClick.AddListener(() =>
        {
            矿工界面.gameObject.SetActive(true);
        });
        
        矿洞Button.onClick.AddListener(() =>
        {
            矿洞界面.gameObject.SetActive(true);
        });
        
        背包Button.onClick.AddListener(() =>
        {
            背包界面.gameObject.SetActive(true);
        });
        
        宝物Button.onClick.AddListener(() =>
        {
            宝物界面.gameObject.SetActive(true);
        });
    }

    public void 刷新灵石()
    {
        灵石Count.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.灵石]);
    }
    public void Show背景土层()
    {
        土层Type 土层Type = 灵矿场Config.Get当前层();
        土层1.gameObject.SetActive(土层Type==土层Type.黑土浅层);
        土层2.gameObject.SetActive(土层Type==土层Type.岩石矿层);
        土层3.gameObject.SetActive(土层Type==土层Type.赤铜矿层);
        土层4.gameObject.SetActive(土层Type==土层Type.玄铁深层);
        土层5.gameObject.SetActive(土层Type==土层Type.金玉灵层);
        土层6.gameObject.SetActive(土层Type==土层Type.紫晶幻层);
        土层7.gameObject.SetActive(土层Type==土层Type.地火熔层);
        土层8.gameObject.SetActive(土层Type==土层Type.深渊暗层);
        土层9.gameObject.SetActive(土层Type==土层Type.归墟混元层);
        土层10.gameObject.SetActive(土层Type==土层Type.太初本源层);
        
        背景1.gameObject.SetActive(土层Type==土层Type.黑土浅层);
        背景2.gameObject.SetActive(土层Type==土层Type.岩石矿层);
        背景3.gameObject.SetActive(土层Type==土层Type.赤铜矿层);
        背景4.gameObject.SetActive(土层Type==土层Type.玄铁深层);
        背景5.gameObject.SetActive(土层Type==土层Type.金玉灵层);
        背景6.gameObject.SetActive(土层Type==土层Type.紫晶幻层);
        背景7.gameObject.SetActive(土层Type==土层Type.地火熔层);
        背景8.gameObject.SetActive(土层Type==土层Type.深渊暗层);
        背景9.gameObject.SetActive(土层Type==土层Type.归墟混元层);
        背景10.gameObject.SetActive(土层Type==土层Type.太初本源层);
    }
    public void Show开采信息()
    {
        当前层.text = 灵矿场Config.土层名称[灵矿场Config.Get当前层()];
        当前米.text = PlayerData.S.格式化数字(PlayerData.S.灵矿场当前米数) + "米";
        下一层米数.text = 灵矿场Config.土层米数[灵矿场Config.Get当前层() + 1] + "米";
        当前灵矿.text = 灵矿场Config.灵矿配置表[(int)灵矿场Config.Get当前层()].名称;
        挖掘速度.text = PlayerData.S.格式化数字(灵矿场Config.Get总挖掘速度())+"/每道年";
        灵石收益.text = PlayerData.S.格式化数字(灵矿场Config.Get总固定收益())+"/每道年";
    }
}
