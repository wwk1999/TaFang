using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public enum 英雄详情界面显示类型
{
    None,
    法器,
    功法,
    境界,
}
public class 英雄详情界面 : MonoBehaviour
{
    public GameObject 功法Panel;
    public GameObject 境界Panel;
    public GameObject 法器Panel;

    
    
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
    //功法
    public GameObject 功法详情content;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 职业;
    public TextMeshProUGUI info;
    public GameObject xx1;
    public GameObject xx2;
    public GameObject xx3;
    public GameObject xx4;
    public GameObject xx5;
    public TextMeshProUGUI 当前值;
    public TextMeshProUGUI 最大值;
    public Image 功法经验条;
    public TextMeshProUGUI 基础属性;
    public TextMeshProUGUI 每重增幅;
    public TextMeshProUGUI 当前层数;
    public TextMeshProUGUI 当前加成;
    public TextMeshProUGUI 升星材料count;
    public Button 升星Button;
    public GameObject 功法content;
    public GameObject 升星材料content;
    

    
    private HeroType 当前heroType=HeroType.丹童;
    private 英雄详情界面显示类型 显示类型 = 英雄详情界面显示类型.境界;

    
    public void 刷新功法详情()
    {
        功法Type 功法Type = PlayerData.S.HeroDataDic[当前heroType].功法Type;
        if (功法Type == 功法Type.None)
        {
            功法详情content.SetActive(false);
            return;
        }
        int 功法等级 = PlayerData.S.HeroDataDic[当前heroType].功法等级;
        int 功法星级 = PlayerData.S.HeroDataDic[当前heroType].功法星级;
        升星材料content.SetActive(功法星级<=5);
        功法详情content.SetActive(true);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
        name.text = 功法Config.功法名Dic[功法Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(功法Config.功法TypeQualityDic[功法Type]);
        职业.text = HeroConfig.Get职业Name(功法Config.功法职业Dic[功法Type]);
        info.text = 功法Config.功法介绍Dic[功法Type];
        xx1.gameObject.SetActive(PlayerData.S.HeroDataDic[当前heroType].功法星级>=1);
        xx2.gameObject.SetActive(PlayerData.S.HeroDataDic[当前heroType].功法星级>=2);
        xx3.gameObject.SetActive(PlayerData.S.HeroDataDic[当前heroType].功法星级>=3);
        xx4.gameObject.SetActive(PlayerData.S.HeroDataDic[当前heroType].功法星级>=4);
        xx5.gameObject.SetActive(PlayerData.S.HeroDataDic[当前heroType].功法星级>=5);
        当前值.text = PlayerData.S.HeroDataDic[当前heroType].功法经验.ToString();
        最大值.text = 功法Config.Get功法升级经验(PlayerData.S.HeroDataDic[当前heroType].功法等级).ToString();
        功法经验条.fillAmount = PlayerData.S.HeroDataDic[当前heroType].功法经验 /
                           功法Config.Get功法升级经验(PlayerData.S.HeroDataDic[当前heroType].功法等级);
        基础属性.text = 功法Config.Get功法基础属性String(功法Type);
        当前层数.text = PlayerData.S.HeroDataDic[当前heroType].功法等级.ToString();
        ZhiYeType zhiYeType = 功法Config.功法职业Dic[功法Type];
        float 辅助值 = 功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]];
        float 总最终伤害 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[功法Type]]*功法等级*(1f+0.2f*功法星级);
        float 总辅助值 = 功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]]*功法等级*(1f+0.2f*功法星级);
        float 最终伤害 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[功法Type]];
        Color c = new Color(1/255f, 95/255f, 0f); // 橙色
        string hex = ColorUtility.ToHtmlStringRGB(c);
        if (zhiYeType == ZhiYeType.辅助)
        {
            当前加成.text=$"被辅助英雄伤害+<color=#{hex}>{总辅助值}%</color>";
            每重增幅.text = $"被辅助英雄伤害+<color=#{hex}>{辅助值}%</color>";
        }
        else
        {
            当前加成.text = $"英雄最终伤害+<color=#{hex}>{总最终伤害}%</color>";
            每重增幅.text = $"英雄最终伤害+<color=#{hex}>{最终伤害}%</color>";
        }

        升星材料count.text = PlayerData.S.格式化数字(功法Config.功法升星经验[功法Config.功法TypeQualityDic[功法Type]]);
    }

    public void 刷新功法背包()
    {
        foreach (Transform item in 功法content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in PlayerData.S.功法数量Dic)
        {
            if (item.Value > 0&&功法Config.功法职业Dic[item.Key]==HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
            {
                var baggrid = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情功法item"), 功法content.transform).GetComponent<英雄详情功法item>();
                baggrid.功法Type = item.Key;
                baggrid.HeroType = 当前heroType;
                baggrid.SetItem();
            }
        }
    }


    public void Show功法()
    {
        刷新功法背包();
        刷新功法详情();
    }
    
    
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
        ObserverModuleManager.S.UnRegisterEvent("刷新英雄详情界面",刷新英雄详情界面);
        ObserverModuleManager.S.UnRegisterEvent("刷新技能面板",刷新技能面板);
        ObserverModuleManager.S.UnRegisterEvent("英雄详情英雄点击",英雄详情英雄点击);
    }

    public void 刷新技能面板(object[] obj)
    {
        刷新界面();
    }

    public void 刷新英雄详情界面(object[] obj)
    {
        刷新界面();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新英雄详情界面",刷新英雄详情界面);
        ObserverModuleManager.S.RegisterEvent("刷新技能面板",刷新技能面板);
        ObserverModuleManager.S.RegisterEvent("英雄详情英雄点击",英雄详情英雄点击);
        升星Button.onClick.AddListener(() =>
        {
            int 功法星级 = PlayerData.S.HeroDataDic[当前heroType].功法星级;
            功法Type 功法Type = PlayerData.S.HeroDataDic[当前heroType].功法Type;
            if (功法星级 >= 5)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","功法星级已达最高星级");
                return;
            }
            if (PlayerData.S.PropListDic[PropType.功法经验] < 功法Config.功法升星经验[功法Config.功法TypeQualityDic[功法Type]])
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","功法经验不足");
                return;
            }
            PlayerData.S.PropListDic[PropType.功法经验] -= 功法Config.功法升星经验[功法Config.功法TypeQualityDic[功法Type]];
            PlayerData.S.HeroDataDic[当前heroType].功法星级++;
            ObserverModuleManager.S.SendEvent("刷新英雄卡片功法",当前heroType);
            刷新界面();
        });
        境界Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.境界;
            刷新界面();
        });
        法器Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.法器;
            刷新界面();
        });
        功法Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.功法;
            刷新界面();
        });
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
        设置Button();
        switch (显示类型)
        {
            case 英雄详情界面显示类型.境界:
                功法Panel.SetActive(false);
                法器Panel.SetActive(false);
                境界Panel.SetActive(true);
                Show技能面板();
                break;
            case 英雄详情界面显示类型.功法:
                功法Panel.SetActive(true);
                法器Panel.SetActive(false);
                境界Panel.SetActive(false);
                Show功法();
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
