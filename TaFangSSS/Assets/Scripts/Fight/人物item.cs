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
    [NonSerialized] private HashSet<MonsterBase> 攻击范围内怪物=new HashSet<MonsterBase>();
    [NonSerialized] public float 瑶池冰辅助;
    public GameObject 瑶池冰辅助obj;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            攻击范围内怪物.Add(FightController.S.MonsterColliderDic[other]);
        }
    }

    public void 怪物死亡(object[] obj)
    {
        MonsterBase monsterBase = obj[0] as MonsterBase;
        攻击范围内怪物.Remove(monsterBase);
    }

    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("怪物死亡",怪物死亡);
    }

    private void Update()
    {
        瑶池冰辅助-= Time.deltaTime;
        瑶池冰辅助obj.SetActive(瑶池冰辅助 > 0);
        CurrentAttackTime+= Time.deltaTime;
        MonsterBase monsterBase = FightController.S.GetAttackMonster();
        if (monsterBase!=null&&CurrentAttackTime > HeroConfig.HeroAttackTimeDic[heroType]&&!FightController.S.战斗结束)
        { 
            Vector2 targetPos = monsterBase.transform.position;
            CurrentAttackTime = 0;
            if (heroType == HeroType.瑶池仙女)
            {
                Animator.Play("人物放大缩小",0,0f);
                var dir=(targetPos-(Vector2)transform.position).normalized;
                FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助);
            }
            else if (攻击范围内怪物.Contains(monsterBase))
            {
                Animator.Play("人物攻击",0,0f);
                var dir=(targetPos-(Vector2)transform.position).normalized;
                FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助);
            }
        }
    }

    public void SetItem()
    {
        image.sprite = ResourcesConfig.GetHeroSprite(heroType);
        float scale = HeroConfig.攻击范围Dic[HeroConfig.HeroZhiYeDic[heroType].zhiYeType];
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
