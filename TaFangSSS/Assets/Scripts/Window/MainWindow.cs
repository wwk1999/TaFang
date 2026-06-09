using System;
using System.Collections;
using System.Collections.Generic;
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
    }

    private void Start()
    {
        LevelBtn.onClick.AddListener(() =>
        {
            WindowController.S.LevelWindow.gameObject.SetActive(true);
        });
    }

    private void OnEnable()
    {
        Init();
    }
}
