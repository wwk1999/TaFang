using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class 仙石镶嵌panel : MonoBehaviour
{
    public Button 排序按钮;
    public Button 筛选按钮;
    public GameObject 筛选区域;
    public GameObject 排序区域;
    public GameObject 筛选区域Content;
    public GameObject 排序区域Content;
    public Button 下拉区域Mask;

    public 仙石确认镶嵌弹窗 仙石确认镶嵌弹窗;
    public Button 法器Button;
    public Button 仙石Button;
    public TextMeshProUGUI 法器白;
    public TextMeshProUGUI 法器黑;
    public TextMeshProUGUI 仙石白;
    public TextMeshProUGUI 仙石黑;
    public GameObject content;
    public TextMeshProUGUI 页数;
    public Button 左箭头;
    public Button 右箭头;
    public Image 艺术字;
    public Image Icon;
    public GameObject nameObj;
    public 仙石Image 仙石Image;

    public TextMeshProUGUI name;
    public GameObject 孔content;
    
    public RectTransform canvasRectTransform;
    public RectTransform _transform = null;
    [NonSerialized] public 法器 当前法器 = null;
    [NonSerialized]public int 页数num = 1;
    [NonSerialized]public bool 显示法器 = true;

    private void OnEnable()
    {
        HeroWindowController.S.仙石=null;
        页数num = 1;
        显示法器 = true;
        仙石Image.gameObject.SetActive(false);
        Show();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (HeroWindowController.S.仙石拖拽 && HeroWindowController.S.仙石 != null)
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                eventData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, results);
                foreach (var result in results)
                {
                    var 孔item = result.gameObject.GetComponent<镶嵌孔item>();
                    if (孔item != null)
                    {
                        ObserverModuleManager.S.SendEvent("显示仙石镶嵌确认弹窗", HeroWindowController.S.仙石, 孔item.index, HeroWindowController.S.仙石镶嵌panel当前法器);
                        break;
                    }
                }
            }
            StartCoroutine(Delay松开());
        }
        Vector2 localPoint;
        bool isInside = RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRectTransform, 
            Input.mousePosition, 
            null,
            out localPoint
        );
        _transform.localPosition=localPoint;
    }

    public void 镶嵌法器点击(object[] obj)
    {
        法器 item = obj[0] as 法器;
        当前法器 = item;
        Show右Panel();
    }

    public void Show仙石image(object[] obj)
    {
        HeroWindowController.S.仙石拖拽 = true;
        HeroWindowController.S.仙石 = obj[0] as 仙石;
        仙石Image.仙石 = HeroWindowController.S.仙石;
        StartCoroutine(Delay显示());
    }

    IEnumerator Delay显示()
    {
        yield return null;
        仙石Image.gameObject.SetActive(true);
    }
    

    IEnumerator Delay松开()
    {
        yield return null;
        HeroWindowController.S.仙石拖拽 = false;
        HeroWindowController.S.仙石=null;
        仙石Image.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("隐藏筛选选项",隐藏筛选选项);
        ObserverModuleManager.S.UnRegisterEvent("隐藏排序选项",隐藏排序选项);
        ObserverModuleManager.S.UnRegisterEvent("显示仙石镶嵌确认弹窗",显示仙石镶嵌确认弹窗);
        ObserverModuleManager.S.UnRegisterEvent("刷新仙石镶嵌Panel",刷新仙石镶嵌Panel);
        ObserverModuleManager.S.UnRegisterEvent("Show仙石image",Show仙石image);
        ObserverModuleManager.S.UnRegisterEvent("镶嵌法器点击",镶嵌法器点击);
        ObserverModuleManager.S.UnRegisterEvent("刷新仙石镶嵌背包",刷新仙石镶嵌背包);
    }

    public void 刷新仙石镶嵌Panel(object[] obj)
    {
        Show();
    }

    // 筛选/排序选项点击后刷新背包：列表长度变了，页码必须回到第一页，
    // 否则停在高页码会显示空白
    public void 刷新仙石镶嵌背包(object[] obj)
    {
        页数num = 1;
        Show();
    }

    public void 显示仙石镶嵌确认弹窗(object[] obj)
    {
        仙石 仙石=obj[0] as 仙石;
        int index=(int)obj[1];
        法器 法器 = obj[2] as 法器;
        仙石确认镶嵌弹窗.仙石 = 仙石;
        仙石确认镶嵌弹窗.index = index;
        仙石确认镶嵌弹窗.法器 = 法器;
        仙石确认镶嵌弹窗.gameObject.SetActive(true);
    }
   

    public void Init排序和筛选Content()
    {
        foreach (Transform item in 筛选区域Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in 排序区域Content.transform)
        {
            Destroy(item.gameObject);
        }
        var 筛选item1 = Instantiate(Resources.Load("Prefabs/Window/炼器/仙石筛选选项item"),筛选区域Content.transform).GetComponent<仙石筛选选项item>();
        筛选item1.仙石Type=仙石Type.None;
        筛选item1.SetItem();

        foreach (var item in 仙石Config.仙石名Dic)
        {
            var 筛选item = Instantiate(Resources.Load("Prefabs/Window/炼器/仙石筛选选项item"),筛选区域Content.transform).GetComponent<仙石筛选选项item>();
            筛选item.仙石Type=item.Key;
            筛选item.SetItem();
        }
        foreach (var item in 法器Config.法器附加属性Desc)
        {
            var 筛选item = Instantiate(Resources.Load("Prefabs/Window/炼器/仙石排序选项item"),排序区域Content.transform).GetComponent<仙石排序选项item>();
            筛选item.法器附加属性Type=item.Key;
            筛选item.SetItem();
        }
    }

    public void 隐藏筛选选项(object[] obj)
    {
        筛选区域.gameObject.SetActive(false);
        下拉区域Mask.gameObject.SetActive(false);
    }
    public void 隐藏排序选项(object[] obj)
    {
        排序区域.gameObject.SetActive(false);
        下拉区域Mask.gameObject.SetActive(false);
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("隐藏筛选选项",隐藏筛选选项);
        ObserverModuleManager.S.RegisterEvent("隐藏排序选项",隐藏排序选项);
        ObserverModuleManager.S.RegisterEvent("显示仙石镶嵌确认弹窗",显示仙石镶嵌确认弹窗);
        ObserverModuleManager.S.RegisterEvent("刷新仙石镶嵌Panel",刷新仙石镶嵌Panel);
        ObserverModuleManager.S.RegisterEvent("Show仙石image",Show仙石image);
        ObserverModuleManager.S.RegisterEvent("镶嵌法器点击",镶嵌法器点击);
        ObserverModuleManager.S.RegisterEvent("刷新仙石镶嵌背包",刷新仙石镶嵌背包);
        Init排序和筛选Content();
        排序按钮.onClick.AddListener(() =>
        {
            排序区域.gameObject.SetActive(true);
            下拉区域Mask.gameObject.SetActive(true);
        });
        筛选按钮.onClick.AddListener(() =>
        {
            筛选区域.gameObject.SetActive(true);
            下拉区域Mask.gameObject.SetActive(true);
        });
        下拉区域Mask.onClick.AddListener(() =>
        {
            排序区域.gameObject.SetActive(false);
            筛选区域.gameObject.SetActive(false);
            下拉区域Mask.gameObject.SetActive(false);
        });
        左箭头.onClick.AddListener(() =>
        {
            if (页数num > 1) 
            {
                页数num--;
                Show();
            }
        });
        右箭头.onClick.AddListener(() =>
        {
            int 最大页数 = 0;
            if (显示法器 == false)
            {
                最大页数=Mathf.CeilToInt(Get筛选排序仙石列表().Count/40f);
            }
            else
            {
                最大页数=Mathf.CeilToInt(PlayerData.S.法器列表.Count/40f);
            }
            if (页数num < 最大页数) 
            {
                页数num++;
                Show();
            }
        });

        法器Button.onClick.AddListener(() =>
        {
            if (显示法器 == false)
            {
                显示法器 = true;
                页数num = 1;
                Show();
            }
        });
        仙石Button.onClick.AddListener(() =>
        {
            if (显示法器 == true)
            {
                显示法器 = false;
                页数num = 1;
                Show();
            }
        });
    }

    public void Show切换按钮()
    {
        if (显示法器)
        {
            排序按钮.gameObject.SetActive(false);
            筛选按钮.gameObject.SetActive(false);
            法器Button.image.sprite = ResourcesConfig.按钮黑;
            法器Button.transform.localScale = Vector3.one;
            法器白.gameObject.SetActive(true);
            法器黑.gameObject.SetActive(false);
            法器白.transform.localScale = Vector3.one;
            仙石Button.image.sprite = ResourcesConfig.按钮白;
            仙石Button.transform.localScale = Vector3.one;
            仙石白.gameObject.SetActive(false);
            仙石黑.gameObject.SetActive(true);
            仙石黑.transform.localScale = Vector3.one;
        }
        else
        {
            排序按钮.gameObject.SetActive(true);
            筛选按钮.gameObject.SetActive(true);
            法器Button.image.sprite = ResourcesConfig.按钮白;
            法器Button.transform.localScale = new Vector3(-1, 1, 1);
            法器白.gameObject.SetActive(false);
            法器黑.gameObject.SetActive(true);
            法器黑.transform.localScale = new Vector3(-1, 1, 1);
            仙石Button.image.sprite = ResourcesConfig.按钮黑;
            仙石Button.transform.localScale = new Vector3(-1, 1, 1);
            仙石白.gameObject.SetActive(true);
            仙石黑.gameObject.SetActive(false);
            仙石白.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Show背包()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        页数.text=页数num.ToString();
        if (显示法器)
        {
            for (int i = 40*(页数num-1); i < Math.Min(页数num*40,PlayerData.S.法器列表.Count); i++)
            {
                var 法器item = Instantiate(Resources.Load("Prefabs/Window/炼器/镶嵌法器item"), content.transform)
                    .GetComponent<镶嵌法器item>();
                法器item.法器 = PlayerData.S.法器列表[i];
                法器item.SetItem();
                if (当前法器 != null && 法器item.法器 == 当前法器)
                    法器item.gou.SetActive(true);
            }
        }
        else
        {
            var 仙石列表 = Get筛选排序仙石列表();
            for (int i = 40*(页数num-1); i < Math.Min(页数num*40,仙石列表.Count); i++)
            {
                var 仙石item = Instantiate(Resources.Load("Prefabs/Window/炼器/镶嵌仙石item"), content.transform)
                    .GetComponent<镶嵌仙石item>();
                仙石item.仙石 = 仙石列表[i];
                仙石item.SetItem();
            }
        }
    }
    

    /// <summary>
    /// 筛选 + 排序后的仙石列表：筛选 None 显示全部；排序按选中属性从高到低，
    /// 无排序（None）时默认按最终伤害
    /// </summary>
    public List<仙石> Get筛选排序仙石列表()
    {
        var 筛选type = HeroWindowController.S.当前筛选仙石type;
        var 排序属性 = HeroWindowController.S.当前仙石排序附加属性Type;
        if (排序属性 == 法器附加属性Type.None)
        {
            排序属性 = 法器附加属性Type.最终伤害;
        }
        List<仙石> list = new List<仙石>();
        foreach (var item in PlayerData.S.仙石列表)
        {
            if (item.type == 筛选type||HeroWindowController.S.当前筛选仙石type==仙石Type.None)
            {
                list.Add(item);
            }
        }
        list.Sort((a, b) =>
        {
            int r = Get仙石属性值(b, 排序属性).CompareTo(Get仙石属性值(a, 排序属性));
            if (r != 0) return r;
            // 同值时品质高的在前，保证排序稳定可预期
            return b.quality.CompareTo(a.quality);
        });
        return list;
    }

    private static float Get仙石属性值(仙石 仙石, 法器附加属性Type type)
    {
        foreach (var item in 仙石.list)
        {
            if (item.法器附加属性Type == type) return item.count;
        }
        return 0;
    }
    public void Show左panel()
    {
        Show切换按钮();
        Show背包();
    }

    public void Show右Panel()
    {
        if (当前法器 == null)
        {
            Icon.gameObject.SetActive(false);
            nameObj.gameObject.SetActive(false);
            孔content.SetActive(false);
            艺术字.gameObject.SetActive(false);
        }
        else
        {
            Icon.gameObject.SetActive(true);
            nameObj.gameObject.SetActive(true);
            孔content.SetActive(true);
            艺术字.gameObject.SetActive(true);
            艺术字.sprite = ResourcesConfig.Get艺术字(法器Config.法器品质Dic[当前法器.法器Type]);
            Icon.sprite = ResourcesConfig.Get法器Sprite(当前法器.法器Type);
            name.text = 法器Config.法器名Dic[当前法器.法器Type];
            foreach (Transform item in 孔content.transform)
            {
                Destroy(item.gameObject);
            }

            int index = 0;
            foreach (var item in 当前法器.仙石list)
            {
                镶嵌孔item 孔item = Instantiate(Resources.Load("Prefabs/Window/炼器/镶嵌孔item"), 孔content.transform)
                    .GetComponent<镶嵌孔item>();
                孔item.仙石 = item;
                孔item.index = index;
                index++;
                孔item.SetItem();
            }
        }
    }
    public void Show()
    {
        Show左panel();
        Show右Panel();
    }
}
