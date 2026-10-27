using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 符文熔炼所有弹窗 : MonoBehaviour
{
    public Toggle 黄品Toggle;
    public Toggle 玄品Toggle;
    public Toggle 地品Toggle;
    public Toggle 天品Toggle;
    public Toggle 宇品Toggle;
    public Toggle 宙品Toggle;
    public Toggle 洪品Toggle;
    public Toggle 荒品Toggle;
    public Button 熔炼Button;
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
        黄品Toggle.isOn = 黄;
        玄品Toggle.isOn = 玄;
        地品Toggle.isOn = 地;
        天品Toggle.isOn = 天;
        宇品Toggle.isOn = 宇;
        宙品Toggle.isOn = 宙;
        洪品Toggle.isOn = 洪;
        荒品Toggle.isOn = 荒;
    }
    /// <summary>
    /// 批量熔炼某品质符文：只熔炼未锁定的，每4个熔成1个同品质新符文，剩余1~3个保留原样。
    /// 返回熔炼出的新符文数量。
    /// </summary>
    private int 批量熔炼(List<符文> list, QualityType 品质)
    {
        int 未锁数量 = 0;
        foreach (var item in list)
        {
            if (!item.锁) 未锁数量++;
        }
        int 新符文数 = 未锁数量 / 4;
        if (新符文数 == 0) return 0;
        // 从后往前移除 新符文数*4 个未锁符文
        int 待移除 = 新符文数 * 4;
        for (int i = list.Count - 1; i >= 0 && 待移除 > 0; i--)
        {
            if (!list[i].锁)
            {
                list.RemoveAt(i);
                待移除--;
            }
        }
        for (int i = 0; i < 新符文数; i++)
        {
            list.Add(符文之地Config.Get品质符文(品质));
        }
        return 新符文数;
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
        熔炼Button.onClick.AddListener(() =>
        {
            int 新符文总数 = 0;
            if (黄) 新符文总数 += 批量熔炼(PlayerData.S.符文黄品List, QualityType.黄品);
            if (玄) 新符文总数 += 批量熔炼(PlayerData.S.符文玄品List, QualityType.玄品);
            if (地) 新符文总数 += 批量熔炼(PlayerData.S.符文地品List, QualityType.地品);
            if (天) 新符文总数 += 批量熔炼(PlayerData.S.符文天品List, QualityType.天品);
            if (宇) 新符文总数 += 批量熔炼(PlayerData.S.符文宇品List, QualityType.宇品);
            if (宙) 新符文总数 += 批量熔炼(PlayerData.S.符文宙品List, QualityType.宙品);
            if (洪) 新符文总数 += 批量熔炼(PlayerData.S.符文洪品List, QualityType.洪品);
            if (荒) 新符文总数 += 批量熔炼(PlayerData.S.符文荒品List, QualityType.荒品);
            if (新符文总数 == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","没有可熔炼的符文(需勾选品质且有4个以上未锁符文)");
                return;
            }
            ObserverModuleManager.S.SendEvent("SendUIToast",$"熔炼完成，获得{新符文总数}个新符文");
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
        黄品Toggle.onValueChanged.AddListener((value) =>
        {
            黄=value;
        });
        玄品Toggle.onValueChanged.AddListener((value) =>
        {
           玄=value;
        });
        地品Toggle.onValueChanged.AddListener((value) =>
        {
            地=value;
        });
        天品Toggle.onValueChanged.AddListener((value) =>
        {
            天=value;
        });
        宇品Toggle.onValueChanged.AddListener((value) =>
        {
            宇=value;
        });
        宙品Toggle.onValueChanged.AddListener((value) =>
        {
            宙=value;
        });
        洪品Toggle.onValueChanged.AddListener((value) =>
        {
            洪=value;
        });
        荒品Toggle.onValueChanged.AddListener((value) =>
        {
            荒=value;
        });
    }
}
