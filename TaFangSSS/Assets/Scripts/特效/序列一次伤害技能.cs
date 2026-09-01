using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 序列一次伤害技能 : MonoBehaviour
{
    public 序列一次伤害动画脚本 脚本;
    private Vector2 原始scale=Vector2.one;
    public HeroType heroType;
    public Animator anim;
    public bool 是否神通=false;

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
        脚本.HeroType = heroType;
        if (是否神通)
        {
            return;
        }
        switch (heroType)
        {
            case HeroType.河伯:
                目标scale = 英雄星级属性.河伯效果范围;
                break;
            case HeroType.嫦娥:
                目标scale = 英雄星级属性.嫦娥效果范围;
                break;
            case HeroType.雷震子:
                目标scale = 英雄星级属性.雷震子效果范围;
                break;
            case HeroType.碧霄:
                目标scale = 英雄星级属性.碧霄效果范围;
                break;
            case HeroType.琼霄:
                目标scale = 英雄星级属性.琼霄效果范围;
                break;
            case HeroType.玄女:
                目标scale = 英雄星级属性.玄女效果范围;
                break;
        }
        gameObject.transform.localScale = new Vector3(原始scale.x * 目标scale, 原始scale.y * 目标scale, 1);
    }
}
