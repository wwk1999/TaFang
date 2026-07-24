using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 不周山当前收获弹窗 : MonoBehaviour
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

        foreach (var item in PlayerData.S.不周山寻宝Dic[HeroWindowController.S.当前不周山层数].list)
        {
            var 收获item = Instantiate(Resources.Load("Prefabs/Window/不周山当前收获item"), content.transform)
                .GetComponent<不周山当前收获item>();
            收获item.法则Type = item.法则Type;
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
            if (PlayerData.S.不周山寻宝Dic[HeroWindowController.S.当前不周山层数].寻宝 == false)
            {
                return;
            }
            foreach (var item in PlayerData.S.不周山寻宝Dic[HeroWindowController.S.当前不周山层数].list)
            {
                PlayerData.S.PropListDic[item.法则Type]+=item.count;
            }
            PlayerData.S.不周山寻宝Dic[HeroWindowController.S.当前不周山层数].list.Clear();
            PlayerData.S.不周山寻宝Dic[HeroWindowController.S.当前不周山层数].寻宝 = false;

            for (int i = 0; i < PlayerData.S.不周山英雄派遣Dic[HeroWindowController.S.当前不周山层数].Count; i++)
            {
                HeroType heroType = PlayerData.S.不周山英雄派遣Dic[HeroWindowController.S.当前不周山层数][i];
                PlayerData.S.HeroDataDic[heroType].派遣 = false;
                PlayerData.S.不周山英雄派遣Dic[HeroWindowController.S.当前不周山层数][i] = HeroType.None;
            }
            ObserverModuleManager.S.SendEvent("刷新不周山窗口");
            ObserverModuleManager.S.SendEvent("不周山英雄派遣Item刷新");
            gameObject.SetActive(false);
        });
    }
}
