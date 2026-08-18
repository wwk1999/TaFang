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

   public TextMeshProUGUI  Name;
   public TextMeshProUGUI  跟脚;
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
      头像框Icon.sprite = ResourcesConfig.Get境界Icon(PlayerData.S.JingJieType);
      头像框Icon.SetNativeSize();
   }
   public void Set境界()
   {
      Set头像框();
      修炼速度count.text = 属性config.总修炼速度加成 + "%";
      跟脚.text = MathF.Round(JingJieConfig.跟脚,2).ToString();
      境界Name.text=JingJieConfig.JingJieNameDic[PlayerData.S.JingJieType];
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
      ObserverModuleManager.S.UnRegisterEvent("显示确认分解弹窗",显示确认分解弹窗);
      ObserverModuleManager.S.UnRegisterEvent("刷新背包", 刷新背包);
      ObserverModuleManager.S.UnRegisterEvent("增加修为",增加修为);
      ObserverModuleManager.S.UnRegisterEvent("Show道纹image", Show道纹image);
      ObserverModuleManager.S.UnRegisterEvent("Show道纹弹窗", Show道纹弹窗);
      ObserverModuleManager.S.UnRegisterEvent("刷新装备", 刷新装备);
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
   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("显示确认分解弹窗",显示确认分解弹窗);
      ObserverModuleManager.S.RegisterEvent("功法分解",功法分解);
      ObserverModuleManager.S.RegisterEvent("增加修为",增加修为);
      ObserverModuleManager.S.RegisterEvent("Show道纹image", Show道纹image);
      ObserverModuleManager.S.RegisterEvent("Show道纹弹窗", Show道纹弹窗);
      ObserverModuleManager.S.RegisterEvent("刷新装备", 刷新装备);
      ObserverModuleManager.S.RegisterEvent("刷新背包", 刷新背包);
      ObserverModuleManager.S.RegisterEvent("突破成功", 突破成功);
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
         }
      });
      属性Btn.onClick.AddListener(() =>
      {
         人物属性弹窗.gameObject.SetActive(true);
      });
      突破Button.onClick.AddListener(() =>
      {
         if (PlayerData.S.Exp < JingJieConfig.升级需要年数Dic[PlayerData.S.JingJieType] * 200)
         {
            ObserverModuleManager.S.SendEvent("SendUIToast","当前经验不足");
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
      强化Btn.onClick.AddListener(() => { 强化弹窗.gameObject.SetActive(true); });
      ExitButton.onClick.AddListener(() => { gameObject.SetActive(false); });
   }

   public void Set经验SLider()
   {
      CurrentExp.text = ((int)PlayerData.S.Exp).ToString();
      MaxExp.text = (JingJieConfig.升级需要年数Dic[PlayerData.S.JingJieType]*JingJieConfig.每年基础修为).ToString();
      ExpSlider.value = PlayerData.S.Exp;
      ExpSlider.maxValue=JingJieConfig.升级需要年数Dic[PlayerData.S.JingJieType]*JingJieConfig.每年基础修为;
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
   public void Show道纹()
   {
      分解Btn.gameObject.SetActive(false);
      功法Btn.image.sprite = ResourcesConfig.按钮暗;
      灵物Btn.image.sprite = ResourcesConfig.按钮暗;
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      法器Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮亮;
      仙石Btn.image.sprite = ResourcesConfig.按钮暗;

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
      }
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

      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }
      foreach (var item in PlayerData.S.PropListDic)
      {
         if (item.Value > 0)
         {
            var baggrid = Instantiate(Resources.Load("Prefabs/Window/BagGrid"), BagContent.transform).GetComponent<BagGrid>();
            baggrid.propType = item.Key;
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
