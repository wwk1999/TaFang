using System;
using System.Reflection;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>藏品百科条目：根据藏品尺寸显示对应尺寸的icon子物体，并展示名称、价格、效果、轮廓</summary>
public class 藏品百科item : MonoBehaviour
{
    [Header("尺寸icon父节点（子物体按尺寸命名，如12=1×2）")]
    public Transform icon;

    [Header("信息文本")]
    public TextMeshProUGUI name;
    public TextMeshProUGUI 灵气;
    public TextMeshProUGUI 效果text;
    public TextMeshProUGUI 效果Count;
    public TextMeshProUGUI 轮廓text;
    public TextMeshProUGUI 轮廓Count;

    [NonSerialized] public 藏品Type 藏品Type;

    public void SetItem(藏品Type type)
    {
        藏品Type = type;
        if (!赌坊Config.藏品配置.TryGetValue(type, out 藏品配置 config)) return;

        // 名称
        if (name != null) name.text = config.name;

        // 价格（灵气）
        if (灵气 != null) 灵气.text = PlayerData.S.格式化数字(赌坊Config.藏品价格Dic[type]);

        // 效果文本
        if (效果text != null) 效果text.text = "效果:";
        if (效果Count != null) 效果Count.text = 获取效果文本(config.效果);

        // 轮廓（尺寸）
        if (轮廓text != null) 轮廓text.text = "轮廓:";
        if (轮廓Count != null) 轮廓Count.text = 获取尺寸文本(config.藏品尺寸Type);

        // 根据尺寸显示对应icon子物体，其余隐藏
        刷新尺寸icon(config.藏品尺寸Type, type);
    }

    /// <summary>根据藏品尺寸枚举，取"宽x高"文本，如 C2x5 → "2X5"</summary>
    private string 获取尺寸文本(藏品尺寸Type size)
    {
        return size.ToString().Replace("C", "").Replace("x", "X");
    }

    /// <summary>藏品现在只有一个效果字段，遍历找到非零字段并显示"字段名+值%"</summary>
    private string 获取效果文本(藏品效果 effect)
    {
        if (effect == null) return string.Empty;
        FieldInfo[] fields = typeof(藏品效果).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo f in fields)
        {
            float v = (float)f.GetValue(effect);
            if (Mathf.Abs(v) > 0.0001f)
            {
                return $"{f.Name}+{v}%";
            }
        }
        return string.Empty;
    }

    /// <summary>隐藏所有尺寸子物体，只显示与藏品尺寸匹配的那个，并把它的图片设为藏品icon</summary>
    private void 刷新尺寸icon(藏品尺寸Type size, 藏品Type type)
    {
        if (icon == null) return;

        // 尺寸key：C1x2 → "12"
        string sizeKey = size.ToString().Replace("C", "").Replace("x", "");

        Transform target = icon.Find(sizeKey);
        if (target == null)
        {
            // 兼容预制体里把 1×1/2×2/3×3 合并命名为 "112233" 之类的情况
            foreach (Transform child in icon)
            {
                if (child.name.Contains(sizeKey))
                {
                    target = child;
                    break;
                }
            }
        }

        foreach (Transform child in icon)
        {
            child.gameObject.SetActive(false);
        }

        if (target != null)
        {
            target.gameObject.SetActive(true);
            Image img = target.GetComponent<Image>();
            if (img != null) img.sprite = ResourcesConfig.Get藏品Sprite(type);
        }
    }
}
