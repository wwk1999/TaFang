using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 当前供奉item : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI name;
    public Image 品质bg;
    public TextMeshProUGUI 品质name;
    public GameObject 数值Content;
    public GameObject 特性Content;
    public Button 删除按钮;

    [NonSerialized] public 供奉 供奉;
    
    public void SetItem()
    {
        icon.sprite = 供奉.供奉头像;
        name.text = 供奉.name;
        品质bg.sprite = ResourcesConfig.Get供奉品质标签(供奉.供奉品质Type);
        foreach (Transform item in 数值Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in 特性Content.transform)
        {
            Destroy(item.gameObject);
        }
        var 矿 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        矿.建筑Type = 建筑Type.矿场;
        矿.count = 供奉.矿;
        矿.SetItem();
        
        var 铁 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        铁.建筑Type = 建筑Type.玄铁洞;
        铁.count = 供奉.铁;
        铁.SetItem();
        
        var 玉 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        玉.建筑Type = 建筑Type.地脉;
        玉.count = 供奉.玉;
        玉.SetItem();
        
        var 德 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        德.建筑Type = 建筑Type.功德碑;
        德.count = 供奉.德;
        德.SetItem();
        
        var 贤 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        贤.建筑Type = 建筑Type.聚贤阁;
        贤.count = 供奉.贤;
        贤.SetItem();
        
        var 丹 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        丹.建筑Type = 建筑Type.炼丹室;
        丹.count = 供奉.丹;
        丹.SetItem();
        
        var 器 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        器.建筑Type = 建筑Type.炼器室;
        器.count = 供奉.器;
        器.SetItem();
        
        var 坊 = Instantiate(Resources.Load("Prefabs/Window/领主府/供奉数值item"), 数值Content.transform)
            .GetComponent<供奉数值item>();
        坊.建筑Type = 建筑Type.坊市;
        坊.count = 供奉.坊;
        坊.SetItem();

        if (供奉.特性list != null)
        {
            foreach (var item in 供奉.特性list)
            {
                var 特性 = Instantiate(Resources.Load("Prefabs/Window/领主府/特性item"), 特性Content.transform)
                    .GetComponent<特性item>();
                特性.供奉品质Type = item.供奉品质Type;
                特性.供奉特性Type = item.供奉特性Type;
                特性.SetItem();
            }
        }

        switch (供奉.供奉品质Type)
        {
            case 供奉品质Type.凡:
                品质name.text = "凡品";
                break;
            case 供奉品质Type.灵:
                品质name.text = "灵品";
                break;
            case 供奉品质Type.仙:
                品质name.text = "仙品";
                break;
            case 供奉品质Type.圣:
                品质name.text = "圣品";
                break;
            case 供奉品质Type.道:
                品质name.text = "道品";
                break;
        }
    }

    private void Start()
    {
        删除按钮.onClick.AddListener(() =>
        {
            if (PlayerData.S.供奉保留列表.Count >= 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉保留个数)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","可保留供奉数量已满");
                return;
            }
            PlayerData.S.供奉保留列表.Add(供奉);
            PlayerData.S.当前供奉列表.Remove(供奉);
            ObserverModuleManager.S.SendEvent("刷新领主府");
            ObserverModuleManager.S.SendEvent("SendUIToast","下场供奉成功,进入保留列表");
        });
    }
}
