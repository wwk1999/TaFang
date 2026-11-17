using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 阶数Item : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;
    [NonSerialized] public int 阶数;

    public void SetItem()
    {
        text.text = 阶数 == 0 ? "所有" : PlayerData.S.Get阶数string(阶数);
    }

    private void Start()
    {
        btn.onClick.AddListener(() => ObserverModuleManager.S.SendEvent("矿工背包阶数筛选", 阶数));
    }
}
