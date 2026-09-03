using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum 显示类型
{
    None,
    属性,
    法则,
    神通,
}
public class 英雄详情弹窗 : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject 法则item;
    public Button 星级button;
    public Button 升级button;
    public Button 神通升级button;
    public Button 神通button;

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
    public TextMeshProUGUI 能量text;

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

    private 显示类型 显示类型 = 显示类型.属性;
    public void Set升星材料()
    {
        if (显示类型!=显示类型.属性)
        {
            item1.gameObject.SetActive(false);
            item2.gameObject.SetActive(false);
            法则item.gameObject.SetActive(true);
            法则bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(HeroConfig.HeroQualityDic[HeroType]);
            if (显示类型 == 显示类型.法则)
            {           
                神通升级button.gameObject.SetActive(false);
                星级button.gameObject.SetActive(true);
                法则button.gameObject.SetActive(false); 
                升级button.gameObject.SetActive(true);
                升星button.gameObject.SetActive(false);        
                法则name.text = 法则config.法则名Dic[HeroType];
                法则icon.sprite = ResourcesConfig.Get法则Sprite(HeroType);
                法则当前值.text = PlayerData.S.PropListDic[法则config.法则TypeDic[HeroType]].ToString();
                法则需要值.text=法则config.法则升级材料Dic[PlayerData.S.英雄法则等级Dic[HeroType]].ToString();
            }
            else
            {
                神通升级button.gameObject.SetActive(true);
                升级button.gameObject.SetActive(false);
                升星button.gameObject.SetActive(false);  
                法则name.text = HeroConfig.HeroNameDic[HeroType] + "元神";
                法则icon.sprite = ResourcesConfig.Get品质元神Sprite(HeroConfig.HeroQualityDic[HeroType]);
                法则当前值.text = PlayerData.S.HeroDataDic[HeroType].元神.ToString();
                法则需要值.text="1";
            }
        }
        else
        {
            法则item.gameObject.SetActive(false);
            item1.gameObject.SetActive(true);
            item2.gameObject.SetActive(true);
            神通升级button.gameObject.SetActive(false);
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
        if (显示类型!=显示类型.属性)
        { 
            升星奖励.text = "升级奖励：暴击伤害增幅+" + HeroConfig.神通升级奖励Dic[HeroConfig.HeroQualityDic[HeroType]]+"%";
        }
        int xj = PlayerData.S.HeroDataDic[HeroType].Level - 1;
        if (显示类型==显示类型.法则)
        {
            xj = PlayerData.S.英雄法则等级Dic[HeroType] / 5;
        }
        if (显示类型==显示类型.神通)
        {
            xj = PlayerData.S.HeroDataDic[HeroType].神通等级 / 5;
        }
        for (int i = 1; i <= 5; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/升星信息item"), 升星信息Content.transform)
                .GetComponent<升星信息item>();
            item.锁 = xj < i;
            item.星级 = i;
            item.text = HeroConfig.英雄升星信息Dic[HeroType][i - 1];
            item.Is法则 = 显示类型!=显示类型.属性;
           
            if (显示类型==显示类型.神通)
            {
                if (HeroType == HeroType.女娲 || HeroType == HeroType.瑶池仙女 || HeroType == HeroType.妲己)
                {
                    switch (i)
                    {
                        case 1:
                            item.text = "神通效果 + <color=green>20%</color>";
                            break;
                        case 2:
                            item.text = "神通效果 + <color=green>50%</color>";
                            break;
                        case 3:
                            item.text = "神通效果 + <color=green>100%</color>";
                            break;
                        case 4:
                            item.text = "神通所需能量 - <color=green>20%</color>";
                            break;
                        case 5:
                            item.text = "神通冷却时间 - <color=green>20%</color>";
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        case 1:
                            item.text = "神通伤害 + <color=green>20%</color>";
                            break;
                        case 2:
                            item.text = "神通伤害 + <color=green>50%</color>";
                            break;
                        case 3:
                            item.text = "神通伤害 + <color=green>100%</color>";
                            break;
                        case 4:
                            item.text = "神通所需能量 - <color=green>20%</color>";
                            break;
                        case 5:
                            item.text = "神通冷却时间 - <color=green>20%</color>";
                            break;
                    }
                }
            }
            if (显示类型 == 显示类型.法则)
            {
                item.text = 法则config.法则升级info[HeroType][i - 1];
            }
            item.SetItem();
        }
    }

    public void SetHeroInfo()
    {
        能量text.gameObject.SetActive(false);
        Cdtext.gameObject.SetActive(true);
        技能name.text = "技能";
        skillname.text = HeroConfig.SkillNameDic[HeroType];
        skillicon.sprite = ResourcesConfig.Get技能icon(HeroType);
        skillinfo.text=HeroConfig.HeroSkillInfoDic[HeroType];
        if (显示类型==显示类型.法则)
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
        if (显示类型==显示类型.神通)
        {
            能量text.gameObject.SetActive(true);
            能量text.text="能量："+HeroConfig.英雄神通配置Dic[HeroType].能量;
            Cdtext.gameObject.SetActive(true);
            技能name.text = "神通";
            skillname.text = HeroConfig.英雄神通配置Dic[HeroType].name;
            skillicon.sprite = ResourcesConfig.Get英雄神通icon(HeroType);
            skillinfo.text = HeroConfig.Hero神通InfoDic[HeroType];
        }
    }
    private void OnEnable()
    {
        if (HeroType != HeroType.None)
        {
            显示类型 = 显示类型.属性;
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
        }
        
    }

    private void Start()
    {
        法则button.onClick.AddListener(() =>
        {
            显示类型 = 显示类型.法则;
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
            法则button.gameObject.SetActive(false);
            星级button.gameObject.SetActive(true);
        });
        星级button.onClick.AddListener(() =>
        {
            显示类型 = 显示类型.属性;
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
            法则button.gameObject.SetActive(true);
            星级button.gameObject.SetActive(false);
        });
        神通button.onClick.AddListener(() =>
        {
            显示类型 = 显示类型.神通;
            Set升星信息();
            SetHeroInfo();
            Set升星材料();
        });
        升级button.onClick.AddListener(() =>
        {
            int 需要值=法则config.法则升级材料Dic[PlayerData.S.英雄法则等级Dic[HeroType]];
            long 当前值 = PlayerData.S.PropListDic[法则config.法则TypeDic[HeroType]];
            if (当前值 < 需要值)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
                return;
            }
            else
            {
                PlayerData.S.PropListDic[法则config.法则TypeDic[HeroType]] -= 需要值;
                PlayerData.S.英雄法则等级Dic[HeroType]++;
                ObserverModuleManager.S.SendEvent("法则升级");
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
                ObserverModuleManager.S.SendEvent("SendUIToast","升级成功");
                Set升星信息();
                SetHeroInfo();
                Set升星材料();
            }
        });
        
        
        神通升级button.onClick.AddListener(() =>
        {
            int 需要值=1;
            long 当前值 = PlayerData.S.HeroDataDic[HeroType].元神;
            if (当前值 < 需要值)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
                return;
            }
            else
            {
                PlayerData.S.HeroDataDic[HeroType].元神 -= 需要值;
                PlayerData.S.HeroDataDic[HeroType].神通等级++;
                ObserverModuleManager.S.SendEvent("法则升级");
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
                ObserverModuleManager.S.SendEvent("SendUIToast","神通升级成功");
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
            if (PlayerData.S.HeroDataDic[HeroType].Level >= 6)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","星级已满");
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                return;
            }
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
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);

                ObserverModuleManager.S.SendEvent("SendUIToast","升星成功");
                ObserverModuleManager.S.SendEvent("升星刷新",HeroType);
            }
            else
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);

                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
            }
        });
    }
}
