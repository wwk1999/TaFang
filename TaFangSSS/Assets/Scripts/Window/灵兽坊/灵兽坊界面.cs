using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 灵兽坊界面 : MonoBehaviour
{
    public 灵兽洗髓无暇提示弹窗 灵兽洗髓无暇提示弹窗;
    private bool 当前显示灵兽 = true;
    public Button 灵兽Button;
    public Button 孵化Button;
    public GameObject 灵兽Panel;
    public GameObject 孵化Panel;
    public TextMeshProUGUI 灵蛋count;
    public Button 减Button;
    public Button 加Button;
    public Slider Slider;
    public TextMeshProUGUI 砸蛋数量;
    public Button 砸蛋Button;
    public TextMeshProUGUI 每道年灵蛋数;
    public Button 性别;
    public Button 品级;
    public Button 血脉;
    public Button 阶段筛选Button;
    public Button 元素筛选Button;
    public GameObject 性别下拉区域;
    public GameObject 品级下拉区域;
    public GameObject 血脉下拉区域;
    public GameObject 阶段下拉区域;
    public GameObject 元素下拉区域;
    public GameObject 性别下拉区域Content;
    public GameObject 品级下拉区域Content;
    public GameObject 血脉下拉区域Content;
    public GameObject 阶段下拉区域Content;
    public GameObject 元素下拉区域Content;
    public Button 下拉区域mask;
    public Button 翻页加;
    public Button 翻页减;
    public TextMeshProUGUI 页数;
    public GameObject 灵兽背包;

    public GameObject 灵兽信息Content;
    public Image 灵兽icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 品级Text;
    public TextMeshProUGUI 元素text;
    public TextMeshProUGUI 血脉Text;
    public TextMeshProUGUI 阶段;
    public TextMeshProUGUI 介绍;

    public Button 最终伤害锁;
    public Button 暴击伤害锁;
    public Button 元素伤害锁;

    public TextMeshProUGUI 最终伤害当前;
    public TextMeshProUGUI 最终伤害最大;
    public Image 最终伤害Image;
    public GameObject 最终伤害无暇;
    public TextMeshProUGUI 洗髓消耗Count;
    public TextMeshProUGUI 进化消耗Count;

    public TextMeshProUGUI 暴击伤害当前;
    public TextMeshProUGUI 暴击伤害最大;
    public Image 暴击伤害Image;
    public GameObject 暴击伤害无暇;

    public TextMeshProUGUI 元素伤害当前;
    public TextMeshProUGUI 元素伤害最大;
    public Image 元素伤害Image;
    public GameObject 元素伤害无暇;

    public Button 洗髓Button;
    public Button 进化Button;
    public Button 分解Button;
    public Button 退出Button;
    public 灵兽分解弹窗 灵兽分解弹窗;

    public TextMeshProUGUI 当前血晶;

    private int 当前砸蛋数量 = 0;
    private int 背包页数 = 1;
    private const int 每页灵兽数 = 28;
    private readonly List<灵兽> 筛选列表 = new List<灵兽>();
    private readonly List<灵兽item> 灵兽item池 = new List<灵兽item>();
    private bool 需要重新筛选 = true;
    private int 缓存列表总数 = -1;
    private 性别 缓存性别筛选 = (性别)(-1);
    private QualityType 缓存品级筛选 = (QualityType)(-1);
    private 血脉Type 缓存血脉筛选 = (血脉Type)(-1);
    private 阶段Type 缓存阶段筛选 = (阶段Type)(-1);
    private YuanSuType 缓存元素筛选 = (YuanSuType)(-1);
    private 性别 性别筛选 = global::性别.None;
    private QualityType 品级筛选 = QualityType.None;
    private 血脉Type 血脉筛选 = 血脉Type.None;
    private 阶段Type 阶段筛选 = 阶段Type.None;
    private YuanSuType 元素筛选 = YuanSuType.None;


    public void Set切换Button()
    {
        if (当前显示灵兽)
        {
            灵兽Button.image.sprite = ResourcesConfig.红按钮;
            孵化Button.image.sprite = ResourcesConfig.黑按钮;
        }else 
        {
            灵兽Button.image.sprite = ResourcesConfig.黑按钮;
            孵化Button.image.sprite = ResourcesConfig.红按钮;
        }
    }
    public void Show当前血晶()
    {
        当前血晶.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.血晶]);
    }

    public void Show灵蛋信息()
    {
        灵蛋count.text = "X" + (int)PlayerData.S.灵兽蛋数量;
        Slider.maxValue = PlayerData.S.灵兽蛋数量;
        Slider.value = 当前砸蛋数量;
        砸蛋数量.text = 当前砸蛋数量.ToString();
        每道年灵蛋数.text = 道场Config.Get灵兽蛋速度().ToString();
    }

    public void Show灵兽背包()
    {
        Show当前血晶();
        // 先剔除对象池中已被销毁的引用，否则复用时会访问到已销毁的 灵兽item 抛异常
        灵兽item池.RemoveAll(item => item == null);
        // 清理残留：只销毁不属于本池的遗留 item，不能全清（会连带销毁池内正在复用的 item）
        for (int i = 灵兽背包.transform.childCount - 1; i >= 0; i--)
        {
            var 子物体 = 灵兽背包.transform.GetChild(i);
            var 子item = 子物体.GetComponent<灵兽item>();
            if (子item != null && !灵兽item池.Contains(子item))
            {
                Destroy(子物体.gameObject);
            }
        }

        // 筛选条件或列表数量变化时才重扫，翻页时直接用缓存，O(28) 常量开销
        int 列表总数 = PlayerData.S.灵兽列表.Count;
        if (需要重新筛选
            || 缓存列表总数 != 列表总数
            || 缓存性别筛选 != 性别筛选
            || 缓存品级筛选 != 品级筛选
            || 缓存血脉筛选 != 血脉筛选
            || 缓存阶段筛选 != 阶段筛选
            || 缓存元素筛选 != 元素筛选)
        {
            筛选列表.Clear();
            var 灵兽列表 = PlayerData.S.灵兽列表;
            for (int i = 0; i < 列表总数; i++)
            {
                var item = 灵兽列表[i];
                if (性别筛选 != global::性别.None && item.性别 != 性别筛选) continue;
                if (品级筛选 != QualityType.None && item.QualityType != 品级筛选) continue;
                if (血脉筛选 != 血脉Type.None && item.血脉Type != 血脉筛选) continue;
                if (阶段筛选 != 阶段Type.None && item.阶段Type != 阶段筛选) continue;
                if (元素筛选 != YuanSuType.None && item.元素Type != 元素筛选) continue;
                筛选列表.Add(item);
            }

            缓存列表总数 = 列表总数;
            缓存性别筛选 = 性别筛选;
            缓存品级筛选 = 品级筛选;
            缓存血脉筛选 = 血脉筛选;
            缓存阶段筛选 = 阶段筛选;
            缓存元素筛选 = 元素筛选;
            需要重新筛选 = false;

            // 排序：已装备给英雄（HeroType != None）的排最前，组内按品级从高到低（荒品→黄品）
            筛选列表.Sort((a, b) =>
            {
                bool a装备 = a.HeroType != HeroType.None;
                bool b装备 = b.HeroType != HeroType.None;
                if (a装备 != b装备)
                {
                    return a装备 ? -1 : 1;
                }

                return b.QualityType.CompareTo(a.QualityType);
            });
        }

        int 总页数 = Mathf.Max(1, Mathf.CeilToInt((float)筛选列表.Count / 每页灵兽数));
        背包页数 = Mathf.Clamp(背包页数, 1, 总页数);
        页数.text = 背包页数 + "/" + 总页数;

        int 开始索引 = (背包页数 - 1) * 每页灵兽数;
        int 本页数量 = Mathf.Min(每页灵兽数, 筛选列表.Count - 开始索引);

        // 对象池：只实例化一次，之后翻页仅复用刷新数据，避免 Instantiate/Destroy 卡顿
        while (灵兽item池.Count < 每页灵兽数)
        {
            var 新item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽item"), 灵兽背包.transform).GetComponent<灵兽item>();
            灵兽item池.Add(新item);
        }

        for (int i = 0; i < 每页灵兽数; i++)
        {
            var item = 灵兽item池[i];
            if (i < 本页数量)
            {
                item.gameObject.SetActive(true);
                item.灵兽 = 筛选列表[开始索引 + i];
                item.SetItem();
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    public void Show灵兽信息()
    {
        if (HeroWindowController.S.当前选择灵兽 == null || HeroWindowController.S.当前选择灵兽.灵兽Type == 灵兽Type.None)
        {
            灵兽信息Content.gameObject.SetActive(false);
            return;
        }

        if (HeroWindowController.S.当前选择灵兽.最终伤害锁)
        {
            最终伤害锁.image.sprite = ResourcesConfig.锁;
        }
        else
        {
            最终伤害锁.image.sprite = ResourcesConfig.解锁;
        }

        if (HeroWindowController.S.当前选择灵兽.元素伤害锁)
        {
            元素伤害锁.image.sprite = ResourcesConfig.锁;
        }
        else
        {
            元素伤害锁.image.sprite = ResourcesConfig.解锁;
        }

        if (HeroWindowController.S.当前选择灵兽.暴击伤害锁)
        {
            暴击伤害锁.image.sprite = ResourcesConfig.锁;
        }
        else
        {
            暴击伤害锁.image.sprite = ResourcesConfig.解锁;
        }

        灵兽信息Content.gameObject.SetActive(true);
        灵兽Type type = HeroWindowController.S.当前选择灵兽.灵兽Type;
        QualityType qualityType = HeroWindowController.S.当前选择灵兽.QualityType;

        灵兽icon.sprite = ResourcesConfig.Get灵兽Sprite(type);
        name.text = 灵兽坊Config.阶段Name[HeroWindowController.S.当前选择灵兽.阶段Type] + "·" + 灵兽坊Config.灵兽名[type];
        品级Text.text = PropConfig.QualityNameDic[qualityType];
        血脉Text.text = 灵兽坊Config.血脉Name[HeroWindowController.S.当前选择灵兽.血脉Type];
        阶段.text = 灵兽坊Config.阶段Name[HeroWindowController.S.当前选择灵兽.阶段Type];
        元素text.text = HeroConfig.Get元素string(HeroWindowController.S.当前选择灵兽.元素Type);
        介绍.text = 灵兽坊Config.灵兽介绍[type];
        float 最大资质 = 灵兽坊Config.品级最大资质[qualityType] * 灵兽坊Config.血脉倍数[(int)(HeroWindowController.S.当前选择灵兽.血脉Type - 1)] *
                     灵兽坊Config.阶段倍数[(int)(HeroWindowController.S.当前选择灵兽.阶段Type - 1)];
        最终伤害当前.text = PlayerData.S.格式化数字(HeroWindowController.S.当前选择灵兽.最终伤害);
        最终伤害最大.text = PlayerData.S.格式化数字(最大资质);
        最终伤害无暇.gameObject.SetActive(HeroWindowController.S.当前选择灵兽.最终伤害无暇);
        最终伤害Image.fillAmount = HeroWindowController.S.当前选择灵兽.最终伤害 / 最大资质;

        元素伤害当前.text = PlayerData.S.格式化数字(HeroWindowController.S.当前选择灵兽.元素伤害);
        元素伤害最大.text = PlayerData.S.格式化数字(最大资质);
        元素伤害无暇.gameObject.SetActive(HeroWindowController.S.当前选择灵兽.元素伤害无暇);
        元素伤害Image.fillAmount = HeroWindowController.S.当前选择灵兽.元素伤害 / 最大资质;

        暴击伤害当前.text = PlayerData.S.格式化数字(HeroWindowController.S.当前选择灵兽.暴击伤害);
        暴击伤害最大.text = PlayerData.S.格式化数字(最大资质);
        暴击伤害无暇.gameObject.SetActive(HeroWindowController.S.当前选择灵兽.暴击伤害无暇);
        暴击伤害Image.fillAmount = HeroWindowController.S.当前选择灵兽.暴击伤害 / 最大资质;
        int 锁Count = 0;
        if (HeroWindowController.S.当前选择灵兽.最终伤害锁) 锁Count++;
        if (HeroWindowController.S.当前选择灵兽.元素伤害锁) 锁Count++;
        if (HeroWindowController.S.当前选择灵兽.暴击伤害锁) 锁Count++;

        float 洗髓消耗 = 灵兽坊Config.Get灵兽洗髓消耗(HeroWindowController.S.当前选择灵兽.QualityType,
            HeroWindowController.S.当前选择灵兽.阶段Type) * MathF.Pow(2, 锁Count);
        洗髓消耗Count.text = PlayerData.S.格式化数字(洗髓消耗);
        进化消耗Count.text = PlayerData.S.格式化数字(灵兽坊Config.Get灵兽进化消耗(qualityType, HeroWindowController.S.当前选择灵兽.阶段Type));

    }

    private void OnEnable()
    {
        当前显示灵兽 = true;
        Show界面();
    }

    public void 灵兽性别筛选(object[] obj)
    {
        性别筛选 = (性别)obj[0];
        性别下拉区域.gameObject.SetActive(false);
        下拉区域mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void 灵兽品级筛选(object[] obj)
    {
        品级筛选 = (QualityType)obj[0];
        品级下拉区域.gameObject.SetActive(false);
        下拉区域mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void 灵兽血脉筛选(object[] obj)
    {
        血脉筛选 = (血脉Type)obj[0];
        血脉下拉区域.gameObject.SetActive(false);
        下拉区域mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void 灵兽阶段筛选(object[] obj)
    {
        阶段筛选 = (阶段Type)obj[0];
        阶段下拉区域.gameObject.SetActive(false);
        下拉区域mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void 灵兽元素筛选(object[] obj)
    {
        元素筛选 = (YuanSuType)obj[0];
        元素下拉区域.gameObject.SetActive(false);
        下拉区域mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void On孵化性别筛选(object[] obj)
    {
        孵化性别筛选 = (性别)obj[0];
        孵化性别下拉区域.gameObject.SetActive(false);
        孵化mask.gameObject.SetActive(false);
        Show孵化灵兽背包();
    }

    public void On孵化品级筛选(object[] obj)
    {
        孵化品级筛选 = (QualityType)obj[0];
        孵化品级下拉区域.gameObject.SetActive(false);
        孵化mask.gameObject.SetActive(false);
        Show孵化灵兽背包();
    }

    public void On孵化血脉筛选(object[] obj)
    {
        孵化血脉筛选 = (血脉Type)obj[0];
        孵化血脉下拉区域.gameObject.SetActive(false);
        孵化mask.gameObject.SetActive(false);
        Show孵化灵兽背包();
    }

    public void On孵化阶段筛选(object[] obj)
    {
        孵化阶段筛选 = (阶段Type)obj[0];
        孵化阶段下拉区域.gameObject.SetActive(false);
        孵化mask.gameObject.SetActive(false);
        Show孵化灵兽背包();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("孵化灵兽点击",孵化灵兽点击);
        ObserverModuleManager.S.UnRegisterEvent("灵兽Item锁",灵兽Item锁);
        ObserverModuleManager.S.UnRegisterEvent("孵化池点击",孵化池点击);
        ObserverModuleManager.S.UnRegisterEvent("无暇确定洗练", 无暇确定洗练);
        ObserverModuleManager.S.UnRegisterEvent("灵兽Item点击", 灵兽Item点击);
        ObserverModuleManager.S.UnRegisterEvent("灵兽元素筛选", 灵兽元素筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵兽性别筛选", 灵兽性别筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵兽品级筛选", 灵兽品级筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵兽血脉筛选", 灵兽血脉筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵兽阶段筛选", 灵兽阶段筛选);
        ObserverModuleManager.S.UnRegisterEvent("刷新灵兽背包", 刷新灵兽背包);
        ObserverModuleManager.S.UnRegisterEvent("孵化性别筛选", On孵化性别筛选);
        ObserverModuleManager.S.UnRegisterEvent("孵化品级筛选", On孵化品级筛选);
        ObserverModuleManager.S.UnRegisterEvent("孵化血脉筛选", On孵化血脉筛选);
        ObserverModuleManager.S.UnRegisterEvent("孵化阶段筛选", On孵化阶段筛选);
    }

    public void 刷新灵兽背包(object[] obj)
    {
        Show灵兽背包();
        Show灵兽信息();
    }

    public void 灵兽Item点击(object[] obj)
    {
        Show灵兽信息();
    }

    public void Show界面()
    {
        Set切换Button();
        if (当前显示灵兽)
        {
            灵兽Panel.gameObject.SetActive(true);
            孵化Panel.gameObject.SetActive(false);
            HeroWindowController.S.当前选择灵兽 = null;
            当前砸蛋数量 = 0;
            Show灵蛋信息();
            Show灵兽背包();
            Show灵兽信息();
        }
        else
        {
            灵兽Panel.gameObject.SetActive(false);
            孵化Panel.gameObject.SetActive(true);
            HeroWindowController.S.当前选择孵化池 = null;
            Show孵化信息();
            Show孵化池列表();
            Show父母信息();
            Show孵化灵兽背包();
        }
    }

    public void 孵化池点击(object[] obj)
    {
        Show父母信息();
    }

    public void 灵兽Item锁(object[] obj)
    {
        Show灵兽背包();
    }

    public void 孵化灵兽点击(object[] obj)
    {
        Show父母信息();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("孵化灵兽点击",孵化灵兽点击);
        ObserverModuleManager.S.RegisterEvent("灵兽Item锁",灵兽Item锁);
        ObserverModuleManager.S.RegisterEvent("孵化池点击",孵化池点击);
        ObserverModuleManager.S.RegisterEvent("无暇确定洗练", 无暇确定洗练);
        ObserverModuleManager.S.RegisterEvent("灵兽Item点击", 灵兽Item点击);
        ObserverModuleManager.S.RegisterEvent("灵兽元素筛选", 灵兽元素筛选);
        ObserverModuleManager.S.RegisterEvent("灵兽性别筛选", 灵兽性别筛选);
        ObserverModuleManager.S.RegisterEvent("灵兽品级筛选", 灵兽品级筛选);
        ObserverModuleManager.S.RegisterEvent("灵兽血脉筛选", 灵兽血脉筛选);
        ObserverModuleManager.S.RegisterEvent("灵兽阶段筛选", 灵兽阶段筛选);
        ObserverModuleManager.S.RegisterEvent("刷新灵兽背包", 刷新灵兽背包);
        ObserverModuleManager.S.RegisterEvent("孵化性别筛选", On孵化性别筛选);
        ObserverModuleManager.S.RegisterEvent("孵化品级筛选", On孵化品级筛选);
        ObserverModuleManager.S.RegisterEvent("孵化血脉筛选", On孵化血脉筛选);
        ObserverModuleManager.S.RegisterEvent("孵化阶段筛选", On孵化阶段筛选);

        Init筛选();
        Init孵化筛选();
        灵兽Button.onClick.AddListener(() =>
        {
            当前显示灵兽 = true;
            Show界面();
        });
        孵化Button.onClick.AddListener(() =>
        {
            当前显示灵兽 = false;
            Show界面();
        });
        最终伤害锁.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前选择灵兽.最终伤害锁 = !HeroWindowController.S.当前选择灵兽.最终伤害锁;
            Show灵兽信息();
        });
        暴击伤害锁.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前选择灵兽.暴击伤害锁 = !HeroWindowController.S.当前选择灵兽.暴击伤害锁;
            Show灵兽信息();
        });
        元素伤害锁.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前选择灵兽.元素伤害锁 = !HeroWindowController.S.当前选择灵兽.元素伤害锁;
            Show灵兽信息();
        });
        分解Button.onClick.AddListener(() => { 灵兽分解弹窗.gameObject.SetActive(true); });
        退出Button.onClick.AddListener(() => { gameObject.SetActive(false); });
        进化Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前选择灵兽.阶段Type == 阶段Type.本源体)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "已达最大阶段");
                return;
            }

            if (!HeroWindowController.S.当前选择灵兽.最终伤害无暇 || !HeroWindowController.S.当前选择灵兽.元素伤害无暇 ||
                !HeroWindowController.S.当前选择灵兽.暴击伤害无暇)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "资质全无暇才可以进化");
                return;
            }

            if (PlayerData.S.PropListDic[PropType.血晶] < 灵兽坊Config.Get灵兽进化消耗(HeroWindowController.S.当前选择灵兽.QualityType,
                    HeroWindowController.S.当前选择灵兽.阶段Type))
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "血晶不足");
                return;
            }

            PlayerData.S.PropListDic[PropType.血晶] -= 灵兽坊Config.Get灵兽进化消耗(HeroWindowController.S.当前选择灵兽.QualityType,
                HeroWindowController.S.当前选择灵兽.阶段Type);
            HeroWindowController.S.当前选择灵兽.阶段Type++;
            HeroWindowController.S.当前选择灵兽.最终伤害无暇 = false;
            HeroWindowController.S.当前选择灵兽.暴击伤害无暇 = false;
            HeroWindowController.S.当前选择灵兽.元素伤害无暇 = false;

            ObserverModuleManager.S.SendEvent("SendUIToast", "进化成功");
            Show灵兽信息();
        });
        洗髓Button.onClick.AddListener(() =>
        {
            int 锁Count = 0;
            if (HeroWindowController.S.当前选择灵兽.最终伤害锁) 锁Count++;
            if (HeroWindowController.S.当前选择灵兽.元素伤害锁) 锁Count++;
            if (HeroWindowController.S.当前选择灵兽.暴击伤害锁) 锁Count++;

            float 洗髓消耗 = 灵兽坊Config.Get灵兽洗髓消耗(HeroWindowController.S.当前选择灵兽.QualityType,
                HeroWindowController.S.当前选择灵兽.阶段Type) * MathF.Pow(2, 锁Count);
            if (PlayerData.S.PropListDic[PropType.血晶] < 洗髓消耗)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "血晶不足");
                return;
            }

            if ((!HeroWindowController.S.当前选择灵兽.最终伤害锁 && HeroWindowController.S.当前选择灵兽.最终伤害无暇) ||
                (!HeroWindowController.S.当前选择灵兽.暴击伤害锁 && HeroWindowController.S.当前选择灵兽.暴击伤害无暇) ||
                (!HeroWindowController.S.当前选择灵兽.元素伤害锁 && HeroWindowController.S.当前选择灵兽.元素伤害无暇))
            {
                灵兽洗髓无暇提示弹窗.gameObject.SetActive(true);
                return;
            }

            PlayerData.S.PropListDic[PropType.血晶] -= 洗髓消耗;
            float 最大资质 = 灵兽坊Config.品级最大资质[HeroWindowController.S.当前选择灵兽.QualityType] *
                         灵兽坊Config.血脉倍数[(int)(HeroWindowController.S.当前选择灵兽.血脉Type - 1)] *
                         灵兽坊Config.阶段倍数[(int)(HeroWindowController.S.当前选择灵兽.阶段Type - 1)];
            if (!HeroWindowController.S.当前选择灵兽.最终伤害锁)
            {
                float random = Random.Range(0, 100f);
                if (random < 1f)
                {
                    HeroWindowController.S.当前选择灵兽.最终伤害无暇 = true;
                    HeroWindowController.S.当前选择灵兽.最终伤害 = 最大资质;
                }
                else
                {
                    HeroWindowController.S.当前选择灵兽.最终伤害无暇 = false;
                    HeroWindowController.S.当前选择灵兽.最终伤害 = Random.Range(0, 最大资质);
                }
            }

            if (!HeroWindowController.S.当前选择灵兽.暴击伤害锁)
            {
                float random1 = Random.Range(0, 100f);
                if (random1 < 1f)
                {
                    HeroWindowController.S.当前选择灵兽.暴击伤害无暇 = true;
                    HeroWindowController.S.当前选择灵兽.暴击伤害 = 最大资质;
                }
                else
                {
                    HeroWindowController.S.当前选择灵兽.暴击伤害无暇 = false;
                    HeroWindowController.S.当前选择灵兽.暴击伤害 = Random.Range(0, 最大资质);
                }
            }

            if (!HeroWindowController.S.当前选择灵兽.元素伤害锁)
            {
                float random2 = Random.Range(0, 100f);
                if (random2 < 1f)
                {
                    HeroWindowController.S.当前选择灵兽.元素伤害无暇 = true;
                    HeroWindowController.S.当前选择灵兽.元素伤害 = 最大资质;
                }
                else
                {
                    HeroWindowController.S.当前选择灵兽.元素伤害无暇 = false;
                    HeroWindowController.S.当前选择灵兽.元素伤害 = Random.Range(0, 最大资质);
                }
            }

            Show当前血晶();
            Show灵兽信息();
        });

        翻页加.onClick.AddListener(() =>
        {
            背包页数++;
            Show灵兽背包();
        });
        翻页减.onClick.AddListener(() =>
        {
            背包页数--;
            Show灵兽背包();
        });
        孵化翻页加.onClick.AddListener(() =>
        {
            孵化背包页数++;
            Show孵化灵兽背包();
        });
        孵化翻页减.onClick.AddListener(() =>
        {
            孵化背包页数--;
            Show孵化灵兽背包();
        });
        减Button.onClick.AddListener(() =>
        {
            当前砸蛋数量--;
            当前砸蛋数量 = Math.Max(0, 当前砸蛋数量);
            Show灵蛋信息();
        });
        加Button.onClick.AddListener(() =>
        {
            当前砸蛋数量++;
            当前砸蛋数量 = Math.Min((int)PlayerData.S.灵兽蛋数量, 当前砸蛋数量);
            Show灵蛋信息();
        });
        Slider.onValueChanged.AddListener((value) =>
        {
            int newcount = (int)value;
            Slider.value = newcount;
            当前砸蛋数量 = newcount;
            Show灵蛋信息();
        });
        砸蛋Button.onClick.AddListener(() => { StartCoroutine(砸蛋()); });
        性别.onClick.AddListener(() =>
        {
            下拉区域mask.gameObject.SetActive(true);
            性别下拉区域.gameObject.SetActive(true);
        });
        品级.onClick.AddListener(() =>
        {
            下拉区域mask.gameObject.SetActive(true);
            品级下拉区域.gameObject.SetActive(true);
        });
        血脉.onClick.AddListener(() =>
        {
            下拉区域mask.gameObject.SetActive(true);
            血脉下拉区域.gameObject.SetActive(true);
        });
        阶段筛选Button.onClick.AddListener(() =>
        {
            下拉区域mask.gameObject.SetActive(true);
            阶段下拉区域.gameObject.SetActive(true);
        });
        元素筛选Button.onClick.AddListener(() =>
        {
            下拉区域mask.gameObject.SetActive(true);
            元素下拉区域.gameObject.SetActive(true);
        });
        下拉区域mask.onClick.AddListener(() =>
        {
            性别下拉区域.gameObject.SetActive(false);
            品级下拉区域.gameObject.SetActive(false);
            血脉下拉区域.gameObject.SetActive(false);
            阶段下拉区域.gameObject.SetActive(false);
            元素下拉区域.gameObject.SetActive(false);
            下拉区域mask.gameObject.SetActive(false);
        });
        孵化性别Button.onClick.AddListener(() =>
        {
            孵化mask.gameObject.SetActive(true);
            孵化性别下拉区域.gameObject.SetActive(true);
        });
        孵化品级Button.onClick.AddListener(() =>
        {
            孵化mask.gameObject.SetActive(true);
            孵化品级下拉区域.gameObject.SetActive(true);
        });
        孵化血脉Button.onClick.AddListener(() =>
        {
            孵化mask.gameObject.SetActive(true);
            孵化血脉下拉区域.gameObject.SetActive(true);
        });
        孵化阶段Button.onClick.AddListener(() =>
        {
            孵化mask.gameObject.SetActive(true);
            孵化阶段下拉区域.gameObject.SetActive(true);
        });
        孵化mask.onClick.AddListener(() =>
        {
            孵化性别下拉区域.gameObject.SetActive(false);
            孵化品级下拉区域.gameObject.SetActive(false);
            孵化血脉下拉区域.gameObject.SetActive(false);
            孵化阶段下拉区域.gameObject.SetActive(false);
            孵化mask.gameObject.SetActive(false);
        });
    }

    public void 无暇确定洗练(object[] obj)
    {
        int 锁Count = 0;
        if (HeroWindowController.S.当前选择灵兽.最终伤害锁) 锁Count++;
        if (HeroWindowController.S.当前选择灵兽.元素伤害锁) 锁Count++;
        if (HeroWindowController.S.当前选择灵兽.暴击伤害锁) 锁Count++;

        float 洗髓消耗 = 灵兽坊Config.Get灵兽洗髓消耗(HeroWindowController.S.当前选择灵兽.QualityType,
            HeroWindowController.S.当前选择灵兽.阶段Type) * MathF.Pow(2, 锁Count);
        if (PlayerData.S.PropListDic[PropType.血晶] < 洗髓消耗)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "血晶不足");
            return;
        }

        PlayerData.S.PropListDic[PropType.血晶] -= 洗髓消耗;
        float 最大资质 = 灵兽坊Config.品级最大资质[HeroWindowController.S.当前选择灵兽.QualityType] *
                     灵兽坊Config.血脉倍数[(int)(HeroWindowController.S.当前选择灵兽.血脉Type - 1)] *
                     灵兽坊Config.阶段倍数[(int)(HeroWindowController.S.当前选择灵兽.阶段Type - 1)];
        if (!HeroWindowController.S.当前选择灵兽.最终伤害锁)
        {
            float random = Random.Range(0, 100f);
            if (random < 1f)
            {
                HeroWindowController.S.当前选择灵兽.最终伤害无暇 = true;
                HeroWindowController.S.当前选择灵兽.最终伤害 = 最大资质;
            }
            else
            {
                HeroWindowController.S.当前选择灵兽.最终伤害无暇 = false;
                HeroWindowController.S.当前选择灵兽.最终伤害 = Random.Range(0, 最大资质);
            }
        }

        if (!HeroWindowController.S.当前选择灵兽.暴击伤害锁)
        {
            float random1 = Random.Range(0, 100f);
            if (random1 < 1f)
            {
                HeroWindowController.S.当前选择灵兽.暴击伤害无暇 = true;
                HeroWindowController.S.当前选择灵兽.暴击伤害 = 最大资质;
            }
            else
            {
                HeroWindowController.S.当前选择灵兽.暴击伤害无暇 = false;
                HeroWindowController.S.当前选择灵兽.暴击伤害 = Random.Range(0, 最大资质);
            }
        }

        if (!HeroWindowController.S.当前选择灵兽.元素伤害锁)
        {
            float random2 = Random.Range(0, 100f);
            if (random2 < 1f)
            {
                HeroWindowController.S.当前选择灵兽.元素伤害无暇 = true;
                HeroWindowController.S.当前选择灵兽.元素伤害 = 最大资质;
            }
            else
            {
                HeroWindowController.S.当前选择灵兽.元素伤害无暇 = false;
                HeroWindowController.S.当前选择灵兽.元素伤害 = Random.Range(0, 最大资质);
            }
        }

        Show灵兽信息();
    }


    public void Init筛选()
    {
        foreach (Transform item in 性别下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 品级下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 血脉下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 阶段下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 元素下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < Enum.GetValues(typeof(性别)).Length; i++)
        {
            var 性别筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽性别筛选Item"), 性别下拉区域Content.transform)
                .GetComponent<灵兽性别筛选Item>();
            性别筛选item.性别 = (性别)i;
            性别筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(血脉Type)).Length; i++)
        {
            var 血脉筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽血脉筛选Item"), 血脉下拉区域Content.transform)
                .GetComponent<灵兽血脉筛选Item>();
            血脉筛选item.血脉Type = (血脉Type)i;
            血脉筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(阶段Type)).Length; i++)
        {
            var 阶段筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽阶段筛选Item"), 阶段下拉区域Content.transform)
                .GetComponent<灵兽阶段筛选Item>();
            阶段筛选item.阶段Type = (阶段Type)i;
            阶段筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(YuanSuType)).Length; i++)
        {
            var 元素筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽元素筛选Item"), 元素下拉区域Content.transform)
                .GetComponent<灵兽元素筛选Item>();
            元素筛选item.YuanSuType = (YuanSuType)i;
            元素筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(QualityType)).Length; i++)
        {
            var 品级筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽品质筛选Item"), 品级下拉区域Content.transform)
                .GetComponent<灵兽品级筛选Item>();
            品级筛选item.QualityType = (QualityType)i;
            品级筛选item.SetItem();
        }

    }

    public void Init孵化筛选()
    {
        foreach (Transform item in 孵化性别下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 孵化品级下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 孵化血脉下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 孵化阶段下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < Enum.GetValues(typeof(性别)).Length; i++)
        {
            var 性别筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/孵化性别筛选Item"), 孵化性别下拉区域Content.transform)
                .GetComponent<孵化性别筛选Item>();
            性别筛选item.性别 = (性别)i;
            性别筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(QualityType)).Length; i++)
        {
            var 品级筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/孵化品级筛选Item"), 孵化品级下拉区域Content.transform)
                .GetComponent<孵化品级筛选Item>();
            品级筛选item.QualityType = (QualityType)i;
            品级筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(血脉Type)).Length; i++)
        {
            var 血脉筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/孵化血脉筛选Item"), 孵化血脉下拉区域Content.transform)
                .GetComponent<孵化血脉筛选Item>();
            血脉筛选item.血脉Type = (血脉Type)i;
            血脉筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(阶段Type)).Length; i++)
        {
            var 阶段筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/孵化阶段筛选Item"), 孵化阶段下拉区域Content.transform)
                .GetComponent<孵化阶段筛选Item>();
            阶段筛选item.阶段Type = (阶段Type)i;
            阶段筛选item.SetItem();
        }
    }

    public IEnumerator 砸蛋()
    {
        Dictionary<灵兽Type, int> 砸蛋字典 = new Dictionary<灵兽Type, int>();
        for (int i = 0; i < 当前砸蛋数量; i++)
        {
            QualityType qualityType = QualityType.None;
            var random = Random.Range(0, 10000f);
            float count = 0;
            int index = 0;
            foreach (var item in 灵兽坊Config.灵兽蛋概率)
            {
                count += item;
                if (random <= count)
                {
                    qualityType = (QualityType)(index + 1);
                    break;
                }

                index++;
            }

            灵兽 灵兽 = 灵兽坊Config.砸蛋获得灵兽(qualityType);
            if (砸蛋字典.ContainsKey(灵兽.灵兽Type))
            {
                砸蛋字典[灵兽.灵兽Type]++;
            }
            else
            {
                砸蛋字典[灵兽.灵兽Type] = 1;
            }

            PlayerData.S.灵兽列表.Add(灵兽);
        }

        PlayerData.S.灵兽蛋数量 -= 当前砸蛋数量;
        当前砸蛋数量 = 0;
        Show灵蛋信息();
        Show灵兽背包();
        foreach (var item in 砸蛋字典)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", 灵兽坊Config.灵兽名[item.Key], 灵兽坊Config.灵兽品质[item.Key],
                item.Value);
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    
    
    
    
    
    
    
    
    
    //孵化界面
    public TextMeshProUGUI 当前孵化池数量;
    public TextMeshProUGUI 最大孵化池数量;
    public GameObject 孵化池列表;
    public Button 父bg;
    public Image 父icon;
    public TextMeshProUGUI 父Name;
    public TextMeshProUGUI 父血脉;
    public GameObject 父Content;

    public Button 母bg;
    public Image 母icon;
    public TextMeshProUGUI 母Name;
    public TextMeshProUGUI 母血脉;
    public GameObject 母Content;
    public GameObject 父母信息Content;

    public Image 孵化进度条;
    public TextMeshProUGUI 孵化百分比;
    public Button 结束孵化Button;

    public Button 孵化性别Button;
    public Button 孵化品级Button;
    public Button 孵化血脉Button;
    public Button 孵化阶段Button;

    public GameObject 孵化性别下拉区域;
    public GameObject 孵化品级下拉区域;
    public GameObject 孵化血脉下拉区域;
    public GameObject 孵化阶段下拉区域;
    public GameObject 孵化性别下拉区域Content;
    public GameObject 孵化品级下拉区域Content;
    public GameObject 孵化血脉下拉区域Content;
    public GameObject 孵化阶段下拉区域Content;
    
    public Button 孵化mask;
    public GameObject 孵化灵兽背包;
    public Button 孵化翻页减;
    public Button 孵化翻页加;
    public TextMeshProUGUI num;

    private 性别 孵化性别筛选;
    private QualityType 孵化品级筛选;
    private 血脉Type 孵化血脉筛选;
    private 阶段Type 孵化阶段筛选;

    private int 孵化背包页数 = 1;
    private const int 每页孵化灵兽数 = 20;
    private readonly List<灵兽> 孵化筛选列表 = new List<灵兽>();
    private readonly List<孵化灵兽item> 孵化item池 = new List<孵化灵兽item>();
    // 指派/取消指派灵兽给孵化池（HeroType 变化但列表数量不变）时置 true，强制下次重扫排序
    private bool 孵化需要重新筛选 = true;
    private int 缓存孵化列表总数 = -1;
    private 性别 缓存孵化性别筛选 = (性别)(-1);
    private QualityType 缓存孵化品级筛选 = (QualityType)(-1);
    private 血脉Type 缓存孵化血脉筛选 = (血脉Type)(-1);
    private 阶段Type 缓存孵化阶段筛选 = (阶段Type)(-1);

    public int Get孵化中孵化池数量()
    {
        int count = 0;
        foreach (var item in PlayerData.S.孵化池列表)
        {
            if (item.Value.孵化中)
            {
                count++;
            }
        }

        return count;
    }
    public void Show孵化信息()
    {
        当前孵化池数量.text=Get孵化中孵化池数量().ToString();
        最大孵化池数量.text=PlayerData.S.建筑等级Dic[建筑Type.灵兽坊].ToString();
    }

    public void Show孵化池列表()
    {
        foreach (Transform item in 孵化池列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.孵化池列表)
        {
            var 孵化池 = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/孵化池item"),孵化池列表.transform).GetComponent<孵化池item>();
            孵化池.孵化池 = item.Value;
            孵化池.SetItem();
        }
    }

    public void Show父母信息()
    {
        if (HeroWindowController.S.当前选择孵化池 == null)
        {
            父母信息Content.gameObject.SetActive(false);
        }
        else
        {
            父母信息Content.gameObject.SetActive(true);
            if (HeroWindowController.S.当前选择孵化池.父 == null)
            {
                父Content.gameObject.SetActive(false);
            }
            else
            {
                父Content.gameObject.SetActive(true);
                父bg.image.sprite =
                    ResourcesConfig.Get道具背景框SpriteByQuality(灵兽坊Config.灵兽品质[HeroWindowController.S.当前选择孵化池.父.灵兽Type]);
                父icon.sprite = ResourcesConfig.Get灵兽Sprite(HeroWindowController.S.当前选择孵化池.父.灵兽Type);
                父Name.text = 灵兽坊Config.灵兽名[HeroWindowController.S.当前选择孵化池.父.灵兽Type];
                父血脉.text=灵兽坊Config.血脉Name[HeroWindowController.S.当前选择孵化池.父.血脉Type];
            }
            
            if (HeroWindowController.S.当前选择孵化池.母 == null)
            {
                母Content.gameObject.SetActive(false);
            }
            else
            {
                母Content.gameObject.SetActive(true);
                母bg.image.sprite =
                    ResourcesConfig.Get道具背景框SpriteByQuality(灵兽坊Config.灵兽品质[HeroWindowController.S.当前选择孵化池.母.灵兽Type]);
                母icon.sprite = ResourcesConfig.Get灵兽Sprite(HeroWindowController.S.当前选择孵化池.母.灵兽Type);
                母Name.text = 灵兽坊Config.灵兽名[HeroWindowController.S.当前选择孵化池.母.灵兽Type];
                母血脉.text=灵兽坊Config.血脉Name[HeroWindowController.S.当前选择孵化池.母.血脉Type];
            }

            if (HeroWindowController.S.当前选择孵化池.需要道年 == 0)
            {
                孵化进度条.fillAmount = 0;
                孵化百分比.text = "0%";
            }
            else
            {
                孵化进度条.fillAmount = HeroWindowController.S.当前选择孵化池.当前道年 / HeroWindowController.S.当前选择孵化池.需要道年;
                孵化百分比.text = (HeroWindowController.S.当前选择孵化池.当前道年 / HeroWindowController.S.当前选择孵化池.需要道年).ToString("F1");
            }
        }
    }

    public void Show孵化灵兽背包()
    {
        // 先剔除对象池中已被销毁的引用
        孵化item池.RemoveAll(item => item == null);
        // 清理不属于本池的残留 item
        for (int i = 孵化灵兽背包.transform.childCount - 1; i >= 0; i--)
        {
            var 子物体 = 孵化灵兽背包.transform.GetChild(i);
            var 子item = 子物体.GetComponent<孵化灵兽item>();
            if (子item != null && !孵化item池.Contains(子item))
            {
                Destroy(子物体.gameObject);
            }
        }

        // 筛选条件或列表数量变化时才重扫，翻页时直接用缓存
        int 列表总数 = PlayerData.S.灵兽列表.Count;
        if (孵化需要重新筛选
            || 缓存孵化列表总数 != 列表总数
            || 缓存孵化性别筛选 != 孵化性别筛选
            || 缓存孵化品级筛选 != 孵化品级筛选
            || 缓存孵化血脉筛选 != 孵化血脉筛选
            || 缓存孵化阶段筛选 != 孵化阶段筛选)
        {
            孵化筛选列表.Clear();
            var 灵兽列表 = PlayerData.S.灵兽列表;
            for (int i = 0; i < 列表总数; i++)
            {
                var item = 灵兽列表[i];
                if (孵化性别筛选 != global::性别.None && item.性别 != 孵化性别筛选) continue;
                if (孵化品级筛选 != QualityType.None && item.QualityType != 孵化品级筛选) continue;
                if (孵化血脉筛选 != 血脉Type.None && item.血脉Type != 孵化血脉筛选) continue;
                if (孵化阶段筛选 != 阶段Type.None && item.阶段Type != 孵化阶段筛选) continue;
                孵化筛选列表.Add(item);
            }

            缓存孵化列表总数 = 列表总数;
            缓存孵化性别筛选 = 孵化性别筛选;
            缓存孵化品级筛选 = 孵化品级筛选;
            缓存孵化血脉筛选 = 孵化血脉筛选;
            缓存孵化阶段筛选 = 孵化阶段筛选;
            孵化需要重新筛选 = false;

            // 排序：已指派英雄（HeroType != None）的排最前，组内按品级从高到低（荒品→黄品）
            孵化筛选列表.Sort((a, b) =>
            {
                bool a装备 = a.HeroType != HeroType.None;
                bool b装备 = b.HeroType != HeroType.None;
                if (a装备 != b装备)
                {
                    return a装备 ? -1 : 1;
                }

                return b.QualityType.CompareTo(a.QualityType);
            });
        }

        int 总页数 = Mathf.Max(1, Mathf.CeilToInt((float)孵化筛选列表.Count / 每页孵化灵兽数));
        孵化背包页数 = Mathf.Clamp(孵化背包页数, 1, 总页数);

        int 开始索引 = (孵化背包页数 - 1) * 每页孵化灵兽数;
        int 本页数量 = Mathf.Min(每页孵化灵兽数, 孵化筛选列表.Count - 开始索引);

        // 对象池：只实例化一次，之后翻页仅复用刷新数据
        while (孵化item池.Count < 每页孵化灵兽数)
        {
            var 新item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/孵化灵兽item"), 孵化灵兽背包.transform).GetComponent<孵化灵兽item>();
            孵化item池.Add(新item);
        }

        for (int i = 0; i < 每页孵化灵兽数; i++)
        {
            var item = 孵化item池[i];
            if (i < 本页数量)
            {
                item.gameObject.SetActive(true);
                item.灵兽 = 孵化筛选列表[开始索引 + i];
                item.SetItem();
            }
            else
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}
