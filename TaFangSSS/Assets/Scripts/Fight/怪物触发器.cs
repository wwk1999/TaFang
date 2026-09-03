using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 怪物触发器 : MonoBehaviour
{
    public int 编号;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Monster")) return;
        if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

        FightController.S.Monster分区Dic[编号].Add(monster);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Monster")) return;
        if (!QueueController.S.MonsterColliderDic.TryGetValue(other, out var monster)) return;

        FightController.S.Monster分区Dic[编号].Remove(monster);
    }
}
