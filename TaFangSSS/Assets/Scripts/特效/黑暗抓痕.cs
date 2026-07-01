using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 黑暗抓痕 : MonoBehaviour
{
    public 黑暗抓痕动画脚本 脚本;
    public HeroType  HeroType;
    private Vector2 原始scale;

    private void Start()
    {
        原始scale=transform.localScale;
    }

    private void OnEnable()
    {
        float 目标scale = 1;
        switch (HeroType)
        {
            case HeroType.广目天王:
                目标scale = 英雄星级属性.广目天王效果范围;
                break;
            case HeroType.哪吒:
                目标scale = 英雄星级属性.哪吒效果范围;
                break;
            case HeroType.牛魔王:
                目标scale = 英雄星级属性.牛魔王效果范围;
                break;
        }

        transform.localScale = new Vector3(原始scale.x * 目标scale, 原始scale.y * 目标scale, 1);
    }
}
