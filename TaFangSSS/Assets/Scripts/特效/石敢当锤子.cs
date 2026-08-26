using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 石敢当锤子 : MonoBehaviour
{
   [NonSerialized] public Vector2 dir;
   [NonSerialized] public float speed;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   private Vector2 原始scale=Vector2.one;
   [NonSerialized] public bool 女娲电辅助;
   

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
      if (other.CompareTag("Monster")&&speed>0)
      {
         

         float damage = 属性config.总属性.总攻击力 * 英雄星级属性.石敢当攻击数值 / 100f;
         if (瑶池冰辅助)
         {
            if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
            {
               damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                  功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                  100f);
            }
            QueueController.S.MonsterColliderDic[other].瑶池冰辅助 = 2;
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
            QueueController.S.MonsterColliderDic[other].妲己黑暗辅助 = 黑暗辅助;

         }
         if (女娲电辅助)
         {
            if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
            {
               damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                  功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                  100f);
            }
            damage*=(1+英雄星级属性.女娲辅助伤害/100f);
            QueueController.S.MonsterColliderDic[other].女娲电辅助 = 女娲电辅助;

         }
         if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
         {
            damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
         }
         
         QueueController.S.MonsterColliderDic[other].Hurt(damage,HeroType.石敢当);
      }
   }
}
