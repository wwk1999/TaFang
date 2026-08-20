using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 血海当前收获弹窗 : MonoBehaviour
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

        foreach (var item in PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].list)
        {
            var 收获item = Instantiate(Resources.Load("Prefabs/Window/血海当前收获item"), content.transform)
                .GetComponent<血海当前收获item>();
            收获item.灵药Type= item.灵药.灵药Type;
            收获item.QualityType= item.灵药.QualityType;
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
            if (PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].寻宝 == false)
            {
                return;
            }
            foreach (var item in PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].list)
            {
                int count = PlayerData.S.Get灵药数量(item.灵药.灵药Type, item.灵药.QualityType);
                PlayerData.S.Set灵药数量(item.灵药.灵药Type,item.灵药.QualityType,count+item.count);
            }
            PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].list.Clear();
            PlayerData.S.血海寻宝Dic[HeroWindowController.S.当前血海层数].寻宝 = false;

            for (int i = 0; i < PlayerData.S.血海英雄派遣Dic[HeroWindowController.S.当前血海层数].Count; i++)
            {
                HeroType heroType = PlayerData.S.血海英雄派遣Dic[HeroWindowController.S.当前血海层数][i];
                PlayerData.S.HeroDataDic[heroType].派遣 = false;
                PlayerData.S.血海英雄派遣Dic[HeroWindowController.S.当前血海层数][i] = HeroType.None;
            }
            ObserverModuleManager.S.SendEvent("刷新血海窗口");
            ObserverModuleManager.S.SendEvent("血海英雄派遣Item刷新");

            gameObject.SetActive(false);
        });
    }
}
