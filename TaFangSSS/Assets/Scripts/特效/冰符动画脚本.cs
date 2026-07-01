using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 冰符动画脚本: MonoBehaviour
{
    public 攻击特效Type Type;
    public 冰符 obj;
    public Collider2D _collider2D1;
    public Collider2D _collider2D2;
    public Collider2D _collider2D3;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized]public float damage;
    [NonSerialized]public YuanSuType YuanSuType;


    public void Hide()
    {
        switch (Type)
        {
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
    public void CheckCollisionWithMonsters3()
    {
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D3.OverlapCollider(filter, results);
    
        // 找出所有怪物并处理
        foreach (Collider2D col in results)
        {
            if (col.gameObject == gameObject) continue;
        
            if (col.CompareTag("Monster"))
            {
                if (瑶池冰辅助)
                {
                    FightController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (Type==攻击特效Type.冰符)
                {
                    FightController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    FightController.S.MonsterColliderDic[col].灼烧伤害 = 英雄星级属性.羲和灼烧伤害*属性config.领主攻击力;
                    FightController.S.MonsterColliderDic[col].灼烧time = 3f;
                }

                if (黑暗辅助)
                {
                    damage *= (1f+英雄星级属性.妲己效果/100f);
                }
                
                FightController.S.MonsterColliderDic[col].Hurt(damage,YuanSuType);
            }
        }
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
                    FightController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (Type==攻击特效Type.冰符)
                {
                    FightController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    FightController.S.MonsterColliderDic[col].灼烧伤害 = 9;
                    FightController.S.MonsterColliderDic[col].灼烧time = 2f;
                }

                float damage = 50;
                if (黑暗辅助)
                {
                    damage *= 1.2f;
                }
                
                FightController.S.MonsterColliderDic[col].Hurt(damage,YuanSuType.冰);
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
                    FightController.S.MonsterColliderDic[col].瑶池冰辅助 = 2;
                }
                if (Type==攻击特效Type.冰符)
                {
                    FightController.S.MonsterColliderDic[col].冰符 = 2;
                }
                if (Type==攻击特效Type.火符)
                {
                    FightController.S.MonsterColliderDic[col].灼烧伤害 = 9;
                    FightController.S.MonsterColliderDic[col].灼烧time = 2f;
                }
                float damage = 50;
                if (黑暗辅助)
                {
                    damage *= 1.2f;
                }
                FightController.S.MonsterColliderDic[col].Hurt(damage,YuanSuType.冰);
            }
        }
    }
}
