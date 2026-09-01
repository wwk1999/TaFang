using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 冰符 : MonoBehaviour
{
    public 冰符动画脚本 脚本;
    public HeroType HeroType;
    private Vector2 原始scale=Vector2.one;
    public Animator anim;
    public bool 是否神通 = false;
    private void OnEnable()
    {
        // 对象池复用时确保子对象(sprite)是激活状态，并强制动画从0帧重新播放
        if (脚本 != null)
        {
            脚本.gameObject.SetActive(true);
            if (anim != null)
            {
                anim.Rebind();
                anim.Update(0f);
                if (anim.runtimeAnimatorController != null && anim.runtimeAnimatorController.animationClips != null && anim.runtimeAnimatorController.animationClips.Length > 0)
                    anim.Play(anim.runtimeAnimatorController.animationClips[0].name, -1, 0f);
            }
        }
        float 目标scale = 1;
        if (是否神通) return;
        switch (HeroType)
        {
            case HeroType.常羲:
                目标scale = 英雄星级属性.常曦效果范围;
                break;
            case HeroType.羲和:
                目标scale = 英雄星级属性.羲和效果范围;
                break;
        }

        transform.localScale = new Vector3(原始scale.x * 目标scale, 原始scale.y * 目标scale, 1);
    }
}
