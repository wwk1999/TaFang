using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using UnityEngine.UI;

public class 横幅item : MonoBehaviour
{
    public Animator Animator;
    public Image Icon;
    [NonSerialized] public HeroType HeroType;

    private void OnEnable()
    {
        Icon.sprite = ResourcesConfig.Get英雄神通横幅(HeroType);
        Animator.Play("神通横幅",0,0);
        
    }

    public void destroyobj()
    {
        Destroy(gameObject);
    }
}
