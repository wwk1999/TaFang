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
   [NonSerialized] public YuanSuType YuanSuType;
   [NonSerialized] public bool 瑶池冰辅助;
   [NonSerialized] public bool 黑暗辅助;
   [NonSerialized]public bool 穿透=false;

   
   private void OnEnable()
   {
      CancelInvoke();
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
         if (黑暗辅助)
         {
            realDamage *= 1.2f;
         }
         FightController.S.MonsterColliderDic[other].Hurt(realDamage,YuanSuType);
         hit.gameObject.SetActive(true);
         if (!穿透)
         {
            gameObject.SetActive(false);
         }
         if (瑶池冰辅助)
         {
            FightController.S.MonsterColliderDic[other].瑶池冰辅助 = 2;//持续2s
         }
         if (Type == 攻击特效Type.黑暗魔法弹)
         {
            FightController.S.MonsterColliderDic[other].transform.position = new Vector3(FightController.S.MonsterColliderDic[other].transform.position.x+0.2f,FightController.S.MonsterColliderDic[other].transform.position.y,FightController.S.MonsterColliderDic[other].transform.position.z);
         }
      }
   }
}
