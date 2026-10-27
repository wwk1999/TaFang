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
    public 法器洗练无暇提示弹窗 法器洗练无暇提示弹窗;
    public Button 英雄筛选Button;
    public GameObject 英雄筛选;
    public GameObject 英雄筛选Content;
    public Button 英雄筛选mask;


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
    public TextMeshProUGUI 当前粉尘Count;
    public TextMeshProUGUI 需要粉尘Count;

    public 洗练属性Content 洗练前词条;
    public 洗练属性Content 洗练后词条;
    [NonSerialized] public int 页数num = 1;
    public GameObject 箭头;
    public GameObject 粉尘Icon;
    public TextMeshProUGUI 洗练前无暇;
    public TextMeshProUGUI 洗练后无暇;
    
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
            当前粉尘Count.gameObject.SetActive(false);
            需要粉尘Count.gameObject.SetActive(false);

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
            当前粉尘Count.gameObject.SetActive(true);
            需要粉尘Count.gameObject.SetActive(true);
            粉尘Icon.gameObject.SetActive(true);
            洗练前词条.gameObject.SetActive(true);
            洗练后词条.gameObject.SetActive(true);
            艺术字.sprite = ResourcesConfig.Get艺术字(HeroWindowController.S.洗练panel当前法器.品质);
            nameText.text = 法器Config.Get法器Name(HeroWindowController.S.洗练panel当前法器.法器Type, HeroWindowController.S.洗练panel当前法器.阶数);
            icon.sprite = ResourcesConfig.Get法器Sprite(HeroWindowController.S.洗练panel当前法器.法器Type, HeroWindowController.S.洗练panel当前法器.阶数);
            int count = 0;
            int 洗练后无暇count = 0;
            int 洗练前无暇count = 0;
            if (HeroWindowController.S.洗练panel当前法器 != null && HeroWindowController.S.洗练panel当前法器.list.Count > 0)
            {
                foreach (var item in HeroWindowController.S.洗练panel当前法器.list)
                {
                    if (item.无暇)
                    {
                        洗练前无暇count++;
                    }
                }
            }
            if (HeroWindowController.S.洗练后词条 != null&&HeroWindowController.S.洗练后词条.Count>0)
            {
                foreach (var item in HeroWindowController.S.洗练后词条)
                {
                    if (item.无暇)
                    {
                        洗练后无暇count++;
                    }
                    if (item.锁)
                    {
                        count++;
                    }
                }
            }
            else
            {
                foreach (var item in HeroWindowController.S.洗练panel当前法器.list)
                {
                    if (item.锁)
                    {
                        count++;
                    }
                }
            }

            洗练前无暇.text = 洗练前无暇count.ToString();
            if (HeroWindowController.S.洗练后词条 != null && HeroWindowController.S.洗练后词条.Count > 0)
            {
                洗练后无暇.gameObject.SetActive(true);
                洗练后无暇.text = 洗练后无暇count.ToString();
            }
            else
            {
                洗练后无暇.gameObject.SetActive(false);
            }


            float 需要粉尘 = 法器Config.法器洗练消耗Dic[HeroWindowController.S.洗练panel当前法器.品质] *
                         MathF.Pow(2, count);
            需要粉尘Count.text = PlayerData.S.格式化数字(需要粉尘);
            当前粉尘Count.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.法器粉尘]);
            洗练前词条.list = HeroWindowController.S.洗练panel当前法器.list;
            洗练后词条.list = HeroWindowController.S.洗练后词条;
            洗练后词条.是否带锁 = true;
            洗练前词条.是否带锁 = true;
            洗练前词条.QualityType = HeroWindowController.S.洗练panel当前法器.品质;
            洗练后词条.QualityType = HeroWindowController.S.洗练panel当前法器.品质;
            洗练前词条.SetItem();
            洗练后词条.SetItem();
        }
    }

    public void Show英雄法器(HeroType heroType)
    {
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }
        页数num = 1;
        页数.text = 页数num.ToString();
        if (heroType == HeroType.None)
        {
            Show左Panel();
            return;
        }
        GameObject prefab = Resources.Load("Prefabs/Window/炼器/洗练法器item") as GameObject;

        if (PlayerData.S.HeroDataDic[heroType].武器 != null)
        {
            var 武器 = Instantiate(prefab, Content.transform)
                .GetComponent<洗练法器item>();
            武器.法器 = PlayerData.S.HeroDataDic[heroType].武器;
            武器.法器.HeroType = heroType;
            武器.SetItem();
        }
        
        if (PlayerData.S.HeroDataDic[heroType].头盔 != null)
        {
            var 头盔 = Instantiate(prefab, Content.transform)
                .GetComponent<洗练法器item>();
            头盔.法器 = PlayerData.S.HeroDataDic[heroType].头盔;
            头盔.法器.HeroType = heroType;
            头盔.SetItem();
        }
        
        if (PlayerData.S.HeroDataDic[heroType].衣服 != null)
        {
            var 衣服 = Instantiate(prefab, Content.transform)
                .GetComponent<洗练法器item>();
            衣服.法器 = PlayerData.S.HeroDataDic[heroType].衣服;
            衣服.法器.HeroType = heroType;
            衣服.SetItem();
        }
        
        if (PlayerData.S.HeroDataDic[heroType].鞋子 != null)
        {
            var 鞋子 = Instantiate(prefab, Content.transform)
                .GetComponent<洗练法器item>();
            鞋子.法器 = PlayerData.S.HeroDataDic[heroType].鞋子;
            鞋子.法器.HeroType = heroType;
            鞋子.SetItem();
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

    public void Set出战英雄筛选()
    {
        foreach (Transform Item in 英雄筛选Content.transform)
        {
            Destroy(Item.gameObject);
        }
        var 出战英雄筛选Item1 = Instantiate(Resources.Load("Prefabs/Window/炼器/法器洗练英雄筛选Item"), 英雄筛选Content.transform)
            .GetComponent<法器洗练英雄筛选Item>();
        出战英雄筛选Item1.HeroType = HeroType.None;
        出战英雄筛选Item1.SetItem();

        foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
        {
            if (item != HeroType.None)
            {
                var 出战英雄筛选Item = Instantiate(Resources.Load("Prefabs/Window/炼器/法器洗练英雄筛选Item"), 英雄筛选Content.transform)
                    .GetComponent<法器洗练英雄筛选Item>();
                出战英雄筛选Item.HeroType = item;
                出战英雄筛选Item.SetItem();
            }
        }
    }
    private void OnEnable()
    {
        Set出战英雄筛选();
        洗练确认保留弹窗.gameObject.SetActive(false);
        HeroWindowController.S.洗练panel当前法器 = null;
        页数num = 1;
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("法器洗练无暇确定洗练", 法器洗练无暇确定洗练);
        ObserverModuleManager.S.UnRegisterEvent("法器洗练英雄筛选", 法器洗练英雄筛选);
        ObserverModuleManager.S.UnRegisterEvent("法器词条洗练锁", 法器词条洗练锁);
        ObserverModuleManager.S.UnRegisterEvent("显示洗练保留确认弹窗", 显示洗练保留确认弹窗);
        ObserverModuleManager.S.UnRegisterEvent("刷新洗练Panel", 刷新洗练Panel);
        ObserverModuleManager.S.UnRegisterEvent("洗练法器点击", 洗练法器点击);
    }

    public void 法器词条洗练锁(object[] obj)
    {
        int count = 0;
        if (HeroWindowController.S.洗练后词条 != null&&HeroWindowController.S.洗练后词条.Count>0)
        {
            foreach (var item in HeroWindowController.S.洗练后词条)
            {
                if (item.锁)
                {
                    count++;
                }
            }
        }
        else
        {
            foreach (var item in HeroWindowController.S.洗练panel当前法器.list)
            {
                if (item.锁)
                {
                    count++;
                }
            }
        }


        float 需要粉尘 = 法器Config.法器洗练消耗Dic[HeroWindowController.S.洗练panel当前法器.品质] *
                     MathF.Pow(2, count);
        需要粉尘Count.text = PlayerData.S.格式化数字(需要粉尘);
        当前粉尘Count.text=PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.法器粉尘]);
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
        int count1 = 0;
        if (HeroWindowController.S.洗练后词条 != null&&HeroWindowController.S.洗练后词条.Count>0)
        {
            foreach (var item in HeroWindowController.S.洗练后词条)
            {
                if (item.锁)
                {
                    count1++;
                }
            }
        }
        else
        {
            foreach (var item in HeroWindowController.S.洗练panel当前法器.list)
            {
                if (item.锁)
                {
                    count1++;
                }
            }
        }

        float 需要粉尘 = 法器Config.法器洗练消耗Dic[HeroWindowController.S.洗练panel当前法器.品质] *
                     MathF.Pow(2, count1);
        if (PlayerData.S.PropListDic[PropType.法器粉尘] < 需要粉尘)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "法器粉尘数量不足,可分解法器获取");
            return;
        }

        List<法器附加属性值> list = new List<法器附加属性值>();
        if (HeroWindowController.S.洗练后词条 != null && HeroWindowController.S.洗练后词条.Count > 0)
        {
            list = HeroWindowController.S.洗练后词条;
        }
        else
        {
            foreach (var item in HeroWindowController.S.洗练panel当前法器.list)
            {
                法器附加属性值 法器附加属性值 = new 法器附加属性值();
                法器附加属性值.锁 = item.锁;
                法器附加属性值.count = item.count;
                法器附加属性值.无暇 = item.无暇;
                法器附加属性值.法器附加属性Type = item.法器附加属性Type;
                list.Add(法器附加属性值);
            }
        }
        bool 是否有未锁无暇=false;
        foreach (var item in list)
        {
            if (item.无暇 && !item.锁)
            {
                是否有未锁无暇=true;
                法器洗练无暇提示弹窗.gameObject.SetActive(true);
                return;
            }
        }

        foreach (var item in list)
        {
            if (!item.锁)
            {
                item.法器附加属性Type = (法器附加属性Type)Random.Range(1, Enum.GetValues(typeof(法器附加属性Type)).Length);
                int 阶数 = Mathf.Clamp(HeroWindowController.S.洗练panel当前法器.阶数, 1, 16);
                float min = 法器Config
                    .法器Minmaxes[
                        new 法器附加属性品质type()
                        {
                            法器附加属性Type = item.法器附加属性Type,
                            阶数 = 阶数
                        }].min;
                float max = 法器Config
                    .法器Minmaxes[
                        new 法器附加属性品质type()
                        {
                            法器附加属性Type = item.法器附加属性Type,
                            阶数 = 阶数
                        }].max;
                
                var 无暇random=Random.Range(0,100);
                if (无暇random < 1f)
                {
                    item.无暇=true;
                    item.count = max;
                }
                else
                {
                    item.无暇=false;
                    item.count = Random.Range(min, max);
                }
            }
        }
        HeroWindowController.S.洗练后词条 = list;
        PlayerData.S.PropListDic[PropType.法器粉尘] -= 需要粉尘;
        ObserverModuleManager.S.SendEvent("SendUIToast", "洗练成功");
    }
     public void 无暇提示洗练() 
    {
        int count1 = 0;
        if (HeroWindowController.S.洗练后词条 != null&&HeroWindowController.S.洗练后词条.Count>0)
        {
            foreach (var item in HeroWindowController.S.洗练后词条)
            {
                if (item.锁)
                {
                    count1++;
                }
            }
        }
        else
        {
            foreach (var item in HeroWindowController.S.洗练panel当前法器.list)
            {
                if (item.锁)
                {
                    count1++;
                }
            }
        }

        float 需要粉尘 = 法器Config.法器洗练消耗Dic[HeroWindowController.S.洗练panel当前法器.品质] *
                     MathF.Pow(2, count1);
        if (PlayerData.S.PropListDic[PropType.法器粉尘] < 需要粉尘)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "法器粉尘数量不足,可分解法器获取");
            return;
        }

        List<法器附加属性值> list = new List<法器附加属性值>();
        if (HeroWindowController.S.洗练后词条 != null && HeroWindowController.S.洗练后词条.Count > 0)
        {
            list = HeroWindowController.S.洗练后词条;
        }
        else
        {
            foreach (var item in HeroWindowController.S.洗练panel当前法器.list)
            {
                法器附加属性值 法器附加属性值 = new 法器附加属性值();
                法器附加属性值.锁 = item.锁;
                法器附加属性值.count = item.count;
                法器附加属性值.无暇 = item.无暇;
                法器附加属性值.法器附加属性Type = item.法器附加属性Type;
                list.Add(法器附加属性值);
            }
        }
        foreach (var item in list)
        {
            if (!item.锁)
            {
                item.法器附加属性Type = (法器附加属性Type)Random.Range(1, Enum.GetValues(typeof(法器附加属性Type)).Length);
                int 阶数 = Mathf.Clamp(HeroWindowController.S.洗练panel当前法器.阶数, 1, 16);
                float min = 法器Config
                    .法器Minmaxes[
                        new 法器附加属性品质type()
                        {
                            法器附加属性Type = item.法器附加属性Type,
                            阶数 = 阶数
                        }].min;
                float max = 法器Config
                    .法器Minmaxes[
                        new 法器附加属性品质type()
                        {
                            法器附加属性Type = item.法器附加属性Type,
                            阶数 = 阶数
                        }].max;
                
                var 无暇random=Random.Range(0,100);
                if (无暇random < 1f)
                {
                    item.无暇=true;
                    item.count = max;
                }
                else
                {
                    item.无暇=false;
                    item.count = Random.Range(min, max);
                }
            }
        }
        HeroWindowController.S.洗练后词条 = list;
        PlayerData.S.PropListDic[PropType.法器粉尘] -= 需要粉尘;
        ObserverModuleManager.S.SendEvent("SendUIToast", "洗练成功");
    }

    public void 保留()
    {
        if (HeroWindowController.S.洗练后词条 != null)
        {
            ObserverModuleManager.S.SendEvent("显示洗练保留确认弹窗");
        }
        else
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "请先洗练词条");
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

    public void 法器洗练英雄筛选(object[] obj)
    {
        英雄筛选mask.gameObject.SetActive(false);
        英雄筛选.gameObject.SetActive(false);
        HeroType heroType=(HeroType)obj[0];
        Show英雄法器(heroType);
    }

    public void 法器洗练无暇确定洗练(object[] obj)
    {
        无暇提示洗练();
        Show右Panel();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("法器洗练无暇确定洗练", 法器洗练无暇确定洗练);

        ObserverModuleManager.S.RegisterEvent("法器洗练英雄筛选", 法器洗练英雄筛选);

        ObserverModuleManager.S.RegisterEvent("法器词条洗练锁", 法器词条洗练锁);
        ObserverModuleManager.S.RegisterEvent("显示洗练保留确认弹窗", 显示洗练保留确认弹窗);
        ObserverModuleManager.S.RegisterEvent("刷新洗练Panel", 刷新洗练Panel);
        ObserverModuleManager.S.RegisterEvent("洗练法器点击", 洗练法器点击);
        洗练Button.onClick.AddListener(() =>
        {
            洗练();
            Show右Panel();
        });
        英雄筛选Button.onClick.AddListener(() =>
        {
            英雄筛选mask.gameObject.SetActive(true);
            英雄筛选.gameObject.SetActive(true);
        });
        英雄筛选mask.onClick.AddListener(() =>
        {
            英雄筛选mask.gameObject.SetActive(false);
            英雄筛选.gameObject.SetActive(false);
        });
        保留Button.onClick.AddListener(() => { 保留(); });
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
            最大页数 = Mathf.CeilToInt(PlayerData.S.法器列表.Count / 48f);
            if (页数num < 最大页数)
            {
                页数num++;
                Show();
            }
        });
    }
}
