using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 孙悟空棒子 : MonoBehaviour
{
   public Collider2D 孙悟空Tri;
   public GameObject 棒子obj;
   public Animator Animator;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   [NonSerialized] public bool 妲己神通;
   [NonSerialized] public bool 女娲神通;

   private Vector2 原始scale = Vector2.one;
   [NonSerialized] public int 下场次数 = 0;
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
      float scale = 英雄星级属性.孙悟空效果范围;
      if (scale <= 0) scale = 1;
      transform.localScale = new Vector3(原始scale.x * scale, 原始scale.y * scale, 1);
   }
   
   public void CheckCollisionWithMonsters()
   {
      if (孙悟空Tri == null) return;
      InitFilter();

      _resultsBuffer.Clear();
      孙悟空Tri.OverlapCollider(_monsterFilter, _resultsBuffer);
      if (_resultsBuffer.Count == 0) return;

      // ---- 循环外：基础伤害与所有加成只算一次 ----
      float finalDamage = 属性config.总属性.总攻击力 * 英雄星级属性.孙悟空攻击数值 / 100f;
      finalDamage *= (1 + 下场次数 * 英雄星级属性.孙悟空每次下场伤害 / 100f);

      var playerData = PlayerData.S;
      if (女娲电辅助)
      {
         var 女娲数据 = playerData.HeroDataDic[HeroType.女娲];
         if (女娲数据.功法Type != 功法Type.None)
         {
            finalDamage *= (1 + 女娲数据.功法等级 *
               功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[女娲数据.功法Type]] / 100f);
         }
         finalDamage *= (1 + 英雄星级属性.女娲辅助伤害 / 100f);
      }
      if (黑暗辅助)
      {
         var 妲己数据 = playerData.HeroDataDic[HeroType.妲己];
         if (妲己数据.功法Type != 功法Type.None)
         {
            finalDamage *= (1 + 妲己数据.功法等级 *
               功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[妲己数据.功法Type]] / 100f);
         }
         // 原代码这里误用了 孙悟空攻击数值，应为妲己辅助效果
         finalDamage *= (1f + 英雄星级属性.妲己效果 / 100f);
      }
      if (瑶池冰辅助)
      {
         var 瑶池数据 = playerData.HeroDataDic[HeroType.瑶池仙女];
         if (瑶池数据.功法Type != 功法Type.None)
         {
            finalDamage *= (1 + 瑶池数据.功法等级 *
               功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[瑶池数据.功法Type]] / 100f);
         }
      }
      if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
      {
         finalDamage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
      }

      float 冰冻概率 = 瑶池神通 ? HeroConfig.英雄神通配置Dic[HeroType.孙悟空].damage : 0f;
      var monsterDic = QueueController.S.MonsterColliderDic;

      foreach (Collider2D col in _resultsBuffer)
      {
         if (!monsterDic.TryGetValue(col, out var monster)) continue;

         // 命中特效每只怪一个
         var hit = FightController.S.GetPeng(攻击特效Type.孙悟空棒子);
         hit.transform.position = col.transform.position;
         hit.gameObject.SetActive(true);

         monster.妲己神通 = 妲己神通;
         monster.女娲神通 = 女娲神通;
         monster.妲己黑暗辅助 = 黑暗辅助;
         monster.女娲电辅助 = 女娲电辅助;
         if (瑶池神通)
         {
            if (Random.Range(0, 100f) < 冰冻概率)
            {
               monster.冰冻time = 1;
            }
         }

         monster.Hurt(finalDamage, HeroType.孙悟空, 攻击特效Type.孙悟空棒子);
      }
   }
   
   public IEnumerator 孙悟空攻击(int count)
   {
      棒子obj.gameObject.SetActive(true);
      while (count >= 0)
      {
         count -= 1;
         if (count >= 0)
         {
            ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.孙悟空);
            Animator.Play("向下", 0, 0f);
            yield return new WaitForSeconds(0.25f);
         }

         count -= 1;
         if (count >= 0)
         {
            ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.孙悟空);
            Animator.Play("向上", 0, 0f);
            yield return new WaitForSeconds(0.25f);
         }
      }
      棒子obj.gameObject.SetActive(false);
   }
}
