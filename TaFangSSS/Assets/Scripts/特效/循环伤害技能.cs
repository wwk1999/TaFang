using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

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
    [NonSerialized] public float 伤害间隔=0.2f;
    [NonSerialized] public float 当前伤害时间=0;
    [NonSerialized] public bool 女娲电辅助;

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
                realDamage *= (1+英雄星级属性.妲己效果/100);
            }
            if (女娲电辅助)
            {
                damage*=(1+英雄星级属性.女娲辅助伤害/100f);
            }
            if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
            {
                damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
            }

            float scale = (transform.localScale.x - 1) / 0.01f * 属性config.总属性.老子体积增伤;
            damage *= (1 + scale);
            QueueController.S.MonsterColliderDic[other].Hurt(realDamage, HeroType);
            hit.gameObject.SetActive(true);
            if (瑶池冰辅助)
            {
                QueueController.S.MonsterColliderDic[other].瑶池冰辅助 = 2; //持续2s
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        当前伤害时间+=Time.deltaTime;
        if (当前伤害时间 >= 伤害间隔)
        {
            当前伤害时间 = 0;
        }
        else
        {
            return;
        }
        Vector2 closestPoint = other.ClosestPoint(transform.position);
        if (other.CompareTag("Monster"))
        {
            var hit = FightController.S.GetPeng(Type);
            hit.transform.position = closestPoint;
            float realDamage = damage;
            if (黑暗辅助)
            {
                realDamage *= 1.2f;
            }
            if (瑶池冰辅助 || 女娲电辅助 || 黑暗辅助)
            {
                damage *= 属性config.总属性.辅助被辅助英雄伤害增幅;
            }

            QueueController.S.MonsterColliderDic[other].Hurt(realDamage, HeroType);
            hit.gameObject.SetActive(true);
            if (瑶池冰辅助)
            {
                QueueController.S.MonsterColliderDic[other].瑶池冰辅助 = 2; //持续2s
            }
        }
    }
}
