using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI JingJie;
    public Slider JingJieSlider;
    public TextMeshProUGUI CurrentExp;
    public TextMeshProUGUI MaxExp;
    public TextMeshProUGUI LingQi;
    public TextMeshProUGUI GongDe;
    public Button LevelBtn;
    public Button 招募Btn;
    public Button 招募卷Debug;
    public Button 英雄按钮;
    public Button 储物袋按钮;
    public Button 经验值Debug;


    public void Init()
    {
        Name.text = PlayerData.S.Name;
        JingJie.text=JingJieConfig.JingJieNameDic[PlayerData.S.JingJieType];
        JingJieSlider.maxValue=JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType];
        JingJieSlider.value = PlayerData.S.Exp;
        CurrentExp.text=PlayerData.S.Exp.ToString();
        MaxExp.text=JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType].ToString();
        LingQi.text=PlayerData.S.LingQi.ToString();
        GongDe.text=PlayerData.S.GongDe.ToString();
        InitWindow();
        ResourcesConfig.Init();
    }

    public void InitWindow()
    {
        WindowController.S.LevelWindow=Instantiate(Resources.Load<GameObject>("Prefabs/Window/LevelWindow"));
        WindowController.S.LevelWindow.gameObject.SetActive(false);
        WindowController.S.招募Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/招募界面"));
        WindowController.S.招募Window.gameObject.SetActive(false);
        WindowController.S.英雄Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/HeroWindow"));
        WindowController.S.英雄Window.gameObject.SetActive(false);
        WindowController.S.储物袋Window=Instantiate(Resources.Load<GameObject>("Prefabs/Window/储物袋界面"));
        WindowController.S.储物袋Window.gameObject.SetActive(false);
    }

    private void Start()
    {
        经验值Debug.onClick.AddListener(() =>
        {
            PlayerData.S.PropListDic[PropType.领主经验值] += 999999;
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
        LevelBtn.onClick.AddListener(() =>
        {
            WindowController.S.LevelWindow.gameObject.SetActive(true);
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
