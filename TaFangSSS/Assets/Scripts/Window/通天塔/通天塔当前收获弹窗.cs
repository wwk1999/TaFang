using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 通天塔当前收获弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button exitButton;
    public Button 结束寻宝Button;
    public GameObject content;

    public void Show列表()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.通天塔寻宝Dic[HeroWindowController.S.当前通天塔层数].list)
        {
            var 收获item = Instantiate(Resources.Load("Prefabs/Window/通天塔当前收获item"), content.transform)
                .GetComponent<通天塔当前收获item>();
            收获item.城墙道具Type = item.城墙道具Type;
            收获item.count=item.count;
            收获item.SetItem();
        }
    }

    private void OnEnable()
    {
        Show列表();
    }

    private void Awake()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        结束寻宝Button.onClick.AddListener(() =>
        {
            if (PlayerData.S.通天塔寻宝Dic[HeroWindowController.S.当前通天塔层数].寻宝 == false)
            {
                return;
            }
            foreach (var item in PlayerData.S.通天塔寻宝Dic[HeroWindowController.S.当前通天塔层数].list)
            {
                PlayerData.S.城墙道具等级Dic[item.城墙道具Type]+=item.count;
            }
            PlayerData.S.通天塔寻宝Dic[HeroWindowController.S.当前通天塔层数].list.Clear();
            PlayerData.S.通天塔寻宝Dic[HeroWindowController.S.当前通天塔层数].寻宝 = false;

            for (int i = 0; i < PlayerData.S.通天塔英雄派遣Dic[HeroWindowController.S.当前通天塔层数].Count; i++)
            {
                HeroType heroType = PlayerData.S.通天塔英雄派遣Dic[HeroWindowController.S.当前通天塔层数][i];
                PlayerData.S.HeroDataDic[heroType].派遣 = false;
                PlayerData.S.通天塔英雄派遣Dic[HeroWindowController.S.当前通天塔层数][i] = HeroType.None;
            }
            ObserverModuleManager.S.SendEvent("刷新通天塔窗口");
            gameObject.SetActive(false);
        });
    }
}
