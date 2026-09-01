using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class 人物item : MonoBehaviour
{
    public 黑暗抓痕动画脚本 石敢当神通脚本;
    public GameObject 石敢当神通Obj;
    public GameObject 瑶池神通;
    [NonSerialized]public float 瑶池神通time = 0;
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
    [NonSerialized] private List<MonsterBase> 攻击范围内怪物列表 = new List<MonsterBase>();  // 新增

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
    private float 神通冷却时间=>Get神通间隔();
    private float 神通能量=>Get神通能量();
    private bool 是否在神通=false;
    private float 当前神通冷却时间 = 0;
    private bool 上场=false;
    private int 孙悟空下场次数 = 0;
    private int 盘古出拳次数 = 0;

    public float Get神通间隔()
    {
        float value = HeroConfig.英雄神通配置Dic[heroType].cd;
        return value;
    }
    public float Get神通能量()
    {
        float value = HeroConfig.英雄神通配置Dic[heroType].能量;
        return value;
    }
    public float Get攻击间隔()
    {
        float value = 英雄星级属性.Get英雄Cd(heroType);
        value /= (1f + 体质Config.当前体质总属性.攻击速度 / 100f);
        value /= (1 + 属性config.总属性.英雄冷却缩减);
        if (HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.控制)
        {
            value /= (1 + 属性config.总属性.控制冷却缩减);
        }
        if (女娲电辅助 > 0)
        {
            float 原始星级效果 = 英雄星级属性.女娲效果;
            value /= (1f+原始星级效果);
            value /= (1f + 属性config.总属性.女娲辅助冷却缩减);//道文
        }

        if (HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.射手 &&
            PlayerData.S.HeroDataDic[heroType].功法Type != 功法Type.None)
        {
            value/=(1f+功法Config.功法属性Dic[PlayerData.S.HeroDataDic[heroType].功法Type].count/100f);
        }
        float random=Random.Range(0.8f,1.2f);
        return value*random;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster") && !上场)
        {
            var monster = QueueController.S.MonsterColliderDic[other];
            if (攻击范围内怪物.Add(monster))  // Add返回true表示新增
            {
                攻击范围内怪物列表.Add(monster);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Monster") && !上场)
        {
            var monster = QueueController.S.MonsterColliderDic[other];
            if (攻击范围内怪物.Add(monster))
            {
                攻击范围内怪物列表.Add(monster);
            }
        }
    }

    public void 怪物死亡(object[] obj)
    {
        MonsterBase monsterBase = obj[0] as MonsterBase;
        if (攻击范围内怪物.Remove(monsterBase))
        {
            攻击范围内怪物列表.Remove(monsterBase);
        }
    }

    private Vector2 Get随机怪物位置()
    {
        if (攻击范围内怪物列表.Count == 0)
        {
            float randomx = Random.Range(-3.5f,7.5f);
            float randomy = Random.Range(-3.5f,3.5f);
            return new Vector2(randomx, randomy);
        }
        
    
        int randomIndex = Random.Range(0, 攻击范围内怪物列表.Count);
        return 攻击范围内怪物列表[randomIndex].transform.position;
    }

    public IEnumerator 多次释放神通(攻击特效Type type, int count, float time)
    {
        for (int i = 0; i < count; i++)
        {
            switch (type)
            {
                case 攻击特效Type.玄女神通:
                    FightController.S.一次伤害技能(攻击特效Type.玄女神通, Get随机怪物位置(),瑶池冰辅助>0,妲己黑暗辅助>0,女娲电辅助>0,瑶池神通time>0);           
                    break;
            }
            yield return new WaitForSeconds(time);
        }
    }
    private void Start()
    {
        ObserverModuleManager.S.RegisterEvent("怪物死亡",怪物死亡);
    }

    private void Update()
    {
        瑶池神通time-=Time.deltaTime;
        当前神通冷却时间+=Time.deltaTime;
        瑶池冰辅助-= Time.deltaTime;
        妲己黑暗辅助-= Time.deltaTime;
        女娲电辅助-= Time.deltaTime;
        瑶池冰辅助obj.SetActive(瑶池冰辅助 > 0);
        妲己黑暗辅助obj.SetActive(妲己黑暗辅助 > 0);
        女娲电辅助obj.SetActive(女娲电辅助 > 0);
        瑶池神通.gameObject.SetActive(瑶池神通time>0);
        if (!上场)
        {
          CurrentAttackTime+= Time.deltaTime;  
        }
        MonsterBase monsterBase = FightController.S.GetAttackMonster();
        if (!FightController.S.战斗结束&&PlayerData.S.神通配置List[FightController.S.当前神通index] == heroType &&
            FightController.S.当前英雄之间神通间隔时间 > FightController.S.英雄之间神通间隔时间 && 当前神通冷却时间 > 神通冷却时间 &&
            FightController.S.当前神通能量 >= 神通能量&&攻击范围内怪物列表.Count>0)
        {
            FightController.S.当前神通index++;
            if (FightController.S.当前神通index >= PlayerData.S.神通配置List.Count)
            {
                FightController.S.当前神通index = 0;
            }
            FightController.S.当前英雄之间神通间隔时间 = 0;
            当前神通冷却时间 = 0;
            FightController.S.当前神通能量 -= 神通能量;
            是否在神通 = true;
            释放神通();
        }
        else if (!是否在神通&&monsterBase!=null&&CurrentAttackTime > 攻击间隔&&!上场&&!FightController.S.战斗结束)
        { 
            Vector2 targetPos = monsterBase.transform.position;
            CurrentAttackTime = 0;
            if (heroType == HeroType.瑶池仙女||heroType == HeroType.妲己||heroType == HeroType.女娲)//辅助类
            {
                Animator.Play("人物放大缩小",0,0f);
                var dir=(targetPos-(Vector2)transform.position).normalized;
                FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助,瑶池神通time);
            }
            else if (攻击范围内怪物.Contains(monsterBase))
            {
                if (heroType == HeroType.广目天王)//上场
                {
                    上场技能(攻击特效Type.黑暗抓痕, new Vector2(targetPos.x - 1f, targetPos.y), 0.5f, false,false);
                }
                else if(heroType == HeroType.牛魔王)//上场
                {
                    上场技能(攻击特效Type.牛魔王技能, new Vector2(targetPos.x + 0.5f, targetPos.y), 0.6f, true,false);
                }else if(heroType == HeroType.哪吒)//上场
                {
                    上场技能(攻击特效Type.喷火, new Vector2(targetPos.x - 1f, targetPos.y), 1f, false,false);
                }else if(heroType == HeroType.孙悟空)//上场
                {
                    int count = 英雄星级属性.孙悟空次数;
                    上场技能(攻击特效Type.孙悟空棒子, new Vector2(targetPos.x - 1f, targetPos.y), count*0.25f, false,false,count);
                }
                else if(heroType == HeroType.元始)//上场
                {
                    float random = Random.Range(0, 100f);
                    if (random < 属性config.总属性.元始火种增加数量 * 100f)
                    {
                        FightController.S.元始数量++;
                    }
                    上场技能(攻击特效Type.火球, new Vector2(targetPos.x + 1f, targetPos.y), 英雄星级属性.元始持续时间, true,false,FightController.S.元始数量);
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
                    FightController.S.人物攻击(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助,瑶池神通time);
                }
            }
        }
    }

    public void 释放神通()
    {
        MonsterBase monsterBase = FightController.S.GetAttackMonster();
        Vector2 targetPos=monsterBase.transform.position;
        if (heroType == HeroType.石敢当)
        {
            ObserverModuleManager.S.SendEvent("播放英雄神通",heroType);
            上场技能(攻击特效Type.石敢当神通, new Vector2(targetPos.x + 0.5f, targetPos.y), 0.6f, true,true);
            return;
        }
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendCallback(() =>
        {
            //ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.丹童神通配音);
            ObserverModuleManager.S.SendEvent("播放英雄神通",heroType);
        });
        mySequence.AppendInterval(0.5f);
        mySequence.Append(transform.DOMove(new Vector3(transform.position.x+0.7f,transform.position.y,transform.position.z),0.15f));
        mySequence.AppendCallback(() =>
        {
            var dir=(targetPos-(Vector2)transform.position).normalized;
            switch (heroType)
            {
                case HeroType.龟丞相:
                    FightController.S.人物神通(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助,瑶池神通time);
                    mySequence.AppendInterval(0.5f);
                    break;
                case HeroType.玄女:
                    StartCoroutine(多次释放神通(攻击特效Type.玄女神通,5,0.1f));
                    mySequence.AppendInterval(0.5f);
                    break;
                case HeroType.丹童:
                    FightController.S.人物神通(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助,瑶池神通time);
                    mySequence.AppendInterval(0.5f);
                    break;
                case HeroType.土地:
                    FightController.S.人物神通(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助,瑶池神通time);
                    mySequence.AppendInterval(0.5f);
                    break;
                case HeroType.河伯:
                    FightController.S.人物神通(heroType,transform.position,dir,targetPos,瑶池冰辅助,妲己黑暗辅助,女娲电辅助,瑶池神通time);
                    mySequence.AppendInterval(0.5f);
                    break;
                case HeroType.瑶池仙女:
                    FightController.S.瑶池冰神通();
                    mySequence.AppendInterval(0.5f);
                    break;
            }
        });
        mySequence.Append(transform.DOMove(原始Pos,0.15f));
        mySequence.AppendCallback(() =>
        {
            是否在神通 = false;
        });

    }

    IEnumerator 盘古拳(float waitTime, int count)
    {
        上场 = true;
        while (count > 0)
        {
            盘古出拳次数++;
            count--;
            // 实时获取当前目标怪物位置
            var monsterBase = FightController.S.GetAttackMonster();
            Vector2 monstertrans = monsterBase.transform.position;
            if (!攻击范围内怪物.Contains(monsterBase))
            {
                continue;
            }
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

    public void 上场技能(攻击特效Type Type,Vector2 finalPos,float Time,bool 放大缩小,bool 是否神通,int count=0)
    {
        上场 = true;
        Sequence mySequence = DOTween.Sequence();
        if (是否神通)
        {
           mySequence.AppendInterval(0.5f); 
        }
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
                    黑暗抓痕.脚本.瑶池神通 = 瑶池神通time>0;
                    黑暗抓痕.脚本.是否神通 = false;

                    黑暗抓痕.gameObject.SetActive(true);
                    黑暗抓痕Animator.Play("187黑暗抓痕_Anim",0,0f);
                    break;
                case 攻击特效Type.牛魔王技能:
                    牛魔王脚本.瑶池冰辅助 = 瑶池冰辅助>0;
                    牛魔王脚本.黑暗辅助 = 妲己黑暗辅助>0;
                    牛魔王脚本.女娲电辅助 = 女娲电辅助>0;
                    牛魔王脚本.瑶池神通 = 瑶池神通time>0;
                    牛魔王脚本.是否神通 = false;

                    牛魔王技能Obj.gameObject.SetActive(true);
                    牛魔王技能Animator.Play("219牛魔王技能_Anim",0,0f);
                    break;
                case 攻击特效Type.石敢当神通:
                    石敢当神通脚本.瑶池冰辅助 = 瑶池冰辅助>0;
                    石敢当神通脚本.黑暗辅助 = 妲己黑暗辅助>0;
                    石敢当神通脚本.女娲电辅助 = 女娲电辅助>0;
                    石敢当神通脚本.瑶池神通 = 瑶池神通time>0;
                    石敢当神通脚本.是否神通 = true;

                    石敢当神通Obj.gameObject.SetActive(true);
                    break;
                case 攻击特效Type.喷火:
                    喷火.瑶池冰辅助 = 瑶池冰辅助>0;
                    喷火.黑暗辅助 = 妲己黑暗辅助>0;
                    喷火.女娲电辅助 = 女娲电辅助>0;
                    喷火.瑶池神通 = 瑶池神通time>0;
                    喷火.是否神通 = false;

                    喷火Obj.gameObject.SetActive(true);
                    ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.哪吒);
                    喷火Animator.Play("114喷火_Anim",0,0f);
                    break;
                case 攻击特效Type.孙悟空棒子:
                    孙悟空下场次数++;
                    棒子.下场次数 = 孙悟空下场次数;
                    棒子.瑶池冰辅助 = 瑶池冰辅助>0;
                    棒子.黑暗辅助 = 妲己黑暗辅助>0;
                    棒子.女娲电辅助 = 女娲电辅助>0;
                    棒子.瑶池神通 = 瑶池神通time>0;

                    StartCoroutine(棒子.孙悟空攻击(count));
                    break;
                case 攻击特效Type.火球:
                    ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.元始);
                    switch (count)
                    {
                        case 3:
                            火球3.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球3.黑暗辅助 = 妲己黑暗辅助>0;
                            火球3.女娲电辅助 = 女娲电辅助>0;
                            火球3.瑶池神通 = 瑶池神通time>0;

                            火球3.RotateSpeed = 300;
                            火球3.gameObject.SetActive(true);
                            break;
                        case 4:
                            火球4.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球4.黑暗辅助 = 妲己黑暗辅助>0;
                            火球4.女娲电辅助 = 女娲电辅助>0;
                            火球4.瑶池神通 = 瑶池神通time>0;

                            火球4.RotateSpeed = 300;
                            火球4.gameObject.SetActive(true);
                            break;
                        case 5:
                            火球5.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球5.黑暗辅助 = 妲己黑暗辅助>0;
                            火球5.女娲电辅助 = 女娲电辅助>0;
                            火球5.瑶池神通 = 瑶池神通time>0;

                            火球5.RotateSpeed = 300;
                            火球5.gameObject.SetActive(true);
                            break;
                        case 6:
                            火球6.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球6.黑暗辅助 = 妲己黑暗辅助>0;
                            火球6.女娲电辅助 = 女娲电辅助>0;
                            火球6.瑶池神通 = 瑶池神通time>0;

                            火球6.RotateSpeed = 300;
                            火球6.gameObject.SetActive(true);
                            break;
                        case 7:
                            火球7.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球7.黑暗辅助 = 妲己黑暗辅助>0;
                            火球7.女娲电辅助 = 女娲电辅助>0;
                            火球7.瑶池神通 = 瑶池神通time>0;

                            火球7.RotateSpeed = 300;
                            火球7.gameObject.SetActive(true);
                            break;
                        case 8:
                            火球8.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球8.黑暗辅助 = 妲己黑暗辅助>0;
                            火球8.女娲电辅助 = 女娲电辅助>0;
                            火球8.瑶池神通 = 瑶池神通time>0;

                            火球8.RotateSpeed = 300;
                            火球8.gameObject.SetActive(true);
                            break;
                        case 9:
                            火球9.瑶池冰辅助 = 瑶池冰辅助>0;
                            火球9.黑暗辅助 = 妲己黑暗辅助>0;
                            火球9.女娲电辅助 = 女娲电辅助>0;
                            火球9.瑶池神通 = 瑶池神通time>0;

                            火球9.RotateSpeed = 300;
                            火球9.gameObject.SetActive(true);
                            break;
                    }

                    if (count >= 10)
                    {
                        火球10.瑶池冰辅助 = 瑶池冰辅助>0;
                        火球10.黑暗辅助 = 妲己黑暗辅助>0;
                        火球10.女娲电辅助 = 女娲电辅助>0;
                        火球10.瑶池神通 = 瑶池神通time>0;

                        火球10.RotateSpeed = 300;
                        火球10.gameObject.SetActive(true);
                    }
                    break;
            }
        });
        mySequence.AppendInterval(Time);
        mySequence.AppendCallback(() =>
        {
            if (heroType == HeroType.元始)
            {
                ObserverModuleManager.S.SendEvent("停止元始音效");
            }
        });
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
        if (HeroConfig.HeroZhiYeDic[heroType].zhiYeType == ZhiYeType.战士 &&
            PlayerData.S.HeroDataDic[heroType].功法Type != 功法Type.None)
        {
            scale+=功法Config.功法属性Dic[PlayerData.S.HeroDataDic[heroType].功法Type].count;
        }
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
