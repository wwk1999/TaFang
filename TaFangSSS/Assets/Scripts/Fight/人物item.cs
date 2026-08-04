using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class 人物item : MonoBehaviour
{
    public GameObject content;
    public Transform 盘古拳trans;
    public 火球旋转parent 火球3;
    public 火球旋转parent 火球4;
    public 火球旋转parent 火球5;
    public 火球旋转parent 火球6;
    public 火球旋转parent 火球7;
    public 火球旋转parent 火球8;
    public 火球旋转parent 火球9;
    public 火球旋转parent 火球10;

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
    public GameObject 妲己黑暗辅助obj;
    [NonSerialized] public float 妲己黑暗辅助;
    public GameObject 女娲电辅助obj;
    [NonSerialized] public float 女娲电辅助;
    public GameObject 牛魔王技能Obj;
    public Animator 牛魔王技能Animator;
    public 黑暗抓痕动画脚本 牛魔王脚本;
    public 黑暗抓痕动画脚本 喷火;
    public Animator 喷火Animator;
    public GameObject 喷火Obj;
    public 孙悟空棒子 棒子;
    private float 攻击间隔 => Get攻击间隔();
    private bool 上场=false;
    private int 孙悟空下场次数 = 0;
    private int 盘古出拳次数 = 0;

    public float Get攻击间隔()
    {
        float value = 英雄星级属性.Get英雄Cd(heroType);
        value *= (1 - 属性config.总属性.英雄冷却缩减);
        if (HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.控制)
        {
            value *= (1 - 属性config.总属性.控制冷却缩减);
        }
        if (女娲电辅助 > 0)
        {
            value *= (1f-英雄星级属性.女娲效果);
            value *= (1f - 属性config.总属性.女娲辅助冷却缩减);
        }
        float random=Random.Range(0.9f,1.1f);
        return value*random;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster")&&!上场)
        {
            攻击范围内怪物.Add(QueueController.S.MonsterColliderDic[other]);
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
        妲己黑暗辅助-= Time.deltaTime;
        女娲电辅助-= Time.deltaTime;
        瑶池冰辅助obj.SetActive(瑶池冰辅助 > 0);
        妲己黑暗辅助obj.SetActive(妲己黑暗辅助 > 0);
        女娲电辅助obj.SetActive(女娲电辅助 > 0);
        if (!上场)
        {
          CurrentAttackTime+= Time.deltaTime;  
        }
        MonsterBase monsterBase = FightController.S.GetAttackMonster();
        
        if (monsterBase!=null&&CurrentAttackTime > 攻击间隔&&!FightController.S.战斗结束)
        { 
            Vector2 targetPos = monsterBase.transform.position;
            CurrentAttackTime = 0;
            if (heroType == HeroType.瑶池仙女||heroType == HeroType.妲己||heroType == HeroType.女娲)//辅助类
            {
                Animator.Play("人物放大缩小",0,0f);
                var dir=(targetPos-(Vector2)transform.position).normalized;
                FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助);
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
                }else if(heroType == HeroType.孙悟空)//上场
                {
                    int count = 英雄星级属性.孙悟空次数;
                    上场技能(攻击特效Type.孙悟空棒子, new Vector2(targetPos.x - 1f, targetPos.y), count*0.25f, false,count);
                }
                else if(heroType == HeroType.元始)//上场
                {
                    float random = Random.Range(0, 100f);
                    if (random < 属性config.总属性.元始火种增加数量 * 100f)
                    {
                        FightController.S.元始数量++;
                    }
                    上场技能(攻击特效Type.火球, new Vector2(targetPos.x + 1f, targetPos.y), 英雄星级属性.元始持续时间, true,FightController.S.元始数量);
                }
                else if(heroType == HeroType.盘古)//上场
                {
                    int count = 英雄星级属性.盘古攻击数量;
                    StartCoroutine(盘古拳(  0.4f, count));
                }
                else
                {
                    Animator.Play("人物攻击",0,0f);
                    var dir=(targetPos-(Vector2)transform.position).normalized;
                    FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助);
                }
            }
        }
    }

    IEnumerator 盘古拳(float waitTime, int count)
    {
        上场 = true;
        while (count > 0)
        {
            盘古出拳次数++;
            count--;
            // 实时获取当前目标怪物位置
            Vector2 monstertrans = FightController.S.GetAttackMonster().transform.position;
            Vector2 targetPos = new Vector2(monstertrans.x - 1.5f, monstertrans.y);

            // 移动过去，并等待移动完成（0.2秒）
            yield return transform.DOMove(targetPos, 0.2f).WaitForCompletion();

            // 播放攻击动画
            Animator.Play("人物攻击", 0, 0f);
        
            // 出拳逻辑
            var 盘古拳 = QueueController.S.盘古拳Queue.Dequeue();
            盘古拳.transform.position = 盘古拳trans.position; // 确保 盘古拳trans 正确
            盘古拳.脚本.瑶池冰辅助 = 瑶池冰辅助 > 0;
            盘古拳.脚本.黑暗辅助 = 妲己黑暗辅助 > 0;
            盘古拳.脚本.女娲电辅助 = 女娲电辅助 > 0;
            盘古拳.脚本.HeroType = HeroType.盘古;
            盘古拳.脚本.damage = 属性config.总属性.总攻击力 * 英雄星级属性.Get英雄攻击数值(HeroType.盘古)/100f*(1+盘古出拳次数*英雄星级属性.盘古出拳增加伤害/100f);
            盘古拳.gameObject.SetActive(true);

            // 等待攻击间隔
            yield return new WaitForSeconds(waitTime);
        }

        // 所有攻击结束后归位
        yield return transform.DOMove(原始Pos, 0.2f).WaitForCompletion();
        上场 = false;
    }

    public void 上场技能(攻击特效Type Type,Vector2 finalPos,float Time,bool 放大缩小,int count=0)
    {
        上场 = true;
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
                    黑暗抓痕.脚本.黑暗辅助 = 妲己黑暗辅助>0;
                    黑暗抓痕.脚本.女娲电辅助 = 女娲电辅助>0;

                    黑暗抓痕.gameObject.SetActive(true);
                    黑暗抓痕Animator.Play("187黑暗抓痕_Anim",0,0f);
                    break;
                case 攻击特效Type.牛魔王技能:
                    牛魔王脚本.瑶池冰辅助 = 瑶池冰辅助>0;
                    牛魔王脚本.黑暗辅助 = 妲己黑暗辅助>0;
                    牛魔王脚本.女娲电辅助 = 女娲电辅助>0;

                    牛魔王技能Obj.gameObject.SetActive(true);
                    牛魔王技能Animator.Play("219牛魔王技能_Anim",0,0f);
                    break;
                case 攻击特效Type.喷火:
                    喷火.瑶池冰辅助 = 瑶池冰辅助>0;
                    喷火.黑暗辅助 = 妲己黑暗辅助>0;
                    喷火.女娲电辅助 = 女娲电辅助>0;

                    喷火Obj.gameObject.SetActive(true);
                    喷火Animator.Play("114喷火_Anim",0,0f);
                    break;
                case 攻击特效Type.孙悟空棒子:
                    孙悟空下场次数++;
                    棒子.下场次数 = 孙悟空下场次数;
                    棒子.瑶池冰辅助 = 瑶池冰辅助>0;
                    棒子.黑暗辅助 = 妲己黑暗辅助>0;
                    棒子.女娲电辅助 = 女娲电辅助>0;

                    StartCoroutine(棒子.孙悟空攻击(count));
                    break;
                case 攻击特效Type.火球:
                    switch (count)
                    {
                        case 3:
                            火球3.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球3.黑暗辅助 = 妲己黑暗辅助>0;
                            火球3.女娲电辅助 = 女娲电辅助>0;

                            火球3.RotateSpeed = 100;
                            火球3.damage = 20;
                            火球3.gameObject.SetActive(true);
                            break;
                        case 4:
                            火球4.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球4.黑暗辅助 = 妲己黑暗辅助>0;
                            火球4.女娲电辅助 = 女娲电辅助>0;

                            火球4.RotateSpeed = 100;
                            火球4.damage = 20;
                            火球4.gameObject.SetActive(true);
                            break;
                        case 5:
                            火球5.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球5.黑暗辅助 = 妲己黑暗辅助>0;
                            火球5.女娲电辅助 = 女娲电辅助>0;

                            火球5.RotateSpeed = 100;
                            火球5.damage = 20;
                            火球5.gameObject.SetActive(true);
                            break;
                        case 6:
                            火球6.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球6.黑暗辅助 = 妲己黑暗辅助>0;
                            火球6.女娲电辅助 = 女娲电辅助>0;

                            火球6.RotateSpeed = 100;
                            火球6.damage = 20;
                            火球6.gameObject.SetActive(true);
                            break;
                        case 7:
                            火球7.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球7.黑暗辅助 = 妲己黑暗辅助>0;
                            火球7.女娲电辅助 = 女娲电辅助>0;

                            火球7.RotateSpeed = 100;
                            火球7.damage = 20;
                            火球7.gameObject.SetActive(true);
                            break;
                        case 8:
                            火球8.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球8.黑暗辅助 = 妲己黑暗辅助>0;
                            火球8.女娲电辅助 = 女娲电辅助>0;

                            火球8.RotateSpeed = 100;
                            火球8.damage = 20;
                            火球8.gameObject.SetActive(true);
                            break;
                        case 9:
                            火球9.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球9.黑暗辅助 = 妲己黑暗辅助>0;
                            火球9.女娲电辅助 = 女娲电辅助>0;

                            火球9.RotateSpeed = 100;
                            火球9.damage = 20;
                            火球9.gameObject.SetActive(true);
                            break;
                    }

                    if (count >= 10)
                    {
                        火球10.瑶池冰辅助 = 瑶池冰辅助>0;
                        火球10.黑暗辅助 = 妲己黑暗辅助>0;
                        火球10.女娲电辅助 = 女娲电辅助>0;

                        火球10.RotateSpeed = 100;
                        火球10.damage = 20;
                        火球10.gameObject.SetActive(true);
                    }
                    break;
            }
        });
        mySequence.AppendInterval(Time);
        mySequence.Append(transform.DOMove(原始Pos, 0.2f));
        mySequence.AppendCallback(() =>
        {
            上场 = false;
        });
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
