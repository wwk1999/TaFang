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
            // 点击时二次校验，防止打开确认弹窗到点击确认之间功德被其他系统消耗
            if (PlayerData.S.PropListDic[PropType.功德] < need)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","功德不足");
                gameObject.SetActive(false);
                return;
            }
            PlayerData.S.PropListDic[PropType.功德] -= need;
            PlayerData.S.当前轮回突破Dic[PlayerData.S.当前轮回境界] = QualityType;
            PlayerData.S.Set灵物数量(PlayerData.S.当前轮回境界,QualityType,PlayerData.S.Get灵物数量(PlayerData.S.当前轮回境界,QualityType)-1);
            PlayerData.S.当前轮回境界++;
            if (PlayerData.S.当前轮回境界 > PlayerData.S.历史最高境界)
            {
                PlayerData.S.历史最高境界 = PlayerData.S.当前轮回境界;
                if (PlayerData.S.历史最高境界 == JingJieType.筑基)
                {
                    PlayerData.S.建筑等级Dic[建筑Type.领主府] = 1;
                    PlayerData.S.建筑等级Dic[建筑Type.聚贤阁] = 1;
                    ObserverModuleManager.S.SendEvent("SendUIToast","领主府已解锁");
                    ObserverModuleManager.S.SendEvent("SendUIToast","聚贤阁已解锁");
                }
                
                if (PlayerData.S.历史最高境界 == JingJieType.金丹)
                {
                    PlayerData.S.建筑等级Dic[建筑Type.领主府] = 1;
                    PlayerData.S.建筑等级Dic[建筑Type.聚贤阁] = 1;
                    PlayerData.S.建筑等级Dic[建筑Type.坊市] = 1;
                    ObserverModuleManager.S.SendEvent("SendUIToast","领主府已解锁");
                    ObserverModuleManager.S.SendEvent("SendUIToast","聚贤阁已解锁");
                    ObserverModuleManager.S.SendEvent("SendUIToast","坊市已解锁");
                }
                
                if (PlayerData.S.历史最高境界 == JingJieType.元婴)
                {
                    PlayerData.S.建筑等级Dic[建筑Type.炼丹室] = 1;
                    ObserverModuleManager.S.SendEvent("SendUIToast","炼丹室已解锁");
                }
                
                if (PlayerData.S.历史最高境界 == JingJieType.化神)
                {
                    PlayerData.S.建筑等级Dic[建筑Type.灵植园] = 1;
                    PlayerData.S.建筑等级Dic[建筑Type.仙女阁] = 1;
                    ObserverModuleManager.S.SendEvent("SendUIToast","灵植园已解锁");
                    ObserverModuleManager.S.SendEvent("SendUIToast","仙女阁已解锁");
                }
                
                if (PlayerData.S.历史最高境界 == JingJieType.合体)
                {
                    PlayerData.S.建筑等级Dic[建筑Type.灵兽坊] = 1;
                    ObserverModuleManager.S.SendEvent("SendUIToast","灵兽坊已解锁");
                }
            }
            PlayerData.S.Exp = 0;
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
            ObserverModuleManager.S.SendEvent("突破成功");
            ObserverModuleManager.S.SendEvent("SendUIToast","突破成功");
            ObserverModuleManager.S.SendEvent("Hide突破弹窗");
            gameObject.SetActive(false);
        });
    }
}
