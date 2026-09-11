using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 技能树item : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image bg;
    public Button image;
    public TextMeshProUGUI 当前等级;
    public TextMeshProUGUI 最大等级;
    public Image 选中框;
    public GameObject content;

    [NonSerialized] public HeroType HeroType;
    [NonSerialized] public int 行;
    [NonSerialized] public int 列;

    private void Start()
    {
        image.onClick.AddListener(() =>
        {
            bool 是否激活;
            int 需要等级 = (列-1) * 5;
            bool 需要前置 = 英雄技能树Config.英雄技能树Dic[HeroType][行 - 1][列 - 1].是否有前置;
            if ((需要前置 && 列 > 1 && PlayerData.S.英雄技能树Dic[HeroType][行 - 1][列 - 2] == 0) ||
                PlayerData.S.HeroDataDic[HeroType].境界 < 需要等级)
            {
                是否激活=false;
            }
            else
            {
                是否激活=true;
            }

            if (!是否激活) return;
            if (PlayerData.S.英雄技能树Dic[HeroType][行 - 1][列 - 1] >= 英雄技能树Config.英雄技能树Dic[HeroType][行 - 1][列 - 1].最大等级)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","已经达到最大等级！");
                return;
            }

            if (PlayerData.S.HeroDataDic[HeroType].技能点 <= 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","技能点不足！");
                return;
            }

            PlayerData.S.HeroDataDic[HeroType].技能点--;
            PlayerData.S.英雄技能树Dic[HeroType][行 - 1][列 - 1]++;
            ObserverModuleManager.S.SendEvent("刷新技能面板");
        });
    }

    public void SetItem()
    {
        if (HeroType == HeroType.None||英雄技能树Config.英雄技能树Dic[HeroType][行 - 1][列 - 1].技能Type==技能Type.None)
        {
            content.SetActive(false);
            return;
        }
        int 当前level = PlayerData.S.英雄技能树Dic[HeroType][行 - 1][列 - 1];
        int 最大level = 英雄技能树Config.英雄技能树Dic[HeroType][行 - 1][列 - 1].最大等级;
        当前等级.text=当前level.ToString();
        最大等级.text=最大level.ToString();
        image.image.sprite = ResourcesConfig.Get英雄技能树Icon(英雄技能树Config.Get英雄技能Type(HeroType, 行, 列));
        if (当前level < 最大level)
        {
            bg.sprite = ResourcesConfig.圆环暗;
        }
        else
        {
            bg.sprite = ResourcesConfig.圆环亮;
        }

        int 需要等级 = (列-1) * 5;
        bool 需要前置 = 英雄技能树Config.英雄技能树Dic[HeroType][行 - 1][列 - 1].是否有前置;
        if ((需要前置 && 列 > 1 && PlayerData.S.英雄技能树Dic[HeroType][行 - 1][列 - 2] == 0) ||
            PlayerData.S.HeroDataDic[HeroType].境界 < 需要等级)
        {
            bg.color = new Color(104/255f, 102/255f, 102/255f, 255/255f);
            image.image.color = new Color(104/255f, 102/255f, 102/255f, 255/255f);
        }
        else
        {
            bg.color = new Color(1, 1, 1, 1);
            image.image.color = new Color(1, 1, 1, 1);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        bool 是否激活;
        int 需要等级 = (列-1) * 5;
        bool 需要前置 = 英雄技能树Config.英雄技能树Dic[HeroType][行 - 1][列 - 1].是否有前置;
        if ((需要前置 && 列 > 1 && PlayerData.S.英雄技能树Dic[HeroType][行 - 1][列 - 2] == 0) ||
            PlayerData.S.HeroDataDic[HeroType].境界 < 需要等级)
        {
            是否激活=false;
        }
        else
        {
            是否激活=true;
        }

        if (是否激活)
        {
           选中框.gameObject.SetActive(true); 
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        选中框.gameObject.SetActive(false);
    }
}
