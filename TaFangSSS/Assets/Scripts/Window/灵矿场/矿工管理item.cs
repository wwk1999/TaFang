using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 矿工管理item : MonoBehaviour
{
    public Button bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 类型;
    public TextMeshProUGUI 阶数;
    public TextMeshProUGUI 等级;
    public GameObject 星级;
    public Button 改名Button;
    public GameObject 选中;
    [NonSerialized] public 矿工 矿工;

    public void SetItem()
    {
        bg.image.sprite = ResourcesConfig.Get灵矿场名册条目(矿工.QualityType);
        icon.sprite = ResourcesConfig.Get矿工头像(矿工.矿工类型, 矿工.阶数, 矿工.QualityType);
        name.text = 矿工.name;
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(矿工.QualityType);
        类型.text = 灵矿场Config.矿工类型string[矿工.矿工类型];
        阶数.text = PlayerData.S.Get阶数string(矿工.阶数);
        等级.text = "等级：LV." + 矿工.等级;
        选中.SetActive(false);
        Set功法星级();
    }

    public void 矿工改名(object[] obj)
    {
        矿工 item = obj[0] as 矿工;
        if (item == 矿工)
        {
            SetItem();
        }
    }

    public void 矿工升星(object[] obj)
    {
        if (矿工 == obj[0] as 矿工)
        {
            SetItem();
        }
    }
    private void Start()
    {        
        ObserverModuleManager.S.RegisterEvent("矿工升星",矿工升星);
        ObserverModuleManager.S.RegisterEvent("矿工改名", 矿工改名);
        ObserverModuleManager.S.RegisterEvent("矿工管理Item点击", 矿工管理Item点击);
        bg.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("矿工管理Item点击", 矿工);
        });
        改名Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("显示矿工改名弹窗", 矿工);
        });
    }

    public void 矿工管理Item点击(object[] obj)
    {
        矿工 i = obj[0] as 矿工;
        选中.SetActive(i == 矿工);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("矿工升星",矿工升星);
        ObserverModuleManager.S.UnRegisterEvent("矿工改名", 矿工改名);
        ObserverModuleManager.S.UnRegisterEvent("矿工管理Item点击", 矿工管理Item点击);
    }

    private void Set功法星级()
    {
        foreach (Transform item in 星级.transform)
        {
            Destroy(item.gameObject);
        }

        功法星级 功法星级 = 功法Config.Get功法星级(矿工.星级);
        Add功法星级(功法星级Type.钻石, 功法星级.钻石);
        Add功法星级(功法星级Type.太阳, 功法星级.太阳);
        Add功法星级(功法星级Type.月亮, 功法星级.月亮);
        Add功法星级(功法星级Type.星星, 功法星级.星星);
    }

    private void Add功法星级(功法星级Type type, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var item = Instantiate(Resources.Load<GameObject>("Prefabs/Window/技能树/功法星级item"), 星级.transform)
                .GetComponent<功法星级item>();
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            item.功法星级Type = type;
            item.SetItem();
        }
    }
}
