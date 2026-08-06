using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 胜利弹窗 : MonoBehaviour
{
    public GameObject Content;
    public Button AgainButtn;
    public Button ExitButtn;
    public TextMeshProUGUI 战斗Text;

    private float 重复挑战Time = 0;
    public void 清空怪物()
    {
        foreach (var item in QueueController.S.MonsterColliderDic)
        {
            item.Value.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        ExitButtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("UIScene");
        });
        AgainButtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LoadScene");
        });
    }

    private void Update()
    {
        if (PlayerData.S.重复挑战)
        {
            重复挑战Time += Time.unscaledDeltaTime;
            战斗Text.text = "重复挑战:"+(int)(5f-重复挑战Time);
            if (5f - 重复挑战Time < 0)
            {
                SceneManager.LoadScene("LoadScene");
            }
        }
    }

    private void OnEnable()
    {
        ObserverModuleManager.S.SendEvent("停止元始音效");
        重复挑战Time = 0;
        if (PlayerData.S.重复挑战 == false)
        {
            战斗Text.text = "再战一次";
        }
        普通关卡胜利奖励 value = LevelConfig.Get胜利奖励();
        PlayerData.S.PropListDic[PropType.灵魂] += value.灵魂;
        PlayerData.S.PropListDic[PropType.功德] += value.功德;
        PlayerData.S.PropListDic[PropType.洗练石] += value.洗练石;
        PlayerData.S.PropListDic[PropType.高级招募卷] += value.高级招募卷;
        PlayerData.S.PropListDic[PropType.射手经验值] += value.射手经验值;
        PlayerData.S.PropListDic[PropType.战士经验值] += value.战士经验值;
        PlayerData.S.PropListDic[PropType.辅助经验值] += value.辅助经验值;
        PlayerData.S.PropListDic[PropType.法师经验值] += value.法师经验值;
        PlayerData.S.PropListDic[PropType.控制经验值] += value.控制经验值;
        PlayerData.S.PropListDic[PropType.衣服锻造石] += value.衣服锻造石;
        PlayerData.S.PropListDic[PropType.头盔锻造石] += value.头盔锻造石;
        PlayerData.S.PropListDic[PropType.护手锻造石] += value.护手锻造石;
        PlayerData.S.PropListDic[PropType.鞋子锻造石] += value.鞋子锻造石;
        PlayerData.S.PropListDic[PropType.项链锻造石] += value.项链锻造石;
        PlayerData.S.PropListDic[PropType.戒指锻造石] += value.戒指锻造石;
        PlayerData.S.PropListDic[PropType.招募卷] += value.招募卷;

        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }
        if (value.高级招募卷 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.高级招募卷;
            item.count = value.高级招募卷;
            item.SetItem();
        }

        if (value.灵魂 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = value.灵魂;
            item.SetItem();
        }
        if (value.功德 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.功德;
            item.count = value.功德;
            item.SetItem();
        }
        if (value.战士经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.战士经验值;
            item.count = value.战士经验值;
            item.SetItem();
        }
        if (value.射手经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.射手经验值;
            item.count = value.射手经验值;
            item.SetItem();
        }
        if (value.法师经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.法师经验值;
            item.count = value.法师经验值;
            item.SetItem();
        }
        if (value.控制经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.控制经验值;
            item.count = value.控制经验值;
            item.SetItem();
        }
        if (value.辅助经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.辅助经验值;
            item.count = value.辅助经验值;
            item.SetItem();
        }
        if (value.衣服锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.衣服锻造石;
            item.count = value.衣服锻造石;
            item.SetItem();
        }
        if (value.头盔锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.头盔锻造石;
            item.count = value.头盔锻造石;
            item.SetItem();
        }
        if (value.护手锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.护手锻造石;
            item.count = value.护手锻造石;
            item.SetItem();
        }
        if (value.鞋子锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.鞋子锻造石;
            item.count = value.鞋子锻造石;
            item.SetItem();
        }
        if (value.戒指锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.戒指锻造石;
            item.count = value.戒指锻造石;
            item.SetItem();
        }
        if (value.项链锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.项链锻造石;
            item.count = value.项链锻造石;
            item.SetItem();
        }
        if (value.招募卷 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.招募卷;
            item.count = value.招募卷;
            item.SetItem();
        }
        if (value.洗练石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.洗练石;
            item.count = value.洗练石;
            item.SetItem();
        }
    }
}
