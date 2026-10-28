using System.Collections.Generic;
using System.Linq;
using Config;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 丹药分解弹窗：只按品质筛选分解丹药（丹药无阶数概念），
/// 品质勾选状态按 分解类型.丹药 独立存档。
/// </summary>
public class 丹药分解弹窗 : MonoBehaviour
{
    public Toggle 黄Toggle;
    public Toggle 玄Toggle;
    public Toggle 地Toggle;
    public Toggle 天Toggle;
    public Toggle 宇Toggle;
    public Toggle 宙Toggle;
    public Toggle 洪Toggle;
    public Toggle 荒Toggle;
    public Button 分解Button;
    public Button maskButton;

    private bool 黄 = false;
    private bool 玄 = false;
    private bool 地 = false;
    private bool 天 = false;
    private bool 宇 = false;
    private bool 宙 = false;
    private bool 洪 = false;
    private bool 荒 = false;

    public void SetToggle()
    {
        黄Toggle.isOn = 黄;
        玄Toggle.isOn = 玄;
        地Toggle.isOn = 地;
        天Toggle.isOn = 天;
        宇Toggle.isOn = 宇;
        宙Toggle.isOn = 宙;
        洪Toggle.isOn = 洪;
        荒Toggle.isOn = 荒;
    }

    private void OnEnable()
    {
        载入筛选存档();
        SetToggle();
    }

    private void OnDisable()
    {
        保存筛选存档();
    }

    private void 载入筛选存档()
    {
        var 存档 = PlayerData.S.获取分解筛选存档(分解类型.丹药);
        黄 = 存档.品质勾选[0];
        玄 = 存档.品质勾选[1];
        地 = 存档.品质勾选[2];
        天 = 存档.品质勾选[3];
        宇 = 存档.品质勾选[4];
        宙 = 存档.品质勾选[5];
        洪 = 存档.品质勾选[6];
        荒 = 存档.品质勾选[7];
    }

    private void 保存筛选存档()
    {
        var 存档 = PlayerData.S.获取分解筛选存档(分解类型.丹药);
        存档.品质勾选[0] = 黄;
        存档.品质勾选[1] = 玄;
        存档.品质勾选[2] = 地;
        存档.品质勾选[3] = 天;
        存档.品质勾选[4] = 宇;
        存档.品质勾选[5] = 宙;
        存档.品质勾选[6] = 洪;
        存档.品质勾选[7] = 荒;
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        分解Button.onClick.AddListener(() =>
        {
            // ToList() 先拍快照再遍历：循环体内的 Set丹药数量 会写丹药Dic，
            // 边枚举边写入会抛 "Collection was modified"（索引器写入也递增版本号）
            foreach (var item in PlayerData.S.丹药Dic.ToList())
            {
                // 脏数据防御：解析不出丹药类型的条目（如 "None_黄品"）跳过，
                // 否则 Get丹药分解价格 查 丹药类型Dic[None] 抛 KeyNotFoundException
                丹药Type 丹药Type = PlayerData.S.Get丹药Type(item.Key);
                if (丹药Type == 丹药Type.None) continue;

                QualityType qualityType = PlayerData.S.Get丹药品质(item.Key);
                // 各阶段库存独立，分解时必须按 key 自身的阶段清零，
                // 否则 2~9 阶的丹药会被错误地清到 1 阶的库存上
                int 阶段 = PlayerData.S.Get丹药阶段(item.Key);

                bool 分解 = false;
                switch (qualityType)
                {
                    case QualityType.黄品: 分解 = 黄; break;
                    case QualityType.玄品: 分解 = 玄; break;
                    case QualityType.地品: 分解 = 地; break;
                    case QualityType.天品: 分解 = 天; break;
                    case QualityType.宇品: 分解 = 宇; break;
                    case QualityType.宙品: 分解 = 宙; break;
                    case QualityType.洪品: 分解 = 洪; break;
                    case QualityType.荒品: 分解 = 荒; break;
                }
                if (分解)
                {
                    PlayerData.S.PropListDic[PropType.灵魂] += 丹药Config.Get丹药分解价格(丹药Type, qualityType, 阶段) * item.Value;
                    PlayerData.S.Set丹药数量(丹药Type, qualityType, 0, 阶段);
                }
            }
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });

        黄Toggle.onValueChanged.AddListener(v => 黄 = v);
        玄Toggle.onValueChanged.AddListener(v => 玄 = v);
        地Toggle.onValueChanged.AddListener(v => 地 = v);
        天Toggle.onValueChanged.AddListener(v => 天 = v);
        宇Toggle.onValueChanged.AddListener(v => 宇 = v);
        宙Toggle.onValueChanged.AddListener(v => 宙 = v);
        洪Toggle.onValueChanged.AddListener(v => 洪 = v);
        荒Toggle.onValueChanged.AddListener(v => 荒 = v);
    }
}
