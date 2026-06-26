using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using DG.Tweening;
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
    [NonSerialized] public Vector2 原始Pos;
    public 黑暗抓痕 黑暗抓痕;
    public Animator 黑暗抓痕Animator;
    public GameObject 黑暗辅助obj;
    [NonSerialized] public float 黑暗辅助;
    public GameObject 牛魔王技能Obj;
    public Animator 牛魔王技能Animator;
    public 黑暗抓痕动画脚本 牛魔王脚本;
    public 黑暗抓痕动画脚本 喷火;
    public Animator 喷火Animator;
    public GameObject 喷火Obj;
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
        黑暗辅助-= Time.deltaTime;
        瑶池冰辅助obj.SetActive(瑶池冰辅助 > 0);
        黑暗辅助obj.SetActive(黑暗辅助 > 0);
        CurrentAttackTime+= Time.deltaTime;
        MonsterBase monsterBase = FightController.S.GetAttackMonster();
        if (monsterBase!=null&&CurrentAttackTime > HeroConfig.HeroAttackTimeDic[heroType]&&!FightController.S.战斗结束)
        { 
            Vector2 targetPos = monsterBase.transform.position;
            CurrentAttackTime = 0;
            if (heroType == HeroType.瑶池仙女||heroType == HeroType.妲己)//辅助类
            {
                Animator.Play("人物放大缩小",0,0f);
                var dir=(targetPos-(Vector2)transform.position).normalized;
                FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助,黑暗辅助);
            }
            else if (攻击范围内怪物.Contains(monsterBase))
            {
                if (heroType == HeroType.广目天王)//上场
                {
                    上场技能(攻击特效Type.黑暗抓痕, new Vector2(targetPos.x - 1f, targetPos.y), 0.5f, false);
                }
                else if(heroType == HeroType.牛魔王)//上场
                {
                    上场技能(攻击特效Type.牛魔王技能, new Vector2(targetPos.x + 0.5f, targetPos.y), 0.6f, true);
                }else if(heroType == HeroType.哪吒)//上场
                {
                    上场技能(攻击特效Type.喷火, new Vector2(targetPos.x - 1f, targetPos.y), 1f, false);
                }
                else
                {
                    Animator.Play("人物攻击",0,0f);
                    var dir=(targetPos-(Vector2)transform.position).normalized;
                    FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助,黑暗辅助);
                }
            }
        }
    }

    public void 上场技能(攻击特效Type Type,Vector2 finalPos,float Time,bool 放大缩小)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(finalPos, 0.2f));
        mySequence.AppendCallback(() =>
        {
            if (放大缩小)
            {
                Animator.Play("人物放大缩小",0,0f);
            }
            else
            {
                Animator.Play("人物攻击",0,0f);
            }

            switch (Type)
            {
                case 攻击特效Type.黑暗抓痕:
                    黑暗抓痕.脚本.瑶池冰辅助 = 瑶池冰辅助>0;
                    黑暗抓痕.脚本.黑暗辅助 = 黑暗辅助>0;
                    黑暗抓痕.gameObject.SetActive(true);
                    黑暗抓痕Animator.Play("187黑暗抓痕_Anim",0,0f);
                    break;
                case 攻击特效Type.牛魔王技能:
                    牛魔王脚本.瑶池冰辅助 = 瑶池冰辅助>0;
                    牛魔王脚本.黑暗辅助 = 黑暗辅助>0;
                    牛魔王技能Obj.gameObject.SetActive(true);
                    牛魔王技能Animator.Play("219牛魔王技能_Anim",0,0f);
                    break;
                case 攻击特效Type.喷火:
                    喷火.瑶池冰辅助 = 瑶池冰辅助>0;
                    喷火.黑暗辅助 = 黑暗辅助>0;
                    喷火Obj.gameObject.SetActive(true);
                    喷火Animator.Play("114喷火_Anim",0,0f);
                    break;
            }
        });
        mySequence.AppendInterval(Time);
        mySequence.Append(transform.DOMove(原始Pos, 0.2f));
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
