using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 丹方item : MonoBehaviour
{
    public RectTransform trans;
    public TextMeshProUGUI name;
    public RectTransform 箭头;
    public 丹方下拉区域 丹方下拉区域;
    public Button 按钮;
    [NonSerialized] public 丹药Type 丹药Type;

    private bool 展开 = false;

    public void SetItem()
    {
        name.text = 丹药Config.丹药名Dic[丹药Type];
        箭头.localScale = new Vector3(1, -1, 1);
        丹方下拉区域.gameObject.SetActive(false);
        展开 = false;
        LayoutRebuilder.ForceRebuildLayoutImmediate(trans);
        Canvas.ForceUpdateCanvases();
    }

    public void 关闭下拉区域(object[] obj)
    {
        丹药Type Type = (丹药Type)obj[0];
        if (丹药Type != Type)
        {
            丹方下拉区域.gameObject.SetActive(false);
            箭头.localScale = new Vector3(1, -1, 1);
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("关闭下拉区域", 关闭下拉区域);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("关闭下拉区域", 关闭下拉区域);
        按钮.onClick.AddListener(() =>
        {
            if (!展开)
            {
                展开 = true;
                箭头.localScale = new Vector3(1, 1, 1);
                // [重构] 遍历1-16阶，找出已解锁的阶数
                List<int> 已解锁阶数list = new List<int>();
                for (int 阶数 = 1; 阶数 <= 16; 阶数++)
                {
                    if (PlayerData.S.Get丹方解锁(丹药Type, 阶数))
                        已解锁阶数list.Add(阶数);
                }
                if (已解锁阶数list.Count == 0) return;

                丹方下拉区域.丹药Type = 丹药Type;
                丹方下拉区域.已解锁阶数list = 已解锁阶数list;
                丹方下拉区域.gameObject.SetActive(true);
                LayoutRebuilder.ForceRebuildLayoutImmediate(trans);
                Canvas.ForceUpdateCanvases();
            }
            else
            {
                展开 = false;
                箭头.localScale = new Vector3(1, -1, 1);
                丹方下拉区域.gameObject.SetActive(false);
                LayoutRebuilder.ForceRebuildLayoutImmediate(trans);
                Canvas.ForceUpdateCanvases();
            }
            ObserverModuleManager.S.SendEvent("更新炼丹界面UI");
        });
    }
}
