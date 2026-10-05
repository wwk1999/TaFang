using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 坊市窗口 : MonoBehaviour
{
    public GameObject content;
    public TextMeshProUGUI 刷新次数;
    public TextMeshProUGUI 剩余时间;
    public Button 刷新按钮;
    public Button exitButton;
    public Button 左Button;
    public Button 右Button;
    public TextMeshProUGUI num;

    public Button 自动购买Button;
    public GameObject 自动购买弹窗;

    private void OnEnable()
    {
        Show();
    }

    public void 刷新剩余时间(object[] obj)
    {
        刷新次数.text=PlayerData.S.坊市刷新次数.ToString();
        剩余时间.text = (属性config.每年秒数 - PlayerData.S.道龄S).ToString("F0")+"S";
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新坊市窗口",刷新坊市窗口);
        ObserverModuleManager.S.UnRegisterEvent("刷新坊市剩余时间",刷新剩余时间);
    }

    public void 刷新坊市窗口(object[] obj)
    {
        Show();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新坊市窗口",刷新坊市窗口);
        ObserverModuleManager.S.RegisterEvent("刷新坊市剩余时间",刷新剩余时间);
        
        自动购买Button.onClick.AddListener(() =>
        {
            自动购买弹窗.gameObject.SetActive(true);
        });
        左Button.onClick.AddListener(() =>
        {
            if (PlayerData.S.坊市等级 > 1)
            {
                PlayerData.S.坊市等级--;
                num.text = PlayerData.S.坊市等级.ToString();
            }
        });
        右Button.onClick.AddListener(() =>
        {
            if (PlayerData.S.坊市等级 < PlayerData.S.建筑等级Dic[建筑Type.坊市])
            {
                PlayerData.S.坊市等级++;
                num.text = PlayerData.S.坊市等级.ToString();
            }
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        刷新按钮.onClick.AddListener(() =>
        {
            if (PlayerData.S.坊市刷新次数 <= 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","坊市刷新次数不足");
                return;
            }
            坊市Config.刷新坊市列表();
            float 坊市刷新不消耗次数random=Random.Range(0, 100f);
            if (坊市刷新不消耗次数random >= 道场Config.供奉总属性.坊市刷新概率不消耗次数)
            {
              PlayerData.S.坊市刷新次数--;  
            }
            Show();
        });
    }

    public void Show()
    {
        num.text = PlayerData.S.坊市等级.ToString();
        刷新次数.text=PlayerData.S.坊市刷新次数.ToString();
        剩余时间.text = (属性config.每年秒数 - PlayerData.S.道龄S).ToString("F0")+"S";
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        if (PlayerData.S.坊市物品列表.Count == 0)
        {
            坊市Config.刷新坊市列表();
        }

        int index = 0;
        foreach (var item in PlayerData.S.坊市物品列表)
        {
            var 坊市item = Instantiate(Resources.Load("Prefabs/Window/坊市/坊市item"), content.transform)
                .GetComponent<坊市item>();
            坊市item.QualityType = item.QualityType;
            坊市item.法器Type=item.法器Type;
            坊市item.仙石Type=item.仙石Type;
            坊市item.丹药Type=item.丹药Type;
            坊市item.丹方Type=item.丹方Type;
            坊市item.是否被购买=item.是否被购买;
            坊市item.index = index;
            index++;
            坊市item.SetItem();
        }
    }
}
