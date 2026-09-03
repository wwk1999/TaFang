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
    [NonSerialized] public bool 妲己神通;
    [NonSerialized] public bool 女娲神通;

    [NonSerialized] public bool 瑶池神通;
    [NonSerialized] public float damage;
    [NonSerialized] public HeroType HeroType;
    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 是否神通;

    // 碰撞查询复用缓冲：每个池化实例一份，首次使用时分配，之后零 GC
    private readonly List<Collider2D> _resultsBuffer = new List<Collider2D>(128);
    // 只检测 Monster 层（Layer 7），所有特效脚本共享同一份过滤设置
    private static ContactFilter2D _monsterFilter;
    private static bool _filterInited;

    public static void InitMonsterFilter()
    {
        if (_filterInited) return;
        _monsterFilter = new ContactFilter2D();
        _monsterFilter.useTriggers = true;
        int monsterLayer = LayerMask.NameToLayer("Monster");
        _monsterFilter.SetLayerMask(new LayerMask { value = 1 << monsterLayer });
        _filterInited = true;
    }

    
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
            case 攻击特效Type.老子神通:
                QueueController.S.老子神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.常曦神通:
                QueueController.S.常曦神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.元始神通:
                QueueController.S.元始神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.盘古神通:
                QueueController.S.盘古神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.鸿钧神通:
                QueueController.S.鸿钧神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.碧霄神通:
                QueueController.S.碧霄神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.哪吒神通:
                QueueController.S.哪吒神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.杨戬神通:
                QueueController.S.杨戬神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.多闻天王神通:
                QueueController.S.多闻天王神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.雷震子神通:
                QueueController.S.雷震子神通Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.月老神通:
                QueueController.S.月老神通Queue.Enqueue(Obj);
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
        if (_collider2D == null) return;
        InitMonsterFilter();

        _resultsBuffer.Clear();
        _collider2D.OverlapCollider(_monsterFilter, _resultsBuffer);
        if (_resultsBuffer.Count == 0) return;

        // ---- 循环外：与具体怪物无关的伤害加成只算一次（不写回 damage 字段，避免多怪物/多事件滚雪球） ----
        float finalDamage = damage;
        var playerData = PlayerData.S;

        if (黑暗辅助)
        {
            var 妲己数据 = playerData.HeroDataDic[HeroType.妲己];
            if (妲己数据.功法Type != 功法Type.None)
            {
                finalDamage *= (1 + 妲己数据.功法等级 *
                    功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[妲己数据.功法Type]] / 100f);
            }
            finalDamage *= (1 + 英雄星级属性.妲己效果 / 100f);
        }
        if (女娲电辅助)
        {
            var 女娲数据 = playerData.HeroDataDic[HeroType.女娲];
            if (女娲数据.功法Type != 功法Type.None)
            {
                finalDamage *= (1 + 女娲数据.功法等级 *
                    功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[女娲数据.功法Type]] / 100f);
            }
            finalDamage *= (1 + 英雄星级属性.女娲辅助伤害 / 100f);
        }
        if (瑶池冰辅助)
        {
            var 瑶池数据 = playerData.HeroDataDic[HeroType.瑶池仙女];
            if (瑶池数据.功法Type != 功法Type.None)
            {
                finalDamage *= (1 + 瑶池数据.功法等级 *
                    功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[瑶池数据.功法Type]] / 100f);
            }
        }
        if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
        {
            finalDamage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
        }

        bool 是龟丞相技能 = type == 攻击特效Type.龟丞相技能;
        bool 是黑暗符 = type == 攻击特效Type.黑暗符;
        float 冰冻概率 = 瑶池神通 ? HeroConfig.英雄神通配置Dic[HeroType].damage : 0f;

        var monsterDic = QueueController.S.MonsterColliderDic;

        foreach (Collider2D col in _resultsBuffer)
        {
            // LayerMask 已保证只有 Monster 层，TryGetValue 兜底已死亡/未注册的碰撞体
            if (!monsterDic.TryGetValue(col, out var monster)) continue;

            if (瑶池冰辅助)
            {
                monster.瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
            }
            if (瑶池神通)
            {
                if (Random.Range(0, 100f) < 冰冻概率)
                {
                    monster.冰冻time = 1;
                }
            }
            if (是龟丞相技能)
            {
                monster.龟丞相减速 = 2;
            }
            if (是黑暗符)
            {
                monster.Set黑暗符(英雄星级属性.琼霄定身时长);
            }

            monster.妲己神通 = 妲己神通;
            monster.女娲神通 = 女娲神通;
            monster.妲己黑暗辅助 = 黑暗辅助;
            monster.女娲电辅助 = 女娲电辅助;

            monster.Hurt(finalDamage, HeroType, type);
        }
    }

}
