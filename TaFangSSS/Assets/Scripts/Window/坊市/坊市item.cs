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
    public TextMeshProUGUI 标签text;

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
    [NonSerialized] public int 阶数;
    [NonSerialized] public bool 是否被购买 = false;
    [NonSerialized] public int index = 0;

    public void Start()
    {
        购买Button.onClick.AddListener(() =>
        {
            if (法器Type != 法器Type.None)
            {
                var 价格value = 坊市Config.Get法器价格(阶数) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格value)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast", "灵气不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格value;
                法器 法器 = 法器Config.Get坊市法器(法器Type, QualityType, 阶数);
                PlayerData.S.法器列表.Add(法器);
                ObserverModuleManager.S.SendEvent("SendUIToast", "购买成功");
                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;
                PlayerData.S.任务完成字典[任务Type.坊市购买物品] = true;
            }

            if (仙石Type != 仙石Type.None)
            {
                var 价格value = 坊市Config.Get仙石价格(阶数, QualityType) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格value)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast", "灵石不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格value;
                仙石 仙石 = 仙石Config.Get坊市仙石(仙石Type, QualityType, 阶数);
                PlayerData.S.仙石列表.Add(仙石);
                ObserverModuleManager.S.SendEvent("SendUIToast", "购买成功");

                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;
                PlayerData.S.任务完成字典[任务Type.坊市购买物品] = true;
            }

            if (丹药Type != 丹药Type.None)
            {
                float 价格value = 坊市Config.Get丹药阶数价格(丹药Type, 阶数, QualityType) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格value)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast", "灵石不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格value;
                PlayerData.S.Set丹药数量(丹药Type, QualityType, PlayerData.S.Get丹药数量(丹药Type, QualityType, 阶数) + 1, 阶数);
                ObserverModuleManager.S.SendEvent("SendUIToast", "购买成功");

                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;
                PlayerData.S.任务完成字典[任务Type.坊市购买物品] = true;
            }

            if (丹方Type != 丹药Type.None)
            {
                float 价格value = 坊市Config.Get丹方阶数价格(丹方Type, 阶数) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f);
                if (PlayerData.S.PropListDic[PropType.灵魂] < 价格value)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast", "灵石不足");
                    return;
                }

                PlayerData.S.PropListDic[PropType.灵魂] -= 价格value;
                PlayerData.S.Set丹方数量(丹方Type, 阶数, PlayerData.S.Get丹方数量(丹方Type, 阶数) + 1);
                ObserverModuleManager.S.SendEvent("SendUIToast", "购买成功");

                售空.gameObject.SetActive(true);
                PlayerData.S.坊市物品列表[index].是否被购买 = true;
                PlayerData.S.任务完成字典[任务Type.坊市购买物品] = true;
            }
        });
    }

    public void SetItem()
    {
        售空.gameObject.SetActive(是否被购买);
        if (法器Type != 法器Type.None)
        {
            name.text = 法器Config.Get法器Name(法器Type, 阶数);
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get法器Sprite(法器Type, 阶数);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 法器Config.法器descDic[法器Type];
            价格.text = PlayerData.S.格式化数字(坊市Config.Get法器价格(阶数) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f));
        }

        if (仙石Type != 仙石Type.None)
        {
            name.text = 仙石Config.Get仙石Name(仙石Type, 阶数);
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get仙石Sprite(仙石Type, 阶数);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 仙石Config.仙石DescDic[仙石Type];
            价格.text = PlayerData.S.格式化数字(坊市Config.Get仙石价格(阶数, QualityType) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f));
        }

        if (丹药Type != 丹药Type.None)
        {
            name.text = $"{丹药Config.丹药名Dic[丹药Type]}·{阶数}阶";
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
            icon.sprite = ResourcesConfig.Get丹药icon(丹药Type, QualityType);
            bg.sprite = ResourcesConfig.Get传道背景框(QualityType);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(QualityType);
            desc.text = 丹药Config.Get丹药Desc(丹药Type, QualityType);
            价格.text = PlayerData.S.格式化数字(坊市Config.Get丹药阶数价格(丹药Type, 阶数, QualityType) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f));
        }

        if (丹方Type != 丹药Type.None)
        {
            if (PlayerData.S.Get丹方解锁(丹方Type, 阶数) || PlayerData.S.Get丹方数量(丹方Type, 阶数) > 0)
            {
                售空.gameObject.SetActive(true);
                标签text.text = "已拥有";
            }
            QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
            name.text = $"{丹药Config.丹方名Dic[丹方Type]}·{阶数}阶";
            name.colorGradientPreset = ResourcesConfig.Get品质TMP(材料品质);
            icon.sprite = ResourcesConfig.Get丹方icon(丹方Type, 材料品质); // 丹方icon按阶数对应的材料品质取
            bg.sprite = ResourcesConfig.Get传道背景框(材料品质);
            iconBg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(材料品质);
            desc.text = 丹药Config.丹方DescDic[丹方Type];
            价格.text = PlayerData.S.格式化数字(坊市Config.Get丹方阶数价格(丹方Type, 阶数) / (1f + 道场Config.供奉总属性.坊市价格减少 / 100f));
        }
    }
}
