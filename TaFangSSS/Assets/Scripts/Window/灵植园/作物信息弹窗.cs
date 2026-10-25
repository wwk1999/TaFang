using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 作物信息弹窗：展示收获物的图标、名称、好感度、服用次数与服用效果
/// </summary>
public class 作物信息弹窗 : MonoBehaviour
{
    public Image 图标;
    public TextMeshProUGUI 名称;
    public TextMeshProUGUI 类型;

    public TextMeshProUGUI 好感度;
    public TextMeshProUGUI 服用次数;
    public TextMeshProUGUI 服用效果;

    [NonSerialized] public 灵植Type 灵植Tyep;
    [NonSerialized] public bool 是否变异;

    /// <summary>
    /// 打开弹窗
    /// </summary>
    /// <param name="type">灵植类型</param>
    /// <param name="是否变异">是否为变异收获物（影响图标与服用次数统计）</param>
    public void 打开(灵植Type type, bool 是否变异 = false)
    {
        灵植Tyep = type;
        this.是否变异 = 是否变异;
        gameObject.SetActive(true);
        SetItem();
    }

    private void 关闭()
    {
        gameObject.SetActive(false);
    }

    public void SetItem()
    {
        if (灵植Tyep == 灵植Type.None) return;

        QualityType 品质 = 灵植园Config.灵植品质Dic[灵植Tyep];

        // 图标
        图标.sprite = 是否变异
            ? ResourcesConfig.Get灵植变异收获Sprite(灵植Tyep)
            : ResourcesConfig.Get灵植收获Sprite(灵植Tyep);

        // 名称 + 品质色
        名称.text = (是否变异 ? "变异·" : "") + 灵植园Config.灵植名[灵植Tyep];
        名称.colorGradientPreset = ResourcesConfig.Get品质TMP(品质);

        类型.text = "灵植作物";

        // 好感度（赠送仙女用）
        好感度.text = 灵植园Config.灵植好感度Dic.TryGetValue(灵植Tyep, out float 好感)
            ? 好感.ToString("0.##")
            : "0";

        // 服用次数（普通/变异各自独立计数）
        var 次数Dic = 是否变异 ? PlayerData.S.变异服用次数Dic : PlayerData.S.普通服用次数Dic;
        int 已服用 = 次数Dic != null && 次数Dic.TryGetValue(灵植Tyep, out int c) ? c : 0;
        服用次数.text = 已服用.ToString();

        // 服用效果：复用种子信息弹窗的效果文本构建
        服用效果.text = 种子信息弹窗.获取服用效果文本(灵植Tyep);
    }
}
