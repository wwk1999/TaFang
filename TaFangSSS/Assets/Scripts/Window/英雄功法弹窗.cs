using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 英雄功法弹窗 : MonoBehaviour
{
    public 英雄详情弹窗 英雄详情弹窗;
    public GameObject xx1;
    public GameObject xx2;
    public GameObject xx3;
    public GameObject xx4;
    public GameObject xx5;
    public Slider 经验Slider;
    public TextMeshProUGUI 当前经验;
    public TextMeshProUGUI 最大经验;
    public Button 升星Button;
    public TextMeshProUGUI 功法经验COunt;
    
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 职业;
    public TextMeshProUGUI info;
    public TextMeshProUGUI 基础属性;
    public TextMeshProUGUI 每重加成;
    public TextMeshProUGUI 当前层数;
    public TextMeshProUGUI 当前加成;
    public GameObject content;

    [NonSerialized] public HeroType HeroType = HeroType.None;

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新英雄功法",刷新英雄功法);
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("显示功法选择弹窗",HeroType);
        });
        升星Button.onClick.AddListener(() =>
        {
            int 功法星级 = PlayerData.S.HeroDataDic[HeroType].功法星级;
            功法Type 功法Type = PlayerData.S.HeroDataDic[HeroType].功法Type;
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
            PlayerData.S.HeroDataDic[HeroType].功法星级++;
            SetItem();
        });
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新英雄功法",刷新英雄功法);
    }

    public void 刷新英雄功法(object[] obj)
    {
        SetItem();
    }

    private void OnEnable()
    {
        HeroType = 英雄详情弹窗.HeroType;
        SetItem();
    }

    public void SetItem()
    {
        功法Type 功法Type = PlayerData.S.HeroDataDic[HeroType].功法Type;
        if (功法Type == 功法Type.None)
        {
            bg.image.sprite = ResourcesConfig.加号背景框;
            icon.gameObject.SetActive(false);
            content.SetActive(false);
        }
        else
        {
            int 功法等级 = PlayerData.S.HeroDataDic[HeroType].功法等级;
            int 功法星级 = PlayerData.S.HeroDataDic[HeroType].功法星级;
            xx1.gameObject.SetActive(功法星级>=1);
            xx2.gameObject.SetActive(功法星级>=2);
            xx3.gameObject.SetActive(功法星级>=3);
            xx4.gameObject.SetActive(功法星级>=4);
            xx5.gameObject.SetActive(功法星级>=5);
            经验Slider.maxValue = 功法Config.Get功法升级经验(功法等级);
            经验Slider.value=PlayerData.S.HeroDataDic[HeroType].功法经验;
            当前经验.text=PlayerData.S.HeroDataDic[HeroType].功法经验.ToString();
            最大经验.text=功法Config.Get功法升级经验(功法等级).ToString();
            功法经验COunt.text=功法Config.功法升星经验[功法Config.功法TypeQualityDic[功法Type]].ToString();
            当前层数.text=功法等级.ToString();
            icon.gameObject.SetActive(true);
            content.SetActive(true);
            bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
            icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
            name.text = 功法Config.功法名Dic[功法Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(功法Config.功法TypeQualityDic[功法Type]);
            职业.text = "职业：" + 功法Config.功法职业Dic[功法Type];
            info.text = 功法Config.功法介绍Dic[功法Type];
            基础属性.text = 功法Config.Get功法基础属性(功法Type);
            ZhiYeType zhiYeType = 功法Config.功法职业Dic[功法Type];
            float 最终伤害 = 功法Config.功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]];
            float 辅助值 = 功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]];
            float 总最终伤害 = 功法Config.功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]]*功法等级;
            float 总辅助值 = 功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]]*功法等级;
            if (zhiYeType == ZhiYeType.辅助)
            {
                当前加成.text=$"被辅助英雄伤害+<color=green>{总辅助值}%</color>";
                每重加成.text = $"被辅助英雄伤害+<color=green>{辅助值}%</color>";
            }
            else
            {
                当前加成.text = $"英雄最终伤害+<color=green>{总最终伤害}%</color>";
                每重加成.text = $"英雄最终伤害+<color=green>{最终伤害}%</color>";
            }
        }

    }
}
