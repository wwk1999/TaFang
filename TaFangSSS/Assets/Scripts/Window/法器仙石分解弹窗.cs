using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Config;
using UnityEngine;
using UnityEngine.UI;

public enum 分解类型
{
    None,
    法器,
    仙石,
    丹药,
    符文,
}
public class 法器仙石分解弹窗 : MonoBehaviour
{
    [NonSerialized] public 分解类型 分解类型 = 分解类型.None;
    public Toggle 黄Toggle;
    public Toggle 玄Toggle;
    public Toggle 地Toggle;
    public Toggle 天Toggle;
    public Toggle 宇Toggle;
    public Toggle 宙Toggle;
    public Toggle 洪Toggle;
    public Toggle 荒Toggle;
    // 阶数筛选（法器/仙石共用）：索引0~15对应1~16阶；全部不勾表示不限制阶数
    public Toggle[] 阶数Toggles = new Toggle[16];
    private readonly bool[] 阶数选中 = new bool[16];
    public Button 分解Button;
    public Button maskButton;
    private bool 黄=false;
    private bool 玄=false;
    private bool 地=false;
    private bool 天=false;
    private bool 宇=false;
    private bool 宙=false;
    private bool 洪=false;
    private bool 荒=false;
    public void SetToggle()
    {
        黄Toggle.isOn = 黄;
        玄Toggle.isOn = 玄;
        地Toggle.isOn = 地;
        天Toggle.isOn = 天;
        宇Toggle.isOn = 宇;
        宙Toggle.isOn = 宙;
        洪Toggle.isOn = 洪;
        荒Toggle.isOn = 荒;
        for (int i = 0; i < 阶数Toggles.Length && i < 16; i++)
        {
            if (阶数Toggles[i] != null) 阶数Toggles[i].isOn = 阶数选中[i];
        }
    }
    private void OnEnable()
    {
        载入筛选存档();
        SetToggle();
    }
    private void OnDisable()
    {
        保存筛选存档();
    }

    /// <summary>从存档恢复当前分解类型的品质/阶数勾选（缺省全不勾）</summary>
    private void 载入筛选存档()
    {
        var 存档 = PlayerData.S.获取分解筛选存档(分解类型);
        黄 = 存档.品质勾选[0];
        玄 = 存档.品质勾选[1];
        地 = 存档.品质勾选[2];
        天 = 存档.品质勾选[3];
        宇 = 存档.品质勾选[4];
        宙 = 存档.品质勾选[5];
        洪 = 存档.品质勾选[6];
        荒 = 存档.品质勾选[7];
        for (int i = 0; i < 16; i++) 阶数选中[i] = 存档.阶数勾选[i];
    }

    /// <summary>关闭时把当前品质/阶数勾选写回对应分解类型的存档</summary>
    private void 保存筛选存档()
    {
        var 存档 = PlayerData.S.获取分解筛选存档(分解类型);
        存档.品质勾选[0] = 黄;
        存档.品质勾选[1] = 玄;
        存档.品质勾选[2] = 地;
        存档.品质勾选[3] = 天;
        存档.品质勾选[4] = 宇;
        存档.品质勾选[5] = 宙;
        存档.品质勾选[6] = 洪;
        存档.品质勾选[7] = 荒;
        for (int i = 0; i < 16; i++) 存档.阶数勾选[i] = 阶数选中[i];
    }

    
    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        //分解所有阶段的丹药
        分解Button.onClick.AddListener(() =>
        {
            // 阶数筛选（法器/仙石共用）：有任一阶数勾选时只分解对应阶数；全部不勾则不限制阶数
            bool 限制阶数 = false;
            for (int i = 0; i < 16; i++) { if (阶数选中[i]) { 限制阶数 = true; break; } }
            switch (分解类型)
            {
                case 分解类型.法器:
                    PlayerData.S.法器列表.RemoveAll(法器 => 
                    {
                        var 品质 = 法器.品质;
                        bool v= 法器.HeroType==HeroType.None&&((品质 == QualityType.黄品 && 黄) || 
                               (品质 == QualityType.玄品 && 玄) || 
                               (品质 == QualityType.地品 && 地) || 
                               (品质 == QualityType.天品 && 天) || 
                               (品质 == QualityType.宇品 && 宇)||
                               (品质 == QualityType.宙品 && 宙)||
                               (品质 == QualityType.洪品 && 洪)||
                               (品质 == QualityType.荒品 && 荒));
                        if (限制阶数)
                        {
                            v = v && 阶数选中[法器.阶数 - 1];
                        }
                        if (v)
                        {
                            PlayerData.S.PropListDic[PropType.法器粉尘] += 法器Config.Get法器分解粉尘(法器) * (1f + 道场Config.供奉总属性.增加法器分解粉尘/100f) * (1f + 属性config.仙子总属性.加分解粉尘/100f);
                        }
                        return v;
                    });
                    break;
                case 分解类型.仙石:
                    PlayerData.S.仙石列表.RemoveAll(仙石 =>
                    {
                        var 品质 = 仙石.quality;
                        bool v= (品质 == QualityType.黄品 && 黄) ||
                               (品质 == QualityType.玄品 && 玄) ||
                               (品质 == QualityType.地品 && 地) ||
                               (品质 == QualityType.天品 && 天) ||
                               (品质 == QualityType.宇品 && 宇)||
                               (品质 == QualityType.宙品 && 宙)||
                               (品质 == QualityType.洪品 && 洪)||
                               (品质 == QualityType.荒品 && 荒);
                        if (限制阶数)
                        {
                            v = v && 阶数选中[仙石.阶数 - 1];
                        }
                        if (v)
                        {
                            PlayerData.S.PropListDic[PropType.仙石精华] += 仙石Config.Get仙石分解精华(仙石);
                        }
                        return v;
                    });
                    break;
            }
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
        黄Toggle.onValueChanged.AddListener((value) =>
        {
            黄=value;
        });
        玄Toggle.onValueChanged.AddListener((value) =>
        {
            玄=value;
        });
        地Toggle.onValueChanged.AddListener((value) =>
        {
            地=value;
        });
        天Toggle.onValueChanged.AddListener((value) =>
        {
            天=value;
        });
        宇Toggle.onValueChanged.AddListener((value) =>
        {
            宇=value;
        });
        宙Toggle.onValueChanged.AddListener((value) =>
        {
            宙=value;
        });
        洪Toggle.onValueChanged.AddListener((value) =>
        {
            洪=value;
        });
        荒Toggle.onValueChanged.AddListener((value) =>
        {
            荒=value;
        });
        // 阶数Toggle事件：索引0~15对应1~16阶
        for (int i = 0; i < 阶数Toggles.Length && i < 16; i++)
        {
            int idx = i;
            if (阶数Toggles[idx] != null)
            {
                阶数Toggles[idx].onValueChanged.AddListener((value) =>
                {
                    阶数选中[idx] = value;
                });
            }
        }
    }
}    

