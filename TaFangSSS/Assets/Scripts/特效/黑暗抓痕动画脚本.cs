using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 黑暗抓痕动画脚本 : MonoBehaviour
{
    public GameObject obj;
    public Collider2D _collider2D1;
    public Collider2D _collider2D2;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    public HeroType heroType;
    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 瑶池神通;
    [NonSerialized] public bool 妲己神通;
    [NonSerialized] public bool 女娲神通;
    [NonSerialized] public bool 是否神通;
    [NonSerialized] public 攻击特效Type type;

    // 碰撞查询复用缓冲：每个池化实例一份，首次使用时分配，之后零 GC
    private readonly List<Collider2D> _resultsBuffer = new List<Collider2D>(128);
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

    public void 播放广木天王音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.广目天王);
    }

    public void 播放牛魔王音效()
    {
        if (FightController.S.关卡游戏时长 < 2) return;
        ObserverModuleManager.S.SendEvent("播放人物音效",战斗音效Type.牛魔王);
    }

    public void Hide()
    {
        obj.gameObject.SetActive(false);
    }

    // ============ 动画事件入口（方法名保持不变，动画文件无需改动） ============
    public void CheckCollisionWithMonsters1() => HandleCollision(_collider2D1);
    public void CheckCollisionWithMonsters2() => HandleCollision(_collider2D2);

    private void HandleCollision(Collider2D collider)
    {
        if (collider == null) return;
        InitFilter();

        _resultsBuffer.Clear();
        collider.OverlapCollider(_monsterFilter, _resultsBuffer);
        if (_resultsBuffer.Count == 0) return;

        // ---- 循环外：基础伤害与所有加成只算一次 ----
        float damage = 是否神通
            ? 属性config.总属性.总攻击力 * HeroConfig.英雄神通配置Dic[heroType].damage / 100f
            : 属性config.总属性.总攻击力 * 英雄星级属性.Get英雄攻击数值(heroType) / 100f;

        // 辅助功法加成已移入 MonsterBase.计算功法伤害：与被辅助英雄功法相加后统一乘一次，不再各自乘算
        if (黑暗辅助)
        {
            damage *= (1 + 英雄星级属性.妲己效果 / 100f);
        }
        if (女娲电辅助)
        {
            damage *= (1 + 英雄星级属性.女娲辅助伤害 / 100f);
        }
        if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
        {
            damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
        }

        float 冰冻概率 = 瑶池神通 ? HeroConfig.英雄神通配置Dic[heroType].damage : 0f;
        var monsterDic = QueueController.S.MonsterColliderDic;

        foreach (Collider2D col in _resultsBuffer)
        {
            if (!monsterDic.TryGetValue(col, out var monster)) continue;

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
            monster.妲己神通 = 妲己神通;
            monster.女娲神通 = 女娲神通;
            monster.妲己黑暗辅助 = 黑暗辅助;
            monster.女娲电辅助 = 女娲电辅助;

            monster.Hurt(damage, heroType, type);
        }
    }
}
