using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 黑暗印记爆炸动画脚本 : MonoBehaviour
{
    public Collider2D _collider2D;
    public 黑暗印记爆炸 黑暗印记爆炸;
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

    public void CheckCollisionWithMonsters()
    {
        if (_collider2D == null) return;
        InitMonsterFilter();

        _resultsBuffer.Clear();
        _collider2D.OverlapCollider(_monsterFilter, _resultsBuffer);
        if (_resultsBuffer.Count == 0) return;

        // ---- 循环外：与具体怪物无关的伤害加成只算一次（不写回 damage 字段，避免多怪物/多事件滚雪球） ----
        float finalDamage = 黑暗印记爆炸.damage;
        // 辅助功法加成已移入 MonsterBase.计算功法伤害：与被辅助英雄功法相加后统一乘一次，不再各自乘算
        
        var monsterDic = QueueController.S.MonsterColliderDic;

        foreach (Collider2D col in _resultsBuffer)
        {
            if (!monsterDic.TryGetValue(col, out var monster)) continue;
            monster.Hurt(finalDamage, 黑暗印记爆炸.HeroType, 攻击特效Type.黑暗印记爆炸);
        }
    }
}
