using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 仙石镶嵌panel : MonoBehaviour
{
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
        HeroWindowController.S.仙石镶嵌panel当前法器 = null;
        HeroWindowController.S.仙石=null;
        仙石Image.gameObject.SetActive(false);
        Show();
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
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
        ObserverModuleManager.S.UnRegisterEvent("刷新仙石镶嵌Panel",刷新仙石镶嵌Panel);
        ObserverModuleManager.S.UnRegisterEvent("Show仙石image",Show仙石image);
        ObserverModuleManager.S.UnRegisterEvent("镶嵌法器点击",镶嵌法器点击);
    }

    public void 刷新仙石镶嵌Panel(object[] obj)
    {
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
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("显示仙石镶嵌确认弹窗",显示仙石镶嵌确认弹窗);
        ObserverModuleManager.S.RegisterEvent("刷新仙石镶嵌Panel",刷新仙石镶嵌Panel);
        ObserverModuleManager.S.RegisterEvent("Show仙石image",Show仙石image);
        ObserverModuleManager.S.RegisterEvent("镶嵌法器点击",镶嵌法器点击);
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
                最大页数=Mathf.CeilToInt(PlayerData.S.仙石列表.Count/40f);
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
            for (int i = 40*(页数num-1); i < Math.Min(页数num*40-1,PlayerData.S.法器列表.Count); i++)
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
            for (int i = 40*(页数num-1); i < Math.Min(页数num*40-1,PlayerData.S.仙石列表.Count); i++)
            {
                var 仙石item = Instantiate(Resources.Load("Prefabs/Window/炼器/镶嵌仙石item"), content.transform)
                    .GetComponent<镶嵌仙石item>();
                仙石item.仙石 = PlayerData.S.仙石列表[i];
                仙石item.SetItem();
            }
        }
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
