using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{
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

    public GameObject 通天塔收获弹窗;
    public GameObject 世界树收获弹窗;
    public GameObject 血海收获弹窗;
    public GameObject 不周山收获弹窗;

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
        JingJie.text=JingJieConfig.JingJieNameDic[PlayerData.S.JingJieType];
        JingJieSlider.maxValue=JingJieConfig.升级需要年数Dic[PlayerData.S.JingJieType]*JingJieConfig.每年基础修为;
        JingJieSlider.value = PlayerData.S.Exp;
        CurrentExp.text=((int)PlayerData.S.Exp).ToString();
        MaxExp.text=(JingJieConfig.升级需要年数Dic[PlayerData.S.JingJieType]*JingJieConfig.每年基础修为).ToString();
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
    }

    public void 显示主线关卡弹窗(object[] obj)
    {
        主线关卡Type 主线关卡Type = (主线关卡Type)obj[0];
        主线关卡窗口.主线关卡Type = 主线关卡Type;
        主线关卡窗口.gameObject.SetActive(true);
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
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新主页面",刷新主页面);
        ObserverModuleManager.S.RegisterEvent("显示混沌虚空弹窗",显示混沌虚空弹窗 );
        ObserverModuleManager.S.RegisterEvent("显示三十三重天弹窗",显示三十三重天弹窗 );
        ObserverModuleManager.S.RegisterEvent("显示凌霄宝殿弹窗",显示凌霄宝殿弹窗 );
        ObserverModuleManager.S.RegisterEvent("显示主线关卡弹窗",显示主线关卡弹窗 );
        ObserverModuleManager.S.SendEvent("播放BGM",true);

        通天塔.onClick.AddListener(() =>
        {
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.通天塔;
            通天塔窗口.gameObject.SetActive(true);
        });
        世界树.onClick.AddListener(() =>
        {
            if (PlayerData.S.JingJieType < 世界树Config.世界树关卡Dic[1].jingJieType)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","金丹境界解锁");
                return;
            }
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.世界树;
            世界树窗口.gameObject.SetActive(true);
        });
        血海.onClick.AddListener(() =>
        {
            if (PlayerData.S.JingJieType < 血海Config.血海关卡Dic[1].jingJieType)
            {
                ObserverModuleManager.S.SendEvent("播放音效",音效Type.错误);
                ObserverModuleManager.S.SendEvent("SendUIToast","金丹境界解锁");
                return;
            }
            HeroWindowController.S.当前显示关卡类型 = 当前显示关卡类型.血海;
            血海窗口.gameObject.SetActive(true);
        });
        
        不周山.onClick.AddListener(() =>
        {
            if (PlayerData.S.JingJieType < 不周山Config.不周山关卡Dic[1].jingJieType)
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
        主线关卡Debug.onClick.AddListener(() =>
        {
            PlayerData.S.最大主线关卡++;
            PlayerData.S.混沌虚空最大层数++;
        });
        经验值Debug.onClick.AddListener(() =>
        {
            PlayerData.S.PropListDic[PropType.功德] += 999999;
            PlayerData.S.JingJieType++;
        });
        储物袋按钮.onClick.AddListener(() =>
        {
            WindowController.S.储物袋Window.gameObject.SetActive(true);
        });
        英雄按钮.onClick.AddListener(() =>
        {
            WindowController.S.英雄Window.gameObject.SetActive(true);
        });
        招募卷Debug.onClick.AddListener(() =>
        {
            PlayerData.S.PropListDic[PropType.高级招募卷] += 100;
            PlayerData.S.PropListDic[PropType.招募卷] += 100;
            PlayerData.S.PropListDic[PropType.灵魂] += 10000;
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

    private void OnEnable()
    {
        Init();
    }
}
