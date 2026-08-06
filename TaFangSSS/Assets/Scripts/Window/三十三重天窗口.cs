using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 三十三重天窗口 : MonoBehaviour
{
   public Image image;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI 境界;
    public TextMeshProUGUI 通关奖励;
    public GameObject 敌人Content;
    public GameObject 掉落Content;
    public Button 挑战Button;
    public Button ExitButton;
    public GameObject 关卡列表GameObject;
    public Toggle 重复挑战Toggle;

    public void 三十三重天按钮点击(object[] obj)
    {
        主线关卡Type Type = (主线关卡Type)obj[0];
        Show三十三重天窗口(Type);
    }

    public void Show关卡列表()
    {
        foreach (Transform item in 关卡列表GameObject.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = 24; i <= 32; i++)
        {
            主线关卡Type Type = (主线关卡Type)i;
            var 凌霄宝殿Item = Instantiate(Resources.Load("Prefabs/Window/三十三重天关卡item"),关卡列表GameObject.transform).GetComponent<三十三重天关卡item>();
            凌霄宝殿Item.主线关卡Type = Type;
            凌霄宝殿Item.SetItem();
        }
    }

    private void OnEnable()
    {
        Show关卡列表();
        重复挑战Toggle.isOn = PlayerData.S.重复挑战;
        HeroWindowController.S.当前三十三重天Type= PlayerData.S.最大主线关卡>主线关卡Type.大罗天?主线关卡Type.大罗天:PlayerData.S.最大主线关卡;
        ObserverModuleManager.S.SendEvent("三十三重天按钮点击",HeroWindowController.S.当前三十三重天Type);
    }

    private void OnDestroy()
    {
        ObserverModuleManager.S.UnRegisterEvent("三十三重天按钮点击",三十三重天按钮点击);
    }

    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("三十三重天按钮点击",三十三重天按钮点击);
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
            LevelConfig.当前关卡类型 = 关卡类型.主线关卡;
            LevelConfig.当前主线关卡Type = HeroWindowController.S.当前三十三重天Type;
            SceneManager.LoadScene("LoadScene");
        });
    }

    public void Show三十三重天窗口(主线关卡Type Type)
    {
        image.sprite = ResourcesConfig.Get主线关卡Sprite(Type);
        title.text = LevelConfig.主线关卡NameDic[Type];
        description.text = LevelConfig.主线关卡介绍Dic[Type];
        境界.text = JingJieConfig.JingJieNameDic[LevelConfig.主线关卡境界Dic[Type]];
        通关奖励.text = $"修炼速度+<color=green>{LevelConfig.主线关卡通关奖励Dic[Type]}%</color>";
        foreach (Transform item in 敌人Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in 掉落Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in LevelConfig.LevelMonsterDic[Type])
        {
            var MonsterItem=Instantiate(Resources.Load("Prefabs/Window/MonsterItem"),敌人Content.transform).GetComponent<MonsterItem>();
            MonsterItem.MonsterTypeName = item;
            RectTransform trans = MonsterItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(80, 80);
            MonsterItem.SetItem();
        }

        foreach (var item in LevelConfig.LevelDiaoLuoDic[Type])
        {
            var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
            DiaoLuoItem.propType = item.PropType;
            RectTransform trans = DiaoLuoItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(80, 80);
            DiaoLuoItem.SetItem();
        }
    }
}
