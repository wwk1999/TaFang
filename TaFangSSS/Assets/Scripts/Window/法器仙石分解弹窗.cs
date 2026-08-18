using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public enum 分解类型
{
    None,
    法器,
    仙石,
}
public class 法器仙石分解弹窗 : MonoBehaviour
{
    [NonSerialized] public 分解类型 分解类型 = 分解类型.None;
    public Toggle 黄Toggle;
    public Toggle 玄Toggle;
    public Toggle 地Toggle;
    public Toggle 天Toggle;
    public Toggle 宇Toggle;
    public Button 分解Button;
    private bool 黄=false;
    private bool 玄=false;
    private bool 地=false;
    private bool 天=false;
    private bool 宇=false;

    public void SetToggle()
    {
        黄Toggle.isOn = 黄;
        玄Toggle.isOn = 玄;
        地Toggle.isOn = 地;
        天Toggle.isOn = 天;
        宇Toggle.isOn = 宇;
    }
    private void OnEnable()
    {
        SetToggle();
    }

    
    private void Start()
    {
        分解Button.onClick.AddListener(() =>
        {
            switch (分解类型)
            {
                case 分解类型.法器:
                    PlayerData.S.法器列表.RemoveAll(法器 => 
                    {
                        var 品质 = 法器Config.法器品质Dic[法器.法器Type];
                        bool v= (品质 == QualityType.黄品 && 黄) || 
                               (品质 == QualityType.玄品 && 玄) || 
                               (品质 == QualityType.地品 && 地) || 
                               (品质 == QualityType.天品 && 天) || 
                               (品质 == QualityType.宇品 && 宇);
                        if (v)
                        {
                            PlayerData.S.PropListDic[PropType.法器粉尘] += 法器Config.法器分解Dic[品质];
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
                               (品质 == QualityType.宇品 && 宇);
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
    }
}    

