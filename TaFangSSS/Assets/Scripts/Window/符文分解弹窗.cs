using Config;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 符文分解弹窗：按品质勾选分解符文，被锁住的符文不分解，
/// 每个符文分解后按 符文Config.符文分解Dictionary 转换成道具「符箓」存入 PropListDic。
/// </summary>
public class 符文分解弹窗 : MonoBehaviour
{
    public Toggle 黄品Toggle;
    public Toggle 玄品Toggle;
    public Toggle 地品Toggle;
    public Toggle 天品Toggle;
    public Toggle 宇品Toggle;
    public Toggle 宙品Toggle;
    public Toggle 洪品Toggle;
    public Toggle 荒品Toggle;
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
        黄品Toggle.isOn = 黄;
        玄品Toggle.isOn = 玄;
        地品Toggle.isOn = 地;
        天品Toggle.isOn = 天;
        宇品Toggle.isOn = 宇;
        宙品Toggle.isOn = 宙;
        洪品Toggle.isOn = 洪;
        荒品Toggle.isOn = 荒;
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
        var 存档 = PlayerData.S.获取分解筛选存档(分解类型.符文);
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
        var 存档 = PlayerData.S.获取分解筛选存档(分解类型.符文);
        存档.品质勾选[0] = 黄;
        存档.品质勾选[1] = 玄;
        存档.品质勾选[2] = 地;
        存档.品质勾选[3] = 天;
        存档.品质勾选[4] = 宇;
        存档.品质勾选[5] = 宙;
        存档.品质勾选[6] = 洪;
        存档.品质勾选[7] = 荒;
    }

    /// <summary>
    /// 分解某品质符文：跳过被锁住的符文，其余全部移除并按数量产出符箓。
    /// 返回该品质分解获得的符箓数量。
    /// </summary>
    private int 分解品质(QualityType 品质)
    {
        var list = PlayerData.S.Get符文List(品质);
        if (list == null || list.Count == 0) return 0;

        int 单位符箓 = Mathf.RoundToInt(符文Config.符文分解Dictionary[品质]);
        int 获得符箓 = 0;
        // 从后往前遍历，边删边结算
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i].锁) continue;
            list.RemoveAt(i);
            获得符箓 += 单位符箓;
        }
        return Mathf.RoundToInt(获得符箓 * (1f + 属性config.仙子总属性.分解符箓增加 / 100f));
    }

    private void Start()
    {
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        分解Button.onClick.AddListener(() =>
        {
            int 符箓总数 = 0;
            if (黄) 符箓总数 += 分解品质(QualityType.黄品);
            if (玄) 符箓总数 += 分解品质(QualityType.玄品);
            if (地) 符箓总数 += 分解品质(QualityType.地品);
            if (天) 符箓总数 += 分解品质(QualityType.天品);
            if (宇) 符箓总数 += 分解品质(QualityType.宇品);
            if (宙) 符箓总数 += 分解品质(QualityType.宙品);
            if (洪) 符箓总数 += 分解品质(QualityType.洪品);
            if (荒) 符箓总数 += 分解品质(QualityType.荒品);

            if (符箓总数 == 0)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast", "没有可分解的符文(需勾选品质，且被锁住的符文不分解)");
                return;
            }
            PlayerData.S.PropListDic[PropType.符箓] += 符箓总数;
            ObserverModuleManager.S.SendEvent("SendUIToast", $"分解完成，获得{符箓总数}符箓");
            ObserverModuleManager.S.SendEvent("刷新背包");
            gameObject.SetActive(false);
        });

        黄品Toggle.onValueChanged.AddListener((value) => { 黄 = value; });
        玄品Toggle.onValueChanged.AddListener((value) => { 玄 = value; });
        地品Toggle.onValueChanged.AddListener((value) => { 地 = value; });
        天品Toggle.onValueChanged.AddListener((value) => { 天 = value; });
        宇品Toggle.onValueChanged.AddListener((value) => { 宇 = value; });
        宙品Toggle.onValueChanged.AddListener((value) => { 宙 = value; });
        洪品Toggle.onValueChanged.AddListener((value) => { 洪 = value; });
        荒品Toggle.onValueChanged.AddListener((value) => { 荒 = value; });
    }
}
