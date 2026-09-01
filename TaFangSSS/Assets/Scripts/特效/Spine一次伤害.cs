using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine;  
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spine一次伤害 : MonoBehaviour
{
   public string name;
   public SkeletonAnimation Skeleton;
   public 攻击特效Type type;
   public Collider2D _collider2D;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   [NonSerialized] public bool 妲己神通;

   [NonSerialized] public float damage;
   [NonSerialized] public HeroType HeroType;

   private Vector2 原始scale=Vector2.one;
   [NonSerialized] public bool 女娲电辅助;
   [NonSerialized] public bool 瑶池神通;

   


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
         ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.鸿钧);
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
               if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
               {
                  damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                     功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                     100f);
               }
               QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
            }
            if (瑶池神通)
            {
               var random = Random.Range(0, 100f);
               if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
               {
                  QueueController.S.MonsterColliderDic[col].冰冻time = 1;
               }
            }
            if (黑暗辅助)
            {
               if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
               {
                  damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                     功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                     100f);
               }
               damage *= (1+英雄星级属性.妲己效果/100f);
            }
            QueueController.S.MonsterColliderDic[col].妲己神通 = 妲己神通;
            QueueController.S.MonsterColliderDic[col].妲己黑暗辅助 = 黑暗辅助;
            if (女娲电辅助)
            {
               if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
               {
                  damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                     功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                     100f);
               }
               damage*=(1+英雄星级属性.女娲辅助伤害/100f);
            }
            QueueController.S.MonsterColliderDic[col].女娲电辅助 = 女娲电辅助;

            if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
            {
               damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
            }
            QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
         }
      }
   }

}
