using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum 坊市道具类型
{
    None,
    法器,
    仙石,
    丹药,
    丹方,
}
public class 坊市item : MonoBehaviour
{
    public TextMeshProUGUI name;
    public Image icon;
    public Image bg;
    public Image iconBg;
    public TextMeshProUGUI desc;
    public Button 购买Button;
    public TextMeshProUGUI 价格;
    public GameObject 售空;
    [NonSerialized] public 法器Type 法器Type;
    [NonSerialized] public 仙石Type 仙石Type;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public 丹药Type 丹方Type;
    [NonSerialized] public QualityType QualityType;
    [NonSerialized]public bool 是否被购买 = false;
    [NonSerialized] public int index = 0;

    public void Start()
    {
        购买Button.onClick.AddListener(() =>
        {
            if (法器Type != 法器Type.None)
            {
                var 价格 = 坊市Config.法器价格Dic[法器Config.法器品质Dic[法器Type]];
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","灵石不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                法器 法器 = 法器Config.Get坊市法器(法器Type);
                PlayerData.S.法器列表.Add(法器);
                ObserverModuleManager.S.SendEvent("SendUIToast","购买成功");
                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;
            }
            
            if (仙石Type != 仙石Type.None)
            {
                var 价格 = 坊市Config.仙石价格Dic[QualityType];
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","灵石不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                仙石 仙石 = 仙石Config.Get坊市仙石(仙石Type,QualityType);
                PlayerData.S.仙石列表.Add(仙石);
                ObserverModuleManager.S.SendEvent("SendUIToast","购买成功");

                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;

            }
            
            if (丹药Type != 丹药Type.None)
            {
                var 丹药类型 = 丹药Config.丹药类型Dic[丹药Type];
                long 价格 = 0;
                switch (丹药类型)
                {
                    case 丹药类型.战斗丹药:
                        价格=坊市Config.战斗丹药价格Dic[QualityType];
                        break;
                    case 丹药类型.辅助丹药:
                        价格=坊市Config.辅助丹药价格Dic[QualityType];
                        break;
                    case 丹药类型.根基丹药:
                        价格=坊市Config.根基丹药价格Dic[QualityType];
                        break;
                    case 丹药类型.造化丹药:
                        价格=坊市Config.造化丹药价格Dic[QualityType];
                        break;
                }
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","灵石不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                PlayerData.S.Set丹药数量(丹药Type,QualityType,PlayerData.S.Get丹药数量(丹药Type,QualityType)+1);
                ObserverModuleManager.S.SendEvent("SendUIToast","购买成功");

                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;

            }
            
            
            if (丹方Type != 丹药Type.None)
            {
                var 丹药类型 = 丹药Config.丹药类型Dic[丹方Type];
                long 价格 = 0;
                switch (丹药类型)
                {
                    case 丹药类型.战斗丹药:
                        价格=坊市Config.战斗丹方价格Dic[QualityType];
                        break;
                    case 丹药类型.辅助丹药:
                        价格=坊市Config.辅助丹方价格Dic[QualityType];
                        break;
                    case 丹药类型.根基丹药:
                        价格=坊市Config.根基丹方价格Dic[QualityType];
                        break;
                    case 丹药类型.造化丹药:
                        价格=坊市Config.造化丹方价格Dic[QualityType];
                        break;
                }
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","灵石不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格;
                PlayerData.S.Set丹方数量(丹方Type,QualityType,PlayerData.S.Get丹方数量(丹方Type,QualityType)+1);
                ObserverModuleManager.S.SendEvent("SendUIToast","购买成功");

                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;

            }
        });
    }

    public void SetItem()
    {
        售空.gameObject.SetActive(是否被购买);
        if (法器Type != 法器Type.None)
        {
            name.text = 法器Config.法器名Dic[法器Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(法器Config.法器品质Dic[法器Type]);
            icon.sprite = ResourcesConfig.Get法器Sprite(法器Type);
            bg.sprite = ResourcesConfig.Get传道背景框(法器Config.法器品质Dic[法器Type]);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器Type]);
            desc.text = 法器Config.法器descDic[法器Type];
            价格.text = PlayerData.S.格式化数字(坊市Config.法器价格Dic[法器Config.法器品质Dic[法器Type]]);
        }
        
        if (仙石Type != 仙石Type.None)
        {
            name.text = 仙石Config.仙石名Dic[仙石Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get仙石Sprite(仙石Type,QualityType);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 仙石Config.仙石DescDic[仙石Type];
            价格.text = PlayerData.S.格式化数字(坊市Config.仙石价格Dic[QualityType]);
        }
        
        if (丹药Type != 丹药Type.None)
        {
            name.text = 丹药Config.丹药名Dic[丹药Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get丹药icon(丹药Type,QualityType);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 丹药Config.Get丹药Desc(丹药Type,QualityType);
            价格.text = PlayerData.S.格式化数字(丹药Config.Get丹药价格(丹药Type,QualityType));
        }
        
        if (丹方Type != 丹药Type.None)
        {
            name.text = 丹药Config.丹方名Dic[丹方Type];
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get丹方icon(丹方Type,QualityType);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 丹药Config.丹方DescDic[丹方Type];
            价格.text = PlayerData.S.格式化数字(丹药Config.Get丹方价格(丹方Type,QualityType));
        }
    }
}
