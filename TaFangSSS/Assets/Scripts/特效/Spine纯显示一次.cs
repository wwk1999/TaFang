using System;
using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class Spine纯显示一次 : MonoBehaviour
{
   public SkeletonAnimation Skeleton;
   public string name;
   public 特效Type 特效Type;

   private void Start()
   {
      Skeleton.AnimationState.Complete += Complete;
   }

   public void Complete(TrackEntry trackEntry)
   {
      FightController.S.Spine纯显示一次Hide(this,特效Type,gameObject);
   }

   private void OnEnable()
   {
      Skeleton.AnimationState.SetAnimation(0,name,false);
   }
}
