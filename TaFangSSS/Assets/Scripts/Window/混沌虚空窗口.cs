using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 混沌虚空窗口 : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI 通关奖励;
    public GameObject 敌人Content;
    public GameObject 掉落Content;
    public Button 挑战Button;
    public Button ExitButton;
    public GameObject 关卡层数GameObject;
    public TextMeshProUGUI PageNumText;
    public Button 左箭头;
    public Button 右箭头;
    private int pagenum = 1;
    public Toggle 重复挑战Toggle;

    private void Start()
    {
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        重复挑战Toggle.onValueChanged.AddListener(delegate
        {
            PlayerData.S.重复挑战 = 重复挑战Toggle.isOn;
        });
        挑战Button.onClick.AddListener(() =>
        {
            LevelConfig.当前关卡类型 = 关卡类型.主线关卡;
            LevelConfig.当前主线关卡Type = 主线关卡Type.混沌虚空;
            LevelConfig.Is混沌虚空 = true;
            LevelConfig.战斗混沌虚空层数 = HeroWindowController.S.显示混沌虚空层数;
            SceneManager.LoadScene("LoadScene");
        });
        左箭头.onClick.AddListener(() =>
        {
            if (pagenum == 1)
            {
                return;
            }

            pagenum--;
            PageNumText.text = pagenum.ToString();
            Show关卡层数(pagenum);
        });
        右箭头.onClick.AddListener(() =>
        {
            int 最大页数 = Mathf.CeilToInt(PlayerData.S.混沌虚空最大层数 / 30f);
            if (pagenum == 最大页数)
            {
                return;
            }

            pagenum++;
            PageNumText.text = pagenum.ToString();
            Show关卡层数(pagenum);
        });
    }

    public void Show关卡层数(int pageNum)
    {
        int min=(pageNum - 1) * 30+1;
        int max = Math.Min(PlayerData.S.混沌虚空最大层数,pageNum*30);
        foreach (Transform item in 关卡层数GameObject.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = min; i <= max; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/混沌虚空格子item"), 关卡层数GameObject.transform)
                .GetComponent<混沌虚空格子item>();
            item.层数 = i;
            item.SetItem();
        }
    }

    public void 混沌虚空格子点击(object[] obj)
    {
        int count=(int)obj[0];
        HeroWindowController.S.显示混沌虚空层数 = count;
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("混沌虚空格子点击",混沌虚空格子点击);
    }

    private void OnDestroy()
    {        
        ObserverModuleManager.S.UnRegisterEvent("混沌虚空格子点击",混沌虚空格子点击);
    }

    private void OnEnable()
    {
        重复挑战Toggle.isOn = PlayerData.S.重复挑战;

        int 最大页数 = Mathf.CeilToInt(PlayerData.S.混沌虚空最大层数 / 30f);
        Show关卡层数(最大页数);
        PageNumText.text = 最大页数.ToString();
        pagenum = 最大页数;
        HeroWindowController.S.显示混沌虚空层数 = PlayerData.S.混沌虚空最大层数;
        ObserverModuleManager.S.SendEvent("混沌虚空格子点击",HeroWindowController.S.显示混沌虚空层数);
        title.text = LevelConfig.主线关卡NameDic[主线关卡Type.混沌虚空];
        description.text = LevelConfig.主线关卡介绍Dic[主线关卡Type.混沌虚空];
        通关奖励.text = $"修炼速度+<color=green>{LevelConfig.主线关卡通关奖励Dic[主线关卡Type.混沌虚空]}%</color>";
        foreach (Transform item in 敌人Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in 掉落Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in LevelConfig.LevelMonsterDic[主线关卡Type.混沌虚空])
        {
            var MonsterItem=Instantiate(Resources.Load("Prefabs/Window/MonsterItem"),敌人Content.transform).GetComponent<MonsterItem>();
            MonsterItem.MonsterTypeName = item;
            RectTransform trans = MonsterItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(70, 70);
            MonsterItem.SetItem();
        }

        foreach (var item in LevelConfig.LevelDiaoLuoDic[主线关卡Type.混沌虚空])
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
            DiaoLuoItem.propType = item.PropType;
            RectTransform trans = DiaoLuoItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(70, 70);
            DiaoLuoItem.SetItem();
        }
    }
}
