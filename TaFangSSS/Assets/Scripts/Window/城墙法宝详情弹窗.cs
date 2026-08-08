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
    public RectTransform bgTrans;
    public Button maskButton;
    public Button ExitButton;
    public Image 艺术字;
    public Image image;
    public TextMeshProUGUI name;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI 效果info;
    public TextMeshProUGUI 效果无;
    public GameObject 效果tip;
    public TextMeshProUGUI 升级奖励;
    public GameObject 升级信息Content;
    public GameObject 升级信息;
    [NonSerialized] public 城墙道具Type 城墙道具Type;

    public void Show()
    {
        QualityType quality = 城墙Config.城墙道具QualityDic[城墙道具Type];
        艺术字.sprite=ResourcesConfig.Get艺术字(quality);
        升级奖励.text = "升级奖励：" + $"<color=green>{城墙Config.城墙道具升级奖励Dic[quality]}</color>" + "%最大生命值";
        image.sprite = ResourcesConfig.Get城墙Sprite(城墙道具Type);
        name.text = 城墙Config.城墙道具名Dic[城墙道具Type];
        desc.text=城墙Config.城墙道具介绍Dic[城墙道具Type];
        if (quality >= QualityType.宙品)
        {
            效果info.gameObject.SetActive(true);
            效果info.text = 城墙Config.城墙道具属性Info[城墙Config.城墙道具属性Dic[城墙道具Type]];
            效果tip.gameObject.SetActive(true);
            效果无.gameObject.SetActive(false);
            升级信息.gameObject.SetActive(true);
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
            bgTrans.localPosition = new Vector3(0, 0, 0);
            bgTrans.sizeDelta = new Vector2(523, 840);
        }
        else
        {
            效果info.gameObject.SetActive(false);
            效果tip.gameObject.SetActive(false);
            效果无.gameObject.SetActive(true);
            升级信息.gameObject.SetActive(false);
            bgTrans.localPosition = new Vector3(0, 0, 0);
            bgTrans.sizeDelta = new Vector2(523, 420);
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
