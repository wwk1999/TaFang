using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 矿工招募弹窗 : MonoBehaviour
{
    public Button exitButton;
    public Button maskButton;
    public TextMeshProUGUI 灵魂;
    public GameObject 阶数列表;
    public GameObject 招募列表;
    public TextMeshProUGUI 矿工人数;
    public Button 自动招募普通;
    public Button 自动招募稀有;
    public Button 自动招募罕见;
    public Button 自动招募神话;
    public Button 自动招募永恒;
    public TextMeshProUGUI 刷新灵魂;
    public Button 刷新;
    
    
    private void OnEnable()
    {
        if (PlayerData.S.当前招募矿工列表 == null || PlayerData.S.当前招募矿工列表.Count == 0)
        {
            灵矿场Config.刷新招募列表(1);
            HeroWindowController.S.灵矿场当前招募阶数 = 1;
        }
        else
        {
            HeroWindowController.S.灵矿场当前招募阶数 = PlayerData.S.当前招募矿工列表[0].阶数;
        }

        Show阶数列表();
        Show招募列表();
        Show自动招募();
        灵魂.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.灵魂]);
    }

    public void 矿工招募(object[] obj)
    {
        矿工人数.text = PlayerData.S.矿工列表.Count + "/" + 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级];
        灵魂.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.灵魂]);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("矿工招募",矿工招募);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("矿工招募",矿工招募);
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        刷新.onClick.AddListener(() =>
        {
            刷新招募();
        });
        自动招募普通.onClick.AddListener(() =>
        {
            PlayerData.S.自动招募白 = !PlayerData.S.自动招募白;
            Show自动招募();
        });
        自动招募稀有.onClick.AddListener(() =>
        {
            PlayerData.S.自动招募蓝 = !PlayerData.S.自动招募蓝;
            Show自动招募();
        });
        自动招募罕见.onClick.AddListener(() =>
        {
            PlayerData.S.自动招募橙 = !PlayerData.S.自动招募橙;
            Show自动招募();
        });
        自动招募神话.onClick.AddListener(() =>
        {
            PlayerData.S.自动招募红 = !PlayerData.S.自动招募红;
            Show自动招募();
        });
        自动招募永恒.onClick.AddListener(() =>
        {
            PlayerData.S.自动招募彩 = !PlayerData.S.自动招募彩;
            Show自动招募();
        });
    }

    public void 刷新招募()
    {
        float 价格 = 灵矿场Config.Get刷新价格(HeroWindowController.S.灵矿场当前招募阶数);
        if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
            return;
        }
        灵矿场Config.刷新招募列表(HeroWindowController.S.灵矿场当前招募阶数);
        Show招募列表();
        foreach (var item in PlayerData.S.当前招募矿工列表)
        {
            switch (item.QualityType)
            {
                case QualityType.黄品:
                    if (PlayerData.S.自动招募白)
                    {
                        var 灵魂 = 灵矿场Config.Get矿工价格(HeroWindowController.S.灵矿场当前招募阶数, QualityType.黄品);
                        if (PlayerData.S.PropListDic[PropType.灵魂] < 灵魂)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
                            continue;
                        }

                        if (PlayerData.S.矿工列表.Count >= 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级].人数)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","矿工人数已满");
                            continue;
                        }

                        PlayerData.S.PropListDic[PropType.灵魂] -= 灵魂;
                        PlayerData.S.矿工列表.Add(item);
                        ObserverModuleManager.S.SendEvent("SendUIToast","招募成功");

                    }
                    break;
                
                case QualityType.地品:
                    if (PlayerData.S.自动招募蓝)
                    {
                        var 灵魂 = 灵矿场Config.Get矿工价格(HeroWindowController.S.灵矿场当前招募阶数, QualityType.地品);
                        if (PlayerData.S.PropListDic[PropType.灵魂] < 灵魂)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
                            continue;
                        }

                        if (PlayerData.S.矿工列表.Count >= 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级].人数)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","矿工人数已满");
                            continue;
                        }

                        PlayerData.S.PropListDic[PropType.灵魂] -= 灵魂;
                        PlayerData.S.矿工列表.Add(item);
                        ObserverModuleManager.S.SendEvent("SendUIToast","招募成功");

                    }
                    break;
                
                case QualityType.宇品:
                    if (PlayerData.S.自动招募橙)
                    {
                        var 灵魂 = 灵矿场Config.Get矿工价格(HeroWindowController.S.灵矿场当前招募阶数, QualityType.宇品);
                        if (PlayerData.S.PropListDic[PropType.灵魂] < 灵魂)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
                            continue;
                        }

                        if (PlayerData.S.矿工列表.Count >= 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级].人数)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","矿工人数已满");
                            continue;
                        }

                        PlayerData.S.PropListDic[PropType.灵魂] -= 灵魂;
                        PlayerData.S.矿工列表.Add(item);
                        ObserverModuleManager.S.SendEvent("SendUIToast","招募成功");

                    }
                    break;
                
                case QualityType.洪品:
                    if (PlayerData.S.自动招募红)
                    {
                        var 灵魂 = 灵矿场Config.Get矿工价格(HeroWindowController.S.灵矿场当前招募阶数, QualityType.洪品);
                        if (PlayerData.S.PropListDic[PropType.灵魂] < 灵魂)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
                            continue;
                        }

                        if (PlayerData.S.矿工列表.Count >= 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级].人数)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","矿工人数已满");
                            continue;
                        }

                        PlayerData.S.PropListDic[PropType.灵魂] -= 灵魂;
                        PlayerData.S.矿工列表.Add(item);
                        ObserverModuleManager.S.SendEvent("SendUIToast","招募成功");

                    }
                    break;
                
                case QualityType.荒品:
                    if (PlayerData.S.自动招募彩)
                    {
                        var 灵魂 = 灵矿场Config.Get矿工价格(HeroWindowController.S.灵矿场当前招募阶数, QualityType.荒品);
                        if (PlayerData.S.PropListDic[PropType.灵魂] < 灵魂)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
                            continue;
                        }

                        if (PlayerData.S.矿工列表.Count >= 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级].人数)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast","矿工人数已满");
                            continue;
                        }

                        PlayerData.S.PropListDic[PropType.灵魂] -= 灵魂;
                        PlayerData.S.矿工列表.Add(item);
                        ObserverModuleManager.S.SendEvent("SendUIToast","招募成功");

                    }
                    break;
            }
        }
        矿工人数.text = PlayerData.S.矿工列表.Count + "/" + 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级];
        灵魂.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.灵魂]);
    }

    public void Show自动招募()
    {
        矿工人数.text = PlayerData.S.矿工列表.Count + "/" + 灵矿场Config.矿工人数上限配置[PlayerData.S.矿洞矿工人数等级];
        if (PlayerData.S.自动招募白)
        {
            自动招募普通.image.sprite = ResourcesConfig.灵矿场勾选框亮;
        }
        else
        {
            自动招募普通.image.sprite = ResourcesConfig.灵矿场勾选框暗;
        }
        
        if (PlayerData.S.自动招募蓝)
        {
            自动招募稀有.image.sprite = ResourcesConfig.灵矿场勾选框亮;
        }
        else
        {
            自动招募稀有.image.sprite = ResourcesConfig.灵矿场勾选框暗;
        }
        
        if (PlayerData.S.自动招募橙)
        {
            自动招募罕见.image.sprite = ResourcesConfig.灵矿场勾选框亮;
        }
        else
        {
            自动招募罕见.image.sprite = ResourcesConfig.灵矿场勾选框暗;
        }
        
        if (PlayerData.S.自动招募红)
        {
            自动招募神话.image.sprite = ResourcesConfig.灵矿场勾选框亮;
        }
        else
        {
            自动招募神话.image.sprite = ResourcesConfig.灵矿场勾选框暗;
        }
        
        if (PlayerData.S.自动招募彩)
        {
            自动招募永恒.image.sprite = ResourcesConfig.灵矿场勾选框亮;
        }
        else
        {
            自动招募永恒.image.sprite = ResourcesConfig.灵矿场勾选框暗;
        }
    }

    public void Show招募列表()
    {
        刷新灵魂.text = PlayerData.S.格式化数字(灵矿场Config.Get刷新价格(HeroWindowController.S.灵矿场当前招募阶数));
        foreach (Transform item in 招募列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.当前招募矿工列表)
        {
            var 矿工 = Instantiate(Resources.Load("Prefabs/Window/灵矿场/招募item"), 招募列表.transform).GetComponent<招募item>();
            矿工.矿工 = item;
            矿工.SetItem();
        }
    }
    public void Show阶数列表()
    {
        foreach (Transform item in 阶数列表.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i < 11; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/灵矿场/矿工列表item"), 阶数列表.transform)
                .GetComponent<矿工列表item>();
            item.阶数 = i;
            item.SetItem();
        }
    }
    

}
