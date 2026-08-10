using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 退出确认弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 确认Button;
    public Button 返回Button;

    public void 清空怪物()
    {
        foreach (var item in QueueController.S.MonsterColliderDic)
        {
            item.Value.gameObject.SetActive(false);
        }
        FightController.S.当前怪物Set.Clear();
    }
    private void Awake()
    {
        maskButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        });
        返回Button.onClick.AddListener(() =>
        {
            Time.timeScale = PlayerData.S.关卡倍速;
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            清空怪物();
            SceneManager.LoadScene("UIScene");
        });
    }
}
