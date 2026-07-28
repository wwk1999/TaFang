using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 城墙法宝详情弹窗 : MonoBehaviour
{
    public Button maskButton;
    public Button ExitButton;
    public Image 艺术字;
    public Image image;
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI 效果;
    public TextMeshProUGUI 升级奖励;
    public GameObject 升级信息Content;
    [NonSerialized] public 城墙道具Type 城墙道具Type;

    public void Show()
    {
        QualityType quality = 城墙Config.城墙道具QualityDic[城墙道具Type];
        艺术字.sprite=ResourcesConfig.Get艺术字(quality);
        升级奖励.text = "升级奖励：" + $"<color=green>{城墙Config.城墙道具升级奖励Dic[quality]}</color>" + "%最大生命值";
        image.sprite = ResourcesConfig.Get城墙Sprite(城墙道具Type);
        name.text = 城墙Config.城墙道具名Dic[城墙道具Type];
        desc.text=城墙Config.城墙道具介绍Dic[城墙道具Type];
        效果.text = 城墙Config.城墙道具属性Info[城墙Config.城墙道具属性Dic[城墙道具Type]];
        foreach (Transform item in 升级信息Content.transform)
        {
            Destroy(item.gameObject);
        }

        List<string> list = null;

        if (城墙Config.城墙道具QualityDic[城墙道具Type] >= QualityType.宙品)
        {
            list = 城墙Config.城墙道具属性升级Info[城墙Config.城墙道具属性Dic[城墙道具Type]];
        }else if (城墙Config.城墙道具QualityDic[城墙道具Type] == QualityType.宇品)
        {
            list = 城墙Config.橙色城墙道具升级Info;
        }
        else
        {
            list = 城墙Config.紫色城墙道具升级Info;
        }
        
        for (int i = 0; i <= 4; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/城墙道具升级信息item"), 升级信息Content.transform)
                .GetComponent<城墙道具升级信息item>();
            item.城墙道具Type = 城墙道具Type;
            item.解锁level = 城墙Config.城墙道具升级List[i];
            item.SetItem();
        }
    }

    private void OnEnable()
    {
        Show();
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
