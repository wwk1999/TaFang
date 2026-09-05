using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Config;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{
    public GameObject 神通配置新手mask;

    public Canvas 退出神通Canvas;
    public Transform 退出神通小手trans;
    public Transform 添加神通trans;
    public Transform 添加神通小手trans;
    public Canvas 添加神通Canvas;
    public Transform 神通配置小手trans;
    public Canvas 神通配置Canvas;
    public GameObject 主线关卡新手mask;
    public 神通配置弹窗 神通配置弹窗;
    public Button 主线关卡exitbuttton;
    public Transform 挑战trans;
    public Transform 挑战小手trans;
    public Canvas 挑战Canvas;
    public Transform 关卡trans;
    public Transform 关卡小手trans;
    public Canvas 花果山Canvas;
    public Canvas 父canvas;
    public Transform 英雄Trans;
    public Transform 英雄小手Trans;
    public Canvas 英雄Canvas;
    public Transform 初始Trans;
    public Transform 修为Trans;
    public Transform 修为小手Trans;
    public Canvas 修为Canvas;
    public Animator 小手Animator;
    public GameObject 对话框;
    public GameObject 引导mask;
    public TextMeshProUGUI 对话框Text;
    public Button 引导Button;
    public Image mask;
    public GameObject BuffContent;
    public 丹药选择弹窗 丹药选择弹窗;
    public Button 远古遗迹按钮;
    public 远古遗迹窗口 远古遗迹窗口;
    public Button 洞天秘境按钮;
    public 洞天秘境窗口 洞天秘境窗口;

    public Button 设置按钮;
    public Canvas canvas;
    public 紫霄宫传道窗口 紫霄宫传道窗口;
    public Button 紫霄宫传道Button;
    public TextMeshProUGUI 道龄剩余时间;
    public TextMeshProUGUI 道龄所需时间;

    public TextMeshProUGUI 道龄;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI JingJie;
    public Slider JingJieSlider;
    public TextMeshProUGUI CurrentExp;
    public TextMeshProUGUI MaxExp;
    public TextMeshProUGUI LingQi;
    public TextMeshProUGUI GongDe;
    public Button 招募Btn;
    public Button 招募卷Debug;
    public Button 英雄按钮;
    public Button 储物袋按钮;
    public Button 经验值Debug;
    public Button 道宝Button;
    public Button 城墙Button;
    public Button 炼器Button;
    public Button 坊市Button;
    public Button 炼丹Button;
    public GameObject 坊市窗口;

    public 主线关卡窗口 主线关卡窗口;
    public 凌霄宝殿窗口 凌霄宝殿窗口;
    public 三十三重天窗口 三十三重天窗口;
    public 混沌虚空窗口 混沌虚空窗口;
    public 通天塔窗口 通天塔窗口;
    public Button 通天塔;
    public 世界树窗口 世界树窗口;
    public Button 世界树;
    
    public 血海窗口 血海窗口;
    public Button 血海;
    
    public 不周山窗口 不周山窗口;
    public Button 不周山;

    public Button 主线关卡Debug;
    public Button 城墙Debug;
    public Button 灵宝Debug;

    public GameObject 通天塔收获弹窗;
    public GameObject 世界树收获弹窗;
    public GameObject 血海收获弹窗;
    public GameObject 不周山收获弹窗;

    private int 引导count = 0;
    public void 首次进入主页面引导()
    {
        对话框.transform.localPosition = 初始Trans.localPosition;
        引导mask.gameObject.SetActive(true);
        对话框.gameObject.SetActive(true);
        对话框Text.text = "欢迎道友进入洪荒,共修大道。";
        引导Button.gameObject.SetActive(true);
    }
    public void Show主页()
    {
        var 通天塔list = PlayerData.S.获取通天塔所有道具();
        通天塔收获弹窗.gameObject.SetActive(通天塔list.Count>0);
        var 不周山list = PlayerData.S.获取不周山所有道具();
        不周山收获弹窗.gameObject.SetActive(不周山list.Count>0);
        var 血海list = PlayerData.S.获取血海所有道具();
        血海收获弹窗.gameObject.SetActive(血海list.Count>0);
        var 世界树list = PlayerData.S.获取世界树所有道具();
        世界树收获弹窗.gameObject.SetActive(世界树list.Count>0);
        道龄剩余时间.text = "道年剩余时间:" + (int)(属性config.每年秒数 - PlayerData.S.道龄S) + "S";
        道龄所需时间.text = "(当前每道年时间：" + 属性config.每年秒数 + "S)";
        道龄.text = PlayerData.S.道龄年 + "年";
        Name.text = PlayerData.S.Name;
        JingJie.text=JingJieConfig.JingJieNameDic[PlayerData.S.当前轮回境界];
        JingJieSlider.maxValue=JingJieConfig.升级需要年数Dic[PlayerData.S.当前轮回境界]*JingJieConfig.每年基础修为;
        JingJieSlider.value = PlayerData.S.Exp;
        CurrentExp.text=((int)PlayerData.S.Exp).ToString();
        MaxExp.text=(JingJieConfig.升级需要年数Dic[PlayerData.S.当前轮回境界]*JingJieConfig.每年基础修为).ToString();
        LingQi.text=PlayerData.S.PropListDic[PropType.灵魂].ToString();
        GongDe.text=PlayerData.S.PropListDic[PropType.功德].ToString();
    }
    public void Init()
    {
        Show主页();
        InitWindow();
    }

    public void InitWindow()
    {
        WindowController.S.招募Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/招募界面"));
        WindowController.S.招募Window.gameObject.SetActive(false);
        WindowController.S.英雄Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/HeroWindow"));
        WindowController.S.英雄Window.gameObject.SetActive(false);
        WindowController.S.储物袋Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/储物袋界面"));
        WindowController.S.储物袋Window.gameObject.SetActive(false);
        WindowController.S.道宝Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/道宝界面"));
        WindowController.S.道宝Window.gameObject.SetActive(false);
        WindowController.S.城墙Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/城墙界面"));
        WindowController.S.城墙Window.gameObject.SetActive(false);
        WindowController.S.炼器Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/炼器/炼器界面"));
        WindowController.S.炼器Window.gameObject.SetActive(false);
        WindowController.S.炼丹Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/炼丹界面/炼丹界面"));
        WindowController.S.炼丹Window.gameObject.SetActive(false);
    }

    public void SetBuff()
    {
        foreach (Transform item in BuffContent.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 8; i >= 1; i--)
        {
            if (PlayerData.S.Get辅助丹药Buff(丹药Type.修炼速度, (QualityType)i) > 0)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/BuffItem"), BuffContent.transform)
                    .GetComponent<BuffItem>();
                item.丹药type = 丹药Type.修炼速度;
                item.QualityType = (QualityType)i;
                item.SetItem();
            }
        }
        
        for (int i = 8; i >= 1; i--)
        {
            if (PlayerData.S.Get辅助丹药Buff(丹药Type.掉宝率, (QualityType)i) > 0)
            {
                var item = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/BuffItem"), BuffContent.transform)
                    .GetComponent<BuffItem>();
                item.丹药type = 丹药Type.掉宝率;
                item.QualityType = (QualityType)i;
                item.SetItem();
            }
        }
    }

    public void 显示主线关卡弹窗(object[] obj)
    {
        主线关卡Type 主线关卡Type = (主线关卡Type)obj[0];
        主线关卡窗口.主线关卡Type = 主线关卡Type;
        主线关卡窗口.gameObject.SetActive(true);
        if (PlayerData.S.是否首次进入关卡)
        {
            主线关卡新手mask.gameObject.SetActive(true);
            引导mask.SetActive(false);
            对话框Text.text = "在这里可以看到关卡信息并进行丹药和神通的配置,让我们先配置一下英雄神通吧";
            对话框.transform.localPosition=挑战trans.localPosition;
            小手Animator.transform.localPosition=神通配置小手trans.localPosition;
            神通配置Canvas.GetComponent<GraphicRaycaster>().enabled = true;
            父canvas.GetComponent<GraphicRaycaster>().enabled = false;
            花果山Canvas.overrideSorting = false;
            花果山Canvas.GetComponent<GraphicRaycaster>().enabled = false;
            神通配置Canvas.overrideSorting = true;
            PlayerData.S.是否首次进入关卡 = false;
        }
    }
    public void 新手引导神通配置(object[] obj)
    {
        主线关卡新手mask.gameObject.SetActive(false);
        对话框Text.text = "每个英雄释放神通都需要较长的冷却和神通能量,在这里可以配置神通的释放顺序,点击添加按钮配置英雄神通吧。";
        对话框.transform.localPosition=添加神通trans.localPosition;
        小手Animator.transform.localPosition=添加神通小手trans.localPosition;
        添加神通Canvas.GetComponent<GraphicRaycaster>().enabled = true;
        父canvas.GetComponent<GraphicRaycaster>().enabled = false;
        添加神通Canvas.overrideSorting = true;
        神通配置新手mask.gameObject.SetActive(true);
    }

    public void 退出神通配置(object[] obj)
    {
        对话框.transform.localPosition=挑战trans.localPosition;
        主线关卡新手mask.gameObject.SetActive(true);
        神通配置新手mask.gameObject.SetActive(false);
        对话框Text.text = "点击挑战按钮开始战斗吧！";
        小手Animator.transform.localPosition=挑战小手trans.localPosition;
        神通配置Canvas.overrideSorting = false;
        挑战Canvas.overrideSorting = true;
    }
    public void 新手引导添加神通(object[] obj)
    {
        对话框Text.text = "现在我们退出去进行第一场战斗吧!";
        小手Animator.transform.localPosition=退出神通小手trans.localPosition;
        退出神通Canvas.GetComponent<GraphicRaycaster>().enabled = true;
        添加神通Canvas.overrideSorting = false;
        退出神通Canvas.overrideSorting = true;
        神通配置新手mask.gameObject.SetActive(true);
    }
    
    public void 显示凌霄宝殿弹窗(object[] obj)
    {
        凌霄宝殿窗口.gameObject.SetActive(true);
    }

    public void 显示混沌虚空弹窗(object[] obj)
    {
        混沌虚空窗口.gameObject.SetActive(true);
    }

   
    private void OnDestroy()
    {        
        ObserverModuleManager.S.UnRegisterEvent("退出神通配置",退出神通配置);
        ObserverModuleManager.S.UnRegisterEvent("新手引导添加神通",新手引导添加神通);
        ObserverModuleManager.S.UnRegisterEvent("新手引导神通配置",新手引导神通配置);
        ObserverModuleManager.S.UnRegisterEvent("显示神通配置弹窗",显示神通配置弹窗);
        ObserverModuleManager.S.UnRegisterEvent("关卡新手引导",关卡新手引导);
        ObserverModuleManager.S.UnRegisterEvent("刷新主页Buff",刷新主页Buff);
        ObserverModuleManager.S.UnRegisterEvent("显示丹药选择弹窗",显示丹药选择弹窗);
        ObserverModuleManager.S.UnRegisterEvent("刷新主页面",刷新主页面);
        ObserverModuleManager.S.UnRegisterEvent("显示混沌虚空弹窗",显示混沌虚空弹窗 );
        ObserverModuleManager.S.UnRegisterEvent("显示三十三重天弹窗",显示三十三重天弹窗 );
        ObserverModuleManager.S.UnRegisterEvent("显示凌霄宝殿弹窗",显示凌霄宝殿弹窗 );
        ObserverModuleManager.S.UnRegisterEvent("显示主线关卡弹窗",显示主线关卡弹窗 );
    }
    
    public void 显示三十三重天弹窗(object[] obj)
    {
        三十三重天窗口.gameObject.SetActive(true);
    }


    public void 刷新主页面(object[] obj)
    {
        Show主页();
    }

    public void 显示丹药选择弹窗(object[] obj)
    {
        丹药选择弹窗.index = (int)obj[0];
        丹药选择弹窗.gameObject.SetActive(true);
    }

    public void 刷新主页Buff(object[] obj)
    {
        SetBuff();
    }

    public void 关卡新手引导(object[] obj)
    {
        对话框.gameObject.SetActive(true);
        引导mask.gameObject.SetActive(true);
        小手Animator.gameObject.SetActive(true);
        对话框Text.text = "让我们进入第一个主线关卡花果山进行战斗吧。";
        对话框.transform.localPosition=关卡trans.localPosition;
        小手Animator.transform.localPosition=关卡小手trans.localPosition;
        父canvas.GetComponent<GraphicRaycaster>().enabled = false;
        花果山Canvas.GetComponent<GraphicRaycaster>().enabled = true;
        花果山Canvas.overrideSorting = true;
    }

    public void 显示神通配置弹窗(object[] obj)
    {
        //打开弹窗时按引导标志同步mask状态，避免上次引导残留的activeSelf=true导致非引导时mask跟着显示
        神通配置新手mask.gameObject.SetActive(PlayerData.S.是否首次配置神通);
        神通配置弹窗.gameObject.SetActive(true);
    }
    private void Start()
    {
        神通配置新手mask.gameObject.SetActive(false);

        ObserverModuleManager.S.RegisterEvent("退出神通配置",退出神通配置);
        ObserverModuleManager.S.RegisterEvent("新手引导添加神通",新手引导添加神通);
        ObserverModuleManager.S.RegisterEvent("新手引导神通配置",新手引导神通配置);
        ObserverModuleManager.S.RegisterEvent("显示神通配置弹窗",显示神通配置弹窗);
        ObserverModuleManager.S.RegisterEvent("关卡新手引导",关卡新手引导);
        ObserverModuleManager.S.RegisterEvent("刷新主页Buff",刷新主页Buff);
        ObserverModuleManager.S.RegisterEvent("显示丹药选择弹窗",显示丹药选择弹窗);
        ObserverModuleManager.S.RegisterEvent("刷新主页面",刷新主页面);
        ObserverModuleManager.S.RegisterEvent("显示混沌虚空弹窗",显示混沌虚空弹窗 );
        ObserverModuleManager.S.RegisterEvent("显示三十三重天弹窗",显示三十三重天弹窗 );
        ObserverModuleManager.S.RegisterEvent("显示凌霄宝殿弹窗",显示凌霄宝殿弹窗 );
        ObserverModuleManager.S.RegisterEvent("显示主线关卡弹窗",显示主线关卡弹窗 );
        ObserverModuleManager.S.SendEvent("播放BGM",true);
        ObserverModuleManager.S.SendEvent("刷新主页通天塔收获弹窗");
        ObserverModuleManager.S.SendEvent("刷新主页不周山收获弹窗");
        ObserverModuleManager.S.SendEvent("刷新主页血海收获弹窗");
        ObserverModuleManager.S.SendEvent("刷新主页世界树收获弹窗");
        SetBuff();
        if (PlayerData.S.是否首次进入主页面)
        {
            首次进入主页面引导();
        }
        引导Button.onClick.AddListener(() =>
        {
            if (引导count == 0)
            {
                引导count++;
                修为Canvas.overrideSorting = true;
                对话框.transform.localPosition = 修为Trans.localPosition;
                对话框Text.text = "这里可以看到当前的境界和修为,境界是一切的基础,修为随着时间缓慢增长,当修为满时就可以在储物袋界面进行突破啦。";
                小手Animator.gameObject.SetActive(true);
                小手Animator.gameObject.transform.localPosition=修为小手Trans.localPosition;
            }
            else if (引导count == 1)
            {
                引导count++;
                修为Canvas.overrideSorting = false;
                对话框.transform.localPosition = 英雄Trans.localPosition;
                对话框Text.text = "接下来我们去英雄界面上场英雄吧";
                小手Animator.gameObject.transform.localPosition=英雄小手Trans.localPosition;
                英雄Canvas.overrideSorting = true;
                英雄Canvas.GetComponent<GraphicRaycaster>().enabled = true;
                父canvas.GetComponent<GraphicRaycaster>().enabled = false;
            }
        });
        mask.gameObject.SetActive(true);
        mask.DOFade(0, 1.3f);
        灵宝Debug.onClick.AddListener(() =>
        {
            for (int i = (int)JingJieType.练气; i <= (int)JingJieType.混元圣人; i++)
            {
                for (int j = (int)QualityType.黄品; j <= (int)QualityType.荒品; j++)
                {
                    PlayerData.S.Set灵物数量((JingJieType)i, (QualityType)j,PlayerData.S.Get灵物数量((JingJieType)i, (QualityType)j)+1);
                }
            }
        });
        坊市Button.onClick.AddListener(() =>
        {
            坊市窗口.gameObject.SetActive(true);
        });
        远古遗迹按钮.onClick.AddListener(() =>
        {
            远古遗迹窗口.gameObject.SetActive(true);
        });
        洞天秘境按钮.onClick.AddListener(() =>
        {
            洞天秘境窗口.gameObject.SetActive(true);
        });
        设置按钮.onClick.AddListener(() =>
        {
            GameObject obj=Instantiate(Resources.Load("Prefabs/Window/设置界面"),canvas.transform)as GameObject;
            obj.transform.SetAsLastSibling();
        });
        紫霄宫传道Button.onClick.AddListener(() =>
        {
            紫霄宫传道窗口.gameObject.SetActive(true);
        });
        通天塔.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.通天塔;
            通天塔窗口.gameObject.SetActive(true);
        });
        世界树.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < 世界树Config.世界树关卡Dic[1].jingJieType)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","金丹境界解锁");
                return;
            }
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.血海;
            世界树窗口.gameObject.SetActive(true);
        });
        血海.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < 血海Config.血海关卡Dic[1].jingJieType)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","金丹境界解锁");
                return;
            }
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.世界树;
            血海窗口.gameObject.SetActive(true);
        });
        
        不周山.onClick.AddListener(() =>
        {
            if (PlayerData.S.历史最高境界 < 不周山Config.不周山关卡Dic[1].jingJieType)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","化神境界解锁");
                return;
            }
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.不周山;
            不周山窗口.gameObject.SetActive(true);
        });
        城墙Debug.onClick.AddListener(() =>
        {
            PlayerData.S.城墙等级++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.不动明王阵]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.周天星斗大阵]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.不朽魂晶]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.厚土珠]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.不周山柱]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.永恒之火]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.大道本源]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.不灭玄石]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.九曲黄河阵]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.混沌磐石]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.鸿蒙灵根]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.轮回印记]++;
            PlayerData.S.城墙道具等级Dic[城墙道具Type.不朽魂晶]++;


        });
        道宝Button.onClick.AddListener(() =>
        {
            WindowController.S.道宝Window.gameObject.SetActive(true);
        });
        城墙Button.onClick.AddListener(() =>
        {
            WindowController.S.城墙Window.gameObject.SetActive(true);
        });
        炼器Button.onClick.AddListener(() =>
        {
            WindowController.S.炼器Window.gameObject.SetActive(true);
        });
        炼丹Button.onClick.AddListener(() =>
        {
            WindowController.S.炼丹Window.gameObject.SetActive(true);
        });
        主线关卡Debug.onClick.AddListener(() =>
        {
            PlayerData.S.最大主线关卡++;
            PlayerData.S.混沌虚空最大层数++;
        });
        经验值Debug.onClick.AddListener(() =>
        {
            PlayerData.S.PropListDic[PropType.功德] += 999999;
            PlayerData.S.历史最高境界++;
            if (PlayerData.S.历史最高境界 > JingJieType.混元圣人)
            {
                PlayerData.S.历史最高境界 = JingJieType.混元圣人;
            }
            PlayerData.S.当前轮回境界++;
        });
        储物袋按钮.onClick.AddListener(() =>
        {
            WindowController.S.储物袋Window.gameObject.SetActive(true);
        });
        英雄按钮.onClick.AddListener(() =>
        {
            if (PlayerData.S.是否首次进入主页面)
            {
                对话框.gameObject.SetActive(false);
                小手Animator.gameObject.SetActive(false);
                英雄Canvas.overrideSorting = false;
                父canvas.GetComponent<GraphicRaycaster>().enabled = true;
                PlayerData.S.是否首次进入主页面 = false;
            }
            WindowController.S.英雄Window.gameObject.SetActive(true);
        });
        招募卷Debug.onClick.AddListener(() =>
        {
            PlayerData.S.PropListDic[PropType.高级招募卷] += 100;
            PlayerData.S.PropListDic[PropType.招募卷] += 100;
            PlayerData.S.PropListDic[PropType.灵魂] += 10000000;
            PlayerData.S.PropListDic[PropType.头盔锻造石] += 100;
            PlayerData.S.PropListDic[PropType.护手锻造石] += 100;
            PlayerData.S.PropListDic[PropType.项链锻造石] += 100;
            PlayerData.S.PropListDic[PropType.戒指锻造石] += 100;
            PlayerData.S.PropListDic[PropType.衣服锻造石] += 100;
            PlayerData.S.PropListDic[PropType.鞋子锻造石] += 100;
            PlayerData.S.PropListDic[PropType.洗练石] += 100;
            PlayerData.S.PropListDic[PropType.法师经验值] += 10000;
            PlayerData.S.PropListDic[PropType.战士经验值] += 10000;
            PlayerData.S.PropListDic[PropType.辅助经验值] += 10000;
            PlayerData.S.PropListDic[PropType.控制经验值] += 10000;
            PlayerData.S.PropListDic[PropType.射手经验值] += 10000;

            for (int i = 0; i < 100; i++)
            {
                法器 法器 = 法器Config.单次法器掉落(JingJieType.圣人);
                PlayerData.S.法器列表.Add(法器);
                仙石 仙石 = 仙石Config.单次仙石掉落(JingJieType.圣人);
                PlayerData.S.仙石列表.Add(仙石);
            }
            
            PlayerData.S.Set道纹数量(道纹Type.通天每次暴击增加伤害, QualityType.天品,999);
            PlayerData.S.Set道纹数量(道纹Type.通天每次暴击增加伤害, QualityType.宇品,999);
            PlayerData.S.Set道纹数量(道纹Type.通天每次暴击增加伤害, QualityType.宙品,999);
            PlayerData.S.Set道纹数量(道纹Type.通天每次暴击增加伤害, QualityType.洪品,999);
            PlayerData.S.Set道纹数量(道纹Type.通天每次暴击增加伤害, QualityType.荒品,999);

            PlayerData.S.Set道纹数量(道纹Type.老子旋风体积越大伤害越高, QualityType.天品,999);
            PlayerData.S.Set道纹数量(道纹Type.老子旋风体积越大伤害越高, QualityType.宇品,999);
            PlayerData.S.Set道纹数量(道纹Type.老子旋风体积越大伤害越高, QualityType.宙品,999);
            PlayerData.S.Set道纹数量(道纹Type.老子旋风体积越大伤害越高, QualityType.洪品,999);
            PlayerData.S.Set道纹数量(道纹Type.老子旋风体积越大伤害越高, QualityType.荒品,999);
        });
        招募Btn.onClick.AddListener(() =>
        {
            WindowController.S.招募Window.gameObject.SetActive(true);
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WindowController.S.储物袋Window.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            WindowController.S.道宝Window.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            WindowController.S.英雄Window.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            WindowController.S.招募Window.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            WindowController.S.城墙Window.gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        Init();
    }
}
