using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>赌坊主界面：赌坊切换、仓库生成/揭晓、道具使用、轮数与买下</summary>
public class 赌坊界面 : MonoBehaviour
{
    public Button 退出按钮;
    public Button 下一轮按钮;
    public Button 买下按钮;
    public Button 换仓按钮;

    public Button 确认button;
    public Button 返回button;
    public GameObject 确认更换赌坊提示弹窗;

    public GameObject 赌坊列表Content;
    public GameObject 商店Content;
    public GameObject 道具背包Content;

    public RectTransform 底格content;
    public 随机占格背包 藏品背包;

    public TextMeshProUGUI 当前轮数;
    public TextMeshProUGUI 仓库价格;
    public TextMeshProUGUI 当前灵气;
    public TextMeshProUGUI 当前灵气底部;

    private 赌坊Type 待切换赌坊 = 赌坊Type.None;
    private readonly Dictionary<QualityType, List<藏品Type>> 品质候选缓存 = new Dictionary<QualityType, List<藏品Type>>();

    private void Awake()
    {
        // 仓库生成完全由本界面控制，避免随机占格背包在启用时自己随机一次
        if (藏品背包 != null)
        {
            藏品背包.开启时随机 = false;
        }
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("赌坊Item点击", 赌坊Item点击);
        ObserverModuleManager.S.RegisterEvent("赌坊道具Item点击", 道具Item点击);

        if (退出按钮 != null)
        {
            退出按钮.onClick.AddListener(() =>
            {
                隐藏确认弹窗();
                gameObject.SetActive(false);
            });
        }

        if (下一轮按钮 != null) 下一轮按钮.onClick.AddListener(下一轮);
        if (买下按钮 != null) 买下按钮.onClick.AddListener(买下);
        if (换仓按钮 != null) 换仓按钮.onClick.AddListener(换仓);
        if (确认button != null) 确认button.onClick.AddListener(确认更换赌坊);
        if (返回button != null) 返回button.onClick.AddListener(隐藏确认弹窗);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("赌坊Item点击", 赌坊Item点击);
        ObserverModuleManager.S.UnRegisterEvent("赌坊道具Item点击", 道具Item点击);
    }

    private void OnEnable()
    {
        显示界面();
        // 动态生成的列表首次打开容易出现布局错乱，延迟一帧再强制重建
        StartCoroutine(延迟刷新布局());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            隐藏确认弹窗();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator 延迟刷新布局()
    {
        yield return null;
        if (!gameObject.activeInHierarchy) yield break;
        刷新布局();
    }

    private void 刷新布局()
    {
        Canvas.ForceUpdateCanvases();
        // 从最深层的 LayoutGroup 往上重建，覆盖赌坊列表、商店、道具背包和仓库
        LayoutGroup[] 布局组 = GetComponentsInChildren<LayoutGroup>(true);
        for (int i = 布局组.Length - 1; i >= 0; i--)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(布局组[i].GetComponent<RectTransform>());
        }
    }

    #region 显示

    public void 显示界面()
    {
        // 子节点的 OnEnable 可能晚于本界面执行，这里再兜底关闭自动随机
        if (藏品背包 != null) 藏品背包.开启时随机 = false;

        补全道具字典();

        赌坊存档 存档 = PlayerData.S.赌坊存档;
        if (存档.当前赌坊Type == 赌坊Type.None || !赌坊Config.赌坊配置.ContainsKey(存档.当前赌坊Type))
        {
            存档.当前赌坊Type = 取默认赌坊();
        }

        if (存档.轮数 < 1) 存档.轮数 = 1;

        刷新赌坊列表();

        if (存档.藏品列表.Count == 0)
        {
            生成仓库();
        }

        刷新底格();
        渲染藏品();
        刷新商店();
        刷新道具背包();
        刷新信息();
        刷新按钮();

        if (确认更换赌坊提示弹窗 != null) 确认更换赌坊提示弹窗.SetActive(false);
        待切换赌坊 = 赌坊Type.None;
    }

    private static void 补全道具字典()
    {
        if (PlayerData.S == null || PlayerData.S.赌坊道具Dic == null) return;

        foreach (object value in Enum.GetValues(typeof(赌坊道具Type)))
        {
            赌坊道具Type type = (赌坊道具Type)value;
            if (!PlayerData.S.赌坊道具Dic.ContainsKey(type))
            {
                PlayerData.S.赌坊道具Dic[type] = 0;
            }
        }
    }

    private static 赌坊Type 取默认赌坊()
    {
        foreach (赌坊Type type in 赌坊Config.赌坊配置.Keys)
        {
            if (type != 赌坊Type.None) return type;
        }

        return 赌坊Type.铜钱巷;
    }

    private void 刷新赌坊列表()
    {
        if (赌坊列表Content == null) return;

        清空列表(赌坊列表Content);
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Window/赌坊/赌坊item");
        if (prefab == null) return;

        赌坊存档 存档 = PlayerData.S.赌坊存档;
        foreach (赌坊Type type in 赌坊Config.赌坊配置.Keys)
        {
            赌坊item item = Instantiate(prefab, 赌坊列表Content.transform).GetComponent<赌坊item>();
            if (item == null) continue;

            item.赌坊Type = type;
            item.是否选中 = type == 存档.当前赌坊Type;
            item.SetItem();
        }
    }

    private void 刷新底格()
    {
        if (底格content == null) return;

        int 显示数量 = 取行数() * 取列数();
        for (int i = 0; i < 底格content.childCount; i++)
        {
            Transform child = 底格content.GetChild(i);
            child.gameObject.SetActive(i < 显示数量);
        }
    }

    private void 刷新商店()
    {
        if (商店Content == null) return;

        清空列表(商店Content);
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Window/赌坊/赌坊商品item");
        if (prefab == null) return;

        foreach (KeyValuePair<赌坊道具Type, 道具配置> kv in 赌坊Config.道具配置)
        {
            赌坊商品item item = Instantiate(prefab, 商店Content.transform).GetComponent<赌坊商品item>();
            if (item == null) continue;

            item.道具Type = kv.Key;
            item.SetItem();
        }
    }

    private void 刷新道具背包()
    {
        if (道具背包Content == null) return;

        清空列表(道具背包Content);
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Window/赌坊/赌坊道具item");
        if (prefab == null) return;

        bool 本轮已使用 = PlayerData.S.赌坊存档.本轮已用道具 != 赌坊道具Type.None;
        foreach (KeyValuePair<赌坊道具Type, 道具配置> kv in 赌坊Config.道具配置)
        {
            赌坊道具item item = Instantiate(prefab, 道具背包Content.transform).GetComponent<赌坊道具item>();
            if (item == null) continue;

            item.道具Type = kv.Key;
            item.本轮已使用 = 本轮已使用;
            item.SetItem();
        }
    }

    private void 刷新信息()
    {
        赌坊存档 存档 = PlayerData.S.赌坊存档;

        if (当前轮数 != null) 当前轮数.text = 存档.轮数.ToString();
        if (仓库价格 != null) 仓库价格.text = PlayerData.S.格式化数字(计算价格());

        string 灵气 = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.灵魂]);
        if (当前灵气 != null) 当前灵气.text = 灵气;
        if (当前灵气底部 != null) 当前灵气底部.text = 灵气;
    }

    private void 刷新按钮()
    {
        赌坊存档 存档 = PlayerData.S.赌坊存档;

        if (下一轮按钮 != null) 下一轮按钮.interactable = !存档.已买下 && 存档.轮数 < 取最大轮数();
        if (买下按钮 != null) 买下按钮.interactable = !存档.已买下;
    }

    #endregion

    #region 仓库生成与渲染

    public void 生成仓库()
    {
        赌坊存档 存档 = PlayerData.S.赌坊存档;
        存档.藏品列表.Clear();
        存档.轮数 = 1;
        存档.本轮已用道具 = 赌坊道具Type.None;
        存档.已买下 = false;
        存档.已显示最大藏品轮廓 = false;

        清空藏品();
        if (藏品背包 == null) return;

        int 行 = 取行数();
        int 列 = 取列数();
        // 行数随赌坊配置变化，必须先同步给占地背包再重置占用表
        藏品背包.行数 = 行;
        藏品背包.列数 = 列;
        藏品背包.开始生成(0);
        int 连续失败 = 0;
        while (!藏品背包.已填满 && 连续失败 < 400)
        {
            QualityType 品质 = 按概率抽取品质();
            List<藏品Type> 候选 = 取品质候选(品质);
            bool 已放置 = false;

            if (候选.Count > 0)
            {
                int 尝试次数 = Mathf.Min(候选.Count, 8);
                for (int i = 0; i < 尝试次数; i++)
                {
                    藏品Type type = 候选[Random.Range(0, 候选.Count)];
                    Vector2Int 尺寸 = 取藏品尺寸(type);
                    if (藏品背包.尝试放置(尺寸, out int 格X, out int 格Y))
                    {
                        记录藏品(type, 尺寸, 格X, 格Y);
                        已放置 = true;
                         break;
                    }
                }
            }

            连续失败 = 已放置 ? 0 : 连续失败 + 1;
        }

        补满空格(行, 列);
    }

    private void 补满空格(int 行, int 列)
    {
        for (int y = 0; y < 行; y++)
        {
            for (int x = 0; x < 列; x++)
            {
                if (藏品背包.已填满) return;

                藏品Type type = 取单格藏品(按概率抽取品质());
                if (type == 藏品Type.None) continue;
                if (!藏品背包.单格放置(x, y)) continue;

                记录藏品(type, new Vector2Int(1, 1), x, y);
            }
        }
    }

    private static void 记录藏品(藏品Type type, Vector2Int 尺寸, int 格X, int 格Y)
    {
        PlayerData.S.赌坊存档.藏品列表.Add(new 赌坊藏品存档
        {
            格X = 格X,
            格Y = 格Y,
            宽 = 尺寸.x,
            高 = 尺寸.y,
            藏品Type = type,
            已揭示 = false,
        });
    }

    private void 渲染藏品()
    {
        清空藏品();
        if (藏品背包 == null) return;

        赌坊存档 存档 = PlayerData.S.赌坊存档;
        List<赌坊藏品存档> 列表 = 存档.藏品列表;
        int 最大索引 = 取最大藏品索引(列表);

        for (int i = 0; i < 列表.Count; i++)
        {
            赌坊藏品存档 数据 = 列表[i];
            bool 全部显示 = 存档.已买下;
            bool 显示轮廓 = !全部显示 && !数据.已揭示 && 存档.已显示最大藏品轮廓 && i == 最大索引;
            if (!全部显示 && !数据.已揭示 && !显示轮廓) continue;

            GameObject go = 藏品背包.创建藏品(new Vector2Int(数据.宽, 数据.高), 数据.格X, 数据.格Y);
            if (go == null) continue;

            藏品配置 config = 赌坊Config.藏品配置[数据.藏品Type];

            Image 背景 = go.GetComponent<Image>();
            if (背景 != null)
            {
                背景.sprite = 显示轮廓
                    ? ResourcesConfig.灵植背包格子空
                    : ResourcesConfig.Get灵植背包格子(config.QualityType);
            }

            Transform icon节点 = go.transform.Find("icon");
            if (icon节点 != null)
            {
                icon节点.gameObject.SetActive(全部显示);
                Image icon = icon节点.GetComponent<Image>();
                if (icon != null && 全部显示) icon.sprite = ResourcesConfig.Get藏品Sprite(数据.藏品Type);
            }

            Transform name节点 = go.transform.Find("name");
            if (name节点 != null)
            {
                name节点.gameObject.SetActive(全部显示);
                TextMeshProUGUI name = name节点.GetComponent<TextMeshProUGUI>();
                if (name != null) name.text = config.name;
            }
        }
    }

    private static int 取最大藏品索引(List<赌坊藏品存档> 列表)
    {
        int 索引 = -1;
        int 最大面积 = 0;
        for (int i = 0; i < 列表.Count; i++)
        {
            int 面积 = 列表[i].宽 * 列表[i].高;
            if (面积 > 最大面积)
            {
                最大面积 = 面积;
                索引 = i;
            }
        }

        return 索引;
    }

    private void 清空藏品()
    {
        if (藏品背包 == null) return;

        Transform 父节点 = 藏品背包.物品父节点 != null ? 藏品背包.物品父节点 : 藏品背包.transform;
        for (int i = 父节点.childCount - 1; i >= 0; i--)
        {
            GameObject child = 父节点.GetChild(i).gameObject;
            child.SetActive(false);
            Destroy(child);
        }
    }

    #endregion

    #region 抽取

    private QualityType 按概率抽取品质()
    {
        赌坊配置 config = 赌坊Config.赌坊配置[PlayerData.S.赌坊存档.当前赌坊Type];
        List<float> 概率 = config.概率;

        float 总 = 0;
        for (int i = 0; i < 8; i++)
        {
            if (i >= 概率.Count) break;
            总 += Mathf.Max(0, 概率[i]);
        }

        if (总 <= 0) return QualityType.黄品;

        float 随机值 = Random.value * 总;
        for (int i = 0; i < 8; i++)
        {
            if (i >= 概率.Count) break;

            float 权重 = Mathf.Max(0, 概率[i]);
            if (随机值 < 权重) return (QualityType)(i + 1);
            随机值 -= 权重;
        }

        return QualityType.黄品;
    }

    private List<藏品Type> 取品质候选(QualityType 品质)
    {
        if (品质候选缓存.TryGetValue(品质, out List<藏品Type> 缓存)) return 缓存;

        缓存 = new List<藏品Type>();
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 赌坊Config.藏品配置)
        {
            if (kv.Value.QualityType == 品质) 缓存.Add(kv.Key);
        }

        品质候选缓存[品质] = 缓存;
        return 缓存;
    }

    private 藏品Type 取单格藏品(QualityType 品质)
    {
        foreach (藏品Type type in 取品质候选(品质))
        {
            if (取藏品尺寸(type) == new Vector2Int(1, 1)) return type;
        }

        foreach (藏品Type type in 取品质候选(QualityType.黄品))
        {
            if (取藏品尺寸(type) == new Vector2Int(1, 1)) return type;
        }

        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 赌坊Config.藏品配置)
        {
            if (取藏品尺寸(kv.Key) == new Vector2Int(1, 1)) return kv.Key;
        }

        return 藏品Type.None;
    }

    private static Vector2Int 取藏品尺寸(藏品Type type)
    {
        if (!赌坊Config.藏品配置.TryGetValue(type, out 藏品配置 config))
        {
            return new Vector2Int(1, 1);
        }

        return 赌坊Config.Get藏品尺寸(config.藏品尺寸Type);
    }

    private static int 取行数()
    {
        if (赌坊Config.赌坊配置.TryGetValue(PlayerData.S.赌坊存档.当前赌坊Type, out 赌坊配置 config))
        {
            return Mathf.Max(1, Mathf.RoundToInt(config.行数));
        }

        return 1;
    }

    private static int 取列数()
    {
        // 赌坊界面中的仓库固定 10 列，与底格 GridLayoutGroup 对齐
        return 10;
    }

    private static int 取最大轮数()
    {
        int 最大 = 1;
        foreach (KeyValuePair<int, float> kv in 赌坊Config.轮数价格倍数)
        {
            if (kv.Key > 最大) 最大 = kv.Key;
        }

        return 最大;
    }

    private static float 计算价格()
    {
        赌坊存档 存档 = PlayerData.S.赌坊存档;
        if (!赌坊Config.赌坊配置.TryGetValue(存档.当前赌坊Type, out 赌坊配置 config)) return 0;

        float 倍数 = 1;
        if (!赌坊Config.轮数价格倍数.TryGetValue(存档.轮数, out 倍数))
        {
            倍数 = 1;
        }

        return config.首仓价格 * 倍数;
    }

    #endregion

    #region 交互

    public void 赌坊Item点击(object[] obj)
    {
        if (!gameObject.activeInHierarchy || obj == null || obj.Length == 0) return;

        赌坊Type type = (赌坊Type)obj[0];
        if (type == PlayerData.S.赌坊存档.当前赌坊Type)
        {
            刷新赌坊列表();
            return;
        }

        待切换赌坊 = type;
        if (确认更换赌坊提示弹窗 != null) 确认更换赌坊提示弹窗.SetActive(true);
    }

    public void 道具Item点击(object[] obj)
    {
        if (!gameObject.activeInHierarchy || obj == null || obj.Length == 0) return;

        使用道具((赌坊道具Type)obj[0]);
    }

    private void 确认更换赌坊()
    {
        if (待切换赌坊 == 赌坊Type.None)
        {
            隐藏确认弹窗();
            return;
        }

        PlayerData.S.赌坊存档.当前赌坊Type = 待切换赌坊;
        待切换赌坊 = 赌坊Type.None;

        生成仓库();
        刷新赌坊列表();
        刷新底格();
        渲染藏品();
        刷新道具背包();
        刷新信息();
        刷新按钮();
        隐藏确认弹窗();

        StoreController.S.SaveStoreData();
    }

    private void 隐藏确认弹窗()
    {
        if (确认更换赌坊提示弹窗 != null) 确认更换赌坊提示弹窗.SetActive(false);
        待切换赌坊 = 赌坊Type.None;
    }

    public void 换仓()
    {
        生成仓库();
        刷新底格();
        渲染藏品();
        刷新道具背包();
        刷新信息();
        刷新按钮();

        StoreController.S.SaveStoreData();
    }

    public void 下一轮()
    {
        赌坊存档 存档 = PlayerData.S.赌坊存档;
        if (存档.已买下) return;

        int 最大轮数 = 取最大轮数();
        if (存档.轮数 >= 最大轮数)
        {
            提示("已经是最后一轮");
            return;
        }

        存档.轮数++;
        存档.本轮已用道具 = 赌坊道具Type.None;

        刷新道具背包();
        刷新信息();
        刷新按钮();

        StoreController.S.SaveStoreData();
    }

    public void 买下()
    {
        赌坊存档 存档 = PlayerData.S.赌坊存档;
        if (存档.已买下) return;

        float 价格 = 计算价格();
        if (PlayerData.S.PropListDic[PropType.灵魂] < 价格)
        {
            提示("灵气不足");
            return;
        }

        PlayerData.S.PropListDic[PropType.灵魂] -= 价格;

        foreach (赌坊藏品存档 藏品 in 存档.藏品列表)
        {
            if (!PlayerData.S.藏品仓库Dic.ContainsKey(藏品.藏品Type))
            {
                PlayerData.S.藏品仓库Dic[藏品.藏品Type] = 0;
            }

            PlayerData.S.藏品仓库Dic[藏品.藏品Type]++;
        }

        存档.已买下 = true;

        渲染藏品();
        刷新信息();
        刷新按钮();

        StoreController.S.SaveStoreData();
        提示("买下成功");
    }

    private void 使用道具(赌坊道具Type type)
    {
        if (type == 赌坊道具Type.None) return;

        赌坊存档 存档 = PlayerData.S.赌坊存档;

        if (存档.已买下)
        {
            提示("仓库已买下");
            return;
        }

        if (存档.本轮已用道具 != 赌坊道具Type.None)
        {
            提示("本轮已经使用过道具");
            return;
        }

        if (!PlayerData.S.赌坊道具Dic.TryGetValue(type, out float 数量) || 数量 <= 0)
        {
            提示("道具数量不足");
            return;
        }

        if (赌坊Config.品质道具数量.TryGetValue(type, out int 查看数量))
        {
            if (!揭晓藏品(查看数量))
            {
                提示("没有可查看的藏品");
                return;
            }

            渲染藏品();
        }
        else
        {
            switch (type)
            {
                case 赌坊道具Type.看仓库总格子数:
                    提示($"仓库总格子数：{取行数() * 取列数()}");
                    break;
                case 赌坊道具Type.白格子数量:
                    提示($"白格子数量：{统计品质格子(QualityType.黄品)}");
                    break;
                case 赌坊道具Type.绿格子数量:
                    提示($"绿格子数量：{统计品质格子(QualityType.玄品)}");
                    break;
                case 赌坊道具Type.蓝格子数量:
                    提示($"蓝格子数量：{统计品质格子(QualityType.地品)}");
                    break;
                case 赌坊道具Type.藏品平均价值:
                    提示($"藏品平均价值：{PlayerData.S.格式化数字(统计平均价值())}");
                    break;
                case 赌坊道具Type.看最大藏品轮廓:
                    存档.已显示最大藏品轮廓 = true;
                    渲染藏品();
                    break;
            }
        }

        PlayerData.S.赌坊道具Dic[type] = 数量 - 1;
        存档.本轮已用道具 = type;

        刷新道具背包();
        刷新信息();
        刷新按钮();

        StoreController.S.SaveStoreData();
    }

    /// <summary>随机揭晓指定数量的未揭示藏品，返回是否有可揭晓目标</summary>
    private bool 揭晓藏品(int 数量)
    {
        List<赌坊藏品存档> 列表 = PlayerData.S.赌坊存档.藏品列表;
        List<int> 可揭晓 = new List<int>();
        for (int i = 0; i < 列表.Count; i++)
        {
            if (!列表[i].已揭示) 可揭晓.Add(i);
        }

        if (可揭晓.Count == 0) return false;

        // 洗牌后取前 N 个，保证同一次使用不会重复
        for (int i = 可揭晓.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            int temp = 可揭晓[i];
            可揭晓[i] = 可揭晓[j];
            可揭晓[j] = temp;
        }

        int 揭晓数 = Mathf.Min(数量, 可揭晓.Count);
        for (int i = 0; i < 揭晓数; i++)
        {
            列表[可揭晓[i]].已揭示 = true;
        }

        return true;
    }

    private static int 统计品质格子(QualityType 品质)
    {
        int 总格数 = 0;
        foreach (赌坊藏品存档 藏品 in PlayerData.S.赌坊存档.藏品列表)
        {
            if (赌坊Config.藏品配置[藏品.藏品Type].QualityType == 品质)
            {
                总格数 += 藏品.宽 * 藏品.高;
            }
        }

        return 总格数;
    }

    private static float 统计平均价值()
    {
        List<赌坊藏品存档> 列表 = PlayerData.S.赌坊存档.藏品列表;
        if (列表.Count == 0) return 0;

        float 总价 = 0;
        foreach (赌坊藏品存档 藏品 in 列表)
        {
            if (赌坊Config.藏品价格Dic.TryGetValue(藏品.藏品Type, out float 价格))
            {
                总价 += 价格;
            }
        }

        return 总价 / 列表.Count;
    }

    private static void 提示(string text)
    {
        ObserverModuleManager.S.SendEvent("SendUIToast", text);
    }

    #endregion

    private static void 清空列表(GameObject content)
    {
        if (content == null) return;

        for (int i = content.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = content.transform.GetChild(i).gameObject;
            child.SetActive(false);
            Destroy(child);
        }
    }
}
