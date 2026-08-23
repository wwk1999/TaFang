using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹方使用弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 返回按钮;
    public Button 确认按钮;
    public TextMeshProUGUI name;
    [NonSerialized]public QualityType qualityType;
    [NonSerialized]public 丹药Type 丹药Type;

    private void OnEnable()
    {
        name.text = 丹药Config.丹方名Dic[丹药Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(qualityType);
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        返回按钮.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认按钮.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("SendUIToast","学习丹方成功");
            PlayerData.S.Set丹方解锁(丹药Type,qualityType,true);
            PlayerData.S.Set丹方数量(丹药Type,qualityType,PlayerData.S.Get丹方数量(丹药Type,qualityType)-1);
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
    }
}
