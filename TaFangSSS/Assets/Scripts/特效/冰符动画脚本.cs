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
    [NonSerialized] public bool 妲己神通;
    [NonSerialized] public bool 女娲神通;

    [NonSerialized]public float damage;
    [NonSerialized]public HeroType HeroType;
    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 瑶池神通;

    // 碰撞查询复用缓冲：每个池化实例一份，首次使用时分配，之后零 GC
    private readonly List<Collider2D> _resultsBuffer = new List<Collider2D>(128);
    // 只检测 Monster 层（Layer 7），所有实例共享同一份过滤设置
    private static ContactFilter2D _monsterFilter;
    private static bool _filterInited;

    private static void InitFilter()
    {
        if (_filterInited) return;
        _monsterFilter = new ContactFilter2D();
        _monsterFilter.useTriggers = true;
        int monsterLayer = LayerMask.NameToLayer("Monster");
        _monsterFilter.SetLayerMask(new LayerMask { value = 1 << monsterLayer });
        _filterInited = true;
    }

    public Vector2 Get随机怪物位置()
    {
        switch (Type)
        {
            case 攻击特效Type.嫦娥神通:
                var 人物item = FightController.S.人物items[HeroType.嫦娥];
                return 人物item.Get随机怪物位置();
            case 攻击特效Type.云霄神通:
                var 人物item1 = FightController.S.人物items[HeroType.云霄];
                return 人物item1.Get随机怪物位置();
        }

        return new Vector2(0, 0);
    }

    public void 改变到随机怪物位置()
    {
        obj.transform.position = Get随机怪物位置();
    }

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

    // ============ 动画事件入口（方法名保持不变，动画文件无需改动） ============
    // 1、2 号碰撞体对应琼霄神通的定身帧，需要额外设置黑暗符
    public void CheckCollisionWithMonsters1()  => HandleCollision(_collider2D1, true);
    public void CheckCollisionWithMonsters2()  => HandleCollision(_collider2D2, true);
    public void CheckCollisionWithMonsters3()  => HandleCollision(_collider2D3, false);
    public void CheckCollisionWithMonsters4()  => HandleCollision(_collider2D4, false);
    public void CheckCollisionWithMonsters5()  => HandleCollision(_collider2D5, false);
    public void CheckCollisionWithMonsters6()  => HandleCollision(_collider2D6, false);
    public void CheckCollisionWithMonsters7()  => HandleCollision(_collider2D7, false);
    public void CheckCollisionWithMonsters8()  => HandleCollision(_collider2D8, false);
    public void CheckCollisionWithMonsters9()  => HandleCollision(_collider2D9, false);
    public void CheckCollisionWithMonsters10() => HandleCollision(_collider2D10, false);

    /// <summary>
    /// 统一碰撞处理：collider 为本次事件对应的碰撞体，琼霄定身 仅 1/2 号事件为 true
    /// </summary>
    private void HandleCollision(Collider2D collider, bool 琼霄定身)
    {
        if (collider == null) return;
        InitFilter();

        _resultsBuffer.Clear();
        collider.OverlapCollider(_monsterFilter, _resultsBuffer);
        if (_resultsBuffer.Count == 0) return;

        // ---- 循环外：所有与具体怪物无关的伤害加成只算一次 ----
        // 注意：不能写回 damage 字段，否则同一次施法的多个碰撞事件、多只怪物之间会滚雪球累乘
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
            finalDamage *= (1f + 英雄星级属性.妲己效果 / 100f);
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

        // ---- 循环外：与怪物无关的常量提前算好 ----
        bool 是冰符 = Type == 攻击特效Type.冰符;
        bool 是火符 = Type == 攻击特效Type.火符;
        float 灼烧伤害值 = 是火符 ? 英雄星级属性.羲和灼烧伤害 / 100f * 属性config.总属性.总攻击力 : 0f;
        float 冰冻概率 = 瑶池神通 ? HeroConfig.英雄神通配置Dic[HeroType].damage : 0f;

        var monsterDic = QueueController.S.MonsterColliderDic;

        foreach (Collider2D col in _resultsBuffer)
        {
            // LayerMask 已保证只有 Monster 层，TryGetValue 兜底已死亡/未注册的碰撞体
            if (!monsterDic.TryGetValue(col, out var monster)) continue;

            if (琼霄定身&&Type==攻击特效Type.琼霄神通)
            {
                monster.黑暗符 = 1f;
            }
            if (瑶池冰辅助)
            {
                monster.瑶池冰辅助 = 2;
            }
            if (瑶池神通)
            {
                if (Random.Range(0, 100f) < 冰冻概率)
                {
                    monster.冰冻time = 1;
                }
            }
            if (是冰符)
            {
                monster.冰符 = 2;
            }
            if (是火符)
            {
                monster.Set灼烧伤害(灼烧伤害值);
                monster.灼烧time = 3f;
            }

            monster.女娲神通 = 女娲神通;
            monster.妲己神通 = 妲己神通;
            monster.妲己黑暗辅助 = 黑暗辅助;
            monster.女娲电辅助 = 女娲电辅助;

            monster.Hurt(finalDamage, HeroType, Type);
        }
    }
}
