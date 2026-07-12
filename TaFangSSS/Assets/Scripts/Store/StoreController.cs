using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    private void Update()
    {
        CurrentTime+= Time.deltaTime;
        当前增加修为时间+= Time.deltaTime;
        PlayerData.S.道龄S += Time.deltaTime;
        if (PlayerData.S.道龄S >= 属性config.每年秒数)
        {
            PlayerData.S.道龄S = 0;
            PlayerData.S.道龄年++;
        }
        //自动保存
        if (当前增加修为时间 >= 增加修为时间)
        {
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
