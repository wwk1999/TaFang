using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 冰符动画脚本: MonoBehaviour
{
    public 攻击特效Type Type;
    public 冰符 obj;
    public Collider2D _collider2D1;
    public Collider2D _collider2D2;
    public Collider2D _collider2D3;
    public Collider2D _collider2D4;
    public Collider2D _collider2D5;
    public Collider2D _collider2D6;
    public Collider2D _collider2D7;
    public Collider2D _collider2D8;
    public Collider2D _collider2D9;
    public Collider2D _collider2D10;

    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized]public float damage;
    [NonSerialized]public HeroType HeroType;
    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 瑶池神通;


    public void Hide()
    {
        switch (Type)
        {
            case 攻击特效Type.土地神通:
                QueueController.S.土地神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.云霄神通:
                QueueController.S.云霄神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.嫦娥神通:
                QueueController.S.嫦娥神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.孙悟空神通:
                QueueController.S.孙悟空神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.河伯神通:
                QueueController.S.河伯神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.琼霄神通:
                QueueController.S.琼霄神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.羲和神通:
                QueueController.S.羲和神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.通天神通:
                QueueController.S.通天神通Queue.Enqueue(obj);
                break;
            case 攻击特效Type.龟丞相神通:
                QueueController.S.龟丞相神通Queue.Enqueue(obj);
                break;
            
            
            
            
            case 攻击特效Type.冰符:
                QueueController.S.冰符Queue.Enqueue(obj);
                break;
            case 攻击特效Type.火符:
                QueueController.S.火符Queue.Enqueue(obj);
                break;
            case 攻击特效Type.盘古拳:
                QueueController.S.盘古拳Queue.Enqueue(obj);
                break;
        }
        obj.gameObject.SetActive(false);
    }
    public void 播放羲和音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.羲和);
    }
    public void 播放盘古音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.盘古);
    }
    
    public void 播放常曦音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.常羲);
    }
    public void CheckCollisionWithMonsters3()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D3.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
    public void CheckCollisionWithMonsters2()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D2.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                    QueueController.S.MonsterColliderDic[col].妲己黑暗辅助 = 黑暗辅助;

                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                    QueueController.S.MonsterColliderDic[col].女娲电辅助 = 女娲电辅助;

                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
    public void CheckCollisionWithMonsters1()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D1.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
    
    
    
     public void CheckCollisionWithMonsters4()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D4.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
     
     public void CheckCollisionWithMonsters6()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D6.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
     public void CheckCollisionWithMonsters7()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D7.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
     public void CheckCollisionWithMonsters8()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D8.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
     public void CheckCollisionWithMonsters9()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D9.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
     public void CheckCollisionWithMonsters10()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D10.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
     
     public void CheckCollisionWithMonsters5()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D5.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }
                if (Type==攻击特效Type.冰符)
                {
                    QueueController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    QueueController.S.MonsterColliderDic[col].Set灼烧伤害(英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力);
                    QueueController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                            100f);
                    }
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }

                if (瑶池冰辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                            100f);
                    }
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,HeroType);
            }
        }
    }
}
