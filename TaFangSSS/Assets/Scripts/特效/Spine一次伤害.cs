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
   [NonSerialized] public bool 女娲神通;

   [NonSerialized] public float damage;
   [NonSerialized] public HeroType HeroType;

   private Vector2 原始scale=Vector2.one;
   [NonSerialized] public bool 女娲电辅助;
   [NonSerialized] public bool 瑶池神通;

   // 碰撞查询复用缓冲：每个池化实例一份，首次使用时分配，之后零 GC
   private readonly List<Collider2D> _resultsBuffer = new List<Collider2D>(128);
   private static ContactFilter2D _monsterFilter;
   private static bool _filterInited;

   private static void InitFilter()
   {
      if (_filterInited) return;
      _monsterFilter = new ContactFilter2D();
      _monsterFilter.useTriggers = true;
      int monsterLayer = LayerMask.NameToLayer("Monster");
      _monsterFilter.SetLayerMask(new LayerMask { value = 1 << monsterLayer });
      _filterInited = true;
   }


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
      if (_collider2D == null) return;
      InitFilter();

      _resultsBuffer.Clear();
      _collider2D.OverlapCollider(_monsterFilter, _resultsBuffer);
      if (_resultsBuffer.Count == 0) return;

      // ---- 循环外：与具体怪物无关的伤害加成只算一次（不写回 damage 字段，避免多怪物滚雪球） ----
      float finalDamage = damage;
      // 辅助功法加成已移入 MonsterBase.计算功法伤害：与被辅助英雄功法相加后统一乘一次，不再各自乘算

      if (黑暗辅助)
      {
         finalDamage *= (1 + 英雄星级属性.妲己效果 / 100f);
      }
      if (女娲电辅助)
      {
         finalDamage *= (1 + 英雄星级属性.女娲辅助伤害 / 100f);
      }
      if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
      {
         finalDamage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
      }

      float 冰冻概率 = 瑶池神通 ? HeroConfig.英雄神通配置Dic[HeroType].damage : 0f;
      var monsterDic = QueueController.S.MonsterColliderDic;

      foreach (Collider2D col in _resultsBuffer)
      {
         if (!monsterDic.TryGetValue(col, out var monster)) continue;

         if (瑶池冰辅助)
         {
            monster.瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
         }
         if (瑶池神通)
         {
            if (Random.Range(0, 100f) < 冰冻概率)
            {
               monster.冰冻time = 1;
            }
         }
         monster.女娲神通 = 女娲神通;
         monster.妲己神通 = 妲己神通;
         monster.妲己黑暗辅助 = 黑暗辅助;
         monster.女娲电辅助 = 女娲电辅助;

         monster.Hurt(finalDamage, HeroType, type);
      }
   }

}
