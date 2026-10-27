using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Config;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class StoreController : XSingleton<StoreController>
{
    public StoreDefine.StoreData StoreData;
    private string SavePath =>Path.Combine(Application.persistentDataPath, "TaFangStorePlaytest1.json");
    // 原子写入用的临时文件；.bak 是上一次保存成功的主档，断电/损坏时用它恢复
    private string TmpPath => SavePath + ".tmp";
    private string BakPath => SavePath + ".bak";
    // 自动保存间隔 30 秒：流式写入后单次分配已很小，落盘频率也可以降下来；
    // 退出游戏时 等待后台保存完成() 会兜底，最多损失最后 30 秒内的进度
    private float StoreTime = 30;
    private float CurrentTime = 0;
    private float 增加修为时间 = 1;
    private float 当前增加修为时间 = 0;
    private float 坊市刷新次数时间 = 0;
    private float 法器打造当前时间 = 0;
    // 后台保存状态：0=空闲 1=序列化/落盘中；防重入、导出与退出同步都靠它
    private int 正在后台保存 = 0;

     public void SaveStoreData(StoreDefine.StoreData data = null)
    {
        try
        {
            // 先检查是否有后台落盘在进行：忙则跳过本次序列化，
            // 避免主线程白白卡几百毫秒又丢弃结果
            if (Interlocked.CompareExchange(ref 正在后台保存, 1, 0) != 0)
            {
                return;
            }

            StoreData = data ?? StoreData ?? new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(PlayerData.S);
            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Newtonsoft.Json.Formatting.None,
                Converters = { new BigDoubleJsonConverter() }
            };

            // 序列化必须在主线程完成：CopyFromRuntime 里所有字典/列表都是共享引用，
            // 后台序列化时主线程若修改集合（购买/收获/服用）会抛 Collection was modified，
            // 被 catch 静默吞掉 → 存盘失败 → 退出后进度丢失。
            // 改为主线程序列化到 MemoryStream，后台只负责落盘，彻底避免并发修改。
            byte[] jsonBytes;
            using (var ms = new System.IO.MemoryStream())
            using (var streamWriter = new StreamWriter(ms))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                var serializer = JsonSerializer.Create(settings);
                serializer.Serialize(jsonWriter, StoreData);
                jsonWriter.Flush();
                streamWriter.Flush();
                jsonBytes = ms.ToArray();
            }

            // 序列化结果为空（异常或数据全空）则不落盘，避免用空文件覆盖正常存档
            if (jsonBytes == null || jsonBytes.Length == 0)
            {
                Debug.LogError("[存盘失败] 序列化结果为空，跳过落盘");
                Volatile.Write(ref 正在后台保存, 0);
                return;
            }

            var savePath = SavePath;
            var tmpPath = TmpPath;
            var bakPath = BakPath;

            Task.Run(() =>
            {
                try
                {
                    File.WriteAllBytes(tmpPath, jsonBytes);

                    // 落盘校验：临时文件大小必须 > 0，否则不替换主档，防止空文件覆盖正常存档
                    var tmpInfo = new FileInfo(tmpPath);
                    if (tmpInfo.Length == 0)
                    {
                        Debug.LogError("[存盘失败] 临时文件为空，跳过替换主档");
                        return;
                    }

                    if (File.Exists(savePath))
                    {
                        if ((File.GetAttributes(savePath) & FileAttributes.ReadOnly) != 0)
                        {
                            File.SetAttributes(savePath, FileAttributes.Normal);
                        }
                        if (File.Exists(bakPath) && (File.GetAttributes(bakPath) & FileAttributes.ReadOnly) != 0)
                        {
                            File.SetAttributes(bakPath, FileAttributes.Normal);
                        }
                        try
                        {
                            File.Replace(tmpPath, savePath, bakPath, true);
                        }
                        catch (System.Exception replaceEx)
                        {
                            // File.Replace 在杀毒/云盘锁文件时可能失败；退化为 Copy 覆盖，
                            // 确保主档至少被更新（备份可能不更新，但主档是最新的）
                            Debug.LogWarning($"[存盘] File.Replace 失败，退化为 Copy 覆盖: {replaceEx.Message}");
                            File.Copy(tmpPath, savePath, true);
                        }
                    }
                    else
                    {
                        File.Move(tmpPath, savePath);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning($"[存盘失败] 后台落盘异常: {e.Message}");
                }
                finally
                {
                    Volatile.Write(ref 正在后台保存, 0);
                }
            });
        }
        catch (System.Exception e)
        {
            Volatile.Write(ref 正在后台保存, 0);
            Debug.LogError($"[存盘失败] SaveStoreData 异常: {e}");
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
        var settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            Converters = { new BigDoubleJsonConverter() }
        };
        StoreData = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json, settings);
        return StoreData;
    }

    /// <summary>
    /// 等待后台保存落盘完成：导出存档前必须等（否则拷到的是上一份），
    /// 退出游戏前也等（否则最后一次保存可能没写完进程就结束了）
    /// </summary>
    public void 等待后台保存完成(float 超时秒 = 5f)
    {
        var 截止 = Time.realtimeSinceStartup + 超时秒;
        while (Volatile.Read(ref 正在后台保存) == 1 && Time.realtimeSinceStartup < 截止)
        {
            Thread.Sleep(20);
        }
    }

    private void OnApplicationQuit()
    {
        // 退出前同步存盘一次，确保最后进度落盘。
        // 直接走同步落盘（不走后台 Task.Run），避免进程被杀时后台任务来不及写完。
        try
        {
            // 关键：用 G() 而非 S()。XSingleton 在 Editor 的 OnApplicationQuit 里
            // 会 DestroyImmediate 单例，若 PlayerData 已被销毁，S() 会自动 new 一个
            // 全默认值的 PlayerData，把默认值写进存档 → 下次进游戏进度从 0 开始。
            // G() 不自动创建，已销毁则返回 null，此时沿用 StoreData 里上一次定时存盘的快照。
            var playerData = PlayerData.G();
            if (playerData != null)
            {
                StoreData = StoreData ?? new StoreDefine.StoreData();
                StoreData.Player.CopyFromRuntime(playerData);
            }
            else if (StoreData == null)
            {
                // 既没有 PlayerData 也没有 StoreData，无法存盘
                Debug.LogWarning("[退出存盘] PlayerData 与 StoreData 均为空，跳过存盘");
                return;
            }

            var settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Newtonsoft.Json.Formatting.None,
                Converters = { new BigDoubleJsonConverter() }
            };
            byte[] jsonBytes;
            using (var ms = new System.IO.MemoryStream())
            using (var streamWriter = new StreamWriter(ms))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                var serializer = JsonSerializer.Create(settings);
                serializer.Serialize(jsonWriter, StoreData);
                jsonWriter.Flush();
                streamWriter.Flush();
                jsonBytes = ms.ToArray();
            }
            if (jsonBytes == null || jsonBytes.Length == 0)
            {
                Debug.LogError("[退出存盘] 序列化结果为空，跳过");
                return;
            }
            var savePath = SavePath;
            var tmpPath = TmpPath;
            var bakPath = BakPath;
            File.WriteAllBytes(tmpPath, jsonBytes);
            if (new FileInfo(tmpPath).Length == 0)
            {
                Debug.LogError("[退出存盘] 临时文件为空，跳过替换");
                return;
            }
            if (File.Exists(savePath))
            {
                if ((File.GetAttributes(savePath) & FileAttributes.ReadOnly) != 0)
                    File.SetAttributes(savePath, FileAttributes.Normal);
                if (File.Exists(bakPath) && (File.GetAttributes(bakPath) & FileAttributes.ReadOnly) != 0)
                    File.SetAttributes(bakPath, FileAttributes.Normal);
                try
                {
                    File.Replace(tmpPath, savePath, bakPath, true);
                }
                catch (System.Exception replaceEx)
                {
                    Debug.LogWarning($"[退出存盘] File.Replace 失败，退化为 Copy: {replaceEx.Message}");
                    File.Copy(tmpPath, savePath, true);
                }
            }
            else
            {
                File.Move(tmpPath, savePath);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[退出存盘失败] {e}");
        }
    }

    /// <summary>
    /// 导出存档：先把当前进度保存到本地，再复制一份到桌面，返回导出文件路径。
    /// </summary>
    public string 导出存档()
    {
        // 先落盘（保存已改为后台线程，必须等它写完再拷贝），
        // 保证导出的是最新进度
        SaveStoreData();
        等待后台保存完成();

        string 存档名 = $"塔防刷刷刷存档_{StoreData.Player.Name}_{DateTime.Now:yyyyMMdd_HHmmss}";
        foreach (var c in Path.GetInvalidFileNameChars())
        {
            存档名 = 存档名.Replace(c, '_');
        }

        string 导出路径 = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            存档名 + ".json");

        File.Copy(SavePath, 导出路径, true);
        return 导出路径;
    }

    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private float timer = 0;

    public void 减少辅助丹药时间()
    {
        // 逐品质逐阶段衰减：每种辅助丹药只能服用一颗，实际最多一个 key 非零
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= PlayerData.Get丹药最高阶段((QualityType)i); j++)
            {
                if (PlayerData.S.Get辅助丹药Buff(丹药Type.修炼速度,(QualityType)i,j) > 0)
                {
                    PlayerData.S.Set辅助丹药Buff(丹药Type.修炼速度,(QualityType)i,PlayerData.S.Get辅助丹药Buff(丹药Type.修炼速度,(QualityType)i,j)-1,j);
                }
                if (PlayerData.S.Get辅助丹药Buff(丹药Type.掉宝率,(QualityType)i,j) > 0)
                {
                    PlayerData.S.Set辅助丹药Buff(丹药Type.掉宝率,(QualityType)i,PlayerData.S.Get辅助丹药Buff(丹药Type.掉宝率,(QualityType)i,j)-1,j);
                }
            }
        }
    }

    public void 每道年供奉申请()
    {
        var 申请list = 道场Config.Get每道年供奉申请列表();
        foreach (var item in 申请list)
        {
            switch (item.供奉品质Type)
            {
                case 供奉品质Type.凡:
                    if (!PlayerData.S.自动拒绝凡品供奉 && PlayerData.S.供奉申请列表.Count <
                        道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数)
                    {
                        PlayerData.S.供奉申请列表.Add(item);
                    }
                    break;
                case 供奉品质Type.灵:
                    if (!PlayerData.S.自动拒绝灵品供奉 && PlayerData.S.供奉申请列表.Count <
                        道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数)
                    {
                        PlayerData.S.供奉申请列表.Add(item);
                    }
                    break;
                case 供奉品质Type.仙:
                    if (!PlayerData.S.自动拒绝仙品供奉 && PlayerData.S.供奉申请列表.Count <
                        道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数)
                    {
                        PlayerData.S.供奉申请列表.Add(item);
                    }
                    break;
                case 供奉品质Type.圣:
                    if (!PlayerData.S.自动拒绝圣品供奉 && PlayerData.S.供奉申请列表.Count <
                        道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数)
                    {
                        PlayerData.S.供奉申请列表.Add(item);
                    }
                    break;
                case 供奉品质Type.道:
                    if ( PlayerData.S.供奉申请列表.Count < 道场Config.领主府配置[PlayerData.S.建筑等级Dic[建筑Type.领主府]].供奉申请个数)
                    {
                        PlayerData.S.供奉申请列表.Add(item);
                    }
                    break;
            }
        }
    }

    public void 灵兽孵化()
    {
        foreach (var item in PlayerData.S.孵化池列表)
        {
            if (item.Value.孵化中)
            {
                item.Value.当前道年 += 1 / 属性config.每年秒数;
                if (item.Value.当前道年 >= item.Value.需要道年)
                {
                    灵兽坊Config.Get孵化灵兽(item.Value.父, item.Value.母);
                    item.Value.当前道年 = 0;
                }
            }
        }
        ObserverModuleManager.S.SendEvent("灵兽孵化");
    }
    public void 灵植生长()
    {
        foreach (var item in PlayerData.S.灵植土地列表)
        {
            var 土地 = item.Value;
            if (土地.灵植Type == 灵植Type.None) continue;
            if (土地.植物成长阶段Type == 植物成长阶段Type.成熟) continue;

            float 生长速度 = 1f;
            if (土地.提速肥料 != QualityType.None)
            {
                生长速度 += 灵植园Config.提速肥料数值[土地.提速肥料] / 100f;
            }

            // 土地速度加成与提速肥料为不同乘区
            生长速度 *= 1 + 灵植园Config.土地数值[土地.土地Type].速度 / 100f;

            土地.当前time += 生长速度 / 属性config.每年秒数;
            float 进度 = 土地.当前time / 土地.所需time;
            if (进度 >= 1f)
            {
                土地.当前time = 土地.所需time;
                土地.植物成长阶段Type = 植物成长阶段Type.成熟;
                // 成熟瞬间基础 1% 几率异化，异化肥与土地异化加成分别为不同乘区
                float 异化概率 = 1f;
                if (土地.异化肥料 != QualityType.None)
                {
                    异化概率 *= 1 + 灵植园Config.异化肥料数值[土地.异化肥料] / 100f;
                }
                异化概率 *= 1 + 灵植园Config.土地数值[土地.土地Type].异化 / 100f;
                if (Random.Range(0, 100f) < 异化概率)
                {
                    土地.变异 = true;
                }
            }
            else if (进度 >= 0.66f)
            {
                土地.植物成长阶段Type = 植物成长阶段Type.成长;
            }
            else if (进度 >= 0.33f)
            {
                土地.植物成长阶段Type = 植物成长阶段Type.幼苗;
            }
        }
        ObserverModuleManager.S.SendEvent("刷新灵植园");
    }

    public void 增加道场资源()
    {
        float 矿石速度 = 道场Config.Get矿石速度();
        float 玄铁速度 = 道场Config.Get玄铁速度();
        float 玉髓速度 = 道场Config.Get玉髓速度();
        float 功德速度 = 道场Config.Get功德速度();
        float 灵兽蛋速度 = 道场Config.Get灵兽蛋速度();
        float 矿石增加玄铁random = Random.Range(0, 100f);
        if (矿石增加玄铁random < 道场Config.供奉总属性.获得矿石概率获得玄铁)
        {
            PlayerData.S.PropListDic[PropType.玄铁] += 矿石速度 / 属性config.每年秒数;
        }
        
        float 矿石增加玉髓random = Random.Range(0, 100f);
        if (矿石增加玉髓random < 道场Config.供奉总属性.获得矿石概率获得玉髓)
        {
            PlayerData.S.PropListDic[PropType.玉髓] += 矿石速度 / 属性config.每年秒数;
        }
        
        float 玄铁增加矿石random = Random.Range(0, 100f);
        if (玄铁增加矿石random < 道场Config.供奉总属性.获得玄铁概率获得矿石)
        {
            PlayerData.S.PropListDic[PropType.矿石] += 玄铁速度 / 属性config.每年秒数;
        }
        
        float 玄铁增加玉髓random = Random.Range(0, 100f);
        if (玄铁增加玉髓random < 道场Config.供奉总属性.获得玄铁概率获得玉髓)
        {
            PlayerData.S.PropListDic[PropType.玉髓] += 玄铁速度 / 属性config.每年秒数;
        }
        
        float 玉髓增加矿石random = Random.Range(0, 100f);
        if (玉髓增加矿石random < 道场Config.供奉总属性.获得玉髓概率获得矿石)
        {
            PlayerData.S.PropListDic[PropType.矿石] += 玉髓速度 / 属性config.每年秒数;
        }
        
        float 玉髓增加玄铁random = Random.Range(0, 100f);
        if (玉髓增加玄铁random < 道场Config.供奉总属性.获得玉髓概率获得玄铁)
        {
            PlayerData.S.PropListDic[PropType.玄铁] += 玉髓速度 / 属性config.每年秒数;
        }

        PlayerData.S.灵兽蛋数量+=灵兽蛋速度 / 属性config.每年秒数;
        PlayerData.S.PropListDic[PropType.矿石] += 矿石速度 / 属性config.每年秒数;
        PlayerData.S.PropListDic[PropType.玄铁] += 玄铁速度 / 属性config.每年秒数;
        PlayerData.S.PropListDic[PropType.玉髓] += 玉髓速度 / 属性config.每年秒数;
        PlayerData.S.PropListDic[PropType.功德] += 功德速度 / 属性config.每年秒数;

        // 灵植园每道年产出青石：按建筑等级取每道年青石数，每秒折算
        int 灵植园等级 = PlayerData.S.建筑等级Dic[建筑Type.灵植园];
        if (灵植园等级 > 0 && 道场Config.灵植园配置.ContainsKey(灵植园等级))
        {
            PlayerData.S.青石 += 道场Config.灵植园配置[灵植园等级].每道年青石数 / 属性config.每年秒数;
            ObserverModuleManager.S.SendEvent("Set青石");
        }
    }

    public void 增加灵兽道龄()
    {
        foreach (var item in PlayerData.S.灵兽列表)
        {
            item.道龄++;
        }
    }
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
        坊市刷新次数时间+=Time.unscaledDeltaTime;
        法器打造当前时间+=Time.unscaledDeltaTime;
        PlayerData.S.道龄S += Time.unscaledDeltaTime;
        if (坊市刷新次数时间 >= Get坊市刷新次数时间())
        {
            坊市刷新次数时间 = 0;
            PlayerData.S.坊市刷新次数++;
        }
        if (PlayerData.S.道龄S >= 属性config.每年秒数)
        {
            增加灵兽道龄();
            每道年供奉申请();
            减少辅助丹药时间();
            ObserverModuleManager.S.SendEvent("刷新主页Buff");
            PlayerData.S.道龄S = 0;
            PlayerData.S.道龄年++;
            PlayerData.S.剩余传道次数++;
            坊市Config.刷新坊市列表();
            ObserverModuleManager.S.SendEvent("刷新坊市窗口");
        }
        //自动保存
        if (法器打造当前时间 > 0.1f)
        {
            法器打造当前时间 = 0;
            打造法器();
            炼制丹药1();
        }
        if (当前增加修为时间 >= 增加修为时间)//每秒
        {
            ObserverModuleManager.S.SendEvent("刷新坊市剩余时间");
            ObserverModuleManager.S.SendEvent("刷新主页面");
            当前增加修为时间 = 0;
            if (PlayerData.S.Exp < JingJieConfig.升级需要年数Dic[PlayerData.S.当前轮回境界] * 200&&SceneManager.GetActiveScene().name!="StartScene"&&SceneManager.GetActiveScene().name!="FirstScene")
            {
                PlayerData.S.Exp += JingJieConfig.每秒增加修为;
                ObserverModuleManager.S.SendEvent("增加修为",JingJieConfig.每秒增加修为);
            }

            if (PlayerData.S.当前体质 == 体质Type.长生道体)
            {
                PlayerData.S.长生道体年数++;
            }
            //炼制丹药();
            
            增加道场资源();
            灵兽孵化();
            灵植生长();
        }
        if (CurrentTime >= StoreTime)
        {
            CurrentTime = 0;
            SaveStoreData();
        }
    }

    public float Get坊市刷新次数时间()
    {
        float value = 属性config.每年秒数;
        value /= (1f + 道场Config.供奉总属性.坊市刷新次数时间缩减 / 100f);
        return value;
    }
    public void 打造法器()
    {
        if (PlayerData.S.打造List.Count > 0)
        {
            if (PlayerData.S.打造List[0].进度 >= 100)
            {
                List<PropType> 材料 = 法器Config.Get打造法器材料(PlayerData.S.打造List[0].法器Type);
                foreach (var item in 材料)
                {
                    if (PlayerData.S.PropListDic[item] < 1f)
                    {
                        ObserverModuleManager.S.SendEvent("SendUIToast","材料不足，法器打造终止");
                        PlayerData.S.打造List.Clear();
                        return;
                    }
                }
                foreach (var item in 材料)
                {
                    PlayerData.S.PropListDic[item]--;
                }
                PlayerData.S.法器列表.Add(法器Config.Get坊市法器(PlayerData.S.打造List[0].法器Type));
                PlayerData.S.打造List[0].count--;
                PlayerData.S.打造List[0].进度 = 0;
                if (PlayerData.S.打造List[0].count <= 0)
                {
                    PlayerData.S.打造List.RemoveAt(0);
                }
            }
            else
            {
                float 打造需要秒数 = Get法器打造时间();
                PlayerData.S.打造List[0].进度 += 10f / 打造需要秒数;
            }
        }
        ObserverModuleManager.S.SendEvent("刷新法器打造区域");
    }
    
    public void 炼制丹药1()
    {
        if (PlayerData.S.丹药炼制List.Count > 0)
        {
            if (PlayerData.S.丹药炼制List[0].进度 >= 100)
            {
                foreach (var item in 丹药Config.丹方Dic[PlayerData.S.丹药炼制List[0].丹药Type])
                {
                    if (PlayerData.S.丹药炼制List[0].黄 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.黄品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.黄品) > 0)
                        {
                            continue;
                        }
                    }
                    if (PlayerData.S.丹药炼制List[0].玄 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.玄品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.玄品) > 0)
                        {
                            continue;
                        }
                    }
                    if (PlayerData.S.丹药炼制List[0].地 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.地品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.地品) > 0)
                        {
                            continue;
                        }
                    }
                    if (PlayerData.S.丹药炼制List[0].天 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.天品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.天品) > 0)
                        {
                            continue;
                        }
                    }
                    if (PlayerData.S.丹药炼制List[0].宇 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.宇品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.宇品) > 0)
                        {
                            continue;
                        }
                    }
                    if (PlayerData.S.丹药炼制List[0].宙 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.宙品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.宙品) > 0)
                        {
                            continue;
                        }
                    }
                    if (PlayerData.S.丹药炼制List[0].洪 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.洪品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.洪品) > 0)
                        {
                            continue;
                        }
                    }
                    if (PlayerData.S.丹药炼制List[0].荒 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.荒品)
                    {
                        if (PlayerData.S.Get灵药数量(item, QualityType.荒品) > 0)
                        {
                            continue;
                        }
                    }
                    ObserverModuleManager.S.SendEvent("SendUIToast","灵药数量不足,炼制终止");
                    PlayerData.S.丹药炼制List.Clear();
                    return;
                }

                foreach (var item in 丹药Config.丹方Dic[PlayerData.S.丹药炼制List[0].丹药Type])
                {
                    // 扣减条件必须与上方校验一致：只扣数量>0的品质，否则会扣出负数
                    if (PlayerData.S.丹药炼制List[0].黄 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.黄品
                        && PlayerData.S.Get灵药数量(item, QualityType.黄品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.黄品, PlayerData.S.Get灵药数量(item, QualityType.黄品)-1);
                        continue;
                    }
                    if (PlayerData.S.丹药炼制List[0].玄 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.玄品
                        && PlayerData.S.Get灵药数量(item, QualityType.玄品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.玄品, PlayerData.S.Get灵药数量(item, QualityType.玄品)-1);
                        continue;
                    }
                    if (PlayerData.S.丹药炼制List[0].地 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.地品
                        && PlayerData.S.Get灵药数量(item, QualityType.地品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.地品, PlayerData.S.Get灵药数量(item, QualityType.地品)-1);
                        continue;
                    }
                    if (PlayerData.S.丹药炼制List[0].天 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.天品
                        && PlayerData.S.Get灵药数量(item, QualityType.天品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.天品, PlayerData.S.Get灵药数量(item, QualityType.天品)-1);
                        continue;
                    }
                    if (PlayerData.S.丹药炼制List[0].宇 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.宇品
                        && PlayerData.S.Get灵药数量(item, QualityType.宇品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.宇品, PlayerData.S.Get灵药数量(item, QualityType.宇品)-1);
                        continue;
                    }
                    if (PlayerData.S.丹药炼制List[0].宙 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.宙品
                        && PlayerData.S.Get灵药数量(item, QualityType.宙品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.宙品, PlayerData.S.Get灵药数量(item, QualityType.宙品)-1);
                        continue;
                    }
                    if (PlayerData.S.丹药炼制List[0].洪 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.洪品
                        && PlayerData.S.Get灵药数量(item, QualityType.洪品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.洪品, PlayerData.S.Get灵药数量(item, QualityType.洪品)-1);
                        continue;
                    }
                    if (PlayerData.S.丹药炼制List[0].荒 && PlayerData.S.丹药炼制List[0].丹药QualityType <= QualityType.荒品
                        && PlayerData.S.Get灵药数量(item, QualityType.荒品) > 0)
                    {
                        PlayerData.S.Set灵药数量(item, QualityType.荒品, PlayerData.S.Get灵药数量(item, QualityType.荒品)-1);
                        continue;
                    }
                }
               PlayerData.S.Set丹药数量(PlayerData.S.丹药炼制List[0].丹药Type,PlayerData.S.丹药炼制List[0].丹药QualityType,PlayerData.S.Get丹药数量(PlayerData.S.丹药炼制List[0].丹药Type,PlayerData.S.丹药炼制List[0].丹药QualityType)+1);
               PlayerData.S.炼丹经验 += 丹药Config.Get炼制丹药经验(PlayerData.S.丹药炼制List[0].丹药Type, PlayerData.S.丹药炼制List[0].丹药QualityType);
               if (PlayerData.S.炼丹经验 >= 丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级])
               {
                   PlayerData.S.炼丹经验 -= 丹药Config.炼丹经验Dic[PlayerData.S.炼丹等级];
                   PlayerData.S.炼丹等级++;
               }
               ObserverModuleManager.S.SendEvent("炼制刷新");
                PlayerData.S.丹药炼制List[0].count--;
                PlayerData.S.丹药炼制List[0].进度 = 0;
                if (PlayerData.S.丹药炼制List[0].count <= 0)
                {
                    PlayerData.S.丹药炼制List.RemoveAt(0);
                }
            }
            else
            {
                float 炼制需要秒数 = 丹药Config.Get炼制丹药需要时间(PlayerData.S.丹药炼制List[0].丹药Type,PlayerData.S.丹药炼制List[0].丹药QualityType);
                PlayerData.S.丹药炼制List[0].进度 += 10f / 炼制需要秒数;
            }
        }
        ObserverModuleManager.S.SendEvent("刷新丹药炼制区域");
    }

    public float Get法器打造时间()
    {
        float value=法器Config.法器打造时间[PlayerData.S.打造List[0].品质] * 属性config.每年秒数;
        value /= (1f + 道场Config.供奉总属性.炼器速度/100f);
        value /=(1f+体质Config.当前体质总属性.炼器速度/100f);
        return value;
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
        // 依次尝试：主档 → 备份档（.bak，断电/损坏时的救命稻草）→ 全新档
        if (TryLoad(SavePath))
        {
            Debug.Log($"[读档] 主档加载成功: {SavePath}");
            // 读档成功后立即清掉主档/备份档可能带的只读属性：
            // 旧版本玩家手动拷入的存档常是只读，导致后续 File.Replace 全部失败、进度不保存。
            // 这里在加载阶段就自愈，玩家更新到新版本后启动一次即可恢复正常保存。
            清除存档只读属性(SavePath);
            清除存档只读属性(BakPath);
            return;
        }

        Debug.LogWarning($"[读档] 主档加载失败，尝试备份档: {BakPath}");
        if (TryLoad(BakPath))
        {
            Debug.Log($"[读档] 备份档加载成功，写回主档");
            清除存档只读属性(BakPath);
            // 立即把恢复的数据写回主档，避免下次启动再次走备份
            SaveStoreData(StoreData);
            return;
        }

        Debug.LogError($"[读档] 主档与备份档均加载失败，创建全新存档！主档存在={File.Exists(SavePath)}, 备份档存在={File.Exists(BakPath)}");
        StoreData = new StoreDefine.StoreData();
        StoreData.Player.CopyFromRuntime(PlayerData.S);
        SaveStoreData(StoreData);
    }

    /// <summary>
    /// 清除指定存档文件的只读属性（若存在），保证后续 File.Replace 能成功写入。
    /// 从其他电脑/U盘/云端拷入的存档常带只读位，会让保存静默失败。
    /// </summary>
    private static void 清除存档只读属性(string path)
    {
        try
        {
            if (!File.Exists(path)) return;
            var attr = File.GetAttributes(path);
            if ((attr & FileAttributes.ReadOnly) != 0)
            {
                File.SetAttributes(path, attr & ~FileAttributes.ReadOnly);
            }
        }
        catch
        {
            // 无权限等情况忽略：保存阶段还会再尝试清一次，不影响读档
        }
    }

    /// <summary>
    /// 尝试从指定路径读档并应用到运行时；任何异常都不外抛，返回是否成功
    /// </summary>
    private bool TryLoad(string path)
    {
        if (!File.Exists(path)) return false;
        try
        {
            var json = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(json)) return false;
            var loadSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Converters = { new BigDoubleJsonConverter() }
            };
            var data = JsonConvert.DeserializeObject<StoreDefine.StoreData>(json, loadSettings);
            if (data?.Player == null) return false;
            StoreData = data;
            StoreData.Player.ApplyToRuntime(PlayerData.S);
            // 历史存档可能存在负数资源（如石白=-2导致打造数量显示为负），读档时统一清理
            var 负数keys = new List<PropType>();
            foreach (var kv in PlayerData.S.PropListDic)
            {
                if (kv.Value < 0) 负数keys.Add(kv.Key);
            }
            foreach (var key in 负数keys)
            {
                PlayerData.S.PropListDic[key] = 0;
            }
            // 灵药Dic同样清理（旧版炼丹扣减无>0校验会扣出负数，导致炼制数量Slider的maxValue为负而崩溃）
            var 负数灵药keys = new List<string>();
            foreach (var kv in PlayerData.S.灵药Dic)
            {
                if (kv.Value < 0) 负数灵药keys.Add(kv.Key);
            }
            foreach (var key in 负数灵药keys)
            {
                PlayerData.S.灵药Dic[key] = 0;
            }
            return true;
        }
        catch (Exception e)
        {
            // 读档失败时打出异常与文件信息，定位是 JSON 结构问题还是某个字段反序列化报错
            Debug.LogError($"[读档失败] path={path}, size={(File.Exists(path) ? new FileInfo(path).Length : -1)}字节, 异常={e}");
            return false;
        }
    }
}
