using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 远古遗迹窗口 : MonoBehaviour
{
    public GameObject 丹药content;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject 敌人Content;
    public GameObject 掉落Content;
    public Button 挑战Button;
    public Button ExitButton;
    public GameObject 关卡列表GameObject;
    public Toggle 重复挑战Toggle;

    public void Show关卡列表()
    {
        foreach (Transform item in 关卡列表GameObject.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i < Enum.GetValues(typeof(神物Type)).Length; i++)
        {
            神物Type Type = (神物Type)i;
            var 遗迹Item = Instantiate(Resources.Load("Prefabs/Window/远古遗迹/远古遗迹关卡item"),关卡列表GameObject.transform).GetComponent<远古遗迹关卡item>();
            遗迹Item.神物Type = Type;
            遗迹Item.SetItem();
        }
    }

    public void Show右panel(神物Type type)
    {
        title.text = 神物Config.神物名Dic[type];
        foreach (Transform item in 敌人Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in 掉落Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in 神物Config.遗迹怪物列表[type])
        {
            var MonsterItem=Instantiate(Resources.Load("Prefabs/Window/MonsterItem"),敌人Content.transform).GetComponent<MonsterItem>();
            MonsterItem.MonsterTypeName = item;
            RectTransform trans = MonsterItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(80, 80);
            MonsterItem.SetItem();
        }
        var 神物Item=Instantiate(Resources.Load("Prefabs/Window/远古遗迹/遗迹掉落Item"),掉落Content.transform).GetComponent<遗迹掉落Item>();
        神物Item.神物Type = type;
        RectTransform trans1 = 神物Item.gameObject.GetComponent<RectTransform>();
        trans1.sizeDelta = new Vector2(80, 80);
        神物Item.SetItem();
        
        foreach (var item in 神物Config.遗迹掉落Dic[type])
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/远古遗迹/遗迹掉落Item"),掉落Content.transform).GetComponent<遗迹掉落Item>();
            DiaoLuoItem.PropType = item.PropType;
            RectTransform trans = DiaoLuoItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(80, 80);
            DiaoLuoItem.SetItem();
        }
    }
    
    private void OnEnable()
    {
        Set丹药();
        Show关卡列表();
        重复挑战Toggle.isOn = PlayerData.S.重复挑战;

        HeroWindowController.S.当前遗迹关卡Type = PlayerData.S.最大神物关卡;
        ObserverModuleManager.S.SendEvent("遗迹关卡按钮点击",HeroWindowController.S.当前遗迹关卡Type);
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

        ObserverModuleManager.S.UnRegisterEvent("遗迹关卡按钮点击",遗迹关卡按钮点击);
    }

    public void 遗迹关卡按钮点击(object[] obj)
    {
        神物Type Type = (神物Type)obj[0];
        HeroWindowController.S.当前遗迹关卡Type=Type;
        Show右panel(Type);
    }
    private void Awake()
    {       
        ObserverModuleManager.S.RegisterEvent("刷新战斗丹药",刷新战斗丹药);
        ObserverModuleManager.S.RegisterEvent("遗迹关卡按钮点击",遗迹关卡按钮点击);
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        重复挑战Toggle.onValueChanged.AddListener(delegate
        {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
            PlayerData.S.重复挑战 = 重复挑战Toggle.isOn;
        });
        挑战Button.onClick.AddListener(() =>
        {
            LevelConfig.当前关卡类型 = 关卡类型.远古遗迹;
            LevelConfig.当前神物Type= HeroWindowController.S.当前遗迹关卡Type;
            SceneManager.LoadScene("LoadScene");
        });
    }
}
