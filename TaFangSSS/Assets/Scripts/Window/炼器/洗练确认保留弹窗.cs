using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 洗练确认保留弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 返回Button;
    public Button 确认Button;

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
            {
                HeroWindowController.S.洗练panel当前法器.list.Clear();
                HeroWindowController.S.洗练panel当前法器.list = HeroWindowController.S.洗练后词条;
                HeroWindowController.S.洗练后词条 = null;
                ObserverModuleManager.S.SendEvent("刷新洗练Panel");
                gameObject.SetActive(false);
            }
        );
    }
}
