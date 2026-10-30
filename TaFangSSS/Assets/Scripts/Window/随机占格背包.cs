using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 纯展示用的占地背包：随机生成不同尺寸的物品并铺到格子里，不支持拖拽与手动整理。
/// 挂在背包内容区的 RectTransform 上，开启时自动随机一次，也可手动调用「重新随机」。
/// </summary>
public class 随机占格背包 : MonoBehaviour
{
    [Header("背包格数")]
    [Min(1)] public int 列数 = 10;
    [Min(1)] public int 行数 = 6;

    [Header("格子尺寸")]
    [Min(1f)] public float 每格像素 = 96f;
    [Min(0f)] public float 物品间距 = 4f;
    [Header("外观")]
    [Tooltip("不填则使用自身作为父节点；父节点上不要留 GridLayoutGroup")]
    public RectTransform 物品父节点;
    [Tooltip("可选，根节点或子节点需要带 Image；为空时自动创建色块")]
    public RectTransform 物品预制体;
    public Sprite[] 物品图标;
    [Tooltip("没有配置图标时，给自动创建的色块随机颜色")]
    public bool 无图标用随机颜色 = true;

    [Header("随机规则")]
    [Range(0.3f, 1f)] public float 填充率 = 1;
    [Min(1)] public int 最多物品数 = 300;
    [Tooltip("0 表示每次都用新的随机序列")]
    public int 随机种子;
    public bool 开启时随机 = true;

    [Header("可生成的尺寸（宽×高，单位：格）")]
    public Vector2Int[] 可生成尺寸 =
    {
        new Vector2Int(1, 1),
        new Vector2Int(2, 1),
        new Vector2Int(1, 2),
        new Vector2Int(3, 1),
        new Vector2Int(1, 3),
        new Vector2Int(2, 2),
        new Vector2Int(3, 2),
        new Vector2Int(2, 3),
        new Vector2Int(3, 3),
    };

    private readonly List<GameObject> 已生成 = new List<GameObject>();
    private System.Random 随机数;

    private void OnEnable()
    {
        if (开启时随机)
        {
            重新随机();
        }
    }

    [ContextMenu("重新随机")]
    public void 重新随机()
    {
        清除已有物品();

        if (列数 <= 0 || 行数 <= 0 || 可生成尺寸 == null || 可生成尺寸.Length == 0)
        {
            return;
        }

        随机数 = 随机种子 == 0 ? new System.Random() : new System.Random(随机种子);

        RectTransform 父节点 = 物品父节点 != null ? 物品父节点 : (RectTransform)transform;
        // 父节点若带布局组，会把子节点的锚点位置改回自动排版，这里直接停用
        GridLayoutGroup 布局组 = 父节点.GetComponent<GridLayoutGroup>();
        if (布局组 != null)
        {
            布局组.enabled = false;
        }

        bool[,] 占用 = new bool[行数, 列数];
        int 总格数 = 列数 * 行数;
        int 目标格数 = Mathf.Clamp(Mathf.RoundToInt(总格数 * 填充率), 1, 总格数);
        int 已占格数 = 0;
        int 物品数 = 0;
        int 连续失败 = 0;
        // 随机摆放难免遇到边角塞不进的情况，连续失败足够多就收手
        const int 最大连续失败 = 400;

        while (已占格数 < 目标格数 && 物品数 < 最多物品数 && 连续失败 < 最大连续失败)
        {
            Vector2Int 尺寸 = 可生成尺寸[随机数.Next(可生成尺寸.Length)];
            if (尺寸.x <= 0 || 尺寸.y <= 0 || 尺寸.x > 列数 || 尺寸.y > 行数)
            {
                连续失败++;
                continue;
            }

            int 面积 = 尺寸.x * 尺寸.y;
            // 剩余格数不够时不再尝试这个大尺寸，避免超出目标填充率
            if (已占格数 + 面积 > 目标格数)
            {
                连续失败++;
                continue;
            }

            bool 已放置 = false;
            int 尝试次数 = Mathf.Max(20, 总格数 * 2);
            for (int i = 0; i < 尝试次数; i++)
            {
                int x = 随机数.Next(0, 列数 - 尺寸.x + 1);
                int y = 随机数.Next(0, 行数 - 尺寸.y + 1);
                if (!能否放下(占用, x, y, 尺寸.x, 尺寸.y))
                {
                    continue;
                }

                for (int row = y; row < y + 尺寸.y; row++)
                {
                    for (int col = x; col < x + 尺寸.x; col++)
                    {
                        占用[row, col] = true;
                    }
                }

                生成物品(父节点, x, y, 尺寸);
                已占格数 += 面积;
                物品数++;
                已放置 = true;
                break;
            }

            连续失败 = 已放置 ? 0 : 连续失败 + 1;
        }
    }

    private static bool 能否放下(bool[,] 占用, int x, int y, int 宽, int 高)
    {
        for (int row = y; row < y + 高; row++)
        {
            for (int col = x; col < x + 宽; col++)
            {
                if (占用[row, col])
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void 生成物品(RectTransform 父节点, int x, int y, Vector2Int 尺寸)
    {
        RectTransform 物品;
        Image 图片 = null;

        if (物品预制体 != null)
        {
            物品 = Instantiate(物品预制体, 父节点);
            图片 = 物品.GetComponent<Image>();
            if (图片 == null)
            {
                图片 = 物品.GetComponentInChildren<Image>();
            }
        }
        else
        {
            GameObject go = new GameObject("随机物品", typeof(RectTransform), typeof(Image));
            物品 = (RectTransform)go.transform;
            物品.SetParent(父节点, false);
            图片 = go.GetComponent<Image>();
        }

        // 锚点统一为左上角，坐标即格子索引乘以格子尺寸
        物品.anchorMin = new Vector2(0, 1);
        物品.anchorMax = new Vector2(0, 1);
        物品.pivot = new Vector2(0, 1);
        物品.anchoredPosition = new Vector2(x * 每格像素 + 物品间距 * 0.5f, -(y * 每格像素 + 物品间距 * 0.5f));
        物品.sizeDelta = new Vector2(尺寸.x * 每格像素 - 物品间距, 尺寸.y * 每格像素 - 物品间距);

        if (图片 != null)
        {
            if (物品图标 != null && 物品图标.Length > 0)
            {
                图片.sprite = 物品图标[随机数.Next(物品图标.Length)];
                图片.type = Image.Type.Simple;
            }
            else if (无图标用随机颜色)
            {
                图片.color = Color.HSVToRGB((float)随机数.NextDouble(), 0.45f, 0.9f);
            }
        }

        已生成.Add(物品.gameObject);
    }

    private void 清除已有物品()
    {
        for (int i = 0; i < 已生成.Count; i++)
        {
            GameObject go = 已生成[i];
            if (go == null)
            {
                continue;
            }

            if (Application.isPlaying)
            {
                Destroy(go);
            }
            else
            {
                DestroyImmediate(go);
            }
        }

        已生成.Clear();
    }
}
