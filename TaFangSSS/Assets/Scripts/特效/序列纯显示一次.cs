using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 序列纯显示一次 : MonoBehaviour
{
   public Animator Animator;
   public PengType pengType;
   [NonSerialized]public Vector2 MoveDirection;


   private void OnEnable()
   {
      CancelInvoke();
      float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
      float length = Animator.GetCurrentAnimatorStateInfo(0).length;
      Invoke(nameof(Hide),length);
   }

   public void Hide()
   {
      FightController.S.序列纯显示一次Hide(this,pengType,gameObject);
   }
}
