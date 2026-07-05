using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 道纹弹窗 : MonoBehaviour
{
   [NonSerialized]public EquipType equipType;
   public GameObject content;
   public Button ExitButton;

   private void Start()
   {
      ExitButton.onClick.AddListener(() =>
      {
         gameObject.SetActive(false);
      });
   }

   private void OnEnable()
   {
      foreach (Transform child in content.transform)
      {
         Destroy(child.gameObject);
      }
      List<道纹> list = null;
      switch (equipType)
      {
         case EquipType.头盔:
            list = PlayerData.S.装备道纹List[EquipType.头盔];
            break;
         case EquipType.护手:
            list = PlayerData.S.装备道纹List[EquipType.护手];
            break;
         case EquipType.戒指:
            list = PlayerData.S.装备道纹List[EquipType.戒指];
            break;
         case EquipType.项链:
            list = PlayerData.S.装备道纹List[EquipType.项链];
            break;
         case EquipType.衣服:
            list = PlayerData.S.装备道纹List[EquipType.衣服];
            break;
         case EquipType.鞋子:
            list = PlayerData.S.装备道纹List[EquipType.鞋子];
            break;
      }

      QualityType qualityType = QualityType.天品;
      foreach (var item in list)
      {
         QualityType equipquaType = EquipConfig.GetEquipQuality(equipType);
         var 道纹item = Instantiate(Resources.Load("Prefabs/Window/道纹item"),content.transform).GetComponent<道纹item>();
         道纹item.Is解锁 = equipquaType>=qualityType;
         道纹item.equipType = equipType;
         道纹item.道纹Type=item.道纹Type;
         道纹item.道纹QualityType = item.quality;
         道纹item.解锁境界=qualityType;
         道纹item.SetItem();
         qualityType++;
      }
   }
}
