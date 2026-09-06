using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 石敢当锤子 : MonoBehaviour
{
   [NonSerialized] public Vector2 dir;
   [NonSerialized] public float speed;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   [NonSerialized] public bool 妲己神通;
   [NonSerialized] public bool 女娲神通;

   private Vector2 原始scale=Vector2.one;
   [NonSerialized] public bool 女娲电辅助;
   [NonSerialized] public bool 瑶池神通;


   private void OnEnable()
   {
     
      float 目标scale = 英雄星级属性.石敢当效果范围;
      transform.localScale=new Vector3(原始scale.x*目标scale,原始scale.y*目标scale,1);
   }


   private void Update()
   {
      transform.Translate(dir * speed * Time.deltaTime, Space.World);
   }

   public void Hide()
   {
      speed = 0;
      StartCoroutine(DelayHide());
   }

   IEnumerator DelayHide()
   {
      yield return new WaitForSeconds(0.5f);
      QueueController.S.石敢当锤子Queue.Enqueue(this);
      gameObject.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (!other.CompareTag("Monster") || speed <= 0) return;
      if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

      float finalDamage = 属性config.总属性.总攻击力 * 英雄星级属性.石敢当攻击数值 / 100f;
      // 辅助功法加成已移入 MonsterBase.计算功法伤害：与被辅助英雄功法相加后统一乘一次，不再各自乘算
      if (瑶池冰辅助)
      {
         monster.瑶池冰辅助 = 2;
      }
      monster.妲己黑暗辅助 = 黑暗辅助;
      monster.女娲电辅助 = 女娲电辅助;
      monster.妲己神通 = 妲己神通;
      monster.女娲神通 = 女娲神通;

      if (瑶池神通)
      {
         if (Random.Range(0, 100f) < HeroConfig.英雄神通配置Dic[HeroType.石敢当].damage)
         {
            monster.冰冻time = 1;
         }
      }
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

      monster.Hurt(finalDamage, HeroType.石敢当, 攻击特效Type.石敢当锤子);
   }
}
