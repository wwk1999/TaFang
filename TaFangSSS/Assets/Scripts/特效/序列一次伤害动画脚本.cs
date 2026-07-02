using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 序列一次伤害动画脚本 : MonoBehaviour
{
    public 序列一次伤害技能 Obj;
    public 攻击特效Type type;
    public Collider2D _collider2D;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    [NonSerialized] public float damage;
    [NonSerialized] public YuanSuType YuanSuType;

    public void Hide()
    {
        gameObject.SetActive(false);
        switch (type)
        {
            case 攻击特效Type.嫦娥技能:
                QueueController.S.嫦娥技能Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.冰刺:
                QueueController.S.冰刺Queue.Enqueue(Obj);
                break;
            case 攻击特效Type.玄女技能:
                QueueController.S.冰刺Queue.Enqueue(Obj);
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
        // 检测所有重叠的碰撞体
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = true;
    
        _collider2D.OverlapCollider(filter, results);
    
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

                if (type == 攻击特效Type.龟丞相技能)
                {
                    FightController.S.MonsterColliderDic[col].龟丞相减速 = 2;
                }
                if (type == 攻击特效Type.黑暗符)
                {
                    FightController.S.MonsterColliderDic[col].Set黑暗符(英雄星级属性.琼霄定身时长);
                }

                if (黑暗辅助)
                {
                    damage *= (1+英雄星级属性.妲己效果/100);
                }
               FightController.S.MonsterColliderDic[col].Hurt(damage,YuanSuType);
            }
        }
    }

}
