using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 序列一次伤害动画脚本 : MonoBehaviour
{
    public GameObject Obj;
    public 攻击特效Type type;
    public Collider2D _collider2D;

    public void Hide()
    {
        switch (type)
        {
            case 攻击特效Type.冰刺:
                QueueController.S.冰刺Queue.Enqueue(Obj);
                gameObject.SetActive(false);
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
               FightController.S.MonsterColliderDic[col].Hurt(50,YuanSuType.冰);
            }
        }
    }

}
