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
    }
    private void OnEnable()
    {
        SetToggle();
    }

    
    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        分解Button.onClick.AddListener(() =>
        {
            switch (分解类型)
            {
                case 分解类型.丹药:
                    // ToList() 先拍快照再遍历：循环体内的 Set丹药数量 会写丹药Dic，
                    // 边枚举边写入会抛 "Collection was modified"（索引器写入也递增版本号）
                    foreach (var item in PlayerData.S.丹药Dic.ToList())
                    {
                        // 脏数据防御：解析不出丹药类型的条目（如 "None_黄品"）跳过，
                        // 否则 Get丹药分解价格 查 丹药类型Dic[None] 抛 KeyNotFoundException
                        if (PlayerData.S.Get丹药Type(item.Key) == 丹药Type.None)
                        {
                            continue;
                        }
                        QualityType qualityType=PlayerData.S.Get丹药品质(item.Key);
                        switch (qualityType)
                        {
                            case QualityType.黄品:
                                if (黄)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                            case QualityType.玄品:
                                if (玄)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                            case QualityType.地品:
                                if (地)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                            case QualityType.天品:
                                if (天)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                            case QualityType.宇品:
                                if (宇)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                            case QualityType.宙品:
                                if (宙)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                            case QualityType.洪品:
                                if (洪)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                            case QualityType.荒品:
                                if (荒)
                                {
                                    PlayerData.S.PropListDic[PropType.灵魂]+=丹药Config.Get丹药分解价格(PlayerData.S.Get丹药Type(item.Key),qualityType)*item.Value;
                                    PlayerData.S.Set丹药数量(PlayerData.S.Get丹药Type(item.Key),qualityType,0);
                                }
                                break;
                        }
                    }
                    break;
                case 分解类型.法器:
                    PlayerData.S.法器列表.RemoveAll(法器 => 
                    {
                        var 品质 = 法器Config.法器品质Dic[法器.法器Type];
                        bool v= 法器.HeroType==HeroType.None&&((品质 == QualityType.黄品 && 黄) || 
                               (品质 == QualityType.玄品 && 玄) || 
                               (品质 == QualityType.地品 && 地) || 
                               (品质 == QualityType.天品 && 天) || 
                               (品质 == QualityType.宇品 && 宇)||
                               (品质 == QualityType.宙品 && 宙)||
                               (品质 == QualityType.洪品 && 洪)||
                               (品质 == QualityType.荒品 && 荒));
                        if (v)
                        {
                            PlayerData.S.PropListDic[PropType.法器粉尘] += 法器Config.法器分解Dic[品质]*(1f+道场Config.供奉总属性.增加法器分解粉尘/100f);
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
                        if (v)
                        {
                            PlayerData.S.PropListDic[PropType.仙石精华] += 仙石Config.仙石分解Dic[品质];
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
    }
}    

