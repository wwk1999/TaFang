using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 炼丹界面 : MonoBehaviour
{
    public Button 详情Button;
    public GameObject 详情content;

    public Button 加Button;
    public Button 减button;

    public Button exitbutton;
    public GameObject 丹方列表content;
    public TextMeshProUGUI 炼丹等级;
    public Slider 炼丹经验条;
    public TextMeshProUGUI 当前经验;
    public TextMeshProUGUI 最大经验;
    public Slider 炼制进度条;
    public TextMeshProUGUI 炼制百分比;
    public GameObject 所选灵药Content;
    public Slider 炼制数量Slider;
    public TextMeshProUGUI 炼制数量;
    public Button 炼制Button;
    public TextMeshProUGUI 炼制ButtonText;
    // [重构] 旧的8个品质Toggle已移除，品质概率改为只读展示
    public TextMeshProUGUI 品质概率Text;
    public 丹药信息 丹药信息;
    private int 当前选择炼制数量 = 0;

    public GameObject 炼制区域;

    /// <summary>按阶数刷新灵药显示（阶数决定固定品质和数量）</summary>
    public void Show灵药按阶数(丹药Type type, int 阶数)
    {
        foreach (Transform item in 所选灵药Content.transform)
        {
            Destroy(item.gameObject);
        }
        if (type == 丹药Type.None) return;

        // 造化丹药用灵植，这里跳过（造化丹方Dic没有灵药）
        QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
        int 单种数量 = 丹药Config.Get单种材料数量(阶数);
        bool 是造化丹药 = 丹药Config.丹药类型Dic[type] == 丹药类型.造化丹药;

        List<(灵药Type, QualityType)> 灵药list = null;
        List<(灵植Type, QualityType)> 灵植list = null;

        if (是造化丹药)
        {
            // 造化丹药：用造化丹药灵植Dic里对应品质的灵植
            if (丹药Config.造化丹药灵植Dic.TryGetValue(材料品质, out var 灵植Types))
            {
                灵植list = new List<(灵植Type, QualityType)>();
                foreach (var lt in 灵植Types)
                    灵植list.Add((lt, 材料品质));
            }
        }
        else
        {
            var 原始灵药list = 丹药Config.丹方Dic[type];
            灵药list = new List<(灵药Type, QualityType)>();
            foreach (var lt in 原始灵药list)
                灵药list.Add((lt, 材料品质));
        }

        // 造化丹药：用灵植item（目前灵药item预制体是灵药item，造化时显示灵植？这里先保持用灵药item并替换显示）
        if (灵药list != null)
        {
            for (int i = 0; i < 灵药list.Count; i++)
            {
                var go = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/灵药item"), 所选灵药Content.transform) as GameObject;
                var 灵药item = go.GetComponent<灵药item>();
                灵药item.灵药Type = 灵药list[i].Item1;
                灵药item.QualityType = 灵药list[i].Item2;
                灵药item.显示数量 = 单种数量;
                灵药item.SetItem();
            }
        }
        else if (灵植list != null)
        {
            // 造化丹药：创建灵药item但标记为造化灵植模式
            for (int i = 0; i < 灵植list.Count; i++)
            {
                var go2 = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/灵药item"), 所选灵药Content.transform) as GameObject;
                var 灵药item = go2.GetComponent<灵药item>();
                灵药item.是造化灵植 = true;
                灵药item.灵植Type = 灵植list[i].Item1;
                灵药item.QualityType = 灵植list[i].Item2;
                灵药item.显示数量 = 单种数量;
                灵药item.SetItem();
            }
        }
    }

    /// <summary>旧Show灵药保留做兼容桥接</summary>
    public void Show灵药(丹药Type type, QualityType QualityType)
    {
        Show灵药按阶数(type, (int)QualityType);
    }

    /// <summary>非炼制状态显示</summary>
    public void 非炼制Show(丹药Type type, int 阶数)
    {
        当前选择炼制数量 = 0;
        Show灵药按阶数(type, 阶数);
        Show丹方列表();
        丹药信息.丹药Type = type;
        丹药信息.阶数 = 阶数;
        丹药信息.SetItem();

        // 品质概率展示（只读）
        if (品质概率Text != null)
        {
            品质概率Text.text = 丹药Config.Get品质概率说明();
        }

        炼制ButtonText.text = "开始炼制";
        炼制数量Slider.value = 0;
        炼制数量Slider.maxValue = 0; // 由SetMax炼制数量按钮/逻辑设置
        炼制数量.text = "0";
        炼丹等级.text = "炼丹等级Lv" + PlayerData.S.炼丹等级 + ":";
        炼丹经验条.maxValue = 丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级];
        炼丹经验条.value = PlayerData.S.炼丹经验;
        当前经验.text = PlayerData.S.炼丹经验.ToString("F0");
        最大经验.text = PlayerData.S.格式化数字(丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级]);
        炼制进度条.maxValue = 0;
        炼制进度条.value = 0;
        炼制百分比.text = "0%";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (详情content.activeSelf)
            {
                详情content.gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void 炼制中Show()
    {
        当前选择炼制数量 = 0;
        var 炼制Item = PlayerData.S.丹药炼制List[0];
        Show灵药按阶数(炼制Item.丹药Type, 炼制Item.阶数);
        Show丹方列表();
        丹药信息.丹药Type = 炼制Item.丹药Type;
        丹药信息.阶数 = 炼制Item.阶数;
        丹药信息.SetItem();

        炼制数量Slider.value = 0;
        炼制数量.text = "0";
        炼丹等级.text = "炼丹等级Lv" + PlayerData.S.炼丹等级 + ":";
        炼丹经验条.maxValue = 丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级];
        炼丹经验条.value = PlayerData.S.炼丹经验;
        当前经验.text = PlayerData.S.炼丹经验.ToString();
        最大经验.text = PlayerData.S.格式化数字(丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级]);

        float 需要时间 = 丹药Config.Get炼制时间(炼制Item.丹药Type, 炼制Item.阶数);
        炼制进度条.maxValue = 需要时间;
        炼制进度条.value = PlayerData.S.当前炼制秒数;
        炼制百分比.text = (MathF.Min(PlayerData.S.当前炼制秒数 / 需要时间 * 100f, 100f)).ToString("F1") + "%";
    }

    public void 刷新炼丹界面(object[] obj)
    {
        非炼制Show(HeroWindowController.S.当前炼丹显示Type, HeroWindowController.S.当前炼丹显示阶数);
    }

    public void 炼制刷新(object[] obj)
    {
        炼丹等级.text = "炼丹等级Lv" + PlayerData.S.炼丹等级 + ":";
        炼丹经验条.maxValue = 丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级];
        炼丹经验条.value = PlayerData.S.炼丹经验;
        当前经验.text = PlayerData.S.炼丹经验.ToString("F0");
        最大经验.text = PlayerData.S.格式化数字(丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级]);

        var 炼制Item = PlayerData.S.丹药炼制List.Count > 0 ? PlayerData.S.丹药炼制List[0] : null;
        if (炼制Item != null)
        {
            float 需要时间 = 丹药Config.Get炼制时间(炼制Item.丹药Type, 炼制Item.阶数);
            炼制进度条.maxValue = 需要时间;
            炼制进度条.value = PlayerData.S.当前炼制秒数;
            炼制百分比.text = (MathF.Min(PlayerData.S.当前炼制秒数 / 需要时间 * 100f, 100f)).ToString("F1") + "%";
        }
    }

    public void 炼制结束(object[] obj)
    {
        丹药Type type = (丹药Type)obj[0];
        int 阶数 = obj.Length > 1 ? (int)obj[1] : 1;
        非炼制Show(type, 阶数);
    }

    public void Show丹药炼制区域()
    {
        foreach (Transform item in 炼制区域.transform)
        {
            Destroy(item.gameObject);
        }

        int index = 0;
        foreach (var item in PlayerData.S.丹药炼制List)
        {
            var 打造item = (Instantiate(Resources.Load("Prefabs/Window/炼丹界面/炼丹item"), 炼制区域.transform) as GameObject).GetComponent<炼丹item>();
            打造item.丹药Type = item.丹药Type;
            打造item.阶数 = item.阶数;
            打造item.count = item.count;
            打造item.进度 = item.进度;
            打造item.index = index;
            打造item.SetItem();
            index++;
        }
    }

    public void 刷新丹药炼制区域(object[] obj)
    {
        Show丹药炼制区域();
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新丹药炼制区域", 刷新丹药炼制区域);
        ObserverModuleManager.S.RegisterEvent("炼制结束", 炼制结束);
        ObserverModuleManager.S.RegisterEvent("炼制刷新", 炼制刷新);
        ObserverModuleManager.S.RegisterEvent("刷新炼丹界面", 刷新炼丹界面);
        ObserverModuleManager.S.RegisterEvent("更新炼丹界面UI", 更新炼丹界面UI);

        // 加/减按钮
        加Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前炼丹显示Type == 丹药Type.None) return;
            int max = (int)炼制数量Slider.maxValue;
            if (当前选择炼制数量 >= max) return;
            炼制数量Slider.value = 当前选择炼制数量 + 1;
        });
        详情Button.onClick.AddListener(() =>
        {
            详情content.gameObject.SetActive(true);
        });
        减button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前炼丹显示Type == 丹药Type.None) return;
            if (当前选择炼制数量 <= 0) return;
            炼制数量Slider.value = 当前选择炼制数量 - 1;
        });
        炼制Button.onClick.AddListener(() =>
        {
            if (当前选择炼制数量 == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "请选择炼制数量");
                return;
            }

            int 阶数 = HeroWindowController.S.当前炼丹显示阶数;
            if (阶数 < 1 || 阶数 > 16)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "请先选择丹方阶数");
                return;
            }

            // 校验炼丹等级是否满足该阶数要求
            long 需要炼丹等级 = 丹药Config.Get炼丹等级要求(HeroWindowController.S.当前炼丹显示Type, 阶数);
            if (PlayerData.S.炼丹等级 < 需要炼丹等级)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", $"炼丹等级不足，需要等级Lv{需要炼丹等级}");
                return;
            }

            // 校验炼丹室等级是否满足最高阶数
            int 炼丹室最高阶数 = Get炼丹室最高炼制阶数();
            if (阶数 > 炼丹室最高阶数)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "当前炼丹房等级不足，请前往领主府升级炼丹房");
                return;
            }

            丹药炼制Item 丹药炼制Item = new 丹药炼制Item();
            丹药炼制Item.count = 当前选择炼制数量;
            丹药炼制Item.进度 = 0;
            丹药炼制Item.丹药Type = HeroWindowController.S.当前炼丹显示Type;
            丹药炼制Item.阶数 = 阶数;
            炼制数量Slider.value = 0;
            当前选择炼制数量 = 0;
            PlayerData.S.丹药炼制List.Add(丹药炼制Item);
            炼制中Show();
        });
        exitbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        炼制数量Slider.onValueChanged.AddListener((value) =>
        {
            int newcount = (int)value;
            炼制数量Slider.value = newcount;
            炼制数量.text = newcount.ToString();
            当前选择炼制数量 = newcount;
        });
    }

    /// <summary>根据炼丹室等级计算最高可炼制阶数（每3级解锁一个阶数段：1-3级→1阶，4-6级→2阶...）</summary>
    private int Get炼丹室最高炼制阶数()
    {
        int 等级 = PlayerData.S.建筑等级Dic.TryGetValue(建筑Type.炼丹室, out var lv) ? lv : 1;
        return Math.Min(16, Math.Max(1, (等级 - 1) / 3 + 1));
    }

    /// <summary>根据当前阶数计算能炼几颗（造化丹药查灵植库存，其他查灵药库存）</summary>
    public int Get当前最大炼制数量(丹药Type type, int 阶数)
    {
        if (type == 丹药Type.None || 阶数 < 1 || 阶数 > 16) return 0;
        QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
        int 单种数量 = 丹药Config.Get单种材料数量(阶数);
        if (单种数量 <= 0) return 0;

        // 造化丹药用灵植库存（普通收获+变异收获合计）
        if (丹药Config.丹药类型Dic[type] == 丹药类型.造化丹药)
        {
            if (!丹药Config.造化丹药灵植Dic.TryGetValue(材料品质, out var 灵植Types))
                return 0;

            int min = int.MaxValue;
            foreach (var lt in 灵植Types)
            {
                float 普通库存 = PlayerData.S.普通收获Dic.TryGetValue(lt, out var 普通数) ? 普通数 : 0;
                float 变异库存 = PlayerData.S.变异收获Dic.TryGetValue(lt, out var 变异数) ? 变异数 : 0;
                int 可用于炼制 = (int)MathF.Floor((普通库存 + 变异库存) / 单种数量);
                min = Math.Min(min, 可用于炼制);
            }
            return Math.Max(0, min);
        }

        // 普通丹药：查灵药库存
        var 灵药list = 丹药Config.丹方Dic[type];
        int minCount = int.MaxValue;
        foreach (var lt in 灵药list)
        {
            int 库存 = PlayerData.S.Get灵药数量(lt, 材料品质);
            minCount = Math.Min(minCount, 库存 / 单种数量);
        }
        return Math.Max(0, minCount);
    }

    /// <summary>刷新最大炼制数量（供丹方阶数切换时调用）</summary>
    public void 刷新炼制数量()
    {
        int max = Get当前最大炼制数量(HeroWindowController.S.当前炼丹显示Type, HeroWindowController.S.当前炼丹显示阶数);
        炼制数量Slider.maxValue = max;
        if (当前选择炼制数量 > max)
        {
            当前选择炼制数量 = max;
            炼制数量Slider.value = max;
            炼制数量.text = max.ToString();
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新丹药炼制区域", 刷新丹药炼制区域);
        ObserverModuleManager.S.UnRegisterEvent("炼制结束", 炼制结束);
        ObserverModuleManager.S.UnRegisterEvent("炼制刷新", 炼制刷新);
        ObserverModuleManager.S.UnRegisterEvent("刷新炼丹界面", 刷新炼丹界面);
        ObserverModuleManager.S.UnRegisterEvent("更新炼丹界面UI", 更新炼丹界面UI);
    }

    public void 更新炼丹界面UI(object[] obj)
    {
        StartCoroutine(延迟渲染());
    }

    IEnumerator 延迟渲染()
    {
        yield return null;
        yield return null;
        LayoutRebuilder.ForceRebuildLayoutImmediate(丹方列表content.transform as RectTransform);
        Canvas.ForceUpdateCanvases();
    }

    private void OnEnable()
    {
        HeroWindowController.S.当前炼丹显示Type = 丹药Type.火焰伤害;
        HeroWindowController.S.当前炼丹显示阶数 = 1;
        if (PlayerData.S.丹药炼制List == null || PlayerData.S.丹药炼制List.Count <= 0)
        {
            非炼制Show(丹药Type.火焰伤害, 1);
            刷新炼制数量();
        }
        else
        {
            炼制中Show();
        }
    }

    public void Show丹方列表()
    {
        foreach (Transform item in 丹方列表content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in 丹药Config.丹药名Dic)
        {
            if (item.Key == 丹药Type.None) continue;

            // 统计该丹药Type已解锁的阶数（1-16阶）
            List<int> 已解锁阶数list = new List<int>();
            for (int 阶数 = 1; 阶数 <= 16; 阶数++)
            {
                if (PlayerData.S.Get丹方解锁(item.Key, 阶数))
                    已解锁阶数list.Add(阶数);
            }
            if (已解锁阶数list.Count == 0) continue;

            var 丹方item = (Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹方item"), 丹方列表content.transform) as GameObject).GetComponent<丹方item>();
            丹方item.丹药Type = item.Key;
            丹方item.SetItem();
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(丹方列表content.transform as RectTransform);
        Canvas.ForceUpdateCanvases();
    }
}
