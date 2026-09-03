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

    private void OnEnable()
    {
        alltime = 0;
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
        alltime+=Time.deltaTime;
        transform.position += (Vector3)MoveDirection * MoveSpeed*英雄星级属性.老子弹道速度 * Time.deltaTime;
        if (Type == 攻击特效Type.冰旋风)
        {
            transform.localScale = new Vector3(1+alltime*英雄星级属性.老子增长速度/100f, 1+alltime*英雄星级属性.老子增长速度/100f, transform.localScale.y);
        }
    }

    /// <summary>
    /// 辅助英雄（妲己/女娲/瑶池）伤害加成，与怪物无关，每次命中算一次，不写回 damage 字段
    /// </summary>
    private float 计算辅助加成(float baseDamage)
    {
        float finalDamage = baseDamage;
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
        return finalDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Monster")) return;
        if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

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

    private void OnTriggerStay2D(Collider2D other)
    {
        当前伤害时间+=Time.deltaTime;
        if (当前伤害时间 < 伤害间隔)
        {
            return;
        }
        当前伤害时间 = 0;

        if (!other.CompareTag("Monster")) return;
        if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

        Vector2 closestPoint = other.ClosestPoint(transform.position);
        var hit = FightController.S.GetPeng(Type);
        hit.transform.position = closestPoint;

        float finalDamage = 计算辅助加成(damage);

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
