using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 英雄法器item : MonoBehaviour
{
    [NonSerialized] public HeroType HeroType;
    [NonSerialized] public 法器类型 法器类型;
    public Button bg;
    public Image icon;
    public GameObject 孔content;

    public void SetItem()
    {
        foreach (Transform item in 孔content.transform)
        {
            Destroy(item.gameObject);
        }

        法器 法器 = null;
        switch (法器类型)
        {
            case 法器类型.头盔:
                法器 = PlayerData.S.HeroDataDic[HeroType].头盔;
                break;
            case 法器类型.武器:
                法器 = PlayerData.S.HeroDataDic[HeroType].武器;
                break;
            case 法器类型.鞋子:
                法器 = PlayerData.S.HeroDataDic[HeroType].鞋子;
                break;
            case 法器类型.衣服:
                法器 = PlayerData.S.HeroDataDic[HeroType].衣服;
                break;
        }
        if (法器 == null)
        {
            bg.image.sprite = ResourcesConfig.加号背景框;
            icon.gameObject.SetActive(false);
        }
        else
        {
            icon.gameObject.SetActive(true);
            bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(法器Config.法器品质Dic[法器.法器Type]);
            icon.sprite = ResourcesConfig.Get法器Sprite(法器.法器Type);
            foreach (var item in 法器.仙石list)
            {
                var 孔=Instantiate(Resources.Load("Prefabs/Window/英雄法器孔item"),孔content.transform).GetComponent<英雄法器孔item>();
                孔.仙石 = item;
                孔.SetItem();
            }
        }
    }

    private void Start()
    {
        bg.onClick.AddListener(() =>
            {
                ObserverModuleManager.S.SendEvent("显示法器选择弹窗",HeroType,法器类型);
            }
        );
    }
}
