using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 失败弹窗 : MonoBehaviour
{
    public Button AgainButtn;
    public Button ExitButtn;
    private float 重复挑战Time = 0;
    public TextMeshProUGUI 战斗Text;
    public void 清空怪物()
    {
        foreach (var item in QueueController.S.MonsterColliderDic)
        {
            item.Value.gameObject.SetActive(false);
        }
        FightController.S.当前怪物Set.Clear();
    }

    private void OnEnable()
    {
        重复挑战Time = 0;
        ObserverModuleManager.S.SendEvent("停止元始音效");
        // 与胜利弹窗一致：未开重复挑战时按钮显示"再战一次"，开启时由 Update 显示倒计时
        if (PlayerData.S.重复挑战 == false)
        {
            战斗Text.text = "再战一次";
        }
    }
    
    private void Update()
    {
        if (PlayerData.S.重复挑战)
        {
            重复挑战Time += Time.unscaledDeltaTime;
            战斗Text.text = "重复挑战:" + (int)(5f - 重复挑战Time);
            if (5f - 重复挑战Time < 0)
            {
                // 失败时 Entrance 把 timeScale 冻结为 0，自动重开必须先恢复，
                // 否则重置后 deltaTime 恒为 0，怪物不动、不刷怪，像死机
                Time.timeScale = PlayerData.S.关卡倍速;
                清空怪物();
                ObserverModuleManager.S.SendEvent("关卡重置");
                gameObject.SetActive(false);
            }
        }
    }

    private void Start()
    {
        ExitButtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            清空怪物();
            // 卸载战斗场景并切回还活着的 UIScene（Single 重载会销毁 WindowController/MainWindow，画布排序必乱）
            QueueController.S.退出战斗回道场();
            ObserverModuleManager.S.SendEvent("播放BGM",true);
        });
        AgainButtn.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            清空怪物();
            // 卸载战斗场景后 additive 重走 LoadScene→FightScene 流程，常驻 UIScene 不动
            QueueController.S.重开战斗();
        });
    }
}
