using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Unity.VisualScripting;
using UnityEngine;

public class Entrance : MonoBehaviour
{
   public GameObject 人物Parent;
   public Animator 围栏Animator;

   public void 围栏受击(object[] obj)
   {
      float damage = (float)obj[0];
      float y=(float)obj[1];
      围栏Animator.Play("围栏受击",0,0);
      FightController.S.Show伤害数字(damage,YuanSuType.物理,new Vector2(-5,y));
   }

   private void Start()
   {
      ObserverModuleManager.S.RegisterEvent("围栏受击",围栏受击);
   }

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
      InitRenWu();
   }
}
