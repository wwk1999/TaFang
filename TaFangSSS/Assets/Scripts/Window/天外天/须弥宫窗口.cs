using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 须弥宫窗口 : MonoBehaviour
{
    public Button 秘宝Button;
    public GameObject 秘宝宝库;
    public Button 神通配置Button;

    public GameObject 丹药content;

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
    public Toggle 自动下一关Toggle;

    private void Start()
    {
        秘宝Button.onClick.AddListener(() =>
        {
            秘宝宝库.gameObject.SetActive(true);
        });
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
        自动下一关Toggle.onValueChanged.AddListener(delegate
        {
            ObserverModuleManager.S.SendEvent("播放音效",音效Type.Toggle);
            PlayerData.S.是否自动下一关 = 自动下一关Toggle.isOn;
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
            LevelConfig.当前主线关卡Type = 主线关卡Type.须弥宫;
            LevelConfig.战斗须弥宫层数 = HeroWindowController.S.显示须弥宫层数;
            ObserverModuleManager.S.SendEvent("播放BGM",false);
            SceneManager.LoadScene("LoadScene", LoadSceneMode.Additive);
            Scene Scene = SceneManager.GetSceneByName("LoadScene");
            if (Scene.IsValid() && Scene.isLoaded)
            {
                SceneManager.SetActiveScene(Scene);
            }
            WindowController.S.MainWindow.SetActive(false);
            gameObject.SetActive(false);
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
            int 最大页数 = Mathf.CeilToInt(PlayerData.S.须弥宫最大层数 / 30f);
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
        int max = Math.Min(PlayerData.S.须弥宫最大层数,pageNum*30);
        foreach (Transform item in 关卡层数GameObject.transform)
        {
            Destroy(item.gameObject);
        }

        for (int i = min; i <= max; i++)
        {
            var item = Instantiate(Resources.Load("Prefabs/Window/天外天/须弥宫格子item"), 关卡层数GameObject.transform)
                .GetComponent<须弥宫格子item>();
            item.层数 = i;
            item.SetItem();
        }
    }

    public void 须弥宫格子点击(object[] obj)
    {
        int count=(int)obj[0];
        HeroWindowController.S.显示须弥宫层数 = count;
    }

    public void 刷新须弥宫窗口(object[] obj)
    {
    }
    private void Awake()
    {
        ObserverModuleManager.S.RegisterEvent("刷新战斗丹药",刷新战斗丹药);

        ObserverModuleManager.S.RegisterEvent("刷新须弥宫窗口",刷新须弥宫窗口);
        ObserverModuleManager.S.RegisterEvent("须弥宫格子点击",须弥宫格子点击);
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

        ObserverModuleManager.S.UnRegisterEvent("刷新须弥宫窗口",刷新须弥宫窗口);
        ObserverModuleManager.S.UnRegisterEvent("须弥宫格子点击",须弥宫格子点击);
    }

    private void OnEnable()
    {
        Set丹药();
        重复挑战Toggle.isOn = PlayerData.S.重复挑战;
        自动下一关Toggle.isOn = PlayerData.S.是否自动下一关;
        int 最大页数 = Mathf.CeilToInt(PlayerData.S.须弥宫最大层数 / 30f);
        Show关卡层数(最大页数);
        PageNumText.text = 最大页数.ToString();
        pagenum = 最大页数;
        HeroWindowController.S.显示须弥宫层数 = PlayerData.S.须弥宫最大层数;
        ObserverModuleManager.S.SendEvent("须弥宫格子点击",HeroWindowController.S.显示须弥宫层数);
        foreach (Transform item in 敌人Content.transform)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in 掉落Content.transform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in LevelConfig.LevelMonsterDic[主线关卡Type.须弥宫])
        {
            var MonsterItem=Instantiate(Resources.Load("Prefabs/Window/MonsterItem"),敌人Content.transform).GetComponent<MonsterItem>();
            MonsterItem.MonsterTypeName = item;
            RectTransform trans = MonsterItem.gameObject.GetComponent<RectTransform>();
            trans.sizeDelta = new Vector2(70, 70);
            MonsterItem.SetItem();
        }

        主线关卡掉落 主线关卡掉落 = LevelConfig.Get主线关卡掉落(主线关卡Type.须弥宫,HeroWindowController.S.显示须弥宫层数 );
          
          if (主线关卡掉落.气运 > 0)
          {
              var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
              DiaoLuoItem.propType = PropType.须弥气运;
              DiaoLuoItem.count = 主线关卡掉落.气运;
              RectTransform trans13 = DiaoLuoItem.gameObject.GetComponent<RectTransform>();
              trans13.sizeDelta = new Vector2(70, 70);
              DiaoLuoItem.SetItem();
          }
          
      var 灵魂=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
      灵魂.propType = PropType.灵魂;
      灵魂.count = 主线关卡掉落.灵魂;
      RectTransform trans3 = 灵魂.gameObject.GetComponent<RectTransform>();
      trans3.sizeDelta = new Vector2(70, 70);
      灵魂.SetItem();

      if (主线关卡掉落.轮回石数量 > 0)
      {
         var DiaoLuoItem=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         DiaoLuoItem.propType = PropType.轮回石;
         DiaoLuoItem.count = 主线关卡掉落.轮回石数量;
         RectTransform trans4 = DiaoLuoItem.gameObject.GetComponent<RectTransform>();
         trans4.sizeDelta = new Vector2(70, 70);
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
         RectTransform trans5 = 法器.gameObject.GetComponent<RectTransform>();
         trans5.sizeDelta = new Vector2(70, 70);
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
         RectTransform trans6 = 仙石.gameObject.GetComponent<RectTransform>();
         trans6.sizeDelta = new Vector2(70, 70);
         仙石.SetItem();
         
         var 洗练石=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         洗练石.propType = PropType.洗练石;
         洗练石.count = 主线关卡掉落.洗练石;
         RectTransform trans7 = 洗练石.gameObject.GetComponent<RectTransform>();
         trans7.sizeDelta = new Vector2(70, 70);
         洗练石.SetItem();
         
         var 高级招募卷=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         高级招募卷.propType = PropType.高级招募卷;
         高级招募卷.count = 主线关卡掉落.高级招募卷;
         RectTransform trans8 = 高级招募卷.gameObject.GetComponent<RectTransform>();
         trans8.sizeDelta = new Vector2(70, 70);
         高级招募卷.SetItem();
         
         var 招募卷=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         招募卷.propType = PropType.招募卷;
         招募卷.count = 主线关卡掉落.招募卷;
         RectTransform trans9 = 招募卷.gameObject.GetComponent<RectTransform>();
         trans9.sizeDelta = new Vector2(70, 70);
         招募卷.SetItem();
         
         var 锻造石=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         锻造石.propType = PropType.锻造石;
         锻造石.count = 主线关卡掉落.锻造石;
         RectTransform trans10 = 锻造石.gameObject.GetComponent<RectTransform>();
         trans10.sizeDelta = new Vector2(70, 70);
         锻造石.SetItem();
         
         var 职业经验=Instantiate(Resources.Load("Prefabs/Window/DiaoLuoItem"),掉落Content.transform).GetComponent<DiaoLuoItem>();
         职业经验.propType = PropType.职业经验;
         职业经验.count = 主线关卡掉落.职业经验;
         RectTransform trans11 = 职业经验.gameObject.GetComponent<RectTransform>();
         trans11.sizeDelta = new Vector2(70, 70);
         职业经验.SetItem();
    }
}
