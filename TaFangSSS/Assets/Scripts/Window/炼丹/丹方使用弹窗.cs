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
    [NonSerialized] public int 阶数;
    [NonSerialized] public 丹药Type 丹药Type;

    private void OnEnable()
    {
        QualityType 材料品质 = 丹药Config.Get材料品质(阶数);
        name.text = $"{多语言Config.Get(丹药Config.丹方名Dic[丹药Type])}·{阶数}阶";
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(材料品质);
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
            ObserverModuleManager.S.SendEvent("SendUIToast", "学习丹方成功");
            PlayerData.S.Set丹方解锁(丹药Type, 阶数, true);
            PlayerData.S.Set丹方数量(丹药Type, 阶数, PlayerData.S.Get丹方数量(丹药Type, 阶数) - 1);
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
    }
}
