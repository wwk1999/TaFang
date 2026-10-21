using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public enum 英雄详情界面显示类型
{
    None,
    法器,
    功法,
    境界,
    详情,
    灵兽,
}
public class 英雄详情界面 : MonoBehaviour
{
    //法器
    public GameObject 当前法器Content;
    public Button 武器Button;
    public Button 衣服Button;
    public Button 鞋子Button;
    public Button 头盔Button;
    public GameObject 装备背包Content;
    public Button 左Button;
    public Button 右Button;
    public TextMeshProUGUI Num;
    public Button 装备Button;
    public GameObject 排序Content;
    
    
    
    public GameObject 功法Panel;
    public GameObject 境界Panel;
    public GameObject 法器Panel;

    
    
    public GameObject 英雄列表content;
    public Button 境界Button;
    public Button 功法Button;
    public Button 法器Button;
    public Button 详情Button;
    public Button 灵兽Button;

    public Button 境界亮Button;
    public Button 功法亮Button;
    public Button 法器亮Button;
    public Button 详情亮Button;
    public Button 灵兽亮Button;

    public Button 重置Button;
    public Button 提升境界Button;
    public Button 退出Button;
    public Image 经验值icon;
    public TextMeshProUGUI 经验值count;
    public TextMeshProUGUI 经验值text;
    public TextMeshProUGUI 元神;
    public TextMeshProUGUI 技能点;
    public GameObject 技能Content;
    
    
    //功法
    public GameObject 功法详情content;
    public Image bg;
    public Image icon;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 职业;
    public TextMeshProUGUI info;
    public GameObject 功法星级content;
    public TextMeshProUGUI 当前值;
    public TextMeshProUGUI 最大值;
    public Image 功法经验条;
    public TextMeshProUGUI 基础属性;
    public TextMeshProUGUI 每重增幅;
    public TextMeshProUGUI 当前层数;
    public TextMeshProUGUI 当前加成;
    public TextMeshProUGUI 升星功法经验count;
    public Image 升星需要功法Icon;
    public TextMeshProUGUI 升星需要功法Text;

    public Button 升星Button;
    public GameObject 功法content;
    

    
    [NonSerialized]public HeroType 当前heroType=HeroType.丹童;
    private 英雄详情界面显示类型 显示类型 = 英雄详情界面显示类型.详情;
    
    //详情界面
    public GameObject 详情Panel;
    public Image 英雄icon;
    public TextMeshProUGUI 英雄name;
    public TextMeshProUGUI 英雄职业;
    public TextMeshProUGUI 英雄元素;
    public TextMeshProUGUI 英雄最高境界;
    public Image 职业icon;
    public Image 元素icon;
    public Image 技能icon;
    public TextMeshProUGUI 技能名;
    public TextMeshProUGUI 技能冷却时间;
    public TextMeshProUGUI 技能介绍;
    public Image 神通icon;
    public TextMeshProUGUI 神通名;
    public TextMeshProUGUI 神通冷却时间;
    public TextMeshProUGUI 神通能量;
    public TextMeshProUGUI 神通介绍;

    public void Show英雄详情()
    {
        英雄icon.sprite = ResourcesConfig.Get英雄平台Sprite(当前heroType);
        英雄name.text = HeroConfig.HeroNameDic[当前heroType];
        英雄职业.text = HeroConfig.Get职业Name(HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType);
        英雄元素.text = HeroConfig.HeroZhiYeDic[当前heroType].yuanSuType.ToString();
        英雄最高境界.text = 英雄技能树Config.英雄最高境界Dic[HeroConfig.HeroQualityDic[当前heroType]].ToString();
        职业icon.sprite = ResourcesConfig.Get职业icon(HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType);
        元素icon.sprite = ResourcesConfig.Get元素Sprite(HeroConfig.HeroZhiYeDic[当前heroType].yuanSuType);
        技能icon.sprite = ResourcesConfig.Get技能icon(当前heroType);
        技能名.text = HeroConfig.SkillNameDic[当前heroType];
        技能冷却时间.text = HeroConfig.HeroAttackTimeDic[当前heroType] + "S";
        技能介绍.text = HeroConfig.HeroSkillInfoDic[当前heroType];
        神通名.text = HeroConfig.英雄神通配置Dic[当前heroType].name;
        神通冷却时间.text = HeroConfig.英雄神通配置Dic[当前heroType].cd+"S";
        神通能量.text = HeroConfig.英雄神通配置Dic[当前heroType].能量.ToString();
        神通介绍.text = HeroConfig.Hero神通InfoDic[当前heroType];
        神通icon.sprite = ResourcesConfig.Get英雄神通icon(当前heroType);
    }
    private 法器类型 当前法器类型 = 法器类型.武器;
    private int 法器背包当前页数=1;

    public void Show当前法器()
    {
        foreach (Transform item in 当前法器Content.transform)
        {
            Destroy(item.gameObject);
        }

        var 武器 = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情当前装备item"), 当前法器Content.transform)
            .GetComponent<英雄详情当前装备item>();
        武器.法器 = PlayerData.S.HeroDataDic[当前heroType].武器;
        if (武器.法器 != null)
        {
           武器.法器.HeroType = 当前heroType; 
        }
        武器.SetItem();
        
        var 衣服 = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情当前装备item"), 当前法器Content.transform)
            .GetComponent<英雄详情当前装备item>();
        衣服.法器 = PlayerData.S.HeroDataDic[当前heroType].衣服;
        if (衣服.法器 != null)
        {
            衣服.法器.HeroType = 当前heroType; 
        }
        衣服.SetItem();
        
        var 鞋子 = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情当前装备item"), 当前法器Content.transform)
            .GetComponent<英雄详情当前装备item>();
        鞋子.法器 = PlayerData.S.HeroDataDic[当前heroType].鞋子;
        if (鞋子.法器 != null)
        {
          鞋子.法器.HeroType = 当前heroType;  
        }
        鞋子.SetItem();
        
        
        var 头盔 = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情当前装备item"), 当前法器Content.transform)
            .GetComponent<英雄详情当前装备item>();
        头盔.法器 = PlayerData.S.HeroDataDic[当前heroType].头盔;
        if (头盔.法器 != null)
        {
            头盔.法器.HeroType = 当前heroType;
        }
        头盔.SetItem();
        
    }

    public void Show排序()
    {
        foreach (Transform item in 排序Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in EquipConfig.附加属性NameDic)
        {
            var 排序item = Instantiate(Resources.Load("Prefabs/Window/技能树/装备排序item"), 排序Content.transform)
                .GetComponent<装备排序item>();
            排序item.附加属性Type = item.Key;
            排序item.SetItem();
        }
        ObserverModuleManager.S.SendEvent("装备排序点击",HeroWindowController.S.当前排序附加属性Type);
    }
    /// <summary>
    /// 当前条件下背包总页数：综合当前英雄职业、当前法器部位、法器数量（每页20个，至少1页）
    /// </summary>
    private int Get法器背包总页数()
    {
        ZhiYeType 当前职业 = HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType;
        var list = HeroWindowController.S.Get排序法器(当前法器类型, HeroWindowController.S.当前排序附加属性Type, 当前职业);
        return Mathf.Max(1, Mathf.CeilToInt(list.Count / 20f));
    }

    public void Show法器背包()
    {
        foreach (Transform item in 装备背包Content.transform)
        {
            Destroy(item.gameObject);
        }
        ZhiYeType 当前职业 = HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType;
        var list = HeroWindowController.S.Get排序法器(当前法器类型, HeroWindowController.S.当前排序附加属性Type, 当前职业);
        int 总页数 = Mathf.Max(1, Mathf.CeilToInt(list.Count / 20f));
        if (法器背包当前页数 > 总页数) 法器背包当前页数 = 总页数;
        Num.text = $"{法器背包当前页数}/{总页数}";
        int start = 20 * (法器背包当前页数 - 1);
        for (int i = start; i < start + 20; i++)
        {
            if (i >= list.Count) break;
            var 装备 = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情装备背包item"), 装备背包Content.transform)
                .GetComponent<英雄详情装备背包item>();
            装备.法器 = list[i];
            装备.已装备 = list[i].HeroType == 当前heroType;
            装备.SetItem();
        }
    }

    public void Set功法星级()
    {
        foreach (Transform item in 功法星级content.transform)
        {
            Destroy(item.gameObject);
        }

        功法星级 功法星级 = 功法Config.Get功法星级(PlayerData.S.HeroDataDic[当前heroType].功法星级);
        for (int i = 0; i < 功法星级.钻石; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/技能树/功法星级item"), 功法星级content.transform)
                .GetComponent<功法星级item>();
            item.功法星级Type=功法星级Type.钻石;
            item.SetItem();
        }
        
        for (int i = 0; i < 功法星级.太阳; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/技能树/功法星级item"), 功法星级content.transform)
                .GetComponent<功法星级item>();
            item.功法星级Type=功法星级Type.太阳;
            item.SetItem();
        }
        
        for (int i = 0; i < 功法星级.月亮; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/技能树/功法星级item"), 功法星级content.transform)
                .GetComponent<功法星级item>();
            item.功法星级Type=功法星级Type.月亮;
            item.SetItem();
        }
        
        for (int i = 0; i < 功法星级.星星; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/技能树/功法星级item"), 功法星级content.transform)
                .GetComponent<功法星级item>();
            item.功法星级Type=功法星级Type.星星;
            item.SetItem();
        }
    }
    
    
    
    public void 刷新功法详情()
    {
        功法Type 功法Type = PlayerData.S.HeroDataDic[当前heroType].功法Type;
        if (功法Type == 功法Type.None)
        {
            功法详情content.SetActive(false);
            return;
        }
        int 功法等级 = PlayerData.S.HeroDataDic[当前heroType].功法等级;
        int 功法星级 = PlayerData.S.HeroDataDic[当前heroType].功法星级;
        功法详情content.SetActive(true);
        bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法Config.功法TypeQualityDic[功法Type]);
        icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
        name.text = 功法Config.功法名Dic[功法Type];
        name.colorGradientPreset = ResourcesConfig.Get品质TMP(功法Config.功法TypeQualityDic[功法Type]);
        职业.text = HeroConfig.Get职业Name(功法Config.功法职业Dic[功法Type]);
        info.text = 功法Config.功法介绍Dic[功法Type];
        Set功法星级();
        当前值.text = PlayerData.S.HeroDataDic[当前heroType].功法经验.ToString();
        最大值.text = 功法Config.Get功法升级经验(PlayerData.S.HeroDataDic[当前heroType].功法等级).ToString();
        功法经验条.fillAmount = PlayerData.S.HeroDataDic[当前heroType].功法经验 /
                           功法Config.Get功法升级经验(PlayerData.S.HeroDataDic[当前heroType].功法等级);
        基础属性.text = 功法Config.Get功法基础属性String(功法Type);
        当前层数.text = PlayerData.S.HeroDataDic[当前heroType].功法等级.ToString();
        ZhiYeType zhiYeType = 功法Config.功法职业Dic[功法Type];
        float 辅助值 = 功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]];
        float 总最终伤害 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[功法Type]]*功法等级*(1f+功法Config.Get功法星级总增幅(PlayerData.S.HeroDataDic[当前heroType].功法星级)/100f);
        float 总辅助值 = 功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[功法Type]]*功法等级*(1f+功法Config.Get功法星级总增幅(PlayerData.S.HeroDataDic[当前heroType].功法星级)/100f);
        float 最终伤害 = 功法Config.功法升级最终伤害奖励Dic[功法Config.功法TypeQualityDic[功法Type]];
        Color c = new Color(1/255f, 95/255f, 0f); // 橙色
        if (zhiYeType == ZhiYeType.辅助)
        {
            当前加成.text=$"被辅助英雄伤害+{PlayerData.S.格式化数字(总辅助值)}%";
            每重增幅.text = $"被辅助英雄伤害+{辅助值}%";
        }
        else
        {
            当前加成.text = $"英雄最终伤害+{PlayerData.S.格式化数字(总最终伤害)}%";
            每重增幅.text = $"英雄最终伤害+{最终伤害}%";
        }

        升星需要功法Icon.gameObject.SetActive(功法星级%5==0&&功法星级>0);
        升星需要功法Text.gameObject.SetActive(功法星级%5==0&&功法星级>0);
        升星需要功法Icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
        升星功法经验count.text = PlayerData.S.格式化数字(功法Config.功法升星经验[功法Config.功法TypeQualityDic[功法Type]]);
    }

    public void 刷新功法背包()
    {
        foreach (Transform item in 功法content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in PlayerData.S.功法数量Dic)
        {
            if (item.Value > 0&&功法Config.功法职业Dic[item.Key]==HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
            {
                var baggrid = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情功法item"), 功法content.transform).GetComponent<英雄详情功法item>();
                baggrid.功法Type = item.Key;
                baggrid.HeroType = 当前heroType;
                baggrid.SetItem();
            }
        }
    }


    public void Show功法()
    {
        刷新功法背包();
        刷新功法详情();
    }
    
    
    public void 刷新境界材料()
    {
        float 经验值 = 0;
        switch (HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
        {
            case ZhiYeType.射手:
                经验值text.text = "射手经验值：";
                经验值 = PlayerData.S.PropListDic[PropType.射手经验值];
                break;
            case ZhiYeType.战士:
                经验值text.text = "战士经验值：";
                经验值 = PlayerData.S.PropListDic[PropType.战士经验值];
                break;
            case ZhiYeType.法师:
                经验值text.text = "法师经验值：";

                经验值 = PlayerData.S.PropListDic[PropType.法师经验值];
                break;
            case ZhiYeType.辅助:
                经验值text.text = "辅助经验值：";

                经验值 = PlayerData.S.PropListDic[PropType.辅助经验值];
                break;
            case ZhiYeType.控制:
                经验值text.text = "控制经验值：";

                经验值 = PlayerData.S.PropListDic[PropType.控制经验值];
                break;
        }
        经验值icon.sprite=ResourcesConfig.Get职业经验值Sprite(HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType);
        经验值count.text =
            $"{PlayerData.S.格式化数字(经验值)}/{PlayerData.S.格式化数字(HeroConfig.英雄提升境界经验值Dic[HeroConfig.HeroQualityDic[当前heroType]])}";
        元神.text = $"{PlayerData.S.HeroDataDic[当前heroType].元神}/1";
        技能点.text = PlayerData.S.HeroDataDic[当前heroType].技能点.ToString();
    }

    public void 英雄详情英雄点击(object[] obj)
    {
        HeroType heroType = (HeroType)obj[0];
        当前heroType = heroType;
        法器背包当前页数 = 1;
        刷新界面();
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("右键装备法器",右键装备法器);
        ObserverModuleManager.S.UnRegisterEvent("装备排序点击",装备排序点击);
        ObserverModuleManager.S.UnRegisterEvent("刷新英雄详情界面",刷新英雄详情界面);
        ObserverModuleManager.S.UnRegisterEvent("刷新技能面板",刷新技能面板);
        ObserverModuleManager.S.UnRegisterEvent("英雄详情英雄点击",英雄详情英雄点击);
        ObserverModuleManager.S.UnRegisterEvent("灵兽性别筛选", 灵兽性别筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵兽品级筛选", 灵兽品级筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵兽血脉筛选", 灵兽血脉筛选);
        ObserverModuleManager.S.UnRegisterEvent("灵兽阶段筛选", 灵兽阶段筛选);
    }

    public void 刷新技能面板(object[] obj)
    {
        刷新界面();
    }

    public void 刷新英雄详情界面(object[] obj)
    {
        刷新界面();
    }

    public void Show法器()
    {
        Show当前法器();
        Show法器背包();
        Show排序();
    }

    public void 装备排序点击(object[] obj)
    {
        Show法器背包();
    }

    public void 装备法器()
    {
        if (HeroWindowController.S.英雄详情界面当前选择法器== null)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","请选择装备法器");
                    return;
                }

            法器类型 法器类型 = 法器Config.法器类型Dic[HeroWindowController.S.英雄详情界面当前选择法器.法器Type];

                // 修复：新法器如果还戴在别的英雄身上，先从那位英雄的对应槽位摘下来。
                // 原代码只处理"当前英雄槽位里的旧法器"，从不清"新法器的前任主人"——
                // 结果两个英雄的槽位同时引用同一件法器，属性两边都生效
                var 新法器 = HeroWindowController.S.英雄详情界面当前选择法器;
                if (新法器.HeroType != HeroType.None && 新法器.HeroType != 当前heroType)
                {
                    switch (法器类型)
                    {
                        case 法器类型.头盔: PlayerData.S.HeroDataDic[新法器.HeroType].头盔 = null; break;
                        case 法器类型.衣服: PlayerData.S.HeroDataDic[新法器.HeroType].衣服 = null; break;
                        case 法器类型.鞋子: PlayerData.S.HeroDataDic[新法器.HeroType].鞋子 = null;
                            break;
                        case 法器类型.武器: PlayerData.S.HeroDataDic[新法器.HeroType].武器 = null;
                            break;
                    }
                    Sync法器列表(新法器, 新法器.HeroType);
                }

                switch (法器类型)
                {
                    case 法器类型.头盔:
                        if(PlayerData.S.HeroDataDic[当前heroType].头盔!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[当前heroType].头盔;
                            if (旧法器.HeroType != HeroType.None)
                            {
                                PlayerData.S.HeroDataDic[旧法器.HeroType].头盔 = null;
                            }
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, 当前heroType);
                        }
                        PlayerData.S.HeroDataDic[当前heroType].头盔 = HeroWindowController.S.英雄详情界面当前选择法器;
                        break;
                    case 法器类型.衣服:
                        if(PlayerData.S.HeroDataDic[当前heroType].衣服!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[当前heroType].衣服;
                            if (旧法器.HeroType != HeroType.None)
                            {
                                PlayerData.S.HeroDataDic[旧法器.HeroType].衣服 = null;
                            }
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, 当前heroType);
                        }
                        PlayerData.S.HeroDataDic[当前heroType].衣服 = HeroWindowController.S.英雄详情界面当前选择法器;
                        break;
                    case 法器类型.鞋子:
                        if(PlayerData.S.HeroDataDic[当前heroType].鞋子!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[当前heroType].鞋子;
                            if (旧法器.HeroType != HeroType.None)
                            {
                                PlayerData.S.HeroDataDic[旧法器.HeroType].鞋子 = null;
                            }
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, 当前heroType);
                        }
                        PlayerData.S.HeroDataDic[当前heroType].鞋子 = HeroWindowController.S.英雄详情界面当前选择法器;
                        break;
                    case 法器类型.武器:
                        if(PlayerData.S.HeroDataDic[当前heroType].武器!=null)
                        {
                            var 旧法器 = PlayerData.S.HeroDataDic[当前heroType].武器;
                            if (旧法器.HeroType != HeroType.None)
                            {
                                PlayerData.S.HeroDataDic[旧法器.HeroType].武器 = null;
                            }
                            旧法器.HeroType = HeroType.None;
                            Sync法器列表(旧法器, 当前heroType);
                        }
                        PlayerData.S.HeroDataDic[当前heroType].武器 = HeroWindowController.S.英雄详情界面当前选择法器;
                        break;
                }
                HeroWindowController.S.英雄详情界面当前选择法器.HeroType=当前heroType;
                Show当前法器();
                Show法器背包();
    }
    public void 右键装备法器(object[] obj)
    {
        装备法器();
    }
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("右键装备法器",右键装备法器);
        ObserverModuleManager.S.RegisterEvent("装备排序点击",装备排序点击);
        ObserverModuleManager.S.RegisterEvent("刷新英雄详情界面",刷新英雄详情界面);
        ObserverModuleManager.S.RegisterEvent("刷新技能面板",刷新技能面板);
        ObserverModuleManager.S.RegisterEvent("英雄详情英雄点击",英雄详情英雄点击);
        ObserverModuleManager.S.RegisterEvent("灵兽性别筛选", 灵兽性别筛选);
        ObserverModuleManager.S.RegisterEvent("灵兽品级筛选", 灵兽品级筛选);
        ObserverModuleManager.S.RegisterEvent("灵兽血脉筛选", 灵兽血脉筛选);
        ObserverModuleManager.S.RegisterEvent("灵兽阶段筛选", 灵兽阶段筛选);
        Init灵兽筛选();
        性别Button.onClick.AddListener(() =>
        {
            灵兽筛选mask.gameObject.SetActive(true);
            性别下拉区域.gameObject.SetActive(true);
        });
        品级Button.onClick.AddListener(() =>
        {
            灵兽筛选mask.gameObject.SetActive(true);
            品级下拉区域.gameObject.SetActive(true);
        });
        血脉Button.onClick.AddListener(() =>
        {
            灵兽筛选mask.gameObject.SetActive(true);
            血脉下拉区域.gameObject.SetActive(true);
        });
        阶段Button.onClick.AddListener(() =>
        {
            灵兽筛选mask.gameObject.SetActive(true);
            阶段下拉区域.gameObject.SetActive(true);
        });
        灵兽筛选mask.onClick.AddListener(() =>
        {
            性别下拉区域.gameObject.SetActive(false);
            品级下拉区域.gameObject.SetActive(false);
            血脉下拉区域.gameObject.SetActive(false);
            阶段下拉区域.gameObject.SetActive(false);
            灵兽筛选mask.gameObject.SetActive(false);
        });
        灵兽bg.onClick.AddListener(() =>
        {
            卸下灵兽();
        });
        灵兽左翻页.onClick.AddListener(() =>
        {
            灵兽页数--;
            Show灵兽背包();
        });
        灵兽右翻页.onClick.AddListener(() =>
        {
            灵兽页数++;
            Show灵兽背包();
        });
        左Button.onClick.AddListener(() =>
        {
            if (法器背包当前页数 > 1)
            {
                法器背包当前页数--;
                Show法器背包();
            }
        });
        右Button.onClick.AddListener(() =>
        {
            // 总页数已综合考虑：当前英雄职业 + 当前法器部位 + 过滤后的法器数量（每页20个）
            if (法器背包当前页数 < Get法器背包总页数())
            {
                法器背包当前页数++;
                Show法器背包();
            }
        });
        武器Button.onClick.AddListener(() =>
        {
            法器背包当前页数 = 1;
            武器Button.image.sprite = ResourcesConfig.标签亮;
            衣服Button.image.sprite = ResourcesConfig.标签暗;
            鞋子Button.image.sprite = ResourcesConfig.标签暗;
            头盔Button.image.sprite = ResourcesConfig.标签暗;
            HeroWindowController.S.英雄详情界面当前选择法器 = null;
            if (当前法器类型 != 法器类型.武器)
            {
               当前法器类型 = 法器类型.武器;
                Show法器背包(); 
            }
        });
        
        鞋子Button.onClick.AddListener(() =>
        {
            法器背包当前页数 = 1;
            武器Button.image.sprite = ResourcesConfig.标签暗;
            衣服Button.image.sprite = ResourcesConfig.标签暗;
            鞋子Button.image.sprite = ResourcesConfig.标签亮;
            头盔Button.image.sprite = ResourcesConfig.标签暗;
            HeroWindowController.S.英雄详情界面当前选择法器 = null;
            if (当前法器类型 != 法器类型.鞋子)
            {
                当前法器类型 = 法器类型.鞋子;
                Show法器背包(); 
            }
        });
        
        头盔Button.onClick.AddListener(() =>
        {
            法器背包当前页数 = 1;
            武器Button.image.sprite = ResourcesConfig.标签暗;
            衣服Button.image.sprite = ResourcesConfig.标签暗;
            鞋子Button.image.sprite = ResourcesConfig.标签暗;
            头盔Button.image.sprite = ResourcesConfig.标签亮;
            HeroWindowController.S.英雄详情界面当前选择法器 = null;
            if (当前法器类型 != 法器类型.头盔)
            {
                当前法器类型 = 法器类型.头盔;
                Show法器背包(); 
            }
        });
        
        衣服Button.onClick.AddListener(() =>
        {
            法器背包当前页数 = 1;
            HeroWindowController.S.英雄详情界面当前选择法器 = null;
            武器Button.image.sprite = ResourcesConfig.标签暗;
            衣服Button.image.sprite = ResourcesConfig.标签亮;
            鞋子Button.image.sprite = ResourcesConfig.标签暗;
            头盔Button.image.sprite = ResourcesConfig.标签暗;
            if (当前法器类型 != 法器类型.衣服)
            {
                当前法器类型 = 法器类型.衣服;
                Show法器背包(); 
            }
        });
        装备Button.onClick.AddListener(() =>
        {
            装备法器();
        });
        
        升星Button.onClick.AddListener(() =>
        {
            int 功法星级 = PlayerData.S.HeroDataDic[当前heroType].功法星级;
            功法Type 功法Type = PlayerData.S.HeroDataDic[当前heroType].功法Type;
            QualityType 功法QualityType = 功法Config.功法TypeQualityDic[功法Type];
            if (PlayerData.S.HeroDataDic[当前heroType].功法星级 >= 功法Config.功法最高星级Dic[功法QualityType])
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","功法已达最高星级");
                return;
            }
            if (PlayerData.S.PropListDic[PropType.功法经验] < 功法Config.功法升星经验[功法QualityType])
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","功法经验不足");
                return;
            }

            if (功法星级 % 5 == 0 && 功法星级 > 0)
            {
                if (PlayerData.S.功法数量Dic[功法Type] < 1)
                {
                    ObserverModuleManager.S.SendEvent("SendUIToast","升星功法不足");
                    return;
                }
            }
            PlayerData.S.PropListDic[PropType.功法经验] -= 功法Config.功法升星经验[功法QualityType];
            if (功法星级 % 5 == 0 && 功法星级 > 0)
            {
                PlayerData.S.功法数量Dic[功法Type] -= 1;
            }
            PlayerData.S.HeroDataDic[当前heroType].功法星级++;
            ObserverModuleManager.S.SendEvent("刷新英雄卡片功法",当前heroType);
            刷新界面();
        });
        境界Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.境界;
            刷新界面();
        });
        法器Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.法器;
            刷新界面();
        });
        详情Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.详情;
            刷新界面();
        });
        灵兽Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.灵兽;
            刷新界面();
        });
        功法Button.onClick.AddListener(() =>
        {
            显示类型 = 英雄详情界面显示类型.功法;
            刷新界面();
        });
        境界Button.onClick.AddListener(() =>
        {
            if (显示类型 != 英雄详情界面显示类型.境界)
            {
                显示类型 = 英雄详情界面显示类型.境界;
                设置Button();
                Show技能面板();
            }
        });
        重置Button.onClick.AddListener(() =>
        {
            PlayerData.S.HeroDataDic[当前heroType].技能点 = PlayerData.S.HeroDataDic[当前heroType].境界;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    PlayerData.S.英雄技能树Dic[当前heroType][i][j]=0;
                }
            }
            ObserverModuleManager.S.SendEvent("SendUIToast","重置成功");
            刷新境界材料();
            Show技能面板();
        });
        提升境界Button.onClick.AddListener(() =>
        {
            float 经验值 = 0;
            switch (HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
            {
                case ZhiYeType.射手:
                    经验值 = PlayerData.S.PropListDic[PropType.射手经验值];
                    break;
                case ZhiYeType.战士:
                    经验值 = PlayerData.S.PropListDic[PropType.战士经验值];
                    break;
                case ZhiYeType.法师:
                    经验值 = PlayerData.S.PropListDic[PropType.法师经验值];
                    break;
                case ZhiYeType.辅助:
                    经验值 = PlayerData.S.PropListDic[PropType.辅助经验值];
                    break;
                case ZhiYeType.控制:
                    经验值 = PlayerData.S.PropListDic[PropType.控制经验值];
                    break;
            }
            if (PlayerData.S.HeroDataDic[当前heroType].境界 >= 英雄技能树Config.英雄最高境界Dic[HeroConfig.HeroQualityDic[当前heroType]])
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","已经达到最高境界");
                return;
            }
            float 需要经验值 = HeroConfig.英雄提升境界经验值Dic[HeroConfig.HeroQualityDic[当前heroType]];
            if (PlayerData.S.HeroDataDic[当前heroType].元神 <= 0 || 经验值 < 需要经验值)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","材料不足");
                return;
            }

            PlayerData.S.HeroDataDic[当前heroType].技能点++;
            PlayerData.S.HeroDataDic[当前heroType].境界++;
            PlayerData.S.HeroDataDic[当前heroType].元神--;
            switch (HeroConfig.HeroZhiYeDic[当前heroType].zhiYeType)
            {
                case ZhiYeType.射手:
                    PlayerData.S.PropListDic[PropType.射手经验值]-=需要经验值;
                    break;
                case ZhiYeType.战士:
                    PlayerData.S.PropListDic[PropType.战士经验值]-=需要经验值;
                    break;
                case ZhiYeType.法师:
                    PlayerData.S.PropListDic[PropType.法师经验值]-=需要经验值;
                    break;
                case ZhiYeType.辅助:
                    PlayerData.S.PropListDic[PropType.辅助经验值]-=需要经验值;
                    break;
                case ZhiYeType.控制:
                    PlayerData.S.PropListDic[PropType.控制经验值]-=需要经验值;
                    break;
            }
            ObserverModuleManager.S.SendEvent("SendUIToast","提升境界成功");
            Show技能面板();
            刷新境界材料();
        });
        
        退出Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Sync法器列表(法器 旧法器, HeroType heroType)
    {
        foreach (var f in PlayerData.S.法器列表)
        {
            if (f.法器Type == 旧法器.法器Type && f.HeroType == heroType)
            {
                f.HeroType = HeroType.None;
                break;
            }
        }
    }
    public void Show英雄列表()
    {
        foreach (Transform item in 英雄列表content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in HeroConfig.HeroNameDic)
        {
            if (PlayerData.S.HeroDataDic[item.Key].Level > 0)
            {
               var 英雄列表item = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情列表Item"), 英雄列表content.transform)
                               .GetComponent<英雄详情列表Item>();
                英雄列表item.HeroType = item.Key;
                英雄列表item.SetItem(); 
            }
        }
    }
    
    public void 设置Button()
    {
        switch (显示类型)
        {
            case 英雄详情界面显示类型.境界:
                境界亮Button.gameObject.SetActive(true);
                境界Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                法器亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                详情Button.gameObject.SetActive(true);
                详情亮Button.gameObject.SetActive(false);
                灵兽Button.gameObject.SetActive(true);
                灵兽亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.功法:
                功法亮Button.gameObject.SetActive(true);
                功法Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                法器亮Button.gameObject.SetActive(false);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                详情Button.gameObject.SetActive(true);
                详情亮Button.gameObject.SetActive(false);
                灵兽Button.gameObject.SetActive(true);
                灵兽亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.法器:
                法器亮Button.gameObject.SetActive(true);
                法器Button.gameObject.SetActive(false);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                详情Button.gameObject.SetActive(true);
                详情亮Button.gameObject.SetActive(false);
                灵兽Button.gameObject.SetActive(true);
                灵兽亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.详情:
                法器亮Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                详情Button.gameObject.SetActive(false);
                详情亮Button.gameObject.SetActive(true);
                灵兽Button.gameObject.SetActive(true);
                灵兽亮Button.gameObject.SetActive(false);
                break;
            case 英雄详情界面显示类型.灵兽:
                法器亮Button.gameObject.SetActive(false);
                法器Button.gameObject.SetActive(true);
                境界Button.gameObject.SetActive(true);
                境界亮Button.gameObject.SetActive(false);
                功法Button.gameObject.SetActive(true);
                功法亮Button.gameObject.SetActive(false);
                详情Button.gameObject.SetActive(true);
                详情亮Button.gameObject.SetActive(false);
                灵兽Button.gameObject.SetActive(false);
                灵兽亮Button.gameObject.SetActive(true);
                break;
        }
    }
    public void 刷新界面()
    {
        设置Button();
        switch (显示类型)
        {
            case 英雄详情界面显示类型.境界:
                功法Panel.SetActive(false);
                法器Panel.SetActive(false);
                境界Panel.SetActive(true);
                详情Panel.SetActive(false);
                灵兽Panel.SetActive(false);
                Show技能面板();
                break;
            case 英雄详情界面显示类型.功法:
                功法Panel.SetActive(true);
                法器Panel.SetActive(false);
                境界Panel.SetActive(false);
                详情Panel.SetActive(false);
                灵兽Panel.SetActive(false);
                Show功法();
                break;
            case 英雄详情界面显示类型.法器:
                功法Panel.SetActive(false);
                法器Panel.SetActive(true);
                境界Panel.SetActive(false);
                详情Panel.SetActive(false);
                灵兽Panel.SetActive(false);
                Show法器();
                break;
            case 英雄详情界面显示类型.详情:
                功法Panel.SetActive(false);
                法器Panel.SetActive(false);
                境界Panel.SetActive(false);
                详情Panel.SetActive(true);
                灵兽Panel.SetActive(false);
                Show英雄详情();
                break;
            case 英雄详情界面显示类型.灵兽:
                功法Panel.SetActive(false);
                法器Panel.SetActive(false);
                境界Panel.SetActive(false);
                详情Panel.SetActive(false);
                灵兽Panel.SetActive(true);
                Show灵兽();
                break;
        }
    }

    private void OnEnable()
    {
        Show英雄列表();
        刷新界面();
    }
    

    public void Show技能面板()
    {
        刷新境界材料();
        foreach (Transform item in 技能Content.transform)
        {
            Destroy(item.gameObject);
        }
        for (int i = 1; i <= 5; i++)
        {
            var 技能树行item = Instantiate(Resources.Load("Prefabs/Window/技能树/技能树行item"), 技能Content.transform)
                .GetComponent<技能树行item>();
            技能树行item.行 = i;
            技能树行item.HeroType = 当前heroType;
            技能树行item.SetItem();
        }
    }
    
    
    public GameObject 灵兽Panel;
    public GameObject 灵兽信息content;

    public Image 灵兽icon;
    public Button 灵兽bg;
    public TextMeshProUGUI 灵兽Name;
    public TextMeshProUGUI 阶段;
    public TextMeshProUGUI 血脉;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI 最终伤害资质;
    public TextMeshProUGUI 暴击伤害资质;
    public TextMeshProUGUI 元素伤害资质;
    public TextMeshProUGUI 道龄;
    
    public TextMeshProUGUI 最终伤害增幅;
    public TextMeshProUGUI 暴击伤害增幅;
    public TextMeshProUGUI 元素伤害增幅;
    public GameObject 灵兽背包;
    public Button 性别Button;
    public Button 品级Button;
    public Button 血脉Button;
    public Button 阶段Button;
    public GameObject 性别下拉区域;
    public GameObject 品级下拉区域;
    public GameObject 血脉下拉区域;
    public GameObject 阶段下拉区域;
    public GameObject 性别下拉区域Content;
    public GameObject 品级下拉区域Content;
    public GameObject 血脉下拉区域Content;
    public GameObject 阶段下拉区域Content;
    public Button 灵兽筛选mask;

    private 性别 性别;
    private QualityType 品级筛选;
    private 血脉Type 血脉筛选;
    private 阶段Type 阶段筛选;
    private readonly List<灵兽> 灵兽筛选列表 = new List<灵兽>();
    private int 灵兽页数 = 1;
    public TextMeshProUGUI 灵兽num;
    private const int 每页灵兽数 = 18;
    public Button 灵兽右翻页;
    public Button 灵兽左翻页;
    public GameObject 无;

    public void Show灵兽()
    {
        Show灵兽信息();
        Show灵兽背包();
    }

    /// <summary>
    /// 上方信息区：显示当前英雄已装备的灵兽（一个英雄同时只能携带一只灵兽）
    /// </summary>
    public void Show灵兽信息()
    {
        
        灵兽  当前灵兽 = PlayerData.S.HeroDataDic[当前heroType].灵兽;

        bool 有灵兽 = 当前灵兽 != null && 当前灵兽.灵兽Type != 灵兽Type.None;
        if (!有灵兽)
        {
            灵兽信息content.gameObject.SetActive(false);
            无.gameObject.SetActive(true);
            return;
        }
        无.gameObject.SetActive(false);
        灵兽信息content.gameObject.SetActive(true);
        灵兽bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(当前灵兽.QualityType);
        灵兽icon.sprite = ResourcesConfig.Get灵兽Sprite(当前灵兽.灵兽Type);
        灵兽Name.text = 灵兽坊Config.灵兽名[当前灵兽.灵兽Type];
        灵兽Name.colorGradientPreset = ResourcesConfig.Get品质TMP(灵兽坊Config.灵兽品质[当前灵兽.灵兽Type]);
        阶段.text = 灵兽坊Config.阶段Name[当前灵兽.阶段Type];
        血脉.text = 灵兽坊Config.血脉Name[当前灵兽.血脉Type];
        desc.text = 灵兽坊Config.灵兽介绍[当前灵兽.灵兽Type];
        道龄.text = 当前灵兽.道龄 + "年";
        最终伤害资质.text = PlayerData.S.格式化数字(当前灵兽.最终伤害);
        暴击伤害资质.text = PlayerData.S.格式化数字(当前灵兽.暴击伤害);
        元素伤害资质.text = PlayerData.S.格式化数字(当前灵兽.元素伤害);
        最终伤害增幅.text = "+" + PlayerData.S.格式化数字(灵兽坊Config.Get灵兽最终伤害总增幅(当前灵兽)) + "%";
        暴击伤害增幅.text = "+" + PlayerData.S.格式化数字(灵兽坊Config.Get灵兽暴击伤害总增幅(当前灵兽)) + "%";
        元素伤害增幅.text = "+" + PlayerData.S.格式化数字(灵兽坊Config.Get灵兽元素伤害总增幅(当前灵兽)) + "%";
    }

    /// <summary>
    /// 卸下当前英雄携带的灵兽（点击信息区灵兽框触发）
    /// </summary>
    public void 卸下灵兽()
    {
        if (PlayerData.S.HeroDataDic[当前heroType].灵兽 == null) return;
        PlayerData.S.HeroDataDic[当前heroType].灵兽.HeroType = HeroType.None;
        PlayerData.S.HeroDataDic[当前heroType].灵兽 = null;
        Show灵兽信息();
        Show灵兽背包();
    }

    /// <summary>
    /// 灵兽背包：按性别/品级/血脉/阶段筛选，已装备（HeroType != None）的排最前，组内按品级从高到低
    /// </summary>
    public void Show灵兽背包()
    {
        foreach (Transform item in 灵兽背包.transform)
        {
            Destroy(item.gameObject);
        }
        Show灵兽筛选文字();

        灵兽筛选列表.Clear();
        var 灵兽列表 = PlayerData.S.灵兽列表;
        for (int i = 0; i < 灵兽列表.Count; i++)
        {
            var item = 灵兽列表[i];
            if (性别 != global::性别.None && item.性别 != 性别) continue;
            if (品级筛选 != QualityType.None && item.QualityType != 品级筛选) continue;
            if (血脉筛选 != 血脉Type.None && item.血脉Type != 血脉筛选) continue;
            if (阶段筛选 != 阶段Type.None && item.阶段Type != 阶段筛选) continue;
            灵兽筛选列表.Add(item);
        }

        灵兽筛选列表.Sort((a, b) =>
        {
            bool a装备 = a.HeroType != HeroType.None;
            bool b装备 = b.HeroType != HeroType.None;
            if (a装备 != b装备)
            {
                return a装备 ? -1 : 1;
            }

            return b.QualityType.CompareTo(a.QualityType);
        });

        int 总页数 = Mathf.Max(1, Mathf.CeilToInt((float)灵兽筛选列表.Count / 每页灵兽数));
        灵兽页数 = Mathf.Clamp(灵兽页数, 1, 总页数);

        int 开始索引 = (灵兽页数 - 1) * 每页灵兽数;
        int 本页数量 = Mathf.Min(每页灵兽数, 灵兽筛选列表.Count - 开始索引);

        for (int i = 0; i < 本页数量; i++)
        {
            var 灵兽item = Instantiate(Resources.Load("Prefabs/Window/技能树/英雄详情灵兽item"), 灵兽背包.transform)
                .GetComponent<英雄详情灵兽item>();
            灵兽item.灵兽 = 灵兽筛选列表[开始索引 + i];
            灵兽item.HeroType = 当前heroType;
            灵兽item.SetItem();
        }

        灵兽num.text = 灵兽页数.ToString();
    }

    // 筛选按钮上的文字：类型名 + 当前筛选值（无筛选显示“所有”）
    private void Show灵兽筛选文字()
    {
        var 性别Text = 性别Button.GetComponentInChildren<TextMeshProUGUI>();
        if (性别Text != null)
        {
            性别Text.text = "性别：" + (性别 == global::性别.None ? "所有" : (性别 == global::性别.公 ? "公" : "母"));
        }

        var 品级Text = 品级Button.GetComponentInChildren<TextMeshProUGUI>();
        if (品级Text != null)
        {
            品级Text.text = "品级：" + (品级筛选 == QualityType.None ? "所有" : PropConfig.QualityNameDic[品级筛选]);
        }

        var 血脉Text = 血脉Button.GetComponentInChildren<TextMeshProUGUI>();
        if (血脉Text != null)
        {
            血脉Text.text = "血脉：" + (血脉筛选 == 血脉Type.None ? "所有" : 灵兽坊Config.血脉Name[血脉筛选]);
        }

        var 阶段Text = 阶段Button.GetComponentInChildren<TextMeshProUGUI>();
        if (阶段Text != null)
        {
            阶段Text.text = "阶段：" + (阶段筛选 == 阶段Type.None ? "所有" : 灵兽坊Config.阶段Name[阶段筛选]);
        }
    }

    public void Init灵兽筛选()
    {
        foreach (Transform item in 性别下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 品级下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 血脉下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (Transform item in 阶段下拉区域Content.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 0; i < Enum.GetValues(typeof(global::性别)).Length; i++)
        {
            var 性别筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽性别筛选Item"), 性别下拉区域Content.transform)
                .GetComponent<灵兽性别筛选Item>();
            性别筛选item.性别 = (global::性别)i;
            性别筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(QualityType)).Length; i++)
        {
            var 品级筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽品质筛选Item"), 品级下拉区域Content.transform)
                .GetComponent<灵兽品级筛选Item>();
            品级筛选item.QualityType = (QualityType)i;
            品级筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(血脉Type)).Length; i++)
        {
            var 血脉筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽血脉筛选Item"), 血脉下拉区域Content.transform)
                .GetComponent<灵兽血脉筛选Item>();
            血脉筛选item.血脉Type = (血脉Type)i;
            血脉筛选item.SetItem();
        }

        for (int i = 0; i < Enum.GetValues(typeof(阶段Type)).Length; i++)
        {
            var 阶段筛选item = Instantiate(Resources.Load("Prefabs/Window/灵兽坊/灵兽阶段筛选Item"), 阶段下拉区域Content.transform)
                .GetComponent<灵兽阶段筛选Item>();
            阶段筛选item.阶段Type = (阶段Type)i;
            阶段筛选item.SetItem();
        }
    }

    // 与灵兽坊共用筛选事件，窗口未激活时不响应，避免两个窗口的筛选状态互相污染
    public void 灵兽性别筛选(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;
        性别 = (global::性别)obj[0];
        灵兽页数 = 1;
        性别下拉区域.gameObject.SetActive(false);
        灵兽筛选mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void 灵兽品级筛选(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;
        品级筛选 = (QualityType)obj[0];
        灵兽页数 = 1;
        品级下拉区域.gameObject.SetActive(false);
        灵兽筛选mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void 灵兽血脉筛选(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;
        血脉筛选 = (血脉Type)obj[0];
        灵兽页数 = 1;
        血脉下拉区域.gameObject.SetActive(false);
        灵兽筛选mask.gameObject.SetActive(false);
        Show灵兽背包();
    }

    public void 灵兽阶段筛选(object[] obj)
    {
        if (!gameObject.activeInHierarchy) return;
        阶段筛选 = (阶段Type)obj[0];
        灵兽页数 = 1;
        阶段下拉区域.gameObject.SetActive(false);
        灵兽筛选mask.gameObject.SetActive(false);
        Show灵兽背包();
    }
}
