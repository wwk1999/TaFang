using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 符文熔炼所有弹窗 : MonoBehaviour
{
    public Toggle 灵文Toggle;
    public Toggle 仙文Toggle;
    public Toggle 帝文Toggle;
    public Toggle 圣文Toggle;
    public Toggle 道文Toggle;
    public Button 熔炼Button;
    public Button maskButton;
    private bool 灵=false;
    private bool 仙=false;
    private bool 帝=false;
    private bool 圣=false;
    private bool 道=false;
    public void SetToggle()
    {
        灵文Toggle.isOn = 灵;
        仙文Toggle.isOn = 仙;
        帝文Toggle.isOn = 帝;
        圣文Toggle.isOn = 圣;
        道文Toggle.isOn = 道;
    }
    /// <summary>
    /// 批量熔炼某品质符文：只熔炼未锁定的，每4个熔成1个同品质新符文，剩余1~3个保留原样。
    /// 返回熔炼出的新符文数量。
    /// </summary>
    private int 批量熔炼(List<符文> list, 符文品质Type 品质)
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
            if (灵) 新符文总数 += 批量熔炼(PlayerData.S.符文灵文List, 符文品质Type.灵文);
            if (仙) 新符文总数 += 批量熔炼(PlayerData.S.符文仙文List, 符文品质Type.仙文);
            if (帝) 新符文总数 += 批量熔炼(PlayerData.S.符文帝文List, 符文品质Type.帝文);
            if (圣) 新符文总数 += 批量熔炼(PlayerData.S.符文圣文List, 符文品质Type.圣文);
            if (道) 新符文总数 += 批量熔炼(PlayerData.S.符文道文List, 符文品质Type.道文);
            if (新符文总数 == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","没有可熔炼的符文(需勾选品质且有4个以上未锁符文)");
                return;
            }
            ObserverModuleManager.S.SendEvent("SendUIToast",$"熔炼完成，获得{新符文总数}个新符文");
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
        灵文Toggle.onValueChanged.AddListener((value) =>
        {
            灵=value;
        });
        仙文Toggle.onValueChanged.AddListener((value) =>
        {
           仙=value;
        });
        帝文Toggle.onValueChanged.AddListener((value) =>
        {
            帝=value;
        });
        圣文Toggle.onValueChanged.AddListener((value) =>
        {
            圣=value;
        });
        道文Toggle.onValueChanged.AddListener((value) =>
        {
            道=value;
        });
    }
}
