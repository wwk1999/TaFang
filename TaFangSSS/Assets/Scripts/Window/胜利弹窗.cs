using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
            // 卸载战斗场景并切回还活着的 UIScene（Single 重载会销毁 WindowController/MainWindow，画布排序必乱）
            QueueController.S.退出战斗回道场();
        });
        AgainButtn.onClick.AddListener(() =>
        {
            // 卸载战斗场景后 additive 重走 LoadScene→FightScene 流程，常驻 UIScene 不动
            QueueController.S.重开战斗();
        });
    }
    

    private void Update()
    {
        if (PlayerData.S.重复挑战)
        {
            重复挑战Time += Time.unscaledDeltaTime;
            战斗Text.text = "重复挑战:" + (int)(2f - 重复挑战Time);
            if (2f - 重复挑战Time < 0)
            {
               ObserverModuleManager.S.SendEvent("关卡重置");
               gameObject.SetActive(false);
            }
        }
    }
    
     public void 刷新战斗丹药()
   {
       PlayerData.S.Set丹药数量(PlayerData.S.战斗选择丹药Dic[1].丹药Type, PlayerData.S.战斗选择丹药Dic[1].QualityType,Math.Max(0,
           PlayerData.S.Get丹药数量(PlayerData.S.战斗选择丹药Dic[1].丹药Type, PlayerData.S.战斗选择丹药Dic[1].QualityType, PlayerData.S.战斗选择丹药Dic[1].阶段)-1), PlayerData.S.战斗选择丹药Dic[1].阶段);
       PlayerData.S.Set丹药数量(PlayerData.S.战斗选择丹药Dic[2].丹药Type, PlayerData.S.战斗选择丹药Dic[2].QualityType,Math.Max(0,
           PlayerData.S.Get丹药数量(PlayerData.S.战斗选择丹药Dic[2].丹药Type, PlayerData.S.战斗选择丹药Dic[2].QualityType, PlayerData.S.战斗选择丹药Dic[2].阶段)-1), PlayerData.S.战斗选择丹药Dic[2].阶段);
       PlayerData.S.Set丹药数量(PlayerData.S.战斗选择丹药Dic[3].丹药Type, PlayerData.S.战斗选择丹药Dic[3].QualityType,Math.Max(0,
           PlayerData.S.Get丹药数量(PlayerData.S.战斗选择丹药Dic[3].丹药Type, PlayerData.S.战斗选择丹药Dic[3].QualityType, PlayerData.S.战斗选择丹药Dic[3].阶段)-1), PlayerData.S.战斗选择丹药Dic[3].阶段);
       if (PlayerData.S.Get丹药数量(PlayerData.S.战斗选择丹药Dic[1].丹药Type, PlayerData.S.战斗选择丹药Dic[1].QualityType, PlayerData.S.战斗选择丹药Dic[1].阶段) == 0)
       {
           PlayerData.S.战斗选择丹药Dic[1].丹药Type = 丹药Type.None;
       }
      
       if (PlayerData.S.Get丹药数量(PlayerData.S.战斗选择丹药Dic[2].丹药Type, PlayerData.S.战斗选择丹药Dic[2].QualityType, PlayerData.S.战斗选择丹药Dic[2].阶段) == 0)
       {
           PlayerData.S.战斗选择丹药Dic[2].丹药Type = 丹药Type.None;
       }
      
       if (PlayerData.S.Get丹药数量(PlayerData.S.战斗选择丹药Dic[3].丹药Type, PlayerData.S.战斗选择丹药Dic[3].QualityType, PlayerData.S.战斗选择丹药Dic[3].阶段) == 0)
       {
           PlayerData.S.战斗选择丹药Dic[3].丹药Type = 丹药Type.None;
       }
       ObserverModuleManager.S.SendEvent("设置丹药区域");
       FightController.S.战斗丹药属性 = 丹药Config.Get战斗丹药属性();
       FightController.S.丹药物理伤害 = FightController.S.战斗丹药属性.物理伤害;
       FightController.S.丹药黑暗伤害 = FightController.S.战斗丹药属性.黑暗伤害;
       FightController.S.丹药火焰伤害 = FightController.S.战斗丹药属性.火焰伤害;
       FightController.S.丹药雷电伤害 = FightController.S.战斗丹药属性.雷电伤害;
       FightController.S.丹药冰霜伤害 = FightController.S.战斗丹药属性.冰霜伤害;
       FightController.S.丹药战士伤害 = FightController.S.战斗丹药属性.战士伤害;
       FightController.S.丹药法师伤害 = FightController.S.战斗丹药属性.法师伤害;
       FightController.S.丹药控制伤害 = FightController.S.战斗丹药属性.控制伤害;
       FightController.S.丹药射手伤害 = FightController.S.战斗丹药属性.射手伤害;
       FightController.S.丹药最终伤害 = FightController.S.战斗丹药属性.最终伤害;
   }
    

    private void OnEnable()
    {
        刷新战斗丹药();
        ObserverModuleManager.S.SendEvent("停止元始音效");
        //ObserverModuleManager.S.SendEvent("播放音效", 音效Type.成功);
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
                任务解锁();
                主线关卡结算();
            }
            else if (LevelConfig.当前关卡类型 == 关卡类型.洞天秘境)
            {
                洞天关卡结算();
            }
            else if (LevelConfig.当前关卡类型 == 关卡类型.远古遗迹)
            {
                遗迹关卡结算();
            }
            else if (LevelConfig.当前关卡类型 == 关卡类型.符文之地)
            {
                符文之地结算();
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
        PlayerData.S.PropListDic[PropType.灵魂] += value.灵魂*(1f+属性config.灵气增幅)*(1f+属性config.灵气增幅);
        foreach (var item in value.List)
        {
            PlayerData.S.Set灵物数量(item.JingJieType, item.QualityType,
                PlayerData.S.Get灵物数量(item.JingJieType, item.QualityType) + 1);
        }

        PlayerData.S.PropListDic[PropType.轮回石] += 1 + Mathf.RoundToInt(属性config.仙子总属性.轮回石掉落数量增加);
        var item1 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        item1.Type = PropType.轮回石;
        item1.count = 1;
        item1.SetItem();
        if (value.灵魂 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = (int)value.灵魂;
            item.SetItem();
        }

        foreach (var 灵物item in value.List)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.灵物QualityType = 灵物item.QualityType;
            item.SetItem();
        }
    }


    public void 遗迹关卡结算()
    {
        遗迹关卡胜利奖励 value = 神物Config.Get遗迹关卡奖励();
        PlayerData.S.PropListDic[PropType.轮回石] += 1 + Mathf.RoundToInt(属性config.仙子总属性.轮回石掉落数量增加);
        PlayerData.S.PropListDic[PropType.灵魂] += value.灵魂*(1f+属性config.灵气增幅)*(1f+属性config.灵气增幅);
        // TryGetValue：老存档的神物获得Dic可能缺少新神物键，缺失视为未获得
        bool 已获得神物 = PlayerData.S.神物获得Dic.TryGetValue(LevelConfig.当前神物Type, out var got) && got;
        if (value.神物 && !已获得神物)
        {
            PlayerData.S.神物获得Dic[LevelConfig.当前神物Type] = true;
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.神物Type = LevelConfig.当前神物Type;
            item.SetItem();
            PlayerData.S.最大神物关卡++;
            PlayerData.S.任务完成字典[任务Type.远古遗迹掉落神物] = true;
        }
        var item1 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        item1.Type = PropType.轮回石;
        item1.count = 1;
        item1.SetItem();

        if (value.灵魂 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = (int)value.灵魂;
            item.SetItem();
        }
    }


    public void 符文之地结算()
    {
        if (LevelConfig.当前符文之地Type == PlayerData.S.符文之地最大关卡)
        {
            // 通关最终关后不再自增，否则会产生无效枚举值（11），
            // 触发符文之地窗口的越界钳制把进度回退
            if (PlayerData.S.符文之地最大关卡 < 符文之地Type.天道台)
            {
                PlayerData.S.符文之地最大关卡++;
            }
        }
        PlayerData.S.任务完成字典[任务Type.通关一次符文之地] = true;
        符文之地关卡胜利奖励 value = 符文之地Config.Get符文之地奖励();
        PlayerData.S.PropListDic[PropType.轮回石] += 1 + Mathf.RoundToInt(属性config.仙子总属性.轮回石掉落数量增加);
        PlayerData.S.PropListDic[PropType.灵魂] += value.灵魂*(1f+属性config.灵气增幅)*(1f+属性config.灵气增幅);
        foreach (var item in value.符文list)
        {
            PlayerData.S.Get符文List(item.quality).Add(item);

            var 符文 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            符文.符文Type = item.type;
            符文.符文QualityType = item.quality;
            符文.SetItem();
        }
        var item1 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        item1.Type = PropType.轮回石;
        item1.count = 1;
        item1.SetItem();

        if (value.灵魂 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = (int)value.灵魂;
            item.SetItem();
        }
    }

    public void 任务解锁()
    {
        switch (LevelConfig.当前主线关卡Type)
        {
            case 主线关卡Type.花果山:
                PlayerData.S.任务完成字典[任务Type.花果山] = true;
                break;
            case 主线关卡Type.水帘洞:
                PlayerData.S.任务完成字典[任务Type.水帘洞] = true;
                break;
            case 主线关卡Type.蓬莱仙岛:
                PlayerData.S.任务完成字典[任务Type.蓬莱仙岛] = true;
                break;
            case 主线关卡Type.五行山:
                PlayerData.S.任务完成字典[任务Type.五行山] = true;
                break;
            case 主线关卡Type.傲来国:
                PlayerData.S.任务完成字典[任务Type.傲来国] = true;
                break;
            case 主线关卡Type.高老庄:
                PlayerData.S.任务完成字典[任务Type.高老庄] = true;
                break;
            case 主线关卡Type.女儿国:
                PlayerData.S.任务完成字典[任务Type.女儿国] = true;
                break;
            case 主线关卡Type.小雷音寺:
                PlayerData.S.任务完成字典[任务Type.小雷音寺] = true;
                break;
            case 主线关卡Type.平顶山:
                PlayerData.S.任务完成字典[任务Type.平顶山] = true;
                break;
            case 主线关卡Type.火焰山:
                PlayerData.S.任务完成字典[任务Type.火焰山] = true;
                break;
            case 主线关卡Type.芭蕉洞:
                PlayerData.S.任务完成字典[任务Type.芭蕉洞] = true;
                break;
            case 主线关卡Type.流沙河:
                PlayerData.S.任务完成字典[任务Type.流沙河] = true;
                break;
            case 主线关卡Type.狮驼岭:
                PlayerData.S.任务完成字典[任务Type.狮驼岭] = true;
                break;
            case 主线关卡Type.东海龙宫:
                PlayerData.S.任务完成字典[任务Type.东海龙宫] = true;
                break;
            case 主线关卡Type.冥府:
                PlayerData.S.任务完成字典[任务Type.冥府] = true;
                break;
            case 主线关卡Type.南天门:
                PlayerData.S.任务完成字典[任务Type.南天门] = true;
                break;
            case 主线关卡Type.瑶池仙境:
                PlayerData.S.任务完成字典[任务Type.瑶池仙境] = true;
                break;
            case 主线关卡Type.斩妖台:
                PlayerData.S.任务完成字典[任务Type.斩妖台] = true;
                break;
            case 主线关卡Type.御马监:
                PlayerData.S.任务完成字典[任务Type.御马监] = true;
                break;
            case 主线关卡Type.蟠桃园:
                PlayerData.S.任务完成字典[任务Type.蟠桃园] = true;
                break;
            case 主线关卡Type.兜率宫:
                PlayerData.S.任务完成字典[任务Type.兜率宫] = true;
                break;
            case 主线关卡Type.紫微宫:
                PlayerData.S.任务完成字典[任务Type.紫微宫] = true;
                break;
            case 主线关卡Type.昊天殿:
                PlayerData.S.任务完成字典[任务Type.昊天殿] = true;
                break;
            case 主线关卡Type.混沌虚空:
                if (LevelConfig.战斗混沌虚空层数 >= 50)
                {
                    PlayerData.S.任务完成字典[任务Type.三十三重天50层] = true;
                }
                if (LevelConfig.战斗混沌虚空层数 >= 150)
                {
                    PlayerData.S.任务完成字典[任务Type.三十三重天150层] = true;
                }
                if (LevelConfig.战斗混沌虚空层数 >= 300)
                {
                    PlayerData.S.任务完成字典[任务Type.三十三重天300层] = true;
                }
                if (LevelConfig.战斗混沌虚空层数 >= 600)
                {
                    PlayerData.S.任务完成字典[任务Type.三十三重天600层] = true;
                }
                if (LevelConfig.战斗混沌虚空层数 >= 1000)
                {
                    PlayerData.S.任务完成字典[任务Type.三十三重天1000层] = true;
                }
                break;
        }
    }

    public void 增加法器材料(法器材料Type 法器材料Type, int 阶数, float count)
    {
        switch (法器材料Type)
        {
            case 法器材料Type.石:
                switch (阶数)
                {
                    case 1:
                        PlayerData.S.PropListDic[PropType.石1] += count;
                        break;
                    case 2:
                        PlayerData.S.PropListDic[PropType.石2] += count;
                        break;
                    case 3:
                        PlayerData.S.PropListDic[PropType.石3] += count;
                        break;
                    case 4:
                        PlayerData.S.PropListDic[PropType.石4] += count;
                        break;
                    case 5:
                        PlayerData.S.PropListDic[PropType.石5] += count;
                        break;
                    case 6:
                        PlayerData.S.PropListDic[PropType.石6] += count;
                        break;
                    case 7:
                        PlayerData.S.PropListDic[PropType.石7] += count;
                        break;
                    case 8:
                        PlayerData.S.PropListDic[PropType.石8] += count;
                        break;
                    case 9:
                        PlayerData.S.PropListDic[PropType.石9] += count;
                        break;
                    case 10:
                        PlayerData.S.PropListDic[PropType.石10] += count;
                        break;
                    case 11:
                        PlayerData.S.PropListDic[PropType.石11] += count;
                        break;
                    case 12:
                        PlayerData.S.PropListDic[PropType.石12] += count;
                        break;
                    case 13:
                        PlayerData.S.PropListDic[PropType.石13] += count;
                        break;
                    case 14:
                        PlayerData.S.PropListDic[PropType.石14] += count;
                        break;
                    case 15:
                        PlayerData.S.PropListDic[PropType.石15] += count;
                        break;
                    case 16:
                        PlayerData.S.PropListDic[PropType.石16] += count;
                        break;
                }
                break;
            
            case 法器材料Type.羽:
                switch (阶数)
                {
                    case 1:
                        PlayerData.S.PropListDic[PropType.羽1] += count;
                        break;
                    case 2:
                        PlayerData.S.PropListDic[PropType.羽2] += count;
                        break;
                    case 3:
                        PlayerData.S.PropListDic[PropType.羽3] += count;
                        break;
                    case 4:
                        PlayerData.S.PropListDic[PropType.羽4] += count;
                        break;
                    case 5:
                        PlayerData.S.PropListDic[PropType.羽5] += count;
                        break;
                    case 6:
                        PlayerData.S.PropListDic[PropType.羽6] += count;
                        break;
                    case 7:
                        PlayerData.S.PropListDic[PropType.羽7] += count;
                        break;
                    case 8:
                        PlayerData.S.PropListDic[PropType.羽8] += count;
                        break;
                    case 9:
                        PlayerData.S.PropListDic[PropType.羽9] += count;
                        break;
                    case 10:
                        PlayerData.S.PropListDic[PropType.羽10] += count;
                        break;
                    case 11:
                        PlayerData.S.PropListDic[PropType.羽11] += count;
                        break;
                    case 12:
                        PlayerData.S.PropListDic[PropType.羽12] += count;
                        break;
                    case 13:
                        PlayerData.S.PropListDic[PropType.羽13] += count;
                        break;
                    case 14:
                        PlayerData.S.PropListDic[PropType.羽14] += count;
                        break;
                    case 15:
                        PlayerData.S.PropListDic[PropType.羽15] += count;
                        break;
                    case 16:
                        PlayerData.S.PropListDic[PropType.羽16] += count;
                        break;
                }
                break;
            
            
            case 法器材料Type.砂:
                switch (阶数)
                {
                    case 1:
                        PlayerData.S.PropListDic[PropType.砂1] += count;
                        break;
                    case 2:
                        PlayerData.S.PropListDic[PropType.砂2] += count;
                        break;
                    case 3:
                        PlayerData.S.PropListDic[PropType.砂3] += count;
                        break;
                    case 4:
                        PlayerData.S.PropListDic[PropType.砂4] += count;
                        break;
                    case 5:
                        PlayerData.S.PropListDic[PropType.砂5] += count;
                        break;
                    case 6:
                        PlayerData.S.PropListDic[PropType.砂6] += count;
                        break;
                    case 7:
                        PlayerData.S.PropListDic[PropType.砂7] += count;
                        break;
                    case 8:
                        PlayerData.S.PropListDic[PropType.砂8] += count;
                        break;
                    case 9:
                        PlayerData.S.PropListDic[PropType.砂9] += count;
                        break;
                    case 10:
                        PlayerData.S.PropListDic[PropType.砂10] += count;
                        break;
                    case 11:
                        PlayerData.S.PropListDic[PropType.砂11] += count;
                        break;
                    case 12:
                        PlayerData.S.PropListDic[PropType.砂12] += count;
                        break;
                    case 13:
                        PlayerData.S.PropListDic[PropType.砂13] += count;
                        break;
                    case 14:
                        PlayerData.S.PropListDic[PropType.砂14] += count;
                        break;
                    case 15:
                        PlayerData.S.PropListDic[PropType.砂15] += count;
                        break;
                    case 16:
                        PlayerData.S.PropListDic[PropType.砂16] += count;
                        break;
                }
                break;
            
            
            case 法器材料Type.铁:
                switch (阶数)
                {
                    case 1:
                        PlayerData.S.PropListDic[PropType.铁1] += count;
                        break;
                    case 2:
                        PlayerData.S.PropListDic[PropType.铁2] += count;
                        break;
                    case 3:
                        PlayerData.S.PropListDic[PropType.铁3] += count;
                        break;
                    case 4:
                        PlayerData.S.PropListDic[PropType.铁4] += count;
                        break;
                    case 5:
                        PlayerData.S.PropListDic[PropType.铁5] += count;
                        break;
                    case 6:
                        PlayerData.S.PropListDic[PropType.铁6] += count;
                        break;
                    case 7:
                        PlayerData.S.PropListDic[PropType.铁7] += count;
                        break;
                    case 8:
                        PlayerData.S.PropListDic[PropType.铁8] += count;
                        break;
                    case 9:
                        PlayerData.S.PropListDic[PropType.铁9] += count;
                        break;
                    case 10:
                        PlayerData.S.PropListDic[PropType.铁10] += count;
                        break;
                    case 11:
                        PlayerData.S.PropListDic[PropType.铁11] += count;
                        break;
                    case 12:
                        PlayerData.S.PropListDic[PropType.铁12] += count;
                        break;
                    case 13:
                        PlayerData.S.PropListDic[PropType.铁13] += count;
                        break;
                    case 14:
                        PlayerData.S.PropListDic[PropType.铁14] += count;
                        break;
                    case 15:
                        PlayerData.S.PropListDic[PropType.铁15] += count;
                        break;
                    case 16:
                        PlayerData.S.PropListDic[PropType.铁16] += count;
                        break;
                }
                break;
        }
    }
    public void 主线关卡结算()
    {
        int 层数 = 1;
        switch (LevelConfig.当前主线关卡Type)
        {
            case 主线关卡Type.混沌虚空:
                层数 = LevelConfig.战斗混沌虚空层数;
                break;
            case 主线关卡Type.须弥宫:
                层数 = LevelConfig.战斗须弥宫层数;
                break;
            case 主线关卡Type.娲皇宫:
                层数 = LevelConfig.战斗娲皇宫层数;
                break;
            case 主线关卡Type.碧游宫:
                层数 = LevelConfig.战斗碧游宫层数;
                break;
            case 主线关卡Type.玉虚宫:
                层数 = LevelConfig.战斗玉虚宫层数;
                break;
            case 主线关卡Type.八景宫:
                层数 = LevelConfig.战斗八景宫层数;
                break;
        }
        主线关卡掉落 value = LevelConfig.Get主线关卡掉落(LevelConfig.当前主线关卡Type,层数);
        float 轮回石数量 = value.轮回石数量;
        轮回石数量 += Mathf.RoundToInt(属性config.仙子总属性.轮回石掉落数量增加);
        PlayerData.S.PropListDic[PropType.轮回石] += 轮回石数量;
        float 灵魂 = value.灵魂 * Random.Range(0.8f, 1.2f);
        float 洗练石 = value.洗练石 * Random.Range(0.8f, 1.2f);
        float 射手经验值 = value.职业经验 * Random.Range(0.8f, 1.2f);
        float 战士经验值 = value.职业经验 * Random.Range(0.8f, 1.2f);
        float 辅助经验值 = value.职业经验 * Random.Range(0.8f, 1.2f);
        float 法师经验值 = value.职业经验 * Random.Range(0.8f, 1.2f);
        float 控制经验值 = value.职业经验 * Random.Range(0.8f, 1.2f);
        float 衣服锻造石 = value.锻造石 * Random.Range(0.8f, 1.2f);
        float 头盔锻造石 = value.锻造石 * Random.Range(0.8f, 1.2f);
        float 护手锻造石 = value.锻造石 * Random.Range(0.8f, 1.2f);
        float 鞋子锻造石 = value.锻造石 * Random.Range(0.8f, 1.2f);
        float 项链锻造石 = value.锻造石 * Random.Range(0.8f, 1.2f);
        float 戒指锻造石 = value.锻造石 * Random.Range(0.8f, 1.2f);
        float 招募卷 = value.招募卷 * Random.Range(0.8f, 1.2f);
        if (value.灵魂 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.灵魂;
            item.count = (int)灵魂;
            item.SetItem();
        }
        
        
        int 法器阶数 = value.法器材料阶数;
        float 法器数量 = value.法器材料数量;
        float 砂数量 = 法器数量 * Random.Range(0.8f, 1.2f)*属性config.总掉宝率;
        float 铁数量 = 法器数量 * Random.Range(0.8f, 1.2f)*属性config.总掉宝率;
        float 石数量 = 法器数量 * Random.Range(0.8f, 1.2f)*属性config.总掉宝率;
        float 羽数量 = 法器数量 * Random.Range(0.8f, 1.2f)*属性config.总掉宝率;
        增加法器材料(法器材料Type.石,法器阶数,石数量);
        增加法器材料(法器材料Type.羽,法器阶数,羽数量);
        增加法器材料(法器材料Type.铁,法器阶数,铁数量);
        增加法器材料(法器材料Type.砂,法器阶数,砂数量);
        
        var 石 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        石.法器材料Type = 法器材料Type.石;
        石.法器材料阶数= 法器阶数;
        石.count = Math.Max(1,(int)石数量);
        石.法器材料QualityType = 法器Config.Get阶数对应品质(法器阶数);
        石.SetItem();
        
        var 铁 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        铁.法器材料Type = 法器材料Type.铁;
        铁.法器材料阶数= 法器阶数;  
        铁.count = Math.Max(1,(int)铁数量);
        铁.法器材料QualityType = 法器Config.Get阶数对应品质(法器阶数);
        铁.SetItem();
        
        var 羽 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        羽.法器材料Type = 法器材料Type.羽;
        羽.法器材料阶数= 法器阶数;
        羽.count = Math.Max(1,(int)羽数量);
        羽.法器材料QualityType = 法器Config.Get阶数对应品质(法器阶数);
        羽.SetItem();
        
        var 砂 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        砂.法器材料Type = 法器材料Type.砂;
        砂.法器材料阶数= 法器阶数;
        砂.count = Math.Max(1,(int)砂数量);
        砂.法器材料QualityType = 法器Config.Get阶数对应品质(法器阶数);
        砂.SetItem();
        
        var 仙石列表 = 仙石Config.Get关卡仙石掉落(value);
        foreach (var item in 仙石列表)
        {
            PlayerData.S.仙石列表.Add(item);
            var item1 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item1.仙石Type = item.type;
            item1.仙石QualityType = item.quality;
            item1.仙石阶数 = item.阶数;
            item1.SetItem();
        }

       

        PlayerData.S.PropListDic[PropType.灵魂] += 灵魂;
        PlayerData.S.PropListDic[PropType.洗练石] += 洗练石;
        PlayerData.S.PropListDic[PropType.射手经验值] += 射手经验值;
        PlayerData.S.PropListDic[PropType.战士经验值] += 战士经验值;
        PlayerData.S.PropListDic[PropType.辅助经验值] += 辅助经验值;
        PlayerData.S.PropListDic[PropType.法师经验值] += 法师经验值;
        PlayerData.S.PropListDic[PropType.控制经验值] += 控制经验值;
        PlayerData.S.PropListDic[PropType.衣服锻造石] += 衣服锻造石;
        PlayerData.S.PropListDic[PropType.头盔锻造石] += 头盔锻造石;
        PlayerData.S.PropListDic[PropType.护手锻造石] += 护手锻造石;
        PlayerData.S.PropListDic[PropType.鞋子锻造石] += 鞋子锻造石;
        PlayerData.S.PropListDic[PropType.项链锻造石] += 项链锻造石;
        PlayerData.S.PropListDic[PropType.戒指锻造石] += 戒指锻造石;
        PlayerData.S.PropListDic[PropType.招募卷] += 招募卷;
        PlayerData.S.PropListDic[PropType.高级招募卷] += value.高级招募卷;

        var item11 = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
            .GetComponent<胜利弹窗item>();
        item11.Type = PropType.轮回石;
        item11.count = (int)轮回石数量;
        item11.SetItem();
        
        if (value.高级招募卷 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.高级招募卷;
            item.count = (int)value.高级招募卷;
            item.SetItem();
        }
        
        if (招募卷 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.招募卷;
            item.count = (int)招募卷;
            item.SetItem();
        }

        if (洗练石 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.洗练石;
            item.count = (int)洗练石;
            item.SetItem();
        }
        

        if (value.职业经验 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.战士经验值;
            item.count = (int)战士经验值;
            item.SetItem();
        }

        if (value.职业经验 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.法师经验值;
            item.count = (int)法师经验值;
            item.SetItem();
        }

        if (value.职业经验 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.射手经验值;
            item.count = (int)射手经验值;
            item.SetItem();
        }

        if (value.职业经验 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.控制经验值;
            item.count = (int)控制经验值;
            item.SetItem();
        }

        if (value.职业经验 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.辅助经验值;
            item.count = (int)辅助经验值;
            item.SetItem();
        }

        if (衣服锻造石 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.衣服锻造石;
            item.count = (int)衣服锻造石;
            item.SetItem();
        }

        if (护手锻造石 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.护手锻造石;
            item.count = (int)护手锻造石;
            item.SetItem();
        }

        if (戒指锻造石 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.戒指锻造石;
            item.count = (int)戒指锻造石;
            item.SetItem();
        }

        if (项链锻造石 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.项链锻造石;
            item.count = (int)项链锻造石;
            item.SetItem();
        }

        if (头盔锻造石 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.头盔锻造石;
            item.count = (int)头盔锻造石;
            item.SetItem();
        }

        if (鞋子锻造石 > 0)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/胜利弹窗Item"), Content.transform)
                .GetComponent<胜利弹窗item>();
            item.Type = PropType.鞋子锻造石;
            item.count = (int)鞋子锻造石;
            item.SetItem();
        }
    }
}
