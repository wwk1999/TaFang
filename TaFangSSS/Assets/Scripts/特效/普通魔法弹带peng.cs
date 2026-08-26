using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;

public class 普通魔法弹带peng : MonoBehaviour
{
   [NonSerialized]public float MoveSpeed;
   [NonSerialized]public Vector2 MoveDirection;
   public GameObject parent;
   public 攻击特效Type Type;
   [NonSerialized]public float DelayTime=5;
   [NonSerialized] public float damage;
   [NonSerialized] public HeroType HeroType;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   [NonSerialized]public bool 穿透=false;
   private Vector2 原始scale=Vector2.one;
   [NonSerialized] public bool 女娲电辅助;

  


   private void OnEnable()
   {
      CancelInvoke();
      transform.localScale = Vector2.one;
      if (Type == 攻击特效Type.冰剑气)
      {
         transform.localScale = new Vector3(原始scale.x * 英雄星级属性.云霄效果范围, 原始scale.y * 英雄星级属性.云霄效果范围, 1);
      }
      float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
      parent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
      Invoke(nameof(Hide), DelayTime); 
   }

   public void Hide()
   {
      FightController.S.普通魔法弹Hide(this,Type,gameObject);
   }

   private void Update()
   {
      transform.position += (Vector3)MoveDirection * MoveSpeed * Time.deltaTime;
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      // 获取两个碰撞器之间的最近点（世界坐标）
     Vector2 closestPoint = other.ClosestPoint(transform.position);
      if (other.CompareTag("Monster"))
      {
         var hit = FightController.S.GetPeng(Type);
         hit.transform.position = closestPoint;
         float realDamage = damage;
         if (瑶池冰辅助)
         {
            QueueController.S.MonsterColliderDic[other].瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
         }
         if (黑暗辅助)
         {
            if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
            {
               damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                  功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                  100f);
            }
            damage *= (1+英雄星级属性.妲己效果/100);
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
         QueueController.S.MonsterColliderDic[other].Hurt(realDamage,HeroType);
         hit.gameObject.SetActive(true);
         if (!穿透)
         {
            transform.localScale=Vector2.zero;
         }
         
         if (Type == 攻击特效Type.黑暗魔法弹)
         {
            QueueController.S.MonsterColliderDic[other].transform.position = new Vector3(QueueController.S.MonsterColliderDic[other].transform.position.x+英雄星级属性.土地击退距离,QueueController.S.MonsterColliderDic[other].transform.position.y,QueueController.S.MonsterColliderDic[other].transform.position.z);
         }
      }
   }
}
