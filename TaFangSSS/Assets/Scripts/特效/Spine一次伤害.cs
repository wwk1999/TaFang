using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine;
using Spine.Unity;
using UnityEngine;

public class Spine一次伤害 : MonoBehaviour
{
   public string name;
   public SkeletonAnimation Skeleton;
   public 攻击特效Type type;
   public Collider2D _collider2D;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   [NonSerialized] public float damage;
   [NonSerialized] public YuanSuType YuanSuType;
   private Vector2 原始scale=Vector2.one;
   
   


   private void OnEnable()
   {
      transform.localScale=new Vector3(原始scale.x*英雄星级属性.鸿钧效果范围,原始scale.y*英雄星级属性.鸿钧效果范围,1);
      Skeleton.AnimationState.TimeScale = 1.3f;
      Skeleton.AnimationState.SetAnimation(0, name,false);
   }

   private void Start()
   {
      Skeleton.AnimationState.Complete += Complete;
      Skeleton.AnimationState.Event += OnSpineEvent;
   }
   public void Complete(TrackEntry trackEntry)
   {
      switch (type)
      {
         case 攻击特效Type.陨石:
            QueueController.S.陨石Queue.Enqueue(this);
            break;
      }
      gameObject.SetActive(false);
   }
    
   private void OnSpineEvent(TrackEntry trackEntry, Spine.Event e)
   {
      if (e.Data.Name == "damage")
      {
         CheckCollisionWithMonsters();
      }
   }
   
   
   public void CheckCollisionWithMonsters()
   {
      // 检测所有重叠的碰撞体
      List<Collider2D> results = new List<Collider2D>();
      ContactFilter2D filter = new ContactFilter2D();
      filter.NoFilter();
      filter.useTriggers = true;
    
      _collider2D.OverlapCollider(filter, results);
    
      // 找出所有怪物并处理
      foreach (Collider2D col in results)
      {
         if (col.gameObject == gameObject) continue;
        
         if (col.CompareTag("Monster"))
         {
            if (瑶池冰辅助)
            {
               FightController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
            }
            if (黑暗辅助)
            {
               damage *= (1+英雄星级属性.妲己效果/100f);
            }
            FightController.S.MonsterColliderDic[col].Hurt(damage,YuanSuType);
         }
      }
   }

}
