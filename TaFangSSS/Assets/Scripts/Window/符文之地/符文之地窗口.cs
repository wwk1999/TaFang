using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 符文之地窗口 : MonoBehaviour
{
    public Button 神通配置Button;

    public GameObject 丹药content;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject 敌人Content;
    public GameObject 掉落Content;
    public Button 挑战Button;
    public Button 掉落Button;
    public GameObject 掉落概率GameObject;

    public Button ExitButton;
    public GameObject 关卡列表GameObject;
    public Toggle 重复挑战Toggle;
    
    
    public void Show关卡列表()
    {
        foreach (Transform item in 关卡列表GameObject.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 1; i < Enum.GetValues(typeof(符文之地Type)).Length; i++)
        {
            符文之地Type Type = (符文之地Type)i;
            var 符文之地Item = Instantiate(Resources.Load("Prefabs/Window/符文之地/符文之地关卡item"),关卡列表GameObject.transform).GetComponent<符文之地关卡item>();
            符文之地Item.符文之地Type = Type;
            符文之地Item.SetItem();
        }
    }
    
    
    public void Show符文之地窗口(符文之地Type Type)
    {
        // 越界（通关最终关后自增出的无效值）钳到最终关，保持全解锁
        if (!符文之地Config.符文之地关卡名Dic.ContainsKey(Type))
        {
            Type = 符文之地Type.天道台;
        }
        title.text = 符文之地Config.符文之地关卡名Dic[Type];
        foreach (Transform item in 敌人Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in 掉落Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in 符文之地Config.符文之地怪物列表[Type])
        {
            var MonsterItem=Instantiate(Resources.Load("Prefabs/Window/MonsterItem"),敌人Content.transform).GetComponent<MonsterItem>();
            MonsterItem.MonsterTypeName = item;
            RectTransform trans = MonsterItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(80, 80);
            MonsterItem.SetItem();
        }

        if (符文之地Config.符文之地掉落概率Dic[Type][4] != 0)
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/符文之地/符文之地掉落Item"),掉落Content.transform).GetComponent<符文之地掉落Item>();
            DiaoLuoItem.QualityType = 符文Config.符文品质对应Quality[符文品质Type.道文];
            DiaoLuoItem.SetItem();
        }

        if (符文之地Config.符文之地掉落概率Dic[Type][3] != 0)
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/符文之地/符文之地掉落Item"),掉落Content.transform).GetComponent<符文之地掉落Item>();
            DiaoLuoItem.QualityType = 符文Config.符文品质对应Quality[符文品质Type.圣文];
            DiaoLuoItem.SetItem();
        }
        
        if (符文之地Config.符文之地掉落概率Dic[Type][2] != 0)
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/符文之地/符文之地掉落Item"),掉落Content.transform).GetComponent<符文之地掉落Item>();
            DiaoLuoItem.QualityType = 符文Config.符文品质对应Quality[符文品质Type.帝文];
            DiaoLuoItem.SetItem();
        }
        
        
        if (符文之地Config.符文之地掉落概率Dic[Type][1] != 0)
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/符文之地/符文之地掉落Item"),掉落Content.transform).GetComponent<符文之地掉落Item>();
            DiaoLuoItem.QualityType = 符文Config.符文品质对应Quality[符文品质Type.仙文];
            DiaoLuoItem.SetItem();
        }
        
        if (符文之地Config.符文之地掉落概率Dic[Type][0] != 0)
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/符文之地/符文之地掉落Item"),掉落Content.transform).GetComponent<符文之地掉落Item>();
            DiaoLuoItem.QualityType = 符文Config.符文品质对应Quality[符文品质Type.灵文];
            DiaoLuoItem.SetItem();
        }
        
        foreach (var item in 符文之地Config.符文之地掉落Dic[Type])
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/符文之地/符文之地掉落Item"),掉落Content.transform).GetComponent<符文之地掉落Item>();
            DiaoLuoItem.PropType = item.PropType;
            RectTransform trans = DiaoLuoItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(80, 80);
            DiaoLuoItem.SetItem();
        }
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
    public void 符文之地按钮点击(object[] obj)
    {
        符文之地Type Type = (符文之地Type)obj[0];
        Show符文之地窗口(Type);
    }
    
    private void OnEnable()
    {
        Set丹药();
        Show关卡列表();
        重复挑战Toggle.isOn = PlayerData.S.重复挑战;

        // 越界只可能是通关最终关后自增出的无效值（如 11），
        // 钳到最终关保持全解锁，不能钳回第一关清掉玩家进度
        if (!符文之地Config.符文之地关卡名Dic.ContainsKey(PlayerData.S.符文之地最大关卡))
        {
            PlayerData.S.符文之地最大关卡 = 符文之地Type.天道台;
        }
        HeroWindowController.S.当前符文之地Type = PlayerData.S.符文之地最大关卡;
        ObserverModuleManager.S.SendEvent("符文之地按钮点击",HeroWindowController.S.当前符文之地Type);
    }
    
    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("刷新战斗丹药",刷新战斗丹药);
        ObserverModuleManager.S.UnRegisterEvent("符文之地按钮点击",符文之地按钮点击);
    }
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("刷新战斗丹药",刷新战斗丹药);
        ObserverModuleManager.S.RegisterEvent("符文之地按钮点击",符文之地按钮点击);
        ExitButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        神通配置Button.onClick.AddListener(() =>
        {
            ObserverModuleManager.S.SendEvent("显示神通配置弹窗");
        });
        重复挑战Toggle.onValueChanged.AddListener(delegate
        {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
            PlayerData.S.重复挑战 = 重复挑战Toggle.isOn;
        });
        掉落Button.onClick.AddListener(() =>
        {
            掉落概率GameObject.gameObject.SetActive(true);
        });
        挑战Button.onClick.AddListener(() =>
        {
            Scene Scene1 = SceneManager.GetSceneByName("FightScene");
            if (Scene1.IsValid() && Scene1.isLoaded)
            {
                ObserverModuleManager.S.SendEvent("SendUIToast","已在战斗中");
                return;
            }
            LevelConfig.当前关卡类型 = 关卡类型.符文之地;
            LevelConfig.Is混沌虚空 = false;
            LevelConfig.当前符文之地Type = HeroWindowController.S.当前符文之地Type;
            SceneManager.LoadScene("LoadScene", LoadSceneMode.Additive);
            Scene Scene = SceneManager.GetSceneByName("LoadScene");
            if (Scene.IsValid() && Scene.isLoaded)
            {
                SceneManager.SetActiveScene(Scene);
            }
            WindowController.S.MainWindow.SetActive(false);
            gameObject.SetActive(false);
        });
    }
}
