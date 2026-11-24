using System;
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
    // 写盘繁忙时登记的补存请求，由主线程 Update 在当前写盘结束后补上
    private int 保存待补 = 0;
    // 后台写盘开始时间（UTC），用于看门狗超时复位
    private DateTime 后台保存开始时间 = DateTime.MinValue;
    // 每次保存的代数：用于生成唯一临时文件，并阻止卡住的旧任务覆盖新档
    private int 保存代数 = 0;
    // 最近一次通过校验的存档道龄，用于“道龄只增不减”保护
    private int 上次存盘道龄年 = -1;
    private float 上次存盘道龄S = -1f;
    // 是否已成功读档：读档成功前禁止自动保存/退出覆盖，避免默认数据覆盖正常存档
    private bool 已成功读档 = false;

     public void SaveStoreData(StoreDefine.StoreData data = null)
    {
        try
        {
            // 关键：不管磁盘写盘是否繁忙，先把当前运行时数据同步到内存快照，
            // 避免 StoreData 长期停留在旧状态。
            // 这里用 G() 而不是 S()：PlayerData 已被销毁时不能自动创建一个默认实例并写盘。
            var playerData = PlayerData.G();
            if (playerData == null)
            {
                Debug.LogError("[存盘] PlayerData 不存在，跳过本次存盘（保留磁盘现有存档）");
                return;
            }

            StoreData = data ?? StoreData ?? new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(playerData);

            // 写盘前记录关键字段，并校验道龄只增不减；明显回退时拒绝覆盖正常存档
            if (!校验并记录存盘数据("存盘", StoreData.Player))
            {
                return;
            }

            // 上一次后台写盘还没结束：登记补存，由主线程 Update 在写完后补上
            if (Interlocked.CompareExchange(ref 正在后台保存, 1, 0) != 0)
            {
                Volatile.Write(ref 保存待补, 1);
                Debug.Log("[存盘] 上一次写盘未完成，已登记补存");
                return;
            }

            后台保存开始时间 = DateTime.UtcNow;
            var 本次保存代数 = Interlocked.Increment(ref 保存代数);

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
            // 每次保存使用独立的临时文件，避免看门狗复位后新旧任务同时写同一个 .tmp
            var tmpPath = SavePath + "." + 本次保存代数 + ".tmp";
            var bakPath = BakPath;

            Task.Run(() =>
            {
                try
                {
                    // 卡住的旧任务（看门狗复位后）不允许再覆盖新档
                    if (本次保存代数 != Volatile.Read(ref 保存代数))
                    {
                        Debug.LogWarning($"[存盘] 丢弃过期保存任务 #{本次保存代数}");
                        return;
                    }

                    File.WriteAllBytes(tmpPath, jsonBytes);

                    // 落盘校验：临时文件大小必须 > 0，否则不替换主档，防止空文件覆盖正常存档
                    var tmpInfo = new FileInfo(tmpPath);
                    if (tmpInfo.Length == 0)
                    {
                        Debug.LogError("[存盘失败] 临时文件为空，跳过替换主档");
                        return;
                    }

                    if (本次保存代数 != Volatile.Read(ref 保存代数))
                    {
                        Debug.LogWarning($"[存盘] 丢弃过期保存任务 #{本次保存代数}（写盘前）");
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
                    try
                    {
                        if (File.Exists(tmpPath)) File.Delete(tmpPath);
                    }
                    catch
                    {
                        // 清理临时文件失败不影响存档
                    }
                    // 只有当前代数的任务才允许清除繁忙标志，避免旧任务的 finally 误清新任务的标志
                    if (本次保存代数 == Volatile.Read(ref 保存代数))
                    {
                        Volatile.Write(ref 正在后台保存, 0);
                    }
                }
            });
        }
        catch (System.Exception e)
        {
            Volatile.Write(ref 正在后台保存, 0);
            Debug.LogError($"[存盘失败] SaveStoreData 异常: {e}");
        }
    }

    /// <summary>
    /// 写盘前记录关键字段，并校验道龄只增不减（道龄只会增加，不会减少）。
    /// 明显回退通常意味着退出时 PlayerData 已被默认实例替换，此时拒绝覆盖正常存档。
    /// </summary>
    private bool 校验并记录存盘数据(string 来源, StoreDefine.PlayData p)
    {
        Debug.Log($"[{来源}] 写入前 道龄={p.道龄年}年+{p.道龄S:F1}S, 境界={p.当前轮回境界}, Name={p.Name}");

        if (上次存盘道龄年 >= 0)
        {
            bool 回退 = p.道龄年 < 上次存盘道龄年 ||
                        (p.道龄年 == 上次存盘道龄年 && p.道龄S + 0.01f < 上次存盘道龄S);
            if (回退)
            {
                Debug.LogError($"[{来源}] 道龄回退（{上次存盘道龄年}年+{上次存盘道龄S:F1}S -> {p.道龄年}年+{p.道龄S:F1}S），拒绝覆盖");
                return false;
            }
        }

        上次存盘道龄年 = p.道龄年;
        上次存盘道龄S = p.道龄S;
        return true;
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
            // 先等后台写盘结束，避免退出后还有旧快照在写
            等待后台保存完成(5f);

            // 本次没有成功读档，说明运行时数据不可信（可能是默认新档），禁止覆盖磁盘存档
            if (!已成功读档)
            {
                Debug.LogError("[退出存盘] 本次未成功读档，保留磁盘现有存档，跳过本次覆盖");
                return;
            }

            // 关键：用 G() 而非 S()。XSingleton 在 Editor 的 OnApplicationQuit 里
            // 会 DestroyImmediate 单例，若 PlayerData 已被销毁，S() 会自动 new 一个
            // 全默认值的 PlayerData，把默认值写进存档 → 下次进游戏进度从 0 开始。
            // G() 不自动创建；已销毁时直接跳过，绝不能用旧 StoreData 覆盖磁盘存档。
            var playerData = PlayerData.G();
            if (playerData == null)
            {
                Debug.LogError("[退出存盘] PlayerData 已销毁，保留磁盘现有存档，跳过本次覆盖");
                return;
            }

            StoreData = StoreData ?? new StoreDefine.StoreData();
            StoreData.Player.CopyFromRuntime(playerData);

            // 写盘前记录关键字段，并校验道龄只增不减
            if (!校验并记录存盘数据("退出存盘", StoreData.Player))
            {
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
            var 本次保存代数 = Interlocked.Increment(ref 保存代数);
            var tmpPath = SavePath + "." + 本次保存代数 + ".tmp";
            var bakPath = BakPath;
            File.WriteAllBytes(tmpPath, jsonBytes);
            if (new FileInfo(tmpPath).Length == 0)
            {
                Debug.LogError("[退出存盘] 临时文件为空，跳过替换");
                try { File.Delete(tmpPath); } catch { }
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

            // 成功后临时文件已被 Replace/Move 消费；失败时清理残留
            try
            {
                if (File.Exists(tmpPath)) File.Delete(tmpPath);
            }
            catch
            {
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
                item.Value.当前道年 += (1f + 属性config.仙子总属性.孵化时间缩减 / 100f) / 属性config.每年秒数;
                if (item.Value.当前道年 >= item.Value.需要道年)
                {
                    灵兽坊Config.Get孵化灵兽(item.Value.父, item.Value.母);
                    PlayerData.S.任务完成字典[任务Type.灵兽孵化] = true;
                    ObserverModuleManager.S.SendEvent("刷新任务栏");

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
            生长速度 *= 1 + 属性config.仙子总属性.灵植生长速度 / 100f;

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
                异化概率 *= 1 + 属性config.仙子总属性.灵植变异概率 / 100f;
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

        PlayerData.S.灵兽蛋数量 += 灵兽蛋速度 * (1f + 属性config.仙子总属性.灵兽蛋数量增加 / 100f) / 属性config.每年秒数;
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
            item.道龄 += 1f * (1f + 属性config.仙子总属性.灵兽生长速度 / 100f);
        }
    }
    private void Update()
    {
        // 后台写盘看门狗 + 补存：避免一次卡死的写盘导致后续所有保存被永久跳过
        刷新后台保存状态();

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
            PlayerData.S.剩余传道次数 += 1 + Mathf.RoundToInt(属性config.仙子总属性.每道年传道次数翻倍);
            坊市Config.刷新坊市列表();
            ObserverModuleManager.S.SendEvent("刷新坊市窗口");
            if (PlayerData.S.当前体质 == 体质Type.长生道体)
            {
                PlayerData.S.长生道体年数++;
            }
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

            悟道崖灵石消耗();
            灵矿场();
            //炼制丹药();
            参悟大道();
            增加道场资源();
            灵兽孵化();
            灵植生长();
        }
        if (CurrentTime >= StoreTime)
        {
            CurrentTime = 0;
            // 读档成功前禁止自动保存，避免默认数据把正常存档覆盖掉
            if (已成功读档)
            {
                SaveStoreData();
            }
            else
            {
                Debug.LogWarning("[存盘] 尚未成功读档，跳过本次自动保存");
            }
        }
    }

    /// <summary>
    /// 主线程每帧调用：后台写盘超时看门狗 + 执行补存。
    /// </summary>
    private void 刷新后台保存状态()
    {
        if (Volatile.Read(ref 正在后台保存) == 1 &&
            (DateTime.UtcNow - 后台保存开始时间).TotalSeconds > 10)
        {
            Debug.LogError("[存盘] 后台写盘超过10秒未完成，强制复位保存标志");
            Volatile.Write(ref 正在后台保存, 0);
        }

        if (Volatile.Read(ref 保存待补) == 1 && Volatile.Read(ref 正在后台保存) == 0)
        {
            Volatile.Write(ref 保存待补, 0);
            Debug.Log("[存盘] 执行补存");
            SaveStoreData();
        }
    }

    public void 悟道崖灵石消耗()
    {
        // 没有在参悟大道时不消耗灵石
        if (PlayerData.S.当前参悟大道Type == 大道Type.None) return;

        // 实际加经验的可能是递归到的前置大道，优先按前置大道的等阶计算消耗
        大道Type 消耗大道 = PlayerData.S.当前前置参悟大道Type != 大道Type.None
            ? PlayerData.S.当前前置参悟大道Type
            : PlayerData.S.当前参悟大道Type;
        float 每秒消耗 = 悟道崖Config.悟道崖灵石消耗[悟道崖Config.大道配置[消耗大道].大道等级Type] / 属性config.每年秒数;

        if (PlayerData.S.PropListDic[PropType.灵石] < 每秒消耗)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast","悟道崖灵石不足，参悟大道中止");
            //终止参悟大道
            PlayerData.S.当前参悟大道Type = 大道Type.None;
            PlayerData.S.当前前置参悟大道Type = 大道Type.None;
            ObserverModuleManager.S.SendEvent("刷新悟道崖界面");
            ObserverModuleManager.S.SendEvent("刷新悟道崖当前悟道界面");
            return;
        }

        PlayerData.S.PropListDic[PropType.灵石]-=每秒消耗;
    }
    public void 灵矿场()
    {
        灵矿场挖掘();
        灵矿场固定收益();
        灵矿场矿工挖宝();
        灵矿场矿工成长();
        ObserverModuleManager.S.SendEvent("刷新开采信息");
    }

    public void 灵矿场挖掘()
    {
        float 每秒挖掘速度 = 灵矿场Config.Get总挖掘速度() / 属性config.每年秒数;
        PlayerData.S.灵矿场当前米数 += 每秒挖掘速度;
    }

    public void 灵矿场矿工挖宝()
    {
        foreach (var item in PlayerData.S.矿工列表)
        {
            item.当前挖宝时间 += 1f / 属性config.每年秒数;
            if (item.当前挖宝时间 >= 灵矿场Config.Get矿工挖宝箱时间(item))
            {
                灵矿场Config.矿工挖宝();
                item.当前挖宝时间 = 0;
            }
        }
    }
    
    public void 灵矿场矿工成长()
    {
        foreach (var item in PlayerData.S.矿工列表)
        {
            item.经验 += 灵矿场Config.Get矿工每道年增加经验(item) / 属性config.每年秒数;
            if (item.经验 >= 灵矿场Config.矿工经验表[item.等级])
            {
                item.经验 -= 灵矿场Config.矿工经验表[item.等级];
                item.等级++;
            }
        }
    }

    public void 灵矿场固定收益()
    {
        float 每秒固定收益 = 灵矿场Config.Get总固定收益() / 属性config.每年秒数;
        PlayerData.S.PropListDic[PropType.灵石] += 每秒固定收益;
    }
    public void 解锁大道()
    {
        foreach (var item in 悟道崖Config.大道配置)
        {
            if (item.Value.大道等级Type > 大道等级Type.基础大道&&PlayerData.S.大道配置[item.Key].等级==0)
            {
                var list=悟道崖Config.大道限制列表[item.Key];
                bool 解锁 = true;
                foreach (var 大道 in  list)
                {
                    if (PlayerData.S.大道配置[大道].等级 < 悟道崖Config.大道解锁等级)
                    {
                        解锁 = false;
                        break;
                    }
                }
                if (解锁)
                {
                    PlayerData.S.大道配置[item.Key].等级 = 1;
                    if (item.Value.大道等级Type == 大道等级Type.上等大道)
                    {
                        PlayerData.S.任务完成字典[任务Type.解锁上等大道] = true;
                        ObserverModuleManager.S.SendEvent("刷新任务栏");

                    }
                    else if (item.Value.大道等级Type == 大道等级Type.至尊大道)
                    {
                        PlayerData.S.任务完成字典[任务Type.解锁至尊大道] = true;
                        ObserverModuleManager.S.SendEvent("刷新任务栏");

                    }
                }
            }
        }
    }
    public void 参悟大道()
    {
        if (PlayerData.S.当前参悟大道Type != 大道Type.None)
        {
            递归参悟大道(PlayerData.S.当前参悟大道Type);
        }
        解锁大道();
        ObserverModuleManager.S.SendEvent("刷新悟道崖界面");
        ObserverModuleManager.S.SendEvent("刷新悟道崖当前悟道界面");
        ObserverModuleManager.S.SendEvent("刷新悟道崖果位界面");

    }

    /// <summary>
    /// 递归参悟指定大道。若前置大道等级不足，则自动参悟第一个不满足的前置大道。
    /// 目标大道从 N 级升到 N+1 级，需要所有前置大道 >= N * 大道前置等级。
    /// </summary>
    private void 递归参悟大道(大道Type type)
    {
        var 配置 = 悟道崖Config.大道配置[type];
        var 玩家数据 = PlayerData.S.大道配置[type];

        // 基础大道无前置，直接参悟自己
        if (配置.大道等级Type == 大道等级Type.基础大道)
        {
            PlayerData.S.当前前置参悟大道Type = type;
            给大道加经验(type);
            return;
        }

        // 高阶大道：检查前置是否满足升到下一级的条件
        int 当前等级 = (int)玩家数据.等级;
        int 要求前置等级 = 当前等级 * 悟道崖Config.大道前置等级; // 升到 level+1 需要前置 level*10 级

        var 前置list = 悟道崖Config.大道限制列表[type];
        大道Type 不足的前置 = 大道Type.None;
        foreach (var 前置 in 前置list)
        {
            if (PlayerData.S.大道配置[前置].等级 < 要求前置等级)
            {
                不足的前置 = 前置;
                break;
            }
        }

        if (不足的前置 != 大道Type.None)
        {
            // 前置不足，递归下去参悟那个前置（最底层会把当前前置参悟大道Type设到真正加经验的那个）
            递归参悟大道(不足的前置);
        }
        else
        {
            // 前置都满足了，参悟自己
            PlayerData.S.当前前置参悟大道Type = type;
            给大道加经验(type);
        }
    }

    private void 给大道加经验(大道Type type)
    {
        var 配置 = 悟道崖Config.大道配置[type];
        var 玩家数据 = PlayerData.S.大道配置[type];
        float 经验需求 = 悟道崖Config.大道经验[配置.大道等级Type];

        玩家数据.经验 += JingJieConfig.每秒增加修为;
        while (玩家数据.经验 >= 经验需求)
        {
            玩家数据.经验 -= 经验需求;
            玩家数据.等级++;
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
                法器打造Item 当前打造 = PlayerData.S.打造List[0];
                // 材料在加入打造队列时已扣除；品质在打造完成时随机赋予
                QualityType 成品品质 = 法器Config.Random品质(当前打造.阶数);
                if (Random.Range(0f, 100f) < 属性config.仙子总属性.加荒品打造概率)
                {
                    成品品质 = QualityType.荒品;
                }
                PlayerData.S.法器列表.Add(法器Config.Get坊市法器(当前打造.法器Type, 成品品质, 当前打造.阶数));
                if (Random.Range(0f, 100f) < 属性config.仙子总属性.一炉双器概率)
                {
                    PlayerData.S.法器列表.Add(法器Config.Get坊市法器(当前打造.法器Type, 成品品质, 当前打造.阶数));
                }
                // 打造完成提示，并刷新背包法器列表
                //ObserverModuleManager.S.SendEvent("SendUIToast", 法器Config.Get法器Name(当前打造.法器Type, 当前打造.阶数), 成品品质, 1);
                PlayerData.S.任务完成字典[任务Type.打造一件法器] = true;
                ObserverModuleManager.S.SendEvent("刷新任务栏");

                ObserverModuleManager.S.SendEvent("刷新背包");
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
                var 当前炼制 = PlayerData.S.丹药炼制List[0];
                QualityType 材料品质 = 丹药Config.Get材料品质(当前炼制.阶数);
                int 单种数量 = 丹药Config.Get单种材料数量(当前炼制.阶数);
                bool 是造化丹药 = 丹药Config.丹药类型Dic[当前炼制.丹药Type] == 丹药类型.造化丹药;

                // ========== 1. 材料校验 ==========
                if (是造化丹药)
                {
                    // 造化丹药校验灵植库存
                    if (丹药Config.造化丹药灵植Dic.TryGetValue(材料品质, out var 灵植Types))
                    {
                        foreach (var lt in 灵植Types)
                        {
                            float 普通库存 = PlayerData.S.普通收获Dic.TryGetValue(lt, out var 普通数) ? 普通数 : 0;
                            float 变异库存 = PlayerData.S.变异收获Dic.TryGetValue(lt, out var 变异数) ? 变异数 : 0;
                            if ((int)MathF.Floor((普通库存 + 变异库存) / 单种数量) <= 0)
                            {
                                ObserverModuleManager.S.SendEvent("SendUIToast", "灵植数量不足,炼制终止");
                                PlayerData.S.丹药炼制List.Clear();
                                return;
                            }
                        }
                    }
                }
                else
                {
                    // 普通丹药校验灵药库存（固定品质）
                    foreach (var lt in 丹药Config.丹方Dic[当前炼制.丹药Type])
                    {
                        if (PlayerData.S.Get灵药数量(lt, 材料品质) < 单种数量)
                        {
                            ObserverModuleManager.S.SendEvent("SendUIToast", "灵药数量不足,炼制终止");
                            PlayerData.S.丹药炼制List.Clear();
                            return;
                        }
                    }
                }

                // ========== 2. 扣材料 ==========
                if (是造化丹药)
                {
                    if (丹药Config.造化丹药灵植Dic.TryGetValue(材料品质, out var 灵植Types))
                    {
                        foreach (var lt in 灵植Types)
                        {
                            // 优先扣普通，不够再扣变异
                            float 普通库存 = PlayerData.S.普通收获Dic.TryGetValue(lt, out var 普通数) ? 普通数 : 0;
                            float 普通扣除 = Math.Min(普通数, 单种数量);
                            PlayerData.S.普通收获Dic[lt] = 普通库存 - 普通扣除;
                            float 剩余需扣 = 单种数量 - 普通扣除;
                            if (剩余需扣 > 0)
                            {
                                float 变异库存 = PlayerData.S.变异收获Dic.TryGetValue(lt, out var 变异数) ? 变异数 : 0;
                                PlayerData.S.变异收获Dic[lt] = Math.Max(0, 变异库存 - 剩余需扣);
                            }
                        }
                    }
                }
                else
                {
                    foreach (var lt in 丹药Config.丹方Dic[当前炼制.丹药Type])
                    {
                        int 当前库存 = PlayerData.S.Get灵药数量(lt, 材料品质);
                        PlayerData.S.Set灵药数量(lt, 材料品质, 当前库存 - 单种数量);
                    }
                }

                // ========== 3. 成品品质随机 ==========
                QualityType 成品品质 = 丹药Config.随机品质();
                // 仙子属性提升品质概率（在随机结果上再+1阶）
                if (Random.Range(0f, 100f) < 属性config.仙子总属性.提升品质概率)
                {
                    成品品质 = (QualityType)Mathf.Min((int)成品品质 + 1, (int)QualityType.荒品);
                }
                // 仙子属性提升阶数概率：不再影响成品阶段，保持玩家选的阶数

                // 一炉双丹概率
                int 出炉数量 = Random.Range(0f, 100f) < 属性config.仙子总属性.一炉双丹概率 ? 2 : 1;

                // ========== 4. 增加丹药库存 ==========
                PlayerData.S.Set丹药数量(当前炼制.丹药Type, 成品品质,
                    PlayerData.S.Get丹药数量(当前炼制.丹药Type, 成品品质, 当前炼制.阶数) + 出炉数量, 当前炼制.阶数);

                // ========== 5. 炼丹经验 ==========
                float 获得经验 = 丹药Config.Get炼制经验(当前炼制.丹药Type, 当前炼制.阶数);
                PlayerData.S.炼丹经验 += (long)获得经验;
                PlayerData.S.任务完成字典[任务Type.炼制丹药] = true;
                ObserverModuleManager.S.SendEvent("刷新任务栏");


                // ========== 6. 炼丹等级升级 ==========
                if (PlayerData.S.炼丹经验 >= 丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级])
                {
                    PlayerData.S.炼丹经验 -= 丹药Config.炼丹等级经验Dic[PlayerData.S.炼丹等级];
                    PlayerData.S.炼丹等级++;
                }

                ObserverModuleManager.S.SendEvent("炼制刷新");
                当前炼制.count--;
                当前炼制.进度 = 0;
                if (当前炼制.count <= 0)
                {
                    PlayerData.S.丹药炼制List.RemoveAt(0);
                }
            }
            else
            {
                // 炼制进度推进：按阶数取炼制时间
                float 炼制需要秒数 = 丹药Config.Get炼制时间(PlayerData.S.丹药炼制List[0].丹药Type, PlayerData.S.丹药炼制List[0].阶数);
                PlayerData.S.丹药炼制List[0].进度 += 10f / 炼制需要秒数;
            }
        }
        ObserverModuleManager.S.SendEvent("刷新丹药炼制区域");
    }

    public float Get法器打造时间()
    {
        // 打造时间只与阶数有关；阶数缺失时按1阶兜底，避免旧数据索引崩溃
        if (!法器Config.法器打造时间.TryGetValue(PlayerData.S.打造List[0].阶数, out float 基础道年))
        {
            基础道年 = 法器Config.法器打造时间[1];
        }
        float value=基础道年 * 属性config.每年秒数;
        // 炼器室等级提供的炼器速度加成
        value /= (1f + 道场Config.炼器室配置[PlayerData.S.建筑等级Dic[建筑Type.炼器室]].速度加成/100f);
        value /= (1f + 道场Config.供奉总属性.炼器速度/100f);
        value /=(1f+体质Config.当前体质总属性.炼器速度/100f);
        value /=(1f+属性config.仙子总属性.炼器速度/100f);
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
                        ObserverModuleManager.S.SendEvent("通天塔英雄派遣Item刷新");
                        PlayerData.S.任务完成字典[任务Type.通天塔寻宝] = true;
                        ObserverModuleManager.S.SendEvent("刷新任务栏");


                    }
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
                        PlayerData.S.任务完成字典[任务Type.九幽血海寻宝] = true;
                        ObserverModuleManager.S.SendEvent("刷新任务栏");

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
                        PlayerData.S.任务完成字典[任务Type.世界树寻宝] = true;
                        ObserverModuleManager.S.SendEvent("刷新任务栏");

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
        已成功读档 = false;
        // 依次尝试：主档 → 备份档（.bak，断电/损坏时的救命稻草）→ 全新档
        if (TryLoad(SavePath))
        {
            Debug.Log($"[读档] 主档加载成功: {SavePath}");
            // 读档成功后立即清掉主档/备份档可能带的只读属性：
            // 旧版本玩家手动拷入的存档常是只读，导致后续 File.Replace 全部失败、进度不保存。
            // 这里在加载阶段就自愈，玩家更新到新版本后启动一次即可恢复正常保存。
            清除存档只读属性(SavePath);
            清除存档只读属性(BakPath);
            已成功读档 = true;
            return;
        }

        Debug.LogWarning($"[读档] 主档加载失败，尝试备份档: {BakPath}");
        if (TryLoad(BakPath))
        {
            Debug.Log($"[读档] 备份档加载成功，写回主档");
            清除存档只读属性(BakPath);
            // 立即把恢复的数据写回主档，避免下次启动再次走备份
            SaveStoreData(StoreData);
            已成功读档 = true;
            return;
        }

        Debug.LogError($"[读档] 主档与备份档均加载失败，创建全新存档！主档存在={File.Exists(SavePath)}, 备份档存在={File.Exists(BakPath)}");
        StoreData = new StoreDefine.StoreData();
        StoreData.Player.CopyFromRuntime(PlayerData.S);
        SaveStoreData(StoreData);
        已成功读档 = true;
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
            // 以读到的存档作为“道龄只增不减”的基线
            上次存盘道龄年 = data.Player.道龄年;
            上次存盘道龄S = data.Player.道龄S;
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
