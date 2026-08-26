using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class 洞天秘境窗口 : MonoBehaviour
{
    public GameObject 丹药content;

    public Button exitButton;
    public Button maskButton;

    public GameObject 关卡列表;
    public TextMeshProUGUI 关卡名;
    public GameObject 敌人列表;
    public GameObject 掉落列表;
    public TextMeshProUGUI 境界要求;
    public Button left;
    public Button right;
    public TextMeshProUGUI 难度;
    public Button 挑战按钮;
    public Toggle 重复挑战;
    
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("刷新战斗丹药",刷新战斗丹药);
        挑战按钮.onClick.AddListener(() =>
        {
            LevelConfig.当前关卡类型 = 关卡类型.洞天秘境;
            SceneManager.LoadScene("LoadScene");
        });
        exitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        maskButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        重复挑战.onValueChanged.AddListener((value) =>
        {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
            PlayerData.S.重复挑战=value;
        });
        left.onClick.AddListener(() =>
        {
            if (LevelConfig.当前洞天QualityType > QualityType.黄品)
            {
                LevelConfig.当前洞天QualityType--;
                ShowInfo();
            }
        });
        right.onClick.AddListener(() =>
        {
            if (LevelConfig.当前洞天QualityType < QualityType.荒品)
            {
                LevelConfig.当前洞天QualityType++;
                ShowInfo();
            }
        });
    }
    public void 刷新战斗丹药(object[] obj)
    {
        Set丹药();
    }
    public void Set丹药()
    {
        foreach (Transform item in 丹药content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in PlayerData.S.战斗选择丹药Dic)
        {
            var 丹药item=Instantiate(Resources.Load("Prefabs/Window/炼丹界面/战斗丹药tem"),丹药content.transform).GetComponent<战斗丹药tem>();
            丹药item.index = item.Key;
            丹药item.SetItem();
        }
    }
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新战斗丹药",刷新战斗丹药);

    }

    private void OnEnable()
    {
        Set丹药();
        ShowInfo();
        Show关卡列表();
    }

    public void ShowInfo()
    {
        境界要求.text=JingJieConfig.JingJieNameDic[PlayerData.S.当前轮回境界];
        难度.text = PropConfig.QualityNameDic[LevelConfig.当前洞天QualityType];
        难度.colorGradientPreset = ResourcesConfig.Get品质TMP(LevelConfig.当前洞天QualityType);
        关卡名.text = JingJieConfig.JingJieNameDic[PlayerData.S.当前轮回境界] + "境";
        foreach (Transform item in 敌人列表.transform)
        {
            Destroy(item.gameObject);
        }
        
        foreach (Transform item in 掉落列表.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in LevelConfig.洞天MonsterDic[PlayerData.S.当前轮回境界])
        {
            var MonsterItem=Instantiate(Resources.Load("Prefabs/Window/MonsterItem"),敌人列表.transform).GetComponent<MonsterItem>();
            MonsterItem.MonsterTypeName = item;
            RectTransform trans = MonsterItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(80, 80);
            MonsterItem.SetItem();
        }
        var 功德item=Instantiate(Resources.Load("Prefabs/Window/洞天掉落Item"),掉落列表.transform).GetComponent<洞天掉落Item>();
        功德item.PropType = PropType.功德;
        功德item.QualityType = LevelConfig.当前洞天QualityType;

        RectTransform trans1 = 功德item.gameObject.GetComponent<RectTransform>();
        trans1.sizeDelta = new Vector2(80, 80);
        功德item.SetItem();
        var 灵魂item=Instantiate(Resources.Load("Prefabs/Window/洞天掉落Item"),掉落列表.transform).GetComponent<洞天掉落Item>();
        灵魂item.PropType = PropType.灵魂;
        灵魂item.QualityType = LevelConfig.当前洞天QualityType;

        RectTransform trans2 = 灵魂item.gameObject.GetComponent<RectTransform>();
        trans2.sizeDelta = new Vector2(80, 80);
        灵魂item.SetItem();
        var list = 灵物突破Config.灵物掉落概率Dic[LevelConfig.当前洞天QualityType];
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == 0) continue;
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/洞天掉落Item"),掉落列表.transform).GetComponent<洞天掉落Item>();
            DiaoLuoItem.QualityType = (QualityType)(i+1);
            DiaoLuoItem.SetItem();
        }
    }
    public void Show关卡列表()
    {
        foreach (Transform item in 关卡列表.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i < Enum.GetValues(typeof(JingJieType)).Length-1; i++)
        {
            var 关卡item=Instantiate(Resources.Load("Prefabs/Window/洞天秘境关卡item"),关卡列表.transform).GetComponent<洞天秘境关卡item>();
            关卡item.JingJieType = (JingJieType)i;
            关卡item.SetItem();
        }
    }
    
}
