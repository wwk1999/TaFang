using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 仙石重铸panel : MonoBehaviour
{
    public 重铸确认保留弹窗 重铸确认保留弹窗;
    public GameObject Content;
    public Button 左Button;
    public Button 右Button;
    public TextMeshProUGUI 页数;
    public Image 艺术字;
    public Image icon;
    public GameObject nameObj;
    public TextMeshProUGUI nameText;
    public Button 保留Button;
    public Button 重铸Button;
    public TextMeshProUGUI 粉尘Count;
    public 洗练属性Content 洗练前词条;
    public 洗练属性Content 洗练后词条;
    [NonSerialized] public int 页数num=1;
    public GameObject 箭头;
    public GameObject 粉尘Icon;
    
    public void Show左Panel()
    {
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }

        页数.text = 页数num.ToString();
        GameObject prefab = Resources.Load("Prefabs/Window/炼器/仙石重铸Item") as GameObject;
        for (int i = 48 * (页数num - 1); i < Math.Min(页数num * 48, PlayerData.S.仙石列表.Count); i++)
        {
            var 仙石item = Instantiate(prefab, Content.transform)
                .GetComponent<仙石重铸Item>();
            仙石item.仙石 = PlayerData.S.仙石列表[i];
            仙石item.SetItem();
        }
    }
    
    public void Show右Panel()
    {
        if (HeroWindowController.S.重铸panel当前仙石 == null)
        {
            艺术字.gameObject.SetActive(false);
            nameObj.SetActive(false);
            icon.gameObject.SetActive(false);
            保留Button.gameObject.SetActive(false);
            重铸Button.gameObject.SetActive(false);
            箭头.gameObject.SetActive(false);
            粉尘Count.gameObject.SetActive(false);
            粉尘Icon.gameObject.SetActive(false);
            洗练前词条.gameObject.SetActive(false);
            洗练后词条.gameObject.SetActive(false);
        }
        else
        {
            艺术字.gameObject.SetActive(true);
            nameObj.SetActive(true);
            icon.gameObject.SetActive(true);
            保留Button.gameObject.SetActive(true);
            重铸Button.gameObject.SetActive(true);
            箭头.gameObject.SetActive(true);
            粉尘Count.gameObject.SetActive(true);
            粉尘Icon.gameObject.SetActive(true);
            洗练前词条.gameObject.SetActive(true);
            洗练后词条.gameObject.SetActive(true);
            艺术字.sprite = ResourcesConfig.Get艺术字(HeroWindowController.S.重铸panel当前仙石.quality);
            nameText.text = 仙石Config.仙石名Dic[HeroWindowController.S.重铸panel当前仙石.type];
            icon.sprite = ResourcesConfig.Get仙石Sprite(HeroWindowController.S.重铸panel当前仙石.type,HeroWindowController.S.重铸panel当前仙石.quality);
            粉尘Count.text = 仙石Config.仙石重铸消耗Dic[HeroWindowController.S.重铸panel当前仙石.quality].ToString();
            洗练前词条.list = HeroWindowController.S.重铸panel当前仙石.list;
            洗练前词条.仙石Type = HeroWindowController.S.重铸panel当前仙石.type;
            洗练后词条.list = HeroWindowController.S.仙石重铸后词条;
            洗练后词条.仙石Type = HeroWindowController.S.重铸后仙石Type;
            洗练前词条.SetItem();
            洗练后词条.SetItem();
        }
    }
    
    public void Show()
    {
        Show左Panel();
        Show右Panel();
    }
    private void OnEnable()
    {
        重铸确认保留弹窗.gameObject.SetActive(false);
        HeroWindowController.S.重铸panel当前仙石 = null;
        HeroWindowController.S.重铸后仙石Type = 仙石Type.None;
        Show();
    }

    public void 刷新重铸Panel(object[] obj)
    {
        Show();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新重铸Panel",刷新重铸Panel);
        ObserverModuleManager.S.RegisterEvent("重铸仙石点击",重铸仙石点击);
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
            int 最大页数 = 0;
            最大页数=Mathf.CeilToInt(PlayerData.S.仙石列表.Count/48f);
            if (页数num < 最大页数) 
            {
                页数num++;
                Show();
            }
        });
        重铸Button.onClick.AddListener(() =>
        {
            重铸();
        });
        保留Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.仙石重铸后词条 != null)
            {
                重铸确认保留弹窗.gameObject.SetActive(true);
            }
        });
    }

    public void 重铸()
    {
        if (PlayerData.S.PropListDic[PropType.仙石精华] < 仙石Config.仙石重铸消耗Dic[HeroWindowController.S.重铸panel当前仙石.quality])
        {
            ObserverModuleManager.S.SendEvent("SendUIToast","仙石精华不足,可分解仙石获取");
            return;
        }
        仙石Type type=(仙石Type)Random.Range(1, Enum.GetValues(typeof(仙石Type)).Length);
        HeroWindowController.S.重铸后仙石Type = type;
        List<法器附加属性值> list = 仙石Config.Get仙石附加属性(HeroWindowController.S.重铸panel当前仙石.quality);
        HeroWindowController.S.仙石重铸后词条=list;
        Show();
    }
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新重铸Panel",刷新重铸Panel);
        ObserverModuleManager.S.UnRegisterEvent("重铸仙石点击",重铸仙石点击);
    }

    public void 重铸仙石点击(object[] obj)
    {
        HeroWindowController.S.仙石重铸后词条 = null;
        HeroWindowController.S.重铸后仙石Type=仙石Type.None;
        HeroWindowController.S.重铸panel当前仙石 = obj[0] as 仙石;
        Show右Panel();
        foreach (Transform item in Content.transform)
        {
            var 仙石item = item.GetComponent<仙石重铸Item>();
            if (仙石item != null)
                仙石item.gou.SetActive(HeroWindowController.S.重铸panel当前仙石 == 仙石item.仙石);
        }
    }
}
