using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class 附加属性item : MonoBehaviour
{
   public Image bg;
   public TextMeshProUGUI labeltext;
   public TextMeshProUGUI info;
   public Button Suo;
   public GameObject mask;
   public TextMeshProUGUI 无暇text;
   public TextMeshProUGUI masktext;
   [NonSerialized]public QualityType JieSuoQualityType;
   [NonSerialized]public EquipType EquipType;
   [NonSerialized] public bool IsQiangHua;

   private void Start()
   {
      Suo.onClick.AddListener(() =>
      {
         bool issuo = PlayerData.S.装备附加属性Dic[EquipType][(int)(JieSuoQualityType - 2)].IsSuo;
         PlayerData.S.装备附加属性Dic[EquipType][(int)(JieSuoQualityType - 2)].IsSuo=!issuo;
         SetItem();
         ObserverModuleManager.S.SendEvent("刷新材料");
      });
   }

   public void SetItem()
   {
      if (EquipConfig.GetEquipQuality(EquipType) < JieSuoQualityType)
      {
         mask.SetActive(true);
         masktext.text = PropConfig.QualityNameDic[JieSuoQualityType] + "解锁";
      }
      else
      {
         附加属性Type 附加属性Type = PlayerData.S.装备附加属性Dic[EquipType][(int)(JieSuoQualityType - 2)].附加属性Type;
         QualityType QualityType= PlayerData.S.装备附加属性Dic[EquipType][(int)(JieSuoQualityType - 2)].QualityType;
         bool 无暇 = PlayerData.S.装备附加属性Dic[EquipType][(int)(JieSuoQualityType - 2)].无暇;
         无暇text.gameObject.SetActive(无暇);
         无暇text.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
         mask.SetActive(false);
         bg.sprite = ResourcesConfig.Get标签背景(QualityType);
         labeltext.colorGradientPreset = ResourcesConfig.Get品质TMP(QualityType);
         labeltext.text=PropConfig.QualityNameDic[QualityType];
         info.text = EquipConfig.附加属性NameDic[附加属性Type] + "+" + PlayerData.S.装备附加属性Dic[EquipType][(int)(JieSuoQualityType - 2)].count.ToString("F1")+"%";
         if (IsQiangHua)
         {
            Suo.gameObject.SetActive(false);
         }
         else
         {
            Suo.gameObject.SetActive(true);
            bool issuo = PlayerData.S.装备附加属性Dic[EquipType][(int)(JieSuoQualityType - 2)].IsSuo;
            if (!issuo)
            {
               Suo.image.sprite = ResourcesConfig.解锁;
            }
            else
            {
               Suo.image.sprite = ResourcesConfig.锁;
            }
         }
      }
   }
}
