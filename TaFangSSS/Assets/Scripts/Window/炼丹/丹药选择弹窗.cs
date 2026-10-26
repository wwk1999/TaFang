using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 丹药选择弹窗 : MonoBehaviour
{
    public GameObject content;
    public Button 确认Button;
    public Button exitButton;
    public Button maskButton;
    [NonSerialized] public int index = 0;

    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        确认Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.当前选择丹药Type == 丹药Type.None)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择丹药");
                return;
            }

            // 卸下旧丹药：按原类型/品质/阶段还回背包
            if (PlayerData.S.战斗选择丹药Dic[index].丹药Type != 丹药Type.None)
            {
                var 旧 = PlayerData.S.战斗选择丹药Dic[index];
                PlayerData.S.Set丹药数量(旧.丹药Type,旧.QualityType,PlayerData.S.Get丹药数量(旧.丹药Type,旧.QualityType,旧.阶段)+1,旧.阶段);
            }
            PlayerData.S.战斗选择丹药Dic[index].丹药Type = HeroWindowController.S.当前选择丹药Type;
            PlayerData.S.战斗选择丹药Dic[index].QualityType = HeroWindowController.S.当前选择丹药QualityType;
            PlayerData.S.战斗选择丹药Dic[index].阶段 = HeroWindowController.S.当前选择丹药阶段;
            PlayerData.S.Set丹药数量(HeroWindowController.S.当前选择丹药Type,HeroWindowController.S.当前选择丹药QualityType,PlayerData.S.Get丹药数量(HeroWindowController.S.当前选择丹药Type,HeroWindowController.S.当前选择丹药QualityType,HeroWindowController.S.当前选择丹药阶段)-1,HeroWindowController.S.当前选择丹药阶段);
            ObserverModuleManager.S.SendEvent("刷新战斗丹药");
            gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        HeroWindowController.S.当前选择丹药QualityType = QualityType.None;
        HeroWindowController.S.当前选择丹药Type=丹药Type.None;
        HeroWindowController.S.当前选择丹药阶段 = 1;
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        // 各阶段独立成格：品质从高到低，同品质阶段从高到低
        for (int i = 8; i >= 1; i--)
        {
            foreach (var item in 丹药Config.丹药名Dic)
            {
                if(item.Key==丹药Type.None)continue;
                if (丹药Config.丹药类型Dic[item.Key] != 丹药类型.战斗丹药) continue;
                for (int 阶段 = PlayerData.Get丹药最高阶段((QualityType)i); 阶段 >= 1; 阶段--)
                {
                    if (PlayerData.S.Get丹药数量(item.Key, (QualityType)i, 阶段) > 0)
                    {
                        var 丹药选择Item=Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹药选择Item"), content.transform)
                            .GetComponent<丹药选择Item>();
                        丹药选择Item.丹药Type = item.Key;
                        丹药选择Item.QualityType = (QualityType)i;
                        丹药选择Item.阶段 = 阶段;
                        丹药选择Item.SetItem();
                    }
                }
            }
        }
    }
}
