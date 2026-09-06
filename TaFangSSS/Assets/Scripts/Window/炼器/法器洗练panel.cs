using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 法器洗练panel : MonoBehaviour
{
    public 洗练确认保留弹窗 洗练确认保留弹窗;
    public GameObject Content;
    public Button 左Button;
    public Button 右Button;
    public TextMeshProUGUI 页数;
    public Image 艺术字;
    public Image icon;
    public GameObject nameObj;
    public TextMeshProUGUI nameText;
    public Button 保留Button;
    public Button 洗练Button;
    public TextMeshProUGUI 粉尘Count;
    public 洗练属性Content 洗练前词条;
    public 洗练属性Content 洗练后词条;
    [NonSerialized] public int 页数num=1;
    public GameObject 箭头;
    public GameObject 粉尘Icon;

    public void Show右Panel()
    {
        if (HeroWindowController.S.洗练panel当前法器 == null)
        {
            艺术字.gameObject.SetActive(false);
            nameObj.SetActive(false);
            icon.gameObject.SetActive(false);
            保留Button.gameObject.SetActive(false);
            洗练Button.gameObject.SetActive(false);
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
            洗练Button.gameObject.SetActive(true);
            箭头.gameObject.SetActive(true);
            粉尘Count.gameObject.SetActive(true);
            粉尘Icon.gameObject.SetActive(true);
            洗练前词条.gameObject.SetActive(true);
            洗练后词条.gameObject.SetActive(true);
            艺术字.sprite = ResourcesConfig.Get艺术字(法器Config.法器品质Dic[HeroWindowController.S.洗练panel当前法器.法器Type]);
            nameText.text = 法器Config.法器名Dic[HeroWindowController.S.洗练panel当前法器.法器Type];
            icon.sprite = ResourcesConfig.Get法器Sprite(HeroWindowController.S.洗练panel当前法器.法器Type);
            粉尘Count.text = 法器Config.法器洗练消耗Dic[法器Config.法器品质Dic[HeroWindowController.S.洗练panel当前法器.法器Type]].ToString();
            洗练前词条.list = HeroWindowController.S.洗练panel当前法器.list;
            洗练后词条.list = HeroWindowController.S.洗练后词条;
            洗练前词条.SetItem();
            洗练后词条.SetItem();
        }
    }

    public void Show左Panel()
    {
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }

        页数.text = 页数num.ToString();
        GameObject prefab = Resources.Load("Prefabs/Window/炼器/洗练法器item") as GameObject;
        for (int i = 48 * (页数num - 1); i < Math.Min(页数num * 48, PlayerData.S.法器列表.Count); i++)
        {
            var 法器item = Instantiate(prefab, Content.transform)
                .GetComponent<洗练法器item>();
            法器item.法器 = PlayerData.S.法器列表[i];
            法器item.SetItem();
        }
    }

    public void Show()
    {
        Show左Panel();
        Show右Panel();
    }
    private void OnEnable()
    {
        洗练确认保留弹窗.gameObject.SetActive(false);
        HeroWindowController.S.洗练panel当前法器 = null;
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("显示洗练保留确认弹窗",显示洗练保留确认弹窗);
        ObserverModuleManager.S.UnRegisterEvent("刷新洗练Panel",刷新洗练Panel);
        ObserverModuleManager.S.UnRegisterEvent("洗练法器点击",洗练法器点击);
    }

    public void 洗练法器点击(object[] obj)
    {
        if (HeroWindowController.S.洗练后词条 != null)
        {
            HeroWindowController.S.洗练后词条.Clear();
        }
        HeroWindowController.S.洗练panel当前法器 = obj[0] as 法器;
        
        Show右Panel();
        foreach (Transform item in Content.transform)
        {
            var 洗练item = item.GetComponent<洗练法器item>();
            if (洗练item != null)
                洗练item.gou.SetActive(HeroWindowController.S.洗练panel当前法器 == 洗练item.法器);
        }
    }

    public void 洗练()
    {
        if (PlayerData.S.PropListDic[PropType.法器粉尘] <
            法器Config.法器洗练消耗Dic[法器Config.法器品质Dic[HeroWindowController.S.洗练panel当前法器.法器Type]])
        {
            ObserverModuleManager.S.SendEvent("SendUIToast","法器粉尘数量不足,可分解法器获取");
            return;
        }
        int count = HeroWindowController.S.洗练panel当前法器.list.Count;
        List<法器附加属性值> list = new List<法器附加属性值>();
        for (int i = 0; i < count; i++)
        {
            法器附加属性值 item = new 法器附加属性值();
            item.法器附加属性Type = (法器附加属性Type)Random.Range(1, Enum.GetValues(typeof(法器附加属性Type)).Length);
            float min = 法器Config
                .法器Minmaxes[
                    new 法器附加属性品质type()
                    {
                        法器附加属性Type = item.法器附加属性Type,
                        QualityType = 法器Config.法器品质Dic[HeroWindowController.S.洗练panel当前法器.法器Type]
                    }].min;
            float max = 法器Config
                .法器Minmaxes[
                    new 法器附加属性品质type()
                    {
                        法器附加属性Type = item.法器附加属性Type,
                        QualityType = 法器Config.法器品质Dic[HeroWindowController.S.洗练panel当前法器.法器Type]
                    }].max;
            item.count=Random.Range(min,max);
            list.Add(item);
        }
        HeroWindowController.S.洗练后词条 = list;
        PlayerData.S.PropListDic[PropType.法器粉尘] -=
            法器Config.法器洗练消耗Dic[法器Config.法器品质Dic[HeroWindowController.S.洗练panel当前法器.法器Type]];
    }

    public void 保留()
    {
        if (HeroWindowController.S.洗练后词条!=null)
        {
            ObserverModuleManager.S.SendEvent("显示洗练保留确认弹窗");
        }
        else
        {
            ObserverModuleManager.S.SendEvent("SendUIToast","请先洗练词条");
        }
    }

    public void 刷新洗练Panel(object[] obj)
    {
        Show右Panel();
    }

    public void 显示洗练保留确认弹窗(object[] obj)
    {
        洗练确认保留弹窗.gameObject.SetActive(true);
    }
    private void Start()
    {        
        ObserverModuleManager.S.RegisterEvent("显示洗练保留确认弹窗",显示洗练保留确认弹窗);
        ObserverModuleManager.S.RegisterEvent("刷新洗练Panel",刷新洗练Panel);
        ObserverModuleManager.S.RegisterEvent("洗练法器点击",洗练法器点击);
        洗练Button.onClick.AddListener(() =>
        {
            洗练();
            Show右Panel();
        });
        保留Button.onClick.AddListener(() =>
        {
            保留();
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
            int 最大页数 = 0;
            最大页数=Mathf.CeilToInt(PlayerData.S.法器列表.Count/48f);
            if (页数num < 最大页数) 
            {
                页数num++;
                Show();
            }
        });
    }
}
