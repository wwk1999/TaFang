using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 无暇提示弹窗 : MonoBehaviour
{
    public Button 返回Button;
    public Button 确定Button;

    private void Start()
    {
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确定Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("无暇确定洗练");
            gameObject.SetActive(false);
        });
    }
}
