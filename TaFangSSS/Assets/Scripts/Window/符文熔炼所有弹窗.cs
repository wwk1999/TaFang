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
            if (灵)
            {
                int count = PlayerData.S.符文灵文List.Count/4;
            }
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
