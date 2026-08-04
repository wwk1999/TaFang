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
      // 对象池复用时强制动画从0帧重新播放
      if (Animator != null)
      {
         Animator.Rebind();
         Animator.Update(0f);
         if (Animator.runtimeAnimatorController != null && Animator.runtimeAnimatorController.animationClips != null && Animator.runtimeAnimatorController.animationClips.Length > 0)
            Animator.Play(Animator.runtimeAnimatorController.animationClips[0].name, -1, 0f);
      }
      float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
      float length = Animator != null ? Animator.GetCurrentAnimatorStateInfo(0).length : 0.5f;
      Invoke(nameof(Hide),length);
   }

   public void Hide()
   {
      FightController.S.序列纯显示一次Hide(this,pengType,gameObject);
   }
}
