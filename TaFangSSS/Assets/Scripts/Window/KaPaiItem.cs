using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KaPaiItem : MonoBehaviour,IPointerDownHandler
{
   [NonSerialized]public HeroType heroType;
   public GameObject 功法;
   public GameObject 功法xx1;
   public GameObject 功法xx2;
   public GameObject 功法xx3;
   public GameObject 功法xx4;
   public GameObject 功法xx5;
   public TextMeshProUGUI 功法Name;
   public Image 功法bg;
   public Image 功法icon;
   public TextMeshProUGUI 功法level;

   
   public GameObject xx1;
   public GameObject xx2;
   public GameObject xx3;
   public GameObject xx4;
   public GameObject xx5;
   public Button bg;
   public GameObject 出战icon;
   public Image 职业icon;
   public Image image;
   public TextMeshProUGUI Name;
   public Slider Exp;
   public TextMeshProUGUI CurrentExp;
   public TextMeshProUGUI MaxExp;
   public GameObject 合成Obj;
   public Button 合成mask;
   public GameObject 升级Obj;
   public GameObject ActiveMask;
   [NonSerialized] public bool IsSend = false;

   [NonSerialized]public Vector3 MousePos;
   [NonSerialized] public float 进度条当前时间=0;
   [NonSerialized] public float 进度条显示时间=0.2f;
   [NonSerialized] public float 进度条总时间=0.2f;

   public Image 圆环;
   
   
   public void OnPointerDown(PointerEventData eventData)
   {
      MousePos=Input.mousePosition;
   }

   IEnumerator DelaySetJiaoHuan()
   {
      yield return null;
      HeroWindowController.S.DragHero = HeroType.None;
      HeroWindowController.S.IsJiaoHuan=false;
   }

   private void Update()
   {
      if (Input.GetMouseButton(0)&&Input.mousePosition==MousePos)
      {
         进度条当前时间+=Time.deltaTime;
         圆环.fillAmount = (进度条当前时间-进度条显示时间) / 进度条总时间;
      }
      else
      {
         IsSend=false;
         进度条当前时间 = 0;
      }

      if (Input.GetMouseButtonUp(0))
      {
         HeroWindowController.S.IsDrag=false;
         StartCoroutine(DelaySetJiaoHuan());      
      }

      if (进度条当前时间 == 0||进度条当前时间>进度条显示时间+进度条总时间)
      {
         圆环.gameObject.SetActive(false);
      }
      else
      {
         圆环.gameObject.SetActive(true);
      }

      if (进度条当前时间 > 进度条显示时间 + 进度条总时间 && !IsSend)
      {
         HeroWindowController.S.IsDrag=true;
         HeroWindowController.S.DragHero = heroType;
         IsSend = true;
      }
   }
   private void Start()
   {
      bg.onClick.AddListener(() =>
      {
         ObserverModuleManager.S.SendEvent("英雄详情弹窗",heroType);
      });
      合成mask.onClick.AddListener(() =>
      {
         PlayerData.S.HeroDataDic[heroType].元神 -= 1;
         PlayerData.S.HeroDataDic[heroType].Level = 1;
         SetItem();
      });
      
   }

   public void SetItem()
   {
      功法Type 功法Type = PlayerData.S.HeroDataDic[heroType].功法Type;
      if (功法Type == 功法Type.None)
      {
         功法.gameObject.SetActive(false);
      }
      else
      {
         功法.gameObject.SetActive(true);
         int 功法等级 = PlayerData.S.HeroDataDic[heroType].功法等级;
         int 功法星级 = PlayerData.S.HeroDataDic[heroType].功法星级;
         QualityType 功法品质 = 功法Config.功法TypeQualityDic[功法Type];
         功法xx1.gameObject.SetActive(功法星级>=1);
         功法xx2.gameObject.SetActive(功法星级>=2);
         功法xx3.gameObject.SetActive(功法星级>=3);
         功法xx4.gameObject.SetActive(功法星级>=4);
         功法xx5.gameObject.SetActive(功法星级>=5);
         功法bg.sprite = ResourcesConfig.Get道具背景框SpriteByQuality(功法品质);
         功法icon.sprite = ResourcesConfig.Get功法Sprite(功法Type);
         功法Name.text = 功法Config.功法名Dic[功法Type];
         功法Name.colorGradientPreset = ResourcesConfig.Get品质TMP(功法品质);
         功法level.text = 功法等级.ToString();
      }


      xx1.gameObject.SetActive(PlayerData.S.HeroDataDic[heroType].Level>=2);
      xx2.gameObject.SetActive(PlayerData.S.HeroDataDic[heroType].Level>=3);
      xx3.gameObject.SetActive(PlayerData.S.HeroDataDic[heroType].Level>=4);
      xx4.gameObject.SetActive(PlayerData.S.HeroDataDic[heroType].Level>=5);
      xx5.gameObject.SetActive(PlayerData.S.HeroDataDic[heroType].Level>=6);
      int level = PlayerData.S.HeroDataDic[heroType].Level;
      int exp = PlayerData.S.HeroDataDic[heroType].元神;
      Exp.maxValue = HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[heroType], PlayerData.S.HeroDataDic[heroType].Level-1).元神;
      Exp.value = exp;
      CurrentExp.text=exp.ToString();
      MaxExp.text=HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[heroType], PlayerData.S.HeroDataDic[heroType].Level-1).元神.ToString();
      image.sprite=ResourcesConfig.GetHeroSprite(heroType);
      Name.text=HeroConfig.HeroNameDic[heroType];
      
      if (level<6&&level > 0 && exp >= HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[heroType], PlayerData.S.HeroDataDic[heroType].Level-1).元神)
      {
         升级Obj.SetActive(true);    
      }
      else
      {
         升级Obj.SetActive(false);
      }
      if (level == 0 && exp >= HeroConfig.Get升星材料(HeroConfig.HeroQualityDic[heroType], PlayerData.S.HeroDataDic[heroType].Level-1).元神)
      {
         合成Obj.gameObject.SetActive(true);
      }
      else
      {
         合成Obj.gameObject.SetActive(false);
      }

      if (level == 0)
      {
         ActiveMask.SetActive(true);
      }
      else
      {
         ActiveMask.SetActive(false);
      }
      出战icon.gameObject.SetActive(false);
      foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.当前出战编队-1])
      {
         if (item == heroType)
         {
            出战icon.gameObject.SetActive(true);
         }
      }

      bg.image.sprite = ResourcesConfig.Get道具背景框SpriteByPropType(HeroConfig.HeroQualityDic[heroType]);
      

      职业icon.sprite = ResourcesConfig.Get职业icon(HeroConfig.HeroZhiYeDic[heroType].zhiYeType);
   }
}
