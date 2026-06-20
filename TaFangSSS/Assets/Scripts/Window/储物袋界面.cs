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
   public Button ExitButton;
   public GameObject EquipContent;
   public GameObject BagContent;
   public Button 强化Btn;
   public Button 幻化Btn;
   public Button 神通Btn;
   public Button 灵宝Btn;
   public Button 材料Btn;
   public Button 道纹Btn;
   public Button 分类Btn;
   public Button 合成Btn;
   public TextMeshProUGUI  Name;
   public TextMeshProUGUI 境界Name;
   public TextMeshProUGUI CurrentExp;
   public TextMeshProUGUI MaxExp;
   public Slider ExpSlider;
   public Button 提升修为Button;
   public TextMeshProUGUI 提升修为Text;
   public GameObject 突破弹窗;
   private bool IsProp = true;

   public void Set境界()
   {
      境界Name.text="境界："+JingJieConfig.JingJieNameDic[PlayerData.S.JingJieType];
   }
   public void 突破成功(object[] obj)
   {
      Set经验SLider();
      Set提升修为();
      Set境界();
   }
   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("突破成功",突破成功);
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
      提升修为Button.onClick.AddListener(() =>
      {
         if (PlayerData.S.Exp >= JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType])
         {
            突破弹窗.gameObject.SetActive(true);
         }
         else
         {
            int cha = JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType] - PlayerData.S.Exp;
            if (PlayerData.S.PropListDic[PropType.领主经验值] >= cha)
            {
               PlayerData.S.PropListDic[PropType.领主经验值] -= cha;
               PlayerData.S.Exp += cha;
            }
            else
            {
               PlayerData.S.Exp += PlayerData.S.PropListDic[PropType.领主经验值];
               PlayerData.S.PropListDic[PropType.领主经验值] = 0;
            }

            if (IsProp)
            {
               ShowProp();
            }
         }

         Set经验SLider();
         Set提升修为();
      });
   }

   public void Set经验SLider()
   {
      CurrentExp.text = PlayerData.S.Exp.ToString();
      MaxExp.text = JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType].ToString();
      ExpSlider.value = PlayerData.S.Exp;
      ExpSlider.maxValue=JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType];
   }

   public void Set提升修为()
   {
      提升修为Button.interactable = PlayerData.S.PropListDic[PropType.领主经验值] > 0;
      if (PlayerData.S.Exp >= JingJieConfig.JingJieExpDic[PlayerData.S.JingJieType])
      {
         提升修为Text.text = "突破";
      }
      else
      {
         提升修为Text.text = "提升修为";
      }
   }

   private void OnEnable()
   {
      IsProp = true;
      ShowProp();
      ShowEquip();
      Set提升修为();
      Set经验SLider();
      Set境界();
   }

   public void ShowProp()
   {
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
