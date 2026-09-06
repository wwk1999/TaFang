using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;
using Random = UnityEngine.Random;

public class 火球 : MonoBehaviour
{
    public 攻击特效Type Type;
    [NonSerialized] public float damage;
    [NonSerialized] public HeroType HeroType=HeroType.元始;

    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized] public bool 妲己神通;
    [NonSerialized] public bool 女娲神通;

    [NonSerialized] public bool 女娲电辅助;
    [NonSerialized] public bool 瑶池神通;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Monster")) return;
        if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        var hit = FightController.S.GetPeng(Type);
        hit.transform.position = closestPoint;

        float realDamage = damage;
        // 辅助功法加成已移入 MonsterBase.计算功法伤害：与被辅助英雄功法相加后统一乘一次，不再各自乘算
        if (黑暗辅助)
        {
            realDamage *= (1 + 英雄星级属性.妲己效果 / 100f);
        }
        if (女娲电辅助)
        {
            realDamage *= (1 + 英雄星级属性.女娲辅助伤害 / 100f);
        }
        if (瑶池神通)
        {
            if (Random.Range(0, 100f) < HeroConfig.英雄神通配置Dic[HeroType].damage)
            {
                monster.冰冻time = 1;
            }
        }
        monster.女娲神通 = 女娲神通;
        monster.妲己神通 = 妲己神通;
        monster.妲己黑暗辅助 = 黑暗辅助;
        monster.女娲电辅助 = 女娲电辅助;
        // 瑶池辅助计时需在Hurt前赋值，当次命中的辅助功法加成才会在Hurt中生效
        if (瑶池冰辅助)
        {
            monster.瑶池冰辅助 = 2;//持续2s
        }

        if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
        {
            realDamage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
        }
        monster.Hurt(realDamage, HeroType, Type);
        hit.gameObject.SetActive(true);
    }
}
