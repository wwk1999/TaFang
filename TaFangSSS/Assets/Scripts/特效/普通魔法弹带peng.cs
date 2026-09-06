using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using Spine.Unity;
using UnityEngine;
using Random = UnityEngine.Random;

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
   [NonSerialized] public bool 瑶池神通;
   [NonSerialized] public bool 妲己神通;
   [NonSerialized] public bool 女娲神通;

   [NonSerialized] public bool 黑暗辅助;
   [NonSerialized]public bool 穿透=false;
   private Vector2 原始scale=Vector2.one;
   [NonSerialized] public bool 女娲电辅助;
   [NonSerialized] public bool 是否神通;

  


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
      if (!other.CompareTag("Monster")) return;
      if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

      // 获取两个碰撞器之间的最近点（世界坐标）
      Vector2 closestPoint = other.ClosestPoint(transform.position);
      var hit = FightController.S.GetPeng(Type);
      hit.transform.position = closestPoint;

      // ---- 辅助加成全部算在局部变量上，不写回 damage 字段（避免穿透弹多怪物滚雪球） ----
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

      if (瑶池神通)
      {
         if (Random.Range(0, 100f) < HeroConfig.英雄神通配置Dic[HeroType].damage)
         {
            monster.冰冻time = 1;
         }
      }
      if (瑶池冰辅助)
      {
         monster.瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
      }
      monster.妲己黑暗辅助 = 黑暗辅助;
      monster.女娲电辅助 = 女娲电辅助;
      monster.妲己神通 = 妲己神通;
      monster.女娲神通 = 女娲神通;

      monster.Hurt(finalDamage, HeroType, Type);
      hit.gameObject.SetActive(true);
      if (!穿透)
      {
         transform.localScale = Vector2.zero;
      }

      if (Type == 攻击特效Type.黑暗魔法弹)
      {
         monster.transform.position = new Vector3(monster.transform.position.x + 英雄星级属性.土地击退距离, monster.transform.position.y, monster.transform.position.z);
      }
   }
}
