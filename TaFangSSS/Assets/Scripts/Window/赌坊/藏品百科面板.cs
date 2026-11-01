using System;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

/// <summary>藏品百科面板：品质/轮廓筛选 + 对象池列表渲染</summary>
public class 藏品百科面板 : MonoBehaviour
{
    [Header("品质筛选：子物体按 黄玄地天宇宙洪荒 顺序排列，每个含 Button 与 gou")]
    public Transform 品质筛选Content;

    [Header("轮廓筛选：每个尺寸对应一个预制体（按顺序拖入即可）")]
    public Transform 轮廓筛选Content;
    public List<轮廓筛选Prefab项> 轮廓筛选Prefab列表 = new List<轮廓筛选Prefab项>();

    [Serializable]
    public class 轮廓筛选Prefab项
    {
        public 藏品尺寸Type 尺寸;
        public GameObject 预制体;
    }

    [Header("藏品列表")]
    public Transform 列表Content;
    public GameObject 藏品百科ItemPrefab;

    // 筛选状态：None 表示不筛选（显示全部）
    private QualityType 当前品质 = QualityType.None;
    private 藏品尺寸Type 当前轮廓 = 藏品尺寸Type.None;

    // 品质筛选按钮（按 黄玄地天宇宙洪荒 顺序）
    private readonly List<Button> 品质按钮 = new List<Button>();
    private readonly List<GameObject> 品质gou = new List<GameObject>();

    // 轮廓筛选按钮
    private readonly List<藏品百科轮廓筛选Item> 轮廓按钮 = new List<藏品百科轮廓筛选Item>();

    // 对象池
    private readonly List<藏品百科item> 池 = new List<藏品百科item>();
    private readonly List<藏品百科item> 活跃 = new List<藏品百科item>();

    // 全部藏品缓存，按品质从高到低排序
    private List<KeyValuePair<藏品Type, 藏品配置>> 全部藏品;

    private void Start()
    {
        缓存全部藏品();
        初始化品质筛选();
        初始化轮廓筛选();
        刷新列表();
    }

    private void 缓存全部藏品()
    {
        全部藏品 = new List<KeyValuePair<藏品Type, 藏品配置>>(赌坊Config.藏品配置);
        // 默认排序：品质从高到低（荒品最大），同品质按枚举序号升序
        全部藏品.Sort((a, b) =>
        {
            // CompareTo：a<b 返回负，a>b 返回正。取负号实现降序（高品质在前）
            int q = a.Value.QualityType.CompareTo(b.Value.QualityType);
            return q != 0 ? -q : a.Key.CompareTo(b.Key);
        });
    }

    #region 品质筛选

    private void 初始化品质筛选()
    {
        if (品质筛选Content == null) return;

        // 目标品质顺序：从高到低 荒洪宙宇天地玄黄
        QualityType[] 顺序 =
        {
            QualityType.荒品, QualityType.洪品, QualityType.宙品, QualityType.宇品,
            QualityType.天品, QualityType.地品, QualityType.玄品, QualityType.黄品
        };

        // 收集所有子按钮，并按品质从高到低重排显示顺序
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < 品质筛选Content.childCount; i++)
        {
            children.Add(品质筛选Content.GetChild(i));
        }
        // 预制体里默认顺序是 黄玄地天宇宙洪荒（低到高），反转为 荒洪宙宇天地玄黄（高到低）
        children.Reverse();
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }

        for (int i = 0; i < children.Count && i < 顺序.Length; i++)
        {
            Transform child = children[i];
            // Button 可能在子节点（如 黄Button）上，用 GetComponentInChildren 查找
            Button btn = child.GetComponentInChildren<Button>();
            if (btn == null) continue;

            QualityType q = 顺序[i];
            品质按钮.Add(btn);

            // gou 选中标记：优先在直接子节点找，找不到就在后代找
            Transform gouT = child.Find("gou");
            if (gouT == null)
            {
                foreach (Transform c in child.GetComponentsInChildren<Transform>())
                {
                    if (c.name == "gou") { gouT = c; break; }
                }
            }
            品质gou.Add(gouT != null ? gouT.gameObject : null);

            btn.onClick.AddListener(() => 点击品质(q));
        }

        更新品质选中状态();
    }

    private void 点击品质(QualityType q)
    {
        // 再次点击已选中的品质 → 取消筛选（显示全部）
        当前品质 = 当前品质 == q ? QualityType.None : q;
        更新品质选中状态();
        刷新列表();
    }

    private void 更新品质选中状态()
    {
        for (int i = 0; i < 品质按钮.Count; i++)
        {
            if (i >= 品质gou.Count) break;
            if (品质gou[i] != null) 品质gou[i].SetActive(false);
        }

        if (当前品质 == QualityType.None) return;

        QualityType[] 顺序 =
        {
            QualityType.荒品, QualityType.洪品, QualityType.宙品, QualityType.宇品,
            QualityType.天品, QualityType.地品, QualityType.玄品, QualityType.黄品
        };
        int idx = Array.IndexOf(顺序, 当前品质);
        if (idx >= 0 && idx < 品质gou.Count && 品质gou[idx] != null)
        {
            品质gou[idx].SetActive(true);
        }
    }

    #endregion

    #region 轮廓筛选

    private void 初始化轮廓筛选()
    {
        if (轮廓筛选Content == null) return;

        // 建立 尺寸→预制体 查找表
        Dictionary<藏品尺寸Type, GameObject> prefabDic = new Dictionary<藏品尺寸Type, GameObject>();
        foreach (轮廓筛选Prefab项 项 in 轮廓筛选Prefab列表)
        {
            if (项.预制体 != null) prefabDic[项.尺寸] = 项.预制体;
        }

        // 清空已有
        for (int i = 轮廓筛选Content.childCount - 1; i >= 0; i--)
        {
            Destroy(轮廓筛选Content.GetChild(i).gameObject);
        }
        轮廓按钮.Clear();

        // 所有尺寸（除 None），按面积从小到大排序
        List<藏品尺寸Type> sizes = new List<藏品尺寸Type>();
        foreach (藏品尺寸Type s in Enum.GetValues(typeof(藏品尺寸Type)))
        {
            if (s != 藏品尺寸Type.None) sizes.Add(s);
        }
        sizes.Sort((a, b) =>
        {
            Vector2Int sa = 赌坊Config.Get藏品尺寸(a);
            Vector2Int sb = 赌坊Config.Get藏品尺寸(b);
            int area = (sa.x * sa.y).CompareTo(sb.x * sb.y);
            return area != 0 ? area : sa.x.CompareTo(sb.x);
        });

        foreach (藏品尺寸Type s in sizes)
        {
            if (!prefabDic.TryGetValue(s, out GameObject prefab) || prefab == null) continue;
            GameObject go = Instantiate(prefab, 轮廓筛选Content);
            藏品百科轮廓筛选Item item = go.GetComponent<藏品百科轮廓筛选Item>();
            if (item == null) item = go.AddComponent<藏品百科轮廓筛选Item>();
            item.SetItem(s, 点击轮廓);
            轮廓按钮.Add(item);
        }

        更新轮廓选中状态();
    }

    private void 点击轮廓(藏品尺寸Type s)
    {
        // 再次点击已选中的尺寸 → 取消筛选（显示全部）
        当前轮廓 = 当前轮廓 == s ? 藏品尺寸Type.None : s;
        更新轮廓选中状态();
        刷新列表();
    }

    private void 更新轮廓选中状态()
    {
        foreach (藏品百科轮廓筛选Item item in 轮廓按钮)
        {
            item.SetSelected(item.尺寸 == 当前轮廓 && 当前轮廓 != 藏品尺寸Type.None);
        }
    }

    #endregion

    #region 列表渲染（对象池）

    private void 刷新列表()
    {
        // 回收到池
        foreach (藏品百科item item in 活跃)
        {
            item.gameObject.SetActive(false);
            池.Add(item);
        }
        活跃.Clear();

        // 筛选
        List<KeyValuePair<藏品Type, 藏品配置>> 显示列表 = 获取筛选结果();

        int 序号 = 0;
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 显示列表)
        {
            藏品百科item item = 取出池item();
            item.gameObject.SetActive(true);
            // 强制设置兄弟顺序，避免对象池复用导致显示顺序错乱
            item.transform.SetSiblingIndex(序号);
            item.SetItem(kv.Key);
            活跃.Add(item);
            序号++;
        }
    }

    private List<KeyValuePair<藏品Type, 藏品配置>> 获取筛选结果()
    {
        List<KeyValuePair<藏品Type, 藏品配置>> 结果 = new List<KeyValuePair<藏品Type, 藏品配置>>();
        foreach (KeyValuePair<藏品Type, 藏品配置> kv in 全部藏品)
        {
            if (当前品质 != QualityType.None && kv.Value.QualityType != 当前品质) continue;
            if (当前轮廓 != 藏品尺寸Type.None && kv.Value.藏品尺寸Type != 当前轮廓) continue;
            结果.Add(kv);
        }
        return 结果;
    }

    private 藏品百科item 取出池item()
    {
        if (池.Count > 0)
        {
            int last = 池.Count - 1;
            藏品百科item item = 池[last];
            池.RemoveAt(last);
            return item;
        }
        GameObject go = Instantiate(藏品百科ItemPrefab, 列表Content);
        藏品百科item newItem = go.GetComponent<藏品百科item>();
        if (newItem == null) newItem = go.AddComponent<藏品百科item>();
        return newItem;
    }

    #endregion
}
