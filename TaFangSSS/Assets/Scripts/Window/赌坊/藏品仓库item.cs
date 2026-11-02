using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 藏品仓库item : MonoBehaviour
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
    public TextMeshProUGUI Count;

    public Image bg;

    [NonSerialized] public 藏品Type 藏品Type;
    private string 获取尺寸文本(藏品尺寸Type size)
    {
        return size.ToString().Replace("C", "").Replace("x", "X");
    }
    
    private void 自动查找引用()
    {
        if (icon == null) icon = 找<Transform>("icon");
        if (name == null) name = 找<TextMeshProUGUI>("name");
        if (灵气 == null) 灵气 = 找<TextMeshProUGUI>("灵气");
        if (效果text == null) 效果text = 找<TextMeshProUGUI>("效果text");
        if (效果Count == null) 效果Count = 找<TextMeshProUGUI>("效果Count");
        if (轮廓text == null) 轮廓text = 找<TextMeshProUGUI>("轮廓text");
        if (轮廓Count == null) 轮廓Count = 找<TextMeshProUGUI>("轮廓Count");
    }

    private T 找<T>(string childName) where T : Component
    {
        Transform t = transform.Find("bg/" + childName);
        if (t == null) t = transform.Find(childName);
        return t != null ? t.GetComponent<T>() : null;
    }

    public void SetItem(藏品Type type)
    {
        自动查找引用();
        bg.sprite = ResourcesConfig.Get灵植背包格子(赌坊Config.藏品配置[type].QualityType);
        藏品Type = type;
        if (!赌坊Config.藏品配置.TryGetValue(type, out 藏品配置 config)) return;
        Count.text=PlayerData.S.藏品仓库Dic[type].ToString();
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
        return "无";
    }
    
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
