using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 石敢当锤子 : MonoBehaviour
{
   [NonSerialized] public Vector2 dir;
   [NonSerialized] public float speed;

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
         FightController.S.MonsterColliderDic[other].Hurt(50,YuanSuType.物理);
      }
   }
}
