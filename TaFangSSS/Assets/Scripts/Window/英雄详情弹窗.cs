using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 英雄详情弹窗 : MonoBehaviour
{
    public Image image;
    public Image 艺术字;
    public Image bg;
    public TextMeshProUGUI name;
    public Image 职业icon;
    public TextMeshProUGUI 职业text;
    public TextMeshProUGUI skillname;
    public Image skillicon;
    public TextMeshProUGUI Cdtext;
    public TextMeshProUGUI skillinfo;
    public Image 元素icon;
    public TextMeshProUGUI 元素name;
    public GameObject 升星信息Content;
    public TextMeshProUGUI 升星奖励;
    public Image 经验值bg;
    public Image 经验值icon;
    public TextMeshProUGUI 经验值name;
    public TextMeshProUGUI 经验值当前值;
    public TextMeshProUGUI 经验值需要值;
    public Image 元神bg;
    public Image 元神icon;
    public TextMeshProUGUI 元神name;
    public TextMeshProUGUI 元神当前值;
    public TextMeshProUGUI 元神需要值;
    public Button 升星button;
    public Button 法则button;
    public Button maskButton;
    [NonSerialized] public HeroType HeroType;

    public void Set升星材料()
    {
        法则button.gameObject.SetActive(HeroConfig.HeroQualityDic[HeroType]>=QualityType.宇品);
        经验值name.text=HeroConfig.Get职业Name(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType)+"经验值";
        经验值bg.sprite = ResourcesConfig.道具背景框蓝;
        经验值icon.sprite = ResourcesConfig.Get职业经验值Sprite(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        经验值需要值.text = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level)
            .Exp.ToString();
        元神bg.sprite = ResourcesConfig.Get道具背景框Sprite(HeroConfig.HeroToPropDic[HeroType]);
        元神name.text = HeroConfig.HeroNameDic[HeroType] + "元神";
        元神需要值.text = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level)
            .元神.ToString();
        元神当前值.text = PlayerData.S.HeroDataDic[HeroType].元神.ToString();
        元神icon.sprite = ResourcesConfig.Get品质元神Sprite(HeroConfig.HeroQualityDic[HeroType]);
        switch (HeroConfig.HeroZhiYeDic[HeroType].zhiYeType)
        {
            case ZhiYeType.射手:
                经验值当前值.text = PlayerData.S.PropListDic[PropType.射手经验值].ToString();
                break;
            case ZhiYeType.战士:
                经验值当前值.text = PlayerData.S.PropListDic[PropType.战士经验值].ToString();
                break;
            case ZhiYeType.控制:
                经验值当前值.text = PlayerData.S.PropListDic[PropType.控制经验值].ToString();
                break;
            case ZhiYeType.辅助:
                经验值当前值.text = PlayerData.S.PropListDic[PropType.辅助经验值].ToString();
                break;
            case ZhiYeType.法师:
                经验值当前值.text = PlayerData.S.PropListDic[PropType.法师经验值].ToString();
                break;
        }
        
    }
    public void Set升星信息()
    {
        foreach (Transform item in 升星信息Content.transform)
        {
            Destroy(item.gameObject);
        }
        升星奖励.text = "升星奖励：暴击伤害增幅+" + HeroConfig.升星奖励Dic[HeroConfig.HeroQualityDic[HeroType]]+"%";
        int xj = PlayerData.S.HeroDataDic[HeroType].Level - 1;
        for (int i = 1; i <= 5; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/升星信息item"), 升星信息Content.transform)
                .GetComponent<升星信息item>();
            item.锁 = xj >= i;
            item.星级 = i;
            item.text = HeroConfig.英雄升星信息Dic[HeroType][i - 1];
            item.SetItem();
        }
    }

    public void SetHeroInfo()
    {
        skillicon.sprite = ResourcesConfig.Get技能icon(HeroType);
        QualityType heroquality = HeroConfig.HeroQualityDic[HeroType];
        image.sprite=ResourcesConfig.GetHeroSprite(HeroType);
        艺术字.sprite = ResourcesConfig.Get艺术字(heroquality);
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(heroquality);
        name.text=HeroConfig.HeroNameDic[HeroType];
        职业icon.sprite = ResourcesConfig.Get职业icon(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        职业text.text = HeroConfig.Get职业Name(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        skillname.text = HeroConfig.SkillNameDic[HeroType];
        Cdtext.text = "CD:" + HeroConfig.HeroAttackTimeDic[HeroType]+"S";
        skillinfo.text=HeroConfig.HeroSkillInfoDic[HeroType];
        元素icon.sprite=ResourcesConfig.Get元素Sprite(HeroConfig.HeroZhiYeDic[HeroType].yuanSuType);
        switch (HeroConfig.HeroZhiYeDic[HeroType].yuanSuType)
        {
            case YuanSuType.火:
                元素name.text = "火焰";
                元素name.colorGradientPreset = ResourcesConfig.火焰TMP;
                break;
            case YuanSuType.冰:
                元素name.text = "冰霜";
                元素name.colorGradientPreset = ResourcesConfig.冰霜TMP;
                break;
            case YuanSuType.物理:
                元素name.text = "物理";
                元素name.colorGradientPreset = ResourcesConfig.物理TMP;
                break;
            case YuanSuType.电:
                元素name.text = "雷电";
                元素name.colorGradientPreset = ResourcesConfig.雷电TMP;
                break;
            case YuanSuType.黑暗:
                元素name.text = "黑暗";
                元素name.colorGradientPreset = ResourcesConfig.黑暗TMP;
                break;

        }
    }
    private void OnEnable()
    {
        if (HeroType != HeroType.None)
        {
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
        }
        
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        升星button.onClick.AddListener(() =>
        {
            ZhiYeType zhiye=HeroConfig.HeroZhiYeDic[HeroType].zhiYeType;
            PropType 经验值 = PropType.None;
            switch (zhiye)
            {
                case ZhiYeType.射手:
                    经验值 = PropType.射手经验值;
                    break;
                case ZhiYeType.辅助:
                    经验值 = PropType.辅助经验值;
                    break;
                case ZhiYeType.法师:
                    经验值 = PropType.法师经验值;
                    break;
                case ZhiYeType.控制:
                    经验值 = PropType.控制经验值;
                    break;
                case ZhiYeType.战士:
                    经验值 = PropType.战士经验值;
                    break;
            }

            int 经验值需要值 = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level).Exp;
            int 元神需要值 = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level).元神;
            if (PlayerData.S.PropListDic[经验值] >= 经验值需要值 && PlayerData.S.HeroDataDic[HeroType].元神 >= 元神需要值)
            {
                PlayerData.S.PropListDic[经验值] -= 经验值需要值;
                PlayerData.S.HeroDataDic[HeroType].元神 -= 元神需要值;
                PlayerData.S.HeroDataDic[HeroType].Level++;
                ObserverModuleManager.S.SendEvent("SendUIToast","升星成功");
            }
            else
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
            }
        });
    }
}
