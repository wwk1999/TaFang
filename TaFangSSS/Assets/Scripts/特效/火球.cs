using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 火球 : MonoBehaviour
{
    public 攻击特效Type Type;
    [NonSerialized] public float damage;
    [NonSerialized] public HeroType HeroType=HeroType.元始;

    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized] public bool 女娲电辅助;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 获取两个碰撞器之间的最近点（世界坐标）
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster"))
        {
            var hit = FightController.S.GetPeng(Type);
            hit.transform.position = closestPoint;
            float realDamage = damage;
            if (黑暗辅助)
            {
                if (PlayerData.S.HeroDataDic[HeroType.妲己].功法Type != 功法Type.None)
                {
                    realDamage *= (1 + PlayerData.S.HeroDataDic[HeroType.妲己].功法等级 *
                        功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.妲己].功法Type]] /
                        100f);
                }
                realDamage *= (1+英雄星级属性.妲己效果/100f);
            }
            if (女娲电辅助)
            {
                if (PlayerData.S.HeroDataDic[HeroType.女娲].功法Type != 功法Type.None)
                {
                    realDamage *= (1 + PlayerData.S.HeroDataDic[HeroType.女娲].功法等级 *
                        功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.女娲].功法Type]] /
                        100f);
                }
                realDamage*=(1+英雄星级属性.女娲辅助伤害/100f);
            }

            if (瑶池冰辅助)
            {
                if (PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type != 功法Type.None)
                {
                    realDamage *= (1 + PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法等级 *
                        功法Config.辅助功法升级奖励Dic[功法Config.功法TypeQualityDic[PlayerData.S.HeroDataDic[HeroType.瑶池仙女].功法Type]] /
                        100f);
                }
            }
            if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
            {
                realDamage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
            }
            QueueController.S.MonsterColliderDic[other].Hurt(realDamage,HeroType);
            hit.gameObject.SetActive(true);
            
            if (瑶池冰辅助)
            {
                QueueController.S.MonsterColliderDic[other].瑶池冰辅助 = 2;//持续2s
            }
           
        }
    }
}
