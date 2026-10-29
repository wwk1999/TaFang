using System;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 仙女殿界面 : MonoBehaviour
{
    public Button 退出按钮;

    public GameObject 列表Content;
    public Image 立绘;
    public TextMeshProUGUI 仙子名;

    public TextMeshProUGUI 姓名;
    public TextMeshProUGUI 身份;
    public TextMeshProUGUI 性格;
    public TextMeshProUGUI 简介;
    public TextMeshProUGUI 每级效果;

    public TextMeshProUGUI 好感等级;
    public TextMeshProUGUI 当前好感;
    public TextMeshProUGUI 最大好感;
    public Image 好感进度条;

    public GameObject 等级列表Content;
    public GameObject 灵植列表Content;

    [NonSerialized] public 仙子Type 当前选择仙子 = 仙子Type.None;

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("仙女Item点击", 仙女Item点击);
        退出按钮.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("仙女Item点击", 仙女Item点击);
    }

    private void OnEnable()
    {
        Show();
    }

    private 仙子Type 取默认仙子()
    {
        foreach (var type in 阴阳殿Config.仙子解锁顺序)
        {
            if (PlayerData.S.仙女Dic[type].解锁) return type;
        }
        return 阴阳殿Config.仙子解锁顺序[0];
    }

    public void 仙女Item点击(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;
        当前选择仙子 = (仙子Type)obj[0];
        刷新选中状态();
        Show仙子信息();
    }

    private void 刷新选中状态()
    {
        foreach (Transform item in 列表Content.transform)
        {
            var 列表item = item.GetComponent<仙女列表item>();
            if (列表item == null) continue;
            列表item.是否选中 = 列表item.仙子Type == 当前选择仙子;
            列表item.SetItem();
        }
    }

    public void Show()
    {
        if (当前选择仙子 == 仙子Type.None) 当前选择仙子 = 取默认仙子();
        Show仙女列表();
        Show仙子信息();
    }

    private void Show仙女列表()
    {
        for (int i = 列表Content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(列表Content.transform.GetChild(i).gameObject);
        }

        foreach (var type in 阴阳殿Config.仙子解锁顺序)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/仙女殿/仙女列表item"), 列表Content.transform)
                .GetComponent<仙女列表item>();
            item.仙子Type = type;
            item.是否选中 = type == 当前选择仙子;
            item.SetItem();
        }
    }

    private void Show仙子信息()
    {
        var 仙女 = PlayerData.S.仙女Dic[当前选择仙子];

        立绘.sprite = ResourcesConfig.Get仙子Icon(当前选择仙子);
        仙子名.text = 阴阳殿Config.仙子名Dic[当前选择仙子];
        姓名.text = 阴阳殿Config.仙子名Dic[当前选择仙子];
        身份.text = 阴阳殿Config.仙子身份Dic[当前选择仙子];
        性格.text = 阴阳殿Config.仙子性格Dic[当前选择仙子];
        简介.text = 阴阳殿Config.仙子简介Dic[当前选择仙子];
        每级效果.text = 阴阳殿Config.Get每级奖励描述(当前选择仙子);

        int 上限 = 阴阳殿Config.Get好感度升级经验(仙女.好感度等级);
        好感等级.text = "LV." + 仙女.好感度等级;
        当前好感.text = PlayerData.S.格式化数字(仙女.好感度经验);
        最大好感.text = PlayerData.S.格式化数字(上限);
        好感进度条.fillAmount = 上限 > 0 ? Mathf.Clamp01((float)仙女.好感度经验 / 上限) : 0f;

        Show等级列表();
        Show灵植列表();
    }

    private void Show等级列表()
    {
        for (int i = 等级列表Content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(等级列表Content.transform.GetChild(i).gameObject);
        }

        var 奖励 = 阴阳殿Config.仙子等级解锁奖励[当前选择仙子];
        var 属性列表 = new 仙子属性[]
        {
            奖励.仙子属性1, 奖励.仙子属性2, 奖励.仙子属性3,
            奖励.仙子属性4, 奖励.仙子属性5, 奖励.仙子属性6,
        };

        for (int i = 0; i < 阴阳殿Config.仙子解锁等级.Count; i++)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/仙女殿/好感度等级item"), 等级列表Content.transform)
                .GetComponent<好感度等级item>();
            item.等级 = 阴阳殿Config.仙子解锁等级[i];
            item.属性 = 属性列表[i];
            item.SetItem();
        }
    }

    private void Show灵植列表()
    {
        for (int i = 灵植列表Content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(灵植列表Content.transform.GetChild(i).gameObject);
        }

        foreach (var type in 阴阳殿Config.仙子喜好灵植dic[当前选择仙子])
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/仙女殿/仙女灵植item"), 灵植列表Content.transform)
                .GetComponent<仙女灵植item>();
            item.灵植Type = type;
            item.SetItem();
        }
    }
}
