using System;
using System.Collections;
using System.Collections.Generic;
using Config;
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
         Scene Scene1 = SceneManager.GetSceneByName("FightScene");
         if (Scene1.IsValid() && Scene1.isLoaded)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","已在战斗中");
            return;
         }
         LevelConfig.当前关卡类型 = 关卡类型.主线关卡;
         LevelConfig.当前主线关卡Type = 主线关卡Type;

         SceneManager.LoadScene("LoadScene", LoadSceneMode.Additive);
         Scene Scene = SceneManager.GetSceneByName("LoadScene");
         WindowController.S.MainWindow.SetActive(false);
         if (Scene.IsValid() && Scene.isLoaded)
         {
            SceneManager.SetActiveScene(Scene);
         }
         gameObject.SetActive(false);
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

      主线关卡掉落 主线关卡掉落 = LevelConfig.Get主线关卡掉落(主线关卡Type, 1);
      if (主线关卡掉落.气运 > 0)
      {
         var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         switch (主线关卡Type)
         {
            case 主线关卡Type.须弥宫:
               DiaoLuoItem.propType = PropType.须弥气运;
               break;
            case 主线关卡Type.娲皇宫:
               DiaoLuoItem.propType = PropType.娲皇气运;
               break;
            case 主线关卡Type.碧游宫:
               DiaoLuoItem.propType = PropType.碧游气运;
               break;
            case 主线关卡Type.玉虚宫:
               DiaoLuoItem.propType = PropType.玉虚气运;
               break;
            case 主线关卡Type.八景宫:
               DiaoLuoItem.propType = PropType.八景气运;
               break;
         }
         DiaoLuoItem.count = 主线关卡掉落.气运;
         DiaoLuoItem.SetItem();
      }
      var 灵魂=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
      灵魂.propType = PropType.灵魂;
      灵魂.count = 主线关卡掉落.灵魂;
      灵魂.SetItem();

      if (主线关卡掉落.轮回石数量 > 0)
      {
         var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         DiaoLuoItem.propType = PropType.轮回石;
         DiaoLuoItem.count = 主线关卡掉落.轮回石数量;
         DiaoLuoItem.SetItem();
      }
      
         var 法器=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         switch (主线关卡掉落.法器材料阶数)
         {
            case 1:
               法器.propType = PropType.法器1;
               break;
            case 2:
               法器.propType = PropType.法器2;
               break;
            case 3:
               法器.propType = PropType.法器3;
               break;
            case 4:
               法器.propType = PropType.法器4;
               break;
            case 5:
               法器.propType = PropType.法器5;
               break;
            case 6:
               法器.propType = PropType.法器6;
               break;
            case 7:
               法器.propType = PropType.法器7;
               break;
            case 8:
               法器.propType = PropType.法器8;
               break;
            case 9:
               法器.propType = PropType.法器9;
               break;
            case 10:
               法器.propType = PropType.法器10;
               break;
            case 11:
               法器.propType = PropType.法器11;
               break;
            case 12:
               法器.propType = PropType.法器12;
               break;
            case 13:
               法器.propType = PropType.法器13;
               break;
            case 14:
               法器.propType = PropType.法器14;
               break;
            case 15:
               法器.propType = PropType.法器15;
               break;
            case 16:
               法器.propType = PropType.法器16;
               break;
         }
         法器.count = 主线关卡掉落.法器材料数量;
         法器.SetItem();
         
         
         
         var 仙石=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         switch (主线关卡掉落.仙石掉落阶数)
         {
            case 1:
               仙石.propType = PropType.仙石1;
               break;
            case 2:
               仙石.propType = PropType.仙石2;
               break;
            case 3:
               仙石.propType = PropType.仙石3;
               break;
            case 4:
               仙石.propType = PropType.仙石4;
               break;
            case 5:
               仙石.propType = PropType.仙石5;
               break;
            case 6:
               仙石.propType = PropType.仙石6;
               break;
            case 7:
               仙石.propType = PropType.仙石7;
               break;
            case 8:
               仙石.propType = PropType.仙石8;
               break;
            case 9:
               仙石.propType = PropType.仙石9;
               break;
            case 10:
               仙石.propType = PropType.仙石10;
               break;
            case 11:
               仙石.propType = PropType.仙石11;
               break;
            case 12:
               仙石.propType = PropType.仙石12;
               break;
            case 13:
               仙石.propType = PropType.仙石13;
               break;
            case 14:
               仙石.propType = PropType.仙石14;
               break;
            case 15:
               仙石.propType = PropType.仙石15;
               break;
            case 16:
               仙石.propType = PropType.仙石16;
               break;
         }
         仙石.count = 主线关卡掉落.仙石掉落数量;
         仙石.SetItem();
         
         var 洗练石=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         洗练石.propType = PropType.洗练石;
         洗练石.count = 主线关卡掉落.洗练石;
         洗练石.SetItem();
         
         var 高级招募卷=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         高级招募卷.propType = PropType.高级招募卷;
         高级招募卷.count = 主线关卡掉落.高级招募卷;
         高级招募卷.SetItem();
         
         var 招募卷=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         招募卷.propType = PropType.招募卷;
         招募卷.count = 主线关卡掉落.招募卷;
         招募卷.SetItem();
         
         var 锻造石=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         锻造石.propType = PropType.锻造石;
         锻造石.count = 主线关卡掉落.锻造石;
         锻造石.SetItem();
         
         var 职业经验=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         职业经验.propType = PropType.职业经验;
         职业经验.count = 主线关卡掉落.职业经验;
         职业经验.SetItem();
      
   }
}
