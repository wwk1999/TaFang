using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 符文附魔panel : MonoBehaviour
{
    public Button 符文排序Button;
    public GameObject 符文排序;
    public GameObject 符文排序Content;
    
    public Button 英雄筛选Button;
    public GameObject 英雄筛选;
    public GameObject 英雄筛选Content;
    public Button 英雄筛选mask;
    
    public 符文确认附魔弹窗 符文确认附魔弹窗;
    public Button 法器Button;
    public Button 符文Button;
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
    public TextMeshProUGUI name;
    public GameObject 符文Content;
    public TextMeshProUGUI 符文名;
    public TextMeshProUGUI 符文效果;
    public TextMeshProUGUI 符文数值;
    public Button 附魔Button;
    [NonSerialized]public int 页数num = 1;
    [NonSerialized]public bool 显示法器 = true;
    private HeroType 当前英雄筛选=HeroType.None;

    public void Set出战英雄筛选()
    {
        foreach (Transform Item in 英雄筛选Content.transform)
        {
            Destroy(Item.gameObject);
        }
        var 出战英雄筛选Item1 = Instantiate(Resources.Load("Prefabs/Window/炼器/符文附魔英雄筛选Item"), 英雄筛选Content.transform)
            .GetComponent<符文附魔英雄筛选Item>();
        出战英雄筛选Item1.HeroType = HeroType.None;
        出战英雄筛选Item1.SetItem();

        foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
        {
            if (item != HeroType.None)
            {
                var 出战英雄筛选Item = Instantiate(Resources.Load("Prefabs/Window/炼器/符文附魔英雄筛选Item"), 英雄筛选Content.transform)
                    .GetComponent<符文附魔英雄筛选Item>();
                出战英雄筛选Item.HeroType = item;
                出战英雄筛选Item.SetItem();
            }
        }
    }
    
    public void Set符文排序()
    {
        foreach (Transform Item in 符文排序Content.transform)
        {
            Destroy(Item.gameObject);
        }
        var 符文排序Item = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文附魔排序选项item"), 符文排序Content.transform)
            .GetComponent<符文附魔排序选项item>();
        符文排序Item.符文Type = 符文Type.None;
        符文排序Item.SetItem();

        foreach (var item in 符文Config.符文名Dic)
        {
            if (item.Key != 符文Type.None)
            {
                var 符文排序Item1 = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文附魔排序选项item"), 符文排序Content.transform)
                    .GetComponent<符文附魔排序选项item>();
                符文排序Item1.符文Type = item.Key;
                符文排序Item1.SetItem();
            }
        }
    }
    private void OnEnable()
    {
        Set出战英雄筛选();
        HeroWindowController.S.当前符文附魔法器 = null;
        HeroWindowController.S.当前符文附魔符文=null;
        页数num = 1;
        显示法器 = true;
        Show();
    }
    
    public void Show切换按钮()
    {
        if (显示法器)
        {
            英雄筛选Button.gameObject.SetActive(true);
            符文排序Button.gameObject.SetActive(false);
            法器Button.image.sprite = ResourcesConfig.按钮黑;
            法器Button.transform.localScale = Vector3.one;
            法器白.gameObject.SetActive(true);
            法器黑.gameObject.SetActive(false);
            法器白.transform.localScale = Vector3.one;
            符文Button.image.sprite = ResourcesConfig.按钮白;
            符文Button.transform.localScale = Vector3.one;
            仙石白.gameObject.SetActive(false);
            仙石黑.gameObject.SetActive(true);
            仙石黑.transform.localScale = Vector3.one;
        }
        else
        {
            英雄筛选Button.gameObject.SetActive(false);
            符文排序Button.gameObject.SetActive(true);
            法器Button.image.sprite = ResourcesConfig.按钮白;
            法器Button.transform.localScale = new Vector3(-1, 1, 1);
            法器白.gameObject.SetActive(false);
            法器黑.gameObject.SetActive(true);
            法器黑.transform.localScale = new Vector3(-1, 1, 1);
            符文Button.image.sprite = ResourcesConfig.按钮黑;
            符文Button.transform.localScale = new Vector3(-1, 1, 1);
            仙石白.gameObject.SetActive(true);
            仙石黑.gameObject.SetActive(false);
            仙石白.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
    public int Get最大页数()
    {
        if (显示法器)
        {
            return Mathf.Max(1, Mathf.CeilToInt(PlayerData.S.法器列表.Count / 40f));
        }
        else
        {
            int count = 0;
            if (HeroWindowController.S.当前符文附魔排序Type == 符文Type.None)
            {
                count = PlayerData.S.Get符文总数();
            }
            else
            {
                for (int q = 1; q <= 8; q++)
                {
                    foreach (var item in PlayerData.S.Get符文List((QualityType)q))
                    {
                        if (item.type == HeroWindowController.S.当前符文附魔排序Type)
                        {
                            count++;
                        }
                    }
                }
            }
            return Mathf.Max(1, Mathf.CeilToInt(count / 40f));
        }
    }

    public void 刷新符文附魔Panel(object[] obj)
    {
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("隐藏符文附魔排序选项", 隐藏符文附魔排序选项);
        ObserverModuleManager.S.UnRegisterEvent("刷新符文附魔背包", 刷新符文附魔背包);
        ObserverModuleManager.S.UnRegisterEvent("符文附魔英雄筛选", 符文附魔英雄筛选);
        ObserverModuleManager.S.UnRegisterEvent("刷新符文附魔Panel",刷新符文附魔Panel);
    }
    public void 符文附魔英雄筛选(object[] obj)
    {
        英雄筛选mask.gameObject.SetActive(false);
        英雄筛选.gameObject.SetActive(false);
        HeroType heroType=(HeroType)obj[0];
        当前英雄筛选 = heroType;
        Show英雄法器(heroType);
    }
    
    
    public void Show英雄法器(HeroType heroType)
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        页数num = 1;
        页数.text = 页数num.ToString();
        if (heroType == HeroType.None)
        {
            Show左panel();
            return;
        }
        GameObject prefab = Resources.Load("Prefabs/Window/符文之地/符文附魔法器item") as GameObject;

        if (PlayerData.S.HeroDataDic[heroType].武器 != null)
        {
            var 武器 = Instantiate(prefab, content.transform)
                .GetComponent<符文附魔法器item>();
            武器.法器 = PlayerData.S.HeroDataDic[heroType].武器;
            武器.法器.HeroType = heroType;
            武器.SetItem();
            if (HeroWindowController.S.当前符文附魔法器 != null && 武器.法器 == HeroWindowController.S.当前符文附魔法器)
            {
                武器.gou.SetActive(true);
            }
            else
            {
                武器.gou.SetActive(false);
            }
        }
        
        if (PlayerData.S.HeroDataDic[heroType].头盔 != null)
        {
            var 头盔 = Instantiate(prefab, content.transform)
                .GetComponent<符文附魔法器item>();
            头盔.法器 = PlayerData.S.HeroDataDic[heroType].头盔;
            头盔.法器.HeroType = heroType;
            头盔.SetItem();
            if (HeroWindowController.S.当前符文附魔法器 != null && 头盔.法器 == HeroWindowController.S.当前符文附魔法器)
            {
                头盔.gou.SetActive(true);
            }
            else
            {
                头盔.gou.SetActive(false);
            }
        }
        
        if (PlayerData.S.HeroDataDic[heroType].衣服 != null)
        {
            var 衣服 = Instantiate(prefab, content.transform)
                .GetComponent<符文附魔法器item>();
            衣服.法器 = PlayerData.S.HeroDataDic[heroType].衣服;
            衣服.法器.HeroType = heroType;
            衣服.SetItem();
            if (HeroWindowController.S.当前符文附魔法器 != null && 衣服.法器 == HeroWindowController.S.当前符文附魔法器)
            {
                衣服.gou.SetActive(true);
            }
            else
            {
                衣服.gou.SetActive(false);
            }
        }
        
        if (PlayerData.S.HeroDataDic[heroType].鞋子 != null)
        {
            var 鞋子 = Instantiate(prefab, content.transform)
                .GetComponent<符文附魔法器item>();
            鞋子.法器 = PlayerData.S.HeroDataDic[heroType].鞋子;
            鞋子.法器.HeroType = heroType;
            鞋子.SetItem();
            if (HeroWindowController.S.当前符文附魔法器 != null && 鞋子.法器 == HeroWindowController.S.当前符文附魔法器)
            {
                鞋子.gou.SetActive(true);
            }
            else
            {
                鞋子.gou.SetActive(false);
            }
        }
    }

    public void 刷新符文附魔背包(object[] obj)
    {
        页数num = 1;
        Show左panel();
    }

    public void 隐藏符文附魔排序选项(object[] obj)
    {
        符文排序.gameObject.SetActive(false);
        英雄筛选mask.gameObject.SetActive(false);
    }

  
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("隐藏符文附魔排序选项", 隐藏符文附魔排序选项);
        ObserverModuleManager.S.RegisterEvent("刷新符文附魔背包", 刷新符文附魔背包);
        ObserverModuleManager.S.RegisterEvent("符文附魔英雄筛选", 符文附魔英雄筛选);
        ObserverModuleManager.S.RegisterEvent("刷新符文附魔Panel",刷新符文附魔Panel);
        Set符文排序();
        英雄筛选Button.onClick.AddListener(() =>
        {
            英雄筛选mask.gameObject.SetActive(true);
            英雄筛选.gameObject.SetActive(true);
        });
        符文排序Button.onClick.AddListener(() =>
        {
            英雄筛选mask.gameObject.SetActive(true);
            符文排序.gameObject.SetActive(true);
        });
        英雄筛选mask.onClick.AddListener(() =>
        {
            英雄筛选mask.gameObject.SetActive(false);
            英雄筛选.gameObject.SetActive(false);
            符文排序.gameObject.SetActive(false);

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
                最大页数=Mathf.CeilToInt(PlayerData.S.Get符文总数()/40f);
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
        附魔Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前符文附魔法器 == null)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择附魔法器");
                return;
            }
            if (HeroWindowController.S.当前符文附魔符文 == null)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择附魔符文");
                return;
            }
            符文确认附魔弹窗.gameObject.SetActive(true);
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
        
        符文Button.onClick.AddListener(() =>
        {
            if (显示法器 == true)
            {
                显示法器 = false;
                页数num = 1;
                Show();
            }
        });
    }
    public void Show()
    {
        Show左panel();
        Show右Panel();
    }
    public void Show右Panel()
    {
        if (HeroWindowController.S.当前符文附魔符文 == null)
        {
            符文Content.gameObject.SetActive(false);
        }
        else
        {
            符文Content.gameObject.SetActive(true);
            符文名.text = 符文Config.符文名Dic[HeroWindowController.S.当前符文附魔符文.type];
            符文名.colorGradientPreset = ResourcesConfig.Get品质TMP(HeroWindowController.S.当前符文附魔符文.quality);
            符文效果.text = 符文Config.符文效果Dic[HeroWindowController.S.当前符文附魔符文.type];
            if (HeroWindowController.S.当前符文附魔符文.type == 符文Type.击杀怪物获得神通能量)
            {
                符文数值.text = HeroWindowController.S.当前符文附魔符文.count.ToString("F2");
            }
            else
            {
                符文数值.text = HeroWindowController.S.当前符文附魔符文.count.ToString("F1")+"%";
            }
        }
        if (HeroWindowController.S.当前符文附魔法器 == null)
        {
            Icon.gameObject.SetActive(false);
            nameObj.gameObject.SetActive(false);
            艺术字.gameObject.SetActive(false);
        }
        else
        {
            Icon.gameObject.SetActive(true);
            nameObj.gameObject.SetActive(true);
            艺术字.gameObject.SetActive(true);
            艺术字.sprite = ResourcesConfig.Get艺术字(HeroWindowController.S.当前符文附魔法器.品质);
            Icon.sprite = ResourcesConfig.Get法器Sprite(HeroWindowController.S.当前符文附魔法器.法器Type, HeroWindowController.S.当前符文附魔法器.阶数);
            name.text = 法器Config.Get法器Name(HeroWindowController.S.当前符文附魔法器.法器Type, HeroWindowController.S.当前符文附魔法器.阶数);
            name.colorGradientPreset =
                ResourcesConfig.Get品质TMP(HeroWindowController.S.当前符文附魔法器.品质);
        }
    }

    public void Show符文排序(符文Type type)
    {
        if (type == 符文Type.None)
        {
            页数num = 1;
            Show背包();
            return;
        }
        // 兜底设置全局排序Type，确保 Get最大页数() 按同一条件算分页
        HeroWindowController.S.当前符文附魔排序Type = type;
        
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        // 翻页钳制：无论哪种模式，页数num 都不能超过当前模式的总页数，避免翻出空白页
        int 最大页数 = Get最大页数();
        if (页数num > 最大页数) 页数num = 最大页数;
        if (页数num < 1) 页数num = 1;
        页数.text = 页数num.ToString();
       
        // 按传入的 type 筛选，只显示匹配的符文（品质从高到低：荒→洪→宙→宇→天→地→玄→黄）
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
        int start = 40 * (页数num - 1);
        int end = 页数num * 40;
        foreach (var list in 符文Lists)
        {
            foreach (var 符文item in list)
            {
                // 只显示匹配 type 的符文，count 也只对匹配的递增，确保分页对齐
                if (符文item.type != type) continue;
                if (count >= start && count < end)
                {
                    var item = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文附魔符文item"), content.transform)
                        .GetComponent<符文附魔符文item>();
                    item.符文 = 符文item;
                    item.SetItem();
                    if (HeroWindowController.S.当前符文附魔符文 != null && item.符文 == HeroWindowController.S.当前符文附魔符文)
                    {
                        item.gou.SetActive(true);
                    }
                    else
                    {
                        item.gou.SetActive(false);
                    }
                }
                count++;
            }
        }
    }
    
    public void Show左panel()
    {
        Show切换按钮();
        Show背包();
    }
    public void Show背包()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
        // 翻页钳制：无论哪种模式，页数num 都不能超过当前模式的总页数，避免翻出空白页
        int 最大页数 = Get最大页数();
        if (页数num > 最大页数) 页数num = 最大页数;
        if (页数num < 1) 页数num = 1;
        页数.text = 页数num.ToString();
        if (显示法器)
        {
            if (当前英雄筛选 != HeroType.None)
            {
                Show英雄法器(当前英雄筛选);
                return;
            }
            for (int i = 40*(页数num-1); i < Math.Min(页数num*40,PlayerData.S.法器列表.Count); i++)
            {
                var 法器item = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文附魔法器item"), content.transform)
                    .GetComponent<符文附魔法器item>();
                法器item.法器 = PlayerData.S.法器列表[i];
                法器item.SetItem();
                if (HeroWindowController.S.当前符文附魔法器 != null && 法器item.法器 == HeroWindowController.S.当前符文附魔法器)
                {
                    法器item.gou.SetActive(true);
                }
                else
                {
                    法器item.gou.SetActive(false);
                }
            }
        }
        else
        {
            if (HeroWindowController.S.当前符文附魔排序Type != 符文Type.None)
            {
                Show符文排序(HeroWindowController.S.当前符文附魔排序Type);
                return;
            }
            // 品质从高到低依次显示：荒 → 洪 → 宙 → 宇 → 天 → 地 → 玄 → 黄
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
            int start = 40 * (页数num - 1);
            int end = 页数num * 40;
            foreach (var list in 符文Lists)
            {
                foreach (var 符文item in list)
                {
                    if (count >= start && count < end)
                    {
                        var item = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文附魔符文item"), content.transform)
                            .GetComponent<符文附魔符文item>();
                        item.符文 = 符文item;
                        item.SetItem();
                        if (HeroWindowController.S.当前符文附魔符文 != null && item.符文 == HeroWindowController.S.当前符文附魔符文)
                        {
                            item.gou.SetActive(true);
                        }
                        else
                        {
                            item.gou.SetActive(false);
                        }
                    }
                    count++;
                }
            }
        }
    }
}
