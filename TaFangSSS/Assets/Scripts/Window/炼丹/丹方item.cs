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

    private bool 展开=false;
    public void SetItem()
    {
        name.text = 丹药Config.丹药名Dic[丹药Type];
        箭头.localScale = new Vector3(1, -1, 1);
        丹方下拉区域.gameObject.SetActive(false);
        展开=false;
        LayoutRebuilder.ForceRebuildLayoutImmediate(trans);
        Canvas.ForceUpdateCanvases();
    }

    public void 关闭下拉区域(object[] obj)
    {
        丹药Type Type=(丹药Type)obj[0];
        if (丹药Type != Type)
        {
            丹方下拉区域.gameObject.SetActive(false);
            箭头.localScale = new Vector3(1, -1, 1);
        }
        
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("关闭下拉区域",关闭下拉区域);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("关闭下拉区域",关闭下拉区域);
        按钮.onClick.AddListener(() =>
        {
            //ObserverModuleManager.S.SendEvent("关闭下拉区域",丹药Type);
            if (!展开)
            {
                展开 = !展开;
                箭头.localScale = new Vector3(1, 1, 1);
                List<丹药> list = new List<丹药>();
                for (int i = 1; i <= 8; i++)
                {
                    bool flag = PlayerData.S.Get丹方解锁(丹药Type, (QualityType)i);
                    if (flag)
                    {
                        list.Add(new 丹药(){丹药Type = 丹药Type,QualityType = (QualityType)i});
                    }
                }
                if(list.Count == 0)return;
                丹方下拉区域.list=list;
                丹方下拉区域.gameObject.SetActive(true);
                LayoutRebuilder.ForceRebuildLayoutImmediate(trans);
                Canvas.ForceUpdateCanvases();
            }
            else
            {
                展开 = !展开;
                箭头.localScale = new Vector3(1, -1, 1);
                丹方下拉区域.gameObject.SetActive(false);
                LayoutRebuilder.ForceRebuildLayoutImmediate(trans);
                Canvas.ForceUpdateCanvases();
            }
            ObserverModuleManager.S.SendEvent("更新炼丹界面UI");
        });
    }
}
