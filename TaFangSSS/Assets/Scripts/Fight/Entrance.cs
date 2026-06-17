using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class Entrance : MonoBehaviour
{
   public GameObject 人物Parent;
   public void InitRenWu()
   {
      int index = 1;
      foreach (var item in PlayerData.S.出战英雄List[PlayerData.S.CurrentBianDui-1])
      {
         if (item == HeroType.None)
         {
            continue;
         }
         var renwu = Instantiate(Resources.Load("Prefabs/Fight/人物Item"),人物Parent.transform).GetComponent<人物item>();
         renwu.heroType = item;
         renwu.SetItem();
         renwu.transform.localPosition = FightConfig.人物位置Dic[index];
         index++;
      }
   }

   private void Awake()
   {
      FightController.S.Init怪物死亡Queue();
      FightController.S.InitHeroSkill();
      InitRenWu();
   }
}
