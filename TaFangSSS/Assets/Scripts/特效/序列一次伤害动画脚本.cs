using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 序列一次伤害动画脚本 : MonoBehaviour
{
    public 序列一次伤害技能 Obj;
    public 攻击特效Type type;
    public Collider2D _collider2D;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized] public bool 瑶池神通;
    [NonSerialized] public float damage;
    [NonSerialized] public HeroType HeroType;
    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 是否神通;

    

    public void 播放碧霄音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.碧霄);
    }
    public void 播放琼霄音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.琼霄);
    }
    
    public void 播放嫦娥音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.嫦娥);
    }
    public void 播放雷震子音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.雷震子);
    }
    public void 播放河伯音效1()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.河伯1);
    }
    public void 播放河伯音效2()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.河伯2);
    }
    public void 播放龟丞相音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.龟丞相);
    }
    public void 播放玄女音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.玄女);
    }
    public void Hide()
    {
        Obj.gameObject.SetActive(false);
        switch (type)
        {
            case 攻击特效Type.多闻天王神通:
                QueueController.S.多闻天王神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.雷震子神通:
                QueueController.S.雷震子神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.玄女神通:
                QueueController.S.玄女神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.嫦娥技能:
                QueueController.S.嫦娥技能Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.冰刺:
                QueueController.S.冰刺Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.玄女技能:
                QueueController.S.玄女技能Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.龟丞相技能:
                QueueController.S.龟丞相技能Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.落雷:
                QueueController.S.落雷Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.冰龙:
                QueueController.S.冰龙Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.黑暗符:
                QueueController.S.黑暗符Queue.Enqueue(Obj);
                break;
        }
    }
    public void CheckCollisionWithMonsters()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    QueueController.S.MonsterColliderDic[col].瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
                }
                if (瑶池神通)
                {
                    var random = Random.Range(0, 100f);
                    if (random < HeroConfig.英雄神通配置Dic[HeroType].damage)
                    {
                        QueueController.S.MonsterColliderDic[col].冰冻time = 1;
                    }
                }

                if (type == 攻击特效Type.龟丞相技能)
                {
                    QueueController.S.MonsterColliderDic[col].龟丞相减速 = 2;
                }
                if (type == 攻击特效Type.黑暗符)
                {
                    QueueController.S.MonsterColliderDic[col].Set黑暗符(英雄星级属性.琼霄定身时长);
                }

                if (黑暗辅助)
                {
                    if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                    {
                        damage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                            功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                            100f);
                    }
                    damage *= (1+英雄星级属性.妲己效果/100);
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

}
