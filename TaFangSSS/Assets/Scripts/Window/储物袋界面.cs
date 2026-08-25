using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 储物袋界面 : MonoBehaviour
{
   public 轮回确认弹窗 轮回确认弹窗;
   public Button 轮回按钮;
   public 丹方使用弹窗 丹方使用弹窗;
   public 确认服用造化丹药弹窗 确认服用造化丹药弹窗;
   public 服用辅助丹药弹窗 服用辅助丹药弹窗;
   public 根基丹药服用弹窗 根基丹药服用弹窗;
   
   public 分解确认弹窗 分解确认弹窗;
   public Button 左箭头;
   public Button 右箭头;
   public TextMeshProUGUI 页数;
   private int 页数Num = 1;
   public 法器仙石分解弹窗 法器仙石分解弹窗;
   public 功法分解弹窗 功法分解弹窗;
   public TextMeshProUGUI 修炼速度count;
   public GameObject 头像框;
   public Button 突破Button;
   public Image 道纹image;
   public 道纹弹窗 道纹弹窗;
   public Button ExitButton;
   public GameObject EquipContent;
   public GameObject BagContent;
   public Button 强化Btn;
   public Button 材料Btn;
   public Button 道纹Btn;
   public Button 功法Btn;
   public Button 灵物Btn;
   public Button 法器Btn;
   public Button 仙石Btn;
   public Button 分解Btn;
   public Button 神物Btn;
   public Button 灵药Btn;
   public Button 丹药Btn;

   public TextMeshProUGUI  Name;
   public TextMeshProUGUI  跟脚;
   public TextMeshProUGUI  体质;

   public TextMeshProUGUI 境界Name;
   public TextMeshProUGUI CurrentExp;
   public TextMeshProUGUI MaxExp;
   public Slider ExpSlider;
   public GameObject 突破弹窗;
   private int 显示类型 = 1;//1是材料，2是道文，3是功法
   public GameObject 强化弹窗;
   public GameObject 人物属性弹窗;
   public Button 属性Btn;
   public Image 头像框Icon;

   public void Set头像框()
   {
      头像框Icon.sprite = ResourcesConfig.Get境界Icon(PlayerData.S.当前轮回境界);
      头像框Icon.SetNativeSize();
   }
   public void Set境界()
   {
      Set头像框();
      体质.text = 体质Config.体质名Dic[PlayerData.S.当前体质];
      体质.colorGradientPreset = ResourcesConfig.Get品质TMP(体质Config.体质品质Dic[PlayerData.S.当前体质]);
      轮回按钮.gameObject.SetActive(PlayerData.S.当前轮回境界>=JingJieType.合体);
      修炼速度count.text = 属性config.总修炼速度加成 + "%";
      跟脚.text = MathF.Round(JingJieConfig.跟脚,2).ToString();
      境界Name.text=JingJieConfig.JingJieNameDic[PlayerData.S.当前轮回境界];
   }
   public void 突破成功(object[] obj)
   {
      Set经验SLider();
      Set境界();
      刷新背包();
   }

   public void 刷新装备(object[] obj)
   {
      ShowEquip();
   }

   public void Show道纹弹窗(object[] obj)
   {
      EquipType equipType = (EquipType)obj[0];
      道纹弹窗.equipType = equipType;
      道纹弹窗.gameObject.SetActive(true);
      道纹弹窗.GetComponent<RectTransform>().anchoredPosition=道纹config.道纹弹窗Pos[equipType];
   }

   public void Show道纹image(object[] obj)
   {
      道纹Type 道纹Type = (道纹Type)obj[0];
      QualityType qualityType = (QualityType)obj[1];
      HeroWindowController.S.道纹Type = 道纹Type;
      HeroWindowController.S.道纹QualityType = qualityType;
      道纹image.sprite = ResourcesConfig.Get道纹Sprite(道纹Type,qualityType);
      道纹image.gameObject.SetActive(true);
   }

   public void 增加修为(object[] obj)
   {
      float 修为 = (float)obj[0];
      var 修为item = Instantiate(Resources.Load("Prefabs/Window/修为item"),头像框.transform).GetComponent<修为item>();
      修为item.修为 = 修为;
      修为item.SetItem();
      Set经验SLider();
      Set境界();
   }

   public void 刷新背包(object[] obj)
   {
      刷新背包();
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("刷新人物信息",刷新人物信息);
      ObserverModuleManager.S.UnRegisterEvent("显示使用丹方弹窗",显示使用丹方弹窗);
      ObserverModuleManager.S.UnRegisterEvent("显示服用造化丹药确认弹窗",显示服用造化丹药确认弹窗);
      ObserverModuleManager.S.UnRegisterEvent("服用根基丹药",服用根基丹药);
      ObserverModuleManager.S.UnRegisterEvent("服用辅助丹药弹窗",服用辅助丹药弹窗1);
      ObserverModuleManager.S.UnRegisterEvent("显示确认分解弹窗",显示确认分解弹窗);
      ObserverModuleManager.S.UnRegisterEvent("功法分解",功法分解);
      ObserverModuleManager.S.UnRegisterEvent("增加修为",增加修为);
      ObserverModuleManager.S.UnRegisterEvent("Show道纹image", Show道纹image);
      ObserverModuleManager.S.UnRegisterEvent("Show道纹弹窗", Show道纹弹窗);
      ObserverModuleManager.S.UnRegisterEvent("刷新装备", 刷新装备);
      ObserverModuleManager.S.UnRegisterEvent("刷新背包", 刷新背包);
      ObserverModuleManager.S.UnRegisterEvent("突破成功", 突破成功);
   }

   public void 功法分解(object[] obj)
   {
      功法Type type = (功法Type)obj[0];
      功法分解弹窗.功法Type = type;
      功法分解弹窗.SetItem();
      功法分解弹窗.gameObject.SetActive(true);
   }

   public void 显示确认分解弹窗(object[] obj)
   {
      分解类型 类型 = (分解类型)obj[0];
      if (类型 == 分解类型.法器)
      {
         法器 法器 = obj[1] as 法器;
         分解确认弹窗.分解类型 = 类型;
         分解确认弹窗.法器 = 法器;
      }
      else
      {
         仙石 仙石 = obj[1] as 仙石;
         分解确认弹窗.分解类型 = 类型;
         分解确认弹窗.仙石 = 仙石;
      }
      分解确认弹窗.gameObject.SetActive(true);
   }

   public void 服用辅助丹药弹窗1(object[] obj)
   {
      丹药Type type=(丹药Type)obj[0];
      QualityType qualityType = (QualityType)obj[1];
      服用辅助丹药弹窗.丹药Type = type;
      服用辅助丹药弹窗.QualityType = qualityType;
      服用辅助丹药弹窗.gameObject.SetActive(true);
   }

   public void 服用根基丹药(object[] obj)
   {
      丹药Type type=(丹药Type)obj[0];
      QualityType qualityType = (QualityType)obj[1];
      根基丹药服用弹窗.丹药Type = type;
      根基丹药服用弹窗.QualityType = qualityType;
      根基丹药服用弹窗.gameObject.SetActive(true);
   }

   public void 显示服用造化丹药确认弹窗(object[] obj)
   {
      QualityType qualityType=(QualityType)obj[0];
      确认服用造化丹药弹窗.qualityType = qualityType;
      确认服用造化丹药弹窗.gameObject.SetActive(true);
   }

   public void 显示使用丹方弹窗(object[] obj)
   {
      丹药Type type = (丹药Type)obj[0];
      QualityType qualityType=(QualityType)obj[1];
      丹方使用弹窗.qualityType = qualityType;
      丹方使用弹窗.丹药Type = type;
      丹方使用弹窗.gameObject.SetActive(true);
   }

   public void 刷新人物信息(object[] obj)
   {
      Set经验SLider();
      Set境界();
   }
   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("刷新人物信息",刷新人物信息);
      ObserverModuleManager.S.RegisterEvent("显示使用丹方弹窗",显示使用丹方弹窗);
      ObserverModuleManager.S.RegisterEvent("显示服用造化丹药确认弹窗",显示服用造化丹药确认弹窗);
      ObserverModuleManager.S.RegisterEvent("服用根基丹药",服用根基丹药);
      ObserverModuleManager.S.RegisterEvent("服用辅助丹药弹窗",服用辅助丹药弹窗1);
      ObserverModuleManager.S.RegisterEvent("显示确认分解弹窗",显示确认分解弹窗);
      ObserverModuleManager.S.RegisterEvent("功法分解",功法分解);
      ObserverModuleManager.S.RegisterEvent("增加修为",增加修为);
      ObserverModuleManager.S.RegisterEvent("Show道纹image", Show道纹image);
      ObserverModuleManager.S.RegisterEvent("Show道纹弹窗", Show道纹弹窗);
      ObserverModuleManager.S.RegisterEvent("刷新装备", 刷新装备);
      ObserverModuleManager.S.RegisterEvent("刷新背包", 刷新背包);
      ObserverModuleManager.S.RegisterEvent("突破成功", 突破成功);
      轮回按钮.onClick.AddListener(() =>
      {
         轮回确认弹窗.gameObject.SetActive(true);
      });
      分解Btn.onClick.AddListener(() =>
      {
         if (显示类型 == 5)
         {
            法器仙石分解弹窗.分解类型 = 分解类型.法器;
            法器仙石分解弹窗.gameObject.SetActive(true);
         }
         if (显示类型 == 6)
         {
            法器仙石分解弹窗.分解类型 = 分解类型.仙石;
            法器仙石分解弹窗.gameObject.SetActive(true);
         }
      });
      左箭头.onClick.AddListener(() =>
      {
         if (页数Num > 1)
         {
            页数Num--;
            刷新背包();
         }
      });
      右箭头.onClick.AddListener(() =>
      {
         switch (显示类型)
         {
            case 2:
               if (页数Num < Get道纹最大页数())
               {
                  页数Num++;
                  刷新背包();
               }
               break;
            case 3:
               if (页数Num < Get功法最大页数())
               {
                  页数Num++;
                  刷新背包();
               }
               break;
            case 4:
               if (页数Num < Get灵物最大页数())
               {
                  页数Num++;
                  刷新背包();
               }
               break;
            case 5:
               if (页数Num < Get法器最大页数())
               {
                  页数Num++;
                  刷新背包();
               }
               break;
            case 6:
               if (页数Num < Get仙石最大页数())
               {
                  页数Num++;
                  刷新背包();
               }
               break;
            case 8:
               if (页数Num < Get灵药最大页数())
               {
                  页数Num++;
                  刷新背包();
               }
               break;
            case 9:
               if (页数Num < Get丹药最大页数())
               {
                  页数Num++;
                  刷新背包();
               }
               break;
         }
      });
      属性Btn.onClick.AddListener(() =>
      {
         人物属性弹窗.gameObject.SetActive(true);
      });
      突破Button.onClick.AddListener(() =>
      {
         if (PlayerData.S.Exp < JingJieConfig.升级需要年数Dic[PlayerData.S.当前轮回境界] * 200)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","当前修为不足");
            return;
         }
         
         突破弹窗.SetActive(true);
      });
      材料Btn.onClick.AddListener(() =>
      {
         显示类型 = 1;
         页数Num = 1;
         刷新背包(); 
      });
      道纹Btn.onClick.AddListener(() => { 
         显示类型 = 2;
         页数Num = 1;
         刷新背包(); 
      });
      功法Btn.onClick.AddListener(() => { 
         显示类型 = 3;
         页数Num = 1;
         刷新背包(); 
      });
      灵物Btn.onClick.AddListener(() =>
      {
         显示类型 = 4;
         页数Num = 1;
         刷新背包();
      });
      法器Btn.onClick.AddListener(() =>
      {
         显示类型 = 5;
         页数Num = 1;
         刷新背包();
      });
      仙石Btn.onClick.AddListener(() =>
      {
         显示类型 = 6;
         页数Num = 1;
         刷新背包();
      });
      神物Btn.onClick.AddListener(() =>
      {
         显示类型 = 7;
         页数Num = 1;
         刷新背包();
      });
      灵药Btn.onClick.AddListener(() =>
      {
         显示类型 = 8;
         页数Num = 1;
         刷新背包();
      });
      丹药Btn.onClick.AddListener(() =>
      {
         显示类型 = 9;
         页数Num = 1;
         刷新背包();
      });
      强化Btn.onClick.AddListener(() => { 强化弹窗.gameObject.SetActive(true); });
      ExitButton.onClick.AddListener(() => { gameObject.SetActive(false); });
   }

   public void Set经验SLider()
   {
      CurrentExp.text = ((int)PlayerData.S.Exp).ToString();
      MaxExp.text = (JingJieConfig.升级需要年数Dic[PlayerData.S.当前轮回境界]*JingJieConfig.每年基础修为).ToString();
      ExpSlider.value = PlayerData.S.Exp;
      ExpSlider.maxValue=JingJieConfig.升级需要年数Dic[PlayerData.S.当前轮回境界]*JingJieConfig.每年基础修为;
   }
   

   private void OnEnable()
   {
      显示类型 = 1;
      ShowProp();
      ShowEquip();
      Set经验SLider();
      Set境界();
   }

   public int Get道纹最大页数()
   {
      int count = 0;
      foreach (var item in 道纹config.道纹名Dic)
      {
         for (int j = (int)QualityType.天品; j <=  (int)QualityType.荒品; j++)
         {
            int v=PlayerData.S.Get道纹数量(item.Key, (QualityType)j);
            if (v > 0)
            {
               count++;
            }
         }
      }
      return Mathf.CeilToInt(count / 48f);
   }
   
   public void Show丹药()
   {
      分解Btn.gameObject.SetActive(false);
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮亮;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }
      int count = 0;
      for (int i = 8; i >= 1; i--)
      {
         foreach (var item in 丹药Config.丹药名Dic)
         {
            if (PlayerData.S.Get丹药数量(item.Key, (QualityType)i) > 0)
            {
               if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
               {
                  var baggrid = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹药Grid"), BagContent.transform)
                     .GetComponent<丹药grid>();
                  baggrid.丹药Type = item.Key;
                  baggrid.QualityType = (QualityType)i;
                  baggrid.SetItem();
               }
               count++;
            }
         }
      }
   }

   public void Show灵药()
   {
      分解Btn.gameObject.SetActive(false);
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮亮;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }
      int count = 0;
      for (int i = 8; i >= 1; i--)
      {
         foreach (var item in 丹药Config.灵药名Dic)
         {
            if (PlayerData.S.Get灵药数量(item.Key, (QualityType)i) > 0)
            {
               if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
               {
                  var baggrid = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/灵药Grid"), BagContent.transform)
                     .GetComponent<灵药grid>();
                  baggrid.灵药Type = item.Key;
                  baggrid.QualityType = (QualityType)i;
                  baggrid.SetItem();
               }
               count++;
            }
         }
      }
   }
   public void Show道纹()
   {
      分解Btn.gameObject.SetActive(false);
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮亮;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;

      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      int count = 0;
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.荒品)>0)
         {
            if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
            {
               var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
               baggrid.道纹Type = item.Key;
               baggrid.QualityType = QualityType.荒品;
               baggrid.SetItem();
            }
            count++;
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.洪品)>0)
         {
            if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
            {
               var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
               baggrid.道纹Type = item.Key;
               baggrid.QualityType = QualityType.洪品;
               baggrid.SetItem();
            }
            count++;
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.宙品)>0)
         {
            if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
            {
               var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
               baggrid.道纹Type = item.Key;
               baggrid.QualityType = QualityType.宙品;
               baggrid.SetItem();
            }
            count++;
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.宇品)>0)
         {
            if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
            {
               var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
               baggrid.道纹Type = item.Key;
               baggrid.QualityType = QualityType.宇品;
               baggrid.SetItem();
            }
            count++;
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.天品)>0)
         {
            if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
            {
               var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
               baggrid.道纹Type = item.Key;
               baggrid.QualityType = QualityType.天品;
               baggrid.SetItem();
            }
            count++;
         }
      }
   }

   public void 刷新背包()
   {
      页数.text = 页数Num.ToString();
      switch (显示类型)
      {
         case 1:
            ShowProp();
            break;
         case 2:
            Show道纹();
            break;
         case 3:
            Show功法();
            break;
         case 4:
            Show灵物();
            break;
         case 5:
            Show法器();
            break;
         case 6:
            Show仙石();
            break;
         case 7:
            Show神物();
            break;
         case 8:
            Show灵药();
            break;
         case 9:
            Show丹药();
            break;
      }
   }
   public int Get灵药最大页数()
   {
      int count = 0;
      foreach (var item in 丹药Config.灵药名Dic)
      {
         for (int i = 1; i <= 8; i++)
         {
            if (PlayerData.S.Get灵药数量(item.Key, (QualityType)i) > 0)
            {
               count++;
            }
         }
      }
      return Mathf.CeilToInt(count / 48f);
   }
   
   public int Get丹药最大页数()
   {
      int count = 0;
      foreach (var item in 丹药Config.丹药名Dic)
      {
         for (int i = 1; i <= 8; i++)
         {
            if (PlayerData.S.Get丹药数量(item.Key, (QualityType)i) > 0)
            {
               count++;
            }
         }
      }
      return Mathf.CeilToInt(count / 48f);
   }

   public int Get功法最大页数()
   {
      int count = 0;
      foreach (var item in PlayerData.S.功法数量Dic)
      {
         if (item.Value > 0)
         {
            count++;
         }
      }
      return Mathf.CeilToInt(count / 48f);
   }
   public void Show功法()
   {
      分解Btn.gameObject.SetActive(false);
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      功法Btn.image.sprite = ResourcesConfig.按钮亮;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      int count = 0;
      foreach (var item in PlayerData.S.功法数量Dic)
      {
         if (item.Value > 0)
         {
            if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
            {
               var baggrid = Instantiate(Resources.Load("Prefabs/Window/功法Grid"), BagContent.transform).GetComponent<功法Grid>();
               baggrid.功法Type = item.Key;
               baggrid.SetItem();
            }
            count++;
         }
      }
   }
   public void ShowProp()
   {
      分解Btn.gameObject.SetActive(false);
      材料Btn.image.sprite = ResourcesConfig.按钮亮;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      // 收集道具和丹方，按品质降序排序
      var itemList = new List<(int quality, bool is丹方, PropType propType, 丹药Type 丹药Type, QualityType 丹方Quality)>();

      foreach (var item in PlayerData.S.PropListDic)
      {
         if (item.Value > 0)
         {
            itemList.Add(((int)PropConfig.PropQualityDic[item.Key], false, item.Key, 0, QualityType.None));
         }
      }

      foreach (var item in PlayerData.S.丹方Dic)
      {
         if (item.Value > 0)
         {
            var parts = item.Key.Split('_');
            if (parts.Length == 2 && Enum.TryParse(parts[0], out 丹药Type 丹药type) && Enum.TryParse(parts[1], out QualityType quality))
            {
               itemList.Add(((int)quality, true, PropType.None, 丹药type, quality));
            }
         }
      }

      itemList.Sort((a, b) => b.quality.CompareTo(a.quality));

      int startIndex = (页数Num - 1) * 48;
      int endIndex = Mathf.Min(页数Num * 48, itemList.Count);
      for (int i = startIndex; i < endIndex; i++)
      {
         var entry = itemList[i];
         if (entry.is丹方)
         {
            var 丹方grid = Instantiate(Resources.Load("Prefabs/Window/炼丹界面/丹方Grid"), BagContent.transform).GetComponent<丹方Grid>();
            丹方grid.丹药Type = entry.丹药Type;
            丹方grid.QualityType = entry.丹方Quality;
            丹方grid.SetItem();
         }
         else
         {
            var baggrid = Instantiate(Resources.Load("Prefabs/Window/BagGrid"), BagContent.transform).GetComponent<BagGrid>();
            baggrid.propType = entry.propType;
            baggrid.SetItem();
         }
      }
   }
   public int Get灵物最大页数()
   {
      int count = 0;
      for (int j = (int)QualityType.荒品; j >= (int)QualityType.黄品; j--)
      {
         for (int i = (int)JingJieType.混元圣人; i >= (int)JingJieType.练气; i--)
         {
            if (PlayerData.S.Get灵物数量((JingJieType)i, (QualityType)j) > 0)
            {
               count++;
            }
         }
      }
      return Mathf.CeilToInt(count / 48f);
   }
   public void Show灵物()
   {
      分解Btn.gameObject.SetActive(false);
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮亮;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      int count = 0;
      
         for (int j = (int)QualityType.荒品; j >= (int)QualityType.黄品; j--)
         {
            for (int i = (int)JingJieType.混元圣人; i >= (int)JingJieType.练气; i--)
            {
               if (PlayerData.S.Get灵物数量((JingJieType)i, (QualityType)j) > 0)
               {
                  if (count >= (页数Num - 1) * 48 && count <= 页数Num * 48)
                  {
                     var 灵物grid=Instantiate(Resources.Load("Prefabs/Window/灵物Grid"), BagContent.transform).GetComponent<灵物Grid>();
                     灵物grid.JingJieType = (JingJieType)i;
                     灵物grid.QualityType = (QualityType)j;
                     灵物grid.SetItem();
                  }
                  count++;
               }
            }
         }
      
   }
   
   public int Get仙石最大页数()
   {
      int count = 0;
      
      return Mathf.CeilToInt(PlayerData.S.仙石列表.Count / 48f);
   }
   public int Get法器最大页数()
   {
      int count = 0;
      
      return Mathf.CeilToInt(PlayerData.S.法器列表.Count / 48f);
   }
   public void Show仙石()
   {
      分解Btn.gameObject.SetActive(true);
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      仙石Btn.image.sprite = ResourcesConfig.按钮亮;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      for (int i = 48 * (页数Num - 1); i < Math.Min(页数Num * 48, PlayerData.S.仙石列表.Count); i++)
      {
         var 仙石item = Instantiate(Resources.Load("Prefabs/Window/仙石Grid"), BagContent.transform).GetComponent<仙石Grid>();
         仙石item.仙石 = PlayerData.S.仙石列表[i];
         仙石item.SetItem();
      }
   }
   
   public void Show法器()
   {
      分解Btn.gameObject.SetActive(true);
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮亮;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮暗;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      for (int i = 48 * (页数Num - 1); i < Math.Min(页数Num * 48, PlayerData.S.法器列表.Count); i++)
      {
         var 法器item = Instantiate(Resources.Load("Prefabs/Window/法器Grid"), BagContent.transform).GetComponent<法器Grid>();
         法器item.法器 = PlayerData.S.法器列表[i];
         法器item.SetItem();
      }
   }
   
   
   public void Show神物()
   {
      分解Btn.gameObject.SetActive(false);
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;
      神物Btn.image.sprite = ResourcesConfig.按钮亮;
      灵药Btn.image.sprite = ResourcesConfig.按钮暗;
      丹药Btn.image.sprite = ResourcesConfig.按钮暗;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in PlayerData.S.神物获得Dic)
      {
         if (item.Value)
         {
            var 神物item = Instantiate(Resources.Load("Prefabs/Window/远古遗迹/神物Grid"), BagContent.transform).GetComponent<神物Grid>();
            神物item.type = item.Key;
            神物item.SetItem();
         }
      }
   }


   public void ShowEquip()
   {
      foreach (Transform item in EquipContent.transform)
      {
         Destroy(item.gameObject);
      }

      var 衣服 = Instantiate(Resources.Load("Prefabs/Window/装备item"), EquipContent.transform).GetComponent<装备item>();
      衣服.EquipType = EquipType.衣服;
      衣服.SetItem();
      
      var 鞋子 = Instantiate(Resources.Load("Prefabs/Window/装备item"), EquipContent.transform).GetComponent<装备item>();
      鞋子.EquipType = EquipType.鞋子;
      鞋子.SetItem();
      
      var 头盔 = Instantiate(Resources.Load("Prefabs/Window/装备item"), EquipContent.transform).GetComponent<装备item>();
      头盔.EquipType = EquipType.头盔;
      头盔.SetItem();
      
      var 戒指 = Instantiate(Resources.Load("Prefabs/Window/装备item"), EquipContent.transform).GetComponent<装备item>();
      戒指.EquipType = EquipType.戒指;
      戒指.SetItem();
      
      var 项链 = Instantiate(Resources.Load("Prefabs/Window/装备item"), EquipContent.transform).GetComponent<装备item>();
      项链.EquipType = EquipType.项链;
      项链.SetItem();
      
      var 护手 = Instantiate(Resources.Load("Prefabs/Window/装备item"), EquipContent.transform).GetComponent<装备item>();
      护手.EquipType = EquipType.护手;
      护手.SetItem();
   }
}
