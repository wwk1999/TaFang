using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 坊市自动购买Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public 法器Type 法器Type;
    [NonSerialized] public 丹药Type 丹药Type;
    [NonSerialized] public 丹药Type 丹方Type;
    [NonSerialized] public 仙石Type 仙石Type;
    [NonSerialized] public QualityType QualityType;

    private void Start()
    {
        btn.onClick.AddListener(() =>
        {
            if (丹药Type != 丹药Type.None)
            {
                PlayerData.S.Set坊市丹药自动购买(丹药Type,QualityType,!PlayerData.S.Get坊市丹药自动购买(丹药Type,QualityType));
            }
            if (丹方Type != 丹药Type.None)
            {
                PlayerData.S.Set坊市丹方自动购买(丹方Type,QualityType,!PlayerData.S.Get坊市丹方自动购买(丹方Type,QualityType));
            }
            
            if (法器Type != 法器Type.None)
            {
                PlayerData.S.Set坊市法器自动购买(法器Type,!PlayerData.S.Get坊市法器自动购买(法器Type));
            }
            
            if (仙石Type != 仙石Type.None)
            {
                PlayerData.S.Set坊市仙石自动购买(仙石Type,QualityType,!PlayerData.S.Get坊市仙石自动购买(仙石Type,QualityType));
            }
            SetItem();
        });
    }

    public void SetItem()
    {
        if (法器Type != 法器Type.None)
        {
            if (PlayerData.S.坊市自动购买法器配置[法器Type])
            {
                btn.image.sprite = ResourcesConfig.toggle亮;
            }
            else
            {
                btn.image.sprite = ResourcesConfig.toggle暗;
            }

            text.text = PropConfig.QualityNameDic[法器Config.法器品质Dic[法器Type]] +法器Config.法器职业Dic[法器Type]+
                        法器Config.法器类型String[法器Config.法器类型Dic[法器Type]];
        }
        
        if (仙石Type != 仙石Type.None)
        {
            string str = 仙石Type + "_" + QualityType;
            if (PlayerData.S.坊市自动购买仙石配置[str])
            {
                btn.image.sprite = ResourcesConfig.toggle亮;
            }
            else
            {
                btn.image.sprite = ResourcesConfig.toggle暗;
            }
            text.text = PropConfig.QualityNameDic[QualityType] + 仙石Config.仙石名Dic[仙石Type];
        }
        
        if (丹药Type != 丹药Type.None)
        {
            string str = 丹药Type + "_" + QualityType;
            if (PlayerData.S.坊市自动购买丹药配置[str])
            {
                btn.image.sprite = ResourcesConfig.toggle亮;
            }
            else
            {
                btn.image.sprite = ResourcesConfig.toggle暗;
            }
            text.text = PropConfig.QualityNameDic[QualityType] + 丹药Config.丹药名Dic[丹药Type];
        }
        if (丹方Type != 丹药Type.None)
        {
            string str = 丹方Type + "_" + QualityType;
            if (PlayerData.S.坊市自动购买丹方配置[str])
            {
                btn.image.sprite = ResourcesConfig.toggle亮;
            }
            else
            {
                btn.image.sprite = ResourcesConfig.toggle暗;
            }
            text.text = PropConfig.QualityNameDic[QualityType] + 丹药Config.丹方名Dic[丹方Type];
        }
    }
}
