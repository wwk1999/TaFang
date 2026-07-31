using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 黑暗抓痕动画脚本 : MonoBehaviour
{
    public GameObject obj;
    public Collider2D _collider2D1;
    public Collider2D _collider2D2;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    public HeroType heroType;
    [NonSerialized] public bool 女娲电辅助;


    public void Hide()
    {
        obj.gameObject.SetActive(false);
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

                float damage = 属性config.领主攻击力*英雄星级属性.Get英雄攻击数值(heroType)/100f;
                if (黑暗辅助)
                {
                    damage *= (1+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }
                
                QueueController.S.MonsterColliderDic[col].Hurt(damage,heroType);
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

                float damage = 属性config.领主攻击力*英雄星级属性.Get英雄攻击数值(heroType)/100f;
                if (黑暗辅助)
                {
                    damage *= (1+英雄星级属性.妲己效果/100f);
                }
                if (女娲电辅助)
                {
                    damage*=(1+英雄星级属性.女娲辅助伤害/100f);
                }
                if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
                {
                    damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
                }
                QueueController.S.MonsterColliderDic[col].Hurt(damage,heroType);
            }
        }
    }
}
