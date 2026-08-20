using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Config;
using Newtonsoft.Json;
using UnityEngine;
public class StoreController : XSingleton<StoreController>
{
    public StoreDefine.StoreData StoreData;
    private string SavePath =>Path.Combine(Application.persistentDataPath, "TaFangStore.json");
    private float StoreTime = 3;
    private float CurrentTime = 0;
    private float 增加修为时间 = 1;
    private float 当前增加修为时间 = 0;

    
     public void SaveStoreData(StoreDefine.StoreData data = null)
    {
        try
        {
            StoreData = data ?? StoreData ?? new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(PlayerData.S);
            var json = JsonConvert.SerializeObject(StoreData, Newtonsoft.Json.Formatting.None);

            File.WriteAllText(SavePath, json);

            Debug.Log($"保存数据成功->{SavePath}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"保存数据失败: {e.Message}");
            Debug.LogError($"异常类型: {e.GetType().Name}");
            Debug.LogError($"堆栈跟踪: {e.StackTrace}");

            // 检查各个单例对象是否存在
            Debug.Log($"PlayerData.S 存在: {PlayerData.S != null}");
        }
    }

    public bool GetStoreIsEmpty()
    {
        var path1 = SavePath;
        return !File.Exists(path1);
    }

    public StoreDefine.StoreData GetStoreData()
    {
        var path = SavePath;
        var json = File.ReadAllText(path);
        StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json);
        return StoreData;
    }

    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private float timer = 0;
    private void Update()
    {
        timer+=Time.unscaledDeltaTime;
        if (timer >= 1f/(1+道宝Config.羁绊寻宝速度/100f))
        {
            timer = 0;
            通关塔掉落();
            世界树掉落();
            血海掉落();
            不周山掉落();
        }
        CurrentTime+= Time.unscaledDeltaTime;
        当前增加修为时间+= Time.unscaledDeltaTime;
        PlayerData.S.道龄S += Time.unscaledDeltaTime;
        if (PlayerData.S.道龄S >= 属性config.每年秒数)
        {
            PlayerData.S.道龄S = 0;
            PlayerData.S.道龄年++;
            PlayerData.S.剩余传道次数++;
        }
        //自动保存
        if (当前增加修为时间 >= 增加修为时间)
        {
            ObserverModuleManager.S.SendEvent("刷新主页面");
            当前增加修为时间 = 0;
            if (PlayerData.S.Exp < JingJieConfig.升级需要年数Dic[PlayerData.S.JingJieType] * 200)
            {
                PlayerData.S.Exp += JingJieConfig.每秒增加修为;
                ObserverModuleManager.S.SendEvent("增加修为",JingJieConfig.每秒增加修为);
            }
            
        }
        if (CurrentTime >= StoreTime)
        {
            CurrentTime = 0;
            SaveStoreData();
        }
    }
    
    
    public void 通天塔单次掉落(int i)
    {
        var list = 通天塔Config.Get通天塔掉落(i);
        foreach (var item in list)
        {
            bool flag = false;
            for (int j = 0; j < PlayerData.S.通天塔寻宝Dic[i].list.Count; j++)
            {
                if (PlayerData.S.通天塔寻宝Dic[i].list[j].城墙道具Type == item)
                {
                    flag = true;
                    PlayerData.S.通天塔寻宝Dic[i].list[j].count++;
                    break;
                }
            }
            if (!flag)
            {
                寻宝城墙道具item 掉落item = new 寻宝城墙道具item(){城墙道具Type =item,count=1 };
                PlayerData.S.通天塔寻宝Dic[i].list.Add(掉落item);
            }
        }
    }

    public void 通关塔掉落()
    {
        for (int i = 1; i <= 10; i++)
        {
            if (PlayerData.S.通天塔寻宝Dic[i].寻宝)
            {
                PlayerData.S.通天塔寻宝Dic[i].time--;
                if (PlayerData.S.通天塔寻宝Dic[i].time <= 0)
                {
                    通天塔单次掉落(i);
                    if (PlayerData.S.通天塔寻宝Dic[i].重复)
                    {
                        PlayerData.S.通天塔寻宝Dic[i].time = 属性config.每年秒数 * 通天塔Config.通天塔关卡Dic[i].需要年数;
                        ObserverModuleManager.S.SendEvent("刷新主页通天塔收获弹窗");
                    }
                    else
                    {
                        PlayerData.S.通天塔寻宝Dic[i].寻宝 = false;
                        foreach (var item in PlayerData.S.通天塔寻宝Dic[i].list)
                        {
                            PlayerData.S.城墙道具等级Dic[item.城墙道具Type]+=item.count;
                        }
                        ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
                        ObserverModuleManager.S.SendEvent("SendUIToast","寻宝结束,已获得"+城墙Config.城墙道具名Dic[PlayerData.S.通天塔寻宝Dic[i].list[0].城墙道具Type]);
                        PlayerData.S.通天塔寻宝Dic[i].list.Clear();
                        PlayerData.S.通天塔寻宝Dic[i].寻宝 = false;

                        for (int j = 0; j < PlayerData.S.通天塔英雄派遣Dic[i].Count; j++)
                        {
                            HeroType heroType = PlayerData.S.通天塔英雄派遣Dic[i][j];
                            PlayerData.S.HeroDataDic[heroType].派遣 = false;
                            PlayerData.S.通天塔英雄派遣Dic[i][j] = HeroType.None;
                        }
                        ObserverModuleManager.S.SendEvent("刷新通天塔窗口");
                        ObserverModuleManager.S.SendEvent("通天塔英雄派遣Item刷新");                    }
                }
            }
        }
    }
    
    
    public void 世界树单次掉落(int i)
    {
        var list = 世界树Config.Get世界树掉落(i);
        foreach (var item in list)
        {
            bool flag = false;
            for (int j = 0; j < PlayerData.S.世界树寻宝Dic[i].list.Count; j++)
            {
                if (PlayerData.S.世界树寻宝Dic[i].list[j].道宝Type == item)
                {
                    flag = true;
                    PlayerData.S.世界树寻宝Dic[i].list[j].count++;
                    break;
                }
            }
            if (!flag)
            {
                寻宝道宝道具item 掉落item = new 寻宝道宝道具item(){道宝Type = item,count=1 };
                PlayerData.S.世界树寻宝Dic[i].list.Add(掉落item);
            }
        }
    }
    
    
    public void 世界树掉落()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (PlayerData.S.世界树寻宝Dic[i].寻宝)
            {
                PlayerData.S.世界树寻宝Dic[i].time--;
                if (PlayerData.S.世界树寻宝Dic[i].time <= 0)
                {
                    世界树单次掉落(i);
                    if (PlayerData.S.世界树寻宝Dic[i].重复)
                    {
                        ObserverModuleManager.S.SendEvent("刷新主页世界树收获弹窗");
                        PlayerData.S.世界树寻宝Dic[i].time = 属性config.每年秒数 * 世界树Config.世界树关卡Dic[i].需要年数;
                    }
                    else
                    {
                        PlayerData.S.世界树寻宝Dic[i].寻宝 = false;
                        foreach (var item in PlayerData.S.世界树寻宝Dic[i].list)
                        {
                            PlayerData.S.道宝LevelDic[item.道宝Type]+=item.count;
                        }
                        ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
                        ObserverModuleManager.S.SendEvent("SendUIToast","寻宝结束,已获得"+道宝Config.道宝NameDic[PlayerData.S.世界树寻宝Dic[i].list[0].道宝Type]);

                        PlayerData.S.世界树寻宝Dic[i].list.Clear();
                        PlayerData.S.世界树寻宝Dic[i].寻宝 = false;

                        for (int j = 0; j < PlayerData.S.世界树英雄派遣Dic[i].Count; j++)
                        {
                            HeroType heroType = PlayerData.S.世界树英雄派遣Dic[i][j];
                            PlayerData.S.HeroDataDic[heroType].派遣 = false;
                            PlayerData.S.世界树英雄派遣Dic[i][j] = HeroType.None;
                        }
                        ObserverModuleManager.S.SendEvent("刷新世界树窗口");
                        ObserverModuleManager.S.SendEvent("世界树英雄派遣Item刷新");
                    }
                }
            }
        }
    }
    
    
    
    
    public void 血海单次掉落(int i)
    {
        var list = 血海Config.Get血海掉落(i);
        foreach (var item in list)
        {
            bool flag = false;//字典里是否已经有了
            for (int j = 0; j < PlayerData.S.血海寻宝Dic[i].list.Count; j++)
            {
                if (PlayerData.S.血海寻宝Dic[i].list[j].灵药.灵药Type == item.灵药Type&&PlayerData.S.血海寻宝Dic[i].list[j].灵药.QualityType == item.QualityType)
                {
                    flag = true;
                    PlayerData.S.血海寻宝Dic[i].list[j].count++;
                    break;
                }
            }
            if (!flag)
            {
                寻宝灵药道具item 掉落item = new 寻宝灵药道具item(){};
                掉落item.灵药.灵药Type = item.灵药Type;
                掉落item.灵药.QualityType = item.QualityType;
                掉落item.count = 1;
                PlayerData.S.血海寻宝Dic[i].list.Add(掉落item);
            }
        }
    }
    
    
    public void 血海掉落()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (PlayerData.S.血海寻宝Dic[i].寻宝)
            {
                PlayerData.S.血海寻宝Dic[i].time--;
                if (PlayerData.S.血海寻宝Dic[i].time <= 0)
                {
                    血海单次掉落(i);
                    if (PlayerData.S.血海寻宝Dic[i].重复)
                    {
                        ObserverModuleManager.S.SendEvent("刷新主页血海收获弹窗");
                        PlayerData.S.血海寻宝Dic[i].time = 属性config.每年秒数 * 血海Config.血海关卡Dic[i].需要年数;
                    }
                    else
                    {
                        PlayerData.S.血海寻宝Dic[i].寻宝 = false;
                        foreach (var item in PlayerData.S.血海寻宝Dic[i].list)
                        {
                            int count = PlayerData.S.Get灵药数量(item.灵药.灵药Type, item.灵药.QualityType);
                            PlayerData.S.Set灵药数量(item.灵药.灵药Type,item.灵药.QualityType,count+item.count);
                        }
                        ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
                        ObserverModuleManager.S.SendEvent("SendUIToast","寻宝结束,已获得"+丹药Config.灵药名Dic[PlayerData.S.血海寻宝Dic[i].list[0].灵药.灵药Type]);

                        PlayerData.S.血海寻宝Dic[i].list.Clear();
                        PlayerData.S.血海寻宝Dic[i].寻宝 = false;

                        for (int j = 0; j < PlayerData.S.血海英雄派遣Dic[i].Count; j++)
                        {
                            HeroType heroType = PlayerData.S.血海英雄派遣Dic[i][j];
                            PlayerData.S.HeroDataDic[heroType].派遣 = false;
                            PlayerData.S.血海英雄派遣Dic[i][j] = HeroType.None;
                        }
                        ObserverModuleManager.S.SendEvent("刷新血海窗口");
                        ObserverModuleManager.S.SendEvent("血海英雄派遣Item刷新");
                    }
                }
            }
        }
    }
    
    
    
    public void 不周山单次掉落(int i)
    {
        var list = 不周山Config.Get不周山掉落(i);
        foreach (var item in list)
        {
            bool flag = false;
            for (int j = 0; j < PlayerData.S.不周山寻宝Dic[i].list.Count; j++)
            {
                if (PlayerData.S.不周山寻宝Dic[i].list[j].法则Type == item)
                {
                    flag = true;
                    PlayerData.S.不周山寻宝Dic[i].list[j].count++;
                    break;
                }
            }
            if (!flag)
            {
                寻宝法则道具item 掉落item = new 寻宝法则道具item(){法则Type = item,count=1 };
                PlayerData.S.不周山寻宝Dic[i].list.Add(掉落item);
            }
        }
    }
    
    
    public void 不周山掉落()
    {
        for (int i = 1; i <= 8; i++)
        {
            if (PlayerData.S.不周山寻宝Dic[i].寻宝)
            {
                PlayerData.S.不周山寻宝Dic[i].time--;
                if (PlayerData.S.不周山寻宝Dic[i].time <= 0)
                {
                    不周山单次掉落(i);
                    if (PlayerData.S.不周山寻宝Dic[i].重复)
                    {
                        ObserverModuleManager.S.SendEvent("刷新主页不周山收获弹窗");
                        PlayerData.S.不周山寻宝Dic[i].time = 属性config.每年秒数 * 不周山Config.不周山关卡Dic[i].需要年数;
                    }
                    else
                    {
                        PlayerData.S.不周山寻宝Dic[i].寻宝 = false;
                        foreach (var item in PlayerData.S.不周山寻宝Dic[i].list)
                        {
                            PlayerData.S.PropListDic[item.法则Type]+=item.count;
                        }
                        ObserverModuleManager.S.SendEvent("播放音效",音效Type.成功);
                        ObserverModuleManager.S.SendEvent("SendUIToast","寻宝结束,已获得"+法则config.法则名Dic[法则config.法则英雄Dic[PlayerData.S.不周山寻宝Dic[i].list[0].法则Type]]);

                        PlayerData.S.不周山寻宝Dic[i].list.Clear();
                        PlayerData.S.不周山寻宝Dic[i].寻宝 = false;

                        for (int j = 0; j < PlayerData.S.不周山英雄派遣Dic[i].Count; j++)
                        {
                            HeroType heroType = PlayerData.S.不周山英雄派遣Dic[i][j];
                            PlayerData.S.HeroDataDic[heroType].派遣 = false;
                            PlayerData.S.不周山英雄派遣Dic[i][j] = HeroType.None;
                        }
                        ObserverModuleManager.S.SendEvent("刷新不周山窗口");
                        ObserverModuleManager.S.SendEvent("不周山英雄派遣Item刷新");
                    }
                }
            }
        }
    }

    public void LoadStoreData()
    {
        var path = SavePath;
        if (!File.Exists(path))
        {
            StoreData = new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(PlayerData.S);
            SaveStoreData(StoreData);
            Debug.Log("首次创建存档");
            return;
        }

        try
        {
            var json = File.ReadAllText(path);
            StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json);
            StoreData.Player.ApplyToRuntime(PlayerData.S);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        Debug.Log("加载数据完成");
    }
}
