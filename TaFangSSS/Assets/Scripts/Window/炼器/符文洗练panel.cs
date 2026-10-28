using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 符文洗练panel : MonoBehaviour
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
    public Image 艺术字;
    public Image icon;
    public GameObject nameObj;
    public TextMeshProUGUI nameText;
    public Button 洗练Button;
    public TextMeshProUGUI 当前符箓Count;
    public TextMeshProUGUI 需要符箓Count;
    public GameObject 符箓Icon;
    public TextMeshProUGUI 符文效果;
    public TextMeshProUGUI 符文数值;
    public TextMeshProUGUI 无暇Text;

    public 符文洗练无暇提示弹窗 符文洗练无暇提示弹窗;
    [NonSerialized] public int 页数num = 1;

    private void OnEnable()
    {
        HeroWindowController.S.符文洗练panel当前符文 = null;
        HeroWindowController.S.符文洗练排序Type = 符文Type.None;
        HeroWindowController.S.符文洗练品质筛选 = QualityType.None;
        页数num = 1;
        Set符文筛选();
        Set品质筛选();
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("符文洗练点击", 符文洗练点击);
        ObserverModuleManager.S.UnRegisterEvent("隐藏符文洗练筛选选项", 隐藏符文洗练筛选选项);
        ObserverModuleManager.S.UnRegisterEvent("隐藏符文洗练品质筛选", 隐藏符文洗练品质筛选);
        ObserverModuleManager.S.UnRegisterEvent("刷新符文洗练背包", 刷新符文洗练背包);
        ObserverModuleManager.S.UnRegisterEvent("符文洗练无暇确定洗练", 符文洗练无暇确定洗练);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("符文洗练点击", 符文洗练点击);
        ObserverModuleManager.S.RegisterEvent("隐藏符文洗练筛选选项", 隐藏符文洗练筛选选项);
        ObserverModuleManager.S.RegisterEvent("隐藏符文洗练品质筛选", 隐藏符文洗练品质筛选);
        ObserverModuleManager.S.RegisterEvent("刷新符文洗练背包", 刷新符文洗练背包);
        ObserverModuleManager.S.RegisterEvent("符文洗练无暇确定洗练", 符文洗练无暇确定洗练);

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
        洗练Button.onClick.AddListener(() =>
        {
            洗练();
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
            int 最大页数 = Get最大页数();
            if (页数num < 最大页数)
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
        var item0 = Instantiate(Resources.Load("Prefabs/Window/炼器/符文洗练筛选选项item") as GameObject, 符文筛选Content.transform)
            .GetComponent<符文洗练筛选选项item>();
        item0.符文Type = 符文Type.None;
        item0.SetItem();
        foreach (var kv in 符文Config.符文名Dic)
        {
            if (kv.Key != 符文Type.None)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/炼器/符文洗练筛选选项item") as GameObject, 符文筛选Content.transform)
                    .GetComponent<符文洗练筛选选项item>();
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
        var item0 = Instantiate(Resources.Load("Prefabs/Window/炼器/符文洗练品质筛选Item") as GameObject, 品质筛选Content.transform)
            .GetComponent<符文洗练品质筛选Item>();
        item0.qualityType = QualityType.None;
        item0.SetItem();
        for (int i = 1; i <= 8; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/炼器/符文洗练品质筛选Item") as GameObject, 品质筛选Content.transform)
                .GetComponent<符文洗练品质筛选Item>();
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
                // 融合符文不参与洗练
                if (item.融合) continue;
                if (HeroWindowController.S.符文洗练品质筛选 != QualityType.None && item.quality != HeroWindowController.S.符文洗练品质筛选) continue;
                if (HeroWindowController.S.符文洗练排序Type != 符文Type.None && item.type != HeroWindowController.S.符文洗练排序Type) continue;
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
                // 融合符文不出现在洗练背包
                if (符文item.融合) continue;
                if (HeroWindowController.S.符文洗练品质筛选 != QualityType.None && 符文item.quality != HeroWindowController.S.符文洗练品质筛选) continue;
                if (HeroWindowController.S.符文洗练排序Type != 符文Type.None && 符文item.type != HeroWindowController.S.符文洗练排序Type) continue;
                if (count >= start && count < end)
                {
                    var item = Instantiate(Resources.Load("Prefabs/Window/炼器/符文洗练item") as GameObject, Content.transform)
                        .GetComponent<符文洗练item>();
                    item.符文 = 符文item;
                    item.SetItem();
                }
                count++;
            }
        }
    }

    public void Show右Panel()
    {
        if (HeroWindowController.S.符文洗练panel当前符文 == null)
        {
            艺术字.gameObject.SetActive(false);
            nameObj.SetActive(false);
            icon.gameObject.SetActive(false);
            洗练Button.gameObject.SetActive(false);
            当前符箓Count.gameObject.SetActive(false);
            需要符箓Count.gameObject.SetActive(false);
            符箓Icon.gameObject.SetActive(false);
            符文效果.gameObject.SetActive(false);
            符文数值.gameObject.SetActive(false);
            无暇Text.gameObject.SetActive(false);
        }
        else
        {
            var 符文 = HeroWindowController.S.符文洗练panel当前符文;
            艺术字.gameObject.SetActive(true);
            nameObj.SetActive(true);
            icon.gameObject.SetActive(true);
            洗练Button.gameObject.SetActive(true);
            当前符箓Count.gameObject.SetActive(true);
            需要符箓Count.gameObject.SetActive(true);
            符箓Icon.gameObject.SetActive(true);
            符文效果.gameObject.SetActive(true);
            符文数值.gameObject.SetActive(true);
            无暇Text.gameObject.SetActive(true);

            艺术字.sprite = ResourcesConfig.Get艺术字(符文.quality);
            nameText.text = 符文Config.符文名Dic[符文.type];
            icon.sprite = ResourcesConfig.Get符文Sprite(符文.type, 符文.quality);
            符文效果.text = 符文Config.符文效果Dic[符文.type];
            if (符文.type == 符文Type.击杀怪物获得神通能量)
            {
                符文数值.text = 符文.count.ToString("F2");
            }
            else
            {
                符文数值.text = 符文.count.ToString("F1") + "%";
            }
            无暇Text.text = 符文.无暇 ? "无暇" : "";

            float 需要符箓 = 符文Config.符文洗练Dictionary[符文.quality];
            需要符箓Count.text = PlayerData.S.格式化数字(需要符箓);
            当前符箓Count.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.符箓]);
        }
    }

    public void 符文洗练点击(object[] obj)
    {
        HeroWindowController.S.符文洗练panel当前符文 = obj[0] as 符文;
        Show右Panel();
        foreach (Transform item in Content.transform)
        {
            var 洗练item = item.GetComponent<符文洗练item>();
            if (洗练item != null)
                洗练item.gou.SetActive(HeroWindowController.S.符文洗练panel当前符文 == 洗练item.符文);
        }
    }

    public void 洗练()
    {
        var 符文 = HeroWindowController.S.符文洗练panel当前符文;
        if (符文 == null) return;

        if (符文.无暇)
        {
            符文洗练无暇提示弹窗.gameObject.SetActive(true);
            return;
        }

        float 需要符箓 = 符文Config.符文洗练Dictionary[符文.quality];
        if (PlayerData.S.PropListDic[PropType.符箓] < 需要符箓)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "符箓数量不足,可分解符文获取");
            return;
        }

        // 保留符文type，重置count
        var mm = 符文Config.Get符文minmax(符文.type, 符文.quality);
        float min = mm.min;
        float max = mm.max;

        var 无暇random = Random.Range(0, 100);
        if (无暇random < 1f)
        {
            符文.无暇 = true;
            符文.count = max;
        }
        else
        {
            符文.无暇 = false;
            符文.count = Random.Range(min, max);
        }

        PlayerData.S.PropListDic[PropType.符箓] -= 需要符箓;
        ObserverModuleManager.S.SendEvent("SendUIToast", "洗练成功");
        Show();
    }

    public void 符文洗练无暇确定洗练(object[] obj)
    {
        无暇提示洗练();
    }

    public void 无暇提示洗练()
    {
        var 符文 = HeroWindowController.S.符文洗练panel当前符文;
        if (符文 == null) return;

        float 需要符箓 = 符文Config.符文洗练Dictionary[符文.quality];
        if (PlayerData.S.PropListDic[PropType.符箓] < 需要符箓)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "符箓数量不足,可分解符文获取");
            return;
        }

        var mm = 符文Config.Get符文minmax(符文.type, 符文.quality);
        float min = mm.min;
        float max = mm.max;

        var 无暇random = Random.Range(0, 100);
        if (无暇random < 1f)
        {
            符文.无暇 = true;
            符文.count = max;
        }
        else
        {
            符文.无暇 = false;
            符文.count = Random.Range(min, max);
        }

        PlayerData.S.PropListDic[PropType.符箓] -= 需要符箓;
        ObserverModuleManager.S.SendEvent("SendUIToast", "洗练成功");
        Show();
    }

    public void 隐藏符文洗练筛选选项(object[] obj)
    {
        符文筛选.gameObject.SetActive(false);
        符文筛选mask.gameObject.SetActive(false);
    }

    public void 隐藏符文洗练品质筛选(object[] obj)
    {
        品质筛选.gameObject.SetActive(false);
        品质筛选mask.gameObject.SetActive(false);
    }

    public void 刷新符文洗练背包(object[] obj)
    {
        页数num = 1;
        Show();
    }
}
