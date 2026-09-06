using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 循环伤害技能 : MonoBehaviour
{
    [NonSerialized]public float MoveSpeed=0;
    [NonSerialized]public Vector2 MoveDirection;
    public 攻击特效Type Type;
    [NonSerialized]public float DelayTime=15;
    [NonSerialized] public float damage;
    [NonSerialized] public HeroType HeroType;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized] public bool 妲己神通;
    [NonSerialized] public bool 女娲神通;

    [NonSerialized] public float 伤害间隔=0.2f;
    [NonSerialized] public float 当前伤害时间=0;
    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 瑶池神通;

    private float alltime=0;
    private readonly HashSet<MonsterBase> 当前范围内怪物 = new HashSet<MonsterBase>();
    private readonly List<MonsterBase> _伤害快照 = new List<MonsterBase>();

    private void OnEnable()
    {
        alltime = 0;
        当前伤害时间 = 0;
        当前范围内怪物.Clear();
        CancelInvoke();
        Invoke(nameof(Hide), DelayTime);
    }

    public void Hide()
    {
        switch (Type)
        {
            case 攻击特效Type.冰旋风:
                QueueController.S.冰旋风Queue.Enqueue(this);
                break;
        }
        gameObject.SetActive(false);
    }

    private void Update()
    {
        alltime += Time.deltaTime;
        transform.position += (Vector3)MoveDirection * MoveSpeed * 英雄星级属性.老子弹道速度 * Time.deltaTime;
        if (Type == 攻击特效Type.冰旋风)
        {
            transform.localScale = new Vector3(1 + alltime * 英雄星级属性.老子增长速度 / 100f, 1 + alltime * 英雄星级属性.老子增长速度 / 100f, transform.localScale.y);
        }

        // 计时器只在 Update 里累加一次，避免多怪物时 N 倍速计时
        if (当前范围内怪物.Count > 0)
        {
            当前伤害时间 += Time.deltaTime;
            if (当前伤害时间 >= 伤害间隔)
            {
                当前伤害时间 = 0;
                对范围内所有怪物循环伤害();
            }
        }
    }

    /// <summary>
    /// 对当前范围内所有怪物施加一次循环伤害（OnTriggerStay2D 改从 Update 批量触发）
    /// </summary>
    private void 对范围内所有怪物循环伤害()
    {
        if (当前范围内怪物.Count == 0) return;

        float finalDamage = 计算辅助加成(damage);

        // 用复用的 List 快照，避免每次伤害都 new List 产生 GC
        _伤害快照.Clear();
        _伤害快照.AddRange(当前范围内怪物);
        foreach (var monster in _伤害快照)
        {
            if (monster == null || monster.isDead)
            {
                当前范围内怪物.Remove(monster);
                continue;
            }

            Vector2 closestPoint = monster.Collider2D.ClosestPoint(transform.position);
            var hit = FightController.S.GetPeng(Type);
            hit.transform.position = closestPoint;

            if (瑶池冰辅助)
            {
                monster.瑶池冰辅助 = 英雄星级属性.瑶池仙女持续时间;
            }
            monster.女娲电辅助 = 女娲电辅助;
            monster.妲己黑暗辅助 = 黑暗辅助;

            monster.Hurt(finalDamage, HeroType, Type);
            hit.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 辅助英雄（妲己/女娲/瑶池）伤害加成，与怪物无关，每次命中算一次，不写回 damage 字段
    /// </summary>
    private float 计算辅助加成(float baseDamage)
    {
        float finalDamage = baseDamage;
        // 辅助功法加成已移入 MonsterBase.计算功法伤害：与被辅助英雄功法相加后统一乘一次，不再各自乘算

        if (黑暗辅助)
        {
            finalDamage *= (1 + 英雄星级属性.妲己效果 / 100f);
        }
        if (女娲电辅助)
        {
            finalDamage *= (1 + 英雄星级属性.女娲辅助伤害 / 100f);
        }
        if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
        {
            finalDamage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
        }
        return finalDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Monster")) return;
        if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

        // 同一怪物的首次命中（进入范围时立即打一次），之后靠 Update 定时器循环伤害
        if (当前范围内怪物.Add(monster) == false) return;

        Vector2 closestPoint = other.ClosestPoint(transform.position);
        var hit = FightController.S.GetPeng(Type);
        hit.transform.position = closestPoint;

        float finalDamage = 计算辅助加成(damage);
        // 老子冰旋风体积增伤
        float scale = (transform.localScale.x - 1) / 0.01f * 属性config.总属性.老子体积增伤;
        finalDamage *= (1 + scale);

        monster.妲己黑暗辅助 = 黑暗辅助;
        monster.女娲电辅助 = 女娲电辅助;
        monster.妲己神通 = 妲己神通;
        monster.女娲神通 = 女娲神通;

        if (瑶池神通)
        {
            if (Random.Range(0, 100f) < HeroConfig.英雄神通配置Dic[HeroType].damage)
            {
                monster.冰冻time = 1;
            }
        }
        if (瑶池冰辅助)
        {
            monster.瑶池冰辅助 = 2; //持续2s
        }

        monster.Hurt(finalDamage, HeroType, Type);
        hit.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Monster")) return;
        if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

        当前范围内怪物.Remove(monster);
    }
}
