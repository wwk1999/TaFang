using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 灵植商店窗口 : MonoBehaviour
{
    public Button maskButton;
    public Button 种子Button;
    public Button 肥料Button;
    public GameObject 商店;
    public Button 左Button;
    public Button 右Button;
    public TextMeshProUGUI text;
    private bool 是否在种子 = true;
    private int 页数=1;

    private void OnEnable()
    {
        页数 = 1;
        是否在种子 = true;
        Show();
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        左Button.onClick.AddListener(() =>
        {
            if (页数 > 1)
            {
                页数--;
                Show();
            }
        });
        右Button.onClick.AddListener(() =>
        {
            if (页数 < 2)
            {
                页数++;
                Show();
            }
        });
    }

    public void Show()
    {
        text.text = 页数.ToString();
        if (是否在种子)
        {
            Show种子();
        }
        else
        {
            Show肥料();
        }
    }

    public void Set按钮()
    {
        if (是否在种子)
        {
            种子Button.image.sprite = ResourcesConfig.红按钮;
            肥料Button.image.sprite = ResourcesConfig.黑按钮;
        }
        else
        {
            种子Button.image.sprite = ResourcesConfig.黑按钮;
            肥料Button.image.sprite = ResourcesConfig.红按钮;
        }
    }

    public void Show肥料()
    {
        foreach (Transform item in 商店.transform)
        {
            Destroy(item.gameObject);
        }

        if (页数 == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.黄品;
                item.SetItem();
            }
            
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.玄品;
                item.SetItem();
            }
            
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.地品;
                item.SetItem();
            }
            
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.天品;
                item.SetItem();
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.宇品;
                item.SetItem();
            }
            
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.宙品;
                item.SetItem();
            }
            
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.洪品;
                item.SetItem();
            }
            
            for (int i = 0; i < 4; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.肥料Type = (肥料Type)(i + 1);
                item.quality = QualityType.荒品;
                item.SetItem();
            }
        }
    }
    public void Show种子()
    {
        foreach (Transform item in 商店.transform)
        {
            Destroy(item.gameObject);
        }

        if (页数 == 1)
        {
            for (int i = 0; i < 16; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.灵植Type = (灵植Type)(i + 1);
                item.quality = 灵植园Config.灵植品质Dic[(灵植Type)(i + 1)];
                item.SetItem();
            }
        }
        else
        {
            for (int i = 16; i < 32; i++)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/灵植园/灵植商店item"), 商店.transform)
                    .GetComponent<灵植商店item>();
                item.灵植Type = (灵植Type)(i + 1);
                item.quality = 灵植园Config.灵植品质Dic[(灵植Type)(i + 1)];
                item.SetItem();
            }
        }
    }
}
