using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 悟道崖界面 : MonoBehaviour
{
    public Button 总加成Button;

    public Button exitButton;
    public TextMeshProUGUI 修炼速度;
    public Image 当前参悟Bg;
    public Image 当前参悟icon;
    public TextMeshProUGUI 当前参悟名;
    public TextMeshProUGUI 当前参悟等级;
    public TextMeshProUGUI 当前参悟当前值;
    public TextMeshProUGUI 当前参悟最大值;
    public Image 当前参悟进度条;
    public TextMeshProUGUI 介绍;
    public GameObject 当前参悟;
    
    public GameObject 悟道区域;
    public GameObject 果位列表;

    public void 大道item点击(object[] obj)
    {
        Show();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新悟道崖界面",大道item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新悟道崖界面",大道item点击);
        exitButton.onClick.AddListener(() =>
            {
                gameObject.SetActive(false);
            }
        );
    }

    public void Show当前参悟区域()
    {
        修炼速度.text = "修炼速度："+PlayerData.S.格式化数字(JingJieConfig.每秒增加修为 * 属性config.每年秒数) + "/每道年";
        if (PlayerData.S.当前前置参悟大道Type == 大道Type.None)
        {
            当前参悟.gameObject.SetActive(false);
        }
        else
        {
            当前参悟.gameObject.SetActive(true);
            switch (悟道崖Config.大道配置[PlayerData.S.当前前置参悟大道Type].大道等级Type)
            {
                case 大道等级Type.基础大道:
                    当前参悟Bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.地品);
                    break;
                case 大道等级Type.上等大道:
                    当前参悟Bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.宇品);
                    break;
                case 大道等级Type.至尊大道:
                    当前参悟Bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.洪品);
                    break;
                case 大道等级Type.本源大道:
                    当前参悟Bg.sprite = ResourcesConfig.Get灵植背包格子(QualityType.荒品);
                    break;
            }

            当前参悟icon.sprite = ResourcesConfig.Get大道Icon(PlayerData.S.当前前置参悟大道Type);
            当前参悟名.text = 悟道崖Config.大道配置[PlayerData.S.当前前置参悟大道Type].name;
            当前参悟等级.text = "LV." + PlayerData.S.大道配置[PlayerData.S.当前前置参悟大道Type].等级;
            float 当前值 = PlayerData.S.大道配置[PlayerData.S.当前前置参悟大道Type].经验;
            float 最大值 = 悟道崖Config.大道经验[悟道崖Config.大道配置[PlayerData.S.当前前置参悟大道Type].大道等级Type];
            当前参悟当前值.text=PlayerData.S.格式化数字(当前值);
            当前参悟最大值.text=PlayerData.S.格式化数字(最大值);
            当前参悟进度条.fillAmount = 当前值 / 最大值;
            介绍.text = 悟道崖Config.大道配置[PlayerData.S.当前前置参悟大道Type].介绍;
        }
    }
    
    public void Show当前悟道区域()
    {
        foreach (Transform item in 悟道区域.transform)
        {
            Destroy(item.gameObject);
        }

        var 基础大道 = Instantiate(Resources.Load("Prefabs/Window/悟道崖/大道类型item"), 悟道区域.transform).GetComponent<大道类型item>();
        基础大道.大道等级Type = 大道等级Type.基础大道;
        基础大道.SetItem();
        
        var 上等大道 = Instantiate(Resources.Load("Prefabs/Window/悟道崖/大道类型item"), 悟道区域.transform).GetComponent<大道类型item>();
        上等大道.大道等级Type = 大道等级Type.上等大道;
        上等大道.SetItem();
        
        var 至尊大道 = Instantiate(Resources.Load("Prefabs/Window/悟道崖/大道类型item"), 悟道区域.transform).GetComponent<大道类型item>();
        至尊大道.大道等级Type = 大道等级Type.至尊大道;
        至尊大道.SetItem();
        
        var 本源大道 = Instantiate(Resources.Load("Prefabs/Window/悟道崖/大道类型item"), 悟道区域.transform).GetComponent<大道类型item>();
        本源大道.大道等级Type = 大道等级Type.本源大道;
        本源大道.SetItem();
    }
    
    public void Show果位列表()
    {
        foreach (Transform item in 果位列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in 悟道崖Config.大道配置)
        {
            if (PlayerData.S.大道配置[item.Key].等级 < 100) continue;
            var 果位item = Instantiate(Resources.Load("Prefabs/Window/悟道崖/果位item"), 果位列表.transform)
                .GetComponent<果位Item>();
            果位item.大道Type = item.Key;
            果位item.SetItem(item.Key);
        }
    }

    public void Show()
    {
        Show当前参悟区域();
        Show果位列表();
    }

    private void OnEnable()
    {
        Show当前悟道区域();
        Show();
    }
}
