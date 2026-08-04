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
   public TextMeshProUGUI  Name;
   public TextMeshProUGUI  跟脚;
   public TextMeshProUGUI 境界Name;
   public TextMeshProUGUI CurrentExp;
   public TextMeshProUGUI MaxExp;
   public Slider ExpSlider;
   public GameObject 突破弹窗;
   private bool IsProp = true;
   public GameObject 强化弹窗;
   public GameObject 人物属性弹窗;
   public Button 属性Btn;

   public void Set境界()
   {
      if (PlayerData.S.Exp >= JingJieConfig.升级需要年数Dic[PlayerData.S.JingJieType] * 200)
      {
         突破Button.gameObject.SetActive(true);
      }
      else
      {
         突破Button.gameObject.SetActive(false);
      }
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

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("增加修为",增加修为);
      ObserverModuleManager.S.UnRegisterEvent("Show道纹image", Show道纹image);
      ObserverModuleManager.S.UnRegisterEvent("Show道纹弹窗", Show道纹弹窗);
      ObserverModuleManager.S.UnRegisterEvent("刷新装备", 刷新装备);
      ObserverModuleManager.S.UnRegisterEvent("突破成功", 突破成功);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("增加修为",增加修为);
      ObserverModuleManager.S.RegisterEvent("Show道纹image", Show道纹image);
      ObserverModuleManager.S.RegisterEvent("Show道纹弹窗", Show道纹弹窗);
      ObserverModuleManager.S.RegisterEvent("刷新装备", 刷新装备);
      ObserverModuleManager.S.RegisterEvent("突破成功", 突破成功);
      属性Btn.onClick.AddListener(() =>
      {
         人物属性弹窗.gameObject.SetActive(true);
      });
      突破Button.onClick.AddListener(() =>
      {
         突破弹窗.SetActive(true);
      });
      材料Btn.onClick.AddListener(() =>
      {
         IsProp = true;
         刷新背包(); 
      });
      道纹Btn.onClick.AddListener(() => { 
         IsProp = false;
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
      IsProp = true;
      ShowProp();
      ShowEquip();
      Set经验SLider();
      Set境界();
   }
   
   public void Show道纹()
   {
      材料Btn.image.sprite = ResourcesConfig.按钮暗;
      道纹Btn.image.sprite = ResourcesConfig.按钮亮;
      foreach (Transform item in BagContent.transform)
      {
         Destroy(item.gameObject);
      }

      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.荒品)>0)
         {
            var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
            baggrid.道纹Type = item.Key;
            baggrid.QualityType = QualityType.荒品;
            baggrid.SetItem();
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.洪品)>0)
         {
            var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
            baggrid.道纹Type = item.Key;
            baggrid.QualityType = QualityType.洪品;
            baggrid.SetItem();
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.宙品)>0)
         {
            var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
            baggrid.道纹Type = item.Key;
            baggrid.QualityType = QualityType.宙品;
            baggrid.SetItem();
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.宇品)>0)
         {
            var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
            baggrid.道纹Type = item.Key;
            baggrid.QualityType = QualityType.宇品;
            baggrid.SetItem();
         }
      }
      
      foreach (var item in 道纹config.道纹名Dic)
      {
         if (PlayerData.S.Get道纹数量(item.Key,QualityType.天品)>0)
         {
            var baggrid = Instantiate(Resources.Load("Prefabs/Window/道纹Grid"), BagContent.transform).GetComponent<道纹grid>();
            baggrid.道纹Type = item.Key;
            baggrid.QualityType = QualityType.天品;
            baggrid.SetItem();
         }
      }
   }

   public void 刷新背包()
   {
      if (IsProp)
      {
         ShowProp();
      }
      else
      {
         Show道纹();
      }
   }

   public void ShowProp()
   {
      材料Btn.image.sprite = ResourcesConfig.按钮亮;
      道纹Btn.image.sprite = ResourcesConfig.按钮暗;
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
