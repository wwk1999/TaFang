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
   public TextMeshProUGUI title;
   public TextMeshProUGUI description;
   public TextMeshProUGUI 境界;
   public TextMeshProUGUI 通关奖励;
   public GameObject 敌人Content;
   public GameObject 掉落Content;
   public Button 挑战Button;
   public Button ExitButton;
   [NonSerialized] public 主线关卡Type 主线关卡Type;

   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      挑战Button.onClick.AddListener(() =>
      {
         LevelConfig.当前关卡类型 = 关卡类型.主线关卡;
         LevelConfig.当前主线关卡Type = 主线关卡Type;
         SceneManager.LoadScene("LoadScene");
      });
   }

   private void OnEnable()
   {
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
