using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 破限弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button 退出按钮;
    public Button 关闭Button;
    public TextMeshProUGUI 真灵总倍数;
    public GameObject 境界列表;
    public TextMeshProUGUI 当前破限次数;
    public TextMeshProUGUI 当前荒品突破次数;
    public TextMeshProUGUI 破限所需荒品次数;
    public TextMeshProUGUI 当前真灵倍数;
    public TextMeshProUGUI 破限后真灵倍数;
    public Button 破限按钮;
    public TextMeshProUGUI 破限灵魂;

    private void OnEnable()
    {
        HeroWindowController.S.破限弹窗境界 = JingJieType.练气;
        Show境界列表();
        Show破限信息();
    }

    public void 破限境界item点击(object[] obj)
    {
        Show破限信息();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("破限境界item点击",破限境界item点击);
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        关闭Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        退出按钮.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        破限按钮.onClick.AddListener(() =>
        {
            int 次数 = JingJieConfig.破限荒品次数列表[PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界]];
            float 灵魂 = JingJieConfig.Get破限灵魂(HeroWindowController.S.破限弹窗境界,
                PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界]);
            if (PlayerData.S.荒品突破次数[HeroWindowController.S.破限弹窗境界] < 次数)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","荒品突破次数不足");
                return;
            }

            if (PlayerData.S.PropListDic[PropType.灵魂] < 灵魂)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","灵魂不足");
                return;
            }

            PlayerData.S.PropListDic[PropType.灵魂] -= 灵魂;
            PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界]++;
            ObserverModuleManager.S.SendEvent("SendUIToast","破限成功");

        });
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("破限境界item点击",破限境界item点击);
    }

    public void Show境界列表()
    {
        真灵总倍数.text = JingJieConfig.Get总破限真灵倍数().ToString("F1") + "倍";
        foreach (Transform item in 境界列表.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i <= (int)JingJieType.混元圣人; i++)
        {
            var item=Instantiate(Resources.Load("Prefabs/Window/破限境界item"),境界列表.transform).GetComponent<破限境界item>();
            item.jingJieType = (JingJieType)i;
            item.SetItem();
        }
    }

    public void Show破限信息()
    {
        当前破限次数.text = PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界] + "次破限";
        当前荒品突破次数.text=PlayerData.S.荒品突破次数[HeroWindowController.S.破限弹窗境界] + "次";
        破限所需荒品次数.text = JingJieConfig.破限荒品次数列表[PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界]] + "次";
        当前真灵倍数.text = JingJieConfig.破限真灵倍数列表[PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界]].ToString("F1") + "倍";
        破限后真灵倍数.text=JingJieConfig.破限真灵倍数列表[PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界]+1].ToString("F1") + "倍";
        破限灵魂.text = PlayerData.S.格式化数字(JingJieConfig.Get破限灵魂(HeroWindowController.S.破限弹窗境界, PlayerData.S.破限次数[HeroWindowController.S.破限弹窗境界]));
    }
}
