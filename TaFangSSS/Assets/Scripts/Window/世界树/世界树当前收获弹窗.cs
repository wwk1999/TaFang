using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 世界树当前收获弹窗 : MonoBehaviour
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

        foreach (var item in PlayerData.S.世界树寻宝Dic[HeroWindowController.S.当前世界树层数].list)
        {
            var 收获item = Instantiate(Resources.Load("Prefabs/Window/世界树当前收获item"), content.transform)
                .GetComponent<世界树当前收获item>();
            收获item.道宝Type = item.道宝Type;
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
            if (PlayerData.S.世界树寻宝Dic[HeroWindowController.S.当前世界树层数].寻宝 == false)
            {
                return;
            }
            foreach (var item in PlayerData.S.世界树寻宝Dic[HeroWindowController.S.当前世界树层数].list)
            {
                PlayerData.S.道宝LevelDic[item.道宝Type]+=item.count;
            }
            PlayerData.S.世界树寻宝Dic[HeroWindowController.S.当前世界树层数].list.Clear();
            PlayerData.S.世界树寻宝Dic[HeroWindowController.S.当前世界树层数].寻宝 = false;

            for (int i = 0; i < PlayerData.S.世界树英雄派遣Dic[HeroWindowController.S.当前世界树层数].Count; i++)
            {
                HeroType heroType = PlayerData.S.世界树英雄派遣Dic[HeroWindowController.S.当前世界树层数][i];
                PlayerData.S.HeroDataDic[heroType].派遣 = false;
                PlayerData.S.世界树英雄派遣Dic[HeroWindowController.S.当前世界树层数][i] = HeroType.None;
            }
            ObserverModuleManager.S.SendEvent("刷新世界树窗口");
            ObserverModuleManager.S.SendEvent("世界树英雄派遣Item刷新");

            gameObject.SetActive(false);
        });
    }
}
