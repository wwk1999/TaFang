using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 黑暗印记爆炸 : MonoBehaviour
{
    public Animator Animator;
    [NonSerialized] public float damage;
    [NonSerialized] public HeroType HeroType;

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
        float length = Animator != null ? Animator.GetCurrentAnimatorStateInfo(0).length : 0.5f;
        Invoke(nameof(Hide),length);
    }

    public void Hide()
    {
        QueueController.S.黑暗印记爆炸Queue.Enqueue(this);
        gameObject.SetActive(false);
    }
}
