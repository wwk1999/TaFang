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

   private Vector2 原始scale = Vector2.one;
   [NonSerialized] public int 下场次数 = 0;
   [NonSerialized] public bool 女娲电辅助;
   [NonSerialized] public bool 瑶池神通;


   private void OnEnable()
   {
      float scale = 英雄星级属性.孙悟空效果范围;
      if (scale <= 0) scale = 1;
      transform.localScale = new Vector3(原始scale.x * scale, 原始scale.y * scale, 1);
   }
   
   public void CheckCollisionWithMonsters()
   {
      // 检测所有重叠的碰撞体
      List<Collider2D> results = new List<Collider2D>();
      ContactFilter2D filter = new ContactFilter2D();
      filter.NoFilter();
      filter.useTriggers = true;
    
      孙悟空Tri.OverlapCollider(filter, results);
    
      // 找出所有怪物并处理
      foreach (Collider2D col in results)
      {
         if (col.gameObject == gameObject) continue;
        
         if (col.CompareTag("Monster"))
         {
            var hit = FightController.S.GetPeng(攻击特效Type.孙悟空棒子);
            hit.transform.position = col.gameObject.transform.position;
            hit.gameObject.SetActive(true);
            float damage = 属性config.总属性.总攻击力*英雄星级属性.孙悟空攻击数值/100f;
            damage *= (1+下场次数 *英雄星级属性.孙悟空每次下场伤害 / 100f);
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
            QueueController.S.MonsterColliderDic[col].妲己神通 = 妲己神通;

            QueueController.S.MonsterColliderDic[col].妲己黑暗辅助 = 黑暗辅助;
            QueueController.S.MonsterColliderDic[col].女娲电辅助 = 女娲电辅助;
            if (瑶池神通)
            {
               var random = Random.Range(0, 100f);
               if (random < HeroConfig.英雄神通配置Dic[HeroType.孙悟空].damage)
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
               damage *= (1f+英雄星级属性.孙悟空攻击数值/100f);
            }

            if (瑶池冰辅助)
            {
               if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
               {
                  damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                     功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                     100f);
               }
            }
            if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
            {
               damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
            }
            QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType.孙悟空);
         }
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
