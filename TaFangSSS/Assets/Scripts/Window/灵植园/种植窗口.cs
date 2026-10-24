using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 种植窗口 : MonoBehaviour
{
    public Button mask;
    public GameObject 背包;

    private void OnEnable()
    {
        HeroWindowController.S.当前选择灵植 = 灵植Type.None;
        HeroWindowController.设置光标(null);
        Show背包();
    }

    private void Start()
    {
        mask.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Show背包()
    {
        foreach (Transform item in 背包.transform)
        {
            Destroy(item.gameObject);
        }

        List<灵植Type> 种子列表 = new List<灵植Type>();
        foreach (var item in PlayerData.S.种子Dic)
        {
            if (item.Value > 0)
            {
                种子列表.Add(item.Key);
            }
        }

        // 品质从高到低（荒品→黄品）
        种子列表.Sort((a, b) => 灵植园Config.灵植品质Dic[b].CompareTo(灵植园Config.灵植品质Dic[a]));

        foreach (var 灵植 in 种子列表)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/种植item"), 背包.transform).GetComponent<种植item>();
            item.灵植Tyep = 灵植;
            item.SetItem();
        }
    }
}
