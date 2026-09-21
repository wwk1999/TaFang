using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 符文附魔panel : MonoBehaviour
{
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

    private void OnEnable()
    {
        HeroWindowController.S.当前符文附魔法器 = null;
        HeroWindowController.S.当前符文附魔符文=null;
        Show();
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
            符文Button.image.sprite = ResourcesConfig.按钮白;
            符文Button.transform.localScale = Vector3.one;
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
            int count = PlayerData.S.符文道文List.Count + PlayerData.S.符文圣文List.Count
                + PlayerData.S.符文帝文List.Count + PlayerData.S.符文仙文List.Count
                + PlayerData.S.符文灵文List.Count;
            return Mathf.Max(1, Mathf.CeilToInt(count / 40f));
        }
    }

    public void 刷新符文附魔Panel(object[] obj)
    {
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新符文附魔Panel",刷新符文附魔Panel);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新符文附魔Panel",刷新符文附魔Panel);
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
                最大页数=Mathf.CeilToInt((PlayerData.S.符文道文List.Count+PlayerData.S.符文圣文List.Count+PlayerData.S.符文帝文List.Count+PlayerData.S.符文仙文List.Count+PlayerData.S.符文灵文List.Count)/40f);
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
            艺术字.sprite = ResourcesConfig.Get艺术字(法器Config.法器品质Dic[HeroWindowController.S.当前符文附魔法器.法器Type]);
            Icon.sprite = ResourcesConfig.Get法器Sprite(HeroWindowController.S.当前符文附魔法器.法器Type);
            name.text = 法器Config.法器名Dic[HeroWindowController.S.当前符文附魔法器.法器Type];
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
            // 品质从高到低依次显示：道文(荒品) → 圣文(洪品) → 帝文(宙品) → 仙文(宇品) → 灵文(地品)
            List<List<符文>> 符文Lists = new List<List<符文>>()
            {
                PlayerData.S.符文道文List,
                PlayerData.S.符文圣文List,
                PlayerData.S.符文帝文List,
                PlayerData.S.符文仙文List,
                PlayerData.S.符文灵文List,
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
