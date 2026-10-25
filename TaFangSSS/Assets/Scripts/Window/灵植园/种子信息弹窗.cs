using System;
using System.Collections.Generic;
using System.Text;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 种子/收获物信息弹窗：点击种子或收获物时展示基础属性与服用信息
/// </summary>
public class 种子信息弹窗 : MonoBehaviour
{

    public Image 图标;
    public TextMeshProUGUI 名称;

    public TextMeshProUGUI 生长时间;
    public TextMeshProUGUI 预计产量;
    public TextMeshProUGUI 收获青石;
    public TextMeshProUGUI 收获经验;
    public TextMeshProUGUI 服用次数;
    public TextMeshProUGUI 服用效果;

    [NonSerialized] public 灵植Type 灵植Tyep;
    [NonSerialized] public bool 是否变异;
    [NonSerialized] public bool 是否种子;

   

    /// <summary>
    /// 打开弹窗
    /// </summary>
    /// <param name="type">灵植类型</param>
    /// <param name="是否变异">是否为变异收获物（影响图标与服用次数统计）</param>
    /// <param name="是否种子">是否为种子（影响图标）</param>
    public void 打开(灵植Type type, bool 是否变异 = false, bool 是否种子 = true)
    {
        灵植Tyep = type;
        this.是否变异 = 是否变异;
        this.是否种子 = 是否种子;
        gameObject.SetActive(true);
        SetItem();
    }

    private void 关闭()
    {
        gameObject.SetActive(false);
    }

    public void SetItem()
    {
        QualityType 品质 = 灵植园Config.灵植品质Dic[灵植Tyep];

        // 图标
        if (是否种子)
        {
            图标.sprite = ResourcesConfig.Get灵植种子Sprite(灵植Tyep);
        }
        else if (是否变异)
        {
            图标.sprite = ResourcesConfig.Get灵植变异收获Sprite(灵植Tyep);
        }
        else
        {
            图标.sprite = ResourcesConfig.Get灵植收获Sprite(灵植Tyep);
        }

        // 名称 + 品质色
        名称.text = (是否变异 ? "变异·" : "") + 灵植园Config.灵植名[灵植Tyep];
        名称.colorGradientPreset = ResourcesConfig.Get品质TMP(品质);

        // 基础属性
        生长时间.text = 灵植园Config.灵植成熟时间Dic[灵植Tyep].ToString("F0") + "道年";
        预计产量.text = 灵植园Config.灵植产量Dic[灵植Tyep].ToString("F0");
        收获青石.text = 灵植园Config.灵植收获青石Dic[灵植Tyep].ToString("F0");
        收获经验.text = 灵植园Config.灵植收获经验Dic[灵植Tyep].ToString("F0");

        // 服用次数（普通/变异各自独立计数）
        int 已服用 = 是否变异
            ? PlayerData.S.变异服用次数Dic[灵植Tyep]
            : PlayerData.S.普通服用次数Dic[灵植Tyep];
        服用次数.text = 已服用 + " / " + 灵植园Config.最大服用次数;

        // 服用效果：取该灵植的所有非零效果，按"名称 +X%"拼接展示
        服用效果.text = 获取服用效果文本(灵植Tyep);
    }

    /// <summary>
    /// 将 灵植效果 中所有非零字段拼成展示文本，每行一个，格式如 "战士伤害 +1%"
    /// </summary>
    private static string 获取服用效果文本(灵植Type type)
    {
        if (!灵植园Config.灵植效果.TryGetValue(type, out 灵植效果 效果) || 效果 == null)
        {
            return "无";
        }

        // 字段显示名（与灵植效果类字段一一对应）
        var 列表 = new List<(string 名, float 值)>
        {
            ("城墙生命值", 效果.城墙生命值),
            ("城墙防御", 效果.城墙防御),
            ("暴击率", 效果.暴击率),
            ("暴击伤害", 效果.暴击伤害),
            ("最终伤害", 效果.最终伤害),
            ("战士伤害", 效果.战士伤害),
            ("射手伤害", 效果.射手伤害),
            ("控制伤害", 效果.控制伤害),
            ("法师伤害", 效果.法师伤害),
            ("黑暗伤害", 效果.黑暗伤害),
            ("火焰伤害", 效果.火焰伤害),
            ("雷电伤害", 效果.雷电伤害),
            ("物理伤害", 效果.物理伤害),
            ("冰霜伤害", 效果.冰霜伤害),
            ("职业伤害", 效果.职业伤害),
            ("元素伤害", 效果.元素伤害),
            ("掉宝率", 效果.掉宝率),
            ("灵气增幅", 效果.灵气增幅),
            ("功德增幅", 效果.功德增幅),
            ("跟脚", 效果.跟脚),
            ("真灵", 效果.真灵),
            ("时间流速", 效果.时间流速),
            ("修炼速度", 效果.修炼速度),
        };

        var sb = new StringBuilder();
        foreach (var item in 列表)
        {
            if (Mathf.Abs(item.值) > 0.0001f)
            {
                string 符号 = item.值 >= 0 ? "+" : "";
                sb.AppendLine($"{item.名} {符号}{item.值:0.##}%");
            }
        }

        return sb.Length > 0 ? sb.ToString().TrimEnd() : "无";
    }
}
