using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 人物item : MonoBehaviour
{
    public SpriteRenderer bg;
    public SpriteRenderer image;
    public Animator Animator;
    public GameObject 攻击范围Tri;
    [NonSerialized]public HeroType heroType;
    private float CurrentAttackTime = 0;

    private void Update()
    {
        CurrentAttackTime+= Time.deltaTime;
        if (CurrentAttackTime > HeroConfig.HeroAttackTimeDic[heroType])
        { 
            Vector2 targetPos = FightController.S.GetAttackPostion();
            if (targetPos.x < 10000)
            {
                CurrentAttackTime = 0;
                Animator.Play("人物攻击",0,0f);
                var dir=(targetPos-(Vector2)transform.position).normalized;
                FightController.S.Shot普通魔法弹(攻击特效Type.火虎魔法弹,transform.position,dir,50,YuanSuType.火,8);
            }
        }
    }

    public void SetItem()
    {
        HashSet<人物item> a = new HashSet<人物item>();
        人物item b = new 人物item();
        a.Remove(b);
        image.sprite = ResourcesConfig.GetHeroSprite(heroType);
        float scale = HeroConfig.攻击范围Dic[HeroConfig.HeroZhiYeDic[heroType]];
        攻击范围Tri.transform.localScale = new Vector3(scale, scale, scale);
        switch (HeroConfig.HeroQualityDic[heroType])
        {
            case QualityType.黄品:
                bg.sprite = ResourcesConfig.战斗人物背景框白;
                break;
            case QualityType.玄品:
                bg.sprite = ResourcesConfig.战斗人物背景框绿;
                break;
            case QualityType.地品:
                bg.sprite = ResourcesConfig.战斗人物背景框蓝;
                break;
            case QualityType.天品:
                bg.sprite = ResourcesConfig.战斗人物背景框紫;
                break;
            case QualityType.宇品:
                bg.sprite = ResourcesConfig.战斗人物背景框橙;
                break;
            case QualityType.宙品:
                bg.sprite = ResourcesConfig.战斗人物背景框粉;
                break;
            case QualityType.洪品:
                bg.sprite = ResourcesConfig.战斗人物背景框红;
                break;
            case QualityType.荒品:
                bg.sprite = ResourcesConfig.战斗人物背景框彩;
                break;
        }
    }

}
