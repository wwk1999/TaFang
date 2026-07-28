using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 孙悟空棒子 : MonoBehaviour
{
   public GameObject 棒子obj;
   public Animator Animator;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   private Vector2 原始scale;
   [NonSerialized] public int 下场次数 = 0;
   [NonSerialized] public bool 女娲电辅助;

   

   private void OnEnable()
   {
      transform.localScale=new Vector3(原始scale.x*英雄星级属性.孙悟空效果范围,原始scale.y*英雄星级属性.孙悟空效果范围,1);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Monster"))
      {
         Vector2 closestPoint = other.ClosestPoint(transform.position);
         var hit = FightController.S.GetPeng(攻击特效Type.孙悟空棒子);
         hit.transform.position = closestPoint;
         hit.gameObject.SetActive(true);
         if (瑶池冰辅助)
         {
            QueueController.S.MonsterColliderDic[other].瑶池冰辅助 = 2;
         }

         float damage = 属性config.领主攻击力*英雄星级属性.孙悟空攻击数值/100f;
         damage *= (1+下场次数 *英雄星级属性.孙悟空每次下场伤害 / 100f);
         if (女娲电辅助)
         {
            damage*=(1+英雄星级属性.女娲辅助伤害/100f);
         }
         
         if (黑暗辅助)
         {
            damage *= (1f+英雄星级属性.孙悟空攻击数值/100f);
         }
         QueueController.S.MonsterColliderDic[other].Hurt(damage,YuanSuType.物理);
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
            Animator.Play("向下", 0, 0f);
            yield return new WaitForSeconds(0.25f);
         }

         count -= 1;
         if (count >= 0)
         {
            Animator.Play("向上", 0, 0f);
            yield return new WaitForSeconds(0.25f);
         }
      }
      棒子obj.gameObject.SetActive(false);
   }
}
