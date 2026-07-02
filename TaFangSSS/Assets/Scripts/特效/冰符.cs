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
    

    private void OnEnable()
    {
        float 目标scale = 1;
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
