using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        // 失败重开是原地重置（"关卡重置"），不重走 LoadScene 预热——场上活怪必须回池。
        // 以前只 SetActive(false) 不入队：每次失败把池漏掉当时场上的全部活怪（失败时场上怪最多），
        // 连败几场后池=0，不出怪也没怪打墙，战斗死锁在"不赢不败"的中间态
        foreach (var monster in FightController.S.当前怪物Set.ToList())
        {
            if (monster == null || monster.isDead) continue;   // 已死的 Die finally 已回池
            monster.isDead = true;   // 与 Die 互斥：飞行中的弹幕再调 Hurt/Die 不会重复入队
            switch (MonsterConfig.MonsterTypeDic[monster.MonsterTypeName])
            {
                case MonsterType.Normal: QueueController.S.普通怪Queue.Enqueue(monster as 普通怪); break;
                case MonsterType.Elite: QueueController.S.精英怪Queue.Enqueue(monster as 精英怪); break;
                case MonsterType.Boss: QueueController.S.首领怪Queue.Enqueue(monster as 首领怪); break;
            }
            for (int i = 1; i <= 7; i++)
            {
                FightController.S.Monster分区Dic[i].Remove(monster);
            }
            monster.gameObject.SetActive(false);
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
            战斗Text.text = "重复挑战:" + (int)(2f - 重复挑战Time);
            if (2f - 重复挑战Time < 0)
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
