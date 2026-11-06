using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 任务item : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Button bg;
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public GameObject 勾;
    public GameObject mask;
    [NonSerialized] public 任务Type 任务Type;
    public void SetItem()
    {
        任务类型 任务类型 = 任务Config.任务配置[任务Type].任务类型;
        string str = 任务类型 == 任务类型.主线任务 ? "主线" : "支线";
        name.text = str+任务Config.任务配置[任务Type].任务名;
        desc.text = 任务Config.任务配置[任务Type].任务目标;
        勾.SetActive(PlayerData.S.任务完成字典[任务Type]);
    }

    private void Start()
    {
        bg.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前显示任务Type = 任务Type;
            WindowController.S.打开窗口(WindowController.S.任务Window);
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mask.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mask.SetActive(false);
    }
}
