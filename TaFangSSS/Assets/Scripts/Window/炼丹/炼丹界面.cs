using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
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
    public Toggle 黄;
    public Toggle 玄;
    public Toggle 地;
    public Toggle 天;
    public Toggle 宇;
    public Toggle 宙;
    public Toggle 洪;
    public Toggle 荒;
    public 丹药信息 丹药信息;
    private int 当前选择炼制数量 = 0;

    public GameObject 炼制区域;
    public void Show灵药(丹药Type type, QualityType QualityType)
    {
        foreach (Transform item in 所选灵药Content.transform)
        {
            Destroy(item.gameObject);
        }
        var list = 丹药Config.Get炼制灵药(type,QualityType);
        for (int i = 1; i <= 4; i++)
        {
            var 灵药item = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/灵药item"), 所选灵药Content.transform)
                .GetComponent<灵药item>();
            if (type == 丹药Type.None)
            {
                灵药item.灵药Type=灵药Type.None;
            }
            else
            {
                if (list.Count >= i)
                {
                    灵药item.灵药Type=list[i-1].灵药Type;
                    灵药item.QualityType=list[i-1].QualityType;
                }
                else
                {
                    灵药item.灵药Type=灵药Type.None;
                }
            }
            灵药item.SetItem();
        }
    }

    public void 非炼制Show(丹药Type type, QualityType QualityType)
    {
        当前选择炼制数量 = 0;
        Show灵药(type,QualityType);
        Show丹方列表();
        丹药信息.丹药Type = type;
        丹药信息.QualityType = QualityType;
        丹药信息.SetItem();
        PlayerData.S.丹药灵药筛选Dic[QualityType.黄品] = false;
        PlayerData.S.丹药灵药筛选Dic[QualityType.玄品] = false;
        PlayerData.S.丹药灵药筛选Dic[QualityType.地品] = false;
        PlayerData.S.丹药灵药筛选Dic[QualityType.天品] = false;
        PlayerData.S.丹药灵药筛选Dic[QualityType.宇品] = false;
        PlayerData.S.丹药灵药筛选Dic[QualityType.宙品] = false;
        PlayerData.S.丹药灵药筛选Dic[QualityType.洪品] = false;
        PlayerData.S.丹药灵药筛选Dic[QualityType.荒品] = false;

        黄.isOn = false;
        玄.isOn = false;
        地.isOn = false;
        天.isOn = false;
        宇.isOn = false;
        宙.isOn = false;
        洪.isOn = false;
        荒.isOn = false;
        黄.interactable = QualityType<=QualityType.黄品;
        玄.interactable = QualityType<=QualityType.玄品;
        地.interactable = QualityType<=QualityType.地品;
        天.interactable = QualityType<=QualityType.天品;
        宇.interactable = QualityType<=QualityType.宇品;
        宙.interactable = QualityType<=QualityType.宙品;
        洪.interactable = QualityType<=QualityType.洪品;
        荒.interactable = QualityType<=QualityType.荒品;

        炼制ButtonText.text = "开始炼制";
        炼制数量Slider.value = 0;
        炼制数量.text = "0";
        炼丹等级.text = "炼丹等级Lv" + PlayerData.S.炼丹等级 + ":";
        炼丹经验条.maxValue = 丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级];
        炼丹经验条.value = PlayerData.S.炼丹经验;
        当前经验.text=PlayerData.S.炼丹经验.ToString("F0");
        最大经验.text=PlayerData.S.格式化数字(丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级]);
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
        Show灵药(PlayerData.S.丹药炼制List[0].丹药Type,PlayerData.S.丹药炼制List[0].丹药QualityType);
        Show丹方列表();
        丹药信息.丹药Type = PlayerData.S.丹药炼制List[0].丹药Type;
        丹药信息.QualityType = PlayerData.S.丹药炼制List[0].丹药QualityType;
        丹药信息.SetItem();
        黄.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.黄品];
        玄.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.玄品];
        地.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.地品];
        天.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.天品];
        宇.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.宇品];
        宙.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.宙品];
        洪.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.洪品];
        荒.isOn = PlayerData.S.丹药灵药筛选Dic[QualityType.荒品];
        黄.interactable = false;
        玄.interactable = false;
        地.interactable = false;
        天.interactable = false;
        宇.interactable = false;
        宙.interactable = false;
        洪.interactable = false;
        荒.interactable = false;

        炼制数量Slider.value = 0;
        炼制数量.text = "0";
        炼丹等级.text = "炼丹等级Lv" + PlayerData.S.炼丹等级 + ":";
        炼丹经验条.maxValue = 丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级];
        炼丹经验条.value = PlayerData.S.炼丹经验;
        当前经验.text=PlayerData.S.炼丹经验.ToString();
        最大经验.text=PlayerData.S.格式化数字(丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级]);
        丹药类型 当前炼制丹药类型 = 丹药Config.丹药类型Dic[HeroWindowController.S.当前炼丹显示Type];
        float 需要时间 = 0;
        switch (当前炼制丹药类型)
        {
            case 丹药类型.战斗丹药:
                需要时间 = 属性config.每年秒数 * 丹药Config.战斗丹药炼制时间Dic[HeroWindowController.S.当前炼丹显示QualityType];
                break;
            case 丹药类型.辅助丹药:
                需要时间 = 属性config.每年秒数 * 丹药Config.辅助丹药炼制时间Dic[HeroWindowController.S.当前炼丹显示QualityType];
                break;
            case 丹药类型.根基丹药:
                需要时间 = 属性config.每年秒数 * 丹药Config.根基丹药炼制时间Dic[HeroWindowController.S.当前炼丹显示QualityType];
                break;
            case 丹药类型.造化丹药:
                需要时间 = 属性config.每年秒数 * 丹药Config.造化丹药炼制时间Dic[HeroWindowController.S.当前炼丹显示QualityType];
                break;
        }
        炼制进度条.maxValue = 需要时间;
        炼制进度条.value = PlayerData.S.当前炼制秒数;
        炼制百分比.text = (MathF.Min(PlayerData.S.当前炼制秒数 / 需要时间*100f,100f)).ToString("F1")+"%";
    }

    public void 刷新炼丹界面(object[] obj)
    {
        非炼制Show(HeroWindowController.S.当前炼丹显示Type, HeroWindowController.S.当前炼丹显示QualityType);
    }

    public void 炼制刷新(object[] obj)
    {
        炼丹等级.text = "炼丹等级Lv" + PlayerData.S.炼丹等级 + ":";
        炼丹经验条.maxValue = 丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级];
        炼丹经验条.value = PlayerData.S.炼丹经验;
        当前经验.text=PlayerData.S.炼丹经验.ToString("F0");
        最大经验.text=PlayerData.S.格式化数字(丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级]);
        float 需要时间 = 丹药Config.Get炼制丹药需要时间(HeroWindowController.S.当前炼丹显示Type, HeroWindowController.S.当前炼丹显示QualityType);
        炼制进度条.maxValue = 需要时间;
        炼制进度条.value = PlayerData.S.当前炼制秒数;
        炼制百分比.text = (MathF.Min(PlayerData.S.当前炼制秒数 / 需要时间*100f,100f)).ToString("F1")+"%";
    }

    public void 炼制结束(object[] obj)
    {
        丹药Type type=(丹药Type)obj[0];
        QualityType  qualityType=(QualityType)obj[1];
        非炼制Show(type, qualityType);
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
            var 打造item = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/炼丹item"), 炼制区域.transform).GetComponent<炼丹item>();
            打造item.丹药Type = item.丹药Type;
            打造item.丹药QualityType = item.丹药QualityType;
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
        ObserverModuleManager.S.RegisterEvent("刷新丹药炼制区域",刷新丹药炼制区域);
        ObserverModuleManager.S.RegisterEvent("炼制结束",炼制结束);
        ObserverModuleManager.S.RegisterEvent("炼制刷新",炼制刷新);
        ObserverModuleManager.S.RegisterEvent("刷新炼丹界面",刷新炼丹界面);
        ObserverModuleManager.S.RegisterEvent("更新炼丹界面UI",更新炼丹界面UI);
        // 加/减按钮：步进炼制数量。只改 Slider.value，由 onValueChanged 统一同步
        // 当前选择炼制数量 与 炼制数量 文本（单一数据源）；炼制过程中不可调整
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
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择炼制数量");
                return;
            }

            if (HeroWindowController.S.当前炼丹显示QualityType != QualityType.None
                && HeroWindowController.S.当前炼丹显示QualityType > 道场Config.炼丹室配置[PlayerData.S.建筑等级Dic[建筑Type.炼丹室]].最高炼制QualityType)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","当前炼丹房等级不足,请前往领主府升级炼丹房");
                return;
            }
            
           
            
            丹药炼制Item 丹药炼制Item = new 丹药炼制Item();
            丹药炼制Item.count = 当前选择炼制数量;
            丹药炼制Item.进度 = 0;
            丹药炼制Item.黄 = 黄.isOn;
            丹药炼制Item.玄 = 玄.isOn;
            丹药炼制Item.地 = 地.isOn;
            丹药炼制Item.天 = 天.isOn;
            丹药炼制Item.宇 = 宇.isOn;
            丹药炼制Item.宙 = 宙.isOn;
            丹药炼制Item.洪 = 洪.isOn;
            丹药炼制Item.荒 = 荒.isOn;
            丹药炼制Item.丹药Type = HeroWindowController.S.当前炼丹显示Type;
            丹药炼制Item.丹药QualityType = HeroWindowController.S.当前炼丹显示QualityType;
            炼制数量Slider.value = 0;
            当前选择炼制数量 = 0;
            PlayerData.S.丹药炼制List.Add(丹药炼制Item);
            炼制中Show();
        });
        exitbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        黄.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.黄品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        玄.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.玄品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));            
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        地.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.地品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        天.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.天品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        宇.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.宇品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        宙.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.宙品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        洪.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.洪品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        荒.onValueChanged.AddListener((value) =>
        {
            PlayerData.S.丹药灵药筛选Dic[QualityType.荒品]=value;
            当前选择炼制数量 = 0;
            炼制数量Slider.value = 0;
            炼制数量Slider.maxValue = Mathf.Max(0, 丹药Config.Get最大炼制数量(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType,黄.isOn,玄.isOn,地.isOn,天.isOn,宇.isOn,宙.isOn,洪.isOn,荒.isOn));
            Show灵药(HeroWindowController.S.当前炼丹显示Type,HeroWindowController.S.当前炼丹显示QualityType);
        });
        炼制数量Slider.onValueChanged.AddListener((value) =>
        {
            int newcount = (int)value;
            炼制数量Slider.value=newcount;
            炼制数量.text=newcount.ToString();
            当前选择炼制数量 = newcount;
        });
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新丹药炼制区域",刷新丹药炼制区域);
        ObserverModuleManager.S.UnRegisterEvent("炼制结束",炼制结束);
        ObserverModuleManager.S.UnRegisterEvent("炼制刷新",炼制刷新);
        ObserverModuleManager.S.UnRegisterEvent("刷新炼丹界面",刷新炼丹界面);
        ObserverModuleManager.S.UnRegisterEvent("更新炼丹界面UI",更新炼丹界面UI);
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
        HeroWindowController.S.当前炼丹显示QualityType = QualityType.黄品;
        if (PlayerData.S.丹药炼制List==null||PlayerData.S.丹药炼制List.Count<=0)
        {
            非炼制Show(丹药Type.火焰伤害,QualityType.黄品);
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
            if(item.Key==丹药Type.None)continue;
            List<丹药> list = new List<丹药>();
            for (int i = 1; i <= 8; i++)
            {
                bool flag = PlayerData.S.Get丹方解锁(item.Key, (QualityType)i);
                if (flag)
                {
                    list.Add(new 丹药(){丹药Type = item.Key,QualityType = (QualityType)i});
                }
            }
            if(list.Count == 0)continue;
            var 丹方item=Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹方item"),丹方列表content.transform).GetComponent<丹方item>();
            丹方item.丹药Type = item.Key;
            丹方item.SetItem();
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(丹方列表content.transform as RectTransform);
        Canvas.ForceUpdateCanvases();
    }
}
