using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 土地窗口 : MonoBehaviour
{
    public Button mask;

    public Image 当前土地Image;
    public TextMeshProUGUI 当前土地名;
    public Image 升级后土地Image;
    public TextMeshProUGUI 升级后土地名;

    // 顺序固定：生长速度 / 产量加成 / 青石加成 / 经验加成 / 变异概率
    public TextMeshProUGUI[] 当前数值;
    public TextMeshProUGUI[] 升级后数值;

    public Button 升级Button;
    public TextMeshProUGUI 需要等级;
    public TextMeshProUGUI 需要青石;

    private int 当前index = 1;

    private void Start()
    {
        if (mask != null) mask.onClick.AddListener(关闭);
        升级Button.onClick.AddListener(升级);
    }

    /// <summary>
    /// 点击土地item时调用，打开对应土地的属性/升级界面
    /// </summary>
    public void 打开(int index)
    {
        当前index = index;
        // 红土地是最高等级，没有可升级的下一级，不弹窗只提示
        if (PlayerData.S.灵植土地列表[index].土地Type == 土地Type.红土地)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "红土地已是最高等级");
            return;
        }
        gameObject.SetActive(true);
        SetItem();
    }

    private void 关闭()
    {
        gameObject.SetActive(false);
    }

    public void SetItem()
    {
        土地 当前土地 = PlayerData.S.灵植土地列表[当前index];
        土地Type 当前类型 = 当前土地.土地Type;
        土地Type 下一级类型 = 当前类型 + 1;

        bool 有下一级 = 灵植园Config.土地升级消耗.ContainsKey(当前类型)
                        && 灵植园Config.土地数值.ContainsKey(下一级类型);

        当前土地Image.sprite = ResourcesConfig.Get土地Sprite(当前类型);
        当前土地名.text = 当前类型.ToString();

        // 已达最高级时，右侧显示当前土地，按钮置灰
        升级后土地Image.sprite = ResourcesConfig.Get土地Sprite(有下一级 ? 下一级类型 : 当前类型);
        升级后土地名.text = 有下一级 ? 下一级类型.ToString() : "已满级";

        土地数值 当前数值配置 = 灵植园Config.土地数值[当前类型];
        土地数值 下一级数值配置 = 灵植园Config.土地数值[有下一级 ? 下一级类型 : 当前类型];

        Set数值(当前数值, 当前数值配置);
        Set数值(升级后数值, 下一级数值配置);

        Set消耗(有下一级, 下一级类型);

        升级Button.interactable = 有下一级;
    }

    /// <summary>
    /// 升级到下一级所需的灵植园建筑等级与青石消耗
    /// </summary>
    private void Set消耗(bool 有下一级, 土地Type 下一级类型)
    {
        if (!有下一级)
        {
            if (需要等级 != null) 需要等级.text = "已达到最高等级";
            if (需要青石 != null) 需要青石.text = "";
            return;
        }

        if (需要等级 != null)
        {
            需要等级.text = 获取所需灵植园等级(下一级类型).ToString();
        }

        if (需要青石 != null)
        {
            float 消耗 = 灵植园Config.土地升级消耗[下一级类型 - 1];
            需要青石.text = PlayerData.S.格式化数字(消耗);
        }
    }

    /// <summary>
    /// 反查：要使土地最高等级达到目标类型，至少需要的灵植园建筑等级
    /// </summary>
    private static int 获取所需灵植园等级(土地Type 目标类型)
    {
        for (int 等级 = 0; 等级 <= 21; 等级++)
        {
            if (!道场Config.灵植园配置.ContainsKey(等级)) continue;
            if (道场Config.灵植园配置[等级].土地最高等级 >= 目标类型) return 等级;
        }

        return 21;
    }

    /// <summary>
    /// 五个数值依次为：生长速度、产量加成、青石加成、经验加成、变异概率，均按百分比展示
    /// </summary>
    private void Set数值(TextMeshProUGUI[] 文本列表, 土地数值 数值配置)
    {
        if (文本列表 == null || 文本列表.Length < 5) return;

        文本列表[0].text = 数值配置.速度.ToString("F0") + "%";
        文本列表[1].text = 数值配置.增产.ToString("F0") + "%";
        文本列表[2].text = 数值配置.青石加成.ToString("F0") + "%";
        文本列表[3].text = 数值配置.经验加成.ToString("F0") + "%";
        文本列表[4].text = 数值配置.异化.ToString("F0") + "%";
    }

    private void 升级()
    {
        土地 当前土地 = PlayerData.S.灵植土地列表[当前index];
        土地Type 当前类型 = 当前土地.土地Type;

        // 是否还有下一级（红土地已是最高级）
        if (!灵植园Config.土地升级消耗.ContainsKey(当前类型))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "已达到最高等级");
            SetItem();
            return;
        }

        // 受领主府灵植园建筑的「土地最高等级」限制
        if (!PlayerData.S.建筑等级Dic.TryGetValue(建筑Type.灵植园, out int 灵植园等级)
            || !道场Config.灵植园配置.ContainsKey(灵植园等级))
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "灵植园等级不足，无法升级土地");
            return;
        }
        土地Type 土地最高等级 = 道场Config.灵植园配置[灵植园等级].土地最高等级;
        if (当前类型 >= 土地最高等级)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "灵植园等级不足，无法升级土地");
            return;
        }

        float 消耗 = 灵植园Config.土地升级消耗[当前类型];
        if (PlayerData.S.青石 < 消耗)
        {
            ObserverModuleManager.S.SendEvent("SendUIToast", "青石不足");
            return;
        }

        PlayerData.S.青石 -= 消耗;
        当前土地.土地Type = 当前类型 + 1;

        ObserverModuleManager.S.SendEvent("Set青石");
        ObserverModuleManager.S.SendEvent("刷新灵植园");
        SetItem();
    }
}
