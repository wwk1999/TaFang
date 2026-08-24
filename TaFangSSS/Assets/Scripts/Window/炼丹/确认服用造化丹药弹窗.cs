using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 确认服用造化丹药弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 返回按钮;
    public Button 确认按钮;
    [NonSerialized]public QualityType qualityType;

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
            PlayerData.S.造化丹药List.Add(qualityType);
            PlayerData.S.当前轮回造化丹药QualityType = qualityType;
            ObserverModuleManager.S.SendEvent("SendUIToast","服用丹药成功");
            PlayerData.S.Set丹药数量(丹药Type.加跟脚,qualityType,PlayerData.S.Get丹药数量(丹药Type.加跟脚,qualityType)-1);
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });
    }
}
