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
    public GameObject item1;
    public GameObject item2;
    public GameObject 法则item;
    public Button 星级button;
    public Button 升级button;
    public Image 法则bg;
    public Image 法则icon;
    public TextMeshProUGUI 法则name;
    public TextMeshProUGUI 法则当前值;
    public TextMeshProUGUI 法则需要值;
    public TextMeshProUGUI 技能name;
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

    private bool Is法则 = false;
    public void Set升星材料()
    {
        if (Is法则)
        {
            item1.gameObject.SetActive(false);
            item2.gameObject.SetActive(false);
            法则item.gameObject.SetActive(true);
            升级button.gameObject.SetActive(true);
            升星button.gameObject.SetActive(false);
            星级button.gameObject.SetActive(true);
            法则button.gameObject.SetActive(false);
            法则bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[HeroType]);
            法则icon.sprite = ResourcesConfig.Get法则Sprite(HeroType);
            法则name.text = 法则config.法则名Dic[HeroType];
            法则当前值.text = PlayerData.S.PropListDic[法则config.法则TypeDic[HeroType]].ToString();
            法则需要值.text=法则config.法则升级材料Dic[PlayerData.S.英雄法则等级Dic[HeroType]].ToString();
            法则button.gameObject.SetActive(HeroConfig.HeroQualityDic[HeroType]>=QualityType.宇品);
        }
        else
        {
            法则item.gameObject.SetActive(false);
            item1.gameObject.SetActive(true);
            item2.gameObject.SetActive(true);
            升级button.gameObject.SetActive(false);
            升星button.gameObject.SetActive(true);
            星级button.gameObject.SetActive(false);
            法则button.gameObject.SetActive(true);
        }
        if (HeroConfig.HeroQualityDic[HeroType] < QualityType.宇品)
        {
            法则button.gameObject.SetActive(false);
        }
        经验值name.text=HeroConfig.Get职业Name(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType)+"经验值";
        经验值bg.sprite = ResourcesConfig.道具背景框蓝;
        经验值icon.sprite = ResourcesConfig.Get职业经验值Sprite(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        经验值需要值.text = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level-1)
            .Exp.ToString();
        元神bg.sprite = ResourcesConfig.Get道具背景框Sprite(HeroConfig.HeroToPropDic[HeroType]);
        元神name.text = HeroConfig.HeroNameDic[HeroType] + "元神";
        元神需要值.text = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level-1)
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
        if (Is法则)
        { 
            升星奖励.text = "升级奖励：伤害增幅+" + 法则config.法则升级奖励Dic[HeroConfig.HeroQualityDic[HeroType]]+"%";
        }
        int xj = PlayerData.S.HeroDataDic[HeroType].Level - 1;
        if (Is法则)
        {
            xj = PlayerData.S.英雄法则等级Dic[HeroType] / 5;
        }
        for (int i = 1; i <= 5; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/升星信息item"), 升星信息Content.transform)
                .GetComponent<升星信息item>();
            item.锁 = xj < i;
            item.星级 = i;
            item.text = HeroConfig.英雄升星信息Dic[HeroType][i - 1];
            item.Is法则 = Is法则;
            if (Is法则)
            {
                item.text = 法则config.法则升级info[HeroType][i - 1];
            }
            item.SetItem();
        }
    }

    public void SetHeroInfo()
    {
        Cdtext.gameObject.SetActive(true);
        技能name.text = "技能";
        skillname.text = HeroConfig.SkillNameDic[HeroType];
        skillicon.sprite = ResourcesConfig.Get技能icon(HeroType);
        skillinfo.text=HeroConfig.HeroSkillInfoDic[HeroType];
        if (Is法则)
        {
            Cdtext.gameObject.SetActive(false);
            技能name.text = "法则";
            skillname.text = 法则config.法则名Dic[HeroType];
            skillicon.sprite = ResourcesConfig.Get法则Sprite(HeroType);
            skillinfo.text=法则config.法则info[HeroType];
        }
        QualityType heroquality = HeroConfig.HeroQualityDic[HeroType];
        image.sprite=ResourcesConfig.GetHeroSprite(HeroType);
        艺术字.sprite = ResourcesConfig.Get艺术字(heroquality);
        bg.sprite=ResourcesConfig.Get道具背景框SpriteByQuality(heroquality);
        name.text=HeroConfig.HeroNameDic[HeroType];
        职业icon.sprite = ResourcesConfig.Get职业icon(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        职业text.text = HeroConfig.Get职业Name(HeroConfig.HeroZhiYeDic[HeroType].zhiYeType);
        Cdtext.text = "CD:" + HeroConfig.HeroAttackTimeDic[HeroType]+"S";
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
            Is法则 = false;
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
        }
        
    }

    private void Start()
    {
        法则button.onClick.AddListener(() =>
        {
            Is法则 = true;
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
            法则button.gameObject.SetActive(false);
            星级button.gameObject.SetActive(true);
        });
        星级button.onClick.AddListener(() =>
        {
            Is法则 = false;
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
            法则button.gameObject.SetActive(true);
            星级button.gameObject.SetActive(false);
        });
        升级button.onClick.AddListener(() =>
        {
            int 需要值=法则config.法则升级材料Dic[PlayerData.S.英雄法则等级Dic[HeroType]];
            int 当前值 = PlayerData.S.PropListDic[法则config.法则TypeDic[HeroType]];
            if (当前值 < 需要值)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
                return;
            }
            else
            {
                PlayerData.S.PropListDic[法则config.法则TypeDic[HeroType]] -= 需要值;
                PlayerData.S.英雄法则等级Dic[HeroType]++;
                ObserverModuleManager.S.SendEvent("SendUIToast","升级成功");
                Set升星信息();
                SetHeroInfo();
                Set升星材料();
            }
        });
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

            int 经验值需要值 = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level-1).Exp;
            int 元神需要值 = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[HeroType], PlayerData.S.HeroDataDic[HeroType].Level-1).元神;
            if (PlayerData.S.PropListDic[经验值] >= 经验值需要值 && PlayerData.S.HeroDataDic[HeroType].元神 >= 元神需要值)
            {
                PlayerData.S.PropListDic[经验值] -= 经验值需要值;
                PlayerData.S.HeroDataDic[HeroType].元神 -= 元神需要值;
                PlayerData.S.HeroDataDic[HeroType].Level++;
                Set升星信息();
                Set升星材料();
                ObserverModuleManager.S.SendEvent("SendUIToast","升星成功");
                ObserverModuleManager.S.SendEvent("升星刷新",HeroType);
            }
            else
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
            }
        });
    }
}
