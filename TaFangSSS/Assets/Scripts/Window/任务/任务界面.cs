using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 任务界面 : MonoBehaviour
{
    public GameObject 任务列表;

    public GameObject 任务信息;
    public TextMeshProUGUI name;
    public TextMeshProUGUI 目标;
    public TextMeshProUGUI 详情;
    public TextMeshProUGUI 灵气;
    public Button 完成任务按钮;

    public Button exitButton;
    public void Show任务信息()
    {
        if (HeroWindowController.S.当前显示任务Type == 任务Type.None)
        {
            任务信息.SetActive(false);
            return;
        }
        任务信息.SetActive(true);
        完成任务按钮.interactable = PlayerData.S.任务完成字典[HeroWindowController.S.当前显示任务Type];
        任务类型 任务类型 = 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务类型;
        string 类型 = 任务类型 == 任务类型.主线任务 ? "[主线]" : "[支线]";
        name.text = 类型 + 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务名;
        目标.text = 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务目标;
        详情.text = 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].任务详情;
        灵气.text = "灵气X" + 任务Config.任务配置[HeroWindowController.S.当前显示任务Type].灵气;
    }

    public void 刷新列表()
    {
        foreach (Transform item in 任务列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.当前任务列表)
        {
            if (任务Config.任务配置[item].任务类型 == 任务类型.主线任务)
            {
                var 任务item = Instantiate(Resources.Load("Prefabs/Window/任务/任务界面item"), 任务列表.transform)
                    .GetComponent<任务界面item>();
                任务item.任务Type = item;
                任务item.SetItem();
            }
        }
        
        foreach (var item in PlayerData.S.当前任务列表)
        {
            if (任务Config.任务配置[item].任务类型 == 任务类型.支线任务)
            {
                var 任务item = Instantiate(Resources.Load("Prefabs/Window/任务/任务界面item"), 任务列表.transform)
                    .GetComponent<任务界面item>();
                任务item.任务Type = item;
                任务item.SetItem();
            }
        }
    }

    private void OnEnable()
    {
        刷新列表();
        Show任务信息();
    }

    public void 任务界面item点击(object[] obj)
    {
        Show任务信息();
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("任务界面item点击",任务界面item点击);
        完成任务按钮.onClick.AddListener(() =>
        {
            添加任务();
            ObserverModuleManager.S.SendEvent("SendUIToast","任务完成,获得灵气X"+任务Config.任务配置[HeroWindowController.S.当前显示任务Type].灵气);
            PlayerData.S.当前任务列表.Remove(HeroWindowController.S.当前显示任务Type);
            HeroWindowController.S.当前显示任务Type = 任务Type.None;
            ObserverModuleManager.S.SendEvent("刷新任务栏");
            Show任务信息();
            刷新列表();
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void 添加任务()
    {
        switch (HeroWindowController.S.当前显示任务Type)
        {
            // 主线关卡
            case 任务Type.花果山:
                任务Config.添加任务(任务Type.筑基);
                任务Config.添加任务(任务Type.水帘洞);
                break;
            case 任务Type.水帘洞:
                任务Config.添加任务(任务Type.获取一本功法);
                任务Config.添加任务(任务Type.蓬莱仙岛);
                任务Config.添加任务(任务Type.打造一件法器);
                break;
            case 任务Type.蓬莱仙岛:
                任务Config.添加任务(任务Type.五行山);
                break;
            case 任务Type.五行山:
                任务Config.添加任务(任务Type.通天塔寻宝);
                任务Config.添加任务(任务Type.傲来国);
                break;
            case 任务Type.傲来国:
                任务Config.添加任务(任务Type.高老庄);
                break;
            case 任务Type.高老庄:
                任务Config.添加任务(任务Type.九幽血海寻宝);

                任务Config.添加任务(任务Type.女儿国);
                break;
            case 任务Type.女儿国:
                任务Config.添加任务(任务Type.小雷音寺);
                break;
            case 任务Type.小雷音寺:
                任务Config.添加任务(任务Type.平顶山);
                break;
            case 任务Type.平顶山:
                任务Config.添加任务(任务Type.火焰山);
                break;
            case 任务Type.火焰山:
                任务Config.添加任务(任务Type.世界树寻宝);
                任务Config.添加任务(任务Type.芭蕉洞);
                break;
            case 任务Type.芭蕉洞:
                任务Config.添加任务(任务Type.流沙河);
                break;
            case 任务Type.流沙河:
                任务Config.添加任务(任务Type.远古遗迹掉落神物);
                任务Config.添加任务(任务Type.狮驼岭);
                break;
            case 任务Type.狮驼岭:
                任务Config.添加任务(任务Type.通关一次符文之地);
                任务Config.添加任务(任务Type.东海龙宫);
                break;
            case 任务Type.东海龙宫:
                任务Config.添加任务(任务Type.冥府);
                break;
            case 任务Type.冥府:
                任务Config.添加任务(任务Type.南天门);
                break;
            case 任务Type.南天门:
                任务Config.添加任务(任务Type.瑶池仙境);
                break;
            case 任务Type.瑶池仙境:
                任务Config.添加任务(任务Type.斩妖台);
                break;
            case 任务Type.斩妖台:
                任务Config.添加任务(任务Type.御马监);
                break;
            case 任务Type.御马监:
                任务Config.添加任务(任务Type.蟠桃园);
                break;
            case 任务Type.蟠桃园:
                任务Config.添加任务(任务Type.兜率宫);
                break;
            case 任务Type.兜率宫:
                任务Config.添加任务(任务Type.紫微宫);
                break;
            case 任务Type.紫微宫:
                任务Config.添加任务(任务Type.昊天殿);
                break;
            case 任务Type.昊天殿:
                任务Config.添加任务(任务Type.三十三重天50层);
                break;

            // 三十三重天
            case 任务Type.三十三重天50层:
                任务Config.添加任务(任务Type.三十三重天150层);
                break;
            case 任务Type.三十三重天150层:
                任务Config.添加任务(任务Type.三十三重天300层);
                break;
            case 任务Type.三十三重天300层:
                任务Config.添加任务(任务Type.三十三重天600层);
                break;
            case 任务Type.三十三重天600层:
                任务Config.添加任务(任务Type.三十三重天1000层);
                break;
            case 任务Type.三十三重天1000层:
                break;

            // 境界突破
            case 任务Type.筑基:
                任务Config.添加任务(任务Type.招募);
                任务Config.添加任务(任务Type.金丹);
                任务Config.添加任务(任务Type.上场供奉);

                break;
            case 任务Type.金丹:
                任务Config.添加任务(任务Type.坊市购买物品);
                任务Config.添加任务(任务Type.元婴);
                break;
            case 任务Type.元婴:
                任务Config.添加任务(任务Type.炼制丹药);
                任务Config.添加任务(任务Type.洗练一次法器);
                任务Config.添加任务(任务Type.分解一次法器);
                任务Config.添加任务(任务Type.化神);
                break;
            case 任务Type.化神:
                任务Config.添加任务(任务Type.种植一个灵植);
                任务Config.添加任务(任务Type.镶嵌仙石);
                任务Config.添加任务(任务Type.仙石洗练);
                任务Config.添加任务(任务Type.合体);
                break;
            case 任务Type.合体:
                任务Config.添加任务(任务Type.赠送灵植);
                任务Config.添加任务(任务Type.丹药升阶);
                任务Config.添加任务(任务Type.轮回);
                任务Config.添加任务(任务Type.大乘);
                break;
            case 任务Type.大乘:
                任务Config.添加任务(任务Type.开灵兽蛋);
                任务Config.添加任务(任务Type.天仙);
                break;
            case 任务Type.天仙:
                任务Config.添加任务(任务Type.解锁上等大道);
                任务Config.添加任务(任务Type.玄仙);
                break;
            case 任务Type.玄仙:
                任务Config.添加任务(任务Type.金仙);
                break;
            case 任务Type.金仙:
                任务Config.添加任务(任务Type.太乙金仙);
                break;
            case 任务Type.太乙金仙:
                任务Config.添加任务(任务Type.大罗金仙);
                break;
            case 任务Type.大罗金仙:
                任务Config.添加任务(任务Type.准圣);
                break;
            case 任务Type.准圣:
                任务Config.添加任务(任务Type.圣人);
                break;
            case 任务Type.圣人:
                任务Config.添加任务(任务Type.天道圣人);
                break;
            case 任务Type.天道圣人:
                任务Config.添加任务(任务Type.大道圣人);
                break;
            case 任务Type.大道圣人:
                任务Config.添加任务(任务Type.混元圣人);
                break;
            case 任务Type.混元圣人:
                任务Config.添加任务(任务Type.鸿蒙);
                break;

            // 秘境寻宝
            case 任务Type.鸿蒙:
                break;
            
           
            case 任务Type.通关一次符文之地:
                任务Config.添加任务(任务Type.符文洗练);
                任务Config.添加任务(任务Type.符文融合);
                任务Config.添加任务(任务Type.符文重铸);
                任务Config.添加任务(任务Type.符文附魔);
                break;

            // 支线
            
           
            case 任务Type.上场供奉:
                任务Config.添加任务(任务Type.升级矿场);
                任务Config.添加任务(任务Type.升级地脉);
                任务Config.添加任务(任务Type.升级玄铁);
                任务Config.添加任务(任务Type.升级功德碑);
                break;
            
            case 任务Type.打造一件法器:
                任务Config.添加任务(任务Type.装备一件法器);
                任务Config.添加任务(任务Type.领主装备强化);
                break;

            case 任务Type.领主装备强化:
                任务Config.添加任务(任务Type.领主装备洗练);
                break;
            
            
            
            case 任务Type.种植一个灵植:
                任务Config.添加任务(任务Type.施一次肥);
                break;
            case 任务Type.施一次肥:
                任务Config.添加任务(任务Type.收获一次);
                break;
            case 任务Type.收获一次:
                任务Config.添加任务(任务Type.收获一次变异灵植);
                break;
            
            case 任务Type.解锁上等大道:
                任务Config.添加任务(任务Type.解锁至尊大道);
                break;
            
            case 任务Type.开灵兽蛋:
                任务Config.添加任务(任务Type.灵兽孵化);
                break;
        }
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("任务界面item点击",任务界面item点击);
    }
}
