using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 胜利弹窗 : MonoBehaviour
{
    public GameObject Content;
    public Button AgainButtn;
    public Button ExitButtn;
    public TextMeshProUGUI 战斗Text;

    private float 重复挑战Time = 0;
    
    private void Start()
    {
        ExitButtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("UIScene");
        });
        AgainButtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LoadScene");
        });
    }

    private void Update()
    {
        if (PlayerData.S.重复挑战)
        {
            重复挑战Time += Time.unscaledDeltaTime;
            战斗Text.text = "重复挑战:"+(int)(5f-重复挑战Time);
            if (5f - 重复挑战Time < 0)
            {
                SceneManager.LoadScene("LoadScene");
            }
        }
    }

    private void OnEnable()
    {
        ObserverModuleManager.S.SendEvent("停止元始音效");
        ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
        if (PlayerData.S.是否首次通关关卡)
        {
            PlayerData.S.是否首次通关关卡 = false;
            ObserverModuleManager.S.SendEvent("通关新手引导");
        }
        重复挑战Time = 0;
        if (PlayerData.S.重复挑战 == false)
        {
            战斗Text.text = "再战一次";
        }
        foreach (Transform item in Content.transform)
        {
            Destroy(item.gameObject);
        }

        // try/finally：结算里任何一步（奖励UI实例化、字典缺键等）抛异常时，
        // 已发放到内存的奖励也必须落盘，否则玩家看完奖励退出却回档
        try
        {
            if (LevelConfig.当前关卡类型 == 关卡类型.主线关卡)
            {
                主线关卡结算();
            }
            else if (LevelConfig.当前关卡类型 == 关卡类型.洞天秘境)
            {
                洞天关卡结算();
            }else if (LevelConfig.当前关卡类型 == 关卡类型.远古遗迹)
            {
                遗迹关卡结算();
            }
        }
        finally
        {
            StoreController.S.SaveStoreData();
        }
    }

    public void 洞天关卡结算()
    {
        洞天关卡胜利奖励 value = LevelConfig.Get洞天关卡胜利奖励();
        PlayerData.S.PropListDic[PropType.灵魂] += value.灵魂;
        PlayerData.S.PropListDic[PropType.功德] += value.功德;
        foreach (var item in value.List)
        {
            PlayerData.S.Set灵物数量(item.JingJieType,item.QualityType,PlayerData.S.Get灵物数量(item.JingJieType,item.QualityType)+1);
        }
        
        if (value.灵魂 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = value.灵魂;
            item.SetItem();
        }
        if (value.功德 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.功德;
            item.count = value.功德;
            item.SetItem();
        }

        foreach (var 灵物item in value.List)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.灵物QualityType = 灵物item.QualityType;
            item.SetItem();
        }
    }
    
    
    public void 遗迹关卡结算()
    {
        遗迹关卡胜利奖励 value = 神物Config.Get遗迹关卡奖励();
        PlayerData.S.PropListDic[PropType.灵魂] += value.灵魂;
        PlayerData.S.PropListDic[PropType.功德] += value.功德;
        // TryGetValue：老存档的神物获得Dic可能缺少新神物键，缺失视为未获得
        bool 已获得神物 = PlayerData.S.神物获得Dic.TryGetValue(LevelConfig.当前神物Type, out var got) && got;
        if (value.神物 && !已获得神物)
        {
            PlayerData.S.神物获得Dic[LevelConfig.当前神物Type] = true;
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.神物Type = LevelConfig.当前神物Type;
            item.SetItem();
            PlayerData.S.最大神物关卡++;
        }
        
        if (value.灵魂 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = value.灵魂;
            item.SetItem();
        }
        if (value.功德 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.功德;
            item.count = value.功德;
            item.SetItem();
        }
    }
    
    public void 主线关卡结算()
    {
        普通关卡胜利奖励 value = LevelConfig.Get主线胜利奖励();
        道纹 道纹 = 道纹config.Get关卡道纹掉落(LevelConfig.主线关卡境界Dic[LevelConfig.当前主线关卡Type]);
        if (道纹 != null)
        {
            PlayerData.S.Set道纹数量(道纹.道纹Type,道纹.quality,PlayerData.S.Get道纹数量(道纹.道纹Type,道纹.quality)+1);
            var item1=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item1.道纹Type = 道纹.道纹Type;
            item1.道纹QualityType = 道纹.quality;
            item1.SetItem();
        }
        var list = 法器Config.Get关卡法器掉落(LevelConfig.主线关卡境界Dic[LevelConfig.当前主线关卡Type]);
        foreach (var item in list)
        {
            PlayerData.S.法器列表.Add(item);
            var item1=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item1.法器Type = item.法器Type;
            item1.SetItem();
        }

        var 仙石列表 = 仙石Config.Get关卡仙石掉落(LevelConfig.主线关卡境界Dic[LevelConfig.当前主线关卡Type]);
        foreach (var item in 仙石列表)
        {
            PlayerData.S.仙石列表.Add(item);
            var item1=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item1.仙石Type = item.type;
            item1.仙石QualityType = item.quality;
            item1.SetItem();
        }
        PlayerData.S.PropListDic[PropType.灵魂] += value.灵魂;
        PlayerData.S.PropListDic[PropType.功德] += value.功德;
        PlayerData.S.PropListDic[PropType.洗练石] += value.洗练石;
        PlayerData.S.PropListDic[PropType.高级招募卷] += value.高级招募卷;
        PlayerData.S.PropListDic[PropType.射手经验值] += value.射手经验值;
        PlayerData.S.PropListDic[PropType.战士经验值] += value.战士经验值;
        PlayerData.S.PropListDic[PropType.辅助经验值] += value.辅助经验值;
        PlayerData.S.PropListDic[PropType.法师经验值] += value.法师经验值;
        PlayerData.S.PropListDic[PropType.控制经验值] += value.控制经验值;
        PlayerData.S.PropListDic[PropType.衣服锻造石] += value.衣服锻造石;
        PlayerData.S.PropListDic[PropType.头盔锻造石] += value.头盔锻造石;
        PlayerData.S.PropListDic[PropType.护手锻造石] += value.护手锻造石;
        PlayerData.S.PropListDic[PropType.鞋子锻造石] += value.鞋子锻造石;
        PlayerData.S.PropListDic[PropType.项链锻造石] += value.项链锻造石;
        PlayerData.S.PropListDic[PropType.戒指锻造石] += value.戒指锻造石;
        PlayerData.S.PropListDic[PropType.招募卷] += value.招募卷;
        
        if (value.高级招募卷 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.高级招募卷;
            item.count = value.高级招募卷;
            item.SetItem();
        }

        if (value.灵魂 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = value.灵魂;
            item.SetItem();
        }
        if (value.功德 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.功德;
            item.count = value.功德;
            item.SetItem();
        }
        if (value.战士经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.战士经验值;
            item.count = value.战士经验值;
            item.SetItem();
        }
        if (value.射手经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.射手经验值;
            item.count = value.射手经验值;
            item.SetItem();
        }
        if (value.法师经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.法师经验值;
            item.count = value.法师经验值;
            item.SetItem();
        }
        if (value.控制经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.控制经验值;
            item.count = value.控制经验值;
            item.SetItem();
        }
        if (value.辅助经验值 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.辅助经验值;
            item.count = value.辅助经验值;
            item.SetItem();
        }
        if (value.衣服锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.衣服锻造石;
            item.count = value.衣服锻造石;
            item.SetItem();
        }
        if (value.头盔锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.头盔锻造石;
            item.count = value.头盔锻造石;
            item.SetItem();
        }
        if (value.护手锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.护手锻造石;
            item.count = value.护手锻造石;
            item.SetItem();
        }
        if (value.鞋子锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.鞋子锻造石;
            item.count = value.鞋子锻造石;
            item.SetItem();
        }
        if (value.戒指锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.戒指锻造石;
            item.count = value.戒指锻造石;
            item.SetItem();
        }
        if (value.项链锻造石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.项链锻造石;
            item.count = value.项链锻造石;
            item.SetItem();
        }
        if (value.招募卷 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.招募卷;
            item.count = value.招募卷;
            item.SetItem();
        }
        if (value.洗练石 > 0)
        {
            var item=Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"),Content.transform).GetComponent<胜利弹窗item>();
            item.Type = PropType.洗练石;
            item.count = value.洗练石;
            item.SetItem();
        }
        
    }
}
