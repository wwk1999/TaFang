using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 符文熔炼panel : MonoBehaviour
{
    public GameObject 背包content;
    public Button 左Button;
    public Button 右Button;
    public TextMeshProUGUI 页数Text;
    public 熔炼Item 熔炼Item1;
    public 熔炼Item 熔炼Item2;
    public 熔炼Item 熔炼Item3;
    public 熔炼Item 熔炼Item4;
    public Image 艺术字;
    public TextMeshProUGUI name;
    public Image icon;
    
    public GameObject 符文Content;
    public TextMeshProUGUI 符文名;
    public TextMeshProUGUI 符文效果;
    public TextMeshProUGUI 符文数值;
    public Button 熔炼Button;
    [NonSerialized]public int 页数num = 1;

    public void Show()
    {
        Show背包();
        Show右panel();
    }
    public int Get最大页数()
    {
        int count = PlayerData.S.符文道文List.Count + PlayerData.S.符文圣文List.Count
                                                    + PlayerData.S.符文帝文List.Count + PlayerData.S.符文仙文List.Count
                                                    + PlayerData.S.符文灵文List.Count;
        return Mathf.Max(1, Mathf.CeilToInt(count / 48f));
    }
    
    public void Show背包()
    {
        foreach (Transform item in 背包content.transform)
        {
            Destroy(item.gameObject);
        }
        int 最大页数 = Get最大页数();
        if (页数num > 最大页数) 页数num = 最大页数;
        if (页数num < 1) 页数num = 1;
        页数Text.text = 页数num.ToString();
        List<List<符文>> 符文Lists = new List<List<符文>>()
        {
            PlayerData.S.符文道文List,
            PlayerData.S.符文圣文List,
            PlayerData.S.符文帝文List,
            PlayerData.S.符文仙文List,
            PlayerData.S.符文灵文List,
        };
        int count = 0;
        int start = 48 * (页数num - 1);
        int end = 页数num * 48;
        foreach (var list in 符文Lists)
        {
            foreach (var 符文item in list)
            {
                if (count >= start && count < end)
                {
                    var item = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文熔炼选择item"), 背包content.transform)
                        .GetComponent<符文熔炼选择item>();
                    item.符文 = 符文item;
                    item.SetItem();
                }
                count++;
            }
        }
    }

    public void Show右panel()
    {
        熔炼Item1.符文 = HeroWindowController.S.符文熔炼选择1;
        熔炼Item1.SetItem();
        熔炼Item2.符文 = HeroWindowController.S.符文熔炼选择2;
        熔炼Item2.SetItem();
        熔炼Item3.符文 = HeroWindowController.S.符文熔炼选择3;
        熔炼Item3.SetItem();
        熔炼Item4.符文 = HeroWindowController.S.符文熔炼选择4;
        熔炼Item4.SetItem();
        if (HeroWindowController.S.熔炼后符文 == null)
        {
            艺术字.gameObject.SetActive(false);
            name.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            符文Content.SetActive(false);
        }
        else
        {
            艺术字.gameObject.SetActive(true);
            name.gameObject.SetActive(true);
            icon.gameObject.SetActive(true);
            符文Content.SetActive(true);
            艺术字.sprite = ResourcesConfig.Get艺术字(HeroWindowController.S.熔炼后符文.quality);
            name.text = 符文Config.符文名Dic[HeroWindowController.S.熔炼后符文.type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(HeroWindowController.S.熔炼后符文.quality);
            icon.sprite = ResourcesConfig.Get符文Sprite(HeroWindowController.S.熔炼后符文.type,
                符文Config.Quality对应符文品质[HeroWindowController.S.熔炼后符文.quality]);
            
            符文名.text = 符文Config.符文名Dic[HeroWindowController.S.熔炼后符文.type];
            符文名.colorGradientPreset = ResourcesConfig.Get品质TMP(HeroWindowController.S.熔炼后符文.quality);
            符文效果.text = 符文Config.符文效果Dic[HeroWindowController.S.熔炼后符文.type];
            if (HeroWindowController.S.熔炼后符文.type == 符文Type.击杀怪物获得神通能量)
            {
                符文数值.text = HeroWindowController.S.熔炼后符文.count.ToString("F2");
            }
            else
            {
                符文数值.text = HeroWindowController.S.熔炼后符文.count.ToString("F1")+"%";
            }
        }
    }

    public void 刷新符文熔炼Panel(object[] obj)
    {
        Show();
    }
    private void OnEnable()
    {
        HeroWindowController.S.熔炼后符文 = null;
        HeroWindowController.S.符文熔炼选择1=null;
        HeroWindowController.S.符文熔炼选择2=null;
        HeroWindowController.S.符文熔炼选择3=null;
        HeroWindowController.S.符文熔炼选择4=null;
        HeroWindowController.S.符文熔炼选择1=null;
        HeroWindowController.S.符文熔炼选择2=null;
        HeroWindowController.S.符文熔炼选择3=null;
        HeroWindowController.S.符文熔炼选择4=null;
        页数num = 1;
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新符文熔炼Panel",刷新符文熔炼Panel);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新符文熔炼Panel",刷新符文熔炼Panel);
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
            
            最大页数=Mathf.CeilToInt((PlayerData.S.符文道文List.Count+PlayerData.S.符文圣文List.Count+PlayerData.S.符文帝文List.Count+PlayerData.S.符文仙文List.Count+PlayerData.S.符文灵文List.Count)/48f);
            if (页数num < 最大页数) 
            {
                页数num++;
                Show();
            }
        });
        熔炼Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.符文熔炼选择1 == null || HeroWindowController.S.符文熔炼选择2 == null ||
                HeroWindowController.S.符文熔炼选择3 == null || HeroWindowController.S.符文熔炼选择4 == null)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择4个熔炼符文");
                return;
            }

            QualityType qualityType = HeroWindowController.S.符文熔炼选择1.quality;
            qualityType = (QualityType)Math.Min((int)qualityType, (int)HeroWindowController.S.符文熔炼选择2.quality);
            qualityType = (QualityType)Math.Min((int)qualityType, (int)HeroWindowController.S.符文熔炼选择3.quality);
            qualityType = (QualityType)Math.Min((int)qualityType, (int)HeroWindowController.S.符文熔炼选择4.quality);
            符文 符文 = 符文之地Config.Get品质符文(符文Config.Quality对应符文品质[qualityType]);
            switch (符文.quality)
            {
                case QualityType.地品:
                    PlayerData.S.符文灵文List.Add(符文);
                    break;
                case QualityType.宇品:
                    PlayerData.S.符文仙文List.Add(符文);
                    break;
                case QualityType.宙品:
                    PlayerData.S.符文帝文List.Add(符文);
                    break;
                case QualityType.洪品:
                    PlayerData.S.符文圣文List.Add(符文);
                    break;
                case QualityType.荒品:
                    PlayerData.S.符文道文List.Add(符文);
                    break;
            }

            HeroWindowController.S.熔炼后符文 = 符文;
            PlayerData.S.符文灵文List.Remove(HeroWindowController.S.符文熔炼选择1);
            PlayerData.S.符文仙文List.Remove(HeroWindowController.S.符文熔炼选择1);
            PlayerData.S.符文帝文List.Remove(HeroWindowController.S.符文熔炼选择1);
            PlayerData.S.符文圣文List.Remove(HeroWindowController.S.符文熔炼选择1);
            PlayerData.S.符文道文List.Remove(HeroWindowController.S.符文熔炼选择1);

            PlayerData.S.符文灵文List.Remove(HeroWindowController.S.符文熔炼选择2);
            PlayerData.S.符文仙文List.Remove(HeroWindowController.S.符文熔炼选择2);
            PlayerData.S.符文帝文List.Remove(HeroWindowController.S.符文熔炼选择2);
            PlayerData.S.符文圣文List.Remove(HeroWindowController.S.符文熔炼选择2);
            PlayerData.S.符文道文List.Remove(HeroWindowController.S.符文熔炼选择2);
            
            PlayerData.S.符文灵文List.Remove(HeroWindowController.S.符文熔炼选择3);
            PlayerData.S.符文仙文List.Remove(HeroWindowController.S.符文熔炼选择3);
            PlayerData.S.符文帝文List.Remove(HeroWindowController.S.符文熔炼选择3);
            PlayerData.S.符文圣文List.Remove(HeroWindowController.S.符文熔炼选择3);
            PlayerData.S.符文道文List.Remove(HeroWindowController.S.符文熔炼选择3);
            
            PlayerData.S.符文灵文List.Remove(HeroWindowController.S.符文熔炼选择4);
            PlayerData.S.符文仙文List.Remove(HeroWindowController.S.符文熔炼选择4);
            PlayerData.S.符文帝文List.Remove(HeroWindowController.S.符文熔炼选择4);
            PlayerData.S.符文圣文List.Remove(HeroWindowController.S.符文熔炼选择4);
            PlayerData.S.符文道文List.Remove(HeroWindowController.S.符文熔炼选择4);
            HeroWindowController.S.符文熔炼选择1 = null;
            HeroWindowController.S.符文熔炼选择2 = null;
            HeroWindowController.S.符文熔炼选择3 = null;
            HeroWindowController.S.符文熔炼选择4 = null;

            Show();
        });
    }
}
