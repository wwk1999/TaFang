using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 轮回确认弹窗 : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button 返回Button;
    public Button 确认Button;
    public Button maskButton;

    private void OnEnable()
    {
        text.text = $"是否确认轮回,轮回后将重置修为和体质,同时保留<color=green>{JingJieConfig.轮回系数}%</color>当前跟脚作为轮回后的初始跟脚";
    }

    private void Start()
    {
        返回Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            for (int i = 1; i < Enum.GetValues(typeof(JingJieType)).Length-1; i++)
            {
                PlayerData.S.当前轮回突破Dic[(JingJieType)i] = QualityType.None;
            }
            PlayerData.S.初始跟脚 += JingJieConfig.跟脚 * JingJieConfig.轮回系数 / 100f;
            PlayerData.S.当前轮回境界 = JingJieType.练气;
            PlayerData.S.Exp = 0;
            PlayerData.S.当前体质 = 体质Config.Get轮回体质();
            PlayerData.S.长生道体年数 = 0;
            PlayerData.S.当前轮回造化丹药QualityType = QualityType.None;
            ObserverModuleManager.S.SendEvent("SendUIToast","轮回成功");
            ObserverModuleManager.S.SendEvent("刷新人物信息");
            gameObject.SetActive(false);
        });
    }
}
