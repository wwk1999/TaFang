using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 种子/收获物信息弹窗：点击种子或收获物时展示基础属性与服用信息
/// </summary>
public class 种子信息弹窗 : MonoBehaviour
{
    public Button mask;

    public Image 图标;
    public Image 品质框;          // 可选：品质背景框
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

    private void Start()
    {
        if (mask != null) mask.onClick.AddListener(关闭);
    }

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
        if (品质框 != null) 品质框.sprite = ResourcesConfig.Get作物品质背景框(品质);
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

        // 服用效果
        服用效果.text = 灵植园Config.Get服用效果(灵植Tyep);
    }
}
