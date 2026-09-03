using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 主线关卡窗口 : MonoBehaviour
{
   public Button 神通配置Button;

   public GameObject 丹药content;
   public Image image;
   public TextMeshProUGUI title;
   public TextMeshProUGUI description;
   public TextMeshProUGUI 境界;
   public TextMeshProUGUI 通关奖励;
   public GameObject 敌人Content;
   public GameObject 掉落Content;
   public Button 挑战Button;
   public Button ExitButton;
   [NonSerialized] public 主线关卡Type 主线关卡Type;
   public Toggle 重复挑战Toggle;

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新战斗丹药",刷新战斗丹药);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新战斗丹药",刷新战斗丹药);
      重复挑战Toggle.onValueChanged.AddListener(delegate
      {
         ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
         PlayerData.S.重复挑战 = 重复挑战Toggle.isOn;
      });    
      神通配置Button.onClick.AddListener(() =>
      {
         ObserverModuleManager.S.SendEvent("显示神通配置弹窗");
         if (PlayerData.S.是否首次配置神通)
         {
            ObserverModuleManager.S.SendEvent("新手引导神通配置");
         }
      });
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      挑战Button.onClick.AddListener(() =>
      {
         LevelConfig.当前关卡类型 = 关卡类型.主线关卡;
         LevelConfig.当前主线关卡Type = 主线关卡Type;
         LevelConfig.Is混沌虚空 = false;

         SceneManager.LoadScene("LoadScene");
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
   private void OnEnable()
   {
      Set丹药();
      重复挑战Toggle.isOn = PlayerData.S.重复挑战;

      image.sprite = ResourcesConfig.Get主线关卡Sprite(主线关卡Type);
      title.text = LevelConfig.主线关卡NameDic[主线关卡Type];
      description.text = LevelConfig.主线关卡介绍Dic[主线关卡Type];
      境界.text = JingJieConfig.JingJieNameDic[LevelConfig.主线关卡境界Dic[主线关卡Type]];
      通关奖励.text = $"修炼速度+<color=green>{LevelConfig.主线关卡通关奖励Dic[主线关卡Type]}%</color>";
      foreach (Transform item in 敌人Content.transform)
      {
         Destroy(item.gameObject);
      }
      foreach (Transform item in 掉落Content.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in LevelConfig.LevelMonsterDic[主线关卡Type])
      {
         var MonsterItem=Instantiate(Resources.Load("Prefabs/Window/MonsterItem"),敌人Content.transform).GetComponent<MonsterItem>();
         MonsterItem.MonsterTypeName = item;
         MonsterItem.SetItem();
      }

      foreach (var item in LevelConfig.LevelDiaoLuoDic[主线关卡Type])
      {
         var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         DiaoLuoItem.propType = item.PropType;
         DiaoLuoItem.SetItem();
      }
   }
}
