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

            if (PlayerData.S.战斗选择丹药Dic[index].丹药Type != 丹药Type.None)
            {
                PlayerData.S.Set丹药数量(PlayerData.S.战斗选择丹药Dic[index].丹药Type,PlayerData.S.战斗选择丹药Dic[index].QualityType,PlayerData.S.Get丹药数量(PlayerData.S.战斗选择丹药Dic[index].丹药Type,PlayerData.S.战斗选择丹药Dic[index].QualityType)+1);
            }
            PlayerData.S.战斗选择丹药Dic[index].丹药Type = HeroWindowController.S.当前选择丹药Type;
            PlayerData.S.战斗选择丹药Dic[index].QualityType = HeroWindowController.S.当前选择丹药QualityType;
            PlayerData.S.Set丹药数量(HeroWindowController.S.当前选择丹药Type,HeroWindowController.S.当前选择丹药QualityType,PlayerData.S.Get丹药数量(HeroWindowController.S.当前选择丹药Type,HeroWindowController.S.当前选择丹药QualityType)-1);
            ObserverModuleManager.S.SendEvent("刷新战斗丹药");
            gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        HeroWindowController.S.当前选择丹药QualityType = QualityType.None;
        HeroWindowController.S.当前选择丹药Type=丹药Type.None;
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 8; i >= 1; i--)
        {
            foreach (var item in 丹药Config.丹药名Dic)
            {
                if(item.Key==丹药Type.None)continue;
                if (丹药Config.丹药类型Dic[item.Key] == 丹药类型.战斗丹药 && PlayerData.S.Get丹药数量(item.Key, (QualityType)i) > 0)
                {
                    var 丹药选择Item=Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹药选择Item"), content.transform)
                        .GetComponent<丹药选择Item>();
                    丹药选择Item.丹药Type = item.Key;
                    丹药选择Item.QualityType = (QualityType)i;
                    丹药选择Item.SetItem();
                }
            }
        }
    }
}
