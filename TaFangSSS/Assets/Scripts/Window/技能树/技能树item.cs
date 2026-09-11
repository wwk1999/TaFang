using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 技能树item : MonoBehaviour
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
        if (当前level == 0)
        {
            bg.color = new Color(104, 102, 102, 255);
            image.image.color = new Color(104, 102, 102, 255);
            bg.sprite = ResourcesConfig.圆环暗;
        }else if (当前level >= 1 && 当前level < 最大level)
        {
            bg.color = new Color(255, 255, 255, 255);
            image.image.color = new Color(255, 255, 255, 255);
            bg.sprite = ResourcesConfig.圆环暗;
        }else if (当前level==最大level)
        {
            bg.color = new Color(255, 255, 255, 255);
            image.image.color = new Color(255, 255, 255, 255);
            bg.sprite = ResourcesConfig.圆环亮;
        }
    }

}
