using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 宝物弹窗 : MonoBehaviour
{
    public Button 详情Button;
    public Button exitbutton;
    public Button maskButton;
    public GameObject 当前佩戴obj;
    public GameObject 宝物背包obj;
    public GameObject 全局效果obj;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品质;
    public TextMeshProUGUI 效果;
    public GameObject 宝物信息Obj;
    public TextMeshProUGUI 宝物碎片;
    public Button 佩戴Button;

    private 宝物Type 当前选择宝物Type;
    private QualityType QualityType1;
    private void OnEnable()
    {
        当前选择宝物Type = 宝物Type.None;
        QualityType1= QualityType.None;
        宝物碎片.text = PlayerData.S.格式化数字(PlayerData.S.宝物碎片);
        宝物信息Obj.SetActive(false);
        Show当前佩戴宝物();
        Show宝物背包();
        Show全局效果();
    }

    public void Show当前佩戴宝物()
    {
        foreach (Transform item in 当前佩戴obj.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i <= 10; i++)
        {
            var 宝物 = Instantiate(Resources.Load("Prefabs/Window/灵矿场/当前佩戴宝物Item"), 当前佩戴obj.transform)
                .GetComponent<当前佩戴宝物Item>();
            宝物.index = i;
            宝物.SetItem();
        }
    }

    // 宝物只使用黄、地、宇、洪、荒五种品质，枚举值不连续，展示顺序固定
    private static readonly QualityType[] 五种品质 =
    {
        QualityType.黄品, QualityType.地品, QualityType.宇品, QualityType.洪品, QualityType.荒品,
    };

    public void Show宝物背包()
    {
        foreach (Transform item in 宝物背包obj.transform)
        {
            Destroy(item.gameObject);
        }

        // 先收集所有拥有的宝物，再按品质从高到低排序
        var 条目 = new List<(宝物Type 类型, QualityType 品质, int 数量)>();
        int 类型数 = Enum.GetValues(typeof(宝物Type)).Length;
        for (int i = 1; i < 类型数; i++)
        {
            var 宝物类型 = (宝物Type)i;
            foreach (var 品质Type in 五种品质)
            {
                int 数量 = PlayerData.S.Get宝物数量(宝物类型, 品质Type);
                if (数量 <= 0) continue;
                条目.Add((宝物类型, 品质Type, 数量));
            }
        }
        条目.Sort((a, b) =>
        {
            int 品质比较 = ((int)b.品质).CompareTo((int)a.品质);
            if (品质比较 != 0) return 品质比较;
            return ((int)a.类型).CompareTo((int)b.类型);
        });

        foreach (var 张 in 条目)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/灵矿场/宝物背包item"), 宝物背包obj.transform)
                .GetComponent<宝物背包item>();
            item.宝物Type = 张.类型;
            item.QualityType = 张.品质;
            item.SetItem();
        }
    }

    public void Show全局效果()
    {
        foreach (Transform item in 全局效果obj.transform)
        {
            Destroy(item.gameObject);
        }

        var 总属性 = 灵矿场Config.当前总宝物属性;
        int 类型数 = Enum.GetValues(typeof(宝物Type)).Length;
        for (int i = 1; i < 类型数; i++)
        {
            var 宝物类型 = (宝物Type)i;
            // 只展示当前实际生效（数值不为 0）的全局效果
            if (Mathf.Approximately(灵矿场Config.Get总宝物数值(宝物类型, 总属性), 0f)) continue;

            var item = Instantiate(Resources.Load("Prefabs/Window/灵矿场/全局效果item"), 全局效果obj.transform)
                .GetComponent<全局效果item>();
            item.宝物Type = 宝物类型;
            item.SetItem();
        }
    }

    public void 宝物背包item点击(object[] obj)
    {
        宝物Type 宝物Type1 = (宝物Type)obj[0];
        QualityType QualityType1 = (QualityType)obj[1];
        当前选择宝物Type = 宝物Type1;
        this.QualityType1 = QualityType1;
        
        宝物信息Obj.SetActive(true);
        bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType1);
        icon.sprite = ResourcesConfig.Get宝物Sprite(宝物Type1);
        name.text = 灵矿场Config.宝物名[宝物Type1];
        品质.text = 灵矿场Config.Get品质显示名(QualityType1);
        效果.text = 灵矿场Config.Get宝物效果(宝物Type1, QualityType1);
    }

    public void 升级宝物格子(object[] obj)
    {
        宝物碎片.text = PlayerData.S.格式化数字(PlayerData.S.宝物碎片);
    }

    public void 当前佩戴宝物卸下(object[] obj)
    {
        Show当前佩戴宝物();
        Show宝物背包();
        Show全局效果();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("当前佩戴宝物卸下",当前佩戴宝物卸下);
        ObserverModuleManager.S.RegisterEvent("升级宝物格子",升级宝物格子);
        ObserverModuleManager.S.RegisterEvent("宝物背包item点击",宝物背包item点击);
        exitbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        佩戴Button.onClick.AddListener(() =>
        {
            if (当前选择宝物Type == 宝物Type.None) return;
            if (PlayerData.S.Get宝物数量(当前选择宝物Type, QualityType1) <= 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","宝物数量不足");
                return;
            }
            int 已解锁槽位数 = 灵矿场Config.宝物佩戴上限配置[PlayerData.S.矿洞宝物佩戴上限].个数;
            foreach (var item in PlayerData.S.当前宝物)
            {
                if (item.Key <= 已解锁槽位数 && item.Value == null)
                {
                    PlayerData.S.当前宝物[item.Key]=new 宝物(){宝物Type = 当前选择宝物Type,QualityType =  QualityType1};
                    PlayerData.S.Set宝物数量(当前选择宝物Type,QualityType1,PlayerData.S.Get宝物数量(当前选择宝物Type,QualityType1)-1);
                    Show当前佩戴宝物();
                    Show宝物背包();
                    Show全局效果();
                    return;
                }
            }
            ObserverModuleManager.S.SendEvent("SendUIToast","宝物佩戴已满");
        });
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("当前佩戴宝物卸下",当前佩戴宝物卸下);
        ObserverModuleManager.S.UnRegisterEvent("升级宝物格子",升级宝物格子);
        ObserverModuleManager.S.UnRegisterEvent("宝物背包item点击",宝物背包item点击);
    }
}
