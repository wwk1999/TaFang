using System;
using System.Collections;
using System.Collections.Generic;
using Config;
using UnityEngine;

public class 火球 : MonoBehaviour
{
    public 攻击特效Type Type;
    [NonSerialized] public float damage;
    [NonSerialized] public YuanSuType YuanSuType=YuanSuType.火;
    [NonSerialized] public bool 瑶池冰辅助;
    [NonSerialized] public bool 黑暗辅助;
    
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
                realDamage *= 1.2f;
            }
            FightController.S.MonsterColliderDic[other].Hurt(realDamage,YuanSuType);
            hit.gameObject.SetActive(true);
            
            if (瑶池冰辅助)
            {
                FightController.S.MonsterColliderDic[other].瑶池冰辅助 = 2;//持续2s
            }
            if (Type == 攻击特效Type.黑暗魔法弹)
            {
                FightController.S.MonsterColliderDic[other].transform.position = new Vector3(FightController.S.MonsterColliderDic[other].transform.position.x+0.2f,FightController.S.MonsterColliderDic[other].transform.position.y,FightController.S.MonsterColliderDic[other].transform.position.z);
            }
        }
    }
}
