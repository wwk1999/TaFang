using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 法器选择弹窗 : MonoBehaviour
{
    private 法器 当前选择法器;
    [NonSerialized]public HeroType HeroType;
    [NonSerialized] public 法器类型 法器类型 = 法器类型.None;
    public Button 装备Button;
    public GameObject content;
    public Button maskButton;

    
    private void OnEnable()
    {
        当前选择法器 = null;
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.法器列表)
        {
            if (法器Config.法器职业Dic[item.法器Type] == HeroConfig.HeroZhiYeDic[HeroType].zhiYeType &&
                法器Config.法器类型Dic[item.法器Type] == 法器类型&&item.HeroType == HeroType.None)
            {
                var a = Instantiate(Resources.Load("Prefabs/Window/法器选择item"), content.transform)
                    .GetComponent<法器选择item>();
                a.法器 = item;
                a.SetItem();
            }
        }
    }

    public void 法器选择Item点击(object[] obj)
    {
        法器 a = obj[0] as 法器;
        当前选择法器 = a;
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("法器选择Item点击",法器选择Item点击);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("法器选择Item点击",法器选择Item点击);
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        装备Button.onClick.AddListener(() =>
            {
                if (当前选择法器 == null)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","请选择装备法器");
                    return;
                }

                switch (法器类型)
                {
                    case 法器类型.头盔:
                        if(PlayerData.S.HeroDataDic[HeroType].头盔!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[HeroType].头盔;
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, HeroType);
                        }
                        PlayerData.S.HeroDataDic[HeroType].头盔 = 当前选择法器;
                        break;
                    case 法器类型.衣服:
                        if(PlayerData.S.HeroDataDic[HeroType].衣服!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[HeroType].衣服;
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, HeroType);
                        }
                        PlayerData.S.HeroDataDic[HeroType].衣服 = 当前选择法器;
                        break;
                    case 法器类型.鞋子:
                        if(PlayerData.S.HeroDataDic[HeroType].鞋子!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[HeroType].鞋子;
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, HeroType);
                        }
                        PlayerData.S.HeroDataDic[HeroType].鞋子 = 当前选择法器;
                        break;
                    case 法器类型.武器:
                        if(PlayerData.S.HeroDataDic[HeroType].武器!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[HeroType].武器;
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, HeroType);
                        }
                        PlayerData.S.HeroDataDic[HeroType].武器 = 当前选择法器;
                        break;
                }
                当前选择法器.HeroType=HeroType;
                ObserverModuleManager.S.SendEvent("法器装备刷新");
                gameObject.SetActive(false);
            }
        );
    }

    /// <summary>
    /// JSON反序列化后法器列表与英雄槽位可能不是同一引用，需同步法器列表中的HeroType
    /// </summary>
    private void Sync法器列表(法器 旧法器, HeroType heroType)
    {
        foreach (var f in PlayerData.S.法器列表)
        {
            if (f.法器Type == 旧法器.法器Type && f.HeroType == heroType)
            {
                f.HeroType = HeroType.None;
                break;
            }
        }
    }
}
