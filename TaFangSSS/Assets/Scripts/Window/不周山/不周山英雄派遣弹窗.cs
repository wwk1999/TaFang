using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 不周山英雄派遣弹窗 : MonoBehaviour
{
    public Button exitbutton;
    public Button 派遣Button;
    public GameObject list;
    public Button maskButton;

    private void Awake()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        exitbutton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        派遣Button.onClick.AddListener(() =>
        {
            if (HeroWindowController.S.不周山当前选择派遣HeroType == HeroType.None)
            {
                return;
            }
            HeroType 之前HeroType =
                PlayerData.S.不周山英雄派遣Dic[HeroWindowController.S.当前不周山层数][HeroWindowController.S.不周山英雄派遣Index];
            if (之前HeroType != HeroType.None)
            {
                PlayerData.S.HeroDataDic[之前HeroType].派遣 = false;
            }
            PlayerData.S.HeroDataDic[HeroWindowController.S.不周山当前选择派遣HeroType].派遣 = true;
            PlayerData.S.不周山英雄派遣Dic[HeroWindowController.S.当前不周山层数][HeroWindowController.S.不周山英雄派遣Index] =
                HeroWindowController.S.不周山当前选择派遣HeroType;
            ObserverModuleManager.S.SendEvent("刷新不周山窗口");
            gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        HeroWindowController.S.不周山当前选择派遣HeroType=HeroType.None;
        ShowList();
    }

    public void ShowList()
    {
        foreach (Transform item in list.transform)
        {
            Destroy(item.gameObject);
        }

        var 要求 = 不周山Config.不周山关卡Dic[HeroWindowController.S.当前不周山层数];
        foreach (var item in PlayerData.S.HeroDataDic)
        {
            if (item.Value.Level > 0)
            {
                var 派遣item = Instantiate(Resources.Load("Prefabs/Window/不周山英雄派遣弹窗item"), list.transform)
                    .GetComponent<不周山英雄派遣弹窗item>();
                派遣item.需要品质 = 要求.需要英雄品质;
                派遣item.需要星级 = 要求.需要英雄星级;
                派遣item.需要职业 = 要求.需要英雄职业;
                派遣item.需要元素 = 要求.需要英雄元素;
                派遣item.HeroType = item.Key;
                派遣item.SetItem();
            }
        }
        
        
    }
}
