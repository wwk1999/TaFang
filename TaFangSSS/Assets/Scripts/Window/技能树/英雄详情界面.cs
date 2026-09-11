using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum 英雄详情界面显示类型
{
    None,
    法器,
    功法,
    境界,
}
public class 英雄详情界面 : MonoBehaviour
{
    public GameObject 英雄列表content;
    public Button 境界Button;
    public Button 功法Button;
    public Button 法器Button;
    
    public Button 境界亮Button;
    public Button 功法亮Button;
    public Button 法器亮Button;
    
    public Button 重置Button;
    public Button 提升境界Button;
    public Button 退出Button;

    public Image 经验值icon;
    public TextMeshProUGUI 经验值count;
    public TextMeshProUGUI 经验值text;
    public TextMeshProUGUI 元神;
    public TextMeshProUGUI 技能点;


    public GameObject 技能Content;
    private HeroType 当前heroType=HeroType.丹童;
    private 英雄详情界面显示类型 显示类型 = 英雄详情界面显示类型.境界;

    public void 刷新境界材料()
    {
        float 经验值 = 0;
        switch (HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
        {
            case ZhiYeType.射手:
                经验值text.text = "射手经验值：";
                经验值 = PlayerData.S.PropListDic[PropType.射手经验值];
                break;
            case ZhiYeType.战士:
                经验值text.text = "战士经验值：";
                经验值 = PlayerData.S.PropListDic[PropType.战士经验值];
                break;
            case ZhiYeType.法师:
                经验值text.text = "法师经验值：";

                经验值 = PlayerData.S.PropListDic[PropType.法师经验值];
                break;
            case ZhiYeType.辅助:
                经验值text.text = "辅助经验值：";

                经验值 = PlayerData.S.PropListDic[PropType.辅助经验值];
                break;
            case ZhiYeType.控制:
                经验值text.text = "控制经验值：";

                经验值 = PlayerData.S.PropListDic[PropType.控制经验值];
                break;
        }
        经验值icon.sprite=ResourcesConfig.Get职业经验值Sprite(HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType);
        经验值count.text =
            $"{PlayerData.S.格式化数字(经验值)}/{PlayerData.S.格式化数字(HeroConfig.英雄提升境界经验值Dic[HeroConfig.HeroQualityDic[当前heroType]])}";
        元神.text = $"{PlayerData.S.HeroDataDic[当前heroType].元神}/1";
        技能点.text = PlayerData.S.HeroDataDic[当前heroType].技能点.ToString();
    }

    public void 英雄详情英雄点击(object[] obj)
    {
        HeroType heroType = (HeroType)obj[0];
        当前heroType = heroType;
        刷新界面();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新技能面板",刷新技能面板);
        ObserverModuleManager.S.UnRegisterEvent("英雄详情英雄点击",英雄详情英雄点击);
    }

    public void 刷新技能面板(object[] obj)
    {
        刷新界面();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新技能面板",刷新技能面板);
        ObserverModuleManager.S.RegisterEvent("英雄详情英雄点击",英雄详情英雄点击);
        境界Button.onClick.AddListener(() =>
        {
            if (显示类型 != 英雄详情界面显示类型.境界)
            {
                显示类型 = 英雄详情界面显示类型.境界;
                设置Button();
                Show技能面板();
            }
        });
        重置Button.onClick.AddListener(() =>
        {
            PlayerData.S.HeroDataDic[当前heroType].技能点 = PlayerData.S.HeroDataDic[当前heroType].境界;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PlayerData.S.英雄技能树Dic[当前heroType][i][j]=0;
                }
            }
            ObserverModuleManager.S.SendEvent("SendUIToast","重置成功");
            刷新境界材料();
            Show技能面板();
        });
        提升境界Button.onClick.AddListener(() =>
        {
            float 经验值 = 0;
            switch (HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
            {
                case ZhiYeType.射手:
                    经验值 = PlayerData.S.PropListDic[PropType.射手经验值];
                    break;
                case ZhiYeType.战士:
                    经验值 = PlayerData.S.PropListDic[PropType.战士经验值];
                    break;
                case ZhiYeType.法师:
                    经验值 = PlayerData.S.PropListDic[PropType.法师经验值];
                    break;
                case ZhiYeType.辅助:
                    经验值 = PlayerData.S.PropListDic[PropType.辅助经验值];
                    break;
                case ZhiYeType.控制:
                    经验值 = PlayerData.S.PropListDic[PropType.控制经验值];
                    break;
            }
            if (PlayerData.S.HeroDataDic[当前heroType].境界 >= 英雄技能树Config.英雄最高境界Dic[HeroConfig.HeroQualityDic[当前heroType]])
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","已经达到最高境界");
                return;
            }
            float 需要经验值 = HeroConfig.英雄提升境界经验值Dic[HeroConfig.HeroQualityDic[当前heroType]];
            if (PlayerData.S.HeroDataDic[当前heroType].元神 <= 0 || 经验值 < 需要经验值)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
                return;
            }

            PlayerData.S.HeroDataDic[当前heroType].技能点++;
            PlayerData.S.HeroDataDic[当前heroType].境界++;
            PlayerData.S.HeroDataDic[当前heroType].元神--;
            switch (HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
            {
                case ZhiYeType.射手:
                    PlayerData.S.PropListDic[PropType.射手经验值]-=需要经验值;
                    break;
                case ZhiYeType.战士:
                    PlayerData.S.PropListDic[PropType.战士经验值]-=需要经验值;
                    break;
                case ZhiYeType.法师:
                    PlayerData.S.PropListDic[PropType.法师经验值]-=需要经验值;
                    break;
                case ZhiYeType.辅助:
                    PlayerData.S.PropListDic[PropType.辅助经验值]-=需要经验值;
                    break;
                case ZhiYeType.控制:
                    PlayerData.S.PropListDic[PropType.控制经验值]-=需要经验值;
                    break;
            }
            ObserverModuleManager.S.SendEvent("SendUIToast","提升境界成功");
            Show技能面板();
            刷新境界材料();
        });
        
        退出Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Show英雄列表()
    {
        foreach (Transform item in 英雄列表content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in HeroConfig.HeroNameDic)
        {
            if (PlayerData.S.HeroDataDic[item.Key].Level > 0)
            {
               var 英雄列表item = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情列表Item"), 英雄列表content.transform)
                               .GetComponent<英雄详情列表Item>();
                英雄列表item.HeroType = item.Key;
                英雄列表item.SetItem(); 
            }
        }
    }
    
    public void 设置Button()
    {
        switch (显示类型)
        {
            case 英雄详情界面显示类型.境界:
                境界亮Button.gameObject.SetActive(true);
                境界Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                法器亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.功法:
                功法亮Button.gameObject.SetActive(true);
                功法Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                法器亮Button.gameObject.SetActive(false);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.法器:
                法器亮Button.gameObject.SetActive(true);
                法器Button.gameObject.SetActive(false);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                break;
        }
    }
    public void 刷新界面()
    {
        switch (显示类型)
        {
            case 英雄详情界面显示类型.境界:
                设置Button();
                Show技能面板();
                break;
        }
    }

    private void OnEnable()
    {
        Show英雄列表();
        刷新界面();
    }
    

    public void Show技能面板()
    {
        刷新境界材料();
        foreach (Transform item in 技能Content.transform)
        {
            Destroy(item.gameObject);
        }
        for (int i = 1; i <= 5; i++)
        {
            var 技能树行item = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树行item"), 技能Content.transform)
                .GetComponent<技能树行item>();
            技能树行item.行 = i;
            技能树行item.HeroType = 当前heroType;
            技能树行item.SetItem();
        }
    }
}
