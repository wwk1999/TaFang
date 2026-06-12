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
    }

    private void Start()
    {
        招募卷Debug.onClick.AddListener(() =>
        {
            PlayerData.S.PropCountDic[PropType.高级招募卷] += 100;
            PlayerData.S.PropCountDic[PropType.招募卷] += 100;
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
