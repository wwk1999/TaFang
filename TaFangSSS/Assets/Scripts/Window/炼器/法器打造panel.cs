using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 法器打造panel : MonoBehaviour
{
    public Button 武器Button;
    public Button 衣服Button;
    public Button 鞋子Button;
    public Button 头盔Button;
    public GameObject 背包;
    

    public Image icon;
    public Image 艺术字;
    public TextMeshProUGUI Name;
    public Slider 数量进度条;
    public TextMeshProUGUI Count;
    public GameObject 打造区域;
    public Button 打造Button;
    public GameObject 材料区域;
    public Image 材料1bg;
    public Image 材料1icon;
    public Image 材料2bg;
    public Image 材料2icon;

    private int 打造数量 = 0;
    public void Show左Panel()
    {
        Set法器类型Button();
        foreach (Transform item in 背包.transform)
        {
            Destroy(item.gameObject);
        }
        QualityType 最高品级 = 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].最高炼制QualityType;
        for (int i = (int)最高品级; i >=(int)QualityType.黄品; i--)
        {
            var list = 法器Config.法器品质列表Dic[(QualityType)i];
            foreach (var item in list)
            {
                if (法器Config.法器类型Dic[item] == HeroWindowController.S.法器打造法器类型)
                {
                    var 法器打造item = Instantiate(Resources.Load("Prefabs/Window/炼器/法器打造item"),背包.transform).GetComponent<法器打造item>();
                    法器打造item.法器Type = item;
                    法器打造item.SetItem();
                }
            }
        }
    }

    public void Show打造区域()
    {
        foreach (Transform item in 打造区域.transform)
        {
            Destroy(item.gameObject);
        }

        int index = 0;
        foreach (var item in PlayerData.S.打造List)
        {
            var 打造item = Instantiate(Resources.Load("Prefabs/Window/炼器/打造item"), 打造区域.transform).GetComponent<打造item>();
            打造item.法器Type = item.法器Type;
            打造item.count = item.count;
            打造item.进度 = item.进度;
            打造item.index = index;
            打造item.SetItem();
            index++;
        }
    }
    public void Show右panel()
    {
        if (HeroWindowController.S.法器打造法器Type == 法器Type.None)
        {
            数量进度条.gameObject.SetActive(false);
            艺术字.gameObject.SetActive(false);
            icon.gameObject.SetActive(false);
            Name.gameObject.SetActive(false);
            Count.gameObject.SetActive(false);
            材料区域.gameObject.SetActive(false);
            return;
        }
        材料区域.gameObject.SetActive(true);
        Count.gameObject.SetActive(true);
        数量进度条.gameObject.SetActive(true);
        艺术字.gameObject.SetActive(true);
        icon.gameObject.SetActive(true);
        Name.gameObject.SetActive(true);
        var list = 法器Config.Get打造法器材料(HeroWindowController.S.法器打造法器Type);
        材料1bg.sprite = ResourcesConfig.Get道具背景框Sprite(list[0]);
        材料2bg.sprite = ResourcesConfig.Get道具背景框Sprite(list[1]);
        材料1icon.sprite = ResourcesConfig.GetPropSprite(list[0]);
        材料2icon.sprite = ResourcesConfig.GetPropSprite(list[1]);
        icon.sprite = ResourcesConfig.Get法器Sprite(HeroWindowController.S.法器打造法器Type);
        艺术字.sprite = ResourcesConfig.Get艺术字(法器Config.法器品质Dic[HeroWindowController.S.法器打造法器Type]);
        Name.text = 法器Config.法器名Dic[HeroWindowController.S.法器打造法器Type];
        数量进度条.value = 0;
        Count.text = "0";
       
        Show打造区域();
    }

    public void Show法器打造Panel()
    {
        Show左Panel();
        Show右panel();
    }

    public void Set法器类型Button()
    {
        switch (HeroWindowController.S.法器打造法器类型)
        {
            case 法器类型.武器:
                武器Button.image.sprite = ResourcesConfig.标签亮;
                头盔Button.image.sprite = ResourcesConfig.标签暗;
                衣服Button.image.sprite = ResourcesConfig.标签暗;
                鞋子Button.image.sprite = ResourcesConfig.标签暗;
                break;
            case 法器类型.头盔:
                武器Button.image.sprite = ResourcesConfig.标签暗;
                头盔Button.image.sprite = ResourcesConfig.标签亮;
                衣服Button.image.sprite = ResourcesConfig.标签暗;
                鞋子Button.image.sprite = ResourcesConfig.标签暗;
                break;
            case 法器类型.衣服:
                武器Button.image.sprite = ResourcesConfig.标签暗;
                头盔Button.image.sprite = ResourcesConfig.标签暗;
                衣服Button.image.sprite = ResourcesConfig.标签亮;
                鞋子Button.image.sprite = ResourcesConfig.标签暗;
                break;
            case 法器类型.鞋子:
                武器Button.image.sprite = ResourcesConfig.标签暗;
                头盔Button.image.sprite = ResourcesConfig.标签暗;
                衣服Button.image.sprite = ResourcesConfig.标签暗;
                鞋子Button.image.sprite = ResourcesConfig.标签亮;
                break;
        }
    }

    public void 刷新法器打造Panel(object[] obj)
    {
        数量进度条.maxValue = Get最大打造数量();
        数量进度条.value = 0;
        Show法器打造Panel();
    }

    public void 数量进度条监听(float value)
    {
        int newCount=(int)value;
        数量进度条.value=newCount;
        Count.text=newCount.ToString();
        打造数量=newCount;
    }
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新法器打造区域",刷新法器打造区域);
        ObserverModuleManager.S.UnRegisterEvent("刷新法器打造Panel",刷新法器打造Panel);
    }

    private void OnEnable()
    {
        HeroWindowController.S.法器打造法器类型 = 法器类型.武器;
        HeroWindowController.S.法器打造法器Type = 法器Type.None;
        Show法器打造Panel();
    }

    public int Get最大打造数量()
    {
        // 未选中具体法器时打造数量为0
        if (HeroWindowController.S.法器打造法器Type == 法器Type.None) return 0;

        // 每件法器需要每种材料各1个，最大打造数取所有材料持有量的最小值
        int 最大数量 = int.MaxValue;
        foreach (var propType in 法器Config.Get打造法器材料(HeroWindowController.S.法器打造法器Type))
        {
            PlayerData.S.PropListDic.TryGetValue(propType, out float count);
            最大数量 = Math.Min(最大数量, Mathf.FloorToInt(count));
        }

        return 最大数量 == int.MaxValue ? 0 : 最大数量;
    }

    public void 刷新法器打造区域(object[] obj)
    {
        Show打造区域();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新法器打造区域",刷新法器打造区域);
        ObserverModuleManager.S.RegisterEvent("刷新法器打造Panel",刷新法器打造Panel);
        武器Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.法器打造法器类型 = 法器类型.武器;
            HeroWindowController.S.法器打造法器Type = 法器Type.None;
            Show法器打造Panel();
        });
        头盔Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.法器打造法器类型 = 法器类型.头盔;
            HeroWindowController.S.法器打造法器Type = 法器Type.None;
            Show法器打造Panel();
        });
        衣服Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.法器打造法器类型 = 法器类型.衣服;
            HeroWindowController.S.法器打造法器Type = 法器Type.None;
            Show法器打造Panel();
        });
        鞋子Button.onClick.AddListener(() =>
        {
            HeroWindowController.S.法器打造法器类型 = 法器类型.鞋子;
            HeroWindowController.S.法器打造法器Type = 法器Type.None;
            Show法器打造Panel();
        });
        数量进度条.onValueChanged.AddListener(数量进度条监听);
        打造Button.onClick.AddListener(() =>
        {
            if (打造数量 == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","请选择打造数量");
                return;
            }
            数量进度条.maxValue = Get最大打造数量();
            法器打造Item 法器打造Item = new 法器打造Item();
            法器打造Item.count = 打造数量;
            法器打造Item.进度 = 0;
            法器打造Item.法器Type = HeroWindowController.S.法器打造法器Type;
            数量进度条.value = 0;
            打造数量 = 0;
            PlayerData.S.打造List.Add(法器打造Item);
        });
    }
}
