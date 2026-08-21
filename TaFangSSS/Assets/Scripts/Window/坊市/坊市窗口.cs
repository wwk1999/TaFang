using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 坊市窗口 : MonoBehaviour
{
    public GameObject content;
    public TextMeshProUGUI 刷新次数;
    public TextMeshProUGUI 剩余时间;
    public Button 刷新按钮;
    public Button exitButton;

    private void OnEnable()
    {
        Show();
    }

    private void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Show()
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < 12; i++)
        {
            var 坊市item = Instantiate(Resources.Load("Prefabs/Window/坊市/坊市item"), content.transform)
                .GetComponent<坊市item>();
            var item = 坊市Config.Get坊市物品();
            坊市item.QualityType = item.QualityType;
            坊市item.法器Type=item.法器Type;
            坊市item.仙石Type=item.仙石Type;
            坊市item.丹药Type=item.丹药Type;
            坊市item.丹方Type=item.丹方Type;
            坊市item.SetItem();
        }
    }
}
