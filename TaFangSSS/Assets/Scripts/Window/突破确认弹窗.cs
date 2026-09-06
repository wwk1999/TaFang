using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 突破确认弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 取消Button;
    public Button 确认Button;
    public TextMeshProUGUI text;
    [NonSerialized] public QualityType QualityType;


    private void OnEnable()
    {
        text.text = "是否以" + PropConfig.QualityNameDic[QualityType] + "突破,突破后跟脚X" + JingJieConfig.突破跟脚Dic[QualityType];
    }

    private void Awake()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        取消Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            long need = JingJieConfig.突破材料Dic[PlayerData.S.当前轮回境界][(int)(QualityType-1)];
            PlayerData.S.PropListDic[PropType.功德] -= need;
            PlayerData.S.当前轮回突破Dic[PlayerData.S.当前轮回境界] = QualityType;
            PlayerData.S.当前轮回境界++;
            if (PlayerData.S.当前轮回境界 > PlayerData.S.历史最高境界)
            {
                PlayerData.S.历史最高境界 = PlayerData.S.当前轮回境界;
            }
            PlayerData.S.Set灵物数量(PlayerData.S.当前轮回境界,QualityType,PlayerData.S.Get灵物数量(PlayerData.S.当前轮回境界,QualityType)-1);
            PlayerData.S.Exp = 0;
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
            ObserverModuleManager.S.SendEvent("突破成功");
            ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
            ObserverModuleManager.S.SendEvent("Hide突破弹窗");
            gameObject.SetActive(false);
        });
    }
}
