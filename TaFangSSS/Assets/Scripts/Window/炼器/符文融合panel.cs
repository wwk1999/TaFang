using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 符文融合panel : MonoBehaviour
{
    public Button 符文筛选Button;
    public GameObject 符文筛选;
    public GameObject 符文筛选Content;
    public Button 符文筛选mask;

    public Button 品质筛选Button;
    public GameObject 品质筛选;
    public GameObject 品质筛选Content;
    public Button 品质筛选mask;

    public GameObject Content;
    public Button 左Button;
    public Button 右Button;
    public TextMeshProUGUI 页数;

    public Image 主符文Icon;
    public TextMeshProUGUI 主符文效果;
    public TextMeshProUGUI 主符文数值;
    public TextMeshProUGUI 主符文无暇;
    public Image 副符文Icon;
    public TextMeshProUGUI 副符文效果;
    public TextMeshProUGUI 副符文数值;
    public TextMeshProUGUI 副符文无暇;
    public Button 融合Button;

    public 符文融合提示弹窗 符文融合提示弹窗;
    [NonSerialized] public int 页数num = 1;

    private void OnEnable()
    {
        HeroWindowController.S.符文融合主符文 = null;
        HeroWindowController.S.符文融合副符文 = null;
        HeroWindowController.S.符文融合排序Type = 符文Type.None;
        HeroWindowController.S.符文融合品质筛选 = QualityType.None;
        页数num = 1;
        Set符文筛选();
        Set品质筛选();
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("符文融合点击", 符文融合点击);
        ObserverModuleManager.S.UnRegisterEvent("隐藏符文融合筛选选项", 隐藏符文融合筛选选项);
        ObserverModuleManager.S.UnRegisterEvent("隐藏符文融合品质筛选", 隐藏符文融合品质筛选);
        ObserverModuleManager.S.UnRegisterEvent("刷新符文融合背包", 刷新符文融合背包);
        ObserverModuleManager.S.UnRegisterEvent("符文融合确定融合", 符文融合确定融合);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("符文融合点击", 符文融合点击);
        ObserverModuleManager.S.RegisterEvent("隐藏符文融合筛选选项", 隐藏符文融合筛选选项);
        ObserverModuleManager.S.RegisterEvent("隐藏符文融合品质筛选", 隐藏符文融合品质筛选);
        ObserverModuleManager.S.RegisterEvent("刷新符文融合背包", 刷新符文融合背包);
        ObserverModuleManager.S.RegisterEvent("符文融合确定融合", 符文融合确定融合);

        符文筛选Button.onClick.AddListener(() =>
        {
            符文筛选mask.gameObject.SetActive(true);
            符文筛选.gameObject.SetActive(true);
        });
        品质筛选Button.onClick.AddListener(() =>
        {
            品质筛选mask.gameObject.SetActive(true);
            品质筛选.gameObject.SetActive(true);
        });
        符文筛选mask.onClick.AddListener(() =>
        {
            符文筛选mask.gameObject.SetActive(false);
            符文筛选.gameObject.SetActive(false);
        });
        品质筛选mask.onClick.AddListener(() =>
        {
            品质筛选mask.gameObject.SetActive(false);
            品质筛选.gameObject.SetActive(false);
        });
        融合Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.符文融合主符文 == null || HeroWindowController.S.符文融合副符文 == null) return;
            符文融合提示弹窗.gameObject.SetActive(true);
        });
        左Button.onClick.AddListener(() =>
        {
            if (页数num > 1)
            {
                页数num--;
                Show();
            }
        });
        右Button.onClick.AddListener(() =>
        {
            if (页数num < Get最大页数())
            {
                页数num++;
                Show();
            }
        });
    }

    public void Set符文筛选()
    {
        foreach (Transform item in 符文筛选Content.transform)
        {
            Destroy(item.gameObject);
        }
        var item0 = Instantiate(Resources.Load("Prefabs/Window/炼器/符文融合筛选选项item") as GameObject, 符文筛选Content.transform)
            .GetComponent<符文融合筛选选项item>();
        item0.符文Type = 符文Type.None;
        item0.SetItem();
        foreach (var kv in 符文Config.符文名Dic)
        {
            if (kv.Key != 符文Type.None)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/炼器/符文融合筛选选项item") as GameObject, 符文筛选Content.transform)
                    .GetComponent<符文融合筛选选项item>();
                item.符文Type = kv.Key;
                item.SetItem();
            }
        }
    }

    public void Set品质筛选()
    {
        foreach (Transform item in 品质筛选Content.transform)
        {
            Destroy(item.gameObject);
        }
        var item0 = Instantiate(Resources.Load("Prefabs/Window/炼器/符文融合品质筛选Item") as GameObject, 品质筛选Content.transform)
            .GetComponent<符文融合品质筛选Item>();
        item0.qualityType = QualityType.None;
        item0.SetItem();
        for (int i = 1; i <= 8; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/炼器/符文融合品质筛选Item") as GameObject, 品质筛选Content.transform)
                .GetComponent<符文融合品质筛选Item>();
            item.qualityType = (QualityType)i;
            item.SetItem();
        }
    }

    public int Get最大页数()
    {
        int count = 0;
        for (int q = 1; q <= 8; q++)
        {
            foreach (var item in PlayerData.S.Get符文List((QualityType)q))
            {
                // 融合符文不参与融合
                if (item.融合) continue;
                if (HeroWindowController.S.符文融合品质筛选 != QualityType.None && item.quality != HeroWindowController.S.符文融合品质筛选) continue;
                if (HeroWindowController.S.符文融合排序Type != 符文Type.None && item.type != HeroWindowController.S.符文融合排序Type) continue;
                count++;
            }
        }
        return Mathf.Max(1, Mathf.CeilToInt(count / 48f));
    }

    public void Show()
    {
        Show左Panel();
        Show右Panel();
    }

    public void Show左Panel()
    {
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }
        int 最大页数 = Get最大页数();
        if (页数num > 最大页数) 页数num = 最大页数;
        if (页数num < 1) 页数num = 1;
        页数.text = 页数num.ToString();

        List<List<符文>> 符文Lists = new List<List<符文>>()
        {
            PlayerData.S.符文荒品List,
            PlayerData.S.符文洪品List,
            PlayerData.S.符文宙品List,
            PlayerData.S.符文宇品List,
            PlayerData.S.符文天品List,
            PlayerData.S.符文地品List,
            PlayerData.S.符文玄品List,
            PlayerData.S.符文黄品List,
        };
        int count = 0;
        int start = 48 * (页数num - 1);
        int end = 页数num * 48;
        foreach (var list in 符文Lists)
        {
            foreach (var 符文item in list)
            {
                // 融合符文不出现在融合背包
                if (符文item.融合) continue;
                if (HeroWindowController.S.符文融合品质筛选 != QualityType.None && 符文item.quality != HeroWindowController.S.符文融合品质筛选) continue;
                if (HeroWindowController.S.符文融合排序Type != 符文Type.None && 符文item.type != HeroWindowController.S.符文融合排序Type) continue;
                if (count >= start && count < end)
                {
                    var item = Instantiate(Resources.Load("Prefabs/Window/炼器/符文融合item") as GameObject, Content.transform)
                        .GetComponent<符文融合item>();
                    item.符文 = 符文item;
                    item.SetItem();
                }
                count++;
            }
        }
    }

    public static string 数值文本(符文 符文)
    {
        if (符文.type == 符文Type.击杀怪物获得神通能量)
        {
            return 符文.count.ToString("F2");
        }
        return 符文.count.ToString("F1") + "%";
    }

    public void Show右Panel()
    {
        var 主 = HeroWindowController.S.符文融合主符文;
        var 副 = HeroWindowController.S.符文融合副符文;

        Show符文区(主, 主符文Icon, 主符文效果, 主符文数值, 主符文无暇);
        Show符文区(副, 副符文Icon, 副符文效果, 副符文数值, 副符文无暇);
        融合Button.interactable = 主 != null && 副 != null;
    }

    /// <summary>
    /// 主/副符文区域统一刷新：符文为空时连同效果/数值/无暇一起隐藏，
    /// 避免图标已清空但下方仍残留上一个符文的数据
    /// </summary>
    private void Show符文区(符文 符文, Image icon, TextMeshProUGUI 效果, TextMeshProUGUI 数值, TextMeshProUGUI 无暇)
    {
        bool 有符文 = 符文 != null;
        icon.gameObject.SetActive(有符文);
        效果.gameObject.SetActive(有符文);
        数值.gameObject.SetActive(有符文);
        无暇.gameObject.SetActive(有符文);
        if (!有符文) return;

        icon.sprite = ResourcesConfig.Get符文Sprite(符文.type, 符文.quality);
        效果.text = "效果：" + 符文Config.符文效果Dic[符文.type];
        数值.text = 数值文本(符文);
        无暇.text = 符文.无暇 ? "无暇" : "";
    }

    public void 符文融合点击(object[] obj)
    {
        var 符文 = obj[0] as 符文;
        if (符文 == null) return;

        // 已选中的符文：再次点击取消
        if (HeroWindowController.S.符文融合主符文 == 符文)
        {
            HeroWindowController.S.符文融合主符文 = null;
        }
        else if (HeroWindowController.S.符文融合副符文 == 符文)
        {
            HeroWindowController.S.符文融合副符文 = null;
        }
        // 主符文为空优先占主位
        else if (HeroWindowController.S.符文融合主符文 == null)
        {
            HeroWindowController.S.符文融合主符文 = 符文;
        }
        // 主符文已占，副符文为空则占副位
        else if (HeroWindowController.S.符文融合副符文 == null)
        {
            HeroWindowController.S.符文融合副符文 = 符文;
        }
        else
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "主副符文已选择，再次点击已选符文可取消选择");
            return;
        }
        Show();
    }

    public void 符文融合确定融合(object[] obj)
    {
        var 主 = HeroWindowController.S.符文融合主符文;
        var 副 = HeroWindowController.S.符文融合副符文;
        if (主 == null || 副 == null) return;

        // 50% 成功
        if (Random.Range(0, 100) < 50 + 属性config.仙子总属性.符文融合成功概率增加)
        {
            主.融合 = true;
            主.融合type = 副.type;
            主.融合count = 副.count;
            主.融合无暇 = 副.无暇;
            销毁符文(副);
            ObserverModuleManager.S.SendEvent("SendUIToast", "融合成功");
        }
        else
        {
            // 失败只销毁副符文，不给符箓
            销毁符文(副);
            ObserverModuleManager.S.SendEvent("SendUIToast", "融合失败，副符文已销毁");
        }

        HeroWindowController.S.符文融合主符文 = null;
        HeroWindowController.S.符文融合副符文 = null;
        页数num = 1;
        Show();
    }

    /// <summary>从玩家符文列表中移除指定符文</summary>
    private void 销毁符文(符文 符文)
    {
        var list = PlayerData.S.Get符文List(符文.quality);
        if (list != null) list.Remove(符文);
    }

    public void 隐藏符文融合筛选选项(object[] obj)
    {
        符文筛选.gameObject.SetActive(false);
        符文筛选mask.gameObject.SetActive(false);
    }

    public void 隐藏符文融合品质筛选(object[] obj)
    {
        品质筛选.gameObject.SetActive(false);
        品质筛选mask.gameObject.SetActive(false);
    }

    public void 刷新符文融合背包(object[] obj)
    {
        页数num = 1;
        Show();
    }
}
