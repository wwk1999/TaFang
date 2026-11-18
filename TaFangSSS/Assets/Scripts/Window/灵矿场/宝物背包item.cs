using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 宝物背包item : MonoBehaviour
{
   public Button bg;
   public TextMeshProUGUI name;
   public Image icon;
   public TextMeshProUGUI count;
   public GameObject 选中;
   [NonSerialized] public 宝物Type 宝物Type;
   [NonSerialized] public QualityType QualityType;

   public void SetItem()
   {
      选中.gameObject.SetActive(false);
      bg.image.sprite = ResourcesConfig.Get灵植背包格子(QualityType);
      name.text = 灵矿场Config.宝物名[宝物Type];
      icon.sprite = ResourcesConfig.Get宝物Sprite(宝物Type);
      count.text = PlayerData.S.Get宝物数量(宝物Type, QualityType).ToString();
   }

   public void 宝物背包item点击(object[] obj)
   {
      宝物Type 宝物Type1 = (宝物Type)obj[0];
      QualityType QualityType1= (QualityType)obj[1];
      选中.gameObject.SetActive(宝物Type==宝物Type1&&QualityType==QualityType1);
   }

   private void OnDestroy()
   {
      ObserverModuleManager.S.UnRegisterEvent("宝物背包item点击",宝物背包item点击);
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("宝物背包item点击",宝物背包item点击);
      bg.onClick.AddListener(() =>
      {
         ObserverModuleManager.S.SendEvent("宝物背包item点击",宝物Type, QualityType);
      });
   }
}
