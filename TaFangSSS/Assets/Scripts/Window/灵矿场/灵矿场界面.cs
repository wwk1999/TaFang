using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 灵矿场界面 : MonoBehaviour
{
    public Button exitButton;
    public Button 详情Button;
    public TextMeshProUGUI 灵石Count;

    //开采信息
    public TextMeshProUGUI 当前层;
    public TextMeshProUGUI 当前米;
    public TextMeshProUGUI 下一层米数;
    public TextMeshProUGUI 当前灵矿;
    public TextMeshProUGUI 挖掘速度;
    public TextMeshProUGUI 灵石收益;

    //按钮
    public Button 招募Button;
    public Button 矿工Button;
    public Button 矿洞Button;
    public Button 背包Button;
    public Button 宝物Button;

    public Button 返回领地Button;
    
    //弹窗
    public GameObject 招募界面;
    public GameObject 矿工界面;
    public GameObject 矿洞界面;
    public GameObject 背包界面;
    public GameObject 宝物界面;
    public GameObject 详情界面;
    //背景
    public GameObject 背景1;
    public GameObject 背景2;
    public GameObject 背景3;
    public GameObject 背景4;
    public GameObject 背景5;
    public GameObject 背景6;
    public GameObject 背景7;
    public GameObject 背景8;
    public GameObject 背景9;
    public GameObject 背景10;
    
    public GameObject 土层1;
    public GameObject 土层2;
    public GameObject 土层3;
    public GameObject 土层4;
    public GameObject 土层5;
    public GameObject 土层6;
    public GameObject 土层7;
    public GameObject 土层8;
    public GameObject 土层9;
    public GameObject 土层10;

    private void OnEnable()
    {
        刷新灵石();
        Show背景土层();
        Show开采信息();
    }

    private void Start()
    {
        if (PlayerData.S.是否首次进入灵矿场)
        {
            ObserverModuleManager.S.SendEvent("剧情对话",200,false);
            PlayerData.S.是否首次进入灵矿场=false;
        }
        详情Button.onClick.AddListener(() =>
        {
            详情界面.SetActive(false);
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        返回领地Button.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        招募Button.onClick.AddListener(() =>
        {
            招募界面.gameObject.SetActive(true);
        });
        
        矿工Button.onClick.AddListener(() =>
        {
            矿工界面.gameObject.SetActive(true);
        });
        
        矿洞Button.onClick.AddListener(() =>
        {
            矿洞界面.gameObject.SetActive(true);
        });
        
        背包Button.onClick.AddListener(() =>
        {
            背包界面.gameObject.SetActive(true);
        });
        
        宝物Button.onClick.AddListener(() =>
        {
            宝物界面.gameObject.SetActive(true);
        });
    }

    public void 刷新灵石()
    {
        灵石Count.text = PlayerData.S.格式化数字(PlayerData.S.PropListDic[PropType.灵石]);
    }
    public void Show背景土层()
    {
        土层Type 土层Type = 灵矿场Config.Get当前层();
        土层1.gameObject.SetActive(土层Type==土层Type.黑土浅层);
        土层2.gameObject.SetActive(土层Type==土层Type.岩石矿层);
        土层3.gameObject.SetActive(土层Type==土层Type.赤铜矿层);
        土层4.gameObject.SetActive(土层Type==土层Type.玄铁深层);
        土层5.gameObject.SetActive(土层Type==土层Type.金玉灵层);
        土层6.gameObject.SetActive(土层Type==土层Type.紫晶幻层);
        土层7.gameObject.SetActive(土层Type==土层Type.地火熔层);
        土层8.gameObject.SetActive(土层Type==土层Type.深渊暗层);
        土层9.gameObject.SetActive(土层Type==土层Type.归墟混元层);
        土层10.gameObject.SetActive(土层Type==土层Type.太初本源层);
        
        背景1.gameObject.SetActive(土层Type==土层Type.黑土浅层);
        背景2.gameObject.SetActive(土层Type==土层Type.岩石矿层);
        背景3.gameObject.SetActive(土层Type==土层Type.赤铜矿层);
        背景4.gameObject.SetActive(土层Type==土层Type.玄铁深层);
        背景5.gameObject.SetActive(土层Type==土层Type.金玉灵层);
        背景6.gameObject.SetActive(土层Type==土层Type.紫晶幻层);
        背景7.gameObject.SetActive(土层Type==土层Type.地火熔层);
        背景8.gameObject.SetActive(土层Type==土层Type.深渊暗层);
        背景9.gameObject.SetActive(土层Type==土层Type.归墟混元层);
        背景10.gameObject.SetActive(土层Type==土层Type.太初本源层);
    }
    public void Show开采信息()
    {
        当前层.text = 灵矿场Config.土层名称[灵矿场Config.Get当前层()];
        当前米.text = PlayerData.S.当前米数 + "米";
        下一层米数.text = 灵矿场Config.土层米数[灵矿场Config.Get当前层() + 1] + "米";
        当前灵矿.text = 灵矿场Config.灵矿配置表[(int)灵矿场Config.Get当前层()].名称;
        挖掘速度.text = PlayerData.S.格式化数字(灵矿场Config.Get总挖掘速度())+"/每道年";
        灵石收益.text = PlayerData.S.格式化数字(灵矿场Config.Get总固定收益())+"/每道年";
    }
}
